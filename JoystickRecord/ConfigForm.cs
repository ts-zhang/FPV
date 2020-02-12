using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SharpDX.DirectInput;

namespace JoystickRecord
{
    public partial class Form1 : Form
    {
        private readonly DirectInput _di = new DirectInput();

        private readonly List<DeviceInstance> _joystickList = new List<DeviceInstance>();

        private Joystick _joystick;

        /**
        定时器，从设备拉取数据
        */
        private readonly Timer _timer = new Timer();

        /**
         * 校准标识
         */
        private bool _calibrateFlag = false;

        private static readonly int MIN = 0,MAX = 65535;
        
        /**
         * 油门 舵机行程范围
         */
        private int _throttleMin = MAX, _throttleMax = MIN;

        /**
         * 水平方向旋转 舵机行程范围
         */
        private int _yawMin = MAX, _yawMax = MIN;

        /**
         * 俯仰 舵机行程范围
         */
        private int _pitchMin = MAX, _pitchMax = MIN;

        /**
         * 翻滚 舵机行程范围
         */
        private int _rollMin = MAX, _rollMax = MIN;

        public Form1()
        {
            InitializeComponent();

            _timer.Interval = 100;
            _timer.Tick += (sender, args) =>
            {
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

                    if (_calibrateFlag)
                    {
                        {
                            //油门数据
                            if (currentState.Z > _throttleMax)
                            {
                                _throttleMax = currentState.Z;
                            }

                            if (currentState.Z < _throttleMin)
                            {
                                _throttleMin = currentState.Z;
                            }
                        }
                        {
                            //水平旋转数据
                            if (currentState.RotationY > _yawMax)
                            {
                                _yawMax = currentState.RotationY;
                            }

                            if (currentState.RotationY < _yawMin)
                            {
                                _yawMin = currentState.RotationY;
                            }
                        }
                        {
                            //俯仰数据
                            if (currentState.Y > _pitchMax)
                            {
                                _pitchMax = currentState.Y;
                            }

                            if (currentState.Y < _pitchMin)
                            {
                                _pitchMin = currentState.Y;
                            }
                        }
                        {
                            //翻滚数据
                            if (currentState.X > _rollMax)
                            {
                                _rollMax = currentState.X;
                            }

                            if (currentState.X < _rollMin)
                            {
                                _rollMin = currentState.X;
                            }
                        }

                        lblThrottleRange.Text = string.Format("{0} - {1}", _throttleMin, _throttleMax);
                        lblYawRange.Text = string.Format("{0} - {1}", _yawMin, _yawMax);
                        lblPitchRange.Text = string.Format("{0} - {1}", _pitchMin, _pitchMax);
                        lblRollRange.Text = string.Format("{0} - {1}", _rollMin, _rollMax);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            };
        }

        private void Reset()
        {
            _joystickList.Clear();
            cbDeviceList.Items.Clear();
        }

        private void LoadDevices()
        {
            foreach (var device in _di.GetDevices())
            {
                if (DeviceType.Joystick == device.Type)
                {
                    _joystickList.Add(device);
                    cbDeviceList.Items.Add(device.InstanceName);
                }
            }
        }

        private void LoadData(Joystick joystick)
        {
            _timer.Stop();
            //clean state,and stop timer
            _joystick = joystick;
            _joystick.Properties.BufferSize = 32;
            _joystick.Acquire();
            _timer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDevices();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            Reset();
            LoadDevices();
        }

        private void cbDeviceList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_joystickList.Count == 0)
            {
                return;
            }

            var deviceInstance = _joystickList[cbDeviceList.SelectedIndex];
            var joystick = new Joystick(_di, deviceInstance.InstanceGuid);
            LoadData(joystick);
        }

        /**
         * 显示遥控器数据
         */
        private void ShowValue(AttitudeEnum attitude, int value)
        {
            switch (attitude)
            {
                case AttitudeEnum.Throttle:
                    lblThrottle.Text = value.ToString();
                    break;
                case AttitudeEnum.Yaw:
                    lblYaw.Text = value.ToString();
                    break;
                case AttitudeEnum.Pitch:
                    lblPitch.Text = value.ToString();
                    break;
                case AttitudeEnum.Roll:
                    lblRoll.Text = value.ToString();
                    break;
            }
        }

        private void btnGameMode_Click(object sender, EventArgs e)
        {
            if (_joystick == null)
            {
                MessageBox.Show("请连接模拟器设备", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_calibrateFlag)
            {
                MessageBox.Show("请点击[校准完成]退出校准模式", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_throttleMax == MIN || _throttleMin == MAX || _yawMax == MIN || _yawMin == MAX
                || _pitchMax == MIN || _pitchMin == MAX    || _rollMax == MIN || _rollMin == MAX)
            {
                MessageBox.Show("请完成遥控器校准", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            try
            {
                _timer.Stop();
                _joystick.Unacquire();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            TravelRange travelRange = new TravelRange();
            
            travelRange.ThrottleMax = _throttleMax;
            travelRange.ThrottleMin = _throttleMin;

            travelRange.YawMax = _yawMax;
            travelRange.YawMin = _yawMin;
            
            travelRange.PitchMax = _pitchMax;
            travelRange.PitchMin = _pitchMin;

            travelRange.RollMax = _rollMax;
            travelRange.RollMin = _rollMin;
            
            Game gameWin = new Game(_joystick,travelRange);
            
            this.Hide();
            gameWin.Show();
        }

        private void lbtnStartCalibrate_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_joystick == null)
            {
                MessageBox.Show("请连接模拟器设备", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!_calibrateFlag)
            {
                //准备开始校准
                //重置
                _throttleMin = MAX;
                _throttleMax = MIN;
                _yawMin = MAX;
                _yawMax = MIN;
                _pitchMin = MAX;
                _pitchMax = MIN;
                _rollMin = MAX;
                _rollMax = MIN;
                lbtnCalibrate.Text = "校准完成";
                MessageBox.Show("请将摇杆打到最大最小值，点击确定后开始校准", "遥控器校准", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                //校准完成，结束当前校准
                
                lbtnCalibrate.Text = "开始校准";
            }

            _calibrateFlag = !_calibrateFlag;
        }
    }
}