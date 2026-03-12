namespace AVLtree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AVLtree<string> t = new AVLtree<string>();
            t.Insert2("f");
            t.Insert2("f");
            //t.Insert2("g");
            //t.Insert2("b");
            //t.Insert2("a");
            //t.Insert2("c");
            //t.Insert2("e");
            //t.Insert2("g");
            //t.Insert2("i");
            //t.Insert2("h");
            //t.Insert2("q");
            //t.Insert2("w");
            //t.Insert2("e");
            //t.Insert2("p");
            //t.Insert2("z");

            //bool b = t.Insert(67);
            //bool h = t.Insert(67);
            //Node<int> p = t.Search(13);

            AVLtree<int> tree = new AVLtree<int>();

            tree.Insert2(3);
            tree.Insert2(2);
            tree.Insert2(1);
            tree.Insert2(4);
            tree.Insert2(8);
            tree.Insert2(6);
            tree.Insert2(9);
            tree.Insert2(10);
            tree.Insert2(7);
            tree.Insert2(5);
            tree.Insert2(13);
            tree.Insert2(14);

            // int l = t.Maximum(t.root.Right.Right);
            bool q;
            Queue<int> s = new Queue<int>();

           // tree.inOrderRecursive(s, tree.root);
        }
    }
}
