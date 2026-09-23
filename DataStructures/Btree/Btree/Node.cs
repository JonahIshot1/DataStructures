using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Btree
{
    public class Node<T>
    {
        IComparer<T> comparer;
        public List<T> vals;
        public List<Node<T>> children;
        public Node(IComparer<T> comp)
        {
            children = new List<Node<T>>();
            comparer = comp;
            vals = new List<T>();
        }
        public bool Contains(T val)
        {
            if (vals.Contains(val)) return true;
            for (int i = 0; i < vals.Count; i++)
            {
                if (comparer.Compare(val, vals[i]) < 0 || (vals.Count == 3 && comparer.Compare(val, vals[2]) > 0 && i == 2))
                {
                    if (children is not null && i < children.Count)
                    {
                        return children[i].Contains(val);
                    }
                    return false;
                }
            }
            return false;
        }
        void merge(Node<T> cild)
        {
            if(vals.Count<3)
            {
                vals.Add(cild.vals[0]);
                int index = children.IndexOf(cild);
                children.Remove(cild);
                children.Insert(index,cild.children[0]);
                children.Insert(index+1,cild.children[1]);
            }
            ////// what if the node i am merging with is aready a 4 node
        }
        public Node<T> Insert(T val, out bool splited)
        {
            splited = false;
            if (vals.Contains(val)) return this;
            if (vals.Count < 3)
            {
                if (children.Count > 0)
                {
                    bool sliped = false;
                    if (comparer.Compare(val, vals[0]) < 0)
                    {
                        children[0] = children[0].Insert(val, out sliped);
                        if (sliped) merge(children[0]);
                        return this;
                    }
                    if (vals.Count > 1 && comparer.Compare(val, vals[1]) < 0)
                    {
                        children[1] = children[1].Insert(val, out sliped);
                        if (sliped) merge(children[1]);
                        return this;
                    }
                    if (vals.Count > 2 && comparer.Compare(val, vals[2]) < 0)
                    {
                        children[2] = children[2].Insert(val, out sliped);
                        if (sliped) merge(children[2]);
                        return this;
                    }
                    children[vals.Count] = children[vals.Count].Insert(val, out sliped);
                    if (sliped) merge(children[vals.Count]);
                    return this;

                }
                for (int i = 0; i < vals.Count; i++)
                {
                    if (comparer.Compare(val, vals[i]) < 0)
                    {
                        vals.Insert(i, val);
                        return this;
                    }
                }
                vals.Add(val);
                return this;
            }
            for (int i = 0; i < vals.Count; i++)
            {
                if (comparer.Compare(val, vals[i]) < 0 || (comparer.Compare(val, vals[2]) > 0 && i == 2))
                {
                    bool nothin = false;
                    if(children.Count == 4)
                    {
                        Node<T> temp0 = new Node<T>(comparer);
                        temp0.vals.Add(vals[0]);

                        Node<T> temp1 = new Node<T>(comparer);
                        temp1.vals.Add(vals[1]);

                        Node<T> temp2 = new Node<T>(comparer);
                        temp2.vals.Add(vals[2]);

                        temp0.children.Add(children[0]);
                        temp0.children.Add(children[1]);
                        temp2.children.Add(children[2]);
                        temp2.children.Add(children[3]);
                        temp1.children.Add(temp0);
                        temp1.children.Add(temp2);
                        if (i < 2)
                        {
                            temp0.Insert(val, out nothin);
                        }
                        else
                        {
                            temp2.Insert(val, out nothin);
                        }
                        splited = true;
                        return temp1;

                    }
                    if (children.Count == 0)
                    {
                        Node<T> temp0 = new Node<T>(comparer);
                        temp0.vals.Add(vals[0]);

                        Node<T> temp1 = new Node<T>(comparer);
                        temp1.vals.Add(vals[1]);

                        Node<T> temp2 = new Node<T>(comparer);
                        temp2.vals.Add(vals[2]);

                        temp1.children.Add(temp0);
                        temp1.children.Add(temp2);
                        if (i < 2)
                        {
                            temp0.Insert(val,out nothin);
                        }
                        else
                        {
                            temp2.Insert(val,out nothin);
                        }
                        splited = true;
                        return temp1;
                    }
                    return children[i].Insert(val, out nothin);
                }
            }
            return this;
        }



    }
}
