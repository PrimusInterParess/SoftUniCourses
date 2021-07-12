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
            this.Key = key;

            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);

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

            this.AppendingSb(sb);

            return sb.ToString().TrimEnd();


        }



        public Tree<T> GetDeepestLeftomostNode()
        {
            Func<Tree<T>, bool> predicate = (node) => this.IsLeaf(node);

            List<Tree<T>> leafs = this.GetListOfTrees(predicate);
            int deepest = 0;
            Tree<T> toReturnTree = null;

            foreach (var tree in leafs)
            {
                int treeDepth = GetTreeDepth(tree);

                if (treeDepth > deepest)
                {
                    deepest = treeDepth;
                    toReturnTree = tree;
                }

            }

            return toReturnTree;
        }

       


        public List<T> GetLeafKeys()
        {
            Func<Tree<T>, bool> leafKeysFunc = (node) => this.IsLeaf(node);

            return this.OrderBfs(leafKeysFunc);

            //List<T> leafkeys = new List<T>();

            //this.GetLeafKeysByDfs(this, leafkeys);

            //return leafkeys;
        }


        public List<T> GetMiddleKeys()
        {
            Func<Tree<T>, bool> predicate = (node) => this.IsMiddle(node);

            return this.OrderBfs(predicate);

            //List<T> middleKeys = new List<T>();

            //Queue<Tree<T>> queue = new Queue<Tree<T>>();

            //queue.Enqueue(this);

            //while (queue.Count > 0)
            //{
            //    var currrent = queue.Dequeue();

            //    if ((!IsRoot(currrent)) && (!IsLeaf(currrent)))
            //    {
            //        middleKeys.Add(currrent.Key);

            //    }

            //    foreach (var child in currrent.Children)
            //    {
            //        queue.Enqueue(child);
            //    }
            //}

            //return middleKeys;
        }



        public List<T> GetLongestPath()
        {
            Tree<T> deepestNode = this.GetDeepestLeftomostNode();

            Tree<T> current = deepestNode;

            var result = new Stack<T>();

            while (current != null)
            {
                result.Push(current.Key);
                current = current.Parent;

            }

            return result.ToList();
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            throw new NotImplementedException();
        }


        private void GetLeafKeysByDfs(Tree<T> tree, List<T> leafkeys)
        {
            foreach (var child in tree.Children)
            {
                this.GetLeafKeysByDfs(child, leafkeys);
            }

            if (tree.Children.Count == 0)
            {
                leafkeys.Add(tree.Key);
            }
        }


        private int GetTreeDepth(Tree<T> tree)
        {
            int toReturn = 0;

            Tree<T> current = tree;

            while (current.Parent != null)
            {
                toReturn++;
                current = current.Parent;
            }

            return toReturn;
        }

        private List<Tree<T>> GetListOfTrees(Func<Tree<T>,bool> predicate)
        {
            List<Tree<T>> toReturn = new List<Tree<T>>();

            Queue<Tree<T>> toTraverse = new Queue<Tree<T>>();

            toTraverse.Enqueue(this);

            while (toTraverse.Count > 0)
            {
                var current = toTraverse.Dequeue();

                if (predicate(current))
                {
                    toReturn.Add(current);
                }
                else
                {
                    foreach (var child in current.Children)
                    {
                        toTraverse.Enqueue(child);
                    }
                }


            }

            return toReturn;
        }

        private List<T> OrderBfs(Func<Tree<T>, bool> predicate)
        {
            var result = new List<T>();

            Queue<Tree<T>> toTraverse = new Queue<Tree<T>>();

            toTraverse.Enqueue(this);

            while (toTraverse.Count > 0)
            {
                var current = toTraverse.Dequeue();

                if (predicate(current))
                {
                    result.Add(current.Key);
                }

                foreach (var child in current.Children)
                {
                    toTraverse.Enqueue(child);
                }
            }

            return result;
        }

        private void Dfs(Tree<T> tree, StringBuilder sb, int indent)
        {
            sb.AppendLine(new string(' ', indent) + tree.Key);

            foreach (var child in tree.Children)
            {
                this.Dfs(child, sb, indent + 2);
            }

        }

        private void AppendingSb(StringBuilder sb)
        {
            int indent = 0;

            this.Dfs(this, sb, indent);
        }

        private bool IsLeaf(Tree<T> currrent)
        {
            return currrent.Children.Count == 0;
        }

        private bool IsMiddle(Tree<T> node)
        {
            return node.Parent != null && node.Children.Count > 0;
        }

        private bool IsRoot(Tree<T> node)
        {
            return node.Parent == null;
        }
    }
}
