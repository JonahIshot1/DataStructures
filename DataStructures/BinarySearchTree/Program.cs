namespace BinarySearchTree
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Tree<string> t = new Tree<string>();
            t.Insert("f");
            t.Insert("b");
            t.Insert("a");
            t.Insert("d");
            t.Insert("c");
            t.Insert("e");
            t.Insert("g");
            t.Insert("i");
            t.Insert("h");

            //bool b = t.Insert(67);
            //bool h = t.Insert(67);
            //Node<int> p = t.Search(13);

            // int l = t.Maximum(t.root.Right.Right);
            bool q;
            q = t.Remove("f");
            q = t.Remove("d");
            q = t.Remove("h");
            q = t.Remove("e");

        }
    }
}
