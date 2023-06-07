namespace Lista
{
    public class Node<T>
    {
        public Node()
        {
            Next = null;
            Previous = null;
            Value = default(T);
        }
        public Node(T value, Node<T> next, Node<T> previous)
        {
            this.Value = value;
            this.Next = next;
            this.Previous = previous;
        }
        public Node(T value)
        {
            this.Value = value;
            this.Next = null;
            this.Previous = null;
        }

        public T? Value { get; set; }
        public Node<T>? Next { get; set; }
        public Node<T>? Previous { get; set; }
    };
}
