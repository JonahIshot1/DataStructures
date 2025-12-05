namespace BinarySearchTree
{
    public class Tree<T> where T : IComparable<T>
    {
        Node<T> root;
        public Tree()
        {
        }
        public bool Insert(T value)
        {

            if (root == null)
            {
                root = new Node<T>();
                root.Value = value;
                return true;
            }
            Node<T> curVal = root;
            while (!curVal.Value.Equals(value))
            {
                if (curVal.Value.CompareTo(value) > 0)
                {
                    if (curVal.Left != null) { curVal = curVal.Left; }
                    else
                    {
                        curVal.Left = new Node<T>();
                        curVal.Left.Value = value;
                        return true;
                    }
                }
                else
                {
                    if (curVal.Right != null) { curVal = curVal.Right; }
                    else
                    {
                        curVal.Right = new Node<T>();
                        curVal.Right.Value = value;
                        return true;
                    }
                }
            }
            return false;
        }
        public Node<T> Search(T value)
        {
            if (root == null)
            {
                return null;
            }
            Node<T> curVal = root;
            while (!curVal.Value.Equals(value))
            {
                if (curVal.Value.CompareTo(value) > 0)
                {
                    if (curVal.Left != null) { curVal = curVal.Left; }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    if (curVal.Right != null) { curVal = curVal.Right; }
                    else
                    {
                        return null;
                    }
                }
            }
            return curVal;
        }
    }
}

