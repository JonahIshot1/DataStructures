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
            var e = new Vertex<string>("E") { Edges = new List<Edge<string>>() };

            graph.vertices.AddRange(new[] { a, b, c, d, e });

            // Manually connect edges (since AddEdge is buggy)
            var ab = new Edge<string>(a, b, 1);
            var ac = new Edge<string>(a, c, 2);
            var cd = new Edge<string>(c, d, 4);
            var bd = new Edge<string>(b, d, 1);
            var de = new Edge<string>(d, e, 1);
            var be = new Edge<string>(b, e, 3);



            a.Edges.Add(ab);
            a.Edges.Add(ac);
            b.Edges.Add(bd);
            c.Edges.Add(cd);
            d.Edges.Add(de);
            b.Edges.Add(be);


            // Act
            var path = graph.Pathfindgood(a, e);

            // Assert
            Assert.NotNull(path);
            Assert.Equal(3, path.Count);

        }
        [Fact]
        public void Pathfindimpossible()
        {
            Graph<string> graph = new Graph<string>();

            var a = new Vertex<string>("A") { Edges = new List<Edge<string>>() };
            var b = new Vertex<string>("B") { Edges = new List<Edge<string>>() };
            var c = new Vertex<string>("C") { Edges = new List<Edge<string>>() };
            var d = new Vertex<string>("D") { Edges = new List<Edge<string>>() };
            var e = new Vertex<string>("E") { Edges = new List<Edge<string>>() };

            graph.vertices.AddRange(new[] { a, b, c, d, e });

            // Manually connect edges (since AddEdge is buggy)
            var ab = new Edge<string>(a, b, 1);
            var ac = new Edge<string>(a, c, 2);
            var cd = new Edge<string>(c, d, 4);
            var bd = new Edge<string>(b, d, 1);
            var de = new Edge<string>(d, e, 1);
            var be = new Edge<string>(b, e, 3);

            
            a.Edges.Add(ab);
            a.Edges.Add(ac);
            b.Edges.Add(bd);
            c.Edges.Add(cd);


            // Act
            List<Edge<string>> path = graph.Pathfindgood(a, e);

            // Assert
            Assert.Null(path);
        }
    }
}
