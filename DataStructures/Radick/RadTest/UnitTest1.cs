using Radick;

namespace RadTest
{
    public class UnitTest1
    {
        [Fact]
        public void empty()
        {
            int[] arry = new int[0];
            Assert.Null(Sort.County(arry));
        }
        [Fact]
        public void alreadySortedSory()
        {
            int[] arry = { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] arry2 = { 1, 2, 3, 4, 5, 6, 7, 8 };
            Sort.County(arry);
            Assert.Equal(arry, arry2);
        }
        [Fact]
        public void normalSort()
        {
            int[] arry = { 7, 4, 2, 1, 3, 5, 8, 6 };
            int[] arry2 = { 1, 2, 3, 4, 5, 6, 7, 8 };
            Sort.County(arry);
            Assert.Equal(arry, arry2);
        }
    }
}
