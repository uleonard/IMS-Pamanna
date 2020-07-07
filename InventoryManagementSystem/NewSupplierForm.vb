Imports System.Data
Imports System.Data.OleDb
Public Class NewSupplierForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    
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
        str = "INSERT INTO supplier ([name], [contact_person], [address], [phone], [email],[bank_details]) values (?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)

        cmd.Parameters.Add(New OleDbParameter("name", CType(txtName.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("contact_person", CType(txtContactPerson.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("address", CType(txtAddress.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("phone", CType(txtPhone.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("email", CType(txtEmail.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("bank_details", CType(txtBankDetails.Text, String)))

        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Supplier Saved!!!")
            txtName.Text = ""
            txtContactPerson.Text = ""
            txtAddress.Text = ""
            txtPhone.Text = ""
            txtEmail.Text = ""
            txtBankDetails.Text = ""
            txtName.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        SuppliersForm.LoadSuppliers()
        Me.Dispose()

    End Sub

    Private Sub NewSupplierForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SuppliersForm.LoadSuppliers()
        Me.Dispose()
    End Sub

    Private Sub NewSupplierForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = SuppliersForm.Left + 40
        Me.Top = SuppliersForm.Top + 200
    End Sub


End Class