Public Class NewProductCategoryForm

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()
    End Sub

    Private Sub NewProductCategoryForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub NewProductCategoryForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtName.Text = "" Then
            MsgBox("Category name cannot be empty")
            Exit Sub
        End If
        Dim p As ProductsTable = New ProductsTable()
        p.AddCategory(txtName.Text, txtDescription.Text)
        Me.Dispose()
        ProductCategoriesForm.loadDatagridCategories()
    End Sub
    
End Class