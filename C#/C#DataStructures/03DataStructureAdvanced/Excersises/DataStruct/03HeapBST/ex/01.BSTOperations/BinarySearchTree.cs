namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Copy(root);
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public int Count => this.Root.Count;

        public bool Contains(T element)
        {
            Node<T> currentNode = this.Root;

            while (currentNode != null)
            {
                if (this.IsLess(element, currentNode.Value))
                {
                    currentNode = currentNode.LeftChild;
                }

                else if (this.IsGreater(element, currentNode.Value))
                {
                    currentNode = currentNode.RightChild;
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
            Node<T> toInsert = new Node<T>(element,null,null);

            if (this.Root == null)
            {
                this.Root = toInsert;
            }
            else
            {
                this.InsertDfs(this.Root, null, toInsert);
            }
        }

        private void InsertDfs(Node<T> currentNode, Node<T> previous, Node<T> toInsert)
        {
            if (currentNode == null && this.IsLess(toInsert.Value, previous.Value))
            {
                previous.LeftChild = toInsert;

                if (this.LeftChild == null)
                {
                    this.LeftChild = toInsert;
                }
                return;
            }

            if (currentNode == null && this.IsGreater(toInsert.Value, previous.Value))
            {
                previous.RightChild = toInsert;

                if (this.RightChild == null)
                {
                    this.RightChild = toInsert;
                }
                return;
            }

            if (this.IsLess(toInsert.Value, currentNode.Value))
            {
                this.InsertDfs(currentNode.LeftChild, currentNode, toInsert);

                currentNode.Count++;

            }

            if (this.IsGreater(toInsert.Value, currentNode.Value))
            {
                this.InsertDfs(currentNode.RightChild, currentNode, toInsert);

                currentNode.Count++;

            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            Node<T> current = this.Root;

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
                    break;
                }
            }

            return new BinarySearchTree<T>(current);
        }

        public void EachInOrder(Action<T> action)
        {
            this.EachInOrderDfs(this.Root, action);
        }

        private void EachInOrderDfs(Node<T> currentNode, Action<T> action)
        {
            if (currentNode!=null)
            {
                this.EachInOrderDfs(currentNode.LeftChild,action);
            }

            action.Invoke(currentNode.Value);


            if (currentNode != null)
            {
                this.EachInOrderDfs(currentNode.RightChild, action);
            }
        }

        public List<T> Range(T lower, T upper)
        {
            
        }

        public void DeleteMin()
        {
            throw new NotImplementedException();
        }

        public void DeleteMax()
        {
            throw new NotImplementedException();
        }

        public int GetRank(T element)
        {
            throw new NotImplementedException();
        }


        private void Copy(Node<T> currentNode)
        {
            if (currentNode!=null)
            {
                this.Insert(currentNode.Value);
                this.Copy(currentNode.LeftChild);
                this.Copy(currentNode.RightChild);
            }
            
        }

        private bool IsGreater(T currentNodeValue, T element)
        {
            return currentNodeValue.CompareTo(element) > 0;

        }

        private bool IsLess(T currentNodeValue, T element)
        {
            return currentNodeValue.CompareTo(element) < 0;
        }
    }
}
