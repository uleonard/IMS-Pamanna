Imports System.Data
Imports System.Data.OleDb
Public Class EnterReconciliationFigureForm

    Private Sub EnterReconciliationFigureForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtProduct.Text = CloseMonthForm.DataGridView1.Rows(CloseMonthForm.DataGridView1.CurrentCell.RowIndex).Cells("PRODUCT").Value.ToString
        txtDifference.Text = CloseMonthForm.DataGridView1.Rows(CloseMonthForm.DataGridView1.CurrentCell.RowIndex).Cells("VARIANCE").Value.ToString
    End Sub

    Private Sub btnReconcile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReconcile.Click
        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim Product As String = CloseMonthForm.DataGridView1.Rows(CloseMonthForm.DataGridView1.CurrentCell.RowIndex).Cells("CODE").Value.ToString

        'If a record already exists, delete it first
        DeleteRCFigureFirst(Product)

        Dim str As String
        str = "INSERT INTO reconciliation_figure ([product],  [year], [month], [quantity], [description], [entered_by], [date_entered]) values (?, ?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(Product, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(CloseMonthForm.comYear.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(CloseMonthForm.comMonth.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("quantity", CType(txtDifference.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("description", CType(txtDescription.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("entered_by", CType(UserTable.userId, String)))
        cmd.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))

        Try
            cmd.ExecuteNonQuery()
            'CloseMonthForm.DataGridView1.Rows(CloseMonthForm.DataGridView1.CurrentCell.RowIndex).Cells("VARIANCE").Value = "0"
            CloseMonthForm.DataGridView1.Rows(CloseMonthForm.DataGridView1.CurrentCell.RowIndex).Cells("RC FIGURE").Value = txtDifference.Text
            CloseMonthForm.DataGridView1.Rows(CloseMonthForm.DataGridView1.CurrentCell.RowIndex).Cells("RC STATUS").Value = "Reconciled"

            Me.Close()



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub

    Private Sub DeleteRCFigureFirst(ByVal product As String)
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



        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub
End Class