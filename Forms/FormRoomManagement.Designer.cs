namespace CinemaManagement.Forms
{
    partial class FormRoomManagement
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
            lblHeader = new Label();
            panelControls = new Panel();
            grpRoomInfo = new GroupBox();
            lblVipHint = new Label();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnClear = new Button();
            txtVipRows = new TextBox();
            lblVipRows = new Label();
            txtSeatsPerRow = new TextBox();
            lblSeatsPerRow = new Label();
            txtRows = new TextBox();
            lblRows = new Label();
            txtName = new TextBox();
            lblName = new Label();
            txtId = new TextBox();
            lblId = new Label();
            lvRooms = new ListView();
            colId = new ColumnHeader();
            colName = new ColumnHeader();
            colRows = new ColumnHeader();
            colSeatsPerRow = new ColumnHeader();
            colTotalSeats = new ColumnHeader();
            colVipRows = new ColumnHeader();
            panelTop.SuspendLayout();
            panelControls.SuspendLayout();
            grpRoomInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.FromArgb(33, 37, 41);
            panelTop.Controls.Add(lblHeader);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(880, 55);
            panelTop.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            lblHeader.ForeColor = Color.FromArgb(255, 193, 7);
            lblHeader.Location = new Point(0, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(880, 55);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "🏛️ QUẢN LÝ PHÒNG CHIẾU (SV1)";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelControls
            // 
            panelControls.Controls.Add(grpRoomInfo);
            panelControls.Dock = DockStyle.Top;
            panelControls.Location = new Point(0, 55);
            panelControls.Name = "panelControls";
            panelControls.Padding = new Padding(10);
            panelControls.Size = new Size(880, 210);
            panelControls.TabIndex = 1;
            // 
            // grpRoomInfo
            // 
            grpRoomInfo.Controls.Add(lblVipHint);
            grpRoomInfo.Controls.Add(btnDelete);
            grpRoomInfo.Controls.Add(btnUpdate);
            grpRoomInfo.Controls.Add(btnAdd);
            grpRoomInfo.Controls.Add(btnClear);
            grpRoomInfo.Controls.Add(txtVipRows);
            grpRoomInfo.Controls.Add(lblVipRows);
            grpRoomInfo.Controls.Add(txtSeatsPerRow);
            grpRoomInfo.Controls.Add(lblSeatsPerRow);
            grpRoomInfo.Controls.Add(txtRows);
            grpRoomInfo.Controls.Add(lblRows);
            grpRoomInfo.Controls.Add(txtName);
            grpRoomInfo.Controls.Add(lblName);
            grpRoomInfo.Controls.Add(txtId);
            grpRoomInfo.Controls.Add(lblId);
            grpRoomInfo.Dock = DockStyle.Fill;
            grpRoomInfo.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            grpRoomInfo.Location = new Point(10, 10);
            grpRoomInfo.Name = "grpRoomInfo";
            grpRoomInfo.Size = new Size(860, 190);
            grpRoomInfo.TabIndex = 0;
            grpRoomInfo.TabStop = false;
            grpRoomInfo.Text = "Cấu hình thông tin phòng chiếu";
            // 
            // lblVipHint
            // 
            lblVipHint.AutoSize = true;
            lblVipHint.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            lblVipHint.ForeColor = Color.Gray;
            lblVipHint.Location = new Point(415, 110);
            lblVipHint.Name = "lblVipHint";
            lblVipHint.Size = new Size(346, 19);
            lblVipHint.TabIndex = 14;
            lblVipHint.Text = "(Ví dụ: C,D hoặc D,E - cách nhau bằng dấu phẩy)";
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(530, 145);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(110, 34);
            btnDelete.TabIndex = 13;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(13, 110, 253);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(400, 145);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(110, 34);
            btnUpdate.TabIndex = 12;
            btnUpdate.Text = "✏️ Cập nhật";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(25, 135, 84);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(270, 145);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(110, 34);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "➕ Thêm mới";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(108, 117, 125);
            btnClear.Cursor = Cursors.Hand;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(140, 145);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(110, 34);
            btnClear.TabIndex = 10;
            btnClear.Text = "🔄 Làm mới";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // txtVipRows
            // 
            txtVipRows.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtVipRows.Location = new Point(230, 105);
            txtVipRows.Name = "txtVipRows";
            txtVipRows.Size = new Size(170, 27);
            txtVipRows.TabIndex = 9;
            // 
            // lblVipRows
            // 
            lblVipRows.AutoSize = true;
            lblVipRows.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblVipRows.Location = new Point(25, 108);
            lblVipRows.Name = "lblVipRows";
            lblVipRows.Size = new Size(189, 20);
            lblVipRows.TabIndex = 8;
            lblVipRows.Text = "Các hàng VIP (VD: C, D):";
            // 
            // txtSeatsPerRow
            // 
            txtSeatsPerRow.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtSeatsPerRow.Location = new Point(620, 68);
            txtSeatsPerRow.Name = "txtSeatsPerRow";
            txtSeatsPerRow.Size = new Size(170, 27);
            txtSeatsPerRow.TabIndex = 7;
            // 
            // lblSeatsPerRow
            // 
            lblSeatsPerRow.AutoSize = true;
            lblSeatsPerRow.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblSeatsPerRow.Location = new Point(460, 71);
            lblSeatsPerRow.Name = "lblSeatsPerRow";
            lblSeatsPerRow.Size = new Size(149, 20);
            lblSeatsPerRow.TabIndex = 6;
            lblSeatsPerRow.Text = "Số ghế trên mỗi hàng:";
            // 
            // txtRows
            // 
            txtRows.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtRows.Location = new Point(230, 68);
            txtRows.Name = "txtRows";
            txtRows.Size = new Size(170, 27);
            txtRows.TabIndex = 5;
            // 
            // lblRows
            // 
            lblRows.AutoSize = true;
            lblRows.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblRows.Location = new Point(25, 71);
            lblRows.Name = "lblRows";
            lblRows.Size = new Size(193, 20);
            lblRows.TabIndex = 4;
            lblRows.Text = "Số hàng ghế (tương ứng A-Z):";
            // 
            // txtName
            // 
            txtName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtName.Location = new Point(540, 30);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 27);
            txtName.TabIndex = 3;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.Location = new Point(420, 33);
            lblName.Name = "lblName";
            lblName.Size = new Size(116, 20);
            lblName.TabIndex = 2;
            lblName.Text = "Tên phòng chiếu:";
            // 
            // txtId
            // 
            txtId.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            txtId.Location = new Point(230, 30);
            txtId.Name = "txtId";
            txtId.Size = new Size(170, 27);
            txtId.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            lblId.Location = new Point(25, 33);
            lblId.Name = "lblId";
            lblId.Size = new Size(114, 20);
            lblId.TabIndex = 0;
            lblId.Text = "Mã phòng (P...):";
            // 
            // lvRooms
            // 
            lvRooms.Columns.AddRange(new ColumnHeader[] { colId, colName, colRows, colSeatsPerRow, colTotalSeats, colVipRows });
            lvRooms.Dock = DockStyle.Fill;
            lvRooms.FullRowSelect = true;
            lvRooms.GridLines = true;
            lvRooms.Location = new Point(0, 265);
            lvRooms.MultiSelect = false;
            lvRooms.Name = "lvRooms";
            lvRooms.Size = new Size(880, 285);
            lvRooms.TabIndex = 2;
            lvRooms.UseCompatibleStateImageBehavior = false;
            lvRooms.View = View.Details;
            lvRooms.SelectedIndexChanged += lvRooms_SelectedIndexChanged;
            // 
            // colId
            // 
            colId.Text = "Mã Phòng";
            colId.Width = 110;
            // 
            // colName
            // 
            colName.Text = "Tên Phòng Chiếu";
            colName.Width = 240;
            // 
            // colRows
            // 
            colRows.Text = "Số Hàng";
            colRows.Width = 90;
            // 
            // colSeatsPerRow
            // 
            colSeatsPerRow.Text = "Ghế/Hàng";
            colSeatsPerRow.Width = 100;
            // 
            // colTotalSeats
            // 
            colTotalSeats.Text = "Tổng Chỗ";
            colTotalSeats.Width = 100;
            // 
            // colVipRows
            // 
            colVipRows.Text = "Hàng VIP";
            colVipRows.Width = 180;
            // 
            // FormRoomManagement
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 550);
            Controls.Add(lvRooms);
            Controls.Add(panelControls);
            Controls.Add(panelTop);
            Name = "FormRoomManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý phòng chiếu - Phân hệ SV1";
            Load += FormRoomManagement_Load;
            panelTop.ResumeLayout(false);
            panelControls.ResumeLayout(false);
            grpRoomInfo.ResumeLayout(false);
            grpRoomInfo.PerformLayout();
            ResumeLayout(false);
        }

        private Panel panelTop;
        private Label lblHeader;
        private Panel panelControls;
        private GroupBox grpRoomInfo;
        private TextBox txtId;
        private Label lblId;
        private TextBox txtName;
        private Label lblName;
        private TextBox txtRows;
        private Label lblRows;
        private TextBox txtSeatsPerRow;
        private Label lblSeatsPerRow;
        private TextBox txtVipRows;
        private Label lblVipRows;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnClear;
        private Label lblVipHint;
        private ListView lvRooms;
        private ColumnHeader colId;
        private ColumnHeader colName;
        private ColumnHeader colRows;
        private ColumnHeader colSeatsPerRow;
        private ColumnHeader colTotalSeats;
        private ColumnHeader colVipRows;
    }
}
