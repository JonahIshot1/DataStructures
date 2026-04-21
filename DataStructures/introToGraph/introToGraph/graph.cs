using System;
using System.Collections.Generic;
using System.Text;

namespace introToGraph
{
    public class graph
    {
        public graph() { verti = new List<Vertex>(); }
        public List<Vertex> verti; 
        public bool AddVertex(Vertex vertex)
        {
            if(Search(vertex.val)!=null)return false;
            verti.Add(vertex);
            return true;
        }
        // - Returns true if the addition succeeded, false otherwise
        //
        // - It should only succeed if the vertex is not null and it
        //   hasn't already been added to the graph.
        public bool RemoveVertex(Vertex vertex) 
        {
            if (Search(vertex.val) == null) return false;
            for(int i =0; i < vertex.children.Count;i++)
            {
                Vertex temp = vertex.children[i];
                temp.children.Remove(vertex);
            }
            verti.Remove(vertex);
            return true;
        }
        // - Returns true if the removal succeeded, false otherwise
        //
        // - It should only succeed if the vertex exists in your graph
        //   and you remove all edges/connections to it.
        public bool AddEdge(Vertex a, Vertex b)
        {
            if (a.children.Contains(b)) return false;
            a.children.Add(b);
            b.children.Add(a);
            return true;
        }
        public bool RemoveEdge(Vertex a, Vertex b) 
        {
            if(!a.children.Contains(b))return false;
            a.children.Remove(b);
            b.children.Remove(a);
            return true;
        }
        // - Returns true if the removal succeeded, false otherwise
        //
        // - It should only succeed if both vertices are not null, exist
        //   in the list, and are each other's neighbor.
        public Vertex Search(int value)
        {
            for(int i =0; i < verti.Count;i++)
            {
                if (verti[i].val== value) 
                {
                    return verti[i];
                }
            }
            return null; 
        }
    }
}
