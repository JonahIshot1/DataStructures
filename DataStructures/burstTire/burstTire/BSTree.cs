using System;
using System.Collections.Generic;
using System.Text;

namespace burstTire
{
    namespace BinarySearchTree
    {
        public class BSTree<T> where T : IComparable<T>
        {
            public int count = 0;
            public TreeNode<T> root;
            public BSTree()
            {
            }
            public bool Insert(T value)
            {
                count++;

                if (root == null)
                {
                    root = new TreeNode<T>();
                    root.Value = value;
                    return true;
                }
                TreeNode<T> curVal = root;
                while (!curVal.Value.Equals(value))
                {
                    if (curVal.Value.CompareTo(value) > 0)
                    {
                        if (curVal.Left != null) { curVal = curVal.Left; }
                        else
                        {
                            curVal.Left = new TreeNode<T>();
                            curVal.Left.Value = value;
                            return true;
                        }
                    }
                    else
                    {
                        if (curVal.Right != null) { curVal = curVal.Right; }
                        else
                        {
                            curVal.Right = new TreeNode<T>();
                            curVal.Right.Value = value;
                            return true;
                        }
                    }
                }
                return false;
            }
            public TreeNode<T> Search(T value)
            {
                if (root == null)
                {
                    return null;
                }
                TreeNode<T> curVal = root;
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
            public T Minimum(TreeNode<T> nodeToGetMinOf)
            {
                TreeNode<T> curVa = nodeToGetMinOf;
                while (curVa.Left != null)
                {
                    curVa = curVa.Left;
                }
                return curVa.Value;
            }
            public T Maximum(TreeNode<T> nodeToGetMaxOf)
            {
                TreeNode<T> curVa = nodeToGetMaxOf;
                while (curVa.Right != null)
                {
                    curVa = curVa.Right;
                }
                return curVa.Value;
            }
            public Queue<T> LevelOrder()
            {
                Queue<T> OutP = new Queue<T>();
                Queue<TreeNode<T>> Tep = new Queue<TreeNode<T>>();
                Tep.Enqueue(root);
                TreeNode<T> previous;
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
                Stack<TreeNode<T>> Tep = new Stack<TreeNode<T>>();
                Tep.Push(root);
                TreeNode<T> previous;
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
                Stack<TreeNode<T>> Tep = new Stack<TreeNode<T>>();
                Tep.Push(root);
                TreeNode<T> previous;
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
            public bool Remove(T Target)
            {
                count--;
                TreeNode<T> outP = new TreeNode<T>();
                outP = Search(Target);
                if (outP == null) return false;
                TreeNode<T> temp = new TreeNode<T>();
                TreeNode<T> previous = new TreeNode<T>();
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
            public Queue<T> inOrderRecursive(Queue<T> outP, TreeNode<T> cur)
            {
                if (cur == null) return outP;
                inOrderRecursive(outP, cur.Left);
                outP.Enqueue(cur.Value);
                inOrderRecursive(outP, cur.Right);
                return outP;
                //call inOrder on left side
                //add curr to output
                //call inOrder on right side
            }
            public Queue<T> preOrderRecursive(Queue<T> outP, TreeNode<T> cur)
            {
                if (cur == null) return outP;
                outP.Enqueue(cur.Value);
                preOrderRecursive(outP, cur.Left);
                preOrderRecursive(outP, cur.Right);
                return outP;
            }
            public Queue<T> postOrderRecursive(Queue<T> outP, TreeNode<T> cur)
            {
                if (cur == null) return outP;
                postOrderRecursive(outP, cur.Left);
                postOrderRecursive(outP, cur.Right);
                outP.Enqueue(cur.Value);
                return outP;
            }
            public Queue<T> InOrder(TreeNode<T> start)
            {
                Queue<T> OutP = new Queue<T>();
                Stack<TreeNode<T>> Tep = new Stack<TreeNode<T>>();

                TreeNode<T> cur = start;
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
}
