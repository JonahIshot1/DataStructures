namespace SelectionSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] imputs ={ 1, 2, 71, 21, 33, 435, 153, 946 };
            for (int i = 0; i < imputs.Length; i++)
            {
                int smallestLocation = i;
                for (int j = i + 1; j < imputs.Length; j++)
                {
                    if (imputs[j] < imputs[smallestLocation])
                    {                        
                        smallestLocation = j;
                    }                    
                }

                int temp = imputs[i];
                imputs[i] = imputs[smallestLocation];
                imputs[smallestLocation] = temp;

                for (int j = 0; j < imputs.Length; j++)
                {
                    Console.Write(imputs[j]);
                    Console.Write(",");
                    if (j == imputs.Length - 1)
                    {
                        Console.WriteLine(" ");
                    }
                }
            }
        }
    }
}
