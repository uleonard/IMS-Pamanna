Imports System.Data
Imports System.Data.OleDb
Public Class SalesSummaryReportForm
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter

   

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        btnPrint.Enabled = True



        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()

        ds.Clear()

        myConnection.Open()

        da = New OleDbDataAdapter("SELECT * FROM point_of_sale_summary_report WHERE [ref_number] = '" & txtRefNumber.Text & "'", myConnection)
        da.Fill(ds, "report")

        If ds.Tables("report").Rows.Count = 0 Then
            ClearFields()
            Exit Sub
        End If
        txtCash.Text = Format(ds.Tables("report").Rows(0).Item("cash_sales"), "Standard")
        txtCharge.Text = Format(ds.Tables("report").Rows(0).Item("charge_sales"), "Standard")
        txtCredit.Text = Format(ds.Tables("report").Rows(0).Item("credit_sales"), "Standard")
        txtCheck.Text = Format(ds.Tables("report").Rows(0).Item("check_sales"), "Standard")
        txtTotal.Text = Format(ds.Tables("report").Rows(0).Item("net_sales"), "Standard")

        txtVAT.Text = Format(ds.Tables("report").Rows(0).Item("vat"), "Standard")

        txtRA.Text = Format(ds.Tables("report").Rows(0).Item("ra"), "Standard")
        txtRACount.Text = ds.Tables("report").Rows(0).Item("ra_frequency")
        txtPO.Text = Format(ds.Tables("report").Rows(0).Item("po"), "Standard")
        txtPOCount.Text = ds.Tables("report").Rows(0).Item("po_frequency")

        txtVoidAmount.Text = Format(ds.Tables("report").Rows(0).Item("void_sales"), "Standard")
        txtVoidCount.Text = ds.Tables("report").Rows(0).Item("void_frequency")

        txtCID.Text = Format(ds.Tables("report").Rows(0).Item("cash_in_drawer"), "Standard")

        myConnection.Close()
    End Sub
    Private Sub ClearFields()
        txtCash.Text = ""
        txtCharge.Text = ""
        txtCredit.Text = ""
        txtCheck.Text = ""
        txtTotal.Text = ""

        txtVAT.Text = ""

        txtRA.Text = ""
        txtRACount.Text = ""
        txtPO.Text = ""
        txtPOCount.Text = ""

        txtVoidAmount.Text = ""
        txtVoidCount.Text = ""

        txtCID.Text = ""
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        btnPrint.Visible = False
        txtRefNumber.Visible = False
        btnSearch.Visible = False
        lblClose.Visible = False
        lblTitle.Text = "Sales Report For Ref Number " & txtRefNumber.Text

        PrintForm.Print(Me, PowerPacks.Printing.PrintForm.PrintOption.Scrollable)

        btnPrint.Visible = True
        txtRefNumber.Visible = True
        btnSearch.Visible = True
        lblClose.Visible = True

        lblTitle.Text = "Sales Report For Ref Number " 
    End Sub

    Private Sub lblClose_Click(sender As System.Object, e As System.EventArgs) Handles lblClose.Click
        Me.Dispose()
    End Sub

    Private Sub SalesSummaryReportForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class