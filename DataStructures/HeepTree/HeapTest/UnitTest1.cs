using HeepTree;
namespace HeapTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Heep<int> hep = new Heep<int>();
            hep.insert(1);
            hep.insert(8);
            hep.insert(2);
            hep.insert(14);
            hep.insert(5);
            hep.insert(67);
            hep.insert(12);
            hep.insert(991);
            hep.insert(3);
            int[] done = hep.tree;
            for (int i = 1;i< hep.Count;i++)
            {
                int parent = (i - 1) / 2;
                Assert.True(done[parent] < done[i]);
            }
            //Assert.True(done[0] == hep.pop());
            //int top = hep.pop();
            done = hep.tree;
            for (int i = 1; i < hep.Count; i++)
            {
                int parent = (i - 1) / 2;
                Assert.True(done[parent] < done[i]);
            }
            int[] sorted = new int[hep.Count];
            int c = hep.Count;
            for(int i =0; i < c;i++)
            {
                if(i==c-3)
                {

                }

                sorted[i] = hep.pop();
            }
            for(int i =1; i < sorted.Length;i++)
            {
                Assert.True(sorted[i] > sorted[i-1]);
            }
        }
    }
}
