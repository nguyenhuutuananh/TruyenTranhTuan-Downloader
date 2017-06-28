namespace Test1
{
    partial class frmMain
    {

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvwIMG = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnTaiTheoDS = new System.Windows.Forms.Button();
            this.btnHienDS = new System.Windows.Forms.Button();
            this.btnChangeFolder = new System.Windows.Forms.Button();
            this.btnLayTruyen = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoastToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkSTT = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvwIMG);
            this.groupBox1.Location = new System.Drawing.Point(13, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(580, 174);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ảnh sẽ tải về:";
            // 
            // lvwIMG
            // 
            this.lvwIMG.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwIMG.FullRowSelect = true;
            this.lvwIMG.GridLines = true;
            this.lvwIMG.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwIMG.Location = new System.Drawing.Point(6, 19);
            this.lvwIMG.MultiSelect = false;
            this.lvwIMG.Name = "lvwIMG";
            this.lvwIMG.Size = new System.Drawing.Size(568, 147);
            this.lvwIMG.TabIndex = 0;
            this.lvwIMG.UseCompatibleStateImageBehavior = false;
            this.lvwIMG.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "STT";
            this.columnHeader1.Width = 49;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Link Download";
            this.columnHeader2.Width = 372;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Trạng Thái";
            this.columnHeader3.Width = 122;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSTT);
            this.groupBox2.Controls.Add(this.btnTaiTheoDS);
            this.groupBox2.Controls.Add(this.btnHienDS);
            this.groupBox2.Controls.Add(this.btnChangeFolder);
            this.groupBox2.Controls.Add(this.btnLayTruyen);
            this.groupBox2.Controls.Add(this.txtFolder);
            this.groupBox2.Controls.Add(this.txtLink);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(579, 130);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // btnTaiTheoDS
            // 
            this.btnTaiTheoDS.Location = new System.Drawing.Point(342, 99);
            this.btnTaiTheoDS.Name = "btnTaiTheoDS";
            this.btnTaiTheoDS.Size = new System.Drawing.Size(108, 26);
            this.btnTaiTheoDS.TabIndex = 4;
            this.btnTaiTheoDS.Text = "Tải theo danh sách";
            this.btnTaiTheoDS.UseVisualStyleBackColor = true;
            this.btnTaiTheoDS.Click += new System.EventHandler(this.btnTaiTheoDS_Click);
            // 
            // btnHienDS
            // 
            this.btnHienDS.Location = new System.Drawing.Point(454, 99);
            this.btnHienDS.Name = "btnHienDS";
            this.btnHienDS.Size = new System.Drawing.Size(105, 26);
            this.btnHienDS.TabIndex = 3;
            this.btnHienDS.Text = "Hiện Danh sách";
            this.btnHienDS.UseVisualStyleBackColor = true;
            this.btnHienDS.Click += new System.EventHandler(this.btnHienDS_Click);
            // 
            // btnChangeFolder
            // 
            this.btnChangeFolder.Location = new System.Drawing.Point(107, 38);
            this.btnChangeFolder.Name = "btnChangeFolder";
            this.btnChangeFolder.Size = new System.Drawing.Size(134, 28);
            this.btnChangeFolder.TabIndex = 2;
            this.btnChangeFolder.Text = "Chọn Thư mục";
            this.btnChangeFolder.UseVisualStyleBackColor = true;
            this.btnChangeFolder.Click += new System.EventHandler(this.btnChangeFolder_Click);
            // 
            // btnLayTruyen
            // 
            this.btnLayTruyen.Location = new System.Drawing.Point(107, 98);
            this.btnLayTruyen.Name = "btnLayTruyen";
            this.btnLayTruyen.Size = new System.Drawing.Size(134, 28);
            this.btnLayTruyen.TabIndex = 2;
            this.btnLayTruyen.Text = "Lấy ảnh truyện";
            this.btnLayTruyen.UseVisualStyleBackColor = true;
            this.btnLayTruyen.Click += new System.EventHandler(this.btnLayTruyen_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Enabled = false;
            this.txtFolder.Location = new System.Drawing.Point(107, 12);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(453, 20);
            this.txtFolder.TabIndex = 1;
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(107, 72);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(453, 20);
            this.txtLink.TabIndex = 1;
            this.txtLink.Click += new System.EventHandler(this.txtLink_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Link tập truyện:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thư mục chứa:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtLog);
            this.groupBox3.Location = new System.Drawing.Point(13, 343);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(580, 103);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông báo";
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(6, 16);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(562, 81);
            this.txtLog.TabIndex = 0;
            this.txtLog.TextChanged += new System.EventHandler(this.txtLog_TextChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.thoastToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(604, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // thoastToolStripMenuItem
            // 
            this.thoastToolStripMenuItem.Name = "thoastToolStripMenuItem";
            this.thoastToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.thoastToolStripMenuItem.Text = "Thoát";
            this.thoastToolStripMenuItem.Click += new System.EventHandler(this.thoastToolStripMenuItem_Click);
            // 
            // chkSTT
            // 
            this.chkSTT.AutoSize = true;
            this.chkSTT.Location = new System.Drawing.Point(256, 105);
            this.chkSTT.Name = "chkSTT";
            this.chkSTT.Size = new System.Drawing.Size(75, 17);
            this.chkSTT.TabIndex = 5;
            this.chkSTT.Text = "Theo STT";
            this.chkSTT.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TruyenTranhTuan Chapter Downloader 1.1 -  Multi Chapter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLayTruyen;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtLog;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnChangeFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ListView lvwIMG;
        private System.Windows.Forms.Button btnHienDS;
        private System.Windows.Forms.Button btnTaiTheoDS;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoastToolStripMenuItem;
        private System.Windows.Forms.CheckBox chkSTT;

    }
}

