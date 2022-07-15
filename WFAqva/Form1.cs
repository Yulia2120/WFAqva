using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAqva
{
    public partial class Form1 : Form
    {
        //int speed = 5;
        bool leftMove, upMove;
        Random rd = new Random();
        //  Point mouse_location = new Point();
        public Form1()
        {
            InitializeComponent();
        }

  

        private void Fishs()
        {
            if (leftMove == false)
                pB.Left -= 1;
            if (leftMove == true)
                pB.Left += 1;
            //if (upMove == true)
            //    pB.Top += 1;
            //if (upMove == false)
            //    pB.Top -= 1;
            if (pB.Left <= ClientRectangle.Left)
            {
                leftMove = true;

            }
            if (pB.Left == 0)
            {
                pB.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            }

            if (pB.Right >= ClientRectangle.Right)
            {
                leftMove = false;

            }
            if (pB.Right == ClientRectangle.Right)
            {
                pB.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
            }

            //if (pB.Top <= ClientRectangle.Top)
            //    upMove = true;

            //if (pB.Bottom >= ClientRectangle.Bottom)
            //    upMove = false;
        }

        private void FeedFish()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    for (int i = 0; i < 100; i++)
                    {
                        int width = rd.Next(0, Width);
                        int height = rd.Next(0, 300);
                        CreateGraphics().DrawEllipse(new Pen(Brushes.Bisque, 1), new Rectangle(width, height, 5, 5));

                        Thread.Sleep(100);
                    }
                }
                catch (Exception)
                {

                }

            });

        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void addFishToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void feedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeedFish();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Fishs();
          
        }

       
    }
}
