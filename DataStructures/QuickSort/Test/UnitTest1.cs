using QuickSort;

namespace Test
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

        }
        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(10000)]
        public void Test2(int size)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }
            list.Shuffle();
            var arr = QuickSort.QuickSort.Sort(list.ToArray());
            list.Sort();
            for (int i = 0; i < list.Count; i++)
            {
                Assert.Equal(list[i], arr[i]);
            }
        }
    }
}
