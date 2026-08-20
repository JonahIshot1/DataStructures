using System;
using System.Collections.Generic;
using System.Text;

namespace huffman_coding
{
    public class outPNode
    {
        public char letter;
        public string pos;

        public outPNode(char letter, string pos)
        {
            this.letter = letter;
            this.pos = pos;
        }
    }
}
