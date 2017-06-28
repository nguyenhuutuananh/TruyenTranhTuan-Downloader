namespace Test1
{
    partial class frmDanhSach
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
            this.txtDanhSach = new System.Windows.Forms.TextBox();
            this.btnDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtDanhSach
            // 
            this.txtDanhSach.Location = new System.Drawing.Point(3, 3);
            this.txtDanhSach.Multiline = true;
            this.txtDanhSach.Name = "txtDanhSach";
            this.txtDanhSach.Size = new System.Drawing.Size(305, 284);
            this.txtDanhSach.TabIndex = 0;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(100, 293);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(117, 30);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmDanhSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 329);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.txtDanhSach);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDanhSach";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh sách chapter tải về";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDanhSach_FormClosed);
            this.Load += new System.EventHandler(this.frmDanhSach_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDong;
        public System.Windows.Forms.TextBox txtDanhSach;
    }
}