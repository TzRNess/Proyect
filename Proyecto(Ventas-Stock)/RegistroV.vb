Public Class RegistroV

    Private Mover As Boolean = False

    Private Sub RegistroV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenargrid2()
    End Sub

    Public Sub llenargrid2()
        Dim suma As Double
        Dim Columna As DataGridViewRow
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim strsql As String = "select VentaNro, MontoTotal, Fecha from Ventas"
        Dim adp As New OleDb.OleDbDataAdapter(strsql, conn)

        ds.Tables.Add("Ventas")

        adp.Fill(ds.Tables("Ventas"))

        Me.DataGridView1.DataSource = ds.Tables("Ventas")


        For Each Columna In DataGridView1.Rows
            suma = suma + Columna.Cells(1).Value
            Me.TextBox1.Text = suma

        Next


    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Stocks.Show()
        Me.Hide()
    End Sub

    

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        llenargrid2()
    End Sub

    Private Sub Inicio_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Mover = True
    End Sub


    Private Sub Inicio_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If Mover Then
            If e.Button = Windows.Forms.MouseButtons.Left Then
                Me.Location = Cursor.Position

            End If
        End If
    End Sub


End Class