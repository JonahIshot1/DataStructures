using wAndDGraphs;

namespace PathFindingVis
{
    public partial class Form1 : Form
    {

        const int butS = 50;
        const int width =7;
        const int hight = 7;
        death[,] verti = new death[width,hight];
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int w = 0; w < width; w++)
            {
                for (int h = 0; h < hight; h++)
                {
                    Button temp= new Button();
                    temp = new Button();
                    temp.Size = new Size(butS, butS);
                    temp.Location = new Point(w * butS, h * butS);
                    temp.BackColor = Color.Pink;
                    temp.Click += But_Click;
                    Controls.Add(temp);
                    verti[w, h] = new death(null,false,temp);
                }
            }
            verti[0, 0].but.BackColor = Color.Red;
            verti[width - 1, hight - 1].but.BackColor = Color.Maroon;
            Button FindBut = new Button
            {
                Name = "FindBut",
                Size = new Size(butS * width, 100),
                TabIndex = 0,
                Text = "PathFind",
                UseVisualStyleBackColor = true
            };
            FindBut.Click += FindBut_Click;
            FindBut.Location = new Point(0, butS * hight);
            Controls.Add(FindBut);
        }

        private void But_Click(object sender, EventArgs e)
        {
            Button Sender = (Button)sender;
            if ((Sender.Location.X == 0 && Sender.Location.Y == 0) || (Sender.Location.X == (width - 1) * butS && Sender.Location.Y == (hight - 1) * butS))
            { return; }

            if (Sender.BackColor != Color.Black)
            {
                Sender.BackColor = Color.Black;

                verti[Sender.Location.X / butS, Sender.Location.Y / butS].clicked = true;
            }
            else
            {
                Sender.BackColor = Color.Pink;

                verti[Sender.Location.X / butS, Sender.Location.Y / butS].clicked = false;
            }
        }

        private async void FindBut_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < hight; y++)
                {
                    if (x == 0 && y == 0) continue;
                    if (x == (width-1) && y == (hight - 1)) continue;
                    if (verti[x,y].clicked==false)
                    {
                        verti[x, y].but.BackColor = Color.Pink;
                    }
                    
                }
            }
                    Graph < Point > grap = new();
            for(int x =0; x < width;x++)
            {
                for(int y =0; y < hight;y++)
                {
                    Point p = new Point(x, y);
                    if (verti[x,y].clicked==false)
                    {
                        Vertex<Point> temp = new Vertex<Point>(p);
                        grap.AddVertex(temp);
                        verti[x, y].vert = temp; 
                    }
                }
            }
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < hight; y++)
                {
                    death cur = verti[x, y]; 
                    if (cur.clicked == false)
                    {
                        if(x+1<width && verti[x+1,y].clicked==false )
                        {
                            grap.AddEdge(cur.vert, verti[x + 1, y].vert, 1);
                        }
                        if (x -1 > width && verti[x - 1, y].clicked == false)
                        {
                            grap.AddEdge(cur.vert, verti[x - 1, y].vert, 1);
                        }
                        if (y+1  <hight && verti[x , y+1].clicked == false)
                        {
                            grap.AddEdge(cur.vert, verti[x, y+1].vert, 1);
                        }
                        if (y-1 > width && verti[x, y-1].clicked == false)
                        {
                            grap.AddEdge(cur.vert, verti[x, y-1].vert, 1);
                        }
                    }
                }
            }
            List<Edge<Point>> outP = grap.AStar(verti[0, 0].vert, verti[width-1,hight-1].vert);
            foreach(Edge<Point> cur in outP)
            {
                verti[cur.EndVertex.Value.X, cur.EndVertex.Value.Y].but.BackColor=Color.Blue;
                await Task.Delay(200);
            }


        }

    }
}
