using System;
using System.Collections.Generic;
using System.Text;

namespace SkipList
{
    public class SList<T> where T : IComparable<T>
    {
        public Node<T> sent;
        public SList()
        {
            sent= new Node<T> (default,1);
        }
        public Node<T> goDown(Node<T>InP)
        {
            while (InP.Down != null)
            {
                InP = InP.Down;
            }
            return InP;
        }
        public Queue<T> numDump()
        {
            Queue<T> OutP = new();
            Node<T> temp = sent;
            temp=goDown(temp);
            do
            {
                temp = temp.Next;
                OutP.Enqueue(temp.Value);
            } while (temp.Next != null);
            return OutP;
        }
        public int getNewHeight()
        {
            Random randy = new Random(677);
            int height = 1;
            while (randy.Next(0, 2) == 0)
            {
                height++;
                if (height > sent.Height) return height;
            }
            return height;
        }
        public void BuildStack(Node<T> New)
        {
            int TempCount = New.Height-1;
            Node<T> Temp2 = New;
            while (TempCount > 0)
            {
                Temp2.Down = new Node<T>(New.Value, TempCount);
                Temp2 = Temp2.Down;
                TempCount--;
            }
        }
        public void BuildSent(Node<T> New)
        {
            int height = New.Height;
            if (height > sent.Height)
            {
                while (sent.Height < height)
                {
                    Node<T> tempp = new Node<T>(default, sent.Height + 1);
                    tempp.Down = sent;
                    sent = tempp;
                }
            }
        }
        private void Stack(Node<T> New)
        {
            int height = New.Height;
            BuildStack(New);
            BuildSent(New);
            Node<T> temp = sent;
            Node<T> Curent = New;
            while (temp.Height > New.Height) { temp = temp.Down; }
            while (temp.Height != 0)
            {
                while (temp.Next != null && temp.Next.Value.CompareTo(Curent.Value) < 0)
                {
                    temp = temp.Next;
                }//every thing above works it gets into the right space but i think that making and breaking the conections 
                Node<T> oldNext = temp.Next;
                temp.Next = Curent;
                Curent.Next= oldNext;
                temp = temp.Down;
                Curent = Curent.Down;
                if (temp == null) return;
                if (Curent == null) return;
            }


        }
        public Node<T> locatePrev(T val)
        {
            Node<T> temp = sent;
            do
            {
                if (temp.Next == null|| temp.Next.Value.CompareTo(val) > 0)
                {
                    if (temp.Down==null) return null;
                    if (temp.Down.Next == null) return null;
                    temp = temp.Down;
                }

                else
                {
                    if (temp.Next.Next == null) return null;
                    temp = temp.Next;
                }
            } while (!temp.Next.Value.Equals(val));
            return temp;
        }
        public void IN(T val)
        {
            Stack(new Node<T>(val, getNewHeight()));
        }
        public bool REM(T val)
        {
            throw new NotImplementedException();
            //Node<T> temp = sent;
            //Node<T> Curent;
            //while (temp.Height > New.Height) { temp = temp.Down; }
            //while (temp.Height != 0)
            //{
            //    while (temp.Next != null && temp.Next.Value.CompareTo(Curent.Value) < 0)
            //    {
            //        temp = temp.Next;
            //    }//every thing above works it gets into the right space but i think that making and breaking the conections 
            //    Node<T> oldNext = temp.Next;
            //    temp.Next = Curent;
            //    Curent.Next = oldNext;
            //    temp = temp.Down;
            //    Curent = Curent.Down;
            //    if (temp == null) return;
            //    if (Curent == null) return;
            //}

            //return true;
        }


    }
}
