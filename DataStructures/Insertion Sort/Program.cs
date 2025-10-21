using System.Drawing;
using System.Numerics;

namespace Insertion_Sort
{
    internal class Program
    {

        class Cat : IComparable<Cat>
        {
            public string Name;
            public int Age;
            public Cat(string name, int age)
            { 
                Name = name;
                Age = age;
            }

            public int CompareTo(Cat other)
            { 
                return Age - other.Age;
            }
        }
        
        static void Main(string[] args)
        {
            int result<T>(T a, T b) where T : IComparable<T>
            {
                return a.CompareTo(b);
            }

            Cat fluffy = new Cat("fluffy", 10);
            Cat sam = new Cat("sam", 5);

            if (result(fluffy, sam) < 0)
            { 
            
            }

            void swap(int[] aray, Point pos)
            {
                int temp = aray[pos.X];
                aray[pos.X] = aray[pos.Y];
                aray[pos.Y] = temp;
            }
            int[] imputs = { 1, 21431,13135,33,6542,87652,5672,44,2,1,994};
            for (int i = 0; i < imputs.Length; i++)
            {
                for (int j = i; j>0;j--) 
                {
                    if (imputs[j] < imputs[j-1])
                    {
                        swap(imputs, new Point(j, j - 1));
                    }
                }
                for(int j = 0; j<imputs.Length;j++)
                {
                    Console.Write(imputs[j]);
                    Console.Write(',');
                }
                Console.WriteLine(" ");               
            }
        }
    }
}
