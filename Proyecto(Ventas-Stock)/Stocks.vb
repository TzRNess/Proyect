Public Class Stocks

    Private Mover As Boolean = False
    Private Sub Stocks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenargrid()


    End Sub

    Private Sub llenargrid()

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim strsql As String = "select idProductos, NombreProducto, Linea, Stock, Precio from Productos"
        Dim adp As New OleDb.OleDbDataAdapter(strsql, conn)

        ds.Tables.Add("Productos")

        adp.Fill(ds.Tables("Productos"))

        Me.DataGridView1.DataSource = ds.Tables("Productos")





    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress


        Dim strsql As String = ("select * from Productos where idProductos like '" + TextBox1.Text + "%'")
        Dim Da As New OleDb.OleDbDataAdapter(strsql, conn)
        Dim dt = New DataTable


        Da.Fill(dt)

        Me.DataGridView1.DataSource = dt

        Solonumeros(e)

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Menu1.Show()
        Me.Hide()

    End Sub

    Public Sub Solonumeros(ByRef e As System.Windows.Forms.KeyPressEventArgs)
        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        Else
            e.Handled = True
            MsgBox("Este campo es unicamente para numeros")

        End If
    End Sub


    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Agregar.Show()
        Me.Hide()
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


    Private Sub Inicio_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Mover = False

    End Sub


    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        RegistroV.Show()
        Me.Hide()

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        llenargrid()

    End Sub

End Class