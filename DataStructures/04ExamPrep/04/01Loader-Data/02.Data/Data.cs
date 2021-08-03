using System.Linq;

namespace _02.Data
{
    using _02.Data.Interfaces;
    using System;
    using System.Collections.Generic;

    public class Data : IRepository
    {
        private MaxHeap<IEntity> list;
        private Dictionary<int, IEntity> byId;
        private Dictionary<string, List<IEntity>> byType;
        private Dictionary<int, List<IEntity>> byParentId;


        public Data()
        {
            this.list = new MaxHeap<IEntity>();
            this.byId = new Dictionary<int, IEntity>();
            this.byType = new Dictionary<string, List<IEntity>>();
            this.byParentId = new Dictionary<int, List<IEntity>>();
        }

        public Data(
            MaxHeap<IEntity> copy,
            Dictionary<int,IEntity> first,
            Dictionary<string,List<IEntity>> next,
            Dictionary<int,List<IEntity>> byparentId)
        {
            this.list = copy;
            this.byId = first;
            this.byType = next;
            this.byParentId = byparentId;

        }

        public int Size => this.list.Size;

        public void Add(IEntity entity)
        {
            this.list.Add(entity);

            if (!this.byId.ContainsKey(entity.Id))
            {
                this.byId.Add(entity.Id, entity);
            }

            if (!this.byType.ContainsKey(entity.GetType().Name))
            {
                this.byType.Add(entity.GetType().Name, new List<IEntity>());

            }

            this.byType[entity.GetType().Name].Add(entity);

            if (!this.byParentId.ContainsKey((int)entity.ParentId))
            {
                this.byParentId.Add((int)entity.ParentId,new List<IEntity>());
            }

            this.byParentId[(int) entity.ParentId].Add(entity);

        }

        public IRepository Copy()
        {
            return new Data(list,byId,byType,byParentId);
        }

        public IEntity DequeueMostRecent()
        {
            IEntity toReturn = this.list.Dequeue();

            this.byId.Remove(toReturn.Id);

            return toReturn;

        }

        public List<IEntity> GetAll()
        {
            if (this.list.Size == 0)
            {
                return new List<IEntity>();

            }

            return new List<IEntity>(this.list.List);
        }

        public List<IEntity> GetAllByType(string type)
        {

            if (this.byType.ContainsKey(type))
            {
                return new List<IEntity>(this.byType[type]);
            }

            if (!(type == "Invoice" || type == "StoreClient" || type == "User"))
            {
                throw new InvalidOperationException("Invalid type: " + type);
            }

            return new List<IEntity>();

        }

        public IEntity GetById(int id)
        {
            IEntity toReturn = null;

            if (this.byId.ContainsKey(id))
            {
                toReturn = this.byId[id];
            }

            return toReturn;
        }

        public List<IEntity> GetByParentId(int parentId)
        {
            if (!this.byParentId.ContainsKey(parentId))
            {
                return new List<IEntity>();
            }
            return this.byParentId[parentId];
        }

        public IEntity PeekMostRecent()
        {

            return this.list.Peek();
        }
    }
}
