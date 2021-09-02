namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class RoyaleArena : IArena
    {
        private Dictionary<int, BattleCard> cardsById;

        private SortedSet<BattleCard> cards = new SortedSet<BattleCard>();

        private SortedDictionary<string, List<BattleCard>> byType;

        public RoyaleArena()
        {
            this.cardsById = new Dictionary<int, BattleCard>();

            this.cards = new SortedSet<BattleCard>();
            this.byType = new SortedDictionary<string, List<BattleCard>>();
        }

        public double Swag { get; set; }
        public double Damage { get; set; }
        public string Name { get; private set; }
        public CardType Type { get;  set; }
        public int Id { get; private set; }

        public void Add(BattleCard card)
        {
            if (!this.cardsById.ContainsKey(card.Id))
            {
                this.cardsById.Add(card.Id, card);

                if (!byType.ContainsKey(card.Type.ToString()))
                {
                    byType.Add(card.Type.ToString(),new List<BattleCard>());
                }

                byType[card.Type.ToString()].Add(card);
            }
        }

        public bool Contains(BattleCard card)
        {
            return this.cardsById.ContainsKey(card.Id);
        }

        public int Count
        {
            get => this.cardsById.Count;
        }

        public void ChangeCardType(int id, CardType type)
        {
            if (!this.cardsById.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            string old = cardsById[id].Type.ToString();

            BattleCard toChange = this.byType[old].Find(c => c.Equals(cardsById[id]));
            this.byType[old].Remove(toChange);
            this.cardsById[id].Type = type;

            string newTyp = cardsById[id].Type.ToString();

            if (!this.byType.ContainsKey(newTyp))
            {
                byType[newTyp] = new List<BattleCard>();
            }
            byType[newTyp].Add(cardsById[id]);

        }

        public BattleCard GetById(int id)
        {
            if (!this.cardsById.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            return this.cardsById[id];
        }

        public void RemoveById(int id)
        {
            if (!this.cardsById.ContainsKey(id))
            {
                throw new InvalidOperationException();
            }

            this.cardsById.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }


        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var card in this.cardsById.Values)
            {
                yield return card;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}