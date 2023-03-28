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
                    return true;
                }
            }

            return false;
        }

        public void Insert(T element)
        {
            Node<T> toInsert = new Node<T>(element, null, null);

            if (this.Root == null)
            {
                this.Root = toInsert;
            }
            else
            {
                this.InsertDfs(this.Root, null, toInsert);
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

        public List<T> Range(T lower, T upper)
        {
            var result = new List<T>();

            var queue = new Queue<Node<T>>();

            queue.Enqueue(this.Root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (this.IsLess(lower, current.Value)
                    && this.IsGreater(upper, current.Value))
                {
                    result.Add(current.Value);
                }
                else if (this.AreEqual(lower, current.Value) || AreEqual(upper, current.Value))
                {
                    result.Add(current.Value);

                }

                if (current.LeftChild != null)
                {
                    queue.Enqueue(current.LeftChild);
                }

                if (current.RightChild != null)
                {
                    queue.Enqueue(current.RightChild);
                }
            }

            return result;
        }

        public void DeleteMin()
        {

            this.EnsureNotEmpty();


            Node<T> current = this.Root;
            Node<T> previous = current;

            if (this.Root.LeftChild == null)
            {
                this.Root = RightChild;
            }
            else
            {
                while (current.LeftChild != null)
                {
                    current.Count--;

                    previous = current;
                    current = current.LeftChild;
                }

                previous.LeftChild = current.RightChild;
            }


            //  previous.RightChild = null;
        }



        public void DeleteMax()
        {
            this.EnsureNotEmpty();

            Node<T> current = this.Root;

            Node<T> previous = null;

            if (this.Root.RightChild == null)
            {
                this.Root = LeftChild;
            }
            else
            {
                while (current.RightChild != null)
                {
                    current.Count--;
                    previous = current;
                    current = current.RightChild;
                }

                previous.RightChild = current.LeftChild;

            }




        }

        public int GetRank(T element)
        {
            return this.GetRankDfs(this.Root, element);
        }

        private int GetRankDfs(Node<T> current, T toFind)
        {
            if (current == null)
            {
                return 0;
            }

            if (this.IsLess(toFind, current.Value))
            {
                return this.GetRankDfs(current.LeftChild, toFind);
            }
            else if (this.AreEqual(toFind, current.Value))
            {
                return this.GetNodeCount(current);
            }

            return this.GetNodeCount(current.LeftChild) + 1 + this.GetRankDfs(current.RightChild, toFind);
        }

        private int GetNodeCount(Node<T> current)
        {
            return current == null ? 0 : current.Count;
        }

        private void Copy(Node<T> current)
        {
            if (current != null)
            {
                this.Insert(current.Value);
                this.Copy(current.LeftChild);
                this.Copy(current.RightChild);
            }
        }



        private void InsertDfs(Node<T> current, Node<T> previous
            , Node<T> toInsert)
        {
            if (current == null && this.IsLess(toInsert.Value, previous.Value))
            {
                previous.LeftChild = toInsert;
                if (this.LeftChild == null)
                {
                    this.LeftChild = toInsert;
                }
                return;

            }

            if (current == null && this.IsGreater(toInsert.Value, previous.Value))
            {
                previous.RightChild = toInsert;

                if (this.RightChild == null)
                {
                    this.RightChild = toInsert;
                }
                return;
            }

            if (this.IsLess(toInsert.Value, current.Value))
            {
                InsertDfs(current.LeftChild, current, toInsert);

                current.Count++;

            }
            else if (this.IsGreater(toInsert.Value, current.Value))
            {
                InsertDfs(current.RightChild, current, toInsert);
                current.Count++;


            }




            //if (this.IsLess(toInsert.Value, current.Value))
            //{
            //    if (current.LeftChild == null)
            //    {
            //        current.Count++;

            //        current.LeftChild = toInsert;



            //        if (this.LeftChild == null)
            //        {
            //            this.LeftChild = toInsert;
            //        }
            //        return;

            //    }
            //    this.InsertDfs(current.LeftChild, current, toInsert);

            //}
            //else if (IsGreater(toInsert.Value, current.Value))
            //{

            //    if (current.RightChild == null)
            //    {
            //        current.RightChild = toInsert;


            //        if (this.RightChild == null)
            //        {
            //            this.RightChild = toInsert;

            //        }




            //        return;
            //    }
            //    this.InsertDfs(current.RightChild, current, toInsert);


            //}

        }


        private void EnsureNotEmpty()
        {
            if (this.Root == null)
            {
                throw new InvalidOperationException("ooops");
            }
        }
        private bool IsLess(T first, T second)
        {
            return first.CompareTo(second) < 0;
        }

        private bool IsGreater(T first, T second)
        {
            return first.CompareTo(second) > 0;
        }

        private bool AreEqual(T first, T second)
        {
            return first.CompareTo(second) == 0;
        }

        private void EachInOrderDfs(Node<T> current, Action<T> action)
        {
            if (current != null)
            {
                this.EachInOrderDfs(current.LeftChild, action);
                action.Invoke(current.Value);
                this.EachInOrderDfs(current.RightChild, action);

            }
        }
    }
}
