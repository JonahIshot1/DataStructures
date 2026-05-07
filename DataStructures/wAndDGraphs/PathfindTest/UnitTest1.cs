using wAndDGraphs;
using System;
using System.Collections.Generic;
using Xunit;
namespace PathfindTest
{
    public class UnitTest1
    {

        [Fact]
        public void Pathfind_ShouldReturnCorrectPath()
        {
            // Arrange
            Graph<string> graph = new Graph<string>();

            var a = new Vertex<string>("A") { Edges = new List<Edge<string>>() };
            var b = new Vertex<string>("B") { Edges = new List<Edge<string>>() };
            var c = new Vertex<string>("C") { Edges = new List<Edge<string>>() };
            var d = new Vertex<string>("D") { Edges = new List<Edge<string>>() };

            graph.vertices.AddRange(new[] { a, b, c, d });

            // Manually connect edges (since AddEdge is buggy)
            var ab = new Edge<string>(a, b, 1);
            var ac = new Edge<string>(a, c, 1);
            var bc = new Edge<string>(b, c, 1);
            var bd = new Edge<string>(b, d, 1);
            var cd = new Edge<string>(c ,d, 1);


            a.Edges.Add(ab);
            a.Edges.Add(ac);
            b.Edges.Add(bc);
            b.Edges.Add(bd);
            c.Edges.Add(cd);

            // Act
            var path = graph.PathfindBad(a, d);

            // Assert
            Assert.NotNull(path);
            Assert.Equal(2, path.Count);
  
        }
    }
}
