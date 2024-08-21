namespace ClientSide
{
    partial class Form1
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
            loginbutton = new Button();
            createbutton = new Button();
            label1 = new Label();
            label2 = new Label();
            usernamebox = new TextBox();
            passwordbox = new TextBox();
            SuspendLayout();
            // 
            // loginbutton
            // 
            loginbutton.Location = new Point(220, 265);
            loginbutton.Name = "loginbutton";
            loginbutton.Size = new Size(94, 29);
            loginbutton.TabIndex = 0;
            loginbutton.Text = "login";
            loginbutton.UseVisualStyleBackColor = true;
            loginbutton.Click += loginbutton_Click;
            // 
            // createbutton
            // 
            createbutton.Location = new Point(444, 265);
            createbutton.Name = "createbutton";
            createbutton.Size = new Size(94, 29);
            createbutton.TabIndex = 1;
            createbutton.Text = "create";
            createbutton.UseVisualStyleBackColor = true;
            createbutton.Click += createbutton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(128, 113);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 2;
            label1.Text = "username: ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(128, 158);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 3;
            label2.Text = "password: ";
            // 
            // usernamebox
            // 
            usernamebox.Location = new Point(235, 113);
            usernamebox.Name = "usernamebox";
            usernamebox.Size = new Size(355, 27);
            usernamebox.TabIndex = 4;
            // 
            // passwordbox
            // 
            passwordbox.Location = new Point(235, 158);
            passwordbox.Name = "passwordbox";
            passwordbox.Size = new Size(355, 27);
            passwordbox.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(passwordbox);
            Controls.Add(usernamebox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(createbutton);
            Controls.Add(loginbutton);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button loginbutton;
        private Button createbutton;
        private Label label1;
        private Label label2;
        private TextBox usernamebox;
        private TextBox passwordbox;
    }
}
