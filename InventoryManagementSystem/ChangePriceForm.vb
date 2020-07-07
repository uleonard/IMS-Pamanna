Imports System.Data
Imports System.Data.OleDb
Public Class ChangePriceForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()

    Private Sub ChangePriceForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub ChangePriceForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadDatagridPrices()
        lblProduct.Text = "Change Price - " & ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells("PRODUCT NAME").Value


        dgvPrices.Columns("DATE ENTERED").DefaultCellStyle.Format = "g"
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not Val(txtPrice.Text) > 0 Then
            MsgBox("Price cannot be empty or zero")
            txtPrice.Focus()
            Exit Sub
        End If
        Dim ProductID As String = ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(0).Value
        Dim p As ProductsTable = New ProductsTable()

        p.AddPrice(ProductID, txtPrice.Text)

        'Dim p2 As ProductsTable = New ProductsTable()

        p.UpdatePrice(ProductID, txtPrice.Text)

        ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells("UNIT PRICE").Value = txtPrice.Text

        'Reload Datagrid
        loadDatagridPrices()
        txtPrice.Text = ""
    End Sub
    Private Sub loadDatagridPrices()
        Dim ProductID As String = ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(0).Value

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        ds.Reset()

        da = New OleDbDataAdapter("SELECT [date_entered] AS [DATE ENTERED], [price] AS [PRODUCT PRICE], [entered_by] AS [ENTERED BY] FROM product_price WHERE product= '" & ProductID & "'", myConnection)
        da.Fill(ds, "product_price")
        Dim view1 As New DataView(tables(0))
        source1.DataSource = view1
        Me.dgvPrices.DataSource = view1
        ProductsForm.Refresh()
        myConnection.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub
End Class