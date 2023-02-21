namespace Subsequences
{
    public class Node<T>
    {
        private T value;

        public Node(T value, Node<T> next = null)
        {
            this.value = value;
            this.Next = next;

        }

        public Node<T> Next { get; set; }
    }
}
