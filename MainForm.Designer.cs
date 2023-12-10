namespace NSScreenShot
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            IP_Box = new TextBox();
            Connect_BTN = new Button();
            Disconnect_BTN = new Button();
            Shot_BTN = new Button();
            Debug_Box = new TextBox();
            Name_TB = new TextBox();
            SuspendLayout();
            // 
            // IP_Box
            // 
            IP_Box.Location = new Point(12, 12);
            IP_Box.Name = "IP_Box";
            IP_Box.Size = new Size(100, 23);
            IP_Box.TabIndex = 0;
            IP_Box.TextChanged += IP_Box_TextChanged;
            // 
            // Connect_BTN
            // 
            Connect_BTN.Location = new Point(12, 41);
            Connect_BTN.Name = "Connect_BTN";
            Connect_BTN.Size = new Size(100, 23);
            Connect_BTN.TabIndex = 1;
            Connect_BTN.Text = "连接";
            Connect_BTN.UseVisualStyleBackColor = true;
            Connect_BTN.Click += Connect_BTN_Click;
            // 
            // Disconnect_BTN
            // 
            Disconnect_BTN.Location = new Point(12, 70);
            Disconnect_BTN.Name = "Disconnect_BTN";
            Disconnect_BTN.Size = new Size(100, 23);
            Disconnect_BTN.TabIndex = 2;
            Disconnect_BTN.Text = "断开";
            Disconnect_BTN.UseVisualStyleBackColor = true;
            Disconnect_BTN.Click += Disconnect_BTN_Click;
            // 
            // Shot_BTN
            // 
            Shot_BTN.Location = new Point(12, 99);
            Shot_BTN.Name = "Shot_BTN";
            Shot_BTN.Size = new Size(100, 23);
            Shot_BTN.TabIndex = 3;
            Shot_BTN.Text = "截图！";
            Shot_BTN.UseVisualStyleBackColor = true;
            Shot_BTN.Click += Shot_BTN_Click;
            // 
            // Debug_Box
            // 
            Debug_Box.Location = new Point(118, 41);
            Debug_Box.Multiline = true;
            Debug_Box.Name = "Debug_Box";
            Debug_Box.ScrollBars = ScrollBars.Vertical;
            Debug_Box.Size = new Size(147, 81);
            Debug_Box.TabIndex = 4;
            // 
            // Name_TB
            // 
            Name_TB.Location = new Point(119, 12);
            Name_TB.Name = "Name_TB";
            Name_TB.Size = new Size(146, 23);
            Name_TB.TabIndex = 5;
            Name_TB.Text = "图片1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(277, 134);
            Controls.Add(Name_TB);
            Controls.Add(Debug_Box);
            Controls.Add(Shot_BTN);
            Controls.Add(Disconnect_BTN);
            Controls.Add(Connect_BTN);
            Controls.Add(IP_Box);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NS截图神器";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox IP_Box;
        private Button Connect_BTN;
        private Button Disconnect_BTN;
        private Button Shot_BTN;
        private TextBox Debug_Box;
        private TextBox Name_TB;
    }
}