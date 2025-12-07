Imports System.Drawing
Imports System.Windows.Forms
Imports Npgsql

Public Class Form2
    Inherits Form

    Private Const koneksi As String = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=tugas_uts_pv"

    Private lblKode As Label
    Private txtKode As TextBox

    Private lblNama As Label
    Private txtNama As TextBox

    Private lblUeb As Label
    Private txtUeb As TextBox

    Private lblHarga As Label
    Private txtHarga As TextBox

    Private lblJenis As Label
    Private comboJenis As ComboBox

    Private lblTanggal As Label
    Private datePicker As DateTimePicker

    Private btnOK As Button
    Private btnCancel As Button

    Private table As TableLayoutPanel
    Private buttonsPanel As FlowLayoutPanel

    Private isEditMode As Boolean = False
    Private originalKode As String = Nothing

    Public Property LoadSucceeded As Boolean = True
    Public Property LoadErrorMessage As String = String.Empty

    Public ReadOnly Property ResultingKode As String
        Get
            Return If(txtKode IsNot Nothing, txtKode.Text.Trim(), String.Empty)
        End Get
    End Property

    Public Sub New()
        Me.Text = "Tambah Barang"
        Me.StartPosition = FormStartPosition.CenterParent
        Me.ClientSize = New Size(520, 380)
        Me.MinimumSize = New Size(460, 340)
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.MaximizeBox = True
        Me.MinimizeBox = True
        Me.ShowInTaskbar = False
        Me.AutoScaleMode = AutoScaleMode.Font

        InitializeControls()
    End Sub

    Public Sub New(kodeToEdit As String)
        Me.New() '
        If Not String.IsNullOrWhiteSpace(kodeToEdit) Then
            isEditMode = True
            originalKode = kodeToEdit.Trim()
            Me.Text = "Edit Barang - " & originalKode
            LoadDataForEdit(originalKode)
        End If
    End Sub

    Private Sub InitializeControls()
        table = New TableLayoutPanel() With {
            .Dock = DockStyle.Fill,
            .ColumnCount = 2,
            .RowCount = 8,
            .Padding = New Padding(12),
            .AutoSize = False
        }

        table.ColumnStyles.Add(New ColumnStyle(SizeType.AutoSize))
        table.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0F))

        For i As Integer = 0 To table.RowCount - 1
            table.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        Next

        lblKode = New Label() With {
            .Text = "Kode Barang:",
            .Anchor = AnchorStyles.Right,
            .AutoSize = True,
            .Margin = New Padding(3, 8, 6, 6)
        }
        txtKode = New TextBox() With {
            .Name = "txtKode",
            .Dock = DockStyle.Fill,
            .Margin = New Padding(3, 5, 3, 5)
        }

        lblNama = New Label() With {
            .Text = "Nama Barang:",
            .Anchor = AnchorStyles.Right,
            .AutoSize = True,
            .Margin = New Padding(3, 8, 6, 6)
        }
        txtNama = New TextBox() With {
            .Name = "txtNama",
            .Dock = DockStyle.Fill,
            .Margin = New Padding(3, 5, 3, 5)
        }

        lblUeb = New Label() With {
            .Text = "UEB (Integer):",
            .Anchor = AnchorStyles.Right,
            .AutoSize = True,
            .Margin = New Padding(3, 8, 6, 6)
        }
        txtUeb = New TextBox() With {
            .Name = "txtUeb",
            .Dock = DockStyle.Fill,
            .Margin = New Padding(3, 5, 3, 5)
        }

        lblHarga = New Label() With {
            .Text = "Harga Perolehan:",
            .Anchor = AnchorStyles.Right,
            .AutoSize = True,
            .Margin = New Padding(3, 8, 6, 6)
        }
        txtHarga = New TextBox() With {
            .Name = "txtHarga",
            .Dock = DockStyle.Fill,
            .Margin = New Padding(3, 5, 3, 5)
        }

        lblJenis = New Label() With {
            .Text = "Jenis Aset:",
            .Anchor = AnchorStyles.Right,
            .AutoSize = True,
            .Margin = New Padding(3, 8, 6, 6)
        }
        comboJenis = New ComboBox() With {
            .Name = "comboJenis",
            .Dock = DockStyle.Fill,
            .Margin = New Padding(3, 5, 3, 5),
            .DropDownStyle = ComboBoxStyle.DropDownList
        }
        Dim enumValues = [Enum].GetValues(GetType(JenisAset))
        If enumValues IsNot Nothing AndAlso enumValues.Length > 0 Then
            comboJenis.DataSource = enumValues
            ' pilih default "Tanah" kalau ada; jika tidak, pilih index 0 tetapi hanya jika ada item
            Dim defaultItem As Object = Nothing
            For Each v In enumValues
                If v.ToString() = "Tanah" Then
                    defaultItem = v
                    Exit For
                End If
            Next

            If defaultItem IsNot Nothing Then
                comboJenis.SelectedItem = defaultItem
            ElseIf comboJenis.Items.Count > 0 Then
                comboJenis.SelectedIndex = 0
            End If
        Else
            comboJenis.Items.Clear()
        End If

        lblTanggal = New Label() With {
            .Text = "Tanggal Perolehan:",
            .Anchor = AnchorStyles.Right,
            .AutoSize = True,
            .Margin = New Padding(3, 8, 6, 6)
        }
        datePicker = New DateTimePicker() With {
            .Name = "datePicker",
            .Dock = DockStyle.Fill,
            .Margin = New Padding(3, 5, 3, 5),
            .Format = DateTimePickerFormat.Short,
            .Value = Date.Today
        }

        buttonsPanel = New FlowLayoutPanel() With {
            .FlowDirection = FlowDirection.RightToLeft,
            .Dock = DockStyle.Fill,
            .AutoSize = True,
            .Margin = New Padding(3, 12, 3, 3)
        }

        btnOK = New Button() With {
            .Text = "Simpan",
            .AutoSize = True,
            .Padding = New Padding(8, 4, 8, 4)
        }
        btnCancel = New Button() With {
            .Text = "Batal",
            .AutoSize = True,
            .Padding = New Padding(8, 4, 8, 4)
        }

        AddHandler btnOK.Click, AddressOf BtnOK_Click
        AddHandler btnCancel.Click, AddressOf BtnCancel_Click

        Dim row As Integer = 0
        table.Controls.Add(lblKode, 0, row)
        table.Controls.Add(txtKode, 1, row)
        row += 1

        table.Controls.Add(lblNama, 0, row)
        table.Controls.Add(txtNama, 1, row)
        row += 1

        table.Controls.Add(lblUeb, 0, row)
        table.Controls.Add(txtUeb, 1, row)
        row += 1

        table.Controls.Add(lblHarga, 0, row)
        table.Controls.Add(txtHarga, 1, row)
        row += 1

        table.Controls.Add(lblJenis, 0, row)
        table.Controls.Add(comboJenis, 1, row)
        row += 1

        table.Controls.Add(lblTanggal, 0, row)
        table.Controls.Add(datePicker, 1, row)
        row += 1

        buttonsPanel.Controls.Add(btnCancel)
        buttonsPanel.Controls.Add(btnOK)

        Dim holder As Panel = New Panel() With {
            .Dock = DockStyle.Fill,
            .AutoSize = True
        }
        holder.Controls.Add(buttonsPanel)
        buttonsPanel.Anchor = AnchorStyles.Top Or AnchorStyles.Right

        table.Controls.Add(holder, 0, row)
        table.SetColumnSpan(holder, 2)

        Me.Controls.Add(table)

        Me.AcceptButton = btnOK
        Me.CancelButton = btnCancel
    End Sub

    Private Sub LoadDataForEdit(kode As String)
        Try
            Using conn As New NpgsqlConnection(koneksi)
                conn.Open()
                Using cmd As New NpgsqlCommand("SELECT * FROM daftarbarang WHERE kodebarang = @kode LIMIT 1", conn)
                    cmd.Parameters.AddWithValue("@kode", kode)
                    Using rdr = cmd.ExecuteReader()
                        If rdr.Read() Then
                            txtKode.Text = rdr.Item("kodebarang").ToString()
                            txtNama.Text = rdr.Item("namabarang").ToString()
                            txtUeb.Text = rdr.Item("ueb").ToString()
                            txtHarga.Text = rdr.Item("hargaperolehan").ToString()

                            Dim jenStr As String = ""
                            If Not IsDBNull(rdr.Item("jenisaset")) Then jenStr = rdr.Item("jenisaset").ToString()

                            Dim parsedJenis As JenisAset
                            If [Enum].TryParse(Of JenisAset)(jenStr, True, parsedJenis) Then
                                If comboJenis.Items.Count > 0 Then
                                    comboJenis.SelectedItem = parsedJenis
                                End If
                            Else
                                If comboJenis.Items.Count > 0 Then
                                    comboJenis.SelectedIndex = 0
                                End If
                            End If

                            Dim raw = rdr.Item("tanggalperolehan")
                            If IsDBNull(raw) Then

                            Else
                                Dim dateValue As DateTime = DateTime.MinValue
                                If TypeOf raw Is DateTime Then
                                    dateValue = CType(raw, DateTime)
                                Else
                                    Dim dateOnlyType = Type.GetType("System.DateOnly")
                                    If dateOnlyType IsNot Nothing AndAlso dateOnlyType.IsInstanceOfType(raw) Then
                                        Dim toDateTime = dateOnlyType.GetMethod("ToDateTime", New Type() {Type.GetType("System.TimeOnly")})
                                        If toDateTime IsNot Nothing Then
                                            Dim timeOnlyType = Type.GetType("System.TimeOnly")
                                            Dim timeMinValue As Object = Nothing
                                            If timeOnlyType IsNot Nothing Then
                                                Dim minProp = timeOnlyType.GetProperty("MinValue", Reflection.BindingFlags.Public Or Reflection.BindingFlags.Static)
                                                If minProp IsNot Nothing Then
                                                    timeMinValue = minProp.GetValue(Nothing)
                                                End If
                                            End If
                                            Try
                                                If timeMinValue IsNot Nothing Then
                                                    dateValue = CType(toDateTime.Invoke(raw, New Object() {timeMinValue}), DateTime)
                                                Else
                                                    Dim toDateTimeNoArg = dateOnlyType.GetMethod("ToDateTime", Type.EmptyTypes)
                                                    If toDateTimeNoArg IsNot Nothing Then
                                                        dateValue = CType(toDateTimeNoArg.Invoke(raw, Nothing), DateTime)
                                                    Else
                                                        dateValue = DateTime.Today
                                                    End If
                                                End If
                                            Catch
                                                dateValue = DateTime.Today
                                            End Try
                                        End If
                                    Else
                                        Try
                                            dateValue = Convert.ToDateTime(raw)
                                        Catch
                                            dateValue = DateTime.Today
                                        End Try
                                    End If
                                End If

                                If dateValue <> DateTime.MinValue Then
                                    datePicker.Value = dateValue.Date
                                End If
                            End If
                            LoadSucceeded = True
                            Return
                        Else
                            LoadSucceeded = False
                            LoadErrorMessage = "Data tidak ditemukan untuk editing."
                            Return
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            LoadSucceeded = False
            LoadErrorMessage = "Gagal memuat data: " & ex.Message
        End Try
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs)
        If String.IsNullOrWhiteSpace(txtKode.Text) Then
            MessageBox.Show("Kode barang harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtKode.Focus()
            Return
        End If

        If String.IsNullOrWhiteSpace(txtNama.Text) Then
            MessageBox.Show("Nama barang harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Return
        End If

        Dim uebVal As Integer
        If Not Integer.TryParse(txtUeb.Text, uebVal) Then
            MessageBox.Show("UEB harus berupa bilangan bulat.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUeb.Focus()
            Return
        End If

        Dim hargaVal As Decimal
        If Not Decimal.TryParse(txtHarga.Text, hargaVal) Then
            MessageBox.Show("Harga harus berupa angka desimal (contoh: 1500000.00).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtHarga.Focus()
            Return
        End If

        Dim jenisEnum As JenisAset = CType(comboJenis.SelectedItem, JenisAset)
        Dim jenis As String = jenisEnum.ToString()

        Dim tgl As Date = datePicker.Value.Date

        Try
            Using conn As New NpgsqlConnection(koneksi)
                conn.Open()

                If isEditMode Then
                    Using cmd As New NpgsqlCommand("
                        UPDATE daftarbarang
                        SET kodebarang = @newkode,
                            namabarang = @nama,
                            ueb = @ueb,
                            hargaperolehan = @harga,
                            jenisaset = @jenis,
                            tanggalperolehan = @tgl
                        WHERE kodebarang = @origkode
                    ", conn)
                        cmd.Parameters.AddWithValue("@newkode", txtKode.Text.Trim())
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim())
                        cmd.Parameters.AddWithValue("@ueb", uebVal)
                        cmd.Parameters.AddWithValue("@harga", hargaVal)
                        cmd.Parameters.AddWithValue("@jenis", jenis)
                        cmd.Parameters.AddWithValue("@tgl", tgl)
                        cmd.Parameters.AddWithValue("@origkode", originalKode)

                        Dim rows As Integer = cmd.ExecuteNonQuery()
                        If rows > 0 Then
                            MessageBox.Show("Data berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.DialogResult = DialogResult.OK
                            Me.Close()
                            Return
                        Else
                            MessageBox.Show("Gagal memperbarui data (mungkin data sudah dihapus).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                Else
                    Using cmd As New NpgsqlCommand("
                        INSERT INTO daftarbarang (kodebarang, namabarang, ueb, hargaperolehan, jenisaset, tanggalperolehan)
                        VALUES (@kode, @nama, @ueb, @harga, @jenis, @tgl)
                    ", conn)
                        cmd.Parameters.AddWithValue("@kode", txtKode.Text.Trim())
                        cmd.Parameters.AddWithValue("@nama", txtNama.Text.Trim())
                        cmd.Parameters.AddWithValue("@ueb", uebVal)
                        cmd.Parameters.AddWithValue("@harga", hargaVal)
                        cmd.Parameters.AddWithValue("@jenis", jenis)
                        cmd.Parameters.AddWithValue("@tgl", tgl)

                        Dim rows As Integer = cmd.ExecuteNonQuery()
                        If rows > 0 Then
                            MessageBox.Show("Data berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                            Me.DialogResult = DialogResult.OK
                            Me.Close()
                            Return
                        Else
                            MessageBox.Show("Gagal menyimpan data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End If
            End Using
        Catch ex As PostgresException
            If ex.SqlState = "23505" Then
                MessageBox.Show("Kode barang sudah terdaftar. Gunakan kode lain.", "Duplikat", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtKode.Focus()
            Else
                MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs)
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

End Class
