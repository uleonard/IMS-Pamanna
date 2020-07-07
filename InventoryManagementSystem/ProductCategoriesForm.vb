Imports System.Data
Imports System.Data.OleDb
Public Class ProductCategoriesForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub ProductCategoriesForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub ProductCategoriesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        loadDatagridCategories()
    End Sub
    Private Sub dgvProductCategories_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProductCategories.CellMouseDoubleClick
        EditProductCategoryForm.ShowDialog()
    End Sub
    Public Sub loadDatagridCategories()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        ds.Reset()

        da = New OleDbDataAdapter("SELECT [name] AS [NAME], [description] AS [DESCRIPTION] FROM product_category", myConnection)
        da.Fill(ds, "product_category")
        Dim view1 As New DataView(tables(0))
        source1.DataSource = view1
        Me.dgvProductCategories.DataSource = view1
        ProductsForm.Refresh()
        myConnection.Close()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EditProductCategoryForm.ShowDialog()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        NewProductCategoryForm.ShowDialog()
    End Sub
End Class