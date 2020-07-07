Imports System.Data
Imports System.Data.OleDb
Public Class PaySupplierForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim source1 As New BindingSource()
    Dim myConnection2 As OleDbConnection = New OleDbConnection
    Dim ds2 As DataSet = New DataSet
    Dim da2 As OleDbDataAdapter
    Dim source2 As New BindingSource()
    Private Sub PaySupplierForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSupplier.Text = SuppliersForm.lblSupplier.Text

        dtpDate.MaxDate = Date.Now 'set the maximum date that can be picked
        dtpDate.Text = Date.Now ' set the default date to current date

        LoadData()
        AmountPayable()

    End Sub

    Private Sub comGRN_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comGRN.SelectedIndexChanged
        If comGRN.Text = "All" Then
            source2.Filter = "[GRN] LIKE '%'"
            btnSave.Enabled = False
        Else
            source2.Filter = "[GRN] = '" & comGRN.Text & "'"
            btnSave.Enabled = True
        End If
        dgvTransactions.Refresh()

        AmountPayable()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        SuppliersForm.Trasactions()
        Me.Dispose()


    End Sub
    Private Sub LoadData()
        If myConnection.State = ConnectionState.Open Then
            myConnection.Close()

        End If
        If myConnection2.State = ConnectionState.Open Then
            myConnection2.Close()

        End If

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        'myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT DISTINCT [grn]  FROM purchases WHERE [supplied_by] = '" & txtSupplier.Text & "' AND payment_status = 'Not Paid'", myConnection)
        da.Fill(ds, "purchases")

        comGRN.Items.Clear()

        comGRN.Items.Add("All")
        For i As Integer = 0 To ds.Tables("purchases").Rows.Count - 1
            comGRN.Items.Add(ds.Tables("purchases").Rows(i).Item(0))
        Next

        '*****LOAD THE DATAGRID****************
        Dim dbCon2 As DbConnection = New DbConnection()
        myConnection2.ConnectionString = dbCon.dbConnector()
        'myConnection.Open()
        ds2.Reset()

        da2 = New OleDbDataAdapter("SELECT pc.grn AS [GRN], p.name AS [PRODUCT], pc.gross_cost AS [COST]  FROM purchases pc INNER JOIN product p ON pc.product=p.product_code  WHERE [supplied_by] = '" & txtSupplier.Text & "' AND payment_status = 'Not Paid'", myConnection)
        da2.Fill(ds2, "purchases")
        Dim view1 As New DataView(ds2.Tables("purchases"))
        source2.DataSource = view1
        dgvTransactions.DataSource = view1

        comGRN.Text = "All"
        btnSave.Enabled = False

    End Sub
    Private Sub AmountPayable()
        Dim totalPayable As Double = 0
        For i As Integer = 0 To dgvTransactions.RowCount - 1
            totalPayable += dgvTransactions.Rows(i).Cells("COST").Value

        Next
        txtAmountPayable.Text = Format(totalPayable, "Standard")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtReceipt.Text = "" Or dtpDate.Text = "" Then
            MessageBox.Show("Receipt Number and and Date Paid cannot be empty. Enter Both!!!")
            Exit Sub
        End If

        If myConnection.State = ConnectionState.Open Then
            myConnection.Close()

        End If

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE purchases  SET payment_status = ?, payment_receipt_number = ?, date_paid = ?  WHERE grn = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("payment_status", CType("Paid", String)))
        cmd.Parameters.Add(New OleDbParameter("payment_receipt_number", CType(txtReceipt.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("date_paid", CType(dtpDate.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("grn", CType(comGRN.Text, String)))

        Try
            cmd.ExecuteNonQuery()
            MsgBox("Payment Saved!!!")
            LoadData()
            AmountPayable()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
End Class