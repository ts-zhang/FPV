namespace JoystickRecord
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbDeviceList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRoll = new System.Windows.Forms.Label();
            this.lblYaw = new System.Windows.Forms.Label();
            this.lblPitch = new System.Windows.Forms.Label();
            this.lblThrottle = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnScan = new System.Windows.Forms.Button();
            this.btnGameMode = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbtnCalibrate = new System.Windows.Forms.LinkLabel();
            this.lblRollRange = new System.Windows.Forms.Label();
            this.lblYawRange = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblPitchRange = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblThrottleRange = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbDeviceList
            // 
            this.cbDeviceList.FormattingEnabled = true;
            this.cbDeviceList.Location = new System.Drawing.Point(97, 16);
            this.cbDeviceList.Name = "cbDeviceList";
            this.cbDeviceList.Size = new System.Drawing.Size(308, 25);
            this.cbDeviceList.TabIndex = 0;
            this.cbDeviceList.SelectedIndexChanged += new System.EventHandler(this.cbDeviceList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "设备列表:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblRoll);
            this.groupBox1.Controls.Add(this.lblYaw);
            this.groupBox1.Controls.Add(this.lblPitch);
            this.groupBox1.Controls.Add(this.lblThrottle);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(6, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(462, 110);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "遥控器数据";
            // 
            // lblRoll
            // 
            this.lblRoll.Location = new System.Drawing.Point(248, 76);
            this.lblRoll.Name = "lblRoll";
            this.lblRoll.Size = new System.Drawing.Size(97, 23);
            this.lblRoll.TabIndex = 7;
            this.lblRoll.Text = "0";
            // 
            // lblYaw
            // 
            this.lblYaw.Location = new System.Drawing.Point(78, 76);
            this.lblYaw.Name = "lblYaw";
            this.lblYaw.Size = new System.Drawing.Size(97, 23);
            this.lblYaw.TabIndex = 6;
            this.lblYaw.Text = "0";
            // 
            // lblPitch
            // 
            this.lblPitch.Location = new System.Drawing.Point(248, 40);
            this.lblPitch.Name = "lblPitch";
            this.lblPitch.Size = new System.Drawing.Size(97, 23);
            this.lblPitch.TabIndex = 5;
            this.lblPitch.Text = "0";
            // 
            // lblThrottle
            // 
            this.lblThrottle.Location = new System.Drawing.Point(78, 40);
            this.lblThrottle.Name = "lblThrottle";
            this.lblThrottle.Size = new System.Drawing.Size(97, 23);
            this.lblThrottle.TabIndex = 4;
            this.lblThrottle.Text = "0";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(190, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 23);
            this.label5.TabIndex = 3;
            this.label5.Text = "翻滚：";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(190, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "俯仰：";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "水平旋转：";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "油门：";
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(412, 16);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(55, 25);
            this.btnScan.TabIndex = 3;
            this.btnScan.Text = "刷新";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // btnGameMode
            // 
            this.btnGameMode.Location = new System.Drawing.Point(124, 351);
            this.btnGameMode.Name = "btnGameMode";
            this.btnGameMode.Size = new System.Drawing.Size(202, 67);
            this.btnGameMode.TabIndex = 4;
            this.btnGameMode.Text = "游戏模式";
            this.btnGameMode.UseVisualStyleBackColor = true;
            this.btnGameMode.Click += new System.EventHandler(this.btnGameMode_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbtnCalibrate);
            this.groupBox2.Controls.Add(this.lblRollRange);
            this.groupBox2.Controls.Add(this.lblYawRange);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblPitchRange);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.lblThrottleRange);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(6, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 154);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "遥控器校准";
            // 
            // lbtnCalibrate
            // 
            this.lbtnCalibrate.Location = new System.Drawing.Point(379, 121);
            this.lbtnCalibrate.Name = "lbtnCalibrate";
            this.lbtnCalibrate.Size = new System.Drawing.Size(76, 30);
            this.lbtnCalibrate.TabIndex = 16;
            this.lbtnCalibrate.TabStop = true;
            this.lbtnCalibrate.Text = "开始校准";
            this.lbtnCalibrate.LinkClicked +=
                new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbtnStartCalibrate_LinkClicked);
            // 
            // lblRollRange
            // 
            this.lblRollRange.Location = new System.Drawing.Point(302, 74);
            this.lblRollRange.Name = "lblRollRange";
            this.lblRollRange.Size = new System.Drawing.Size(97, 23);
            this.lblRollRange.TabIndex = 15;
            this.lblRollRange.Text = "0";
            // 
            // lblYawRange
            // 
            this.lblYawRange.Location = new System.Drawing.Point(78, 74);
            this.lblYawRange.Name = "lblYawRange";
            this.lblYawRange.Size = new System.Drawing.Size(97, 23);
            this.lblYawRange.TabIndex = 14;
            this.lblYawRange.Text = "0";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 38);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 21);
            this.label13.TabIndex = 8;
            this.label13.Text = "油门：";
            // 
            // lblPitchRange
            // 
            this.lblPitchRange.Location = new System.Drawing.Point(302, 38);
            this.lblPitchRange.Name = "lblPitchRange";
            this.lblPitchRange.Size = new System.Drawing.Size(97, 23);
            this.lblPitchRange.TabIndex = 13;
            this.lblPitchRange.Text = "0";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(10, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 23);
            this.label12.TabIndex = 9;
            this.label12.Text = "水平旋转：";
            // 
            // lblThrottleRange
            // 
            this.lblThrottleRange.Location = new System.Drawing.Point(78, 37);
            this.lblThrottleRange.Name = "lblThrottleRange";
            this.lblThrottleRange.Size = new System.Drawing.Size(97, 23);
            this.lblThrottleRange.TabIndex = 12;
            this.lblThrottleRange.Text = "0";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(244, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 23);
            this.label11.TabIndex = 10;
            this.label11.Text = "俯仰：";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(244, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 23);
            this.label10.TabIndex = 11;
            this.label10.Text = "翻滚：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 431);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnGameMode);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDeviceList);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "遥控器配置";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDeviceList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblThrottle;
        private System.Windows.Forms.Label lblYaw;
        private System.Windows.Forms.Label lblPitch;
        private System.Windows.Forms.Label lblRoll;
        private System.Windows.Forms.Button btnGameMode;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel lbtnCalibrate;
        private System.Windows.Forms.Label lblRollRange;
        private System.Windows.Forms.Label lblYawRange;
        private System.Windows.Forms.Label lblPitchRange;
        private System.Windows.Forms.Label lblThrottleRange;
    }
}