Imports System.Data
Imports System.Data.OleDb
Public Class ProductsTable
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()

    Public Sub AddProduct()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim vatable As String
        If NewProductForm.radNo.Checked = True Then
            vatable = "No"
        Else
            vatable = "Yes"
        End If

        Dim str As String
        str = "INSERT INTO product ([product_code], [plu_code], [name], [unit_price], [category], [vatable], [description], [entered_by], [date_entered]) values (?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)

        cmd.Parameters.Add(New OleDbParameter("product_code", CType(NewProductForm.txtProductID.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("plu_code", CType(NewProductForm.txtPLUCode.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("name", CType(NewProductForm.txtProductName.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("unit_price", CType(NewProductForm.txtProductUnitPrice.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("category", CType(NewProductForm.comProductCategory.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("vatable", CType(vatable, String)))
        cmd.Parameters.Add(New OleDbParameter("description", CType(NewProductForm.txtProductDescription.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("enetred_by", CType(UserTable.userId, String)))
        cmd.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()


    End Sub
    Public Sub editProduct()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim vatable As String
        If EditProductForm.radNo.Checked = True Then
            vatable = "No"
        Else
            vatable = "Yes"
        End If

        Dim str As String
        str = "UPDATE product SET [name] = ?, [plu_code] = ?, [category] = ?, [vatable] = ?, [description] = ? WHERE [product_code] = '" & Trim(EditProductForm.txtProductID.Text) & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("name", CType(EditProductForm.txtProductName.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("plu", CType(EditProductForm.txtPLUCode.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("category", CType(EditProductForm.comProductCategory.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("vatable", CType(vatable, String)))
        cmd.Parameters.Add(New OleDbParameter("description", CType(EditProductForm.txtProductDescription.Text, String)))


        Try
            cmd.ExecuteNonQuery()
            MessageBox.Show("Product Changes Saved!!!")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub AddPrice(ByVal productID As String, ByVal price As String)
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String

        str = "INSERT INTO product_price ([product], [price], [entered_by], [date_entered], [year], [month]) values (?, ?, ?, ?, ?, ?)"
        Dim cmd2 As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd2.Parameters.Add(New OleDbParameter("product", CType(productID, String)))
        cmd2.Parameters.Add(New OleDbParameter("price", CType(price, String)))
        cmd2.Parameters.Add(New OleDbParameter("enetred_by", CType(UserTable.userId, String)))
        cmd2.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))
        cmd2.Parameters.Add(New OleDbParameter("year", CType(Year(Date.Now), String)))
        cmd2.Parameters.Add(New OleDbParameter("month", CType(MonthName(Month(Date.Now)), String))) ' To have a month as January, February etc

        Try

            cmd2.ExecuteNonQuery()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub UpdatePrice(ByVal productID As String, ByVal price As String)
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE product SET [unit_price] = ? WHERE [product_code] = '" & Trim(productID) & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("unit_price", CType(price, String)))

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub AddCategory(ByVal name As String, ByVal description As String)
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String

        str = "INSERT INTO product_category ([name], [description]) values (?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("name", CType(name, String)))
        cmd.Parameters.Add(New OleDbParameter("description", CType(description, String)))

        Try

            cmd.ExecuteNonQuery()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub EditCategory(ByVal OldName As String, ByVal name As String, ByVal description As String)
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String

        str = "UPDATE product_category SET [name] = ?, [description] = ? WHERE [name] = '" & OldName & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("name", CType(name, String)))
        cmd.Parameters.Add(New OleDbParameter("description", CType(description, String)))


        Try

            cmd.ExecuteNonQuery()


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Function CheckProductVatable(ByVal productCode As String) As Boolean
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT [vatable] FROM product WHERE product_code = '" & productCode & "'", myConnection)
        da.Fill(ds, "product")

        Dim vatable As Boolean
        If tables(0).Rows(0).Item(0) = "Yes" Then
            vatable = True
        Else
            vatable = False
        End If
        myConnection.Close()

        Return vatable
    End Function
    Public Sub loadDatagridProducts()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT [product_code] AS [PRODUCT CODE], [plu_code] AS [PLU CODE], product.[name] AS [PRODUCT NAME],  [unit_price] AS [UNIT PRICE], product_category.[name] AS [CATEGORY], [vatable] AS [TAXABLE], product.[description] AS [DESCRIPTION], [entered_by] AS [ENTERED BY] FROM product,product_category WHERE product.category=product_category.name ORDER BY [product_code]", myConnection)
        da.Fill(ds, "product")
        Dim view1 As New DataView(tables(0))
        source1.DataSource = view1
        ProductsForm.dgvProducts.DataSource = view1
        ProductsForm.Refresh()

        
        myConnection.Close()
    End Sub
    Private Sub checkConnectionStatus()
        If myConnection.State = ConnectionState.Open Then
            myConnection.Close()

        End If
    End Sub
End Class
