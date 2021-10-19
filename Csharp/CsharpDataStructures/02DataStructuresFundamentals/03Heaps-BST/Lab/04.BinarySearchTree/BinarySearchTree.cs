namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {


        public BinarySearchTree(Node<T> root=null)
        {
            this.Coppy(root);

        }

        private void Coppy(Node<T> root)
        {
            if (root != null)
            {
                this.Insert(root.Value);
                this.Coppy(root.LeftChild);
                this.Coppy(root.RightChild);
            }
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {
            var current = this.Root;

            while (current != null)
            {
                if (this.IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (this.IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
                else
                {
                    return true;
                }

            }

            return false;
        }

        public void Insert(T element)
        {
            var toInsert = new Node<T>(element);
            if (this.Root == null)
            {
                this.Root = toInsert;
            }
            else
            {
                var current = this.Root;
                Node<T> prevNode = null;

                while (current != null)
                {
                    prevNode = current;
                    if (this.IsLess(element, current.Value))
                    {
                        current = current.LeftChild;
                    }
                    else if (this.IsGreater(element, current.Value))
                    {
                        current = current.RightChild;
                    }
                    else
                    {
                        return;
                    }

                }

                if (this.IsLess(element, prevNode.Value))
                {
                    prevNode.LeftChild = toInsert;
                    if (this.LeftChild == null)
                    {
                        this.LeftChild = toInsert;
                    }
                }
                else
                {
                    prevNode.RightChild = toInsert;
                    if (this.RightChild == null)
                    {
                        this.RightChild = toInsert;
                    }
                }
            }
        }


        public IAbstractBinarySearchTree<T> Search(T element)
        {
            var current = this.Root;

            while (current != null && !AreEqual(element, current.Value))
            {
                if (this.IsLess(element, current.Value))
                {
                    current = current.LeftChild;
                }
                else if (this.IsGreater(element, current.Value))
                {
                    current = current.RightChild;
                }
            }

            // Node<T> newRoot = this.BSTSearch(element,current);

            return new BinarySearchTree<T>(current);
        }

        private Node<T> BSTSearch(T element, Node<T> current)
        {
            if (current.Value.CompareTo(element) == 0)
            {
                return current;
            }

            if (current == null)
            {
                return null;
            }


            if (current.Value.CompareTo(element) > 0)
            {


                return BSTSearch(element, current.LeftChild);
            }
            else if (current.Value.CompareTo(element) < 0)
            {


                return BSTSearch(element, current.RightChild);
            }
            else
            {
                return null;
            }
        }


        private bool IsLess(T element, T currentValue)
        {
            return element.CompareTo(currentValue) < 0;
        }
        private bool IsGreater(T element, T currentValue)
        {
            return element.CompareTo(currentValue) > 0;
        }

        private bool AreEqual(T element, T currentValue)
        {
            return element.CompareTo(currentValue) == 0;
        }

    }
}
