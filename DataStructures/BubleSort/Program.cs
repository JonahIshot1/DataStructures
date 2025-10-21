namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] imputAray = new string[]{ "brandon","joanh","emily","jhon","fluffy" };
            for (int i = 0; i < imputAray.Length; i++)
            {
                Console.Write(imputAray[i]);
                Console.Write(',');
                if (i + 1 == imputAray.Length)
                {
                    Console.WriteLine(" ");
                }
            }

            void bubleSwap<T>(T[] imput)
                where T : IComparable
            {
                bool notSwap = false;
                while (!notSwap)
                {
                    notSwap = true;
                    for (int i = 0; i < imput.Length - 1; i++)
                    {
                        if (imput[i].CompareTo(imput[i + 1])>0)
                        {
                            notSwap = false;
                            T tempValue = imput[i + 1];
                            imput[i + 1] = imput[i];
                            imput[i] = tempValue;
                        }
                        if (i + 2 == imput.Length)
                        {
                            for (int j = 0; j < imput.Length; j++)
                            {
                                Console.Write(imput[j]);
                                Console.Write(",");

                            }
                            Console.WriteLine(" ");

                        }
                    }
                }
            }
            bubleSwap<string>(imputAray);

            //for (int j = 0; j < imputAray.Length; j++)
            //{
            //    Console.Write(imputAray[j]);
            //    if (j+1 == imputAray.Length)
            //    {
            //        Console.WriteLine(" ");
            //    }
            //}
        }
    }
}
