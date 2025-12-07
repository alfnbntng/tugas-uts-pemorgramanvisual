Imports Npgsql

Public Class Form1

    Private Const koneksi As String = "Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=tugas_uts_pv"
    Dim conn = New NpgsqlConnection(koneksi)

    Dim i As Integer
    Dim dr As NpgsqlDataReader

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        load_data()
        hitung_total()
    End Sub

    Public Sub load_data()
        Try
            DataGridView1.Rows.Clear()

            If conn.State <> ConnectionState.Open Then
                conn.Open()
            End If

            Dim query As New NpgsqlCommand("SELECT * FROM daftarbarang ORDER BY id DESC", conn)
            dr = query.ExecuteReader()

            While dr.Read
                DataGridView1.Rows.Add(
                    dr.Item("kodebarang"),
                    dr.Item("namabarang"),
                    dr.Item("ueb"),
                    dr.Item("hargaperolehan"),
                    dr.Item("jenisaset"),
                    dr.Item("tanggalperolehan"))
            End While

            dr.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If conn.State <> ConnectionState.Closed Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            If conn.State <> ConnectionState.Closed Then conn.Close()
        Catch
        End Try

        Using dlg As New Form2()
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                load_data()
                DataGridView1.ClearSelection()
            End If
        End Using
    End Sub

    Private Sub btn_edit_Click(sender As Object, e As EventArgs) Handles btn_edit.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih satu baris yang ingin diedit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim kode As String = DataGridView1.SelectedRows(0).Cells(0).Value?.ToString()
        If String.IsNullOrWhiteSpace(kode) Then
            MessageBox.Show("Tidak dapat men-detek kode barang dari baris terpilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using dlg As New Form2(kode)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
                load_data()
                For Each r As DataGridViewRow In DataGridView1.Rows
                    If r.Cells(0).Value?.ToString() = dlg.ResultingKode Then
                        r.Selected = True
                        Exit For
                    End If
                Next
            End If
        End Using
    End Sub

    Private Sub btn_delete_Click(sender As Object, e As EventArgs) Handles btn_delete.Click
        If DataGridView1.SelectedRows.Count = 0 Then
            MessageBox.Show("Pilih satu baris yang ingin dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim kode As String = DataGridView1.SelectedRows(0).Cells(0).Value?.ToString()
        If String.IsNullOrWhiteSpace(kode) Then
            MessageBox.Show("Tidak dapat men-detek kode barang dari baris terpilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim confirm = MessageBox.Show($"Hapus barang dengan kode '{kode}' ? Data yang terhapus tidak bisa dikembalikan.", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm <> DialogResult.Yes Then Return

        Try
            If conn.State <> ConnectionState.Open Then conn.Open()
            Using cmd As New NpgsqlCommand("DELETE FROM daftarbarang WHERE kodebarang = @kode", conn)
                cmd.Parameters.AddWithValue("@kode", kode)
                Dim rows = cmd.ExecuteNonQuery()
                If rows > 0 Then
                    MessageBox.Show("Data berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Data tidak ditemukan atau gagal dihapus.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error saat menghapus: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If conn.State <> ConnectionState.Closed Then conn.Close()
            load_data()
        End Try
    End Sub

    Private Sub btn_refresh_Click(sender As Object, e As EventArgs) Handles btn_refresh.Click
        load_data()
        DataGridView1.ClearSelection()
    End Sub

    Private Sub total_harga_perolehan_Click(sender As Object, e As EventArgs) Handles total_harga_perolehan.Click
        Dim total = 0D

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Cells(3).Value IsNot Nothing AndAlso IsNumeric(row.Cells(3).Value) Then
                total += Convert.ToDecimal(row.Cells(3).Value)
            End If
        Next

        total_harga_perolehan.Text = total.ToString("N2")
    End Sub

    Private Sub hitung_total()
        Dim total As Decimal = 0D

        For Each row As DataGridViewRow In DataGridView1.Rows
            If Not row.IsNewRow Then
                Dim harga As Decimal
                If Decimal.TryParse(row.Cells(3).Value.ToString(), harga) Then
                    total += harga
                End If
            End If
        Next

        total_harga_perolehan.Text = "Rp " & total.ToString("N0")
    End Sub


End Class
