Public Class Agregar
    Public cmd As New OleDb.OleDbCommand
    Public sql As String
    Private Mover As Boolean = False

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        Menu1.Show()
        Me.Hide()

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If (Me.TextBox1.Text = "") Then
            MsgBox("El campo IdProductos no puede estar vacio", MsgBoxStyle.Critical, "Atencion")
            Me.TextBox1.Select()
        Else
            Dim IdProd As Integer
            Dim NombreProducto As String = ""
            Dim Linea As String = ""
            Dim Stock As Integer
            Dim Precio As Integer


            IdProd = Me.TextBox1.Text
            NombreProducto = Me.TextBox2.Text
            Linea = Me.TextBox3.Text
            Stock = Me.TextBox4.Text
            Precio = Me.TextBox5.Text


            cmd.CommandType = CommandType.Text
            cmd.Connection = conn

            sql = "insert into Productos (IdProductos, NombreProducto, Linea, Stock, Precio) "
            sql += "Values (" & IdProd & ", '" & NombreProducto & "' , '" & Linea & "'," & Stock & "," & Precio & ")"

            cmd.CommandText = sql

            Try

                cmd.ExecuteNonQuery()

                MsgBox("Los datos se guardaron con exito")
                Me.TextBox1.Text = ""
                Me.TextBox2.Text = ""
                Me.TextBox3.Text = ""
                Me.TextBox4.Text = ""
                Me.TextBox5.Text = ""

            Catch ex As Exception

                If MsgBox("Los datos ya existen en al base de datos") Then

                Else


                End If


            End Try


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



   
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Solonumeros(e)

    End Sub

   
    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        Solonumeros(e)
    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
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

    Private Sub Agregar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class