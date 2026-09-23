using System;
using System.Collections.Generic;
using System.Text;


namespace Btree
{
    public static class TreePrinter
    {
        public static void Print<T>(Tree<T> tree)
        {
            if (tree.root == null)
            {
                Console.WriteLine("(empty tree)");
                return;
            }

            PrintNode(tree.root, "", true);
        }

        private static void PrintNode<T>(
            Node<T> node,
            string prefix,
            bool isLast)
        {
            Console.Write(prefix);
            Console.Write(isLast ? "└── " : "├── ");

            Console.Write("[");

            for (int i = 0; i < node.vals.Count; i++)
            {
                if (i > 0)
                    Console.Write(" | ");

                Console.Write(node.vals[i]);
            }

            Console.WriteLine("]");

            for (int i = 0; i < node.children.Count; i++)
            {
                bool lastChild = i == node.children.Count - 1;

                PrintNode(
                    node.children[i],
                    prefix + (isLast ? "    " : "│   "),
                    lastChild
                );
            }
        }
    }
}
