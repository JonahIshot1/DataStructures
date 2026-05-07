using System.Net.Http.Headers;
using System.Security.AccessControl;

namespace wAndDGraphs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Random rand = new Random();
            Graph<int> grap = new Graph<int>();
            Vertex<int>[] verti = new Vertex<int>[100];
            for(int i =0; i < verti.Length;i++)
            { 
                verti[i] = new Vertex<int>(rand.Next(1, 100));
                grap.AddVertex(verti[i]);
            }
            for(int i = 0; i < 1000; i++)
            {
                grap.AddEdge(verti[rand.Next(1, 100)], verti[rand.Next(1, 100)],10);
            }

            Queue<int> p = grap.Traverse(grap.vertices[2]);
        }
    }
}
