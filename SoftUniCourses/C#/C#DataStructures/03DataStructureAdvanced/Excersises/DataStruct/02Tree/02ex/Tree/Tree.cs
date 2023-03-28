using System.Linq;
using System.Text;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key)
        {
            this.Key = key;
            this.Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T key, params Tree<T>[] children)
        : this(key)
        {
            foreach (var childTree in children)
            {
                childTree.Parent = this;
                this._children.Add(childTree);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            child.Parent = this;
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;

        }

        public string GetAsString()
        {
            StringBuilder sb = new StringBuilder();

            this.GetStringPreOrderDfs(this, sb, 0);

            return sb.ToString().TrimEnd();

        }



        public Tree<T> GetDeepestLeftomostNode()
        {
            Func<Tree<T>, bool> predicate = (node) => this.IsLeafNode(node);

            List<Tree<T>> lisOfTrees = this.GetListOfTrees(predicate);

            int deepestPath = 0;

            Tree<T> deepestLeftMostTree = null;

            foreach (var tree in lisOfTrees)
            {
                int treeDept = this.GetTreeDeptDfs(tree);

                if (deepestPath < treeDept)
                {
                    deepestPath = treeDept;
                    deepestLeftMostTree = tree;
                }
            }

            return deepestLeftMostTree;

        }

        public List<T> GetLeafKeys()
        {
            Func<Tree<T>, bool> predicate = (node) => this.IsLeafNode(node);

            return this.GetKeysBfs(predicate);

        }

        public List<T> GetMiddleKeys()
        {
            Func<Tree<T>, bool> predicate = (node) => this.IsMiddleNode(node);

            return this.GetKeysBfs(predicate);
        }

        public List<T> GetLongestPath()
        {
            Tree<T> deepestTree = this.GetDeepestLeftomostNode();

            Stack<T> toReturn = new Stack<T>();

            var current = deepestTree;

            while (current != null)
            {
                toReturn.Push(current.Key);
                current = current.Parent;
            }

            return toReturn.ToList();


        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<T>>();

            var currentPath = new List<T>();

            currentPath.Add(this.Key);

            int currentSum = Convert.ToInt32(this.Key);

            this.GetPathsWithGivenSum(this, result, currentPath, ref currentSum, sum);

            return result;
        }



        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            List<Tree<T>> listOfTrees = this.GetListOfTrees();

            List<Tree<T>> toReturn = new List<Tree<T>>();

            foreach (var tree in listOfTrees)
            {
                int subTreeSum = this.GetSubTreeSum(tree);

                if (subTreeSum == sum)
                {
                    toReturn.Add(tree);

                }
            }

            return toReturn;
        }

        private int GetSubTreeSum(Tree<T> tree)
        {
            int currentSum = Convert.ToInt32(tree.Key);

            int childSum = 0;

            foreach (var child in tree._children)
            {
                childSum += this.GetSubTreeSum(child);
            }


            return currentSum + childSum;
        }

        private List<T> GetKeysBfs(Func<Tree<T>, bool> predicate)
        {
            List<T> toReturnList = new List<T>();

            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (predicate(current))
                {
                    toReturnList.Add(current.Key);
                }

                foreach (var child in current._children)
                {
                    queue.Enqueue(child);
                }
            }

            return toReturnList;
        }

        private void GetPathsWithGivenSum(Tree<T> tree, List<List<T>> result, List<T> currentPath, ref int currentSum, int sum)
        {
            foreach (var child in tree._children)
            {
                currentPath.Add(child.Key);
                currentSum += Convert.ToInt32(child.Key);

                this.GetPathsWithGivenSum(child, result, currentPath, ref currentSum, sum);

            }

            if (currentSum == sum)
            {
                result.Add(new List<T>(currentPath));
            }

            currentSum -= Convert.ToInt32(tree.Key);
            currentPath.RemoveAt(currentPath.Count - 1);
        }

        private void GetStringPreOrderDfs(Tree<T> tree, StringBuilder sb, int indent)
        {
            sb.AppendLine(new string(' ', indent) + tree.Key);

            foreach (var child in tree._children)
            {
                this.GetStringPreOrderDfs(child, sb, indent + 2);
            }
        }


        private int GetTreeDeptDfs(Tree<T> tree)
        {
            int toReturn = 0;

            var current = tree;

            while (tree.Parent != null)
            {
                toReturn++;
                tree = tree.Parent;
            }

            return toReturn;
        }

        private List<Tree<T>> GetListOfTrees(Func<Tree<T>, bool> predicate = null)
        {
            List<Tree<T>> toReturnList = new List<Tree<T>>();

            Queue<Tree<T>> queue = new Queue<Tree<T>>();

            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (predicate != null)
                {
                    if (predicate(current))
                    {
                        toReturnList.Add(current);
                    }
                }
                else
                {
                    toReturnList.Add(current);
                }

                foreach (var childTree in current._children)
                {
                    queue.Enqueue(childTree);
                }
            }

            return toReturnList;
        }


        private bool IsLeafNode(Tree<T> node)
        {
            return node.Children.Count == 0;
        }

        private bool IsMiddleNode(Tree<T> node)
        {
            return node._children.Count > 0 && node.Parent != null;
        }
    }
}
