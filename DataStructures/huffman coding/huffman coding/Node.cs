using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace huffman_coding
{
    [DebuggerDisplay("{letter}, L: {left}, R: {right}")]
    public class Node
    {
        public Node left;
        public Node right;
        public char letter;
        public int frequency;
        public Node(char letter, int frequency)
        {
            this.letter = letter;
            this.frequency = frequency;
            this.left = null;
            this.right = null;
        }
    }
}
