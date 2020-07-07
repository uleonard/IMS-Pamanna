Imports System.Data
Imports System.Data.OleDb
Public Class SuppliersTable
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()
    Public Sub loadDatagridSuppliers()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT [name] AS [NAME] FROM suppliers", myConnection)
        da.Fill(ds, "suppliers")
        Dim view1 As New DataView(ds.Tables("suppliers"))
        source1.DataSource = view1
        SuppliersForm.dgvSuppliers.DataSource = view1
        myConnection.Close()
    End Sub
End Class
