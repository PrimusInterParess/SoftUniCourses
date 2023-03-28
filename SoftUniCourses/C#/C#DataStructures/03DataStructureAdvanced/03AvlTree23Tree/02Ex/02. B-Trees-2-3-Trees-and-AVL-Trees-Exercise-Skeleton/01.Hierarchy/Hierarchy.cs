using System.Linq;

namespace _01.Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;

    public class Hierarchy<T> : IHierarchy<T>
    {

        private Dictionary<T, Node<T>> dictionary = new Dictionary<T, Node<T>>();
        private Node<T> root;

        public Hierarchy(T root)
        {
            this.root = CreateNode(root);

        }

        public int Count => this.dictionary.Count;

        public void Add(T element, T child)
        {
            this.CheckForExistance(element);

            if (this.dictionary.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            Node<T> node = this.CreateNode(child);

            node.Parent = this.dictionary[element];
            this.dictionary[element].Children.Add(node);
        }

        private Node<T> CreateNode(T element)
        {
            var newNode = new Node<T>(element);
            dictionary.Add(element, newNode);

            return newNode;
        }

        public void Remove(T element)
        {

            if (this.root.Value.Equals(element))
            {
                throw new InvalidOperationException();
            }

            this.CheckForExistance(element);

            this.RemoveElement(element);


        }

        private void RemoveElement(T element)
        {
            var node = dictionary[element];

            node.Parent?.Children.Remove(node);

            if (node.Parent != null && node.Children.Count > 0)
            {
                foreach (var child in node.Children)
                {
                    child.Parent = node.Parent;
                    node.Parent.Children.Add(child);
                }
            }

            node.Children.Clear();

            dictionary.Remove(element);

        }

        public IEnumerable<T> GetChildren(T element)
        {
            this.CheckForExistance(element);

            return dictionary[element].Children.Select(n => n.Value);
        }

        public T GetParent(T element)
        {
            this.CheckForExistance(element);
            Node<T> toReturn = this.dictionary[element];
            return toReturn.Parent != null ? toReturn.Parent.Value : default(T);
        }

        public bool Contains(T element)
        {
            return this.dictionary.ContainsKey(element);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            foreach (var node in dictionary)
            {
                if (other.Contains(node.Value.Value))
                {
                    yield return node.Value.Value;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();

            queue.Enqueue(this.root);


            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                yield return current.Value;

                foreach (var node in current.Children)
                {
                    queue.Enqueue(node);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void CheckForExistance(T element)
        {
            if (!Contains(element))
            {
                throw new ArgumentException();
            }
        }
    }
}