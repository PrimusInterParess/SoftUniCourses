using System.Linq;

namespace _01.Loader
{
    using _01.Loader.Interfaces;
    using _01.Loader.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Loader : IBuffer
    {
        private List<IEntity> list;
        private Dictionary<int, IEntity> sortedbyId;

        public Loader()
        {
            this.list = new List<IEntity>();
            this.sortedbyId = new Dictionary<int, IEntity>();
        }

        public int EntitiesCount => this.list.Count;

        public void Add(IEntity entity)
        {
            this.list.Add(entity);
            if (!this.sortedbyId.ContainsKey(entity.Id))
            {
                this.sortedbyId.Add(entity.Id, entity);

            }
        }

        public void Clear()
        {

            this.list.Clear();
            this.sortedbyId.Clear();

        }

        public bool Contains(IEntity entity)
        {
            return this.sortedbyId.ContainsKey(entity.Id);
        }

        public IEntity Extract(int id)
        {
            IEntity toReturn = null;

            if (this.sortedbyId.ContainsKey(id))
            {
                toReturn = this.sortedbyId[id];
                this.sortedbyId.Remove(id);
                int indexOf = this.list.IndexOf(toReturn);
                this.list.RemoveAt(indexOf);
            }

            return toReturn;
        }

        public IEntity Find(IEntity entity)
        {
            IEntity toReturn = null;

            if (this.sortedbyId.ContainsKey(entity.Id))
            {
                toReturn = this.sortedbyId[entity.Id];
            }

            return toReturn;
        }

        public List<IEntity> GetAll()
        {
            return new List<IEntity>(this.list);
        }



        public void RemoveSold()
        {
            this.list.RemoveAll(e => e.Status == BaseEntityStatus.Sold);
            this.sortedbyId.Values.Select(t => t.Status != BaseEntityStatus.Sold);
        }

        public void Replace(IEntity oldEntity, IEntity newEntity)
        {
            if (!this.sortedbyId.ContainsKey(oldEntity.Id))
            {
                throw new InvalidOperationException("Entity not found");
            }

            int indexOf = this.list.IndexOf(oldEntity);
            this.list[indexOf] = newEntity;
            this.sortedbyId.Remove(oldEntity.Id);
            sortedbyId.Add(newEntity.Id, newEntity);
        }

        public List<IEntity> RetainAllFromTo(BaseEntityStatus lowerBound, BaseEntityStatus upperBound)
        {
            if (this.list.Count == 0)
            {
                return new List<IEntity>();
            }

            return new List<IEntity>(this.list.Where(t => (int)t.Status >= (int)lowerBound && (int)t.Status <= (int)upperBound));
        }

        public void Swap(IEntity first, IEntity second)
        {
            if (!(this.sortedbyId.ContainsKey(first.Id) && this.sortedbyId.ContainsKey(second.Id)))
            {
                throw new InvalidOperationException("Entity not found");
            }

            int firstIndex = this.list.IndexOf(sortedbyId[first.Id]);
            int secondIndex = this.list.IndexOf(sortedbyId[second.Id]);

            this.SwapByIndex(firstIndex, secondIndex);
        }

        private void SwapByIndex(int firstIndex, int secondIndex)
        {
            var temp = this.list[firstIndex];
            this.list[firstIndex] = this.list[secondIndex];
            this.list[secondIndex] = temp;
        }

        public IEntity[] ToArray()
        {
            return this.list.ToArray();
        }

        public void UpdateAll(BaseEntityStatus oldStatus, BaseEntityStatus newStatus)
        {


            for (int i = 0; i < this.list.Count; i++)
            {
                if (this.list[i].Status == oldStatus)
                {
                    this.list[i].Status = newStatus;
                }
            }
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            return this.list.GetEnumerator();

        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
