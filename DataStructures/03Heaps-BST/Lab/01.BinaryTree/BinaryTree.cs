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
            StringBuilder preOrderString = new StringBuilder();

            this.PreOrderDfs(this, preOrderString, indent);

            return preOrderString.ToString();
        }

        private void PreOrderDfs(IAbstractBinaryTree<T> binaryTree, StringBuilder preOrderString, int indent)
        {
            preOrderString.AppendLine(new string(' ', indent) + binaryTree.Value);

            if (binaryTree.LeftChild != null)
            {
                this.PreOrderDfs(binaryTree.LeftChild, preOrderString, indent + 2);
            }

            if (binaryTree.RightChild != null)
            {
                this.PreOrderDfs(binaryTree.RightChild, preOrderString, indent + 2);
            }
        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            List<IAbstractBinaryTree<T>> listToreturn = new List<IAbstractBinaryTree<T>>();


            if (this.LeftChild != null)
            {
                listToreturn.AddRange(this.LeftChild.InOrder());
            }

            listToreturn.Add(this);


            if (this.LeftChild != null)
            {
                listToreturn.AddRange(this.RightChild.InOrder());

                return listToreturn;
            }

            return listToreturn;

        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            List<IAbstractBinaryTree<T>> listToreturn = new List<IAbstractBinaryTree<T>>();

            if (this.LeftChild != null)
            {
                listToreturn.AddRange(this.LeftChild.PostOrder());
            }

            if (this.LeftChild != null)
            {
                listToreturn.AddRange(this.RightChild.PostOrder());
            }

            listToreturn.Add(this);

            return listToreturn;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            List<IAbstractBinaryTree<T>> listToreturn = new List<IAbstractBinaryTree<T>>();

            listToreturn.Add(this);

            if (this.LeftChild != null)
            {
                listToreturn.AddRange(this.LeftChild.PreOrder());
            }

            if (this.RightChild != null)
            {
                listToreturn.AddRange(this.RightChild.PreOrder());
            }

            return listToreturn;

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
    }
}
