using System;
using System.Collections.Generic;
using System.Text;

namespace burstTire
{
    public class BurstTrie
    {
        int burstPolocy;
        public BurstNode root;
        public BurstTrie(int burstPoloc)
        {
            burstPolocy = burstPoloc;
            root = new ContainerNode(-1, this,burstPoloc);
        }
        public void Insert(string value)
        {
            root = root.Insert(value);
        }
        public List<string> GetAll()
        {
            List<string> words = [];
            root.GetAll(words);
            return words;
        }
        public BurstNode? Search(string prefix)
        {
            return root.Search(prefix);
        }
        public BurstNode? Remove(string value, out bool success)
        {
            return root.Remove(value,out success);
        }

    }
}
