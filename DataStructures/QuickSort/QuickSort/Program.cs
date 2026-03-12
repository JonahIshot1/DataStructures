using System;
using System.Reflection.Emit;

namespace QuickSort
{
    internal class Program
    {
        
        //public static int[] Sort(int[] inP, int wall, int cu)
        //{
        //    int wallI = wall;
        //    int cur = cu;
        //    int piv = inP[inP.Length - 1];
        //    if (inP[wallI] > piv)
        //    {
        //        cur++;
        //        Sort(inP, wallI, cur);
        //    }
        //    ///swap/////
        //    inP[wall] = inP[wallI] ^ inP[cur];
        //    inP[cur] = inP[wallI] ^ inP[cur];
        //    inP[wall] = inP[wallI] ^ inP[cur];
        //    ////
        //    wall++;
        //    cur++;
        //    if (cur == inP.Length)
        //    {
        //        inP[wall] = inP[wallI] ^ inP[cur];
        //        inP[cur] = inP[wallI] ^ inP[cur];
        //        inP[wall] = inP[wallI] ^ inP[cur];
        //        return inP;
        //    }
        //    Sort(inP, wallI, cur);
        //    return inP;
        //    //sort();
        //}
        static void Main(string[] args)
        {
            int[] start = { 20, 21, 18, 19, 17, 22, 23 ,121234,98129,218971,112,49202,27832,1232}; //{ 67, 12, 14, 39, 214, 75, 26 };
            //int done = Part2(start, 0, start.Length);
            QuickSort.Sort(start);
        }
    }
}