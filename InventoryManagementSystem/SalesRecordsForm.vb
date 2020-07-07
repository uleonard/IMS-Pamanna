Imports System.Data
Imports System.Data.OleDb
Public Class SalesRecordsForm

    Private Sub SalesRecordsForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        If UserTable.role = "MANAGER" Then
            btnDelete.Enabled = True
            'btnEditBatch.Enabled = True
            btnEdit.Enabled = True

        End If


        Dim yr As Integer
        For yr = 2014 To Year(Date.Now)
            comYear.Items.Add(yr)
        Next
        comYear.Text = Year(Date.Now)
        Dim mon As Integer = Month(Date.Now)

        comMonth.Text = MonthName(mon)

        'POPULATE PRODUCTS INTO PRODUCT COMBO BOX
        Dim ds As DataSet = New DataSet
        Dim da As OleDbDataAdapter

        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [product_code], [name] FROM product ORDER BY [name]", myConnection)
        da.Fill(ds, "product")


        comProduct.Items.Add("All Products")
        For i = 0 To ds.Tables("product").Rows.Count - 1

            comProduct.Items.Add(ds.Tables("product").Rows(i).Item(1) & " | " & ds.Tables("product").Rows(i).Item(0))
        Next
        myConnection.Close()

        comProduct.SelectedIndex = 0


        LoadDataGridByYearAndMonth()

        dgvSales.Columns("PRODUCT PLU").DefaultCellStyle.Format = "n0"
        dgvSales.Columns("SALES DATE").DefaultCellStyle.Format = "d"
        dgvSales.Columns("DATE ENTERED").DefaultCellStyle.Format = "g"
        dgvSales.Columns("DATE_MODIFIED").DefaultCellStyle.Format = "g"
        dgvSales.Columns("ID").Visible = False
    End Sub
    Public Sub LoadDataGridByYearAndMonth()
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim month As String = "%"
        If comMonth.SelectedIndex > 0 Then
            month = comMonth.Text
        End If

        Dim productCode As String = "%"
        If comProduct.SelectedIndex > 0 Then
            productCode = MainModule.splitProduct(comProduct.Text)
        End If

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT s.sales_id AS [ID], s.sales_date AS [SALES DATE], p.name AS [PRODUCT NAME], p.product_code AS [PRODUCT CODE], p.plu_code AS [PRODUCT PLU],  s.quantity AS [QUANTITY], s.ref_number AS [REF NUMBER], s.unit_price AS [UNIT PRICE], s.gross_sales AS [GROSS SALES], s.vat AS [VAT], s.sales AS [NET SALES], s.description AS [DESCRIPTION], s.entered_by AS [ENTERED BY], s.date_entered AS [DATE ENTERED], s.modified_by AS MODIFIED_BY, s.date_modified AS [DATE_MODIFIED] FROM sales s INNER JOIN product p ON s.product=p.product_code WHERE [year] = ? AND [month] LIKE ? AND product_code LIKE ?", myConnection)
        cmd.Parameters.Add(New OleDbParameter("year", CType(comYear.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("month", CType(month, String)))
        cmd.Parameters.Add(New OleDbParameter("product_code", CType(productCode, String)))


        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)


        dgvSales.AutoGenerateColumns = True
        dgvSales.DataSource = dt
        dgvSales.Refresh()
        dgvSales.AllowUserToAddRows = False

        reader.Close()
        myConnection.Close()

        btnEditBatch.Enabled = False
        txtRefNumber.Text = ""

        TotalSales()
    End Sub

    Private Sub comMonth_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles comMonth.SelectedIndexChanged
        LoadDataGridByYearAndMonth()
    End Sub

    Private Sub comYear_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles comYear.SelectedIndexChanged
        LoadDataGridByYearAndMonth()
    End Sub
    Public Sub LoadDataGridBySearch()
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT s.sales_id AS [ID], s.sales_date AS [SALES DATE], p.name AS [PRODUCT NAME], p.product_code AS [PRODUCT CODE], p.plu_code AS [PRODUCT PLU],  s.quantity AS [QUANTITY], s.ref_number AS [REF NUMBER], s.unit_price AS [UNIT PRICE], s.gross_sales AS [GROSS SALES], s.vat AS [VAT], s.sales AS [NET SALES], s.description AS [DESCRIPTION], s.entered_by AS [ENTERED BY], s.date_entered AS [DATE ENTERED], s.modified_by AS MODIFIED_BY, s.date_modified AS [DATE_MODIFIED] FROM sales s INNER JOIN product p ON s.product=p.product_code WHERE [ref_number] = ?", myConnection)
        cmd.Parameters.Add(New OleDbParameter("year", CType(txtRefNumber.Text, String)))

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)


        dgvSales.AutoGenerateColumns = True
        dgvSales.DataSource = dt
        dgvSales.Refresh()
        dgvSales.AllowUserToAddRows = False

        reader.Close()
        If dgvSales.Rows.Count > 0 And UserTable.role <> "CLERK" Then
            btnEditBatch.Enabled = True
        End If

        TotalSales()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        txtRefNumber.Text = txtRefNumber.Text.ToUpper
        LoadDataGridBySearch()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        AddSalesForm.ShowDialog()

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Not dgvSales.SelectedCells.Count > 0 Then
            MsgBox("Select Row first.")
            Exit Sub

        End If
        EditSalesRecordForm.ShowDialog()

    End Sub

    Private Sub txtRefNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRefNumber.TextChanged
        btnEditBatch.Enabled = False

    End Sub

    Private Sub TotalSales()
        'Calculate and display Totals
        Dim TotalGross As Double = 0
        Dim TotalVat As Double = 0
        Dim TotalNet As Double = 0
        For i As Integer = 0 To dgvSales.RowCount - 1
            TotalGross += dgvSales.Rows(i).Cells("GROSS SALES").Value
            TotalVat += dgvSales.Rows(i).Cells("VAT").Value
            TotalNet += dgvSales.Rows(i).Cells("NET SALES").Value
        Next
        txtTotalGrossSales.Text = Format(TotalGross, "Standard")
        txtTotalvat.Text = Format(TotalVat, "Standard")
        'txtTotalnetSales.Text = Format(TotalNet, "Standard")
        txtTotalNetSales.Text = Format(TotalGross - TotalVat, "Standard")
    End Sub

    Private Sub SalesRecordsForm_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize
        Panel2.Left = 20
        Panel2.Width = Me.Width - 60
        Panel2.Height = Me.Height - 200
        Panel1.Top = Panel2.Height + 70
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Dim defaultName As String
        If txtRefNumber.Text = "" Then
            defaultName = "Sales for " & Me.splitProduct() & " " & comMonth.Text & " " & comYear.Text
        Else
            defaultName = "Sales for Ref Number " & txtRefNumber.Text
        End If

        Export(dgvSales, defaultName)

    End Sub
    Private Function splitProduct() As String

        'Splitting  combo box item into the product id and product name
        Dim strCom As Array = comProduct.Text.Split("|")

        Return Trim(strCom(0).ToString) 'PRODUCT CODE

    End Function

    Private Sub comProduct_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles comProduct.SelectedIndexChanged
        LoadDataGridByYearAndMonth()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Not dgvSales.SelectedCells.Count > 0 Then
            MsgBox("Select Row first.")
            Exit Sub

        End If

        Dim res As DialogResult = MsgBox("You have selected to delete a sales record for " & _
                                         dgvSales.Rows(dgvSales.CurrentCell.RowIndex).Cells("PRODUCT NAME").Value & _
                                          " With Ref Number " & _
                                          dgvSales.Rows(dgvSales.CurrentCell.RowIndex).Cells("REF NUMBER").Value & vbCrLf & "IS THIS IN ORDER ?", vbYesNo + MsgBoxStyle.Question, "Inventory Management System")
        If res = vbNo Then
            Exit Sub
        End If


        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()


        Dim str As String
        str = "DELETE FROM sales WHERE [product]=? AND  [ref_number]=?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(dgvSales.Rows(dgvSales.CurrentCell.RowIndex).Cells("PRODUCT CODE").Value, String)))
        cmd.Parameters.Add(New OleDbParameter("ref_number", CType(dgvSales.Rows(dgvSales.CurrentCell.RowIndex).Cells("REF NUMBER").Value, String)))

        Try
            cmd.ExecuteNonQuery()
            MsgBox("Sales record deleted")

            'dgvSales.Rows.RemoveAt((dgvSales.CurrentCell.RowIndex))

            txtRefNumber.Text = dgvSales.Rows(dgvSales.CurrentCell.RowIndex).Cells("REF NUMBER").Value
            LoadDataGridBySearch()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub


    Private Sub btnEditBatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditBatch.Click
        EditSalesForm.ShowDialog()

    End Sub
End Class