using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    public static class QuickSort
    {
       
        public static int Part(int[] inP, int startI, int endI)
        {
            int piv = inP[endI];
            int wall = startI;
            int cur = startI;
            for (int i = 0; i < endI - startI; i++)
            {
                if (inP[cur] > piv)
                {
                    cur++;
                    continue;
                }
                //-----------------swap---------------------//
                (inP[cur], inP[wall]) = (inP[wall], inP[cur]);
                wall++;
                cur++;
            }
            (inP[cur], inP[wall]) = (inP[wall], inP[cur]);
            return wall;
        }
        public static int Part2(int[] inP, int startI, int endI)
        {
            int lp = startI - 1;
            int rp = endI;
            int piv = inP[startI];

            while (true)
            {
                do
                {
                    lp++;
                }
                while (inP[lp] < piv);

                do
                {
                    rp--;
                } while (inP[rp] > piv);

                if (lp >= rp) return rp;

                //-----------------swap---------------------//
                (inP[rp], inP[lp]) = (inP[lp], inP[rp]);
            }
        }


        public static int[] Sort(int[] inP)
        {
            QuickSort(0, inP.Length, inP);
            return inP;

            static void QuickSort(int startI, int endI, int[] nums)
            {
                if (endI - startI <= 1) return;
                int boundry = Part2(nums, startI, endI);
                QuickSort(startI, boundry + 1, nums);
                QuickSort(boundry + 1, endI, nums);
            }
        }
    }
}
