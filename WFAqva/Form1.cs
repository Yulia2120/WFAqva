using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFAqva
{
    public partial class Form1 : Form
    {
       
        bool leftMove, upMove;
        List<PictureBox> items = new List<PictureBox>();
        Image[] image = { Properties.Resources._2, Properties.Resources.giphy__7_, Properties.Resources._1};
        int x, y;
        Random rd = new Random();
     
        public Form1()
        {
            InitializeComponent();
        }

        private void СreateFish()
        {
            PictureBox pic = new PictureBox();
            x = rd.Next(10, ClientSize.Width - pic.Width);
            y = rd.Next(10, ClientSize.Height - pic.Height);
            pic.Location = new Point(x, y);
            pic.BackColor = TransparencyKey;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Size = new Size(100, 100);
            pic.Image = image[rd.Next(0, image.Length)];
            items.Add(pic);
            Controls.Add(pic);

        }

        private void MoveFishesTask()
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (leftMove == false)
                    items[i].Left -= 1;
                if (leftMove == true)
                    items[i].Left += 1;
                if (upMove == true)
                    items[i].Top += 1;
                if (upMove == false)
                    items[i].Top -= 1;

                if (items[i].Left <= ClientRectangle.Left)
                {
                    leftMove = true;

                }
                if (items[i].Left == 0)
                {
                    items[i].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                }

                if (items[i].Right >= ClientRectangle.Right)
                {
                    leftMove = false;

                }
                if (items[i].Right == ClientRectangle.Right)
                {
                    items[i].Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                }
                if (items[i].Top <= ClientRectangle.Top)
                    upMove = true;

                if (items[i].Bottom >= ClientRectangle.Bottom)
                    upMove = false;
            }
        }

        private void StartFish()
        {
            Invoke(new Action(() => {
                MoveFishesTask();
            }));

        }
        private void FeedFish()
        {
            Task.Factory.StartNew(() =>
            {
                try
                {
                    for (int i = 0; i < 300; i++)
                    {
                        int width = rd.Next(0, Width);
                        int height = rd.Next(0, Height/2);
                        CreateGraphics().DrawEllipse(new Pen(Brushes.Bisque, 1), new Rectangle(width, height, 5, 5));

                        Thread.Sleep(100);
                    }
                }
                catch (Exception)
                {

                }

            });

        }

        private void addFishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            СreateFish();
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
            StartFish();

        }

       
    }
}
