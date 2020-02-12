namespace GDI_Demo
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
            this.button1 = new System.Windows.Forms.Button();
            this.paint1 = new System.Windows.Forms.Panel();
            this.tbChannel2 = new System.Windows.Forms.TrackBar();
            this.tbChannel1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.tbChannel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.tbChannel1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "置顶";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // paint1
            // 
            this.paint1.Location = new System.Drawing.Point(15, 17);
            this.paint1.Margin = new System.Windows.Forms.Padding(0);
            this.paint1.Name = "paint1";
            this.paint1.Size = new System.Drawing.Size(199, 285);
            this.paint1.TabIndex = 1;
            // 
            // tbChannel2
            // 
            this.tbChannel2.Location = new System.Drawing.Point(346, 123);
            this.tbChannel2.Maximum = 100;
            this.tbChannel2.Minimum = -100;
            this.tbChannel2.Name = "tbChannel2";
            this.tbChannel2.Size = new System.Drawing.Size(332, 45);
            this.tbChannel2.TabIndex = 2;
            this.tbChannel2.Scroll += new System.EventHandler(this.tbChannel2_Scroll);
            this.tbChannel2.MouseEnter += new System.EventHandler(this.tbChannel2_MouseEnter);
            // 
            // tbChannel1
            // 
            this.tbChannel1.Location = new System.Drawing.Point(504, 11);
            this.tbChannel1.Maximum = 100;
            this.tbChannel1.Minimum = -100;
            this.tbChannel1.Name = "tbChannel1";
            this.tbChannel1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbChannel1.Size = new System.Drawing.Size(45, 251);
            this.tbChannel1.TabIndex = 3;
            this.tbChannel1.Scroll += new System.EventHandler(this.tbChannel1_Scroll);
            this.tbChannel1.MouseEnter += new System.EventHandler(this.tbChannel1_MouseEnter);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(419, 266);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 50);
            this.label1.TabIndex = 4;
            this.label1.Text = "y轴数值";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(419, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 48);
            this.label2.TabIndex = 5;
            this.label2.Text = "x轴数值";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 453);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbChannel1);
            this.Controls.Add(this.tbChannel2);
            this.Controls.Add(this.paint1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "摇杆指示器";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize) (this.tbChannel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.tbChannel1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel paint1;
        private System.Windows.Forms.TrackBar tbChannel2;
        private System.Windows.Forms.TrackBar tbChannel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}