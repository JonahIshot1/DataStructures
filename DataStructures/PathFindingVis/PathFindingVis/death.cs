using System;
using System.Collections.Generic;
using System.Text;
using wAndDGraphs;

namespace PathFindingVis
{
    internal class death
    {
        public Vertex<Point> vert;
        public bool clicked;
        public Button but;

        public death(Vertex<Point> v,bool c,Button b)
        {
            vert = v;
            clicked = c;
            but = b;
        }
    }
}
