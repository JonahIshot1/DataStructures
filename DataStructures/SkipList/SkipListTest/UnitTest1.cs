using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using SkipList;

namespace SkipListTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestGoDown()
        {
            SList<int> list = new SList<int>();
            for (int i = 0; i < 100; i++)
            {
                list.IN(i);
            }
            Node<int> temp = list.sent;
            while(temp.Down!=null)
            {
               temp = temp.Down;
            }
            Assert.True(temp.Equals(list.goDown(list.sent)));
        }
        [Fact]
        public void TestNumDump()
        {
            Queue<int> Sample = new();
            SList<int> list = new SList<int>();
            Node<int> temp = list.sent; 
            for (int i = 0; i < 100; i++)
            {
                Sample.Enqueue(i);
                temp.Next = new Node<int>(i,0);
                temp = temp.Next;
            }
            Queue<int> testSubject = list.numDump();
            for (int i = 0; i < testSubject.Count; i++)
            {
                Assert.True(Sample.Dequeue().Equals(testSubject.Dequeue()));
            }
        }
        [Fact]
        public void NoLostNumbers1()
        {
            SList<int> list = new SList<int>();
            for (int i = 0; i < 100; i++)
            {
                list.IN(i);
            }
            Queue<int> testSubject = list.numDump();
            Assert.True(testSubject.Count==100);
        }
        [Fact]
        public void TestBuildStack()
        {
            Node<int> Noodle = new(32,6);
            SList<int> list = new SList<int>();
            list.BuildStack(Noodle);
            Node<int> Temp = Noodle;
            for(int i = Noodle.Height; i >0;i--)
            {
                Assert.True(Temp.Value == Noodle.Value);
                Assert.True(Temp.Height==i);
                Temp = Temp.Down;
            }

            
        }
        [Fact]
        public void TestGetNewHeight()
        {
            SList<int> list = new SList<int>();
            for (int i = 0; i < 100; i++)
            {
                list.IN(i);
            }
            for(int i =0; i < 128;i++)
            {
                Assert.True(list.sent.Height+1 >= list.getNewHeight());
            }
            
        }
        [Fact]
        public void TestBuildSent()
        {
            Random Randy = new Random();
            SList<int> list = new SList<int>();
            for (int i = 0; i < 100; i++)
            {
                list.IN(i);
            }
            for (int i = 0; i < 128; i++)
            {
                Node<int> sent = list.sent;
                Node<int> Temp = new(i, Randy.Next(1, 100));
                list.BuildSent(Temp);
                if(Temp.Height> sent.Height)
                {
                    Assert.True(list.sent.Height == Temp.Height);
                }
            }

        }
        [Fact]
        public void NoLostNumbers2()
        {
            Random randy = new Random();
            SList<int> list2 = new SList<int>();
            for (int i = 0; i < 100; i++)
            {
                list2.IN(randy.Next(1, 10067));
            }

            Assert.True(list2.numDump().Count == 100);
        }

    }
}
