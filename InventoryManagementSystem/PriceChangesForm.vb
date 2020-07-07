Imports System.Data
Imports System.Data.OleDb
Public Class PriceChangesForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim source1 As New BindingSource()


    Private Sub PriceChangesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load



        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT p.name AS [PRODUCT NAME], p.product_code AS [CODE], pp.price AS [PRICE], pp.entered_by AS [CHANGED BY], pp.date_entered AS [DATE ENTERED], pp.year AS [YEAR], pp.month AS [MONTH] FROM product_price pp INNER JOIN product p ON pp.product=p.product_code ", myConnection)
        da.Fill(ds, "price")

        Dim view1 As New DataView(ds.Tables("price"))
        source1.DataSource = view1
        dgvPriceChanges.DataSource = view1

        myConnection.Close()

        Dim yr As Integer
        For yr = 2014 To Year(Date.Now)
            comYear.Items.Add(yr)
        Next
        comYear.Text = Year(Date.Now)
        Dim mon As Integer = Month(Date.Now)

        comMonth.Text = MonthName(mon)

        dgvPriceChanges.Columns("DATE ENTERED").DefaultCellStyle.Format = "g"
    End Sub

    Private Sub comMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comMonth.SelectedIndexChanged
        source1.Filter = "[MONTH] = '" & comMonth.Text & "' AND [YEAR] = '" & comYear.Text & "'"
        dgvPriceChanges.Refresh()
    End Sub

    Private Sub comYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comYear.SelectedIndexChanged
        source1.Filter = "[MONTH] = '" & comMonth.Text & "' AND [YEAR] = '" & comYear.Text & "'"
        dgvPriceChanges.Refresh()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim defaultName As String = "Pa-manna - Price Changes"
        Export(dgvPriceChanges, defaultName)
        
    End Sub
End Class