using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Radick
{
    public class Sort
    {
        public static int[] County(int[] list)
        {
            if (list.Length == 0) return null;
            int max = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] > max)
                { max = list[i]; }
            }
            int times = 0;
            int temp = max;
            while (temp>0)
            {
                temp /= 10;
                times++;
            }

            for(int q =0; q < times;q++)
            {
                int[] rad = new int[10];
                for(int i =0; i <list.Length;i++ )
                {
                    rad[list[i] % 10]++;
                }
                for(int i =1; i<10;i++)
                {
                    rad[i] = rad[i - 1] + rad[i];
                }
                int[] temps = new int[list.Length];
                for (int i = list.Length-1; i >=0;i--)
                {
                    rad[list[i] % 10]--;
                    temps[rad[list[i] % 10]] = list[i];
                }
                for(int i =0; i< list.Length;i++)
                {
                    list[i] = temps[i];
                }


            }
            return list;

            return null;
        }
    }
}
