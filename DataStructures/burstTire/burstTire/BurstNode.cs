using System;
using System.Collections.Generic;
using System.Text;

namespace burstTire
{
    public abstract class BurstNode
    {
        // The Trie this node belongs to
        public int Depth;
        internal BurstTrie ParentTrie;
        // The amount of values contained in this node
        public abstract int Count { get; }
        // Creates the Node referencing its parent-trie
        protected BurstNode(BurstTrie parent,int depth){

            ParentTrie = parent; Depth = depth;}

        // Abstract recursive insertion function, returns replacement value for back-propagation 
        public abstract BurstNode Insert(string value);
        // Abstract recursive deletion function, returns replacement value for back-propagation    
        public abstract BurstNode? Remove(string value, out bool success);
        // Get a Node containing a defined prefix
        public abstract BurstNode? Search(string prefix);
        // Gets all items in order recursively
        internal abstract void GetAll(List<string> output);
    }
}
