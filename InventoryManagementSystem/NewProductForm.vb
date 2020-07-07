Imports System.Data
Imports System.Data.OleDb


Public Class NewProductForm
    Dim connString As String
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtProductName.Text = "" Then
            MsgBox("Product Name cannot be empty")
            Exit Sub
        End If
        If Not Val(txtProductUnitPrice.Text) > 0 Then
            MsgBox("Unit Price cannot be empty or zero")
            Exit Sub
        End If
        If Not comProductCategory.Items.Count > 0 Then
            MsgBox("Product Category cannot be empty. Add categories first.")
            Exit Sub
        End If
        Dim p As ProductsTable = New ProductsTable()

        p.AddProduct()
        p.AddPrice(txtProductID.Text, txtProductUnitPrice.Text)

        MessageBox.Show("Product Saved!!!")
        txtProductName.Text = ""
        txtProductUnitPrice.Text = ""
        txtProductDescription.Text = ""
        txtPLUCode.Text = ""
        comProductCategory.SelectedIndex = 0
        txtPLUCode.Focus()



        productIdGenerator(txtProductID.Text)

        'SHOW A PRODUCT ADDED IN THE PRODUCT MAIN WINDOW
        Dim p2 As ProductsTable = New ProductsTable()
        p2.loadDatagridProducts()
    End Sub

    Private Sub NewProductForm_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        ' Me.Dispose()
    End Sub


    Private Sub frmNewProduct_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim lastRow As Integer = ProductsForm.dgvProducts.RowCount - 1

        Dim productID As String
        If (ProductsForm.dgvProducts.RowCount > 0) Then
            productID = ProductsForm.dgvProducts.Rows(lastRow).Cells(0).Value
            productIdGenerator(productID)
        Else
            txtProductID.Text = "P0001"
        End If

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Clear()

        da = New OleDbDataAdapter("SELECT [name] FROM [product_category]", myConnection)
        da.Fill(ds, "category")

        comProductCategory.Items.Clear()

        For i = 0 To ds.Tables("category").Rows.Count - 1

            comProductCategory.Items.Add(ds.Tables("category").Rows(i).Item(0))
        Next
        If ds.Tables("category").Rows.Count > 0 Then
            comProductCategory.SelectedIndex = 0
        End If
        myConnection.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub
    Private Sub productIdGenerator(ByVal productID As String)
        Dim productIdNumeric As Integer

        productIdNumeric = Val(Mid(productID, 2, 4)) + 1
        ' MsgBox(productIdNumeric)

        If productIdNumeric < 10 Then
            txtProductID.Text = "P000" & productIdNumeric
        ElseIf productIdNumeric < 100 Then
            txtProductID.Text = "P00" & productIdNumeric
        ElseIf productIdNumeric < 1000 Then
            txtProductID.Text = "P0" & productIdNumeric
        Else
            txtProductID.Text = "P" & productIdNumeric
        End If
    End Sub

    
End Class