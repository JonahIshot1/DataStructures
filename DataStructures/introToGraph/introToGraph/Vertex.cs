using System;
using System.Collections.Generic;
using System.Text;

namespace introToGraph
{
    public class Vertex
    {
        public int val;
        public List<Vertex> children;
        public Vertex(int v)
        {
            val = v;
            children = new List<Vertex>();
        }
    }
}
