using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                if (GetEdge(vertices[i], vertex) != null)
                {
                    RemoveEdge(vertices[i], vertex);
                }
            }
            vertices.Remove(vertex);
            return true;
        }
        public bool AddEdge(Vertex<T> a, Vertex<T> b, float distance)
        {
            if (!vertices.Contains(a) || !vertices.Contains(b)) return false;
            if (GetEdge(a, b) is not null) return false;
            //if (a.Edges.Contains(GetEdge(a, b))) return false;
            Edge<T> temp = new Edge<T>(a, b, distance);
            edges.Add(temp);
            a.Edges.Add(temp);
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
        public Queue<T> Traverse(Vertex<T> start)
        {
            if (start is null) return null;
            Queue<Vertex<T>> next = new();
            Queue<T> outP = new();

            next.Enqueue(start);
            while (next.Count != 0)
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
        private float hur(Point vertex,Point goal)
        {
            float dx = Math.Abs(vertex.X - goal.X);
            float dy = Math.Abs(vertex.Y - goal.Y);
            return(dx + dy);
        }

        public bool BellmanFord(Vertex<T> start)
        {
            Dictionary<Vertex<T>, VertexInfo<T>> dic = new();

            foreach(Vertex<T> vert in vertices)
            {
                dic.Add(vert,new VertexInfo<T>(vert, null, float.MaxValue));
            }
            dic[start].TotalCost = 0;
            for (int i = 0; i < vertices.Count - 1; i++)
            {
                foreach (Edge<T> ege in edges)
                {
                    if (dic[ege.StartVertex].TotalCost + ege.Cost < dic[ege.EndVertex].TotalCost)
                    {
                        dic[ege.EndVertex].TotalCost = dic[ege.StartVertex].TotalCost + ege.Cost;
                    }
                }
            }

            foreach (Edge<T> eg in edges)
            {
                if (dic[eg.StartVertex].TotalCost + eg.Cost < dic[eg.EndVertex].TotalCost)
                {
                    return true;
                }
            }
            return false;

        }

        public List<Edge<Point>> AStar(Vertex<Point> start, Vertex<Point> target)
        {
            if (start is null) return null;
            PriorityQueue<VertexInfo<Point>, float> next = new();
            Dictionary<Vertex<Point>, VertexInfo<Point>> dic = new();
            List<Edge<Point>> outP = new();

            next.Enqueue(new VertexInfo<Point>(start, null, 0), hur(target.Value,start.Value));
            while (next.Count != 0)
            {
                VertexInfo<Point> cur = next.Dequeue();
                if (dic.ContainsKey(cur.Vertex)) continue;
                dic.Add(cur.Vertex, cur);
                if (cur.Vertex.Equals(target))
                {
                    while (true)
                    {
                        outP.Add(cur.FoundingEdge);
                        if (cur.FoundingEdge.StartVertex.Equals(start))
                        {
                            outP.Reverse();
                            return outP;
                        }
                        cur = dic[cur.FoundingEdge.StartVertex];
                    }
                }
                if (cur.Vertex.Edges is null) continue;

                for (int i = 0; i < cur.Vertex.Edges.Count; i++)
                {
                    VertexInfo<Point> temp = new(cur.Vertex.Edges[i].EndVertex, cur.Vertex.Edges[i], cur.TotalCost + cur.Vertex.Edges[i].Cost);
                    next.Enqueue(temp, temp.TotalCost+hur(target.Value, temp.Vertex.Value));
                }
            }
            return null;
        }

        public List<Edge<T>> Pathfindgood(Vertex<T> start, Vertex<T> target)
        {
            if (start is null) return null;
            PriorityQueue<VertexInfo<T>, float> next = new();
            Dictionary<Vertex<T>, VertexInfo<T>> dic = new();
            List<Edge<T>> outP = new();

            next.Enqueue(new VertexInfo<T>(start, null, 0), 0);
            while (next.Count != 0)
            {
                VertexInfo<T> cur = next.Dequeue();
                if (dic.ContainsKey(cur.Vertex)) continue;
                dic.Add(cur.Vertex, cur);
                if (cur.Vertex.Equals(target))
                {
                    while (true)
                    {
                        outP.Add(cur.FoundingEdge);
                        if (cur.FoundingEdge.StartVertex.Equals(start))
                        {
                            outP.Reverse();
                            return outP;
                        }
                        cur = dic[cur.FoundingEdge.StartVertex];
                    }
                }
                if (cur.Vertex.Edges is null) continue;

                for (int i = 0; i < cur.Vertex.Edges.Count; i++)
                {
                    VertexInfo<T> temp = new(cur.Vertex.Edges[i].EndVertex, cur.Vertex.Edges[i], cur.TotalCost + cur.Vertex.Edges[i].Cost);
                    next.Enqueue(temp, temp.TotalCost);
                }
            }
            return null;
        }
        public List<Edge<T>> PathfindBad(Vertex<T> start, Vertex<T> target)
        {
            if (start is null) return null;
            Queue<Vertex<T>> next = new();
            Dictionary<Vertex<T>, Edge<T>> dic = new();
            List<Edge<T>> outP = new();

            next.Enqueue(start);
            while (next.Count != 0)
            {
                Vertex<T> cur = next.Dequeue();
                if (cur.Edges is null) continue;

                for (int i = 0; i < cur.Edges.Count; i++)
                {
                    next.Enqueue(cur.Edges[i].EndVertex);
                    if (dic.ContainsKey(cur.Edges[i].EndVertex)) continue;

                    dic.Add(cur.Edges[i].EndVertex, cur.Edges[i]);
                    if (!cur.Edges[i].EndVertex.Equals(target)) continue;

                    Edge<T> curE = cur.Edges[i];
                    while (true)
                    {
                        outP.Add(curE);
                        if (curE.StartVertex.Equals(start))
                        {
                            outP.Reverse();
                            return outP;
                        }
                        curE = dic[curE.StartVertex];
                    }
                }
            }
            return null;

        }
    }
}