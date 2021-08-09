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
            var result = new List<T>();

            if (IsRootDeleted)
            {
                return result;
            }

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
            var result = new List<T>();

            this.Dfs(this, result);
            return result;

            // return this.OrderDfsWithStack();


            if (IsRootDeleted)
            {
                return result;
            }
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

            var parentNode = FindDfs(parentKey, this);
            this.CheckEmptyNOde(parentNode);
            parentNode._children.Add(child);

        }

        private void CheckIfEmptyNode(Tree<T> parent)
        {
            if (parent is null)
            {
                throw new ArgumentNullException(" Value cannot be null.");
            }

        }



        public void RemoveNode(T nodeKey)
        {
            var currentNode = this.FindBfs(nodeKey);
            this.CheckIfEmptyNode(currentNode);

            foreach (var chlidChild in currentNode.Children)
            {
                chlidChild.Parent = null;
            }

            currentNode._children.Clear();

            var nodeParent = currentNode.Parent;

            if (nodeParent is null)
            {
                IsRootDeleted = true;

            }
            else
            {
                nodeParent._children.Remove(currentNode);
                currentNode.Parent = null;

            }

            currentNode.Value = default(T);

        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = FindBfs(firstKey);
            var secondNode = FindBfs(secondKey);

            CheckIfEmptyNode(firstNode);
            CheckIfEmptyNode(secondNode);

            var firstParent = firstNode.Parent;
            var secondParent = secondNode.Parent;

            if (firstParent==null)
            {
               SwapRoot(secondNode);
               return;
               
            }

            if (secondParent==null)
            {
                SwapRoot(firstNode);
                return;
            }

            firstNode.Parent = secondParent;
            secondNode.Parent = firstParent;

            int indexOfFirst = firstParent._children.IndexOf(firstNode);
            int indexOfSecond = secondParent._children.IndexOf(secondNode);

            firstParent._children[indexOfFirst] = secondNode;
            secondParent._children[indexOfSecond] = firstNode;
        }

        private void SwapRoot(Tree<T> tree)
        {
            this.Value = tree.Value;
            this._children.Clear();

            foreach (var child in tree.Children)
            {
                this._children.Add(child);
            }
        }

        private Tree<T> FindBfs(Tree<T> value)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentTree = queue.Dequeue();

                if (currentTree.Value.Equals(value))
                {
                    return currentTree;
                }

                foreach (var child in currentTree.Children)
                {
                    queue.Enqueue(child);
                }

            }

            return null;
        }

       

        private Tree<T> FindBfs(T value)
        {
            var queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (current.Value.Equals(value))
                {
                    return current;
                }

                foreach (var child in current.Children)
                {

                    queue.Enqueue(child);
                }
            }

            return null;
        }

        private Tree<T> FindDfs(T value, Tree<T> subTree)
        {

            foreach (var child in subTree.Children)
            {
                Tree<T> current = this.FindDfs(value, child);


                if (current != null && current.Equals(value))
                {
                    return current;
                }


            }

            if (subTree.Value.Equals(value))
            {
                return subTree;
            }

            return null;
        }


        private void CheckEmptyNOde(Tree<T> parentNode)
        {
            if (parentNode is null)
            {
                throw new ArgumentNullException("Really?");
            }
        }
    }
}
