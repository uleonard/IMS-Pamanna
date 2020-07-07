Imports System.Data
Imports System.Data.OleDb
Public Class EditProductForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter

    Private Sub EditProductForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub frmEditProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [name] FROM [product_category]", myConnection)
        da.Fill(ds, "category")

        For i = 0 To ds.Tables("category").Rows.Count - 1

            comProductCategory.Items.Add(ds.Tables("category").Rows(i).Item(0))
        Next


        myConnection.Close()

        txtProductID.Text = ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(0).Value
        txtPLUCode.Text = ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(1).Value.ToString
        txtProductName.Text = ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(2).Value.ToString
        comProductCategory.Text = ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(4).Value.ToString
        txtProductDescription.Text = ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(6).Value.ToString


        If ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(5).Value = "Yes" Then
            radYes.Checked = True
        Else
            radNo.Checked = True

        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim p As ProductsTable = New ProductsTable()
        p.editProduct()

        Dim vatable As String
        If radNo.Checked Then
            vatable = "No"
        Else
            vatable = "Yes"
        End If

        ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(1).Value = txtPLUCode.Text
        ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(2).Value = txtProductName.Text
        ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(4).Value = comProductCategory.Text
        ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(5).Value = vatable
        ProductsForm.dgvProducts.Rows(ProductsForm.dgvProducts.CurrentCell.RowIndex).Cells(6).Value = txtProductDescription.Text

        Me.Close()

        
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()

    End Sub
End Class