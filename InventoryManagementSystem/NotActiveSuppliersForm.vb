Imports System.Data
Imports System.Data.OleDb

Public Class NotActiveSuppliersForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim myConnection2 As OleDbConnection = New OleDbConnection
    Dim ds2 As DataSet = New DataSet
    Dim da2 As OleDbDataAdapter
    Dim source1 As New BindingSource()
    Dim source2 As New BindingSource()

    Private Sub NotActiveSuppliersForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSuppliers()

        If UserTable.role = "MANAGER" Or UserTable.role = "SUPERUSER" Then
            btnActivate.Enabled = True
        End If

    End Sub
    Public Sub LoadSuppliers()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT * FROM supplier WHERE status<>'Active'", myConnection)
        da.Fill(ds, "supplier")

        Dim view1 As New DataView(ds.Tables("supplier"))
        source1.DataSource = view1
        dgvSuppliers.DataSource = view1

        myConnection.Close()

    End Sub

    Private Sub btnActivate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivate.Click

        If myConnection.State = ConnectionState.Open Then
            myConnection.Close()

        End If

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()


        Dim str As String
        str = "UPDATE supplier SET [status] = ? WHERE name = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)

        
        cmd.Parameters.Add(New OleDbParameter("status", CType("Active", String)))
        cmd.Parameters.Add(New OleDbParameter("name", CType(dgvSuppliers.Rows(dgvSuppliers.CurrentCell.RowIndex).Cells(0).Value(), String)))

        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Supplier Activated!!!")
            SuppliersForm.LoadSuppliers()
            Me.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub
End Class