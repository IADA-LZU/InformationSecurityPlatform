namespace Information_Safty_Test
{
    partial class Remote_Control_Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Remote_Control_Form));
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.R_R_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.IP_textBox = new System.Windows.Forms.TextBox();
            this.Port_textBox = new System.Windows.Forms.TextBox();
            this.Server_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PORT2_textBox = new System.Windows.Forms.TextBox();
            this.Hide_Button = new System.Windows.Forms.RadioButton();
            this.Client_Button = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.processTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(607, 313);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 119);
            this.button3.TabIndex = 8;
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.Location = new System.Drawing.Point(607, 167);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 119);
            this.button4.TabIndex = 9;
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // R_R_Button
            // 
            this.R_R_Button.Image = ((System.Drawing.Image)(resources.GetObject("R_R_Button.Image")));
            this.R_R_Button.Location = new System.Drawing.Point(607, 21);
            this.R_R_Button.Name = "R_R_Button";
            this.R_R_Button.Size = new System.Drawing.Size(133, 119);
            this.R_R_Button.TabIndex = 10;
            this.R_R_Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.R_R_Button.UseVisualStyleBackColor = true;
            this.R_R_Button.Click += new System.EventHandler(this.R_R_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体", 15F);
            this.label2.Location = new System.Drawing.Point(87, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "输入本机IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体", 15F);
            this.label3.Location = new System.Drawing.Point(87, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "输入端口1";
            // 
            // IP_textBox
            // 
            this.IP_textBox.Font = new System.Drawing.Font("楷体", 15F);
            this.IP_textBox.Location = new System.Drawing.Point(235, 101);
            this.IP_textBox.Name = "IP_textBox";
            this.IP_textBox.Size = new System.Drawing.Size(185, 30);
            this.IP_textBox.TabIndex = 13;
            // 
            // Port_textBox
            // 
            this.Port_textBox.Font = new System.Drawing.Font("楷体", 15F);
            this.Port_textBox.Location = new System.Drawing.Point(235, 157);
            this.Port_textBox.Name = "Port_textBox";
            this.Port_textBox.Size = new System.Drawing.Size(185, 30);
            this.Port_textBox.TabIndex = 14;
            // 
            // Server_Button
            // 
            this.Server_Button.Font = new System.Drawing.Font("楷体", 15F);
            this.Server_Button.Image = ((System.Drawing.Image)(resources.GetObject("Server_Button.Image")));
            this.Server_Button.Location = new System.Drawing.Point(91, 323);
            this.Server_Button.Name = "Server_Button";
            this.Server_Button.Size = new System.Drawing.Size(133, 44);
            this.Server_Button.TabIndex = 15;
            this.Server_Button.Text = "生成服务端";
            this.Server_Button.UseVisualStyleBackColor = true;
            this.Server_Button.Click += new System.EventHandler(this.Server_Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("楷体", 15F);
            this.label4.Location = new System.Drawing.Point(87, 231);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "输入端口2";
            // 
            // PORT2_textBox
            // 
            this.PORT2_textBox.Font = new System.Drawing.Font("楷体", 15F);
            this.PORT2_textBox.Location = new System.Drawing.Point(235, 221);
            this.PORT2_textBox.Name = "PORT2_textBox";
            this.PORT2_textBox.Size = new System.Drawing.Size(185, 30);
            this.PORT2_textBox.TabIndex = 17;
            // 
            // Hide_Button
            // 
            this.Hide_Button.AutoSize = true;
            this.Hide_Button.Location = new System.Drawing.Point(235, 284);
            this.Hide_Button.Name = "Hide_Button";
            this.Hide_Button.Size = new System.Drawing.Size(83, 16);
            this.Hide_Button.TabIndex = 18;
            this.Hide_Button.TabStop = true;
            this.Hide_Button.Text = "服务端隐藏";
            this.Hide_Button.UseVisualStyleBackColor = true;
            // 
            // Client_Button
            // 
            this.Client_Button.Font = new System.Drawing.Font("楷体", 15F);
            this.Client_Button.Image = ((System.Drawing.Image)(resources.GetObject("Client_Button.Image")));
            this.Client_Button.Location = new System.Drawing.Point(333, 323);
            this.Client_Button.Name = "Client_Button";
            this.Client_Button.Size = new System.Drawing.Size(133, 44);
            this.Client_Button.TabIndex = 19;
            this.Client_Button.Text = "生成客户端";
            this.Client_Button.UseVisualStyleBackColor = true;
            this.Client_Button.Click += new System.EventHandler(this.Client_Button_Click);
            // 
            // button5
            // 
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.Location = new System.Drawing.Point(12, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 46);
            this.button5.TabIndex = 20;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.Location = new System.Drawing.Point(64, 12);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(46, 46);
            this.button6.TabIndex = 21;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("楷体", 13F);
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(91, 388);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(133, 44);
            this.button7.TabIndex = 22;
            this.button7.Text = "生成键盘监听服务端";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("楷体", 13F);
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.Location = new System.Drawing.Point(333, 388);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(133, 44);
            this.button8.TabIndex = 23;
            this.button8.Text = "生成键盘监听客户端";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(784, 22);
            this.statusStrip1.TabIndex = 37;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(32, 17);
            this.Status.Text = "就绪";
            // 
            // Remote_Control_Form
            // 
            this.AllowDrop = true;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Client_Button);
            this.Controls.Add(this.Hide_Button);
            this.Controls.Add(this.PORT2_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Server_Button);
            this.Controls.Add(this.Port_textBox);
            this.Controls.Add(this.IP_textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.R_R_Button);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Remote_Control_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "远程控制测试";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button R_R_Button;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox IP_textBox;
        private System.Windows.Forms.TextBox Port_textBox;
        private System.Windows.Forms.Button Server_Button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PORT2_textBox;
        private System.Windows.Forms.RadioButton Hide_Button;
        private System.Windows.Forms.Button Client_Button;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.Timer processTimer;
    }
}