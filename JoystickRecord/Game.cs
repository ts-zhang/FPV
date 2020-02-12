using System;
using System.Drawing;
using System.Windows.Forms;
using SharpDX.DirectInput;

namespace JoystickRecord
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();

            _timer1 = new Timer();
            _timer1.Interval = 2000;
            _timer1.Tick += (sender, args) => { this.TopMost = true; };

            _timer2 = new Timer();
            _timer2.Interval = 100;
            _timer2.Tick += (sender, args) => { ReadValue(); };
        }

        /**
         * 遥控器
         */
        private Joystick _joystick;

        /**
         * 舵机行程范围
         */
        private TravelRange _travelRange;

        /**
         * 中心指示器大小
         */
        private int indicatorWidth = 10, indicatorHeight = 10;

        /**
         * timer1 2秒/次设置窗口置顶
         * timer2 100ms/次拉取遥控器数据
         */
        private Timer _timer1, _timer2;

        /**
         * 左右两个x轴的值
         */
        private int x1Value = 0, x2Value = 0;

        /**
         * 左右两个y轴的值
         */
        private int y1Value = 0, y2Value = 0;

        public Game(Joystick joystick, TravelRange travelRange) : this()
        {
            _joystick = joystick;
            _travelRange = travelRange;

            _joystick.Acquire();

            _timer2.Start();
        }

        /**
         * 绘制背景
         */
        private void DrawBackground()
        {
            {
                var graphics = pLeft.CreateGraphics();
                graphics.Clear(Color.White);
                
                //左边画个圆
                {
                    Brush brush = new SolidBrush(Color.Black);
                    Pen pen = new Pen(brush);
                    pen.Width = 2.0f;
                    
                    graphics.DrawEllipse(pen, 0, 0, pLeft.Width, pLeft.Height);
                }
                //左边画个十字
                {
                    Brush brush = new SolidBrush(Color.Black);
                    Pen pen = new Pen(brush);
                    pen.Width = 2.0f;
                    
                    graphics.DrawLine(pen, pLeft.Width / 2, 0, pLeft.Width / 2, pLeft.Height);
                    graphics.DrawLine(pen, 0, pLeft.Height / 2, pLeft.Width, pLeft.Height / 2);
                }
            }

            {
                var graphics = pRight.CreateGraphics();
                graphics.Clear(Color.White);
                //右边画个圆
                {
                    Brush brush = new SolidBrush(Color.Black);
                    Pen pen = new Pen(brush);
                    pen.Width = 2.0f;

                    graphics.DrawEllipse(pen, 0, 0, pRight.Width, pRight.Height);
                }
                //右边画个十字
                {
                    Brush brush = new SolidBrush(Color.Black);
                    Pen pen = new Pen(brush);
                    pen.Width = 2.0f;
                    
                    graphics.DrawLine(pen, pRight.Width / 2, 0, pRight.Width / 2, pRight.Height);
                    graphics.DrawLine(pen, 0, pRight.Height / 2, pRight.Width, pRight.Height / 2);
                }
            }
        }

        /**
         * 读取遥控器的值
         */
        private void ReadValue()
        {
            if (_joystick == null)
            {
                return;
            }

            try
            {
                _joystick.Poll();
                var currentState = _joystick.GetCurrentState();

                //油门 throttle
                ShowValue(AttitudeEnum.Throttle, currentState.Z);
                //水平方向旋转  yaw
                ShowValue(AttitudeEnum.Yaw, currentState.RotationY);
                //俯仰 pitch
                ShowValue(AttitudeEnum.Pitch, currentState.Y);
                //翻滚 roll
                ShowValue(AttitudeEnum.Roll, currentState.X);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /**
         * 显示遥控器数据（遥控器数据归一化）
         */
        private void ShowValue(AttitudeEnum attitude, int value)
        {
            switch (attitude)
            {
                case AttitudeEnum.Throttle:
                    //范围映射到 -100到100
                {
                    double v = ValueMap(value, _travelRange.ThrottleMin, _travelRange.ThrottleMax);
                    y1Value = (int) v;
                }
                    break;
                case AttitudeEnum.Yaw:
                    //范围映射到 -100到100
                {
                    double v = ValueMap(value, _travelRange.YawMin, _travelRange.YawMax);
                    x1Value = (int) v;
                }
                    break;
                case AttitudeEnum.Pitch:
                    //范围映射到 -100到100
                {
                    double v = ValueMap(value, _travelRange.PitchMin, _travelRange.PitchMax);
                    y2Value = -(int) v;
                }
                    break;
                case AttitudeEnum.Roll:
                    //范围映射到 -100到100
                {
                    double v = ValueMap(value, _travelRange.RollMin, _travelRange.RollMax);
                    x2Value = (int) v;
                }
                    break;
            }

            DrawValue();
        }

        /**
         * 绘制遥控器数据
         */
        private void DrawValue()
        {
            //红色画刷
            Brush brush = new SolidBrush(Color.White);

            //将数据转换为坐标进行绘制
            int x1Pos = XValue2Pos(x1Value);
            int y1Pos = YValue2Pos(y1Value);
            int x2Pos = XValue2Pos(x2Value);
            int y2Pos = YValue2Pos(y2Value);
            
            //unity3d经典背景色#794D31
            Color paintBgColor = Color.FromArgb(0xff, 0x31, 0x4D, 0x79);
            var graphics1 = pLeft.CreateGraphics();
            graphics1.Clear(paintBgColor);
            graphics1.FillEllipse(brush, (int) x1Pos - indicatorWidth / 2, (int) y1Pos - indicatorHeight / 2,
                indicatorWidth, indicatorHeight);

            var graphics2 = pRight.CreateGraphics();
            graphics2.Clear(paintBgColor);
            graphics2.FillEllipse(brush, (int) x2Pos - indicatorWidth / 2, (int) y2Pos - indicatorHeight / 2,
                indicatorWidth, indicatorHeight);
        }

        /**
         * 数据归一化
         * 将遥控器数据映射到[-100,100]区间
         */
        private double ValueMap(int value, int min, int max)
        {
            if (value <= min)
            {
                return -100;
            }

            if (value >= max)
            {
                return 100;
            }

            //数据归一化，区间映射
            double v = ((value - min) * (100 - -100) / (max - min) + -100);

            return v;
        }

        /**
         * x数据转成x坐标
         */
        private int XValue2Pos(int xValue)
        {
            var wMiddle = pLeft.Width / 2;
            int xPos = 0;
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

            return xPos;
        }

        /**
         * y数据转成y坐标
         */
        private int YValue2Pos(int yValue)
        {
            var hMiddle = pLeft.Height / 2;
            int yPos = 0;
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

            return yPos;
        }

        private void Game_Load(object sender, EventArgs e)
        {
            //显示在屏幕下方中间位置
            this.Left = (SystemInformation.WorkingArea.Width - this.Width) / 2;
            this.Top = 0;
            //不显示边框
            this.FormBorderStyle = FormBorderStyle.None;
            //窗口最前
            this.TopMost = true;
            _timer1.Start();
            //背景透明
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            //透明度
            this.Opacity = 0.7d;
            
            //设置画板大小
            //两个画板间隔为80
            int paintSize = 220;
            int spacing = 40;
            this.pLeft.Width = paintSize;
            this.pLeft.Height = paintSize;
            this.pRight.Width = paintSize;
            this.pRight.Height = paintSize;
            this.pRight.Left = paintSize + spacing;

            this.Height = paintSize;
            this.Width = paintSize + spacing + paintSize;
            
            //双击关闭该窗口
            this.MouseDoubleClick += (o, args) =>
            {
                _timer1.Stop();
                _timer2.Stop();
                Application.Exit();
            };
        }
        
        private void Game_Paint(object sender, PaintEventArgs e)
        {
            //DrawBackground();
            DrawValue();
        }
    }
}