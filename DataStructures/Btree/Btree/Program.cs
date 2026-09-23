namespace Btree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Tree<int> tre = new(Comparer<int>.Default);
            tre.Insert(1);
            tre.Insert(45);
            tre.Insert(22); 
            tre.Insert(99);
            tre.Insert(20);

             var l =tre.Contains(100000);
            for (int i = 3; i < 10000; i *= 3)
            {
                tre.Insert(i);
                TreePrinter.Print(tre);
                Console.Write("current added = ");
                Console.WriteLine(i);
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            }
            TreePrinter.Print(tre);
        }
    }
}
