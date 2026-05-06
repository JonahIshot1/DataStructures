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
            var bc = new Edge<string>(b, c, 1);
            var cd = new Edge<string>(c, d, 1);

            a.Edges.Add(ab);
            b.Edges.Add(bc);
            c.Edges.Add(cd);

            // Act
            var path = graph.pathfindBad(a, d);

            // Assert
            Assert.NotNull(path);
            Assert.Equal(3, path.Count);

            Assert.Equal("A", path[0].StartVertex.Value);
            Assert.Equal("B", path[0].EndVertex.Value);

            Assert.Equal("B", path[1].StartVertex.Value);
            Assert.Equal("C", path[1].EndVertex.Value);

            Assert.Equal("C", path[2].StartVertex.Value);
            Assert.Equal("D", path[2].EndVertex.Value);
        }
    }
}
