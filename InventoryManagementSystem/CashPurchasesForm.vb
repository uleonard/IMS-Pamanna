Imports System.Data
Imports System.Data.OleDb
Public Class CashPurchasesForm

    Private Sub CashPurchasesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = MDIManager.Left + 15
        Me.Width = MDIManager.Width - 30
        Me.Height = MDIManager.Height - 200
        dgvPurchases.Width = Me.Width - 15

        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT TOP 1 internal_grn AS [GRN] FROM purchases WHERE purchase_type = ? ORDER BY purchase_id DESC", myConnection)
        cmd.Parameters.Add(New OleDbParameter("purchase_type", CType("Cash", String)))

        txtSearchGRN.Text = cmd.ExecuteScalar()
        Search()

        If UserTable.role = "MANAGER" Or UserTable.role = "SUPERUSER" Then
            btnDelete.Enabled = True

        End If

        dgvPurchases.Columns("PURCHASES DATE").DefaultCellStyle.Format = "d"
        dgvPurchases.Columns("DATE ENTERED").DefaultCellStyle.Format = "g"


        LoadProducts()

    End Sub
    Private Sub LoadProducts()
        Dim ds As DataSet = New DataSet
        Dim da As OleDbDataAdapter
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [product_code], [name] FROM product ORDER BY [name]", myConnection)
        da.Fill(ds, "product")

        For i = 0 To ds.Tables("product").Rows.Count - 1

            comProduct.Items.Add(ds.Tables("product").Rows(i).Item(1) & " | " & ds.Tables("product").Rows(i).Item(0))
        Next
        myConnection.Close()

        comProduct.SelectedIndex = 0
    End Sub
    Public Sub Search()
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT  p.name AS [NAME], p.product_code AS [CODE], pc.purchase_id AS [ID], pc.purchase_date AS [PURCHASES DATE], pc.quantity AS [QUANTITY], pc.unit_cost AS [UNIT COST], pc.gross_cost AS [COST], pc.internal_grn AS [GRN], pc.description AS [DESCRIPTION], pc.entered_by AS [ENTERED BY], pc.date_entered AS [DATE ENTERED], pc.void_status AS [VOID STATUS] FROM purchases pc INNER JOIN product p ON p.product_code=pc.product WHERE pc.internal_grn = ? AND pc.status = ?", myConnection)
        cmd.Parameters.Add(New OleDbParameter("internal_grn", CType(txtSearchGRN.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("ACTIVE", String)))

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)

        dgvPurchases.AutoGenerateColumns = True
        dgvPurchases.DataSource = dt
        dgvPurchases.Refresh()
        dgvPurchases.AllowUserToAddRows = False
        dgvPurchases.Columns("ID").Visible=False

        lblResults.Text = "Results for GRN : " & txtSearchGRN.Text
        reader.Close()

        myConnection.Close()

        'CALCULATE TOTAL COST FOR THIS GRN
        Dim totalCost As Double = 0
        For i As Integer = 0 To dgvPurchases.RowCount - 1
            totalCost += dgvPurchases.Rows(i).Cells("COST").Value
        Next
        txtTotalCost.Text = Format(totalCost, "Standard")

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Search()
    End Sub

 
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AddCashPurchasesForm.ShowDialog()

    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Dim res As MsgBoxResult = MsgBox("You are about to delete a transaction with the following details:" & vbCrLf & _
                                            "Type                   : Cash Purchase" & vbCrLf & _
                                            "Date                   : " & dgvPurchases.Rows(dgvPurchases.CurrentCell.RowIndex).Cells("PURCHASES DATE").Value() & vbCrLf & _
                                            "Product                : " & dgvPurchases.Rows(dgvPurchases.CurrentCell.RowIndex).Cells("CODE").Value() & vbCrLf & _
                                            "GRN                    : " & dgvPurchases.Rows(dgvPurchases.CurrentCell.RowIndex).Cells("GRN").Value() & vbCrLf & _
                                            "Quantity               : " & dgvPurchases.Rows(dgvPurchases.CurrentCell.RowIndex).Cells("QUANTITY").Value() & vbCrLf & _
                                            "Cost                   : MK" & Format(dgvPurchases.Rows(dgvPurchases.CurrentCell.RowIndex).Cells("COST").Value(), "Standard") & vbCrLf & _
                                            "Description            : " & dgvPurchases.Rows(dgvPurchases.CurrentCell.RowIndex).Cells("DESCRIPTION").Value() & vbCrLf & vbCrLf & _
                                            "IS THIS IN ORDER ? ", vbYesNo + vbQuestion, "Inventory management System")
        If res = MsgBoxResult.No Then
            Exit Sub
        End If


        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE purchases  SET status = ?  WHERE purchase_id = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("status", CType("DELETED", String)))
        cmd.Parameters.Add(New OleDbParameter("purchase_id", CType(dgvPurchases.Rows(dgvPurchases.CurrentCell.RowIndex).Cells("ID").Value(), String)))

        Try
            cmd.ExecuteNonQuery()
            MsgBox("Transaction deleted.")
            txtSearchGRN.Text = dgvPurchases.Rows(dgvPurchases.CurrentCell.RowIndex).Cells("GRN").Value()
            Search()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub

    Private Sub btnExportSupplies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportSupplies.Click
        Dim defaultName As String = "Cash Purchases with GRN " & txtSearchGRN.Text
        Export(dgvPurchases, defaultName)
    End Sub

    Private Sub btnSearchByDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByDate.Click
        SearchByDate()

    End Sub
    Public Sub SearchByDate()
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT  p.name AS [NAME], p.product_code AS [CODE], pc.purchase_id AS [ID], pc.purchase_date AS [PURCHASES DATE], pc.quantity AS [QUANTITY], pc.unit_cost AS [UNIT COST], pc.gross_cost AS [COST], pc.internal_grn AS [GRN], pc.description AS [DESCRIPTION], pc.entered_by AS [ENTERED BY], pc.date_entered AS [DATE ENTERED], pc.void_status AS [VOID STATUS] FROM purchases pc INNER JOIN product p ON p.product_code=pc.product WHERE pc.purchase_date = ? AND pc.status = ?", myConnection)
        cmd.Parameters.Add(New OleDbParameter("purchase_date", CType(dtpDate.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("ACTIVE", String)))

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)

        dgvPurchases.AutoGenerateColumns = True
        dgvPurchases.DataSource = dt
        dgvPurchases.Refresh()
        dgvPurchases.AllowUserToAddRows = False
        dgvPurchases.Columns("ID").Visible = False

        lblResults.Text = "Results for date : " & dtpDate.Text
        reader.Close()

        myConnection.Close()

        'CALCULATE TOTAL COST FOR THIS GRN
        Dim totalCost As Double = 0
        For i As Integer = 0 To dgvPurchases.RowCount - 1
            totalCost += dgvPurchases.Rows(i).Cells("COST").Value
        Next
        txtTotalCost.Text = Format(totalCost, "Standard")

    End Sub

    Private Sub btnSearchByProduct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchByProduct.Click
        SearchByProduct()

    End Sub
    Public Sub SearchByProduct()
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim productCode As String = MainModule.splitProduct(comProduct.Text)

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT  p.name AS [NAME], p.product_code AS [CODE], pc.purchase_id AS [ID], pc.purchase_date AS [PURCHASES DATE], pc.quantity AS [QUANTITY], pc.unit_cost AS [UNIT COST], pc.gross_cost AS [COST], pc.internal_grn AS [GRN], pc.description AS [DESCRIPTION], pc.entered_by AS [ENTERED BY], pc.date_entered AS [DATE ENTERED], pc.void_status AS [VOID STATUS] FROM purchases pc INNER JOIN product p ON p.product_code=pc.product WHERE p.product_code = ? AND pc.status = ? ORDER BY pc.purchase_date DESC", myConnection)
        cmd.Parameters.Add(New OleDbParameter("product_code", CType(productCode, String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("ACTIVE", String)))

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)

        dgvPurchases.AutoGenerateColumns = True
        dgvPurchases.DataSource = dt
        dgvPurchases.Refresh()
        dgvPurchases.AllowUserToAddRows = False
        dgvPurchases.Columns("ID").Visible = False

        lblResults.Text = "Results for product : " & comProduct.Text
        reader.Close()

        myConnection.Close()

        'CALCULATE TOTAL COST FOR THIS GRN
        Dim totalCost As Double = 0
        For i As Integer = 0 To dgvPurchases.RowCount - 1
            totalCost += dgvPurchases.Rows(i).Cells("COST").Value
        Next
        txtTotalCost.Text = Format(totalCost, "Standard")

    End Sub
End Class