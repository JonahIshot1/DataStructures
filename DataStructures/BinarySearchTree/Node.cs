namespace BinarySearchTree
{
    public class Node<T>
    {
        public Node<T> Left { get; set; } //Instead of Next
        public Node<T> Right { get; set; } //Instead of Previous

        public T Value { get; set; }
    }
}
