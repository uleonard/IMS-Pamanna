Imports System.Data
Imports System.Data.OleDb
Public Class StockTakingForm

    Private Sub StockTakingForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        'ENABLE EDIT FOR MANAGER AND SUPERUSER USERS
        If Not UserTable.role = "CLERK" Then
            btnEdit.Enabled = True
        End If
        LoadStockTaking()
        'FORMAT DATE COLUMNS
        DataGridView1.Columns("DATE MODIFIED").DefaultCellStyle.Format = "g"
        DataGridView1.Columns("DATE ENTERED").DefaultCellStyle.Format = "g"
    End Sub
    Public Sub LoadStockTaking()
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT p.name AS [PRODUCT NAME], p.product_code AS [PRODUCT CODE], p.plu_code AS [PRODUCT PLU], st.quantity AS [QUANTITY],  st.entered_by AS [ENTERED BY], st.date_entered AS [DATE ENTERED], st.modified_by AS [MODIFIED BY], st.date_modified AS [DATE MODIFIED], st.rc_status AS [RC STATUS] FROM  product p INNER JOIN stock_taking st ON p.product_code=st.product WHERE st.year = ? AND st.month = ?", myConnection)
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


        DataGridView1.ReadOnly = True

    End Sub

 

    Private Sub comYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comYear.SelectedIndexChanged
        LoadStockTaking()
    End Sub

    Private Sub comMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comMonth.SelectedIndexChanged
        LoadStockTaking()
    End Sub

    Private Sub StockTakingForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        DataGridView1.Left = Me.Width / 2 - DataGridView1.Width / 2
        DataGridView1.Height = Me.Height - 160
        Panel1.Top = Me.Height - 80
        Panel1.Left = DataGridView1.Left
        Panel2.Left = DataGridView1.Left
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        EnterStockTakingForm.ShowDialog()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim defaultName As String = "Stock Taking for " & comMonth.Text & " " & comYear.Text
        
        Export(DataGridView1, defaultName)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("No records available!!!")
            Exit Sub
        End If

        EditStockTakingForm.ShowDialog()


    End Sub
End Class