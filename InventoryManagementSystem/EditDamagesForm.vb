Imports System.Data
Imports System.Data.OleDb
Public Class EditDamagesForm

    Private Sub VoidDamagesForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub

    Private Sub VoidDamagesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtID.Text = DamagesForm.dgvDamages.Rows(DamagesForm.dgvDamages.CurrentCell.RowIndex).Cells(0).Value.ToString

        dtpDate.Text = DamagesForm.dgvDamages.Rows(DamagesForm.dgvDamages.CurrentCell.RowIndex).Cells(1).Value.ToString
        txtProduct.Text = DamagesForm.dgvDamages.Rows(DamagesForm.dgvDamages.CurrentCell.RowIndex).Cells(2).Value.ToString
        txtRefNumber.Text = DamagesForm.dgvDamages.Rows(DamagesForm.dgvDamages.CurrentCell.RowIndex).Cells(3).Value.ToString
        txtQuantity.Text = DamagesForm.dgvDamages.Rows(DamagesForm.dgvDamages.CurrentCell.RowIndex).Cells(4).Value.ToString
        txtCost.Text = DamagesForm.dgvDamages.Rows(DamagesForm.dgvDamages.CurrentCell.RowIndex).Cells(6).Value.ToString
        txtDescription.Text = DamagesForm.dgvDamages.Rows(DamagesForm.dgvDamages.CurrentCell.RowIndex).Cells(7).Value.ToString
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim monInt As Integer = Month(CType(dtpDate.Text, Date))
        Dim monName As String = MonthName(monInt)
        Dim yr As Integer = Year(CType(dtpDate.Text, Date))

        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE damages  SET [damages_date] = ?, [year] = ?, [month] = ?, [ref_number] = ?, [quantity] = ?, [unit_cost] = ?, [cost] = ?, [description] = ?    WHERE damages_id = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("damages_date", CType(dtpDate.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(monName, String)))
        cmd.Parameters.Add(New OleDbParameter("ref_number", CType(txtRefNumber.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("quantity", CType(txtQuantity.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("unit_cost", CType(Val(txtCost.Text) / Val(txtQuantity.Text), String)))
        cmd.Parameters.Add(New OleDbParameter("cost", CType(txtCost.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("description", CType(txtDescription.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("damages_id", CType(txtID.Text, String)))

        Try
            cmd.ExecuteNonQuery()
            MsgBox("Transaction updated.")
            DamagesForm.txtRefNumber.Text = DamagesForm.dgvDamages.Rows(DamagesForm.dgvDamages.CurrentCell.RowIndex).Cells(3).Value()
            DamagesForm.Search()
            Me.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()

    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        Cost()
    End Sub
    Private Sub Cost()
        Dim connection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        connection.ConnectionString = dbCon.dbConnector()
        connection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT [product] FROM damages WHERE [damages_id] = ? ", connection)
        cmd.Parameters.Add(New OleDbParameter("damages_id", CType(txtID.Text, String)))

        Dim productCode As String = cmd.ExecuteScalar()

        Dim monInt As Integer = Month(CType(dtpDate.Text, Date))
        Dim monName As String = MonthName(monInt)
        Dim yr As Integer = Year(CType(dtpDate.Text, Date))

        Dim p As PurchasesTable = New PurchasesTable()
        Dim UnitCost As Double = p.GetLastUnitCostByProductPerMonth(yr, monName, productCode)
        txtCost.Text = UnitCost * Val(txtQuantity.Text)

    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        Cost()
    End Sub
End Class