using System;
using System.Collections.Generic;
using System.Text;

namespace ContingSort
{
    public static class Sorty
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
            int[] outP = new int[max + 1];
            for (int i = 0; i < list.Length; i++)
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
        public static int[] bucketSort(int[] list)
        {
            if (list.Length == 0) return null;
            int bucketCount = (int)Math.Sqrt(list.Length);
            int max = 0;
            for (int i = 0; i < list.Length; i++)
            {
                if (list[i] > max)
                { max = list[i]; }
            }
            int partVal = 

            return null;
        }
    }
}
