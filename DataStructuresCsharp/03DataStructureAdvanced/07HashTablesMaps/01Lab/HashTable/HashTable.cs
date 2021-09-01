using System.Linq;

namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private LinkedList<KeyValue<TKey, TValue>>[] hashtable;

        private const int DEF_CAPACITY = 16;
        private const float LOAD_FACTOR = 0.75f;

        private int maxElements;

        public int Count { get; private set; }

        public int Capacity => this.hashtable.Length;

        public HashTable(int capacity = DEF_CAPACITY)
        {
            this.hashtable = new LinkedList<KeyValue<TKey, TValue>>[capacity];
            this.maxElements = (int)(capacity * LOAD_FACTOR);
        }

        public void Add(TKey key, TValue value)
        {
            this.CheckGrowth();

            int hash = Math.Abs(key.GetHashCode() % this.Capacity);

            if (this.hashtable[hash] == null)
            {
                this.hashtable[hash] = new LinkedList<KeyValue<TKey, TValue>>();
            }


            foreach (var kvpKeyValue in this.hashtable[hash])
            {
                if (kvpKeyValue.Key.Equals(key))
                {
                    throw new ArgumentException();
                }

            }

            KeyValue<TKey, TValue> kvp = new KeyValue<TKey, TValue>(key, value);

            this.hashtable[hash].AddLast(kvp);
            this.Count++;

        }





        public bool AddOrReplace(TKey key, TValue value)
        {
            this.CheckGrowth();

            int hash = Math.Abs(key.GetHashCode() % this.Capacity);

            if (this.hashtable[hash] == null)
            {
                this.hashtable[hash] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            KeyValue<TKey, TValue> kvp = null;

            foreach (var kvpKeyValue in this.hashtable[hash])
            {
                if (kvpKeyValue.Key.Equals(key))
                {
                    kvpKeyValue.Value = value;
                    return true;
                }
            }

            KeyValue<TKey, TValue> newKeyValue = new KeyValue<TKey, TValue>(key, value);

            this.hashtable[hash].AddLast(newKeyValue);
            this.Count++;

            return false;
        }


        public TValue Get(TKey key)
        {
            KeyValue<TKey, TValue> pair = this.Find(key);

            if (pair == null)
            {
                throw new KeyNotFoundException();
            }

            return pair.Value;
        }

        public TValue this[TKey key]
        {
            get
            {
                KeyValue<TKey, TValue> KVP = this.Find(key);
                if (KVP == null)
                    throw new KeyNotFoundException();

                return KVP.Value;
            }
            set
            {
                this.AddOrReplace(key, value);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            KeyValue<TKey, TValue> kvp = this.Find(key);

            if (kvp != null)
            {
                value = kvp.Value;
                return true;
            }

            value = default(TValue);
            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode() % this.Capacity);

            if (this.hashtable[hash] != null)
            {
                foreach (var linckedList in this.hashtable[hash])
                {
                    if (key.Equals(linckedList.Key))
                    {
                        return linckedList;
                    }
                }

            }

            return null;

        }

        public bool ContainsKey(TKey key)
        {
            KeyValue<TKey, TValue> pair = this.Find(key);

            return pair != null;
        }

        public bool Remove(TKey key)
        {
            int hash = Math.Abs(key.GetHashCode() % this.Capacity);

            if (this.hashtable[hash]!=null)
            {
                var kvp = this.Find(key);

                if (kvp!=null)
                {
                    this.hashtable[hash].Remove(kvp);
                    this.Count--;

                    return true;
                }
            }

            return false;
        }

        public void Clear()
        {
            this.hashtable = new LinkedList<KeyValue<TKey, TValue>>[DEF_CAPACITY];
            this.maxElements = (int)(this.Capacity * LOAD_FACTOR);
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys => this.hashtable.Where(linked => linked != null).SelectMany(x => x.Select(y => y.Key));


        public IEnumerable<TValue> Values
            => this.hashtable.Where(linked => linked != null).SelectMany(x => x.Select(y => y.Value));


        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var linkedList in this.hashtable)
            {
                if (linkedList != null)
                {
                    foreach (var kvp in linkedList)
                    {
                        yield return kvp;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Grow()
        {
            HashTable<TKey, TValue> doubleSized
                = new HashTable<TKey, TValue>(this.Capacity * 2);

            foreach (var kvpKeyValue in hashtable)
            {
                if (kvpKeyValue != null)
                {
                    foreach (var pair in kvpKeyValue)
                    {
                        doubleSized.Add(pair.Key, pair.Value);
                    }
                }
            }

            this.hashtable = doubleSized.hashtable;
            this.Count = doubleSized.Count;
        }

        private void CheckGrowth()
        {
            if (this.Count >= maxElements)
            {
                this.Grow();
                this.maxElements = (int)(this.Capacity * LOAD_FACTOR);
            }
        }
    }
}
