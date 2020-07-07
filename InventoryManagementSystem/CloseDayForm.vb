Imports System.Data
Imports System.Data.OleDb
Public Class CloseDayForm
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        If txtRefNumber.Text = "" Then
            MsgBox("Please enter a reference number")
            Exit Sub
        End If

        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [product_code], [unit_price], [vatable] FROM product WHERE status = 'Active'", myConnection)
        da.Fill(ds, "product")

        Dim vat As Double = 0
        For i = 0 To ds.Tables("product").Rows.Count - 1
            Dim product As String = ds.Tables("product").Rows(i).Item("product_code")
            Dim sales As Double = GetTotalByProduct(product)
            If ds.Tables("product").Rows(i).Item("vatable") = "Yes" Then
                vat += (sales - Val(sales) / 1.165) 'VAT at 16.5%
            End If

            If sales > 0 Then
                Dim UnitPrice As Double = ds.Tables("product").Rows(i).Item("unit_price")
                Dim quantity As Double = GetTotalQtyByProduct(product)
                Dim description As String = "Directly entered"

                Dim s As SalesTable = New SalesTable()
                s.AddSales(product, Date.Now.ToString, UnitPrice, quantity, sales, description, txtRefNumber.Text)
            End If
        Next
        myConnection.Close()

        'Update VAT in Sales Summary Report table before it is closed
        UpdateVAT(vat)

        'Close the Sales summary report table
        CloseSalesSummaryReport()

        'Change status for transactions in sales_transaction table to Closed
        ChangeStatusToClose()

        MsgBox("Day has been closed successfully!!!")
        Me.Dispose()
    End Sub
    Private Function GetTotalByProduct(ByVal product As String) As Double
        Dim connection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        connection.ConnectionString = dbCon.dbConnector()
        connection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT SUM(sales) FROM sales_transaction WHERE [product] = ? AND status = ?", connection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(product, String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("Open", String)))


        Dim Total As Object = cmd.ExecuteScalar()
        If IsDBNull(Total) Then
            Total = 0
        End If
        connection.Close()
        Return Total
    End Function
    Private Function GetTotalQtyByProduct(ByVal product As String) As Double
        Dim connection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        connection.ConnectionString = dbCon.dbConnector()
        connection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT SUM(quantity) FROM sales_transaction WHERE [product] = ? AND status = ?", connection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(product, String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("Open", String)))


        Dim Total As Object = cmd.ExecuteScalar()
        If IsDBNull(Total) Then
            Total = 0
        End If
        connection.Close()
        Return Total
    End Function
    Private Sub ChangeStatusToClose()
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE sales_transaction  SET status = ?  WHERE status = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("status", CType("Closed", String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("Open", String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Private Sub UpdateVAT(ByVal vat As Double)
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE point_of_sale_summary_report  SET vat = ?  WHERE status = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("vat", CType(vat, String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("Open", String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Private Sub CloseSalesSummaryReport()
        Dim SalesCash As Double = GetTotalSales("Cash")
        Dim SalesCharge As Double = GetTotalSales("Charge")
        Dim SalesCredit As Double = GetTotalSales("Credit")
        Dim SalesCheck As Double = GetTotalSales("Check")
        Dim TotalSales As Double = SalesCash + SalesCharge + SalesCredit + SalesCheck
        Dim CashInDrawer As Double


        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()


        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [ra], [po] FROM point_of_sale_summary_report WHERE [status] = 'Open' ", myConnection)
        da.Fill(ds, "report")

        Dim ra As Double = ds.Tables("report").Rows(0).Item(0)
        Dim po As Double = ds.Tables("report").Rows(0).Item(1)

        myConnection.Close()
        CashInDrawer = SalesCash + ra - po

        myConnection.Open()

        Dim str As String
        str = "UPDATE point_of_sale_summary_report  SET cash_sales = ?, charge_sales = ?, credit_sales = ?, check_sales = ?, net_sales = ?, cash_in_drawer = ?, ref_number = ?, status = ? WHERE status = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("cash_sales", CType(SalesCash, String)))
        cmd.Parameters.Add(New OleDbParameter("charge_sales", CType(SalesCharge, String)))
        cmd.Parameters.Add(New OleDbParameter("credit_sales", CType(SalesCredit, String)))
        cmd.Parameters.Add(New OleDbParameter("check_sales", CType(SalesCheck, String)))
        cmd.Parameters.Add(New OleDbParameter("net_sales", CType(TotalSales, String)))
        cmd.Parameters.Add(New OleDbParameter("cash_in_drawer", CType(CashInDrawer, String)))
        cmd.Parameters.Add(New OleDbParameter("ref_number", CType(txtRefNumber.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("Closed", String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("Open", String)))

        Try
            cmd.ExecuteNonQuery()
            OpenNextRecord()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()

    End Sub
    Private Function GetTotalSales(ByVal SalesType As String) As Double
        Dim connection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        connection.ConnectionString = dbCon.dbConnector()
        connection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT SUM(sales) FROM sales_transaction WHERE status = ? AND sales_type = ?", connection)
        cmd.Parameters.Add(New OleDbParameter("status", CType("Open", String)))
        cmd.Parameters.Add(New OleDbParameter("sales_type", CType(SalesType, String)))


        Dim Total As Object = cmd.ExecuteScalar()
        If IsDBNull(Total) Then
            Total = 0
        End If
        connection.Close()
        Return Total
    End Function
    Private Sub OpenNextRecord()
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "INSERT INTO point_of_sale_summary_report (ra) VALUES(?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("ra", CType("0", String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click, Me.FormClosing
        Me.Dispose()

    End Sub

    Private Sub CloseDayForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class