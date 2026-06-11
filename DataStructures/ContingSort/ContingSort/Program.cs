using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Windows.Markup;

namespace ContingSort
{
    internal class Program
    {
        public int[] sort(int[] list)
        {
            if (list.Length == 0) return null;
            int max = 0;
            for(int i =0; i <list.Length;i++)
            {
                if (list[i] > max)
                { max = list[i]; }
            }
            int[] outP = new int[max+1];
            for(int i =0; i < list.Length;i++)
            {
                outP[list[i]]++;
            }
            int index = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (outP[index] == 0)
                {
                    index++;
                    i--;
                    continue;
                }
                list[i] = index;
                outP[index]--;
            }
            return outP;
        }
        static void Main(string[] args)
        {

            Console.Write("how many number do you want in you list:");
            string word = Console.ReadLine();
            int length = 0;
            while (int.TryParse(word, out length)==false)
            {
                Console.Write("THAT DOESNT WORK!!!!!!!!!!!!!! GIVE ME A NEW NUM PLS:");
                word= Console.ReadLine();
            }

            Console.Write("whats ur min val:");
            string word2 = Console.ReadLine();
            int min = 0;
            while (int.TryParse(word2, out min) == false)
            {
                Console.Write("THAT DOESNT WORK!!!!!!!!!!!!!! GIVE ME A NEW min PLS:");
                word2 = Console.ReadLine();
            }

            Console.Write("whats ur max val:");
            string word3 = Console.ReadLine();
            int max = 0;
            while (true)
            {
                if(int.TryParse(word3, out max) == true)
                {
                    if (max > min)
                    {
                        break;
                    }
                    
                }
                Console.Write("THAT DOESNT WORK!!!!!!!!!!!!!! GIVE ME A NEW max PLS:");
                word3 = Console.ReadLine();
            }
            int[] inP = new int[length];
            Random randy = new Random();
            Console.Write("vals:");
            for(int i =0; i < length;i++)
            {
                inP[i]= randy.Next(min,max);
                Console.Write(inP[i]);
                if (i < length - 1)
                {
                    Console.Write(",");
                }

            }
            Console.WriteLine(" ");
            Sorty.County(inP);
            Console.Write("OutP:");
            for (int i = 0; i < length; i++)
            {
                Console.Write(inP[i]);
                if (i < length - 1)
                {
                    Console.Write(",");
                }

            }





        }
    }
}
