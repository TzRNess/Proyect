Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.OleDb

Module Proyecto
    Public conn As New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Proyecto.accdb;Persist Security Info=False")

  

    Public Sub conectarse()

        Try
            conn.Open()



        Catch ex As Exception
            MsgBox(ex.ToString)




        End Try



    End Sub
  
End Module
