Imports System.Data
Imports System.Data.OleDb
Public Class SuppliersForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim myConnection2 As OleDbConnection = New OleDbConnection
    Dim ds2 As DataSet = New DataSet
    Dim da2 As OleDbDataAdapter
    Dim source1 As New BindingSource()
    Dim source2 As New BindingSource()

    Private SuppliersBindingSource As New BindingSource()
    Private SupplierTransactionsBindingSource As New BindingSource()
    Private Sub SuppliersForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadSuppliers()

        If UserTable.role = "MANAGER" Or UserTable.role = "SUPERUSER" Then
            btnDelete.Enabled = True
        End If

        'FORMAT DATE COLUMNS
        dgvSupplierTransactions.Columns("PURCHASE DATE").DefaultCellStyle.Format = "d"
        dgvSupplierTransactions.Columns("DATE ENTERED").DefaultCellStyle.Format = "g"
        dgvSupplierTransactions.Columns("DATE PAID").DefaultCellStyle.Format = "D"
        dgvSupplierTransactions.Columns("PAYMENT DUE").DefaultCellStyle.Format = "D"

    End Sub
    Public Sub LoadSuppliers()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT * FROM supplier WHERE status='Active' ORDER BY [name]", myConnection)
        da.Fill(ds, "supplier")

        Dim view1 As New DataView(ds.Tables("supplier"))
        source1.DataSource = view1
        dgvSuppliers.DataSource = view1

        myConnection.Close()

    End Sub

    

    Private Sub SuppliersForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        pnlTransactions.Width = Me.Width - pnlTransactions.Left - 50
    End Sub

    Private Sub TextBox1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.Enter
        If txtSearch.Text = "Search Supplier Here" Then
            txtSearch.Text = ""
            txtSearch.ForeColor = Color.Black
        End If

    End Sub

    Private Sub txtSearch_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSearch.Leave
        If txtSearch.Text = "" Then
            txtSearch.Text = "Search Supplier Here"
            txtSearch.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If Not txtSearch.Text = "Search Supplier Here" Then
            source1.Filter = "[name] LIKE '%" & txtSearch.Text & "%'" & " OR [contact_person] LIKE '%" & txtSearch.Text & "%'"
            dgvSuppliers.Refresh()
        End If
        If dgvSuppliers.RowCount > 0 Then
            dgvSuppliers.Rows(0).Selected = True
            Trasactions()
        Else

            lblSupplier.Text = ""
        End If

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        AddSuppliesForm.ShowDialog()

    End Sub


    Private Sub dgvSuppliers_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvSuppliers.Click
        Trasactions()

    End Sub

 
    Public Sub Trasactions()
        Dim dbCon As DbConnection = New DbConnection()
        'If myConnection.State = ConnectionState.Open Then
        '    myConnection.Close()

        'End If
        myConnection2.ConnectionString = dbCon.dbConnector()
        myConnection2.Open()
        ds2.Reset()
        lblSupplier.Text = ""
        If dgvSuppliers.SelectedCells.Count > 0 Then
            lblSupplier.Text = dgvSuppliers.Rows(dgvSuppliers.CurrentCell.RowIndex).Cells(0).Value
        End If
        Dim grn As String = txtSearchGRN.Text
        If grn = "" Then
            grn = "%"
        End If
        da2 = New OleDbDataAdapter("SELECT pc.purchase_id AS [ID], p.name AS [NAME], p.product_code AS [CODE], pc.purchase_date AS [PURCHASE DATE], pc.quantity AS [QTY], pc.unit_cost AS [UNIT COST], pc.gross_cost AS [COST], pc.grn AS [GRN], pc.payment_due AS [PAYMENT DUE], pc.payment_status AS [PAYMENT STATUS], pc.payment_receipt_number AS [RECEIPT], pc.date_paid AS [DATE PAID], pc.entered_by AS [ENTERED BY], pc.date_entered AS [DATE ENTERED],pc.description AS [DESCRIPTION] FROM purchases pc INNER JOIN product p ON pc.product=p.product_code WHERE pc.supplied_by = '" & lblSupplier.Text & "' AND pc.status = 'ACTIVE' AND pc.grn LIKE '" & grn & "' ORDER BY [pc.grn] DESC, [pc.product] ASC", myConnection)
        da2.Fill(ds2, "purchases")

        Dim view2 As New DataView(ds2.Tables("purchases"))
        source2.DataSource = view2
        dgvSupplierTransactions.DataSource = view2
        myConnection2.Close()
        comViewRecords.SelectedIndex = 0

        Dim p As PurchasesTable = New PurchasesTable()
        Dim balance As Double = p.GetCurrentBalance(lblSupplier.Text)
        txtcurrentBalance.Text = Format(balance, "Standard")
        If balance = 0 Then
            btnPay.Enabled = False
        Else
            btnPay.Enabled = True
        End If
        dgvSupplierTransactions.Columns(0).Visible = False
        btnReturnOut.Enabled = False

        

    End Sub


    Private Sub dgvSuppliers_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvSuppliers.KeyUp
        Trasactions()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        'source2.Filter = "[grn] LIKE '" & txtSearchGRN.Text & "'"
        'dgvSupplierTransactions.Refresh()
        'If dgvSupplierTransactions.Rows.Count > 0 Then
        '    btnReturnOut.Enabled = True
        'Else
        '    btnReturnOut.Enabled = False
        'End If

        SearchGRN()
        If dgvSupplierTransactions.Rows.Count > 0 Then
            btnReturnOut.Enabled = True
        Else
            btnReturnOut.Enabled = False
        End If

    End Sub
    Public Sub SearchGRN()
        Dim dbCon As DbConnection = New DbConnection()
        'If myConnection.State = ConnectionState.Open Then
        '    myConnection.Close()

        'End If
        myConnection2.ConnectionString = dbCon.dbConnector()
        myConnection2.Open()
        ds2.Reset()
        lblSupplier.Text = ""
        If dgvSuppliers.SelectedCells.Count > 0 Then
            lblSupplier.Text = dgvSuppliers.Rows(dgvSuppliers.CurrentCell.RowIndex).Cells(0).Value
        End If
        Dim grn As String = txtSearchGRN.Text

        da2 = New OleDbDataAdapter("SELECT pc.purchase_id AS [ID], p.name AS [NAME], p.product_code AS [CODE], pc.purchase_date AS [PURCHASE DATE], pc.quantity AS [QTY], pc.unit_cost AS [UNIT COST], pc.gross_cost AS [COST], pc.grn AS [GRN], pc.payment_due AS [PAYMENT DUE], pc.payment_status AS [PAYMENT STATUS], pc.payment_receipt_number AS [RECEIPT], pc.date_paid AS [DATE PAID], pc.entered_by AS [ENTERED BY], pc.date_entered AS [DATE ENTERED],pc.description AS [DESCRIPTION] FROM purchases pc INNER JOIN product p ON pc.product=p.product_code WHERE pc.grn = '" & grn & "' ORDER BY [pc.grn] DESC, [pc.product] ASC", myConnection)
        da2.Fill(ds2, "purchases")

        Dim view2 As New DataView(ds2.Tables("purchases"))
        source2.DataSource = view2
        dgvSupplierTransactions.DataSource = view2
        myConnection2.Close()
        comViewRecords.SelectedIndex = 0

        Dim p As PurchasesTable = New PurchasesTable()
        Dim balance As Double = p.GetCurrentBalance(lblSupplier.Text)
        txtcurrentBalance.Text = Format(balance, "Standard")
        If balance = 0 Then
            btnPay.Enabled = False
        Else
            btnPay.Enabled = True
        End If
        dgvSupplierTransactions.Columns(0).Visible = False
        btnReturnOut.Enabled = False



    End Sub

    Private Sub comViewRecords_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comViewRecords.SelectedIndexChanged
        If comViewRecords.Text = "All" Then
            source2.Filter = "[PAYMENT STATUS] LIKE '%'"
        Else
            source2.Filter = "[PAYMENT STATUS] = '" & comViewRecords.Text & "'"
        End If
        dgvSupplierTransactions.Refresh()
        btnReturnOut.Enabled = False

    End Sub

 

    Private Sub btnNewSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewSupplier.Click
        NewSupplierForm.ShowDialog()

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EditSupplierForm.ShowDialog()

    End Sub

    Private Sub btnExportSuppliers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportSuppliers.Click
        Dim defaultName As String = "Pa-manna - Suppliers"
        Export(dgvSuppliers, defaultName)
        
    End Sub
    

    Private Sub btnExportSupplies_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportSupplies.Click
        Dim defaultName As String = "Pa-manna - " & lblSupplier.Text
        Export(dgvSupplierTransactions, defaultName)
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If pnlExport.Visible = True Then
            pnlExport.Visible = False
        Else
            pnlExport.Visible = True
        End If
    End Sub

    Private Sub btnPay_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPay.Click
        PaySupplierForm.ShowDialog()
    End Sub

    Private Sub dgvSuppliers_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSuppliers.RowEnter
        Trasactions()

    End Sub

  
    Private Sub btnReturnOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnOut.Click
        ReturnsOutForm.ShowDialog()

    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        'If dgvSupplierTransactions.Rows(dgvSupplierTransactions.CurrentCell.RowIndex).Cells("PAYMENT STATUS").Value() = "Paid" Then
        'MsgBox("You cannot delete a transaction with 'Paid' payment status")
        ' Exit Sub

        'End If
        Dim res As MsgBoxResult = MsgBox("You are about to delete a transaction with the following details:" & vbCrLf & _
                                            "Type                   : Cash Purchase" & vbCrLf & _
                                            "Date                   : " & dgvSupplierTransactions.Rows(dgvSupplierTransactions.CurrentCell.RowIndex).Cells("PURCHASE DATE").Value() & vbCrLf & _
                                            "Product                : " & dgvSupplierTransactions.Rows(dgvSupplierTransactions.CurrentCell.RowIndex).Cells("CODE").Value() & vbCrLf & _
                                            "GRN                    : " & dgvSupplierTransactions.Rows(dgvSupplierTransactions.CurrentCell.RowIndex).Cells("GRN").Value() & vbCrLf & _
                                            "Quantity               : " & dgvSupplierTransactions.Rows(dgvSupplierTransactions.CurrentCell.RowIndex).Cells("QTY").Value() & vbCrLf & _
                                            "Cost                   : MK" & Format(dgvSupplierTransactions.Rows(dgvSupplierTransactions.CurrentCell.RowIndex).Cells("COST").Value(), "Standard") & vbCrLf & _
                                            "Description            : " & dgvSupplierTransactions.Rows(dgvSupplierTransactions.CurrentCell.RowIndex).Cells("DESCRIPTION").Value() & vbCrLf & vbCrLf & _
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
        cmd.Parameters.Add(New OleDbParameter("purchase_id", CType(dgvSupplierTransactions.Rows(dgvSupplierTransactions.CurrentCell.RowIndex).Cells("ID").Value(), String)))

        Try
            cmd.ExecuteNonQuery()
            MsgBox("Transaction deleted.")
            'txtSearchGRN.Text = dgvSupplierTransactions.Rows(dgvSupplierTransactions.CurrentCell.RowIndex).Cells("GRN").Value()
            Trasactions()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub

   
    Private Sub btnNotActiveSuppliers_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotActiveSuppliers.Click
        NotActiveSuppliersForm.ShowDialog()

    End Sub
End Class