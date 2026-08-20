using BloomFilter;

namespace BloomFilterTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestInsert()
        {
            Random random = new Random();
            BloomFilter<string> filt = new(10);
            filt.Insert("pp");
            bool done = true;
            for (int i = 0; i < filt.filters.Count; i++)
            {
                int num = Math.Abs(filt.filters[i]("pp") % filt.used.Length);
                Assert.True(filt.used[num]);
            }
            BloomFilter<int> filt2 = new(1000);
            filt2.Insert(12);
            for (int i = 0; i < 100; i++)
            {
                filt2.Insert(random.Next(1, 1000));
            }
            bool done2 = true;
            for (int i = 0; i < filt2.filters.Count; i++)
            {
                int num = Math.Abs(filt2.filters[i](12) % filt2.used.Length);
                Assert.True(filt2.used[num]);
            }

        }
        [Fact]
        public void TestProbalyContains()
        {
            Random random = new Random(1);
            BloomFilter<string> filt = new(10);
            filt.Insert("pp");
            Assert.True(filt.ProbablyContains("pp"));
            Assert.True(!filt.ProbablyContains("poop"));

            BloomFilter<int> filt2 = new(1000);
            filt2.Insert(12);
            for (int i = 0; i < 100; i++)
            {
                filt2.Insert(random.Next(1, 1000));
            }
            Assert.True(filt2.ProbablyContains(12));
            Assert.True(!filt2.ProbablyContains(407));



        }
    }
}
