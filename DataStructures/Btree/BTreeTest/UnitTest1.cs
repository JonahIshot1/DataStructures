using Btree;
namespace BTreeTest
{
    public class UnitTest1
    {
        [Fact]
        public void Testcontains()
        {
            Tree<int> tre = new(Comparer<int>.Default);
            tre.Insert(1);
            tre.Insert(41);
            tre.Insert(22);
            tre.Insert(92);
            tre.Insert(20);
            for (int i = 3; i < 10000; i *= 3)
            {
                tre.Insert(i);
            }

            Assert.False(tre.Contains(100000));
            Assert.True(tre.Contains(22));
            Assert.True(tre.Contains(20));
            Assert.True(tre.Contains(1));
        }
    }
}
