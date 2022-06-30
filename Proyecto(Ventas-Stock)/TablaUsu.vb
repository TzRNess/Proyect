Public Class TablaUsu
    Private Mover As Boolean = False
    Private Sub llenargrid()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim strsql As String = "select Nombre, Apellido,Barrio from Usuarios"
        Dim adp As New OleDb.OleDbDataAdapter(strsql, conn)

        ds.Tables.Add("Usuarios")

        adp.Fill(ds.Tables("Usuarios"))

        Me.DataGridView2.DataSource = ds.Tables("Usuarios")
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Menu1.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        EliminarUsu.Show()
        Me.Hide()
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        Usuarios.Show()
        Me.Hide()

    End Sub

    Private Sub TablaUsu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenargrid()
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
End Class