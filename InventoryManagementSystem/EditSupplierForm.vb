Imports System.Data
Imports System.Data.OleDb
Public Class EditSupplierForm
    Dim myConnection As OleDbConnection = New OleDbConnection

    Private Sub EditSupplierForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = SuppliersForm.Left + 40
        Me.Top = SuppliersForm.Top + 200

        txtCurrentName.Text = SuppliersForm.dgvSuppliers.Rows(SuppliersForm.dgvSuppliers.CurrentCell.RowIndex).Cells(0).Value()

        txtName.Text = SuppliersForm.dgvSuppliers.Rows(SuppliersForm.dgvSuppliers.CurrentCell.RowIndex).Cells(0).Value()
        txtContactPerson.Text = SuppliersForm.dgvSuppliers.Rows(SuppliersForm.dgvSuppliers.CurrentCell.RowIndex).Cells(1).Value()
        txtAddress.Text = SuppliersForm.dgvSuppliers.Rows(SuppliersForm.dgvSuppliers.CurrentCell.RowIndex).Cells(2).Value()
        txtPhone.Text = SuppliersForm.dgvSuppliers.Rows(SuppliersForm.dgvSuppliers.CurrentCell.RowIndex).Cells(3).Value()
        txtEmail.Text = SuppliersForm.dgvSuppliers.Rows(SuppliersForm.dgvSuppliers.CurrentCell.RowIndex).Cells(4).Value()
        txtBankDetails.Text = SuppliersForm.dgvSuppliers.Rows(SuppliersForm.dgvSuppliers.CurrentCell.RowIndex).Cells(5).Value()
        comStatus.Text = SuppliersForm.dgvSuppliers.Rows(SuppliersForm.dgvSuppliers.CurrentCell.RowIndex).Cells(6).Value()
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtName.Text = "" Then
            MessageBox.Show("Supplier name cannot be empty!!!")
            Exit Sub
        End If


        If myConnection.State = ConnectionState.Open Then
            myConnection.Close()

        End If

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()


        Dim str As String
        str = "UPDATE supplier SET [name] = ?, [contact_person] = ?, [address] = ?, [phone] = ?, [email] = ?, [bank_details] = ?, [status] = ? WHERE name = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(Str, myConnection)

        cmd.Parameters.Add(New OleDbParameter("name", CType(txtName.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("contact_person", CType(txtContactPerson.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("address", CType(txtAddress.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("phone", CType(txtPhone.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("email", CType(txtEmail.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("bank_details", CType(txtBankDetails.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType(comStatus.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("name", CType(txtCurrentName.Text, String)))

        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Supplier Edited!!!")
            SuppliersForm.LoadSuppliers()
            Me.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()

    End Sub
End Class