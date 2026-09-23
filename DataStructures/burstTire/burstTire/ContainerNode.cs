using burstTire.BinarySearchTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace burstTire
{
    internal class ContainerNode : BurstNode
    {
        int burstPol;
        
        BSTree<string> wordTree = new BSTree<string>();
        public override int Count => throw new NotImplementedException();

        public ContainerNode(int dept, BurstTrie parent, int BP) : base(parent,dept)
        {
            burstPol = BP;
        }

        public override BurstNode Insert(string value)
        { 
            if(wordTree.Contains(value))return this;
            wordTree.Insert(value);
            if (wordTree.count >= 5)
            {
                BurstNode NewNod;
                InternalNode NewNode = new(ParentTrie,Depth+1,burstPol);
                Queue < string > Q= new();
                Q = wordTree.LevelOrder();
                foreach(var data in Q )
                {
                    NewNode.Insert(data);
                }
                return NewNode;
            }
            return this;
        }

        public override BurstNode? Remove(string value, out bool success)
        {
            if (wordTree.Contains(value))
            {
                success = true;
                wordTree.Remove(value);
                return this;
            }
            success = false;
            return null;
        }

        public override BurstNode? Search(string prefix)
        {
            if (wordTree.Contains(prefix)) return this;

            return null;
        }

        internal override void GetAll(List<string> output)
        {
            Queue<string> words = new();
            words = wordTree.inOrderRecursive(words, wordTree.root);
            foreach (var data in words)
            {
                output.Add(data);
            }
        }
    }
}
