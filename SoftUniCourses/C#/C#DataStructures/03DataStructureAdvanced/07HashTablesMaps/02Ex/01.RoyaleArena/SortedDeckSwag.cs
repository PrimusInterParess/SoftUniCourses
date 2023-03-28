using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace _01.RoyaleArena
{
    public class SortedDeckSwag : IEnumerable<BattleCard>, IComparer<BattleCard>
    {

        private SortedDictionary<string, SortedSet<BattleCard>> deckByType;


        public SortedDeckSwag()
        {
            deckByType = new SortedDictionary<string, SortedSet<BattleCard>>();
        }

        public void Add(BattleCard card)
        {
            if (!this.deckByType.ContainsKey(card.Name))
            {
                this.deckByType.Add(card.Name, new SortedSet<BattleCard>());
            }

            this.deckByType[card.Name].Add(card);
        }

        public void Remove(BattleCard card)
        {
            this.deckByType[card.Name].Remove(card);
        }

        public void ChangeType(BattleCard card, CardType type)
        {
            this.deckByType[card.Name].Remove(card);

            card.Type = type;

            this.Add(card);
        }

        public IEnumerable<BattleCard> CollectionBattleCardsName(string name)
        {
            if (!this.deckByType.ContainsKey(name))
            {
                throw new InvalidOperationException();
            }

            var toReturn = this.deckByType[name];

            if (toReturn.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return toReturn;
        }

        public IEnumerable<BattleCard> Range(string name, double lo, double hi)
        {
            List<BattleCard> toReturn = new List<BattleCard>();

            if (this.deckByType.ContainsKey(name))
            {
                foreach (var card in deckByType[name])
                {
                    if (card.Swag >= lo && card.Swag < hi)
                    {
                        toReturn.Add(card);
                    }
                }
            }

            if (toReturn.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return toReturn;

        }

        public IEnumerable<BattleCard> Range(double lo, double hi)
        {
           List<BattleCard> toReturn = new List<BattleCard>();

            foreach (var pair in deckByType)
            {
                foreach (var card in pair.Value)
                {
                    if (card.Swag >= lo && card.Swag < hi)
                    {
                        toReturn.Add(card);
                    }
                }

            }

            if (toReturn.Count == 0)
            {
                return toReturn;
            }

            return toReturn.OrderBy(c => c.Swag).ThenBy(D=>D.Id);

        }

        public IEnumerable<BattleCard> Least(int n)
        {
            List<BattleCard> toReturn = new List<BattleCard>();

            foreach (var VARIABLE in deckByType.Values)
            {
                toReturn.AddRange(VARIABLE);
            }

            toReturn = toReturn.OrderBy(c => c.Swag).ThenBy(c => c.Id).ToList();

            return toReturn.Take(n);

        }

        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var pair in deckByType)
            {
                foreach (var card in pair.Value)
                {
                    yield return card;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Compare(BattleCard x, BattleCard y)
        {
            int compare = x.Swag.CompareTo(y);

            if (compare == 0)
            {
                compare = y.Id.CompareTo(x.Id);
            }

            return compare;
        }
    }
}
