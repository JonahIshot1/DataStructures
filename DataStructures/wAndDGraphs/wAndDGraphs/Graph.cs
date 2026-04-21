using System;
using System.Collections.Generic;
using System.Text;

namespace wAndDGraphs
{
    public class Graph<T>()
    {
        public List<Vertex<T>> vertices = [];
        private List<Edge<T>> edges = [];
        public bool AddVertex(Vertex<T> vertex)
        {
            if (Search(vertex.Value) != null) return false;
            vertices.Add(vertex);
            return true;
        }
        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (vertex == null) return false;
            for (int i = 0; i < vertices.Count; i++)
            {
                if (GetEdge(vertices[i], vertex) != null) RemoveEdge(vertices[i], vertex);
            }
            vertices.Remove(vertex);
            return true;
        }
        public bool AddEdge(Vertex<T> a, Vertex<T> b, float distance)
        {
            if (vertices.Contains(a) || vertices.Contains(b)) return false;
            if (GetEdge(a, b) is null) return false;
            if (a.Edges.Contains(GetEdge(a, b))) return false;
            a.Edges.Add(new Edge<T>(a, b, distance));
            return true;
        }
        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (vertices.Contains(a) || vertices.Contains(b)) return false;
            Edge<T> temp = GetEdge(a, b);
            if (temp is null) return false;
            edges.Remove(temp);
            a.Edges.Remove(temp);
            return true;
        }
        public Edge<T> GetEdge(Vertex<T> a, Vertex<T> b)
        {
            for (int i = 0; i < edges.Count; i++)
            {
                if (edges[i].StartVertex == a && edges[i].EndVertex == b)
                {
                    return edges[i];
                }
            }
            return null;
        }
        public Vertex<T> Search(T value)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Value.Equals(value))
                {
                    return vertices[i];
                }
            }
            return null;
        }
        public Queue<T> traverse(Vertex<T>start)
        {
            if (start is null) return null;
            Queue < Vertex<T> > next = new();
            Queue<T> outP = new();
            
            next.Enqueue(start);
            while(next.Count!=0)
            {
                Vertex<T> cur = next.Dequeue();
                if (cur.Edges is not null)
                {
                    for (int i = 0; i < cur.Edges.Count; i++)
                    {
                        if (!outP.Contains(cur.Edges[i].EndVertex.Value)
                            && !next.Contains(cur.Edges[i].EndVertex))
                        {
                            next.Enqueue(cur.Edges[i].EndVertex);
                        }
                    }
                }
                outP.Enqueue(cur.Value);
            }
            return outP;
        }
    }
}