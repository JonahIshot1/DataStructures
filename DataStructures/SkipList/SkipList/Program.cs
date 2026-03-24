namespace SkipList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SList<int> list = new SList<int>();
            list.IN(5);
            list.IN(6);
            list.IN(512);
            list.IN(216);
            list.IN(35);
            list.IN(62);

            Queue<int> outP = list.numDump();


        }
    }
}
