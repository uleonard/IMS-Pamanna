Imports System.Data
Imports System.Data.OleDb
Public Class RAForm
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Clear()

        da = New OleDbDataAdapter("SELECT [ra], [ra_frequency] FROM point_of_sale_summary_report WHERE [status] = 'Open' ", myConnection)
        da.Fill(ds, "ra")

        Dim ra As Double = ds.Tables("ra").Rows(0).Item(0) + Val(txtAmount.Text)
        Dim raf As Double = ds.Tables("ra").Rows(0).Item(1) + 1
       
        myConnection.Close()



        myConnection.Open()

        Dim str As String
        str = "UPDATE point_of_sale_summary_report  SET ra = ?, ra_frequency = ? WHERE status = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("ra", CType(ra, String)))
        cmd.Parameters.Add(New OleDbParameter("ra_frequency", CType(raf, String)))
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        txtAmount.Text = ""
        Me.Close()

    End Sub

    Private Sub RAForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 20
        Me.Top = 50

    End Sub
End Class