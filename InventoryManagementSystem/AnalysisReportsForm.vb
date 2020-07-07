Imports System.Data
Imports System.Data.OleDb
Public Class AnalysisReportsForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Private Sub AnalysisReportsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim yr As Integer
        For yr = 2014 To Year(Date.Now)
            comYear.Items.Add(yr)
        Next
        comYear.Text = Year(Date.Now)

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [product_code], [name] FROM product", myConnection)
        da.Fill(ds, "product")

        For i = 0 To ds.Tables("product").Rows.Count - 1

            comProduct.Items.Add(ds.Tables("product").Rows(i).Item(1) & " | " & ds.Tables("product").Rows(i).Item(0))
        Next
        myConnection.Close()

        comProduct.SelectedIndex = 0

        Dim productCode As String = MainModule.splitProduct(comProduct.Text)

        Dim sms As StockMonthlySummaryTable = New StockMonthlySummaryTable()
        sms.LoadAnalysisReport(comYear.Text, productCode)

        'Me.Width = MDIManager.Width - 20 'SET WIDTH OF THE FORM


    End Sub
    Private Sub comProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comProduct.SelectedIndexChanged
        Dim productCode As String = MainModule.splitProduct(comProduct.Text)

        Dim sms As StockMonthlySummaryTable = New StockMonthlySummaryTable()
        sms.LoadAnalysisReport(comYear.Text, productCode)
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

    Private Sub comYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comYear.SelectedIndexChanged
        If (comProduct.SelectedIndex <> -1) Then
            Dim productCode As String = MainModule.splitProduct(comProduct.Text)

            Dim sms As StockMonthlySummaryTable = New StockMonthlySummaryTable()
            sms.LoadAnalysisReport(comYear.Text, productCode)

        End If
    End Sub

    Private Sub AnalysisReportsForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        dgvAnalysisReports.Width = Me.Width - 60
        dgvAnalysisReports.Left = 20
        dgvAnalysisReports.Width = Me.Width - 60
        dgvAnalysisReports.Height = Me.Height - 200
        Panel3.Top = dgvAnalysisReports.Height + 110
        panel2.Top = dgvAnalysisReports.Height + 70
        Panel1.Left = dgvAnalysisReports.Left
        panel2.Left = dgvAnalysisReports.Left
        Panel3.Left = dgvAnalysisReports.Left
    End Sub

    
    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim defaultName As String = splitProductToGetName(comProduct.Text) & " Year Product Report For " & comYear.Text

        Export(dgvAnalysisReports, defaultName)
    End Sub

End Class