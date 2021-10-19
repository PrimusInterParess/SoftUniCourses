namespace _02._AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {

        private Node<T> root;
        public int CountNodes()
        {
            return this.CountNodesPrivate(this.root);
        }

        private int CountNodesPrivate(Node<T> node)
        {
            if (node == null)
            {
                return 0;
            }

            return 1 + this.CountNodesPrivate(node.Left) + this.CountNodesPrivate(node.Right);
        }

        public bool IsEmpty()
        {
            return this.root == null;
        }

        public void Clear()
        {
            this.root = null;
        }

        public void Insert(T element)
        {
            this.root = this.InsertPrivate(element, this.root);
        }

        private Node<T> InsertPrivate(T element, Node<T> node)
        {
            if (node == null)
            {
                node = new Node<T>(element);
            }
            else if (element.CompareTo(node.Element) < 0)
            {
                node.Left = InsertPrivate(element, node.Left);
            }
            else if (element.CompareTo(node.Element) > 0)
            {
                node.Right = InsertPrivate(element, node.Right);
            }
            else
            {
                throw new InvalidOperationException();
            }

            node = this.Skew(node);
            node = this.Split(node);


            return node;
        }

        private Node<T> Skew(Node<T> node)
        {
            if (node.Left != null &&
                node.Left.Level == node.Level)
            {
                node = this.RotateLeft(node);
            }

            return node;
        }

        private Node<T> RotateLeft(Node<T> node)
        {
            Node<T> newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            return newNode;

        }

        private Node<T> Split(Node<T> node)
        {
            if (node.Right == null || node.Right.Right == null)
            {
                return node;
            }
            else if (node.Right.Right.Level == node.Level)
            {
                node = this.Promote(node);
            }


            return node;
        }

        private Node<T> Promote(Node<T> node)
        {
            Node<T> newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;
            newNode.Level++;

            return newNode;
        }

        public bool Search(T element)
        {
            Node<T> node = FindElement(element);

            return node != null;
        }

        private Node<T> FindElement(T element)
        {
            Node<T> current = this.root;

            while (current != null)
            {
                if (current.Element.CompareTo(element) > 0)
                {
                    current = current.Left;
                }
                else if (current.Element.CompareTo(element) < 0)
                {
                    current = current.Right;
                }
                else
                {
                    break;
                }
            }

            return current;
        }



        public void InOrder(Action<T> action)
        {
            this.EachInOrder(this.root,action);
        }

        private void EachInOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            this.EachInOrder(node.Left, action);
            action(node.Element);
            this.EachInOrder(node.Right, action);
        }

        public void PreOrder(Action<T> action)
        {
           this.PreOrder(this.root,action);
        }

        private void PreOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }

            action(node.Element);

            this.PreOrder(node.Left, action);
            this.PreOrder(node.Right, action);
        }

        public void PostOrder(Action<T> action)
        {
           this.PostOrder(this.root,action);
        }

        private void PostOrder(Node<T> node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }


            this.PostOrder(node.Left, action);
            this.PostOrder(node.Right, action);

            action(node.Element);

        }
    }
}