using System.Text;

namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value, IAbstractBinaryTree<T> leftChild, IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            StringBuilder sb = new StringBuilder();

            this.AsIndentedPreOrderDfs(this, sb, indent);

            return sb.ToString().TrimEnd();
        }


        public List<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> trees = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                trees.AddRange(this.LeftChild.InOrder());
            }

            trees.Add(this);

            if (this.RightChild != null)
            {
                trees.AddRange(this.RightChild.InOrder());
            }

            return trees;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> trees = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                trees.AddRange(this.LeftChild.PostOrder());
            }


            if (this.RightChild != null)
            {
                trees.AddRange(this.RightChild.PostOrder());
            }

            trees.Add(this);


            return trees;

        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> trees = new List<IAbstractBinaryTree<T>>();

            trees.Add(this);


            if (this.LeftChild != null)
            {
                trees.AddRange(this.LeftChild.PreOrder());
            }


            if (this.RightChild != null)
            {
                trees.AddRange(this.RightChild.PreOrder());
            }



            return trees;


        }

        public void ForEachInOrder(Action<T> action)
        {
            if (this.LeftChild != null)
            {
                this.LeftChild.ForEachInOrder(action);
            }

            action.Invoke(this.Value);

            if (this.RightChild != null)
            {
                this.RightChild.ForEachInOrder(action);

            }

        }

        private void AsIndentedPreOrderDfs(
            IAbstractBinaryTree<T> binaryTree,
            StringBuilder sb, int indent)
        {
            sb.AppendLine(new string(' ', indent) + binaryTree.Value);

            if (binaryTree.LeftChild != null)
            {
                this.AsIndentedPreOrderDfs(binaryTree.LeftChild, sb, indent + 2);
            }

            if (binaryTree.RightChild != null)
            {
                this.AsIndentedPreOrderDfs(binaryTree.RightChild, sb, indent + 2);

            }
        }
    }
}
