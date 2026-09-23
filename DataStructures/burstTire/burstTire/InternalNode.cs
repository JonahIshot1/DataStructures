using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace burstTire
{
    internal class InternalNode : BurstNode
    {
        Dictionary<char,BurstNode> children = new Dictionary<char,BurstNode>();
        int BP;
        bool wordExists;
        string word;
        public InternalNode(BurstTrie parent, int dep,int bp) : base(parent,dep)
        {
            BP = bp;
            wordExists= false;
            //for(int i = 0; i < 26;i++)
            //{
            //    children.Add((char)(i+'a'), new ContainerNode(dep, parent));
            //}
        }

        public override int Count => throw new NotImplementedException();

        public override BurstNode Insert(string value)
        {
            if(value.Length==Depth)
            {
                word = value; 
                wordExists= true;
                return this; 
            }
            char letter = value.Substring(Depth, 1)[0];
            if (!children.ContainsKey(letter)) children.Add((char)(letter), new ContainerNode(Depth, ParentTrie,BP));
            children[letter] = children[letter].Insert(value);
            return this;

        }

        public override BurstNode? Remove(string value, out bool success)
        {
            if (Depth < value.Length)
            {
                char letter = value.Substring(Depth, 1)[0];
                success = true;
                return children[letter].Search(value);
            }
            if (word == value)
            {
                word = null;
                wordExists = false;
                success = true;
                return this;
            }
            success = false;
            return null;
        }

        public override BurstNode? Search(string prefix)
        {
            if (Depth < prefix.Length)
            {
                char letter = prefix.Substring(Depth, 1)[0];
                return children[letter].Search(prefix);
            }
            if (word == prefix) return this;
            return null;
        }

        internal override void GetAll(List<string> output)
        {
            if (wordExists) output.Add(word);
            foreach (var chil in children)
            {
                chil.Value.GetAll(output);
            }
        }
    }
}
