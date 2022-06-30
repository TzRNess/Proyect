Imports System.Data
Imports System.Data.OleDb


Public Class Usuarios
    Public sql As String
    Public cmd As New OleDb.OleDbCommand
    Private Mover As Boolean = False



    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If (Me.TxtDni.Text = "") Then
            MsgBox("El campo Dni no puede estar vacio", MsgBoxStyle.Critical, "Atencion")
            Me.TxtDni.Select()

        Else

            Dim Dni As Integer
            Dim Contraseña As Integer
            Dim Nombre As String = ""
            Dim Apellido As String = ""
            Dim Barrio As String = ""


            Dni = Me.TxtDni.Text
            Contraseña = Me.Txtcontrseña.Text
            Nombre = Me.TxtNom.Text
            Apellido = Me.TxtApe.Text
            Barrio = Me.TxtBarrio.Text


            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            sql = "insert into Usuarios (Dni, Contraseña, Nombre, Apellido, Barrio) "
            sql += "Values (" & Dni & ", " & Contraseña & " , '" & Nombre & "','" & Apellido & "','" & Barrio & "')"

            cmd.CommandText = sql

            Try

                cmd.ExecuteNonQuery()

                MsgBox("Los datos se guardaron con exito")
                Me.TxtDni.Text = ""
                Me.Txtcontrseña.Text = ""
                Me.TxtNom.Text = ""
                Me.TxtApe.Text = ""
                Me.TxtBarrio.Text = ""

            Catch ex As Exception

                If MsgBox("Los datos ya existen en al base de datos") Then

                Else


                End If



            End Try


        End If
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
    Private Sub TxtDni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtDni.KeyPress
        Solonumeros(e)

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

    Private Sub Usuarios_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class