namespace JupiterSIPClient1
{
    partial class setSounds
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setSounds));
            this.recordsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kaydıSilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.devredışıBırakToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktifEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.announces = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.announceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.skill = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recordTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playButton = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.newAnnounceName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.fileName = new System.Windows.Forms.Label();
            this.timer1LabelHour = new System.Windows.Forms.Label();
            this.timer1LabelMin = new System.Windows.Forms.Label();
            this.timer1LabelSec = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.recordSkills = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.audioCodecs = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.videoCodecs = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.mics = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.speakers = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.recordsMenu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.announces)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // recordsMenu
            // 
            this.recordsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kaydıSilToolStripMenuItem,
            this.devredışıBırakToolStripMenuItem,
            this.aktifEtToolStripMenuItem});
            this.recordsMenu.Name = "recordsMenu";
            this.recordsMenu.Size = new System.Drawing.Size(152, 70);
            // 
            // kaydıSilToolStripMenuItem
            // 
            this.kaydıSilToolStripMenuItem.Name = "kaydıSilToolStripMenuItem";
            this.kaydıSilToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.kaydıSilToolStripMenuItem.Text = "Kaydı Sil";
            this.kaydıSilToolStripMenuItem.Click += new System.EventHandler(this.kaydıSilToolStripMenuItem_Click);
            // 
            // devredışıBırakToolStripMenuItem
            // 
            this.devredışıBırakToolStripMenuItem.Name = "devredışıBırakToolStripMenuItem";
            this.devredışıBırakToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.devredışıBırakToolStripMenuItem.Text = "Devredışı Bırak";
            this.devredışıBırakToolStripMenuItem.Click += new System.EventHandler(this.devredışıBırakToolStripMenuItem_Click);
            // 
            // aktifEtToolStripMenuItem
            // 
            this.aktifEtToolStripMenuItem.Name = "aktifEtToolStripMenuItem";
            this.aktifEtToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.aktifEtToolStripMenuItem.Text = "Aktif Et";
            this.aktifEtToolStripMenuItem.Click += new System.EventHandler(this.aktifEtToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(592, 355);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Karşılama Anonsu";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.announces);
            this.groupBox2.Location = new System.Drawing.Point(9, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(577, 202);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kayıtlı Anonslar";
            // 
            // announces
            // 
            this.announces.AllowUserToAddRows = false;
            this.announces.AllowUserToDeleteRows = false;
            this.announces.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.announces.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.announces.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.recordName,
            this.announceName,
            this.skill,
            this.recordTime,
            this.state,
            this.playButton});
            this.announces.ContextMenuStrip = this.recordsMenu;
            this.announces.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.announces.EnableHeadersVisualStyles = false;
            this.announces.Location = new System.Drawing.Point(6, 18);
            this.announces.Name = "announces";
            this.announces.RowHeadersVisible = false;
            this.announces.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.announces.ShowEditingIcon = false;
            this.announces.Size = new System.Drawing.Size(565, 175);
            this.announces.TabIndex = 0;
            this.announces.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.records_CellContentClick);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // recordName
            // 
            this.recordName.HeaderText = "Kayıt Adı";
            this.recordName.Name = "recordName";
            this.recordName.Visible = false;
            // 
            // announceName
            // 
            this.announceName.HeaderText = "Kayıt Adı";
            this.announceName.Name = "announceName";
            // 
            // skill
            // 
            this.skill.HeaderText = "Skill";
            this.skill.Name = "skill";
            // 
            // recordTime
            // 
            this.recordTime.HeaderText = "Kayıt Süresi";
            this.recordTime.Name = "recordTime";
            // 
            // state
            // 
            this.state.HeaderText = "Durum";
            this.state.Name = "state";
            // 
            // playButton
            // 
            this.playButton.HeaderText = "Oynat";
            this.playButton.Name = "playButton";
            this.playButton.Text = "Oynat";
            this.playButton.ToolTipText = "Oynat";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.newAnnounceName);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.fileName);
            this.groupBox1.Controls.Add(this.timer1LabelHour);
            this.groupBox1.Controls.Add(this.timer1LabelMin);
            this.groupBox1.Controls.Add(this.timer1LabelSec);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.recordSkills);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(9, 205);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 128);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yeni Anons Kaydet";
            // 
            // newAnnounceName
            // 
            this.newAnnounceName.Location = new System.Drawing.Point(69, 15);
            this.newAnnounceName.Name = "newAnnounceName";
            this.newAnnounceName.Size = new System.Drawing.Size(156, 22);
            this.newAnnounceName.TabIndex = 59;
            this.newAnnounceName.Text = "Anons 1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 14);
            this.label10.TabIndex = 58;
            this.label10.Text = "Kayıt Adı :";
            // 
            // fileName
            // 
            this.fileName.AutoSize = true;
            this.fileName.Location = new System.Drawing.Point(7, 104);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(11, 14);
            this.fileName.TabIndex = 57;
            this.fileName.Text = "-";
            // 
            // timer1LabelHour
            // 
            this.timer1LabelHour.AutoSize = true;
            this.timer1LabelHour.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.timer1LabelHour.Location = new System.Drawing.Point(259, 48);
            this.timer1LabelHour.Name = "timer1LabelHour";
            this.timer1LabelHour.Size = new System.Drawing.Size(37, 29);
            this.timer1LabelHour.TabIndex = 54;
            this.timer1LabelHour.Text = "00";
            // 
            // timer1LabelMin
            // 
            this.timer1LabelMin.AutoSize = true;
            this.timer1LabelMin.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.timer1LabelMin.Location = new System.Drawing.Point(302, 48);
            this.timer1LabelMin.Name = "timer1LabelMin";
            this.timer1LabelMin.Size = new System.Drawing.Size(37, 29);
            this.timer1LabelMin.TabIndex = 53;
            this.timer1LabelMin.Text = "00";
            // 
            // timer1LabelSec
            // 
            this.timer1LabelSec.AutoSize = true;
            this.timer1LabelSec.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.timer1LabelSec.Location = new System.Drawing.Point(348, 48);
            this.timer1LabelSec.Name = "timer1LabelSec";
            this.timer1LabelSec.Size = new System.Drawing.Size(37, 29);
            this.timer1LabelSec.TabIndex = 52;
            this.timer1LabelSec.Text = "00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(336, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 29);
            this.label9.TabIndex = 56;
            this.label9.Text = ":";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(289, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 29);
            this.label6.TabIndex = 55;
            this.label6.Text = ":";
            // 
            // recordSkills
            // 
            this.recordSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.recordSkills.FormattingEnabled = true;
            this.recordSkills.Location = new System.Drawing.Point(69, 44);
            this.recordSkills.Name = "recordSkills";
            this.recordSkills.Size = new System.Drawing.Size(156, 22);
            this.recordSkills.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "Skill :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Bitir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(69, 72);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Başlat";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(592, 355);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ses Ayarları";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(489, 316);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 20;
            this.button3.Text = "Kaydet";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBox3);
            this.groupBox5.Controls.Add(this.comboBox1);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(9, 218);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(555, 92);
            this.groupBox5.TabIndex = 19;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Gelişmiş Ayarlar";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Kapalı",
            "Düşük Seviye",
            "Orta Seviye",
            "Yüksek Seviye"});
            this.comboBox3.Location = new System.Drawing.Point(150, 49);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(286, 22);
            this.comboBox3.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Kapalı",
            "Düşük Seviye",
            "Orta Seviye",
            "Yüksek Seviye"});
            this.comboBox1.Location = new System.Drawing.Point(150, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(286, 22);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gürültü Azaltma :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Otomatik Kazanç Ayarı :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.audioCodecs);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.videoCodecs);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Location = new System.Drawing.Point(9, 113);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(555, 99);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Codec Ayarları";
            // 
            // audioCodecs
            // 
            this.audioCodecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.audioCodecs.FormattingEnabled = true;
            this.audioCodecs.Location = new System.Drawing.Point(153, 21);
            this.audioCodecs.Name = "audioCodecs";
            this.audioCodecs.Size = new System.Drawing.Size(286, 22);
            this.audioCodecs.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(80, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 14);
            this.label8.TabIndex = 14;
            this.label8.Text = "Ses Codec :";
            // 
            // videoCodecs
            // 
            this.videoCodecs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.videoCodecs.FormattingEnabled = true;
            this.videoCodecs.Location = new System.Drawing.Point(153, 49);
            this.videoCodecs.Name = "videoCodecs";
            this.videoCodecs.Size = new System.Drawing.Size(286, 22);
            this.videoCodecs.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(67, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 14);
            this.label7.TabIndex = 15;
            this.label7.Text = "Video Codec :";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.mics);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.speakers);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(555, 101);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Cihaz Ayarları";
            // 
            // mics
            // 
            this.mics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mics.FormattingEnabled = true;
            this.mics.Location = new System.Drawing.Point(153, 31);
            this.mics.Name = "mics";
            this.mics.Size = new System.Drawing.Size(286, 22);
            this.mics.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "Mikrofon :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kulaklık :";
            // 
            // speakers
            // 
            this.speakers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.speakers.FormattingEnabled = true;
            this.speakers.Location = new System.Drawing.Point(153, 59);
            this.speakers.Name = "speakers";
            this.speakers.Size = new System.Drawing.Size(286, 22);
            this.speakers.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(600, 382);
            this.tabControl1.TabIndex = 0;
            // 
            // setSounds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 408);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "setSounds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Jupiter - Ses Ayarları";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.setSounds_FormClosing);
            this.Load += new System.EventHandler(this.callWelcome_Load);
            this.recordsMenu.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.announces)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip recordsMenu;
        private System.Windows.Forms.ToolStripMenuItem kaydıSilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem devredışıBırakToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aktifEtToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.DataGridView announces;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label fileName;
        private System.Windows.Forms.Label timer1LabelHour;
        private System.Windows.Forms.Label timer1LabelMin;
        private System.Windows.Forms.Label timer1LabelSec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox recordSkills;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        internal System.Windows.Forms.ComboBox audioCodecs;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ComboBox videoCodecs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        internal System.Windows.Forms.ComboBox mics;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox speakers;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button button3;
        internal System.Windows.Forms.ComboBox comboBox3;
        internal System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox newAnnounceName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordName;
        private System.Windows.Forms.DataGridViewTextBoxColumn announceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn skill;
        private System.Windows.Forms.DataGridViewTextBoxColumn recordTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewButtonColumn playButton;
    }
}