using unionFind;

namespace unionFIndTest
{
    public class TestQuickFind
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
            nums = new int[30000];
            for(int i =0; i < nums.Length;i++)
            {
                nums[i] = i;
            }
            QuickFInd<int> find2 = new QuickFInd<int>(nums);
            Assert.False(find2.AreConnected(11, 22111));
            Assert.False(find2.AreConnected(7241, 812));
            find2.Union(11, 22111);
            Assert.True(find2.AreConnected(11, 22111));
            Assert.False(find2.AreConnected(10, 812));
            Assert.Throws<Exception>(() => find.AreConnected(1,211111));

        }
        [Fact]
        public void TestFind()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            QuickFInd<int> find = new QuickFInd<int>(nums);
            Assert.True(find.Find(1)==0);
            find.Union(1, 2);
            Assert.True(find.Find(2) == 0);
            Assert.Throws<Exception>(() => find.AreConnected(21, 1113131));
            //_____________________________________
            int[]nums2 = new int[30000];
            for (int i = 0; i < nums2.Length; i++)
            {
                nums2[i] = i;
            }
            QuickFInd<int> find2 = new QuickFInd<int>(nums2);
            int l=find2.Find(99);
            Assert.True(find2.Find(99) == 99);
            Assert.Throws<Exception>(() => find.AreConnected(1, 1111111));

        }
    }
    public class TestQuickUnion
    {
        [Fact]
        public void TestAreConected()

        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            QuickUnion<int> find = new QuickUnion<int>(nums);
            Assert.False(find.AreConnected(1, 2));
            Assert.False(find.AreConnected(7, 8));
            find.Union(1, 2);
            Assert.True(find.AreConnected(1, 2));
            Assert.False(find.AreConnected(1, 8));
            //__________________________________________
            Assert.Throws<Exception>(() => find.AreConnected(1, 11));
            //_____________________________________________
            nums = new int[30000];
            for (int i = 0; i < nums.Length; i++)
            {
                nums[i] = i;
            }
            QuickUnion<int> find2 = new QuickUnion<int>(nums);
            Assert.False(find2.AreConnected(11, 22111));
            Assert.False(find2.AreConnected(7241, 812));
            find2.Union(11, 22111);
            Assert.True(find2.AreConnected(11, 22111));
            Assert.False(find2.AreConnected(10, 812));

        }
        [Fact]
        public void TestFind()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            QuickUnion<int> find = new QuickUnion<int>(nums);
            Assert.True(find.Find(1) == 0);
            find.Union(1, 2);
            Assert.True(find.Find(2) == 1);
            //_____________________________________
            Assert.Throws<Exception>(() => find.AreConnected(1, 1111));
            int[] nums2 = new int[30000];
            for (int i = 0; i < nums2.Length; i++)
            {
                nums2[i] = i;
            }
            QuickUnion<int> find2 = new QuickUnion<int>(nums2);
            int l = find2.Find(99);
            Assert.True(find2.Find(99) == 99);
            Assert.Throws<Exception>(() => find.AreConnected(1, 11111111));

        }
    }
}
