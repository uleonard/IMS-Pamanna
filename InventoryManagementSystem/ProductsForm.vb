
Public Class ProductsForm

    Private Sub ProductsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim p As ProductsTable = New ProductsTable()
        p.loadDatagridProducts()

        'FORMAT DATE COLUMNS
        dgvProducts.Columns("UNIT PRICE").DefaultCellStyle.Format = "N2"

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ' dgvProducts.Sort(dgvProducts.Columns("PRODUCT CODE"), SortOrder.Ascending)

        NewProductForm.ShowDialog()

    End Sub
    Private Sub dgvProducts_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvProducts.CellMouseDoubleClick
        If dgvProducts.Rows.Count > 0 Then
            EditProductForm.ShowDialog()
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Dim p As ProductsTable = New ProductsTable()
        p.loadDatagridProducts()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If dgvProducts.Rows.Count > 0 Then
            EditProductForm.ShowDialog()
        End If
    End Sub

    Private Sub btnChangePrice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePrice.Click
        If dgvProducts.Rows.Count > 0 Then
            ChangePriceForm.ShowDialog()
        End If

    End Sub

    Private Sub btnCategories_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCategories.Click
        ProductCategoriesForm.ShowDialog()
    End Sub

    
    Private Sub btnPriceChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPriceChanges.Click
        PriceChangesForm.ShowDialog()

    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim defaultName As String = "Products List"
        Export(dgvProducts, defaultName)
    End Sub
End Class