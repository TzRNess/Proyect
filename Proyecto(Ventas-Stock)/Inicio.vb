
Imports System.Runtime.InteropServices

Public Class Inicio
    Dim comandos As New OleDb.OleDbCommand
    Dim adaptador As New OleDb.OleDbDataAdapter
    Dim lector As OleDb.OleDbDataReader
    Private Mover As Boolean = False

    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        conectarse()


    End Sub




    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim consulta As String

        consulta = "select * from Usuarios where Dni =  " & Txtusu.Text & " and Contraseña = " & Txtcon.Text & ""
        comandos = New OleDb.OleDbCommand(consulta, conn)
        adaptador.SelectCommand = comandos

        lector = comandos.ExecuteReader

        If lector.Read = True Then
            Dim usuario As String = Me.Txtusu.Text

            Me.Txtusu.Text = ""
            Me.Txtcon.Text = ""

            Menu1.Show()


            Me.Hide()


        Else
            MsgBox("Usuario o Contraseña Incorrectos Amigazo")

        End If



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

    Private Sub Txtusu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtusu.KeyPress
        Solonumeros(e)
        Txtusu.UseSystemPasswordChar = True
    End Sub

    Private Sub Txtcon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Txtcon.KeyPress
        Solonumeros(e)
        Txtcon.UseSystemPasswordChar = True
    End Sub

    Private Sub Button1_Paint(sender As Object, e As PaintEventArgs) Handles Button1.Paint
        Dim Btn As Drawing2D.GraphicsPath = New Drawing2D.GraphicsPath()
        Dim Rectangulo As Rectangle = Button1.ClientRectangle
        Rectangulo.Inflate(-10, 10)
        Btn.AddEllipse(Rectangulo)
        Button1.Region = New Region(Btn)
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

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Application.Exit()
    End Sub
End Class
