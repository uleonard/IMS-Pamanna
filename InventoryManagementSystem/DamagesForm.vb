Imports System.Data
Imports System.Data.OleDb
Public Class DamagesForm

    Private Sub DamagesForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub

    Private Sub DamagesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Dim productCode As String = "%"

        Dim p As PurchasesTable = New PurchasesTable()

        p.loadDatagridDamages(comYear.Text, comMonth.Text, productCode) 'load the datagrid

        If UserTable.role = "MANAGER" Or UserTable.role = "SUPERUSER" Then
            btnEdit.Enabled = True
            btnDelete.Enabled = True

        End If

        'FORMAT DATE COLUMNS
        dgvDamages.Columns("DAMAGES DATE").DefaultCellStyle.Format = "d"
        dgvDamages.Columns("DATE ENTERED").DefaultCellStyle.Format = "g"

        'CALCULATE TOTAL COST
        Dim totalCost As Double = 0
        For i As Integer = 0 To dgvDamages.RowCount - 1
            totalCost += dgvDamages.Rows(i).Cells("COST").Value
        Next
        txtTotalCost.Text = Format(totalCost, "Standard")
    End Sub



    Private Sub comMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comMonth.SelectedIndexChanged
        txtRefNumber.Text = ""

        Dim productCode As String = "%"
        If comProduct.SelectedIndex > 0 Then
            productCode = MainModule.splitProduct(comProduct.Text)
        End If

        Dim p As PurchasesTable = New PurchasesTable()

        p.loadDatagridDamages(comYear.Text, comMonth.Text, productCode)
    End Sub

    Private Sub comYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comYear.SelectedIndexChanged
        txtRefNumber.Text = ""

        Dim productCode As String = "%"
        If comProduct.SelectedIndex > 0 Then
            productCode = MainModule.splitProduct(comProduct.Text)
        End If

        Dim p As PurchasesTable = New PurchasesTable()

        p.loadDatagridDamages(comYear.Text, comMonth.Text, productCode)

    End Sub



    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()

    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Not dgvDamages.Rows.Count > 0 Then
            MsgBox("No records available")
            Exit Sub
        End If
        If Val(dgvDamages.Rows(dgvDamages.CurrentCell.RowIndex).Cells(1).Value) < 0 Then
            MsgBox("You cannot void selected record")
            Exit Sub
        End If

        EditDamagesForm.ShowDialog()

    End Sub


    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        NewDamagesForm.ShowDialog()

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
       
        Search()
    End Sub
    Public Sub Search()
        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT d.damages_id AS [ID], d.damages_date AS [DAMAGES DATE], p.name AS [PRODUCT], d.ref_number AS [REF NUMBER], d.quantity AS [QUANTITY], d.unit_cost AS [UNIT COST], d.cost AS [COST], d.description AS [DESCRIPTION], d.entered_by AS [ENTERED BY], d.date_entered AS [DATE ENTERED] FROM damages d INNER JOIN product p ON p.product_code=d.product WHERE [ref_number] = ? AND d.status = ?", myConnection)
        cmd.Parameters.Add(New OleDbParameter("ref_number", CType(txtRefNumber.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("ACTIVE", String)))

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)

        dgvDamages.AutoGenerateColumns = True
        dgvDamages.DataSource = dt
        dgvDamages.Refresh()
        dgvDamages.AllowUserToAddRows = False

        dgvDamages.Columns(0).Visible = False

        reader.Close()

        myConnection.Close()

        'CALCULATE TOTAL COST
        Dim totalCost As Double = 0
        For i As Integer = 0 To dgvDamages.RowCount - 1
            totalCost += dgvDamages.Rows(i).Cells("COST").Value
        Next
        txtTotalCost.Text = Format(totalCost, "Standard")

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim res As MsgBoxResult = MsgBox("You are about to delete a transaction with the following details:" & vbCrLf & _
                                            "Date                   : " & dgvDamages.Rows(dgvDamages.CurrentCell.RowIndex).Cells(1).Value() & vbCrLf & _
                                            "Product                : " & dgvDamages.Rows(dgvDamages.CurrentCell.RowIndex).Cells(2).Value() & vbCrLf & _
                                            "Reference Number       : " & dgvDamages.Rows(dgvDamages.CurrentCell.RowIndex).Cells(3).Value() & vbCrLf & _
                                            "Quantity               : " & dgvDamages.Rows(dgvDamages.CurrentCell.RowIndex).Cells(4).Value() & vbCrLf & _
                                            "Cost                   : MK " & Format(dgvDamages.Rows(dgvDamages.CurrentCell.RowIndex).Cells("COST").Value(), "Standard") & vbCrLf & _
                                            "Description            : " & dgvDamages.Rows(dgvDamages.CurrentCell.RowIndex).Cells("DESCRIPTION").Value() & vbCrLf & vbCrLf & _
                                            "IS THIS IN ORDER ? ", vbYesNo + vbQuestion, "IMS")
        If res = MsgBoxResult.No Then
            Exit Sub
        End If


        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE damages  SET status = ?  WHERE damages_id = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("status", CType("DELETED", String)))
        cmd.Parameters.Add(New OleDbParameter("purchase_id", CType(dgvDamages.Rows(dgvDamages.CurrentCell.RowIndex).Cells(0).Value(), String)))

        Try
            cmd.ExecuteNonQuery()
            MsgBox("Transaction deleted.")
            txtRefNumber.Text = dgvDamages.Rows(dgvDamages.CurrentCell.RowIndex).Cells(3).Value()
            Search()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()

    End Sub

    Private Sub comProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comProduct.SelectedIndexChanged
        Dim productCode As String = "%"
        If comProduct.SelectedIndex > 0 Then
            productCode = MainModule.splitProduct(comProduct.Text)
        End If

        Dim p As PurchasesTable = New PurchasesTable()

        p.loadDatagridDamages(comYear.Text, comMonth.Text, productCode)
    End Sub
End Class