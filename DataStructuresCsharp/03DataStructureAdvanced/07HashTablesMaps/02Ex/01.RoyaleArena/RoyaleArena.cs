namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class RoyaleArena : IArena
    {
        private Dictionary<int, BattleCard> cardsById;
        private SortedSet<>

        public RoyaleArena()
        {
            this.cardsById = new Dictionary<int, BattleCard>();
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
            }


        }

        public bool Contains(BattleCard card)
        {

            return this.cardsById.ContainsKey(card.Id);
        }

        public int Count { get; }

        public void ChangeCardType(int id, CardType type)
        {
            throw new NotImplementedException();
        }

        public BattleCard GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
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