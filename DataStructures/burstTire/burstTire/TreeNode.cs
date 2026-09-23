using System;
using System.Collections.Generic;
using System.Text;

namespace burstTire
{
    public class TreeNode<T>
    {
        public TreeNode<T> Left { get; set; } //Instead of Next
        public TreeNode<T> Right { get; set; } //Instead of Previous

        public T Value { get; set; }
    }
}
