using AVLtree;

namespace AVLTEST
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            AVLtree<int> tree = new AVLtree<int>();
            for(int i =0; i < 1000;i++)
            {
                tree.Insert2(i);
            }
            Queue<Node<int>> s = new Queue<Node<int>>();
            tree.inOrderRecursive(s,tree.root);
            while(s.Count>0)
            {
                Node<int> temp = s.Dequeue();
                Assert.True(Math.Abs(tree.checkBalance(temp)) < 2);

            }
            Assert.Equal(1, 1);
        }
    }
}
