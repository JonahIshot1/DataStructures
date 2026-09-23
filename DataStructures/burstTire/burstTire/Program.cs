namespace burstTire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BurstTrie trie = new BurstTrie(5);
            trie.Insert("hello");
            trie.Insert("he");
            trie.Insert("lo");
            trie.Insert("hell"); 
            trie.Insert("hel");
            trie.Insert("loooser");
            
            List<string> words = [];
            words = trie.GetAll();
            var i = trie.Search("he");
            var l = false;
            var b = trie.Remove("he",out l);
        }
    }

}
