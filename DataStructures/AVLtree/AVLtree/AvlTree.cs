using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Xml;

namespace AVLtree

{
    public class AVLtree<T> where T : IComparable<T>
    {
        public Node<T> root;
        public AVLtree()
        {
        }
       
        public void Remove(T target)
        {
            if (root == null) throw new NullReferenceException();
            root = removeHelp(root, root, target);
        }
        Node<T> removeHelp(Node<T> prev, Node<T> curVal, T target)
        {
            if (curVal == null) throw new ArgumentException("value u wanted to delete doesnt exist");

            if (curVal.Value.CompareTo(target) > 0)
            {
                curVal.Left = removeHelp(curVal, curVal.Left, target);
            }
            else if(!curVal.Value.Equals(target))
            {
                curVal.Right = removeHelp(curVal, curVal.Right, target);
            }
            else
            {
                Node<T>  temp = GetReplacement(curVal);
                if(temp!= null)
                    Height(temp);
                return temp;
            }
            return curVal;
        }

        Node<T> GetReplacement(Node<T> curr)
        {
            if (curr.Left == null && curr.Right == null) return null;
            if (curr.Left == null) return curr.Right;
            if (curr.Right == null) return curr.Left;
            if (curr.Left.Right == null)
            {
                Node<T> teemp = curr.Left;
                curr.Left = curr.Left.Left;
                teemp.Right = curr.Right;
                return teemp;
            }
            Node<T> temp = curr.Left;
            while (temp.Right.Right != null)
            {
                temp = temp.Right;
            }
            Node<T> temp3 = temp.Right.Left; 
            Node<T> temp2 = temp.Right;
            temp2.Right = curr.Right;
            temp2.Left = curr.Left;
            temp.Right = temp3;
            return temp2;
        }
        public int checkBalance(Node<T> pos)
        {
            int l;
            int r;
            if (pos.Left == null) l = 0;
            else l = pos.Left.Height;
            if (pos.Right == null) r = 0;
            else r = pos.Right.Height;
            return r - l;

        }
        Node<T> rotate (Node<T>pos)
        {
            int bal = checkBalance(pos);
            if (Math.Abs(bal)<2) return pos;
            if(bal>0)
            {
                if (checkBalance(pos.Right) < 0)
                {
                    pos.Right = rotR(pos.Right);
                }
                return rotL(pos);
            }
            else
            {
                if (checkBalance(pos.Left) > 0)
                {
                    pos.Left = rotL(pos.Left);
                }
                return rotR(pos);
            }
        }
        Node<T> rotL(Node<T> pos)
        {
            Node<T> temp = pos.Right;
            pos.Right = temp.Left;
            temp.Left = pos;
            Height(temp.Left);
            Height(temp);
            return temp;
        }
        Node<T> rotR(Node<T> pos)
        {
            Node<T> temp = pos.Left;
            pos.Left = temp.Right;
            temp.Right = pos;
            Height(temp.Right);
            Height(temp);
            return temp;
        }

        void Height(Node<T> pos)
        {
            if (pos.Left == null && pos.Right != null) pos.Height = pos.Right.Height + 1;
            else if (pos.Right == null && pos.Left != null) pos.Height = pos.Left.Height + 1;
            else if (pos.Right != null) pos.Height = Math.Max(pos.Right.Height, pos.Left.Height) + 1;
            else pos.Height = 1;
        }
        public void Insert2(T val)
        {
            root = insertHelp(root, val);
        }
        Node<T> insertHelp(Node<T> curVal, T val)
        {
            if (curVal == null)
            {
                return new Node<T>(val);
            }

            if (curVal.Value.CompareTo(val) > 0)
            {
                curVal.Left =insertHelp(curVal.Left, val);
            }
            else
            {
                curVal.Right = insertHelp(curVal.Right, val);
            }
            Height(curVal);
            return rotate(curVal);
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