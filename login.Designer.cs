namespace JupiterSIPClient1
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.localIp = new System.Windows.Forms.Label();
            this.publicIpShow = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password :";
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(89, 7);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(159, 23);
            this.username.TabIndex = 1;
            this.username.Text = "volkan.muhtar@bursa";
            this.username.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.username_KeyPress);
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(89, 35);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(159, 23);
            this.password.TabIndex = 2;
            this.password.Text = "123123";
            this.password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.password_KeyPress);
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.loginButton.Location = new System.Drawing.Point(173, 61);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 23);
            this.loginButton.TabIndex = 3;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 2000;
            // 
            // localIp
            // 
            this.localIp.AutoSize = true;
            this.localIp.Location = new System.Drawing.Point(15, 69);
            this.localIp.Name = "localIp";
            this.localIp.Size = new System.Drawing.Size(15, 15);
            this.localIp.TabIndex = 5;
            this.localIp.Text = "--";
            // 
            // publicIpShow
            // 
            this.publicIpShow.AutoSize = true;
            this.publicIpShow.Location = new System.Drawing.Point(15, 84);
            this.publicIpShow.Name = "publicIpShow";
            this.publicIpShow.Size = new System.Drawing.Size(15, 15);
            this.publicIpShow.TabIndex = 6;
            this.publicIpShow.Text = "--";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(172, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Restart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 118);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.publicIpShow);
            this.Controls.Add(this.localIp);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jupiter Login";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button loginButton;
        public System.Windows.Forms.TextBox username;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label localIp;
        private System.Windows.Forms.Label publicIpShow;
        private System.Windows.Forms.Button button1;
    }
}