using System.Linq;
using _02.LegionSystem.Models;

namespace _02.LegionSystem
{
    using System;
    using System.Collections.Generic;
    using _02.LegionSystem.Interfaces;

    public class Legion : IArmy
    {
        private MaxHeap<IEnemy> maxHeap;
        private MinHeap<IEnemy> minHeap;
        private Dictionary<int, IEnemy> dictionary;

        public Legion()
        {
            this.maxHeap = new MaxHeap<IEnemy>();
            this.minHeap = new MinHeap<IEnemy>();
            this.dictionary = new Dictionary<int, IEnemy>();
        }

        public int Size => this.dictionary.Count;

        public bool Contains(IEnemy enemy)
        {
            return this.dictionary.ContainsKey(enemy.AttackSpeed);
        }

        public void Create(IEnemy enemy)
        {
            this.maxHeap.Add(enemy);
            this.minHeap.Add(enemy);

            if (!this.dictionary.ContainsKey(enemy.AttackSpeed))
            {
                this.dictionary.Add(enemy.AttackSpeed, enemy);
            }
        }

        public IEnemy GetByAttackSpeed(int speed)
        {
            IEnemy enemy = null;

            if (this.dictionary.ContainsKey(speed))
            {
                enemy = dictionary[speed];
            }

            return enemy;
        }

        public List<IEnemy> GetFaster(int speed)
        {
            return new List<IEnemy>(this.minHeap.List.Where(e => e.AttackSpeed > speed));
        }

        public IEnemy GetFastest()
        {
            this.EnsureNotEmpty();

            return this.maxHeap.Peek();
        }



        public IEnemy[] GetOrderedByHealth()
        {
            return this.minHeap.List.OrderByDescending(e=>e.Health).ToArray();
        }

        public List<IEnemy> GetSlower(int speed)
        {
            return new List<IEnemy>(this.minHeap.List.Where(s => s.AttackSpeed < speed));
        }

        public IEnemy GetSlowest()
        {
            this.EnsureNotEmpty();
            return this.minHeap.Peek();
        }

        public void ShootFastest()
        {
            this.EnsureNotEmpty();

            var toRemove = this.maxHeap.Dequeue();
            this.minHeap.Remove(toRemove);
          
            this.dictionary.Remove(toRemove.AttackSpeed);
        }

        public void ShootSlowest()
        {
            EnsureNotEmpty();
            var toRemove = this.minHeap.Dequeue();
         
            this.maxHeap.Remove(toRemove);
            this.dictionary.Remove(toRemove.AttackSpeed);

        }

        private void EnsureNotEmpty()
        {
            if (this.maxHeap.Size == 0)
            {
                throw new InvalidOperationException("Legion has no enemies!");
            }
        }
    }
}
