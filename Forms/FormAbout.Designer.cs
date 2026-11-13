namespace CinemaManagement.Forms
{
    partial class FormAbout
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            panelTop = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            rtbContent = new RichTextBox();
            btnClose = new Button();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(33, 37, 41);
            panelTop.Controls.Add(lblSubtitle);
            panelTop.Controls.Add(lblTitle);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(650, 75);
            panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.FromArgb(255, 193, 7);
            lblTitle.Location = new Point(12, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(626, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🎬 ĐỀ TÀI 10: QUẢN LÝ RẠP CHIẾU PHIM";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.ForeColor = Color.FromArgb(200, 200, 200);
            lblSubtitle.Location = new Point(12, 42);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(626, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Học phần 111165 - Lập trình trên môi trường Windows (C# Windows Forms)";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // rtbContent
            // 
            rtbContent.BackColor = Color.White;
            rtbContent.BorderStyle = BorderStyle.None;
            rtbContent.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular, GraphicsUnit.Point);
            rtbContent.Location = new Point(20, 90);
            rtbContent.Name = "rtbContent";
            rtbContent.ReadOnly = true;
            rtbContent.Size = new Size(610, 310);
            rtbContent.TabIndex = 1;
            rtbContent.Text = "";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(13, 110, 253);
            btnClose.Cursor = Cursors.Hand;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold, GraphicsUnit.Point);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(265, 415);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 35);
            btnClose.TabIndex = 2;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // FormAbout
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(650, 465);
            Controls.Add(btnClose);
            Controls.Add(rtbContent);
            Controls.Add(panelTop);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormAbout";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Giới thiệu đề tài dự án";
            Load += FormAbout_Load;
            panelTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblTitle;
        private Label lblSubtitle;
        private RichTextBox rtbContent;
        private Button btnClose;
    }
}
