Imports System.Data
Imports System.Data.OleDb
Public Class SalesTable
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()

    Public Sub AddSales(ByVal productCode As String, ByVal salesDate As String, ByVal unitPrice As Double, ByVal quantity As Double, ByVal grossSales As Double, ByVal description As String, ByVal RefNumber As String)
        checkConnectionStatus()

        Dim monInt As Integer = Month(CType(salesDate, Date))
        Dim monName As String = MonthName(monInt)
        Dim yr As Integer = Year(CType(salesDate, Date))

        Dim sales, vat As Double
        Dim p As ProductsTable = New ProductsTable()
        If p.CheckProductVatable(productCode) Then
            sales = Val(grossSales) / 1.165 'VAT at 16.5%
        Else
            sales = Val(grossSales)
        End If

        vat = Val(grossSales) - sales

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "INSERT INTO sales ([product], [sales_date], [year], [month], [ref_number], [unit_price], [gross_sales], [vat], [sales], [quantity], [description], [entered_by], [date_entered]) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(productCode, String)))
        cmd.Parameters.Add(New OleDbParameter("sales_date", CType(salesDate, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(monName, String)))
        cmd.Parameters.Add(New OleDbParameter("ref_number", CType(RefNumber, String)))
        cmd.Parameters.Add(New OleDbParameter("unit_price", CType(unitPrice, String)))
        cmd.Parameters.Add(New OleDbParameter("gross_sales", CType(grossSales, String)))
        cmd.Parameters.Add(New OleDbParameter("vat", CType(vat, String)))
        cmd.Parameters.Add(New OleDbParameter("sales", CType(sales, String)))
        cmd.Parameters.Add(New OleDbParameter("quantity", CType(quantity, String)))
        cmd.Parameters.Add(New OleDbParameter("description", CType(description, String)))
        cmd.Parameters.Add(New OleDbParameter("entered_by", CType(UserTable.userId, String)))
        cmd.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub EditSales(ByVal productCode As String, ByVal salesDate As String, ByVal unitPrice As Double, ByVal quantity As Double, ByVal grossSales As Double, ByVal description As String, ByVal RefNumber As String, ByVal RefNumberCurrent As String)
        checkConnectionStatus()

        Dim monInt As Integer = Month(CType(salesDate, Date))
        Dim monName As String = MonthName(monInt)
        Dim yr As Integer = Year(CType(salesDate, Date))

        Dim sales, vat As Double
        Dim p As ProductsTable = New ProductsTable()
        If p.CheckProductVatable(productCode) Then
            sales = Val(grossSales) / 1.165 'VAT at 16.5%
        Else
            sales = Val(grossSales)
        End If

        vat = Val(grossSales) - sales

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE sales SET [sales_date]=?, [year]=?, [month]=?, [ref_number]=?, [unit_price]=?, [gross_sales]=?, [vat]=?, [sales]=?, [quantity]=?, [description]=?, [modified_by]=?, [date_modified]=? WHERE product=? AND ref_number=?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("sales_date", CType(salesDate, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(monName, String)))
        cmd.Parameters.Add(New OleDbParameter("ref_number", CType(RefNumber, String)))
        cmd.Parameters.Add(New OleDbParameter("unit_price", CType(unitPrice, String)))
        cmd.Parameters.Add(New OleDbParameter("gross_sales", CType(grossSales, String)))
        cmd.Parameters.Add(New OleDbParameter("vat", CType(vat, String)))
        cmd.Parameters.Add(New OleDbParameter("sales", CType(sales, String)))
        cmd.Parameters.Add(New OleDbParameter("quantity", CType(quantity, String)))
        cmd.Parameters.Add(New OleDbParameter("description", CType(description, String)))
        cmd.Parameters.Add(New OleDbParameter("modified_by", CType(UserTable.userId, String)))
        cmd.Parameters.Add(New OleDbParameter("date_modified", CType(Date.Now, String)))
        cmd.Parameters.Add(New OleDbParameter("product", CType(productCode, String)))
        cmd.Parameters.Add(New OleDbParameter("ref_number", CType(RefNumberCurrent, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub AddReturnsIn(ByVal productCode, ByVal damagesDate, ByVal quantity, ByVal cost, ByVal description)
        checkConnectionStatus()

        Dim monInt As Integer = Month(CType(damagesDate, Date))
        Dim monName As String = MonthName(monInt)
        Dim yr As Integer = Year(CType(damagesDate, Date))

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "INSERT INTO returns_in ([product], [returns_in_date], [year], [month], [quantity], [sales], [description], [entered_by], [date_entered]) values (?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(productCode, String)))
        cmd.Parameters.Add(New OleDbParameter("returns_in_date", CType(damagesDate, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(monName, String)))
        cmd.Parameters.Add(New OleDbParameter("quantity", CType(quantity, String)))
        cmd.Parameters.Add(New OleDbParameter("sales", CType(cost, String)))
        cmd.Parameters.Add(New OleDbParameter("description", CType(description, String)))
        cmd.Parameters.Add(New OleDbParameter("entered_by", CType(UserTable.userId, String)))
        cmd.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))

        Try
            cmd.ExecuteNonQuery()
            MsgBox("SAVED!!!")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub UpdateVoidedSales(ByVal recordID)
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE sales  SET void_status = ?  WHERE sales_id = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("void_status", CType("VOIDED", String)))
        cmd.Parameters.Add(New OleDbParameter("sales_id", CType(recordID, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub UpdateVoidedReturnsIn(ByVal recordID)
        checkConnectionStatus()


        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE returns_in  SET void_status = ?  WHERE returns_in_id = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("void_status", CType("VOIDED", String)))
        cmd.Parameters.Add(New OleDbParameter("returns_in_id", CType(recordID, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub

    Public Function GetLastUnitPriceByProductPerMonth(ByVal yr As String, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT TOP 1 [unit_price] FROM sales WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "' ORDER BY sales_date DESC", myConnection)
        da.Fill(ds, "sales")

        Dim unitPrice As Double

        If (ds.Tables("sales").Rows.Count > 0) Then
            unitPrice = ds.Tables("sales").Rows(0).Item("unit_price")  'The Unit Price
        Else
            unitPrice = 0
        End If
        Return unitPrice

        myConnection.Close()
    End Function
   
    Public Function GetTotalSalesQuantityByProduct(ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([quantity]) AS [total] FROM sales WHERE product = '" & productCode & "'", myConnection)
        da.Fill(ds, "total_sales")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("total_sales").Rows(0).Item("total"))) Then
            total = ds.Tables("total_sales").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function
    Public Function GetTotalSalesQuantityByProductPerMonth(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        'myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([quantity]) AS [total] FROM sales WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "total_sales")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("total_sales").Rows(0).Item("total"))) Then
            total = ds.Tables("total_sales").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        ' myConnection.Close()
    End Function

    Public Function GetTotalSalesValueByProductPerMonth(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([sales]) AS [total] FROM sales WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "total_sales")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("total_sales").Rows(0).Item("total"))) Then
            total = ds.Tables("total_sales").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function
    Public Function GetTotalVatByProductPerMonth(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([vat]) AS [total] FROM sales WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "total_vat")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("total_vat").Rows(0).Item("total"))) Then
            total = ds.Tables("total_vat").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function
    Public Function GetTotalSalesValueByProduct(ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([sales]) AS [total] FROM sales WHERE product = '" & productCode & "'", myConnection)
        da.Fill(ds, "total_sales")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("total_sales").Rows(0).Item("total"))) Then
            total = ds.Tables("total_sales").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function
    Public Function GetTotalReturnsInQuantityByProduct(ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([quantity]) AS [total] FROM returns_in WHERE product = '" & productCode & "'", myConnection)
        da.Fill(ds, "returns_in")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("returns_in").Rows(0).Item("total"))) Then
            total = ds.Tables("returns_in").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function
    Public Function GetReturnsInQuantityByProductPerMonth(ByVal yr As String, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        'myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([quantity]) AS [total]  FROM returns_in WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "returns_in")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("returns_in").Rows(0).Item("total"))) Then
            total = ds.Tables("returns_in").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        'myConnection.Close()

    End Function
    Public Function GetReturnsInValueByProductPerMonth(ByVal yr As String, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        'myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([sales]) AS [total]  FROM returns_in WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "returns_in")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("returns_in").Rows(0).Item("total"))) Then
            total = ds.Tables("returns_in").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        'myConnection.Close()

    End Function
    Public Function GetLatestUnitPriceByProduct(ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT TOP 1 [price] FROM product_price WHERE product = '" & productCode & "' ORDER BY product_price_id DESC", myConnection)
        da.Fill(ds, "product_price")

        Dim price As Double

        If (Not ds.Tables("product_price").Rows.Count = 0) Then
            price = ds.Tables("product_price").Rows(0).Item("price")
        Else
            price = 0
        End If
        Return price  'The Unit price

        myConnection.Close()
    End Function
    Public Sub loadDatagridSales(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String)

        SalesForm.txtUnitPrice.Text = GetLatestUnitPriceByProduct(productCode)

        SalesForm.txtAccumulatedQuantity.Text = Format(Me.GetTotalSalesQuantityByProduct(productCode), "fIXED") 'query accummulated quantity sold
        SalesForm.txtAccumulatedValue.Text = Format(Me.GetTotalSalesValueByProduct(productCode), "Standard") 'query accummulated quantity sold

        '===================CALCULATE STOCK AVAILABLE===================================
        Dim p As PurchasesTable = New PurchasesTable()
        Dim p2 As PurchasesTable = New PurchasesTable()

        Dim purchases As Double = p.GetTotalPurchasesByProduct(productCode)
        Dim damages As Double = p2.GetTotalDamagesByProduct(productCode)

        Dim sales As Double = Me.GetTotalSalesQuantityByProduct(productCode)

        Dim returnsOut As Double = p2.GetTotalReturnsOutQuantityByProduct(productCode)
        Dim returnsIn As Double = Me.GetTotalReturnsInQuantityByProduct(productCode)
        
        'SalesForm.txtStockAvailable.Text = Format((purchases + returnsIn - damages - returnsOut - sales), "Standard")
        '===================END CALCULATE STOCK AVAILABLE===================================

       checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()


        da = New OleDbDataAdapter("SELECT [sales_id] AS [ID], [sales_date] AS [SALES DATE], [quantity] AS [QUANTITY], [unit_price] AS [UNIT PRICE], [gross_sales] AS [GROSS SALES], [vat] AS [VAT], [sales] AS [NET SALES], [description] AS [DESCRIPTION], [entered_by] AS [ENTERED BY], [date_entered] AS [DATE ENTERED], [void_status] AS [VOID STATUS] FROM sales WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "sales")

        Dim view1 As New DataView(tables(0))
        source1.DataSource = view1
        SalesForm.dgvSales.DataSource = view1
        myConnection.Close()

        '===================================================================================
        'Calculate and display Totals
        Dim totalQty As Double = 0
        Dim totalSales As Double = 0
        Dim totalVat As Double = 0
        For i As Integer = 0 To SalesForm.dgvSales.RowCount - 1
            totalQty += SalesForm.dgvSales.Rows(i).Cells("QUANTITY").Value
            totalSales += SalesForm.dgvSales.Rows(i).Cells("NET SALES").Value
            totalVat += SalesForm.dgvSales.Rows(i).Cells("VAT").Value

        Next
        SalesForm.txtTotalQuantity.Text = Format(totalQty, "Fixed")
        SalesForm.txtTotalSales.Text = Format(totalSales, "Standard")
        SalesForm.txtTotalVat.Text = Format(totalVat, "Standard")
        '=======================================================================================
        SalesRecordsForm.dgvSales.Columns("ID").Visible = False

        PurchasesForm.Refresh()

    End Sub
    Public Sub loadDatagridReturnsIn(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String)
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT [returns_in_id] AS [ID], [returns_in_date] AS [RETURNS IN DATE], [quantity] AS [QUANTITY], [sales] AS [SALES], [description] AS [DESCRIPTION], [entered_by] AS [ENTERED BY], [date_entered] AS [DATE ENTERED], [void_status] AS [VOID STATUS] FROM returns_in WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "returns_in")
        Dim view1 As New DataView(tables(0))
        source1.DataSource = view1
        ReturnsInForm.dgvReturnsIn.DataSource = view1
        ReturnsInForm.Refresh()
        myConnection.Close()
    End Sub
    Private Sub checkConnectionStatus()
        If myConnection.State = ConnectionState.Open Then
            myConnection.Close()

        End If
    End Sub
   
End Class
