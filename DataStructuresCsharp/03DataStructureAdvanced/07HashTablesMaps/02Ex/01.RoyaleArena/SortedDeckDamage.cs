using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01.RoyaleArena
{
    public class SortedDeckDamage
    {
        private SortedDictionary<Enum, SortedSet<BattleCard>> deckByType;

        public SortedDeckDamage()
        {
            deckByType = new SortedDictionary<Enum, SortedSet<BattleCard>>();
        }

        public IEnumerable<BattleCard> ReturnCollection(Enum type)
        {
            if (!this.deckByType.ContainsKey(type))
            {
                throw new InvalidOperationException();
            }

            return deckByType[type];
        }

        public void Remove(BattleCard card)
        {
            this.deckByType[card.Type].Remove(card);
        }

        public void ChangeType(BattleCard card, CardType type)
        {
            this.deckByType[card.Type].Remove(card);

            card.Type = type;

            this.Add(card);
        }

        public void Add(BattleCard card)
        {
            if (!this.deckByType.ContainsKey(card.Type))
            {
                this.deckByType.Add(card.Type, new SortedSet<BattleCard>());
            }


            this.deckByType[card.Type].Add(card);
        }

        public IEnumerable<BattleCard> Range(Enum type, int lo, int hi)
        {
            if (!this.deckByType.ContainsKey(type))
            {
                throw new InvalidOperationException();
            }

            SortedSet<BattleCard> toReturn = new SortedSet<BattleCard>();

            foreach (var battleCard in deckByType[type])
            {
                if (battleCard.Damage > lo && battleCard.Damage < hi)
                {
                    toReturn.Add(battleCard);
                }
            }

            return toReturn;

        }

        public IEnumerable<BattleCard> MaxCard(CardType type, double damage)
        {

            if (!this.deckByType.ContainsKey(type))
            {
                throw new InvalidOperationException();
            }

            List<BattleCard> toReturn = new List<BattleCard>();

            foreach (var battleCard in deckByType[type])
            {
                if (battleCard.Damage <= damage)
                {
                    toReturn.Add(battleCard);
                }
            }

            return toReturn;
        }

    }
}
