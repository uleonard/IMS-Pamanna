Imports System.Data
Imports System.Data.OleDb
Public Class EnterStockTakingForm

    Private Sub StockTakingForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim yr As Integer
        For yr = 2014 To Year(Date.Now)
            comYear.Items.Add(yr)
        Next

        Dim mon As Integer = Month(Date.Now)

        If mon = 1 Then
            mon = 12
            yr = Year(Date.Now) - 1
        Else
            mon = mon - 1
            yr = Year(Date.Now)
        End If
        comYear.Text = yr
        comMonth.Text = MonthName(mon)


        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT [name] AS [PRODUCT NAME], [product_code] AS [PRODUCT CODE], [plu_code] AS [PRODUCT PLU] FROM  product WHERE status = ?", myConnection)
        cmd.Parameters.Add(New OleDbParameter("status", CType("Active", String)))

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)

        reader.Close()

        DataGridView1.AutoGenerateColumns = True
        DataGridView1.DataSource = dt
        DataGridView1.Refresh()
        DataGridView1.AllowUserToAddRows = False

        DataGridView1.Columns.Add("STOCK", "STOCK")

        'SET Unit Cost Column a READONLY
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True

        'For i As Integer = 0 To DataGridView1.RowCount() - 1
        '    DataGridView1.Rows(i).Cells("STOCK").Value = 0
        'Next

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        'DELETE IF ALREADY ENTERED
        DeleteStockTaking()

        For i As Integer = 0 To DataGridView1.RowCount() - 1

            Dim product As String = DataGridView1.Rows(i).Cells("PRODUCT CODE").Value()
            Dim qty As String = DataGridView1.Rows(i).Cells("STOCK").Value()

            Dim st As StockMonthlySummaryTable = New StockMonthlySummaryTable()

            st.addStockTaking(product, comYear.Text, comMonth.Text, qty)

        Next

        MsgBox("SAVED!!!")
        StockTakingForm.comYear.Text = comYear.Text
        StockTakingForm.comMonth.Text = comMonth.Text
        StockTakingForm.LoadStockTaking()

        Me.Dispose()
    End Sub
    Public Sub DeleteStockTaking()
        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
       
        Dim str As String = "DELETE FROM stock_taking WHERE [year] = " & comYear.Text & " AND [month] = '" & comMonth.Text & "'"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        myConnection.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()

    End Sub
End Class