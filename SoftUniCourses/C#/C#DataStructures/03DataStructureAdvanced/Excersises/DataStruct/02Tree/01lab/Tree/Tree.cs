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

        public bool IsRootDeleted { get; private set; }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            ICollection<T> toReturn = new List<T>();

            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            if (IsRootDeleted)
            {
                return toReturn;
            }

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentT = queue.Dequeue();

                toReturn.Add(currentT.Value);

                foreach (var child in currentT._children)
                {
                    queue.Enqueue(child);
                }

            }

            return toReturn;
        }

        public ICollection<T> OrderDfs()
        {
            //ICollection<T> toReturn = new List<T>();

            //this.Dfs(this, toReturn);

            //return toReturn;

            return this.DfsWithStack();
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            Tree<T> parent = this.FindBfs(this, parentKey);

            this.CheckIfTreeIsNotNull(parent);

            child.Parent = parent;
            parent._children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {

            var toRemove = this.FindBfs(this, nodeKey);

            CheckIfTreeIsNotNull(toRemove);


            toRemove._children.Clear();
            var parent = toRemove.Parent;

            if (parent is null)
            {
                IsRootDeleted = true;
            }
            else
            {
                toRemove.Parent._children.Remove(toRemove);
                toRemove.Parent = null;
            }


            toRemove.Value = default(T);

        }


        public void Swap(T firstKey, T secondKey)
        {
            var firsNode = this.FindBfs(this, firstKey);
            var secondNode = this.FindBfs(this, secondKey);

            this.CheckIfTreeIsNotNull(firsNode);
            this.CheckIfTreeIsNotNull(secondNode);

            var fParent = firsNode.Parent;
            var sParent = secondNode.Parent;

            if (fParent == null)
            {
                this.SwapRoot(secondNode);
                return;
            }

            if (sParent == null)
            {
                this.SwapRoot(firsNode);
            }

            firsNode.Parent = sParent;
            secondNode.Parent = fParent;

            int indexOfFirst = fParent._children.IndexOf(firsNode);
            int indexOfsecond = sParent._children.IndexOf(secondNode);

            fParent._children[indexOfFirst] = secondNode;
            sParent._children[indexOfsecond] = firsNode;


        }

        private void SwapRoot(Tree<T> secondNode)
        {
            this.Value = secondNode.Value;
            this._children.Clear();

            foreach (var k in secondNode._children)
            {
                this._children.Add(k);
            }
        }

        private void Dfs(Tree<T> tree, ICollection<T> toReturn)
        {
            foreach (var child in tree._children)
            {
                this.Dfs(child, toReturn);
            }

            toReturn.Add(tree.Value);
        }

        private ICollection<T> DfsWithStack()
        {
            Stack<T> toReturn = new Stack<T>();

            Stack<Tree<T>> stack = new Stack<Tree<T>>();

            stack.Push(this);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                foreach (var tree in current._children)
                {
                    stack.Push(tree);
                }

                toReturn.Push(current.Value);
            }

            return toReturn.ToList();
        }


        private void CheckIfTreeIsNotNull(Tree<T> tree)
        {
            if (tree is null)
            {
                throw new ArgumentNullException(" Value cannot be null.");
            }
        }

        private Tree<T> FindBfs(Tree<T> tree, T parentKey)
        {
            Tree<T> toReturn = null;

            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(tree);

            while (queue.Count > 0)
            {
                var curentT = queue.Dequeue();

                if (curentT.Value.Equals(parentKey))
                {
                    toReturn = curentT;
                    break;
                }

                foreach (var child in curentT._children)
                {
                    queue.Enqueue(child);
                }
            }

            return toReturn;
        }
    }
}
