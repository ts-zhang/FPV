using System;
using System.Drawing;
using System.Windows.Forms;

namespace GDI_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            _timer.Interval = 1000;
            _timer.Tick += (sender, args) => { this.TopMost = true; };
        }

        private Timer _timer = new Timer();

        private void Form1_Load(object sender, EventArgs e)
        {
            this.paint1.Width = 200;
            this.paint1.Height = 200;

            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _timer.Start();
        }

        private int yValue = 0;
        private int xValue = 0;

        private void tbChannel1_Scroll(object sender, EventArgs e)
        {
            yValue = tbChannel1.Value;
            Draw();
        }

        private void tbChannel2_Scroll(object sender, EventArgs e)
        {
            xValue = tbChannel2.Value;
            Draw();
        }

        /**
         * 中心指示器大小
         */
        private int indicatorWidth = 10, indicatorHeight = 10;

        private void Draw()
        {
            var graphics = paint1.CreateGraphics();
            //unity3d经典背景色#794D31
            graphics.Clear(Color.FromArgb(0xff, 0x31, 0x4D, 0x79));
            var hMiddle = paint1.Height / 2;
            var wMiddle = paint1.Width / 2;
            {
                //坐标转换
                //[-100,100] 区间转换到 [0,200]，归一化处理
                double yPos = hMiddle, xPos = wMiddle;

                if (yValue == 0)
                {
                    yPos = hMiddle;
                }
                else if (yValue > 0)
                {
                    yPos = hMiddle - yValue;
                }
                else if (yValue < 0)
                {
                    yPos = hMiddle + Math.Abs(yValue);
                }

                if (xValue == 0)
                {
                    xPos = wMiddle;
                }
                else if (xValue > 0)
                {
                    xPos = wMiddle + xValue;
                }
                else if (xValue < 0)
                {
                    xPos = wMiddle - Math.Abs(xValue);
                }

                Brush brush = new SolidBrush(Color.White);
                graphics.FillEllipse(brush, (int) xPos - indicatorWidth / 2, (int) yPos - indicatorHeight / 2,
                    indicatorWidth, indicatorHeight);

                label1.Text = "y value = " + yValue + ", pos = " + yPos;
                label2.Text = "x value = " + xValue + ", pos = " + xPos;
            }
        }

        private void tbChannel1_MouseEnter(object sender, EventArgs e)
        {
            LetFront(sender);
        }

        private void tbChannel2_MouseEnter(object sender, EventArgs e)
        {
            LetFront(sender);
        }

        private void LetFront(object sender)
        {
            TrackBar trackBar = sender as TrackBar;
            if (trackBar == null)
            {
                return;
            }

            trackBar.BringToFront();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw();
        }
    }
}