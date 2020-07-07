Imports System.Data
Imports System.Data.OleDb
Public Class StockMonthlySummaryTable
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()

    Public Sub addStockTaking(ByVal productCode As String, ByVal yr As String, ByVal mon As String, ByVal qty As Double)
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "INSERT INTO stock_taking ([product], [year], [month], [quantity], [entered_by], [date_entered]) values (?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(productCode, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(mon, String)))
        cmd.Parameters.Add(New OleDbParameter("quantity", CType(qty, String)))
        cmd.Parameters.Add(New OleDbParameter("entered_by", CType(UserTable.userId, String)))
        cmd.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub UpdateStockTaking(ByVal yr As String, ByVal mon As String, ByVal qty As Double, ByVal StockTakingID As Integer)
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE stock_taking SET  [quantity] = ?, [year] = ?, [month] = ?, [modified_by] = ?, [date_modified] = ? WHERE stock_taking_id =? "
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("quantity", CType(qty, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(mon, String)))
        cmd.Parameters.Add(New OleDbParameter("modified_by", CType(UserTable.userId, String)))
        cmd.Parameters.Add(New OleDbParameter("date_modified", CType(Date.Now, String)))
        cmd.Parameters.Add(New OleDbParameter("stock_taking_id", CType(StockTakingID, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub addSummary(ByVal productCode, ByVal yr, ByVal mon, ByVal stockBDQuantity, ByVal stockBDCost, ByVal salesBDQuantity, ByVal salesBD, ByVal stockReceived, ByVal stockCost, ByVal purchasesVat, ByVal stockDamaged, ByVal damagesCost, ByVal stockSold, ByVal stockSalesValue, ByVal salesVat, ByVal closingStockUnitCost, ByVal returnsOut, ByVal returnsOutValue, ByVal returnsIn, ByVal returnsInValue)

        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "INSERT INTO stock_monthly_summary ([product], [year], [month], [purchases_bf_quantity], [purchases_bf_cost], [sales_bf_quantity], [sales_bf], [purchases_quantity], [purchases_cost], [purchases_vat], [sales_quantity], [sales], [sales_vat], [damages_quantity], [damages_cost], [closing_stock_unit_cost], [entered_by], [date_entered], [returns_out_quantity], [returns_out_cost], [returns_in_quantity], [returns_in_sales]) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(productCode, String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(mon, String)))

        cmd.Parameters.Add(New OleDbParameter("purchases_bf_quantity", CType(stockBDQuantity, String)))
        cmd.Parameters.Add(New OleDbParameter("purchases_bf_cost", CType(stockBDCost, String)))
        cmd.Parameters.Add(New OleDbParameter("sales_bf_quantity", CType(salesBDQuantity, String)))
        cmd.Parameters.Add(New OleDbParameter("sales_bf", CType(salesBD, String)))

        cmd.Parameters.Add(New OleDbParameter("purchases_quantity", CType(stockReceived, String)))
        cmd.Parameters.Add(New OleDbParameter("purchases_cost", CType(stockCost, String)))
        cmd.Parameters.Add(New OleDbParameter("purchases_vat", CType(purchasesVat, String)))
        cmd.Parameters.Add(New OleDbParameter("sales_quantity", CType(stockSold, String)))
        cmd.Parameters.Add(New OleDbParameter("sales", CType(stockSalesValue, String)))
        cmd.Parameters.Add(New OleDbParameter("sales_vat", CType(salesVat, String)))
        cmd.Parameters.Add(New OleDbParameter("damages_quantity", CType(stockDamaged, String)))
        cmd.Parameters.Add(New OleDbParameter("damages_cost", CType(damagesCost, String)))
        cmd.Parameters.Add(New OleDbParameter("closing_stock_unit_cost", CType(closingStockUnitCost, String)))

        cmd.Parameters.Add(New OleDbParameter("entered_by", CType(UserTable.userId, String)))
        cmd.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))
        cmd.Parameters.Add(New OleDbParameter("returns_out_quantity", CType(returnsOut, String)))
        cmd.Parameters.Add(New OleDbParameter("returns_out_cost", CType(returnsOutValue, String)))
        cmd.Parameters.Add(New OleDbParameter("returns_in_quantity", CType(returnsIn, String)))
        cmd.Parameters.Add(New OleDbParameter("returns_in_sales", CType(returnsInValue, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()

    End Sub

    Public Sub DeleteSummaryPerMonth(ByVal yr As Integer, ByVal mon As String)
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        Dim str As String = "DELETE FROM stock_monthly_summary WHERE [year] = " & yr & " AND [month] = '" & mon & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        myConnection.Close()
    End Sub
    Public Sub MarkStockTakingReconciled(ByVal yr As String, ByVal mon As String)
        checkConnectionStatus()

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE stock_taking SET  [rc_status] = ? WHERE year =? AND month = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("rc_status", CType("Reconciled", String)))
        cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(mon, String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub

    Public Function GetStockTakingFigureByProductPerMonth(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT SUM([quantity]) AS [total] FROM stock_taking WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "stock_taking")

        Dim total As Double

        If (Not IsDBNull(ds.Tables("stock_taking").Rows(0).Item("total"))) Then
            total = ds.Tables("stock_taking").Rows(0).Item("total")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function

    '=====BALANCES BROUGHT FORWARD==================

    Public Function GetBalanceBroughtFowardPurchasesQuantityByProduct(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT [purchases_bf_quantity], [purchases_quantity], [sales_quantity], [damages_quantity] FROM stock_monthly_summary WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "stock_monthly_summary")

        tables(0).Columns.Add("balance_bf_quantity").Expression = "purchases_bf_quantity + purchases_quantity - damages_quantity - sales_quantity"

        Dim total As Double

        If ds.Tables("stock_monthly_summary").Rows.Count > 0 Then
            total = ds.Tables("stock_monthly_summary").Rows(0).Item("balance_bf_quantity")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function
    Public Function GetBalanceBroughtFowardPurchasesCostByProduct(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT [purchases_bf_cost], [purchases_cost] FROM stock_monthly_summary WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "stock_monthly_summary")

        tables(0).Columns.Add("balance_bf_cost").Expression = "purchases_bf_cost + purchases_cost "

        Dim total As Double

        If ds.Tables("stock_monthly_summary").Rows.Count > 0 Then
            total = ds.Tables("stock_monthly_summary").Rows(0).Item("balance_bf_cost")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function
    Public Function GetBalanceBroughtFowardSalesQuantityByProduct(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT [sales_bf_quantity], [sales_quantity] FROM stock_monthly_summary WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "stock_monthly_summary")

        tables(0).Columns.Add("balance_bf_sales").Expression = "sales_bf_quantity + sales_quantity "

        Dim total As Double

        If ds.Tables("stock_monthly_summary").Rows.Count > 0 Then
            total = ds.Tables("stock_monthly_summary").Rows(0).Item("balance_bf_sales")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function
    Public Function GetBalanceBroughtFowardSalesByProduct(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String) As Double
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT [sales_bf], [sales] FROM stock_monthly_summary WHERE [year] = " & yr & " AND [month] = '" & mon & "' AND product = '" & productCode & "'", myConnection)
        da.Fill(ds, "stock_monthly_summary")

        tables(0).Columns.Add("balance_bf_sales").Expression = "sales_bf + sales "

        Dim total As Double

        If ds.Tables("stock_monthly_summary").Rows.Count > 0 Then
            total = ds.Tables("stock_monthly_summary").Rows(0).Item("balance_bf_sales")
        Else
            total = 0
        End If
        Return total

        myConnection.Close()
    End Function

    '======END BALANCE BROUGHT FORWARD====================


    Public Sub FillData(ByVal yr As Integer, ByVal mon As String, ByVal productCode As String)

        checkConnectionStatus()

        Dim p As PurchasesTable = New PurchasesTable()
        MonthEndForm.txtStockReceived.Text = p.GetTotalPurchasesQuantityByProductPerMonth(yr, mon, productCode)

        MonthEndForm.txtStockTaking.Text = Me.GetStockTakingFigureByProductPerMonth(yr, mon, productCode)
        Dim s As SalesTable = New SalesTable()
        MonthEndForm.txtStockSold.Text = s.GetTotalSalesQuantityByProductPerMonth(yr, mon, productCode)
        MonthEndForm.txtReturnsIn.Text = s.GetReturnsInQuantityByProductPerMonth(yr, mon, productCode)

        Dim p2 As PurchasesTable = New PurchasesTable()
        MonthEndForm.txtStockDamaged.Text = p2.GetTotalDamagesQuantityByProductPerMonth(yr, mon, productCode)

        MonthEndForm.txtReturnsOut.Text = p2.GetReturnsOutQuantityByProductPerMonth(yr, mon, productCode)


        'GO BACK BY ONE MONTH TO GET BALANCE BROUGHT FORWARD FROM BALANCE CARRIAGE FOREARD
        Dim monthNum As Integer = getMonthNumber(mon)
        If (monthNum = 1) Then
            monthNum = 12
            yr = yr - 1
        Else
            monthNum = monthNum - 1
        End If
        mon = getMonthName(monthNum) 'Get String representation of the month e.g January for 1
        'ALL OTHER FUNCTION CALLS THAT USE MONTH AND YEAR FOR THE CURRENT PERIOD SHOULD BE BEFORE IF CONSTRUCT

        MonthEndForm.txtBalanceBD.Text = Me.GetBalanceBroughtFowardPurchasesQuantityByProduct(yr, mon, productCode)

        MonthEndForm.txtNetStock.Text = Format((Val(MonthEndForm.txtBalanceBD.Text) + Val(MonthEndForm.txtStockReceived.Text) + Val(MonthEndForm.txtReturnsIn.Text)) - (Val(MonthEndForm.txtStockSold.Text) + Val(MonthEndForm.txtReturnsOut.Text) + Val(MonthEndForm.txtStockDamaged.Text)), "Fixed")
        MonthEndForm.txtBalance.Text = Val(MonthEndForm.txtNetStock.Text) - Val(MonthEndForm.txtStockTaking.Text)

        If (Val(MonthEndForm.txtStockTaking.Text) > 0) Then
            MonthEndForm.btnAdd.Visible = False
            MonthEndForm.txtStockTaking.Enabled = False

        Else
            MonthEndForm.btnAdd.Visible = True
            MonthEndForm.txtStockTaking.Enabled = True
        End If
        If Val(MonthEndForm.txtBalance.Text) <= 0 Then
            MonthEndForm.btnReconcile.Enabled = False
            MonthEndForm.btnReconciliationNotes.Enabled = False
        Else
            MonthEndForm.btnReconcile.Enabled = True
            MonthEndForm.btnReconciliationNotes.Enabled = True
        End If

    End Sub
    Public Sub LoadMonthlySummaries(ByVal yr As Integer, ByVal mon As String)
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT [product] AS [PRODUCT], [name] AS [NAME], [purchases_bf_quantity] AS [PURCHASES BF QTY], [purchases_bf_cost] AS [PURCHASES BF COST], [sales_bf_quantity] AS [SALES BF QTY], [sales_bf] AS [SALES BF], " & _
                                  "[purchases_quantity] AS [PURCHASES QTY], [purchases_cost] AS [PURCHASES COST], [purchases_vat] AS [PURCHASES VAT], [sales_quantity] AS [SALES QTY], [sales] AS [SALES], [sales_vat] AS [SALES VAT], [damages_quantity] AS [DAMAGES QTY], [damages_cost] AS [DAMAGES COST]," & _
                                  " [returns_out_quantity] AS [RETURNS OUT QTY], [returns_out_cost] AS [RETURNS OUT COST],[returns_in_quantity] AS [RETURNS IN QTY],[returns_in_sales] AS [RETURNS IN SALES], " & _
                                  " [closing_stock_unit_cost] AS [CLOSING STOCK UNIT COST] " & _
                                  "FROM stock_monthly_summary INNER JOIN product ON stock_monthly_summary.product=product.product_code " & _
                                  "WHERE [year] = " & yr & " AND [month] = '" & mon & "'", myConnection)
        da.Fill(ds, "stock_monthly_summary")

        tables(0).Columns.Add("PURCHASES BD QTY").Expression = "[PURCHASES BF QTY] + [PURCHASES QTY] - [RETURNS OUT QTY] - [DAMAGES QTY] - [SALES QTY] + [RETURNS IN QTY]"
        tables(0).Columns.Add("PURCHASES BD COST").Expression = "([PURCHASES BF QTY] + [PURCHASES QTY] -[RETURNS OUT QTY] - [DAMAGES QTY] - [SALES QTY] + [RETURNS IN QTY])*[CLOSING STOCK UNIT COST] "
        tables(0).Columns.Add("STOCK FOR THE MONTH").Expression = "[PURCHASES BF QTY]+[PURCHASES QTY] - [RETURNS OUT QTY] - ([PURCHASES BF QTY] + [PURCHASES QTY] - [RETURNS OUT QTY] - [DAMAGES QTY] - [SALES QTY] + [RETURNS IN QTY])"
        tables(0).Columns.Add("COST FOR THE MONTH").Expression = "[PURCHASES BF COST]+[PURCHASES COST] -[RETURNS OUT COST] - ([PURCHASES BF QTY] + [PURCHASES QTY] -[RETURNS OUT QTY] - [DAMAGES QTY] - [SALES QTY] + [RETURNS IN QTY])*[CLOSING STOCK UNIT COST]"
        tables(0).Columns.Add("PROFIT").Expression = "[SALES]-([PURCHASES BF COST]+[PURCHASES COST] -[RETURNS OUT COST] - ([PURCHASES BF QTY] + [PURCHASES QTY] -[RETURNS OUT QTY] - [DAMAGES QTY] - [SALES QTY] + [RETURNS IN QTY])*[CLOSING STOCK UNIT COST])"


        Dim view1 As New DataView(tables(0))
        source1.DataSource = view1

        MonthlySummariesForm.dgvMonthlySummaries.DataSource = view1
        MonthlySummariesForm.Refresh()

        myConnection.Close()

        '===================================================================================
        'Calculate and display Totals
        Dim totalSales As Double = 0
        Dim totalCost As Double = 0
        Dim totalSalesVat As Double = 0
        Dim totalPurchasesVat As Double = 0
        Dim totalDamages As Double = 0

        For i As Integer = 0 To MonthlySummariesForm.dgvMonthlySummaries.RowCount - 1
            totalSales += MonthlySummariesForm.dgvMonthlySummaries.Rows(i).Cells("SALES").Value
            totalCost += MonthlySummariesForm.dgvMonthlySummaries.Rows(i).Cells("COST FOR THE MONTH").Value
            totalSalesVat += MonthlySummariesForm.dgvMonthlySummaries.Rows(i).Cells("SALES VAT").Value
            totalPurchasesVat += MonthlySummariesForm.dgvMonthlySummaries.Rows(i).Cells("PURCHASES VAT").Value
            totalDamages += MonthlySummariesForm.dgvMonthlySummaries.Rows(i).Cells("DAMAGES COST").Value


        Next
        MonthlySummariesForm.txtTotalSales.Text = Format(totalSales, "Standard")
        MonthlySummariesForm.txtTotalCost.Text = Format(totalCost, "Standard")
        MonthlySummariesForm.txtProfit.Text = Format(totalSales - totalCost, "Standard")

        MonthlySummariesForm.txtSalesVat.Text = Format(totalSalesVat, "Standard")
        MonthlySummariesForm.txtPurchasesVat.Text = Format(totalPurchasesVat, "Standard")
        MonthlySummariesForm.txtDamages.Text = Format(totalDamages, "Standard")
        '=======================================================================================

        MonthlySummariesForm.dgvMonthlySummaries.Columns("PURCHASES BD QTY").DefaultCellStyle.Format = "N2"
        MonthlySummariesForm.dgvMonthlySummaries.Columns("PURCHASES BD COST").DefaultCellStyle.Format = "N2"
        MonthlySummariesForm.dgvMonthlySummaries.Columns("STOCK FOR THE MONTH").DefaultCellStyle.Format = "N2"
        MonthlySummariesForm.dgvMonthlySummaries.Columns("COST FOR THE MONTH").DefaultCellStyle.Format = "N2"
        MonthlySummariesForm.dgvMonthlySummaries.Columns("PROFIT").DefaultCellStyle.Format = "N2"

    End Sub
    Public Sub LoadAnalysisReport(ByVal yr As String, ByVal productCode As String)
        checkConnectionStatus()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT [month] AS [MONTH], [purchases_bf_quantity] AS [PURCHASES BF QTY], [purchases_bf_cost] AS [PURCHASES BF COST], [sales_bf_quantity] AS [SALES BF QTY], [sales_bf] AS [SALES BF], " & _
                                  "[purchases_quantity] AS [PURCHASES QTY], [purchases_cost] AS [PURCHASES COST], [purchases_vat] AS [PURCHASES VAT], [sales_quantity] AS [SALES QTY], [sales] AS [SALES], [sales_vat] AS [SALES VAT], [damages_quantity] AS [DAMAGES QTY], [damages_cost] AS [DAMAGES COST]," & _
                                  " [returns_out_quantity] AS [RETURNS OUT QTY], [returns_out_cost] AS [RETURNS OUT COST],[returns_in_quantity] AS [RETURNS IN QTY],[returns_in_sales] AS [RETURNS IN SALES], " & _
                                  " [closing_stock_unit_cost] AS [CLOSING STOCK UNIT COST] " & _
                                  "FROM stock_monthly_summary INNER JOIN product ON stock_monthly_summary.product=product.product_code " & _
                                  "WHERE [year] = " & yr & " AND [product] = '" & productCode & "'", myConnection)
        da.Fill(ds, "stock_monthly_summary")

        tables(0).Columns.Add("PURCHASES BD QTY").Expression = "[PURCHASES BF QTY] + [PURCHASES QTY] - [RETURNS OUT QTY] - [DAMAGES QTY] - [SALES QTY] + [RETURNS IN QTY]"
        tables(0).Columns.Add("PURCHASES BD COST").Expression = "([PURCHASES BF QTY] + [PURCHASES QTY] -[RETURNS OUT QTY] - [DAMAGES QTY] - [SALES QTY] + [RETURNS IN QTY])*[CLOSING STOCK UNIT COST] "
        tables(0).Columns.Add("STOCK FOR THE MONTH").Expression = "[PURCHASES BF QTY]+[PURCHASES QTY] - [RETURNS OUT QTY] - ([PURCHASES BF QTY] + [PURCHASES QTY] - [RETURNS OUT QTY] - [DAMAGES QTY] - [SALES QTY] + [RETURNS IN QTY])"
        tables(0).Columns.Add("COST FOR THE MONTH").Expression = "[PURCHASES BF COST]+[PURCHASES COST] -[RETURNS OUT COST] - ([PURCHASES BF QTY] + [PURCHASES QTY] -[RETURNS OUT QTY] - [DAMAGES QTY] - [SALES QTY] + [RETURNS IN QTY])*[CLOSING STOCK UNIT COST]"
        tables(0).Columns.Add("PROFIT").Expression = "[SALES]-([PURCHASES BF COST]+[PURCHASES COST] -[RETURNS OUT COST] - ([PURCHASES BF QTY] + [PURCHASES QTY] -[RETURNS OUT QTY] - [DAMAGES QTY] - [SALES QTY] + [RETURNS IN QTY])*[CLOSING STOCK UNIT COST])"

        Dim view1 As New DataView(tables(0))
        source1.DataSource = view1

        AnalysisReportsForm.dgvAnalysisReports.DataSource = view1
        AnalysisReportsForm.Refresh()

        myConnection.Close()

        '===================================================================================
        'Calculate and display Totals
        Dim totalSales As Double = 0
        Dim totalCost As Double = 0
        Dim totalSalesVat As Double = 0
        Dim totalPurchasesVat As Double = 0
        Dim totalDamages As Double = 0

        For i As Integer = 0 To AnalysisReportsForm.dgvAnalysisReports.RowCount - 1
            totalSales += AnalysisReportsForm.dgvAnalysisReports.Rows(i).Cells("SALES").Value
            totalCost += AnalysisReportsForm.dgvAnalysisReports.Rows(i).Cells("COST FOR THE MONTH").Value
            totalSalesVat += AnalysisReportsForm.dgvAnalysisReports.Rows(i).Cells("SALES VAT").Value
            totalPurchasesVat += AnalysisReportsForm.dgvAnalysisReports.Rows(i).Cells("PURCHASES VAT").Value
            totalDamages += AnalysisReportsForm.dgvAnalysisReports.Rows(i).Cells("DAMAGES COST").Value


        Next
        AnalysisReportsForm.txtTotalSales.Text = Format(totalSales, "Standard")
        AnalysisReportsForm.txtTotalCost.Text = Format(totalCost, "Standard")
        AnalysisReportsForm.txtProfit.Text = Format(totalSales - totalCost, "Standard")

        AnalysisReportsForm.txtSalesVat.Text = Format(totalSalesVat, "Standard")
        AnalysisReportsForm.txtPurchasesVat.Text = Format(totalPurchasesVat, "Standard")
        AnalysisReportsForm.txtDamages.Text = Format(totalDamages, "Standard")
        '=======================================================================================

        'FORMAT ADDED FIELDS
        AnalysisReportsForm.dgvAnalysisReports.Columns("PURCHASES BD QTY").DefaultCellStyle.Format = "N2"
        AnalysisReportsForm.dgvAnalysisReports.Columns("PURCHASES BD COST").DefaultCellStyle.Format = "N2"
        AnalysisReportsForm.dgvAnalysisReports.Columns("STOCK FOR THE MONTH").DefaultCellStyle.Format = "N2"
        AnalysisReportsForm.dgvAnalysisReports.Columns("COST FOR THE MONTH").DefaultCellStyle.Format = "N2"
        AnalysisReportsForm.dgvAnalysisReports.Columns("PROFIT").DefaultCellStyle.Format = "N2"
    End Sub

    Private Sub checkConnectionStatus()
        If myConnection.State = ConnectionState.Open Then
            myConnection.Close()

        End If
    End Sub
    Public Function getMonthNumber(ByVal mon As String) As Integer
        Dim num As Integer
        Select Case mon
            Case "January"
                num = 1
            Case "February"
                num = 2
            Case "March"
                num = 3
            Case "April"
                num = 4
            Case "May"
                num = 5
            Case "June"
                num = 6
            Case "July"
                num = 7
            Case "August"
                num = 8
            Case "September"
                num = 9
            Case "October"
                num = 10
            Case "November"
                num = 11
            Case "December"
                num = 12
        End Select
        Return num
    End Function
    Public Function getMonthName(ByVal mon As Integer) As String
        Dim nam As String = Nothing
        Select Case mon
            Case 1
                nam = "January"
            Case 2
                nam = "February"
            Case 3
                nam = "March"
            Case 4
                nam = "April"
            Case 5
                nam = "May"
            Case 6
                nam = "June"
            Case 7
                nam = "July"
            Case 8
                nam = "August"
            Case 9
                nam = "September"
            Case 10
                nam = "October"
            Case 11
                nam = "November"
            Case 12
                nam = "December"
        End Select
        Return nam
    End Function
End Class

