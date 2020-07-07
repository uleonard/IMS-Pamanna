Public Class MonthlySummariesForm

    Private Sub MonthlySummariesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim yr As Integer
        Dim maxYear As Integer = Year(Date.Now)
        Dim mon As Integer = Month(Date.Now)
        If mon = 1 Then
            maxYear = maxYear - 1
            mon = 12
        Else
            mon = mon - 1
        End If

        For yr = 2014 To maxYear
            comYear.Items.Add(yr)
        Next
        comYear.Text = maxYear

        comMonth.Text = MonthName(mon)


        Dim sms As StockMonthlySummaryTable = New StockMonthlySummaryTable()
        sms.LoadMonthlySummaries(comYear.Text, comMonth.Text)

        dgvMonthlySummaries.Columns("PURCHASES BD QTY").DefaultCellStyle.Format = "N2"
        dgvMonthlySummaries.Columns("PURCHASES BD COST").DefaultCellStyle.Format = "N2"
        dgvMonthlySummaries.Columns("STOCK FOR THE MONTH").DefaultCellStyle.Format = "N2"
        dgvMonthlySummaries.Columns("COST FOR THE MONTH").DefaultCellStyle.Format = "N2"
        dgvMonthlySummaries.Columns("PROFIT").DefaultCellStyle.Format = "N2"

    End Sub

    Private Sub comMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comMonth.SelectedIndexChanged
        Dim sms As StockMonthlySummaryTable = New StockMonthlySummaryTable()
        sms.LoadMonthlySummaries(comYear.Text, comMonth.Text)
    End Sub

    Private Sub comYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comYear.SelectedIndexChanged
        Dim sms As StockMonthlySummaryTable = New StockMonthlySummaryTable()
        sms.LoadMonthlySummaries(comYear.Text, comMonth.Text)
    End Sub

    Private Sub MonthlySummariesForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        dgvMonthlySummaries.Width = Me.Width - 60
        dgvMonthlySummaries.Left = 20
        dgvMonthlySummaries.Width = Me.Width - 60
        dgvMonthlySummaries.Height = Me.Height - 200
        panel3.Top = dgvMonthlySummaries.Height + 110
        panel2.Top = dgvMonthlySummaries.Height + 70
        Panel1.Left = dgvMonthlySummaries.Left
        panel2.Left = dgvMonthlySummaries.Left
        panel3.Left = dgvMonthlySummaries.Left
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim defaultName As String = "Monthly Summary Report For " & comMonth.Text & " " & comYear.Text

        Export(dgvMonthlySummaries, defaultName)
    End Sub
End Class