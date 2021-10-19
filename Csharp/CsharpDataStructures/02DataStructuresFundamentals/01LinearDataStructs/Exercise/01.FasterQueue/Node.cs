namespace Problem01.FasterQueue
{
    public class Node<T>
    {
        public Node(T item,Node<T> next = null)
        {
            this.Next = next;
            this.Item = item;
        }

        public T Item { get; set; }

        public Node<T> Next { get; set; }
    }
}