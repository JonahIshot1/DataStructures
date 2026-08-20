namespace huffman_coding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Encooder encooder = new Encooder("hello world");
            var o = encooder.Encode();
            Console.WriteLine(o);
            foreach(var data in encooder.output)
            {
               Console.Write(data.Key);
               Console.Write(" key: ");
               Console.WriteLine(data.Value.ToString());
            }
            Console.WriteLine(encooder.Decode(o));
        }
    }
}
