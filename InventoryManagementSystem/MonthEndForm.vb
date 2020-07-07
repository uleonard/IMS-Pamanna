Imports System.Data
Imports System.Data.OleDb
Public Class MonthEndForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Private Sub MonthEndForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim yr As Integer = Year(Date.Now)
        Dim mon As Integer = Month(Date.Now)
        If (mon = 1) Then
            mon = 12
            yr = yr - 1
        Else
            mon = mon - 1
        End If
        lblYear.Text = yr
        lblMonth.Text = MonthName(mon)

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [product_code], [name] FROM product", myConnection)
        da.Fill(ds, "product")

        For i = 0 To ds.Tables("product").Rows.Count - 1

            comProduct.Items.Add(ds.Tables("product").Rows(i).Item(1) & " | " & ds.Tables("product").Rows(i).Item(0))
        Next

        comProduct.SelectedIndex = 0

        myConnection.Close()

        Dim productCode As String = splitProduct()

        Dim sms As StockMonthlySummaryTable = New StockMonthlySummaryTable()
        sms.FillData(lblYear.Text, lblMonth.Text, productCode)
    End Sub
    Private Sub comProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comProduct.SelectedIndexChanged
        Dim productCode As String = splitProduct()

        Dim sms As StockMonthlySummaryTable = New StockMonthlySummaryTable()
        sms.FillData(lblYear.Text, lblMonth.Text, productCode)
        
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click

        comProduct.SelectedIndex = comProduct.Items.Count - 1
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        If (comProduct.SelectedIndex > 0) Then
            comProduct.SelectedIndex = comProduct.SelectedIndex - 1
        End If
    End Sub


    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If (comProduct.SelectedIndex < comProduct.Items.Count - 1) Then
            comProduct.SelectedIndex = comProduct.SelectedIndex + 1
        End If
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        comProduct.SelectedIndex = 0
    End Sub
    Public Function splitProduct() As String

        'Splitting  combo box item into the product id and product name
        Dim strCom As Array = comProduct.Text.Split("|")

        lblProduct.Text = strCom(0).ToString.ToUpper

        Return Trim(strCom(1).ToString) 'PRODUCT CODE

    End Function

    Private Sub txtStockTaking_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStockTaking.TextChanged
        txtBalance.Text = Val(txtNetStock.Text) - Val(txtStockTaking.Text)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim productCode As String = splitProduct()
        Dim sms As StockMonthlySummaryTable = New StockMonthlySummaryTable()
        sms.addStockTaking(productCode, lblYear.Text, lblMonth.Text, txtStockTaking.Text)

        Dim sms2 As StockMonthlySummaryTable = New StockMonthlySummaryTable()
        sms2.FillData(lblYear.Text, lblMonth.Text, productCode)



    End Sub

   
    Private Sub btnReconcile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReconcile.Click
        Dim productCode As String = splitProduct()

        Dim p As PurchasesTable = New PurchasesTable()
        Dim unitCost As Double = p.GetLastUnitCostByProductPerMonth(lblYear.Text, lblMonth.Text, productCode) 'get the unit cost for the last record

        Dim cost As Double = Val(txtBalance.Text) * unitCost
        Dim description As String = "RECONCILIATION FIGURE"
        Dim LastDate As Date = lblMonth.Text & "/28/" & lblYear.Text 'reconciliation figure to be entered as on 28th of the the month.
        Dim p2 As PurchasesTable = New PurchasesTable()
        'p2.AddDamages(productCode, LastDate, txtBalance.Text, cost, description)
        MsgBox("RECONCILED!!!")

        Dim sms2 As StockMonthlySummaryTable = New StockMonthlySummaryTable()
        sms2.FillData(lblYear.Text, lblMonth.Text, productCode)
    End Sub

    Private Sub btnReconciliationNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReconciliationNotes.Click
        ReconciliationNotesForm.ShowDialog()

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        '===========CHECK IF ALL PRODUCTS HAVE BEEN RECONCILED=======================


        comProduct.SelectedIndex = 0
        For i As Integer = 0 To comProduct.Items.Count - 1
            If Not Val(txtBalance.Text) = 0 Then
                MsgBox(lblProduct.Text & " is not yet reconciled. Please do so first.")

                Exit Sub

            End If
            comProduct.SelectedIndex = i
        Next
        '====================END CHECK==========================================

        '==================CLOSE THE MONTH===================================

        Dim smsDelete As StockMonthlySummaryTable = New StockMonthlySummaryTable()
        smsDelete.DeleteSummaryPerMonth(lblYear.Text, lblMonth.Text)

        For i As Integer = 0 To comProduct.Items.Count - 1
            comProduct.SelectedIndex = i

            Dim productCode As String = splitProduct()

            'GO BACK BY ONE MONTH TO GET BALANCE BROUGHT FORWARD FROM BALANCE CARRIAGE FOREARD
            Dim sms As StockMonthlySummaryTable = New StockMonthlySummaryTable()
            Dim monthNum As Integer = sms.getMonthNumber(lblMonth.Text)
            Dim yr As Integer = Val(lblYear.Text)

            If (monthNum = 1) Then
                monthNum = 12
                yr = yr - 1
            Else
                monthNum = monthNum - 1
            End If
            Dim mon As String = sms.getMonthName(monthNum) 'Get String representation of the month e.g January for 1

            Dim sms2 As StockMonthlySummaryTable = New StockMonthlySummaryTable()
            Dim stockBDQuantity As Double = sms2.GetBalanceBroughtFowardPurchasesQuantityByProduct(yr, mon, productCode)
            Dim stockBDCost As Double = sms2.GetBalanceBroughtFowardPurchasesCostByProduct(yr, mon, productCode)
            Dim salesBDQuantity As Double = sms2.GetBalanceBroughtFowardSalesQuantityByProduct(yr, mon, productCode)
            Dim salesBD As Double = sms2.GetBalanceBroughtFowardSalesByProduct(yr, mon, productCode)

            Dim p As PurchasesTable = New PurchasesTable()
            Dim stockReceived As Double = p.GetTotalPurchasesQuantityByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)
            Dim stockCost As Double = p.GetTotalPurchasesCostByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)
            Dim stockDamaged As Double = p.GetTotalDamagesQuantityByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)
            Dim damagesCost As Double = p.GetTotalDamagesCostByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)
            Dim closingStockUnitCost As Double = p.GetLastUnitCostByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)
            Dim purchasesVat As Double = p.GetTotalVatByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)
            Dim returnsOut As Double = p.GetReturnsOutQuantityByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)
            Dim returnsOutValue As Double = p.GetReturnsOutValueByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)

            Dim s As SalesTable = New SalesTable()
            Dim stockSold As Double = s.GetTotalSalesQuantityByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)
            Dim stockSalesValue As Double = s.GetTotalSalesValueByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)
            Dim salesVat As Double = s.GetTotalVatByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)
            Dim returnsIn As Double = s.GetReturnsInQuantityByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)
            Dim returnsInValue As Double = s.GetReturnsInValueByProductPerMonth(lblYear.Text, lblMonth.Text, productCode)

            ' Dim s As SalesTable = New SalesTable()
           

            'ADD THE SUMMARY
            Dim sms3 As StockMonthlySummaryTable = New StockMonthlySummaryTable()
            sms3.addSummary(productCode, lblYear.Text, lblMonth.Text, stockBDQuantity, stockBDCost, salesBDQuantity, salesBD, stockReceived, stockCost, purchasesVat, stockDamaged, damagesCost, stockSold, stockSalesValue, salesVat, closingStockUnitCost, returnsOut, returnsOutValue, returnsIn, returnsInValue)





        Next


        MsgBox("The month successfully closed!!")

        '==============================END CLOSE============================
    End Sub
End Class