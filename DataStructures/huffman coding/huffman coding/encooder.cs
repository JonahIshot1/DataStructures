using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace huffman_coding
{
    public class Encooder
    {
        public string input;
        public Dictionary<char, int> frequency;
        public Dictionary<char, string> output;

        public PriorityQueue<Node, int> tree;




        public Queue<outPNode> inOrderRecursive(Queue<outPNode> outP, Node cur, string pos)
        {
            tree = new();
            if (cur == null) return outP;
            inOrderRecursive(outP, cur.left,pos + "0");
            if (cur.letter != '>')
            {
                outP.Enqueue(new outPNode(cur.letter, pos));
            }
            inOrderRecursive(outP, cur.right,pos + "1");
            return outP;
            //call inOrder on left side
            //add curr to output
            //call inOrder on right side
        }

        public Encooder(string input)
        {
            this.input = input.ToLower();
            this.frequency = new Dictionary<char, int>();
            for (int i = 0; i < 26; i++)
            {
                if (input.Contains((char)(i + 97)))
                {
                    frequency.Add((char)(i + 97), 0);
                }
            }
            if(input.Contains(' '))
            {
                frequency.Add(' ', 0);
            }
            this.output = new Dictionary<char, string>();
        }
        static string baseConverter(int inP, int b2)
        {
            Stack<int> powersB = new();
            powersB.Push(1);
            int count = 1;
            while (true)
            {
                if (Math.Pow(b2, count) > inP) break;
                powersB.Push((int)Math.Pow(b2, count));
                count++;
            }
            Queue<int> stuf = new();
            //int num1 = inP / b2;
            //stuf.Push(num1);
            count = powersB.Count();
            for (int i = 0; i < count; i++)
            {
                int div = powersB.Pop();
                stuf.Enqueue(inP / div);
                inP = inP % div;
            }
            StringBuilder sb = new();
            for (int i = 0; i < count; i++)
            {
                sb.Append((char)(stuf.Dequeue() + '0'));
            }
            return sb.ToString();
        }
         string Converttostring(byte[] inP)
        {
            int times = 1;
            int num = 0;
            for(int i =0; i < inP.Length;i++)
            {
                num += inP[i]*times;
                times *= 256;
            }
            return baseConverter(num, 2);

        }
        public string Decode(byte[] inpp)
        {
            string inP = Converttostring(inpp);
            inP = new string( inP.Reverse().ToArray());
            inP += "00";
            StringBuilder sb = new();
            int spot = 0;
            for(int i =0; i < inP.Length+1;i++)
            {
                string val = inP.Substring(spot,i-spot);
                foreach(var data in output)
                {
                    if(data.Value .Equals (val))
                    {
                        sb.Append(data.Key);
                        spot = i;
                    }
                }
            }
            return sb.ToString();
        }
        public byte[] Encode()
        {
            for (int i = 0; i < input.Length; i++)
            {
                frequency[input[i]] += 1;
            }
            PriorityQueue<Node, int> Pque = new();
            foreach (var data in frequency)
            {
                Node temp;
                temp = new Node(data.Key, data.Value);
                Pque.Enqueue(temp, temp.frequency);
            }
            while(Pque.Count>1)
            {
                Node temp1;
                Node temp2;
                temp1 = Pque.Dequeue();
                temp2 = Pque.Dequeue();
                Node temp3;
                temp3 = new Node('>', temp1.frequency + temp2.frequency);
                temp3.left = temp1;
                temp3.right = temp2;
                Pque.Enqueue(temp3, temp3.frequency);
            }
            string position = "";
            Queue<outPNode> outP = new Queue<outPNode>();

            inOrderRecursive(outP, Pque.Dequeue(), position);  
            while(outP.Count>0) 
            {
                outPNode temp = outP.Dequeue();
                if (temp.letter == '>')
                {
                    continue;
                }
                output.Add(temp.letter, temp.pos);
            }
            StringBuilder sb = new();
            foreach(var l in input)
            {
                sb.Append(output[l]); 
            }
            byte[] bites = new byte[sb.Length/8];
            int times = 1;
            int num = 0;
            int count = 0;
            int pos = 0;
            int num2 = 0;
            foreach (var c in sb.ToString())
            {
                num += ((int)c-48) * times;
                num2 += ((int)c - 48) * times;
                count++;
                times *= 2;
                if(count == 8)
                {
                    times = 1;
                    count = 0;
                    bites[pos] = (byte)num;
                    pos++;
                    num = 0;
                }
            }
           return bites;




        }
    }
}
