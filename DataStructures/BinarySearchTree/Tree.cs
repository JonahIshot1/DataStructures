namespace BinarySearchTree
{
    public class Tree<T> where T : IComparable<T>
    {
        public Node<T> root;
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
        public bool Contains(T value)
        {
            return Search(value) != null;
        }
        public T Minimum(Node<T> nodeToGetMinOf)
        {
            Node<T> curVa = nodeToGetMinOf;
            while (curVa.Left != null)
            {
                curVa = curVa.Left;
            }
            return curVa.Value;
        }
        public T Maximum(Node<T> nodeToGetMaxOf)
        {
            Node<T> curVa = nodeToGetMaxOf;
            while (curVa.Right != null)
            {
                curVa = curVa.Right;
            }
            return curVa.Value;
        }
        public Queue<T> LevelOrder()
        {
            Queue<T> OutP = new Queue<T>();
            Queue<Node<T>> Tep = new Queue<Node<T>>();
            Tep.Enqueue(root);
            Node<T> previous;
            while (true)
            {
                previous = Tep.Dequeue();
                if (previous.Left != null)
                {
                    Tep.Enqueue(previous.Left);
                }
                if (previous.Right != null)
                {
                    Tep.Enqueue(previous.Right);
                }
                OutP.Enqueue(previous.Value);
                if (Tep.Count == 0)
                {
                    return OutP;
                }
            }
        }
        public Queue<T> PreOrder()
        {
            //Queue<T> OutP = new Queue<T>();
            //Stack<Node<T>> Tep = new Stack<Node<T>>();
            //Tep.Push(root);
            //Node<T> previous;
            //while (true)
            //{
            //    previous = Tep.Pop();
            //    if (previous.Right != null)
            //    {
            //        Tep.Push(previous.Right);
            //    }
            //    if (previous.Left != null)
            //    {
            //        Tep.Push(previous.Left);
            //    }
            //    OutP.Enqueue(previous.Value);
            //    if (Tep.Count == 0)
            //    {
            //        return OutP;
            //    }
            //}
            Queue<T> OutP = new Queue<T>();
            Stack<Node<T>> Tep = new Stack<Node<T>>();
            Tep.Push(root);
            Node<T> previous;
            while (Tep.Count != 0)
            {
                previous = Tep.Pop();
                if (previous != null)
                {
                    OutP.Enqueue(previous.Value);
                    Tep.Push(previous.Right);
                    Tep.Push(previous.Left);
                }
            }
            return OutP;
        }
        public Stack<T> PostOrder()
        {
            Stack<T> OutP = new Stack<T>();
            Stack<Node<T>> Tep = new Stack<Node<T>>();
            Tep.Push(root);
            Node<T> previous;
            while (Tep.Count != 0)
            {
                previous = Tep.Pop();
                if (previous != null)
                {
                    OutP.Push(previous.Value);
                    Tep.Push(previous.Left);
                    Tep.Push(previous.Right);
                }
            }
            return OutP;
        }
        public Queue<T> InOrder(Node<T> start)
        {
            Queue<T> OutP = new Queue<T>();
            Stack<Node<T>> Tep = new Stack<Node<T>>();

            Node<T> cur = start;
            do
            {
                if (cur != null)
                {
                    Tep.Push(cur);
                    cur = cur.Left;
                    continue;
                }
                cur = Tep.Peek();
                OutP.Enqueue(Tep.Pop().Value);

                cur = cur.Right;

            } while (Tep.Count != 0 || cur != null);

            return OutP;
        }
        public bool Remove(T Target)
        {
            Node<T> outP = new Node<T>();
            outP = Search(Target);
            if (outP == null) return false;
            Node<T> temp = new Node<T>();
            Node<T> previous = new Node<T>();
            if (outP.Left != null) temp = outP.Left;
            while (true)
            {

                if (temp.Right != null)
                {
                    previous = temp;
                    temp = temp.Right;

                }
                else break;
            }
            outP.Value = temp.Value;
            if (temp.Left != null) previous.Right = temp.Left;
            previous.Right = null;

            return true;


        }
    }

}