using unionFind;

namespace unionFIndTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestAreConected()
        
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            QuickFInd<int> find = new QuickFInd<int>(nums);
            Assert.False(find.AreConnected(1, 2));
            Assert.False(find.AreConnected(7, 8));
            find.Union(1, 2);
            Assert.True(find.AreConnected(1, 2));
            Assert.False(find.AreConnected(1, 8));
            //__________________________________________
            Assert.Throws<Exception>(() => find.AreConnected(1, 11));
            //_____________________________________________
            nums = new int[10000];
            for(int i =0; i < nums.Length;i++)
            {
                nums[i] = i;
            }
            QuickFInd<int> find2 = new QuickFInd<int>(nums);
            Assert.False(find2.AreConnected(11, 22111));
            Assert.False(find2.AreConnected(7241, 812));
            find2.Union(11, 2111);
            Assert.True(find2.AreConnected(11, 22111));
            Assert.False(find2.AreConnected(10, 812));

        }
        [Fact]
        public void TestFind()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            QuickFInd<int> find = new QuickFInd<int>(nums);
            Assert.True(find.Find(1)==0);
            find.Union(1, 2);
            Assert.True(find.Find(2) == 0);
            //_____________________________________
            nums = new int[10000];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i;
            }
            QuickFInd<int> find2 = new QuickFInd<int>(nums);
            Assert.True(find.Find(99) == 100);

        }
        [Fact]
        public void Test1()
        {

        }
    }
    public class UnitTest2
    {
        [Fact]
        public void Test1()
        {

        }
    }
}
