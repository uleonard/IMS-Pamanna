Imports System.Data
Imports System.Data.OleDb
Public Class EditStockTakingForm

    Private Sub EditStockTakingForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim yr As Integer
        For yr = 2014 To Year(Date.Now)
            comYear.Items.Add(yr)
        Next
        comYear.Text = StockTakingForm.comYear.Text
        comMonth.Text = StockTakingForm.comMonth.Text



        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT p.name AS [PRODUCT NAME], p.product_code AS [PRODUCT CODE], p.plu_code AS [PRODUCT PLU], st.quantity AS [STOCK], st.quantity AS [STOCK CURRENT], st.stock_taking_id AS [ID] FROM  product p INNER JOIN stock_taking st ON p.product_code=st.product WHERE st.year = ? AND st.month = ?", myConnection)
        cmd.Parameters.Add(New OleDbParameter("year", CType(comYear.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(comMonth.Text, String)))

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)

        reader.Close()

        DataGridView1.AutoGenerateColumns = True
        DataGridView1.DataSource = dt
        DataGridView1.Refresh()

        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True

        'HIDE THE FOLLOWING COLUMNS
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(5).Visible = False
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        
        For i As Integer = 0 To DataGridView1.RowCount() - 1

            Dim QtyCurrent As String = DataGridView1.Rows(i).Cells("STOCK CURRENT").Value()
            Dim qty As String = DataGridView1.Rows(i).Cells("STOCK").Value()
            Dim stID As String = DataGridView1.Rows(i).Cells("ID").Value() 'ID for stock taking

            'If Not qty = QtyCurrent Then
            Dim st As StockMonthlySummaryTable = New StockMonthlySummaryTable()

            st.UpdateStockTaking(comYear.Text, comMonth.Text, qty, stID)
            ' End If

        Next

        MsgBox("SAVED!!!")
        StockTakingForm.comYear.Text = comYear.Text
        StockTakingForm.comMonth.Text = comMonth.Text
        StockTakingForm.LoadStockTaking()

        Me.Dispose()
    End Sub
    

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()

    End Sub
End Class