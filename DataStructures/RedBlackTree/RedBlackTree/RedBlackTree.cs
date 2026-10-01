using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Transactions;
using System.Xml.Linq;

namespace RedBlackTree
{
    public class RedBlackTree<T> where T : IComparable<T>
    {
        public Node<T> root;
        public RedBlackTree()
        {

        }

        //public void Remove(T target)
        //{
        //    if (root == null) throw new NullReferenceException();
        //    root = removeHelp(root, root, target);
        //}
        //Node<T> removeHelp(Node<T> prev, Node<T> curVal, T target)
        //{
        //    if (curVal == null) throw new ArgumentException("value u wanted to delete doesnt exist");

        //    if (curVal.Value.CompareTo(target) > 0)
        //    {
        //        curVal.Left = removeHelp(curVal, curVal.Left, target);
        //    }
        //    else if (!curVal.Value.Equals(target))
        //    {
        //        curVal.Right = removeHelp(curVal, curVal.Right, target);
        //    }
        //    else
        //    {
        //        Node<T> temp = GetReplacement(curVal);
        //        if (temp != null)
        //            Height(temp);
        //        return temp;
        //    }
        //    return curVal;
        //}
        bool IsRed(Node<T> node)
        {
            return node is not null && node.IsRed;
        }
        bool Is4Node(Node<T> cur)
        {
            return !IsRed(cur) && IsRed(cur.Left) && IsRed(cur.Right);
        }
        Node<T> Balance4Nodes(Node<T> cur)
        {
            if(!cur.IsRed&&cur.Right is not null&& cur.Right.Right is not null && cur.Right.IsRed&& cur.Right.Right.IsRed)
            {
                Node<T> neww = cur.Right;
                neww.IsRed = false;
                var temp = neww.Left;
                neww.Left = cur;
                cur.IsRed= true;
                neww.Left.Right = cur.Left;
                return neww;
            }
            if (!cur.IsRed&&cur.Left is not null && cur.Left.Left is not null && cur.Left.IsRed && cur.Left.Left.IsRed)
            {
                Node<T> neww = cur.Left;
                neww.IsRed = false;
                var temp = neww.Left;
                neww.Left = cur;
                cur.IsRed = true;
                neww.Right.Left = cur.Left;
                return neww;
            }
            return cur;
        }
        void flipidy (Node<T> node)
        {
            node.Left.IsRed = node.IsRed;
            node.Right.IsRed = node.IsRed;
            node.IsRed = !node.IsRed;
        }
        Node<T> Check3NodeRotate (Node<T> pos)
        {
            if(!IsRed(pos.Left) && IsRed(pos.Right)&& pos.Right.Left is not null && pos.Right.Right is not null)
            {
                var l = pos.Left;
                var r = pos.Right;
                pos.Right = r.Left;
                Node<T> neww = new Node<T>();
                neww.Left = pos;
                neww.Right = r.Right;
                neww.Value = r.Value;
                neww.Left.IsRed = true;
                return neww;
            }
            return pos;
        }
        Node<T> rotateOneLeft (Node<T> cur)
        {
            if(cur.Left is null && IsRed(cur.Right))
            {
                Node<T> neww = new Node<T>();
                neww = cur.Right;
                neww.IsRed = false;
                neww.Left = cur;
                neww.Left.IsRed = true;
                neww.Left.Right = cur.Left;
                return neww; 
            }
            else if(IsRed(cur.Right)&& !cur.Left.IsRed)
            {
                cur.Right.IsRed = false;
               
            }
            return cur;
        }

        Node<T> rotates (Node<T> cur)
        {
            cur = Balance4Nodes(cur);
            cur = Check3NodeRotate(cur);
            cur = rotateOneLeft(cur);
            return cur;
        }
        public void Insert2(T val)
        {
            if(root is null )
            {
                root = new Node<T>();
                root.Value = val;
                root.IsRed = false;
                return;
            }
            root = insertHelp(root, val);
            root.IsRed = false;
        }
        // on the way up i need to handle rotations 
        Node<T> insertHelp(Node<T> cur, T val)
        {
            if (Is4Node(cur))
            {
                flipidy(cur);
            }
            if (cur.Value.CompareTo(val) > 0)
            {
                if (cur.Left is null)
                {
                    cur.Left= new Node<T>(val);
                    return cur;

                }
                cur.Left = insertHelp(cur.Left, val);
            }
            else
            {
                if (cur.Right is null)
                {
                    cur.Right= new Node<T>(val);

                    return cur;

                }
                cur.Right = insertHelp(cur.Right, val);
            }
            cur = rotates(cur);
            return cur;
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

        public Queue<Node<T>> inOrderRecursive(Queue<Node<T>> outP, Node<T> cur)
        {
            if (cur == null) return outP;
            inOrderRecursive(outP, cur.Left);
            outP.Enqueue(cur);
            inOrderRecursive(outP, cur.Right);
            return outP;
            //call inOrder on left side
            //add curr to output
            //call inOrder on right side
        }
        public Queue<T> preOrderRecursive(Queue<T> outP, Node<T> cur)
        {
            if (cur == null) return outP;
            outP.Enqueue(cur.Value);
            preOrderRecursive(outP, cur.Left);
            preOrderRecursive(outP, cur.Right);
            return outP;
        }
        public Queue<T> postOrderRecursive(Queue<T> outP, Node<T> cur)
        {
            if (cur == null) return outP;
            postOrderRecursive(outP, cur.Left);
            postOrderRecursive(outP, cur.Right);
            outP.Enqueue(cur.Value);
            return outP;
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
    }
}
