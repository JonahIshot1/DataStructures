namespace SortedDoublyLinkedList
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            LList<int> list = new LList<int>();
            list.IN(1);
            list.IN(2);
            list.IN(3);
            list.IN(4);
            list.IN(5);
            list.IN(6);
            list.IN(7);
            bool b=list.remove(11);
            list.remove(2);
            list.remove(7);
        }
    }
}
