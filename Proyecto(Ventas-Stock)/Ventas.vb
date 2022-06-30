Public Class Ventas

    Public sql As String
    Public cmd As New OleDb.OleDbCommand
    Dim comandos As New OleDb.OleDbCommand
    Dim adaptador As New OleDb.OleDbDataAdapter
    Dim Adp As New OleDb.OleDbDataAdapter
    Dim I As Integer = 0
    Dim H As Integer = 1
    Dim X As Integer = 0
    Private Mover As Boolean = False

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        Solonumeros(e)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

        Dim consulta As String
        Dim dt As New DataTable

        If TextBox1.Text <> "" Then

            consulta = ("Select NombreProducto, Precio from Productos where IdProductos=" & TextBox1.Text & "")
            Adp = New OleDb.OleDbDataAdapter(consulta, conn)
            Adp.Fill(dt)
            For Each row As DataRow In dt.Rows
                TextBox2.Text = row("NombreProducto").ToString
                TextBox4.Text = row("Precio").ToString
            Next


        End If

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

        Dim Cantidad As String
        Dim Total As String
        Dim Columna As DataGridViewRow
        Dim Suma As Double


        Cantidad = TextBox3.Text
        Total = Val(Cantidad) * Val(TextBox4.Text)

        DataGridView1.Rows.Add(TextBox2.Text, TextBox3.Text, TextBox4.Text, Total)



        For Each Columna In DataGridView1.Rows
            Suma = Suma + Columna.Cells(3).Value
            Me.TextBox5.Text = Suma

        Next

        Me.TextBox1.Text = ""
        Me.TextBox2.Text = ""
        Me.TextBox3.Text = ""
        Me.TextBox4.Text = ""

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

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        Solonumeros(e)

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        Menu1.Show()
        Me.Hide()
        DataGridView1.Rows.Clear()
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

    Public Sub Imprimir_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles Imprimir.PrintPage

        Dim prFont As New Font("Arial", 20, FontStyle.Bold)

        e.Graphics.DrawImage(PictureBox10.Image, 40, 40, 80, 80)

        e.Graphics.DrawString("Gracias Por su Compra", prFont, Brushes.Black, 40, 100)
        prFont = New Font("Consolas", 11, FontStyle.Regular)
        e.Graphics.DrawString(Date.Now.ToShortDateString.ToString & " " & Date.Now.ToShortTimeString.ToString, prFont, Brushes.Black, 50, 155)
        prFont = New Font("Consolas", 11, FontStyle.Regular)
        e.Graphics.DrawString("CUIT Nº 20-5678912-3", prFont, Brushes.Black, 50, 170)
        prFont = New Font("Consolas", 11, FontStyle.Regular)
        e.Graphics.DrawString("ING.BR: 10234545-1", prFont, Brushes.Black, 50, 185)
        prFont = New Font("Consolas", 11, FontStyle.Regular)
        e.Graphics.DrawString("Misiones 444 - Formosa", prFont, Brushes.Black, 50, 200)

        prFont = New Font("Consolas", 11, FontStyle.Regular)
        e.Graphics.DrawString("Pedido Nº 435", prFont, Brushes.Black, 50, 250)


        prFont = New Font("Consolas", 12, FontStyle.Regular)
        e.Graphics.DrawString("Articulos Varios" & "  $" & TextBox5.Text, prFont, Brushes.Black, 50, 300)
        prFont = New Font("Consolas", 14, FontStyle.Regular)
        e.Graphics.DrawString("        Total $" & " " & TextBox5.Text, prFont, Brushes.Black, 50, 330)

        prFont = New Font("Consolas", 11, FontStyle.Regular)
        e.Graphics.DrawString("IVA RESPONSABLE INSCRIPTO", prFont, Brushes.Black, 50, 390)
        prFont = New Font("Consolas", 11, FontStyle.Regular)
        e.Graphics.DrawString("A CONSUMIDOR FINAL", prFont, Brushes.Black, 50, 405)
        prFont = New Font("Segoe Print", 12, FontStyle.Regular)
        e.Graphics.DrawString("Vuelva Pronto!", prFont, Brushes.Black, 50, 430)
        'indicamos que hemos llegado al final de la pagina
        e.HasMorePages = False
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        Dim Importe As Integer

        If TextBox5.Text = "" Then
            MsgBox("No hay ningun producto agregado")
        Else
            Importe = Me.TextBox5.Text


            cmd.Connection = conn

            sql = "INSERT INTO Ventas (MontoTotal)"
            sql += " VALUES (" & Importe & ")"

            MsgBox("Gracias por su compra")

            cmd.CommandText = sql

            Try
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.ToString)

            End Try

            Imprimir.Print()


        End If
        DataGridView1.Rows.Clear()
        Me.TextBox5.Text = ""
    End Sub

    Private Sub Ventas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class