namespace ClientSide
{
    partial class loggedin
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            logoutButton = new Button();
            downloadspeedlabel = new Label();
            uploadspeedlabel = new Label();
            pinglabel = new Label();
            usernamelabel = new Label();
            DownloadLabel = new Label();
            label6 = new Label();
            AveragePingLabel = new Label();
            AverageUploadLabel = new Label();
            AverageDownloadLabel = new Label();
            PingVarianceLabel = new Label();
            WelcomeToLebanonLabel = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("SimSun", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(261, 73);
            label1.Name = "label1";
            label1.Size = new Size(285, 30);
            label1.TabIndex = 0;
            label1.Text = "Till now it works";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(106, 189);
            label2.Name = "label2";
            label2.Size = new Size(190, 20);
            label2.TabIndex = 1;
            label2.Text = "Average Download Speed: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(106, 236);
            label3.Name = "label3";
            label3.Size = new Size(170, 20);
            label3.TabIndex = 2;
            label3.Text = "Average Upload Speed: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(106, 291);
            label4.Name = "label4";
            label4.Size = new Size(104, 20);
            label4.TabIndex = 3;
            label4.Text = "Average Ping: ";
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(694, 409);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(94, 29);
            logoutButton.TabIndex = 7;
            logoutButton.Text = "logout";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // downloadspeedlabel
            // 
            downloadspeedlabel.AutoSize = true;
            downloadspeedlabel.Location = new Point(328, 189);
            downloadspeedlabel.Name = "downloadspeedlabel";
            downloadspeedlabel.Size = new Size(18, 20);
            downloadspeedlabel.TabIndex = 8;
            downloadspeedlabel.Text = "...";
            downloadspeedlabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // uploadspeedlabel
            // 
            uploadspeedlabel.AutoSize = true;
            uploadspeedlabel.Location = new Point(328, 236);
            uploadspeedlabel.Name = "uploadspeedlabel";
            uploadspeedlabel.Size = new Size(18, 20);
            uploadspeedlabel.TabIndex = 9;
            uploadspeedlabel.Text = "...";
            uploadspeedlabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // pinglabel
            // 
            pinglabel.AutoSize = true;
            pinglabel.Location = new Point(328, 291);
            pinglabel.Name = "pinglabel";
            pinglabel.Size = new Size(18, 20);
            pinglabel.TabIndex = 10;
            pinglabel.Text = "...";
            pinglabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // usernamelabel
            // 
            usernamelabel.AutoSize = true;
            usernamelabel.Location = new Point(13, 9);
            usernamelabel.Name = "usernamelabel";
            usernamelabel.Size = new Size(18, 20);
            usernamelabel.TabIndex = 11;
            usernamelabel.Text = "...";
            // 
            // DownloadLabel
            // 
            DownloadLabel.AutoSize = true;
            DownloadLabel.Location = new Point(430, 189);
            DownloadLabel.Name = "DownloadLabel";
            DownloadLabel.Size = new Size(0, 20);
            DownloadLabel.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(430, 236);
            label6.Name = "label6";
            label6.Size = new Size(0, 20);
            label6.TabIndex = 13;
            // 
            // AveragePingLabel
            // 
            AveragePingLabel.AutoSize = true;
            AveragePingLabel.Location = new Point(430, 291);
            AveragePingLabel.Name = "AveragePingLabel";
            AveragePingLabel.Size = new Size(18, 20);
            AveragePingLabel.TabIndex = 14;
            AveragePingLabel.Text = "...";
            // 
            // AverageUploadLabel
            // 
            AverageUploadLabel.AutoSize = true;
            AverageUploadLabel.Location = new Point(430, 236);
            AverageUploadLabel.Name = "AverageUploadLabel";
            AverageUploadLabel.Size = new Size(18, 20);
            AverageUploadLabel.TabIndex = 15;
            AverageUploadLabel.Text = "...";
            // 
            // AverageDownloadLabel
            // 
            AverageDownloadLabel.AutoSize = true;
            AverageDownloadLabel.Location = new Point(430, 189);
            AverageDownloadLabel.Name = "AverageDownloadLabel";
            AverageDownloadLabel.Size = new Size(18, 20);
            AverageDownloadLabel.TabIndex = 16;
            AverageDownloadLabel.Text = "...";
            // 
            // PingVarianceLabel
            // 
            PingVarianceLabel.AutoSize = true;
            PingVarianceLabel.Location = new Point(528, 291);
            PingVarianceLabel.Name = "PingVarianceLabel";
            PingVarianceLabel.Size = new Size(18, 20);
            PingVarianceLabel.TabIndex = 17;
            PingVarianceLabel.Text = "...";
            // 
            // WelcomeToLebanonLabel
            // 
            WelcomeToLebanonLabel.AutoSize = true;
            WelcomeToLebanonLabel.Location = new Point(413, 363);
            WelcomeToLebanonLabel.Name = "WelcomeToLebanonLabel";
            WelcomeToLebanonLabel.Size = new Size(17, 20);
            WelcomeToLebanonLabel.TabIndex = 18;
            WelcomeToLebanonLabel.Text = ":)";
            // 
            // loggedin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(WelcomeToLebanonLabel);
            Controls.Add(PingVarianceLabel);
            Controls.Add(AverageDownloadLabel);
            Controls.Add(AverageUploadLabel);
            Controls.Add(AveragePingLabel);
            Controls.Add(label6);
            Controls.Add(DownloadLabel);
            Controls.Add(usernamelabel);
            Controls.Add(pinglabel);
            Controls.Add(uploadspeedlabel);
            Controls.Add(downloadspeedlabel);
            Controls.Add(logoutButton);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "loggedin";
            Text = "loggedin";
            FormClosing += loggedin_FormClosing;
            Load += loggedin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button logoutButton;
        private Label downloadspeedlabel;
        private Label uploadspeedlabel;
        private Label pinglabel;
        private Label usernamelabel;
        private Label DownloadLabel;
        private Label label6;
        private Label AveragePingLabel;
        private Label AverageUploadLabel;
        private Label AverageDownloadLabel;
        private Label PingVarianceLabel;
        private Label WelcomeToLebanonLabel;
    }
}