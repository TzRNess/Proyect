Public Class EliminarUsu

    Dim Adp As New OleDb.OleDbDataAdapter
    Public cmd As New OleDb.OleDbCommand
    Public sql As String
    Private Mover As Boolean = False

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

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Solonumeros(e)
    End Sub


    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim consulta As String
        Dim dt As New DataTable

        If TextBox1.Text <> "" Then

            consulta = ("Select Nombre, Apellido from Usuarios where Dni=" & TextBox1.Text & "")
            Adp = New OleDb.OleDbDataAdapter(consulta, conn)
            Adp.Fill(dt)
            For Each row As DataRow In dt.Rows
                TextBox2.Text = row("Nombre").ToString
                TextBox3.Text = row("Apellido").ToString
            Next


        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Menu1.Show()
        Me.Hide()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Dim idpersona As Integer
        idpersona = Me.TextBox1.Text

        cmd.CommandType = CommandType.Text
        cmd.Connection = conn

        sql = " delete from Usuarios where Dni = " & idpersona & " "

        cmd.CommandText = sql


        Try

            cmd.ExecuteNonQuery()

            MsgBox("El usuario ah sido elminado")

        Catch ex As Exception

            MsgBox(ex.ToString)

        End Try

        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""


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