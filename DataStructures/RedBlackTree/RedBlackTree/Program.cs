
namespace RedBlackTree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    //RedBlackTree<int> twe = new(4);
            //    //twe.Insert2(1);
            //    //twe.Insert2(5);
            //    //twe.Insert2(6);
            //    //twe.Insert2(8);
            //    RedBlackTree<int> tree =
            //new RedBlackTree<int>();
            //    tree.Insert2(4);
            //    tree.Insert2(1);
            //    tree.Insert2(5);
            //    tree.Insert2(6);
            //    tree.Insert2(8);


            //    RedBlackTreeConsoleVisualizer<int> visualizer =
            //        new RedBlackTreeConsoleVisualizer<int>(tree);

            //    visualizer.Show();

            //    Console.ReadLine();
            RedBlackTree<int> tree = new RedBlackTree<int>();

            tree.Insert2(50);
            tree.Insert2(67);
            tree.Insert2(100);
            tree.Insert2(20);
            tree.Insert2(29);
            tree.Insert2(60);
            tree.Insert2(80);
            tree.Insert2(10);
            tree.Insert2(25);



            RedBlackTreeConsoleVisualizer<int> visualizer =
                new RedBlackTreeConsoleVisualizer<int>(tree);

            visualizer.Show();

            Console.ReadLine();

        }
    }
}



////for(int i =0; i < 255; i++)
////{
////   for(int l=0; l<255;l++)
////    {
////        Console.WriteLine("console in pink", Color.Pink);
////        Console.WriteLine("console in default");
////    }
////}
//int r = 225;
//int g = 255;
//int b = 250;
//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine("penis", Color.FromArgb(r, g, b));

//    r -= 18;
//    b -= 9;
//}