namespace JupiterSIPClient1
{
    partial class settingSIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingSIP));
            this.serverPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverHost = new System.Windows.Forms.TextBox();
            this.statusScreen = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.auth = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.userName = new System.Windows.Forms.TextBox();
            this.register = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // serverPort
            // 
            this.serverPort.Location = new System.Drawing.Point(186, 94);
            this.serverPort.Name = "serverPort";
            this.serverPort.Size = new System.Drawing.Size(40, 22);
            this.serverPort.TabIndex = 23;
            this.serverPort.Text = "5060";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 14);
            this.label4.TabIndex = 22;
            this.label4.Text = "Server :";
            // 
            // serverHost
            // 
            this.serverHost.Location = new System.Drawing.Point(80, 94);
            this.serverHost.Name = "serverHost";
            this.serverHost.Size = new System.Drawing.Size(100, 22);
            this.serverHost.TabIndex = 21;
            this.serverHost.Text = "192.168.10.96";
            // 
            // statusScreen
            // 
            this.statusScreen.DropDownHeight = 200;
            this.statusScreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.statusScreen.FormattingEnabled = true;
            this.statusScreen.IntegralHeight = false;
            this.statusScreen.Location = new System.Drawing.Point(29, 122);
            this.statusScreen.Name = "statusScreen";
            this.statusScreen.Size = new System.Drawing.Size(153, 110);
            this.statusScreen.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(79, 26);
            this.button1.TabIndex = 19;
            this.button1.Text = "UnRegister";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 14);
            this.label3.TabIndex = 18;
            this.label3.Text = "Password :";
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(80, 62);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(100, 22);
            this.password.TabIndex = 17;
            this.password.Text = "siksik77";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Auth ID :";
            // 
            // auth
            // 
            this.auth.Location = new System.Drawing.Point(80, 34);
            this.auth.Name = "auth";
            this.auth.Size = new System.Drawing.Size(100, 22);
            this.auth.TabIndex = 15;
            this.auth.Text = "1002";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.TabIndex = 14;
            this.label1.Text = "Username :";
            // 
            // userName
            // 
            this.userName.Location = new System.Drawing.Point(80, 6);
            this.userName.Name = "userName";
            this.userName.Size = new System.Drawing.Size(100, 22);
            this.userName.TabIndex = 13;
            this.userName.Text = "1002";
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(0, 0);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(75, 23);
            this.register.TabIndex = 24;
            // 
            // settingSIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 287);
            this.Controls.Add(this.serverPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.serverHost);
            this.Controls.Add(this.statusScreen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.auth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userName);
            this.Controls.Add(this.register);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "settingSIP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jupiter - SIP Ayarları";
            this.Load += new System.EventHandler(this.settingSIP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.ComboBox statusScreen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button register;
        public System.Windows.Forms.TextBox serverPort;
        public System.Windows.Forms.TextBox serverHost;
        public System.Windows.Forms.TextBox password;
        public System.Windows.Forms.TextBox auth;
        public System.Windows.Forms.TextBox userName;
    }
}