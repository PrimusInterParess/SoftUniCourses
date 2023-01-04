using System.Text;

namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
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

            this.AsStringDfs(this, indent, sb);

            return sb.ToString().TrimEnd();
        }



        public List<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> toReturn = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                toReturn.AddRange(this.LeftChild.InOrder());
            }

            toReturn.Add(this);

            if (this.RightChild != null)
            {
                toReturn.AddRange(this.RightChild.InOrder());
            }

            return toReturn;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> toReturn = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                toReturn.AddRange(this.LeftChild.PostOrder());
            }

            if (this.RightChild != null)
            {
                toReturn.AddRange(this.RightChild.PostOrder());
            }

            toReturn.Add(this);

            return toReturn;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> toReturn = new List<IAbstractBinaryTree<T>>();

            toReturn.Add(this);


            if (this.LeftChild != null)
            {
                toReturn.AddRange(this.LeftChild.PreOrder());
            }

            if (this.RightChild != null)
            {
                toReturn.AddRange(this.RightChild.PreOrder());
            }


            return toReturn;
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


        private void AsStringDfs(IAbstractBinaryTree<T> binaryTree, int indent, StringBuilder sb)
        {
            sb.AppendLine(new string(' ', indent) + binaryTree.Value);

            if (binaryTree.LeftChild != null)
            {
                this.AsStringDfs(binaryTree.LeftChild, indent + 2, sb);
            }

            if (binaryTree.RightChild != null)
            {
                this.AsStringDfs(binaryTree.RightChild, indent + 2, sb);
            }
        }
    }
}
