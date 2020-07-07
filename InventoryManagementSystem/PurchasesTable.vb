Imports System.Data
Imports System.Data.OleDb
Public Class PurchasesTable
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()

    Public Sub AddPurchases(ByVal productCode, ByVal purchaseDate, ByVal quantity, ByVal grossCost, ByVal description, ByVal GRN, ByVal supplier, ByVal InternalGRN, ByVal purchaseType, ByVal PaymentStatus, ByVal PaymentDue)
        checkConnectionStatus()

        Dim monInt As Integer = Month(CType(purchaseDate, Date))
        Dim monName As String = MonthName(monInt)
        Dim yr As Integer = Year(CType(purchaseDate, Date))

        Dim cost, vat As Double
        Dim p As ProductsTable = New ProductsTable()
        If p.CheckProductVatable(productCode) Then
            cost = Val(grossCost) / 1.165 'VAT at 16.5%
        Else
            cost = Val(grossCost)
        End If

        vat = Val(grossCost) - cost

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "INSERT INTO purchases ([product], [purchase_date], [year], [month], [quantity], [cost], [gross_cost], [vat], [description], [entered_by], [date_entered], [grn], [internal_grn], [supplied_by], [purchase_type], [payment_status], [payment_due], [unit_cost]) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        'str = "INSERT INTO purchases ([product], [purchase_date], [year], [month], [quantity], [cost], [gross_cost], [vat], [description], [entered_by], [date_entered], [grn], [internal_grn], [supplied_by]) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(productCode, String)))
        cmd.Parameters.Add(New OleDbParameter("purchase_date", CType(purchaseDate, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(monName, String)))
        cmd.Parameters.Add(New OleDbParameter("quantity", CType(quantity, String)))
        cmd.Parameters.Add(New OleDbParameter("cost", CType(cost, String)))
        cmd.Parameters.Add(New OleDbParameter("gross_cost", CType(grossCost, String)))
        cmd.Parameters.Add(New OleDbParameter("vat", CType(vat, String)))
        cmd.Parameters.Add(New OleDbParameter("description", CType(description, String)))
        cmd.Parameters.Add(New OleDbParameter("entered_by", CType(UserTable.userId, String)))
        cmd.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))
        cmd.Parameters.Add(New OleDbParameter("grn", CType(GRN, String)))
        cmd.Parameters.Add(New OleDbParameter("internal_grn", CType(InternalGRN, String)))
        cmd.Parameters.Add(New OleDbParameter("supplied_by", CType(supplier, String)))
        cmd.Parameters.Add(New OleDbParameter("purchase_type", CType(purchaseType, String)))
        cmd.Parameters.Add(New OleDbParameter("payment_status", CType(PaymentStatus, String)))
        cmd.Parameters.Add(New OleDbParameter("payment_due", CType(PaymentDue, String)))
        cmd.Parameters.Add(New OleDbParameter("unit_cost", CType(grossCost / quantity, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub AddCashPurchases(ByVal productCode, ByVal purchaseDate, ByVal quantity, ByVal grossCost, ByVal description, ByVal InternalGRN)
        checkConnectionStatus()

        Dim monInt As Integer = Month(CType(purchaseDate, Date))
        Dim monName As String = MonthName(monInt)
        Dim yr As Integer = Year(CType(purchaseDate, Date))

        Dim cost, vat As Double
        Dim p As ProductsTable = New ProductsTable()
        If p.CheckProductVatable(productCode) Then
            cost = Val(grossCost) / 1.165 'VAT at 16.5%
        Else
            cost = Val(grossCost)
        End If

        vat = Val(grossCost) - cost

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "INSERT INTO purchases ([product], [purchase_date], [year], [month], [quantity], [cost], [gross_cost], [vat], [description], [entered_by], [date_entered], [internal_grn], [purchase_type], [unit_cost]) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        'str = "INSERT INTO purchases ([product], [purchase_date], [year], [month], [quantity], [cost], [gross_cost], [vat], [description], [entered_by], [date_entered], [grn], [internal_grn], [supplied_by]) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(productCode, String)))
        cmd.Parameters.Add(New OleDbParameter("purchase_date", CType(purchaseDate, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(monName, String)))
        cmd.Parameters.Add(New OleDbParameter("quantity", CType(quantity, String)))
        cmd.Parameters.Add(New OleDbParameter("cost", CType(cost, String)))
        cmd.Parameters.Add(New OleDbParameter("gross_cost", CType(grossCost, String)))
        cmd.Parameters.Add(New OleDbParameter("vat", CType(vat, String)))
        cmd.Parameters.Add(New OleDbParameter("description", CType(description, String)))
        cmd.Parameters.Add(New OleDbParameter("entered_by", CType(UserTable.userId, String)))
        cmd.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))
        cmd.Parameters.Add(New OleDbParameter("internal_grn", CType(InternalGRN, String)))
        cmd.Parameters.Add(New OleDbParameter("purchase_type", CType("Cash", String)))
        cmd.Parameters.Add(New OleDbParameter("unit_cost", CType(grossCost / quantity, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub AddDamages(ByVal productCode, ByVal damagesDate, ByVal RefNumber, ByVal quantity, ByVal cost, ByVal description)
        checkConnectionStatus()

        Dim monInt As Integer = Month(CType(damagesDate, Date))
        Dim monName As String = MonthName(monInt)
        Dim yr As Integer = Year(CType(damagesDate, Date))

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "INSERT INTO damages ([product], [damages_date], [year], [month], [ref_number], [quantity], [cost], [unit_cost], [description], [entered_by], [date_entered]) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(productCode, String)))
        cmd.Parameters.Add(New OleDbParameter("damages_date", CType(damagesDate, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(monName, String)))
        cmd.Parameters.Add(New OleDbParameter("ref_number", CType(RefNumber, String)))
        cmd.Parameters.Add(New OleDbParameter("quantity", CType(quantity, String)))
        cmd.Parameters.Add(New OleDbParameter("cost", CType(cost, String)))
        cmd.Parameters.Add(New OleDbParameter("unit_cost", CType(cost / quantity, String)))
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
    Public Sub AddReturnsOut(ByVal productCode, ByVal returnsDate, ByVal quantity, ByVal cost, ByVal description)
        checkConnectionStatus()

        Dim monInt As Integer = Month(CType(returnsDate, Date))
        Dim monName As String = MonthName(monInt)
        Dim yr As Integer = Year(CType(returnsDate, Date))

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "INSERT INTO returns_out ([product], [returns_out_date], [year], [month], [quantity], [cost], [description], [vat], [entered_by], [date_entered]) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(productCode, String)))
        cmd.Parameters.Add(New OleDbParameter("returns_out_date", CType(returnsDate, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(monName, String)))
        cmd.Parameters.Add(New OleDbParameter("quantity", CType(quantity, String)))
        cmd.Parameters.Add(New OleDbParameter("cost", CType(cost, String)))
        cmd.Parameters.Add(New OleDbParameter("description", CType(description, String)))
        cmd.Parameters.Add(New OleDbParameter("vat", CType(0.165 * cost, String)))
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
    Public Sub UpdateVoidedPurchases(ByVal recordID)
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE purchases  SET void_status = ?  WHERE purchase_id = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("void_status", CType("VOIDED", String)))
        cmd.Parameters.Add(New OleDbParameter("purchase_id", CType(recordID, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub UpdateVoidedReturnsOut(ByVal recordID)
        checkConnectionStatus()


        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE returns_out  SET void_status = ?  WHERE returns_out_id = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("void_status", CType("VOIDED", String)))
        cmd.Parameters.Add(New OleDbParameter("returns_out_id", CType(recordID, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub

    Public Function GetLastUnitCostByProduct(ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT TOP 1 [quantity], [cost] FROM purchases WHERE product = '" & productCode & "'  AND status = 'ACTIVE' ORDER BY purchase_date DESC", myConnection)
        da.Fill(ds, "last_stock")

        Dim unitCost As Double

        If (ds.Tables("last_stock").Rows.Count > 0) Then
            unitCost = ds.Tables("last_stock").Rows(0).Item("cost") / ds.Tables("last_stock").Rows(0).Item("quantity") 'The Unit Cost
        Else
            unitCost = 0
        End If
        Return unitCost

        myConnection.Close()
    End Function
    Public Function GetLastUnitCostByProductPerMonth(ByVal yr As String, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT TOP 1 [quantity], [cost] FROM purchases WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'  AND status = 'ACTIVE' ORDER BY purchase_date DESC", myConnection)
        da.Fill(ds, "last_stock")

        Dim unitCost As Double

        If (ds.Tables("last_stock").Rows.Count > 0) Then
            unitCost = ds.Tables("last_stock").Rows(0).Item("cost") / ds.Tables("last_stock").Rows(0).Item("quantity") 'The Unit Cost
        Else
            unitCost = 0
        End If
        Return unitCost

        myConnection.Close()
    End Function
    Public Function GetTotalPurchasesByProduct(ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([quantity]) AS [total] FROM purchases WHERE product = '" & productCode & "'  AND status = 'ACTIVE'", myConnection)
        da.Fill(ds, "total_stock")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("total_stock").Rows(0).Item("total"))) Then
            total = ds.Tables("total_stock").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function
    Public Function GetTotalPurchasesQuantityByProductPerMonth(ByVal yr As String, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        'myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([quantity]) AS [total]  FROM purchases WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'  AND status = 'ACTIVE'", myConnection)
        da.Fill(ds, "total_stock")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("total_stock").Rows(0).Item("total"))) Then
            total = ds.Tables("total_stock").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        'myConnection.Close()

    End Function

    Public Function GetTotalPurchasesCostByProductPerMonth(ByVal yr As String, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([cost]) AS [total]  FROM purchases WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'  AND status = 'ACTIVE'", myConnection)
        da.Fill(ds, "total_stock")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("total_stock").Rows(0).Item("total"))) Then
            total = ds.Tables("total_stock").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()

    End Function
    Public Function GetTotalVatByProductPerMonth(ByVal yr As String, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([vat]) AS [total]  FROM purchases WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'  AND status = 'ACTIVE'", myConnection)
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
    Public Function GetTotalDamagesQuantityByProductPerMonth(ByVal yr As String, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([quantity]) AS [total]  FROM damages WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'  AND status = 'ACTIVE'", myConnection)
        da.Fill(ds, "total_damages")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("total_damages").Rows(0).Item("total"))) Then
            total = ds.Tables("total_damages").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function
    Public Function GetTotalDamagesCostByProductPerMonth(ByVal yr As String, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([cost]) AS [total]  FROM damages WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'  AND status = 'ACTIVE'", myConnection)
        da.Fill(ds, "total_damages")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("total_damages").Rows(0).Item("total"))) Then
            total = ds.Tables("total_damages").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function
    Public Function GetTotalDamagesByProduct(ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([quantity]) AS [total] FROM damages WHERE product = '" & productCode & "'  AND status = 'ACTIVE'", myConnection)
        da.Fill(ds, "total_damages")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("total_damages").Rows(0).Item("total"))) Then
            total = ds.Tables("total_damages").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function
    Public Function GetTotalReturnsOutQuantityByProduct(ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([quantity]) AS [total] FROM returns_out WHERE product = '" & productCode & "'", myConnection)
        da.Fill(ds, "returns_out")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("returns_out").Rows(0).Item("total"))) Then
            total = ds.Tables("returns_out").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

    End Function
    Public Function GetReturnsOutQuantityByProductPerMonth(ByVal yr As String, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        'myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM(ro.quantity) AS [total]  FROM returns_out ro INNER JOIN purchases p ON ro.purchase=p.purchase_id WHERE ro.year = " & yr & " AND ro.month = '" & mon & "' AND p.product = '" & productCode & "'", myConnection)
        da.Fill(ds, "returns_out")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("returns_out").Rows(0).Item("total"))) Then
            total = ds.Tables("returns_out").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        'myConnection.Close()

    End Function
    Public Function GetReturnsOutValueByProductPerMonth(ByVal yr As String, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        'myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([cost]) AS [total]  FROM returns_out WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "returns_out")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("returns_out").Rows(0).Item("total"))) Then
            total = ds.Tables("returns_out").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        'myConnection.Close()

    End Function
    Public Function GetCurrentBalance(ByVal supplier As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        'myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([gross_cost]) AS [total]  FROM purchases WHERE [supplied_by] = '" & supplier & "' AND payment_status = 'Not Paid' AND status = 'ACTIVE'", myConnection)
        da.Fill(ds, "purchases")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("purchases").Rows(0).Item("total"))) Then
            total = ds.Tables("purchases").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        'myConnection.Close()

    End Function
    Public Function GetReconciliationFigureByProductPerMonth(ByVal yr As String, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        'myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([quantity]) AS [total]  FROM reconciliation_figure WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "reconciliation_figure")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("reconciliation_figure").Rows(0).Item("total"))) Then
            total = ds.Tables("reconciliation_figure").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        'myConnection.Close()

    End Function
    Public Sub loadDatagridPurchases(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String, ByVal purchaseType As String)

        ' ''=======================================================================================

        ' ''===================CALCULATE STOCK AVAILABLE===================================
        'Dim s As SalesTable = New SalesTable()

        'Dim purchases As Double = Me.GetTotalPurchasesByProduct(productCode)
        'Dim damages As Double = Me.GetTotalDamagesByProduct(productCode)

        'Dim sales As Double = s.GetTotalSalesQuantityByProduct(productCode)

        'Dim returnsOut As Double = Me.GetTotalReturnsOutQuantityByProduct(productCode)
        'Dim returnsIn As Double = s.GetTotalReturnsInQuantityByProduct(productCode)

        ''PurchasesForm.txtAvailableStock.Text = Format((purchases + returnsIn - damages - returnsOut - sales), "Standard")
        ''===================END CALCULATE STOCK AVAILABLE===================================

        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        If purchaseType = "All" Then
            purchaseType = "%"
        End If

        If mon = "All Months" Then
            mon = "%"
        End If

        'da = New OleDbDataAdapter("SELECT [purchase_id] as [ID], [purchase_date] AS [PURCHASE DATE], [grn] AS [GRN], [internal_grn] AS [INTERNAL GRN], [quantity] AS [QUANTITY], [gross_cost] AS [GROSS COST], [unit_cost] AS [UNIT COST], [vat] AS [VAT], [cost] AS [NET COST], [description] AS [DESCRIPTION], [purchase_type] AS [PURCHASE TYPE], [supplied_by] AS [SUPPLIER], [payment_due] AS [PAYMENT DATE], [payment_status] AS [PAYMENT STATUS], [payment_receipt_number] AS [PAYMENT RECEIPT], [date_paid] AS [DATE PAID], [entered_by] AS [ENTERED BY], [date_entered] AS [DATE ENTERED], [void_status] AS [VOID STATUS] FROM purchases WHERE [year] = " & yr & " AND [month] LIKE '" & mon & "' AND product = '" & productCode & "' AND purchase_type LIKE '" & purchaseType & "'", myConnection)
        da = New OleDbDataAdapter("SELECT p.name AS [PRODUCT NAME], p.product_code AS [PRODUCT CODE], p.plu_code AS [PLU CODE], pc.purchase_id AS [ID], pc.purchase_date AS [PURCHASE DATE], pc.grn AS [GRN], pc.internal_grn AS [INTERNAL GRN], pc.quantity AS [QUANTITY], pc.gross_cost AS [GROSS COST], pc.unit_cost AS [UNIT COST], pc.vat AS [VAT], pc.cost AS [NET COST], pc.description AS [DESCRIPTION], pc.purchase_type AS [PURCHASE TYPE], pc.supplied_by AS [SUPPLIER], pc.payment_due AS [PAYMENT DATE], pc.payment_status AS [PAYMENT STATUS], pc.payment_receipt_number AS [PAYMENT RECEIPT], pc.date_paid AS [DATE PAID], pc.entered_by AS [ENTERED BY], pc.date_entered AS [DATE ENTERED] FROM purchases pc INNER JOIN product p ON pc.product=p.product_code WHERE pc.year = " & yr & " AND pc.month LIKE '" & mon & "' AND pc.product LIKE '" & productCode & "' AND pc.purchase_type LIKE '" & purchaseType & "' AND pc.status = 'ACTIVE'", myConnection)
        da.Fill(ds, "purchases")

        'tables(0).Columns.Add("UNIT COST").Expression = "[NET COST]/QUANTITY"
        'Dim qty As Decimal = tables(0).
        Dim view1 As New DataView(tables(0))
        source1.DataSource = view1
        PurchasesForm.dgvPurchases.DataSource = view1
        'PurchasesForm.dgvPurchases
        myConnection.Close()



        '===================================================================================
        'Calculate and display Totals
        Dim totalQty As Double = 0
        Dim totalCost As Double = 0
        Dim totalVat As Double = 0
        Dim totalNetCost As Double = 0
        For i As Integer = 0 To PurchasesForm.dgvPurchases.RowCount - 1
            totalQty += PurchasesForm.dgvPurchases.Rows(i).Cells("QUANTITY").Value
            totalCost += PurchasesForm.dgvPurchases.Rows(i).Cells("GROSS COST").Value
            totalVat += PurchasesForm.dgvPurchases.Rows(i).Cells("VAT").Value
            totalNetCost += PurchasesForm.dgvPurchases.Rows(i).Cells("NET COST").Value
        Next
        If productCode = "%" Then
            PurchasesForm.txtTotalQuantity.Text = "------"
        Else
            PurchasesForm.txtTotalQuantity.Text = Format(totalQty, "Fixed")
        End If

        PurchasesForm.txtTotalCost.Text = Format(totalCost, "Standard")
        PurchasesForm.txtTotalVat.Text = Format(totalVat, "Standard")
        PurchasesForm.txtTotalNet.Text = Format(totalNetCost, "Standard")

        PurchasesForm.dgvPurchases.Columns("ID").Visible = False

        PurchasesForm.Refresh()

    End Sub
    Public Sub loadDatagridDamages(ByVal yr As Integer, ByVal mon As String, ByVal product As String)
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT d.damages_id AS [ID], d.damages_date AS [DAMAGES DATE], p.name AS [PRODUCT], d.ref_number AS [REF NUMBER], d.quantity AS [QUANTITY], d.unit_cost AS [UNIT COST], d.cost AS [COST], d.description AS [DESCRIPTION], d.entered_by AS [ENTERED BY], d.date_entered AS [DATE ENTERED] FROM damages d INNER JOIN product p ON p.product_code=d.product WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND p.product_code LIKE  '" & product & "' AND d.status = 'ACTIVE'", myConnection)
        da.Fill(ds, "damages")
        Dim view1 As New DataView(ds.Tables(0))
        source1.DataSource = view1
        DamagesForm.dgvDamages.DataSource = view1
        DamagesForm.dgvDamages.Columns(0).Visible = False
        myConnection.Close()


        Dim totalCost As Double = 0
        For i As Integer = 0 To DamagesForm.dgvDamages.RowCount - 1
            totalCost += DamagesForm.dgvDamages.Rows(i).Cells("COST").Value
        Next


        DamagesForm.txtTotalCost.Text = Format(totalCost, "Standard")
    End Sub
    Public Sub loadDatagridReturnsOut(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String)
        'checkConnectionStatus()

        'Dim dbCon As DbConnection = New DbConnection()
        'myConnection.ConnectionString = dbCon.dbConnector()
        'myConnection.Open()
        'ds.Reset()

        'da = New OleDbDataAdapter("SELECT [returns_out_id] AS [ID], [returns_out_date] AS [RETURNS OUT DATE], [quantity] AS [QUANTITY], [cost] AS [NET COST], [vat] AS [VAT], [description] AS [DESCRIPTION], [entered_by] AS [ENTERED BY], [date_entered] AS [DATE ENTERED], [void_status] AS [VOID STATUS] FROM returns_out WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)

        'da.Fill(ds, "returns_out")
        'Dim view1 As New DataView(tables(0))
        'source1.DataSource = view1
        ''ReturnsOutForm.dgvReturnsOut.DataSource = view1
        'ReturnsOutForm.Refresh()
        'myConnection.Close()
    End Sub
    Private Sub checkConnectionStatus()
        If myConnection.State = ConnectionState.Open Then
            myConnection.Close()

        End If
    End Sub
End Class
