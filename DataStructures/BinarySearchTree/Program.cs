namespace BinarySearchTree
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            Tree<int> t = new Tree<int>();
           // t.Insert(67);
            t.Insert(41);
            t.Insert(90);
            t.Insert(100);
            t.Insert(80);
            t.Insert(95);
            t.Insert(13);
            t.Insert(10);
            t.Insert(2);
            bool b =t.Insert(67);
            bool h = t.Insert(67);
            Node<int> p = t.Search(13);
        }
    }
}
