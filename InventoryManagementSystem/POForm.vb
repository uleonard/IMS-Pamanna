Imports System.Data
Imports System.Data.OleDb
Public Class POForm
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()


    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Clear()

        da = New OleDbDataAdapter("SELECT [po], [po_frequency] FROM point_of_sale_summary_report WHERE [status] = 'Open' ", myConnection)
        da.Fill(ds, "po")

        Dim ra As Double = ds.Tables("po").Rows(0).Item(0) + Val(txtAmount.Text)
        Dim raf As Double = ds.Tables("po").Rows(0).Item(1) + 1

        myConnection.Close()

        myConnection.Open()

        Dim str As String
        str = "UPDATE point_of_sale_summary_report  SET po = ?, po_frequency = ? WHERE status = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("po", CType(ra, String)))
        cmd.Parameters.Add(New OleDbParameter("po_frequency", CType(raf, String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("Open", String)))

        Try
            cmd.ExecuteNonQuery()
            'MsgBox("Saved")

            txtAmount.Text = ""
            Me.Close()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub

    Private Sub POForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 20
        Me.Top = 50
    End Sub
End Class