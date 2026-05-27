namespace PathFindingVis
{
    public partial class Form1 : Form
    {

        const int butS = 50;
        const int width = 25;
        const int hight = 16;
        public Button[,] buts = new Button[width, hight];
        public bool[,] Clicked = new bool[width, hight];
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
                    buts[w, h] = new Button();
                    buts[w, h].Size = new Size(butS, butS);
                    buts[w, h].Location = new Point(w * butS, h * butS);
                    buts[w, h].BackColor = Color.Pink;

                    buts[w, h].Click += But_Click;
                    Controls.Add(buts[w, h]);
                }
            }
            buts[0, 0].BackColor = Color.Red;
            buts[width - 1, hight - 1].BackColor = Color.Maroon;
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

                Clicked[Sender.Location.X / butS, Sender.Location.Y / butS] = true;
            }
            else
            {
                Sender.BackColor = Color.Pink;

                Clicked[Sender.Location.X / butS, Sender.Location.Y / butS] = false;
            }
        }

        private void FindBut_Click(object sender, EventArgs e)
        {

        }

    }
}
