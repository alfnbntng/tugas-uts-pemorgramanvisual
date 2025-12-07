<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btn_refresh = New Button()
        btn_delete = New Button()
        btnAdd = New Button()
        btn_edit = New Button()
        TableLayoutPanel1 = New TableLayoutPanel()
        TableLayoutPanel2 = New TableLayoutPanel()
        Panel1 = New Panel()
        DataGridView1 = New DataGridView()
        Column1 = New DataGridViewTextBoxColumn()
        Column2 = New DataGridViewTextBoxColumn()
        Column3 = New DataGridViewTextBoxColumn()
        Column4 = New DataGridViewTextBoxColumn()
        Column5 = New DataGridViewTextBoxColumn()
        Column6 = New DataGridViewTextBoxColumn()
        lbl_total_harga_perolehan = New Label()
        total_harga_perolehan = New Label()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel2.SuspendLayout()
        Panel1.SuspendLayout()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btn_refresh
        ' 
        btn_refresh.BackColor = Color.AliceBlue
        btn_refresh.Dock = DockStyle.Fill
        btn_refresh.Font = New Font("Segoe UI", 12F)
        btn_refresh.ForeColor = SystemColors.WindowFrame
        btn_refresh.Location = New Point(753, 3)
        btn_refresh.Name = "btn_refresh"
        btn_refresh.Size = New Size(246, 52)
        btn_refresh.TabIndex = 3
        btn_refresh.Text = "Muat Ulang"
        btn_refresh.UseVisualStyleBackColor = False
        ' 
        ' btn_delete
        ' 
        btn_delete.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        btn_delete.Dock = DockStyle.Fill
        btn_delete.Font = New Font("Segoe UI", 12F)
        btn_delete.ForeColor = SystemColors.ButtonFace
        btn_delete.Location = New Point(253, 3)
        btn_delete.Name = "btn_delete"
        btn_delete.Size = New Size(244, 52)
        btn_delete.TabIndex = 2
        btn_delete.Text = "Hapus Aset"
        btn_delete.UseVisualStyleBackColor = False
        ' 
        ' btnAdd
        ' 
        btnAdd.BackColor = Color.LimeGreen
        btnAdd.Dock = DockStyle.Fill
        btnAdd.Font = New Font("Segoe UI", 12F)
        btnAdd.ForeColor = SystemColors.ButtonFace
        btnAdd.Location = New Point(3, 3)
        btnAdd.Name = "btnAdd"
        btnAdd.Size = New Size(244, 52)
        btnAdd.TabIndex = 0
        btnAdd.Text = "Tambah Aset"
        btnAdd.UseVisualStyleBackColor = False
        ' 
        ' btn_edit
        ' 
        btn_edit.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(0))
        btn_edit.Dock = DockStyle.Fill
        btn_edit.Font = New Font("Segoe UI", 12F)
        btn_edit.ForeColor = SystemColors.ButtonFace
        btn_edit.Location = New Point(503, 3)
        btn_edit.Name = "btn_edit"
        btn_edit.Size = New Size(244, 52)
        btn_edit.TabIndex = 1
        btn_edit.Text = "Edit Aset"
        btn_edit.UseVisualStyleBackColor = False
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.BackColor = SystemColors.ButtonHighlight
        TableLayoutPanel1.ColumnCount = 1
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Controls.Add(total_harga_perolehan, 0, 1)
        TableLayoutPanel1.Controls.Add(lbl_total_harga_perolehan, 0, 0)
        TableLayoutPanel1.Dock = DockStyle.Bottom
        TableLayoutPanel1.Location = New Point(0, 566)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 2
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50F))
        TableLayoutPanel1.Size = New Size(1002, 98)
        TableLayoutPanel1.TabIndex = 4
        ' 
        ' TableLayoutPanel2
        ' 
        TableLayoutPanel2.ColumnCount = 4
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 25F))
        TableLayoutPanel2.Controls.Add(btnAdd, 0, 0)
        TableLayoutPanel2.Controls.Add(btn_refresh, 3, 0)
        TableLayoutPanel2.Controls.Add(btn_delete, 1, 0)
        TableLayoutPanel2.Controls.Add(btn_edit, 2, 0)
        TableLayoutPanel2.Dock = DockStyle.Top
        TableLayoutPanel2.Location = New Point(0, 0)
        TableLayoutPanel2.Name = "TableLayoutPanel2"
        TableLayoutPanel2.RowCount = 1
        TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel2.Size = New Size(1002, 58)
        TableLayoutPanel2.TabIndex = 5
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(DataGridView1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 58)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1002, 508)
        Panel1.TabIndex = 6
        ' 
        ' DataGridView1
        ' 
        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        DataGridView1.BackgroundColor = SystemColors.ButtonHighlight
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Columns.AddRange(New DataGridViewColumn() {Column1, Column2, Column3, Column4, Column5, Column6})
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(0, 0)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersVisible = False
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(1002, 508)
        DataGridView1.TabIndex = 1
        ' 
        ' Column1
        ' 
        Column1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column1.HeaderText = "Kode Barang"
        Column1.MinimumWidth = 8
        Column1.Name = "Column1"
        ' 
        ' Column2
        ' 
        Column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column2.HeaderText = "Nama Barang"
        Column2.MinimumWidth = 8
        Column2.Name = "Column2"
        ' 
        ' Column3
        ' 
        Column3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column3.HeaderText = "Umur Ekonomis Barang (tahun)"
        Column3.MinimumWidth = 8
        Column3.Name = "Column3"
        ' 
        ' Column4
        ' 
        Column4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column4.HeaderText = "Harga Perolehan"
        Column4.MinimumWidth = 8
        Column4.Name = "Column4"
        ' 
        ' Column5
        ' 
        Column5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column5.HeaderText = "Jenis Aset"
        Column5.MinimumWidth = 8
        Column5.Name = "Column5"
        ' 
        ' Column6
        ' 
        Column6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        Column6.HeaderText = "Tanggal Perolehan"
        Column6.MinimumWidth = 8
        Column6.Name = "Column6"
        ' 
        ' lbl_total_harga_perolehan
        ' 
        lbl_total_harga_perolehan.AutoSize = True
        lbl_total_harga_perolehan.Dock = DockStyle.Fill
        lbl_total_harga_perolehan.Location = New Point(3, 0)
        lbl_total_harga_perolehan.Name = "lbl_total_harga_perolehan"
        lbl_total_harga_perolehan.Size = New Size(996, 49)
        lbl_total_harga_perolehan.TabIndex = 0
        lbl_total_harga_perolehan.Text = "total harga perolehan"
        lbl_total_harga_perolehan.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' total_harga_perolehan
        ' 
        total_harga_perolehan.AutoSize = True
        total_harga_perolehan.Dock = DockStyle.Fill
        total_harga_perolehan.Location = New Point(3, 49)
        total_harga_perolehan.Name = "total_harga_perolehan"
        total_harga_perolehan.Size = New Size(996, 49)
        total_harga_perolehan.TabIndex = 2
        total_harga_perolehan.Text = "total harga perolehan"
        total_harga_perolehan.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSizeMode = AutoSizeMode.GrowAndShrink
        BackColor = SystemColors.ControlDark
        ClientSize = New Size(1002, 664)
        Controls.Add(Panel1)
        Controls.Add(TableLayoutPanel2)
        Controls.Add(TableLayoutPanel1)
        MinimumSize = New Size(800, 600)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        WindowState = FormWindowState.Maximized
        TableLayoutPanel1.ResumeLayout(False)
        TableLayoutPanel1.PerformLayout()
        TableLayoutPanel2.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents btnAdd As Button
    Friend WithEvents btn_edit As Button
    Friend WithEvents btn_delete As Button
    Friend WithEvents btn_refresh As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents total_harga_perolehan As Label
    Friend WithEvents lbl_total_harga_perolehan As Label

End Class
