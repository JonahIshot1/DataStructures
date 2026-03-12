namespace Sierpinski_Carpet
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        Graphics gfx;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            gfx = Graphics.FromImage(bmp);
            gfx.Clear(Color.White);
            int x= 1;
            SierpinskiCarpet(x);
        }
        void SierpinskiCarpet(int x)
        {
            int tries = (int)Math.Pow(3, x);
            int size = pictureBox1.Width / tries;
            int count2 = 0;
            for(int i = 0; i < tries; i++)
            {
                int count = 0;
                for (int l = 0; l < tries; l++)
                {
                    if (count%3 == 1&& count2 % 3 == 1)
                    {
                        Rectangle rectangle = new Rectangle(i * size, l*size,size,size);
                        gfx.FillRectangle(Brushes.Peru,rectangle);
                    }
                    count++;
                }
                count2++;
            }

            pictureBox1.Image = bmp;
            if (x < 4)
            {
                SierpinskiCarpet(x + 1);
            }
            
        }
    }
}
