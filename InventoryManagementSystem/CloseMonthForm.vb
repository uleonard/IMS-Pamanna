Imports System.Data
Imports System.Data.OleDb
Public Class CloseMonthForm

    Private Sub CloseMonthForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim yr As Integer
        For yr = 2014 To Year(Date.Now)
            comYear.Items.Add(yr)
        Next
        comYear.Text = Year(Date.Now)
        Dim mon As Integer = Month(Date.Now)

        If mon = 1 Then
            mon = 12
        Else
            mon = mon - 1
        End If
        comMonth.Text = MonthName(mon)

        lblMomth.Text = comMonth.Text & " / " & comYear.Text

        DataGridView1.ColumnCount = 15
        DataGridView1.Columns(0).Name = "PRODUCT"
        DataGridView1.Columns(1).Name = "CODE"
        DataGridView1.Columns(2).Name = "PLU"
        DataGridView1.Columns(3).Name = "BAL B/D"
        DataGridView1.Columns(4).Name = "STOCK RECEIVED"
        DataGridView1.Columns(5).Name = "RETURNS OUT"
        DataGridView1.Columns(6).Name = "STOCK SOLD"
        DataGridView1.Columns(7).Name = "RETURNS IN"
        DataGridView1.Columns(8).Name = "STOCK DAMAGED"
        DataGridView1.Columns(9).Name = "NET STOCK"
        DataGridView1.Columns(10).Name = "STOCK TAKING FIGURE"
        DataGridView1.Columns(11).Name = "VARIANCE"
        DataGridView1.Columns(12).Name = "% VAR"
        DataGridView1.Columns(13).Name = "RC FIGURE"
        DataGridView1.Columns(14).Name = "RC STATUS" 'RECONCILATION STATUS


        LoadDatagrid()

    End Sub
    Public Sub LoadDatagrid()
        DataGridView1.Rows.Clear()

        'GO BACK BY ONE MONTH TO GET BALANCE BROUGHT FORWARD FROM BALANCE CARRIAGE FOREWARD
        Dim monthNum As Integer = getMonthNumber(comMonth.Text)
        Dim yr As Integer = Val(comYear.Text)
        If (monthNum = 1) Then
            monthNum = 12
            yr = yr - 1
        Else
            monthNum = monthNum - 1
        End If



        'GET PRODUCTS AND STOCK TAKING FUGURES FOR THE SELECTED MONTHS
        Dim reader As OleDbDataReader = GetProductsAndStockTakingFigure()

        Dim RowCount As Integer = 0

        While reader.Read()
            '==============================================================================
            'GET VALUES FOR BAL BD, PURCHASES, SALES, RETURNS OUT, DAMAGES ETC
            Dim st As StockMonthlySummaryTable = New StockMonthlySummaryTable()
            'Dim BalDB As Double = st.GetBalanceBroughtFowardPurchasesQuantityByProduct(yr, MonthName(monthNum), reader.Item("PRODUCT CODE"))

            Dim BalDB As Double = st.GetStockTakingFigureByProductPerMonth(yr, MonthName(monthNum), reader.Item("PRODUCT CODE"))

            Dim p As PurchasesTable = New PurchasesTable()
            Dim StockReceived As Double = p.GetTotalPurchasesQuantityByProductPerMonth(comYear.Text, comMonth.Text, reader.Item("PRODUCT CODE"))

            Dim s As SalesTable = New SalesTable()
            Dim StockSold As Double = s.GetTotalSalesQuantityByProductPerMonth(comYear.Text, comMonth.Text, reader.Item("PRODUCT CODE"))
            Dim ReturnsIn As Double = s.GetReturnsInQuantityByProductPerMonth(comYear.Text, comMonth.Text, reader.Item("PRODUCT CODE"))


            Dim StockDamaged As Double = p.GetTotalDamagesQuantityByProductPerMonth(comYear.Text, comMonth.Text, reader.Item("PRODUCT CODE"))

            Dim ReturnsOut As Double = p.GetReturnsOutQuantityByProductPerMonth(comYear.Text, comMonth.Text, reader.Item("PRODUCT CODE"))

            Dim ReconciliationFigure As Double = p.GetReconciliationFigureByProductPerMonth(comYear.Text, comMonth.Text, reader.Item("PRODUCT CODE"))

            Dim NetStock As Double = Format((BalDB + StockReceived + ReturnsIn) - (StockSold + ReturnsOut + StockDamaged), "Fixed")
            Dim RCStatus As String = "Not Reconciled"

            If FormatNumber(NetStock - reader.Item("QUANTITY") - ReconciliationFigure, 1) <= 0.5 And FormatNumber(NetStock - reader.Item("QUANTITY") - ReconciliationFigure, 1) >= -0.5 Then 'NET MINUS STOCK TAKING FIGURE MINUS RECONCILIATION FIGURE
                RCStatus = "Reconciled"
            End If

            Dim VariancePercentage As Double = 0
            If Not NetStock - reader.Item("QUANTITY") = 0 Then
                VariancePercentage = Format(((NetStock - reader.Item("QUANTITY"))) / NetStock * 100, "Standard")
            End If
            'ENDS HERE
            '===============================================================================
            Dim plu As String
            If IsDBNull(reader.Item("PRODUCT PLU")) Then
                plu = ""
            Else
                plu = reader.Item("PRODUCT PLU")
            End If
            Dim row As String() = New String() {
                                                reader.Item("PRODUCT NAME"),
                                                reader.Item("PRODUCT CODE"),
                                                plu,
                                                BalDB,
                                                StockReceived,
                                                ReturnsOut,
                                                StockSold,
                                                ReturnsIn,
                                                StockDamaged,
                                                NetStock,
                                                reader.Item("QUANTITY"),
                                                Format((NetStock - reader.Item("QUANTITY")), "Standard"),
                                                VariancePercentage,
                                                ReconciliationFigure,
                                                RCStatus
                                            }
            DataGridView1.Rows.Add(row)

            RowCount = RowCount + 1

        End While
        DataGridView1.AllowUserToAddRows = False

        reader.Close()

    End Sub
    Private Function GetProductsAndStockTakingFigure() As OleDbDataReader
        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT p.name AS [PRODUCT NAME], p.product_code AS [PRODUCT CODE], p.plu_code AS [PRODUCT PLU], st.quantity AS [QUANTITY] FROM  product p INNER JOIN stock_taking st ON p.product_code=st.product WHERE st.year = ? AND st.month = ?", myConnection)
        cmd.Parameters.Add(New OleDbParameter("year", CType(comYear.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(comMonth.Text, String)))

        Return cmd.ExecuteReader()

    End Function

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()

    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click

        Dim defaultName As String = "Month End Figures For " & comMonth.Text & " " & comYear.Text

        Export(DataGridView1, defaultName)
    End Sub

    Private Sub btnView_Click(sender As System.Object, e As System.EventArgs) Handles btnView.Click
        lblMomth.Text = comMonth.Text & " / " & comYear.Text
        LoadDatagrid()

        btnCloseThisMonth.Enabled = True
    End Sub

    Private Sub CloseMonthForm_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        DataGridView1.Left = 20
        DataGridView1.Width = Me.Width - 60
        DataGridView1.Height = Me.Height - 200
        Panel1.Top = DataGridView1.Height + 70
        Panel1.Left = DataGridView1.Left
        Panel2.Left = DataGridView1.Left

    End Sub

    Private Sub btnCloseThisMonth_Click(sender As System.Object, e As System.EventArgs) Handles btnCloseThisMonth.Click
        '===========CHECK IF ALL PRODUCTS HAVE BEEN RECONCILED=======================


        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            'If Not Val(DataGridView1.Rows(i).Cells("STOCK TAKING FIGURE").Value) = Val(DataGridView1.Rows(i).Cells("NET STOCK").Value) Then
            'MsgBox(DataGridView1.Rows(i).Cells("PRODUCT").Value & " is not yet reconciled. Please do so first.")

            'Exit Sub

            'End If

            'If Not CType(DataGridView1.Rows(i).Cells("VARIANCE").Value, Double) - CType(DataGridView1.Rows(i).Cells("RC FIGURE").Value, Double) = 0 Then
            If Not CType(DataGridView1.Rows(i).Cells("RC STATUS").Value, String) = "Reconciled" Then

                MsgBox(DataGridView1.Rows(i).Cells("PRODUCT").Value & " is not yet reconciled. Please do so first.")
                DataGridView1.ClearSelection()

                DataGridView1.Rows(i).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(0)

                Exit Sub

            End If
        Next
        '====================END CHECK==========================================
        Dim res As DialogResult = MsgBox("You are closing a month of " & comMonth.Text & " - " & comYear.Text & vbCrLf & "IS THIS IN ORDER ?", vbYesNo + MsgBoxStyle.Question, "Inventory Management System")
        If res = vbNo Then
            Exit Sub
        End If
        '==================CLOSING THE MONTH===================================

        'FIRST DELETE THE RECORDS FOR THE SELECTED MONTH WHICH MIGHT BE IN THE DATABASE
        Dim smsDelete As StockMonthlySummaryTable = New StockMonthlySummaryTable()
        smsDelete.DeleteSummaryPerMonth(comYear.Text, comMonth.Text)

        For i As Integer = 0 To DataGridView1.Rows.Count - 1


            Dim productCode As String = DataGridView1.Rows(i).Cells("CODE").Value

            'GO BACK BY ONE MONTH TO GET BALANCE BROUGHT FORWARD FROM BALANCE CARRIAGE FOREARD
            Dim sms As StockMonthlySummaryTable = New StockMonthlySummaryTable()
            Dim monthNum As Integer = sms.getMonthNumber(comMonth.Text)
            Dim yr As Integer = Val(comYear.Text)

            'If (monthNum = 1) Then
            'monthNum = 12
            ' yr = yr - 1
            ' Else
            ' monthNum = monthNum - 1
            ' End If
            Dim mon As String = comMonth.Text

            ' Dim s As SalesTable = New SalesTable()

            Dim sms2 As StockMonthlySummaryTable = New StockMonthlySummaryTable()
            'Dim stockBDQuantity As Double = sms2.GetBalanceBroughtFowardPurchasesQuantityByProduct(yr, mon, productCode)
            Dim stockBDQuantity As Double = DataGridView1.Rows(i).Cells("BAL B/D").Value
            Dim stockBDCost As Double = Me.GetUnitCost(productCode) * stockBDQuantity
            'sales bd is changed to sales for the month
            Dim salesBDQuantity As Double = 0
            Dim salesBD As Double = 0

            Dim p As PurchasesTable = New PurchasesTable()
            Dim stockReceived As Double = p.GetTotalPurchasesQuantityByProductPerMonth(comYear.Text, comMonth.Text, productCode)
            Dim stockCost As Double = p.GetTotalPurchasesCostByProductPerMonth(comYear.Text, comMonth.Text, productCode)
            Dim stockDamaged As Double = p.GetTotalDamagesQuantityByProductPerMonth(comYear.Text, comMonth.Text, productCode)
            Dim damagesCost As Double = p.GetTotalDamagesCostByProductPerMonth(comYear.Text, comMonth.Text, productCode)
            Dim closingStockUnitCost As Double = p.GetLastUnitCostByProductPerMonth(comYear.Text, comMonth.Text, productCode)
            Dim purchasesVat As Double = p.GetTotalVatByProductPerMonth(comYear.Text, comMonth.Text, productCode)
            Dim returnsOut As Double = p.GetReturnsOutQuantityByProductPerMonth(comYear.Text, comMonth.Text, productCode)
            Dim returnsOutValue As Double = p.GetReturnsOutValueByProductPerMonth(comYear.Text, comMonth.Text, productCode)

            Dim s As SalesTable = New SalesTable()
            Dim stockSold As Double = s.GetTotalSalesQuantityByProductPerMonth(comYear.Text, comMonth.Text, productCode)
            Dim stockSalesValue As Double = s.GetTotalSalesValueByProductPerMonth(comYear.Text, comMonth.Text, productCode)
            Dim salesVat As Double = s.GetTotalVatByProductPerMonth(comYear.Text, comMonth.Text, productCode)
            Dim returnsIn As Double = s.GetReturnsInQuantityByProductPerMonth(comYear.Text, comMonth.Text, productCode)
            Dim returnsInValue As Double = s.GetReturnsInValueByProductPerMonth(comYear.Text, comMonth.Text, productCode)


            'ADD THE SUMMARY
            Dim sms3 As StockMonthlySummaryTable = New StockMonthlySummaryTable()
            sms3.addSummary(productCode, comYear.Text, comMonth.Text, stockBDQuantity, stockBDCost, salesBDQuantity, salesBD, stockReceived, stockCost, purchasesVat, stockDamaged, damagesCost, stockSold, stockSalesValue, salesVat, closingStockUnitCost, returnsOut, returnsOutValue, returnsIn, returnsInValue)
            'Mark stocktaking figures for this month reconciled
            sms3.MarkStockTakingReconciled(comYear.Text, comMonth.Text)
        Next


        MsgBox("The month of " & comMonth.Text & " " & comYear.Text & " has been closed successfully!!!")

        '==============================END CLOSE============================
    End Sub
    Private Function GetUnitCost(ByVal productCode As String)
        Dim yr As Integer = comYear.Text.Trim

        Dim p As PurchasesTable = New PurchasesTable()
        Dim UnitCost As Double = p.GetLastUnitCostByProductPerMonth(comYear.Text, comMonth.Text, productCode)

        '============================START OF A REDUNDANT CODE TO GET UNIT PRICE=====================================
        'GO BACK BY ONE MONTH TO GET UNIT COST
        Dim monthNum As Integer = getMonthNumber(comMonth.Text)

        If (monthNum = 1) Then
            monthNum = 12
            yr = yr - 1
        Else
            monthNum = monthNum - 1
        End If

        UnitCost = p.GetLastUnitCostByProductPerMonth(yr, MonthName(monthNum), productCode)

         If UnitCost = 0 Then
            'GO BACK BY ONE MONTH TO GET UNIT COST
           
            If (monthNum = 1) Then
                monthNum = 12
                yr = yr - 1
            Else
                monthNum = monthNum - 1
            End If

            UnitCost = p.GetLastUnitCostByProductPerMonth(yr, MonthName(monthNum), productCode)
        End If
        'IF unit cost is still zero then go one step further
        If UnitCost = 0 Then
            'GO BACK BY ONE MONTH TO GET UNIT COST

            If (monthNum = 1) Then
                monthNum = 12
                yr = yr - 1
            Else
                monthNum = monthNum - 1
            End If

            UnitCost = p.GetLastUnitCostByProductPerMonth(yr, MonthName(monthNum), productCode)
        End If

        Return UnitCost
        '============================END OF A REDUNDANT CODE TO GET UNIT PRICE=====================================
    End Function

    Private Sub btnReconcile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReconcile.Click
        If Not DataGridView1.SelectedCells.Count > 0 Then
            MsgBox("Select Row first.")
            Exit Sub

        End If
        If DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("RC STATUS").Value = "Reconciled" Then
            MsgBox("Selected row is already reconciled.")
            Exit Sub
        End If

        EnterReconciliationFigureForm.ShowDialog()

    End Sub

    Private Sub btnViewReconciliationFigures_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnViewReconciliationFigures.Click
        ReconciliationFiguresForm.ShowDialog()

    End Sub

    
    Private Sub comMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comMonth.SelectedIndexChanged

        btnCloseThisMonth.Enabled = False

    End Sub

    Private Sub comYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comYear.SelectedIndexChanged
        btnCloseThisMonth.Enabled = False
    End Sub
End Class