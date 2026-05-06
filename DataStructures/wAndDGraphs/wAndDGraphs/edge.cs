using System;
using System.Collections.Generic;
using System.Text;

namespace wAndDGraphs
{
    public class Edge<T>
    {
        public Vertex<T> StartVertex { get; set; }
        public Vertex<T> EndVertex { get; set; }
        public float Cost { get; set; }
        public Edge(Vertex<T> start, Vertex<T> end, float cost) 
        {
            StartVertex = start;
            EndVertex = end;
            Cost=cost;
        }
    }

    public class Vertex<T>
    {
        public T Value { get; set; }
        public List<Edge<T>> Edges { get; set; }

        public Vertex(T value) { Value = value; Edges = new(); }
    }
    public class VertexInfo<T>
    {
        public Vertex<T> Vertex; // This is the original vertex

        public float TotalCost;
        public bool IsVisited;
        public Edge<T> FoundingEdge;
        public VertexInfo(Vertex<T> vertex) { Vertex = vertex; IsVisited = false;FoundingEdge = null;TotalCost = float.MaxValue; }
    }

}
