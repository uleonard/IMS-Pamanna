Public Class EditProductCategoryForm

    Private Sub EditProductCategoryForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub EditProductCategoryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtOldName.Text = ProductCategoriesForm.dgvProductCategories.Rows(ProductCategoriesForm.dgvProductCategories.CurrentCell.RowIndex).Cells(0).Value.ToString
        txtDescription.Text = ProductCategoriesForm.dgvProductCategories.Rows(ProductCategoriesForm.dgvProductCategories.CurrentCell.RowIndex).Cells(1).Value.ToString
        txtName.Text = txtOldName.Text

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim p As ProductsTable = New ProductsTable()
        p.EditCategory(txtOldName.Text, txtName.Text, txtDescription.Text)

        ProductCategoriesForm.dgvProductCategories.Rows(ProductCategoriesForm.dgvProductCategories.CurrentCell.RowIndex).Cells(0).Value = txtName.Text
        ProductCategoriesForm.dgvProductCategories.Rows(ProductCategoriesForm.dgvProductCategories.CurrentCell.RowIndex).Cells(1).Value = txtDescription.Text
        Me.Dispose()
    End Sub
   
End Class