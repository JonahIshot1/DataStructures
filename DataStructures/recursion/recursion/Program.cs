using System.Text;

namespace recursion
{
    internal class Program
    {
        static void doStuf(int x,int lim)
        {
            if (x > lim) return;
            x+=2;
            StringBuilder sb = new StringBuilder();
            int pad = (lim / 2)-(x/2);

            for(int i =0; i < pad;i++)
            {
                sb.Append(' ');
            }
            for (int i = 0; i < x; i++)
            {
                sb.Append('*');
            }
            for (int i = 0; i < pad; i++)
            {
                sb.Append(' ');
            }

            Console.WriteLine(sb.ToString());
            doStuf(x, lim);
        }
        static void Main(string[] args)
        {
            int i = 0;
            doStuf(i, 100);
        }
    }
}
