using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            var result = new List<T>();

            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var subTree = queue.Dequeue();
                result.Add(subTree.Value);

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }

            }
            return result;
        }

        public ICollection<T> OrderDfs()
        {
            //var result = new List<T>();
            //this.Dfs(this, result);
            //return result;

            return this.OrderDfsWithStack();
        }

        private void Dfs(Tree<T> tree, List<T> result)
        {
            foreach (var child in tree.Children)
            {
                this.Dfs(child, result);
            }

            result.Add(tree.Value);
        }

        private ICollection<T> OrderDfsWithStack()
        {
            var result = new Stack<T>();

            var toTraverse = new Stack<Tree<T>>();

            toTraverse.Push(this);

            while (toTraverse.Count > 0)
            {
                var subTree = toTraverse.Pop();

                foreach (var child in subTree.Children)
                {
                    toTraverse.Push(child);
                }

                result.Push(subTree.Value);


            }

            return result.ToList();

        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            throw new NotImplementedException();
        }

        public void RemoveNode(T nodeKey)
        {
            throw new NotImplementedException();
        }

        public void Swap(T firstKey, T secondKey)
        {
            throw new NotImplementedException();
        }
    }
}
