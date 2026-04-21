using System;
using Xunit;
using introToGraph;

namespace graph_test
{
    public class UnitTest1
    {
        // Helper to create graph (since your class is internal)
        private graph CreateGraph()
        {
            return new graph();
        }

        [Fact]
        public void AddVertex_ShouldReturnFalse_WhenDuplicate()
        {
            var g = CreateGraph();
            var v1 = new Vertex(1);
            var v2 = new Vertex(1); // same value

            Assert.True(g.AddVertex(v1));
            Assert.False(g.AddVertex(v2)); // duplicate
        }

        [Fact]
        public void AddVertex_ShouldReturnTrue_WhenUnique()
        {
            var g = CreateGraph();

            Assert.True(g.AddVertex(new Vertex(1)));
            Assert.True(g.AddVertex(new Vertex(2)));
        }

        [Fact]
        public void RemoveVertex_ShouldReturnFalse_WhenNotExist()
        {
            var g = CreateGraph();
            var v = new Vertex(1);

            Assert.False(g.RemoveVertex(v)); // never added
        }

        [Fact]
        public void RemoveVertex_ShouldRemoveVertexAndEdges()
        {
            var g = CreateGraph();
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);

            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddEdge(v1, v2);

            Assert.True(g.RemoveVertex(v1));

            // Ensure v1 is removed from v2's children
            Assert.DoesNotContain(v1, v2.children);
        }

        [Fact]
        public void RemoveVertex_ShouldReturnFalse_WhenAlreadyRemoved()
        {
            var g = CreateGraph();
            var v = new Vertex(1);

            g.AddVertex(v);
            g.RemoveVertex(v);

            Assert.False(g.RemoveVertex(v)); // removing again
        }

        [Fact]
        public void AddEdge_ShouldReturnFalse_WhenEdgeAlreadyExists()
        {
            var g = CreateGraph();
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);

            g.AddVertex(v1);
            g.AddVertex(v2);

            Assert.True(g.AddEdge(v1, v2));
            Assert.False(g.AddEdge(v1, v2)); // duplicate edge
        }

        [Fact]
        public void AddEdge_ShouldReturnTrue_WhenNewEdge()
        {
            var g = CreateGraph();
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);

            g.AddVertex(v1);
            g.AddVertex(v2);

            Assert.True(g.AddEdge(v1, v2));
        }

        [Fact]
        public void RemoveEdge_ShouldReturnFalse_WhenEdgeDoesNotExist()
        {
            var g = CreateGraph();
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);

            g.AddVertex(v1);
            g.AddVertex(v2);

            Assert.False(g.RemoveEdge(v1, v2)); // no edge yet
        }

        [Fact]
        public void RemoveEdge_ShouldReturnTrue_WhenEdgeExists()
        {
            var g = CreateGraph();
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);

            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddEdge(v1, v2);

            Assert.True(g.RemoveEdge(v1, v2));
        }

        [Fact]
        public void RemoveEdge_ShouldRemoveBothDirections()
        {
            var g = CreateGraph();
            var v1 = new Vertex(1);
            var v2 = new Vertex(2);

            g.AddVertex(v1);
            g.AddVertex(v2);
            g.AddEdge(v1, v2);

            g.RemoveEdge(v1, v2);

            Assert.DoesNotContain(v2, v1.children);
            Assert.DoesNotContain(v1, v2.children);
        }
    }
}