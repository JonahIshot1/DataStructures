using LRU_Cache;
namespace LRU_Test
{
    public class UnitTest1
    {
        [Fact]
        public void TestAdd()
        {
            ICachee<int, int> cash = new ICachee<int, int>();
            cash.Put(1, 1);
            cash.Put(2, 2);
            Assert.True(cash.dic.ContainsKey(1));
            Assert.True(cash.dic.ContainsKey(2));
            Assert.True(cash.valuesList.Contains(1));
            Assert.True(cash.valuesList.Contains(2));

            for(int i = 5; i < 1000;i++)
            {
                cash.Put(i, i * 2);

            }
            Assert.True(cash.dic.ContainsKey(100));
            Assert.True(cash.dic.ContainsKey(200));
            Assert.True(cash.valuesList.Contains(100));
            Assert.True(cash.valuesList.Contains(200));
            Assert.True(cash.dic[100] == 200);
        }
        [Fact]
        public void TestRemove()
        {
            ICachee<int, int> cash2 = new ICachee<int, int>();
            cash2.Put(1, 1);
            cash2.Put(2, 2);
            cash2.removeLast();
            Assert.True(!cash2.dic.ContainsKey(1));
            Assert.True(cash2.dic.ContainsKey(2));
            Assert.True(!cash2.valuesList.Contains(1));
            Assert.True(cash2.valuesList.Contains(2));

            for (int i = 5; i < 1000; i++)
            {
                cash2.Put(i, i * 2);

            }
            cash2.removeLast();
            Assert.True(!cash2.dic.ContainsKey(2));
            Assert.True(cash2.dic.ContainsKey(100));
            Assert.True(cash2.dic.ContainsKey(200));
            Assert.True(cash2.valuesList.Contains(100));
            Assert.True(cash2.valuesList.Contains(200));
            Assert.True(cash2.dic[100] == 200);
        }
        [Fact]
        public void TryGet()
        {
            ICachee<int, int> cash2 = new ICachee<int, int>();
            cash2.Put(1, 1);
            cash2.Put(2, 2);
            int p;
            Assert.True(cash2.TryGetValue(1,out p));
            Assert.True(p==1);

            for (int i = 5; i < 1000; i++)
            {
                cash2.Put(i, i * 2);

            }
            cash2.removeLast();
            int q;
            int z;
            Assert.True(cash2.TryGetValue(20, out q));
            Assert.True(cash2.TryGetValue(430, out z));
            Assert.True(!cash2.TryGetValue(100000, out p));
            Assert.True(q==40);
            Assert.True(z==860);
        }

    }
}
