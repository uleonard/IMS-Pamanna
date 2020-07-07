Imports System.Data
Imports System.Data.OleDb
Public Class ReconciliationFiguresForm

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub ReconciliationFiguresForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblMonth.Text = CloseMonthForm.comMonth.Text & " / " & CloseMonthForm.comYear.Text


        Dim connection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        connection.ConnectionString = dbCon.dbConnector()
        connection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT p.[name] AS [PRODUCT], p.product_code AS [CODE], r.quantity AS QTY, r.description AS [DESCRIPTION], r.entered_by AS [ENTERED BY], r.date_entered AS [DATE ENTERED] FROM reconciliation_figure r INNER JOIN product p ON r.product=p.product_code WHERE r.[year] = ? AND r.[month] = ?", connection)
        cmd.Parameters.Add(New OleDbParameter("year", CType(CloseMonthForm.comYear.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(CloseMonthForm.comMonth.Text, String)))

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)

        DataGridView1.AutoGenerateColumns = True
        DataGridView1.DataSource = dt
        DataGridView1.Refresh()
        DataGridView1.AllowUserToAddRows = False

        reader.Close()

        connection.Close()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Not DataGridView1.SelectedCells.Count > 0 Then
            MsgBox("Select Row first.")
            Exit Sub

        End If

        Dim res As DialogResult = MsgBox("You are deleting RC Figure for " & DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("PRODUCT").Value & vbCrLf & "IS THIS IN ORDER ?", vbYesNo + MsgBoxStyle.Question, "Inventory Management System")
        If res = vbNo Then
            Exit Sub
        End If

        Dim product As String = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("CODE").Value

        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()


        Dim str As String
        str = "DELETE FROM reconciliation_figure WHERE [product]=? AND  [year]=? AND [month]=?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(Product, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(CloseMonthForm.comYear.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(CloseMonthForm.comMonth.Text, String)))

        Try
            cmd.ExecuteNonQuery()

            Me.Close()
            CloseMonthForm.LoadDatagrid()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim defaultName As String = "Reconciliation Figures For " & CloseMonthForm.comMonth.Text & " " & CloseMonthForm.comYear.Text

        Export(DataGridView1, defaultName)
    End Sub
End Class