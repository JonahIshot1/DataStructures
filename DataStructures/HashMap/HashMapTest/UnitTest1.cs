using HashMap;
using System.IO.MemoryMappedFiles;

namespace HashMapTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestAdd()
        {
            Map<int, string> map = new Map<int, string>();
            map.Add(1, "a");
            map.Add(2, "b");
            Assert.True(map.ContainsKey(1));
            Assert.True(map.ContainsKey(2));
            Assert.False(map.ContainsKey(3));
            Map<int, string> map2 = new Map<int, string>();
            for (int i =0; i<1000;i++)
            {
                map2.Add(i,"a");
            }
            Assert.True(map2.ContainsKey(100));
            String Val = "";
            map.TryGetValue(10, out Val);

        }
        [Fact]
        public void TestGetVal()
        {
            Map<int, string> map = new Map<int, string>();
            map.Add(1, "a");
            map.Add(2, "b");
            String Val = "";
            map.TryGetValue(1, out Val);
            Assert.True(Val == "a");
            bool condish = map.TryGetValue(3, out Val);
            Assert.False(condish);

        }
        [Fact]
        public void TestRemove()

        {
            Map<int, string> map = new Map<int, string>();
            map.Add(1, "a");
            map.Add(2, "b");
            Assert.True(map.ContainsKey(1));
            map.Remove(1);
            Assert.False(map.ContainsKey(1));
            Assert.True(map.ContainsKey(2));
            Assert.False(map.Remove(1));
            map.Remove(2);
            for (int i = 0; i < 1000; i++)
            {
                map.Add(i, "a");
            }
            Assert.True(map.Remove(214));


        }
        [Fact]
        public void TestClear()
        {
            Map<int, string> map = new Map<int, string>();
            map.Add(1, "a");
            map.Clear();
            map.Add(5, "r");
            map.Add(7, "l");
            Assert.False(map.ContainsKey(2));
            Assert.True(map.ContainsKey(5));
        }
    }
}
