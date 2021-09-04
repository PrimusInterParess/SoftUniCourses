namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class RoyaleArena : IArena
    {
        private Dictionary<int, BattleCard> cardsById;

        private SortedDeckDamage _sortedDeckDamage;

        private SortedDeckSwag _sortedDeckSwag;
        public RoyaleArena()
        {
            this.cardsById = new Dictionary<int, BattleCard>();
            this._sortedDeckDamage = new SortedDeckDamage();
            this._sortedDeckSwag = new SortedDeckSwag();

        }

        public void Add(BattleCard card)
        {
            if (!this.cardsById.ContainsKey(card.Id))
            {
                this.cardsById.Add(card.Id, card);

                this._sortedDeckDamage.Add(card);

                this._sortedDeckSwag.Add(card);

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

            this._sortedDeckDamage.ChangeType(cardsById[id], type);

            this._sortedDeckSwag.ChangeType(cardsById[id],type);

            this.cardsById[id].Type = type;

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

            BattleCard card = cardsById[id];

            this._sortedDeckDamage.Remove(card);

            this._sortedDeckSwag.Remove(card);

            this.cardsById.Remove(id);
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            return this._sortedDeckDamage.ReturnCollection(type);
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            return this._sortedDeckDamage.Range(type, lo, hi);
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            return this._sortedDeckDamage.MaxCard(type, damage);
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            return this._sortedDeckSwag.CollectionBattleCardsName(name);
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            return this._sortedDeckSwag.Range(name, lo, hi);
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            return this._sortedDeckSwag.Least(n);
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            return this._sortedDeckSwag.Range(lo, hi);
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