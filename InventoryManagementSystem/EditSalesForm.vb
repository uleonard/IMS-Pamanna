Imports System.Data
Imports System.Data.OleDb
Public Class EditSalesForm

    Private Sub EditSalesForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SalesRecordsForm.LoadDataGridBySearch()
        Me.Dispose()
    End Sub

    Private Sub EditSalesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtRefNumber.Text = SalesRecordsForm.txtRefNumber.Text
        txtRefNumberCurrent.Text = txtRefNumber.Text
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT p.name AS [PRODUCT NAME], p.product_code AS [PRODUCT CODE], p.plu_code AS [PRODUCT PLU], s.unit_price AS [UNIT PRICE], s.quantity AS [QUANTITY], s.gross_sales AS [SALES], s.description FROM  product p INNER JOIN sales s ON p.product_code=s.product  WHERE s.ref_number = ?", myConnection)
        cmd.Parameters.Add(New OleDbParameter("ref_number", CType(txtRefNumber.Text, String)))

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)


        DataGridView1.AutoGenerateColumns = True
        DataGridView1.DataSource = dt
        DataGridView1.Refresh()
        DataGridView1.AllowUserToAddRows = False


        'SET Unit Cost Column a READONLY
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(2).ReadOnly = True

        reader.Close()

        TotalSales()

        If DataGridView1.Rows.Count > 0 Then
            dtpDate.Text = SalesRecordsForm.dgvSales.Rows(1).Cells("SALES DATE").Value
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Dim Qty As Double = Val(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("QUANTITY").Value())
        Dim Sales As Double = Val(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("SALES").Value())
        Dim UnitPrice As Double = Val(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("UNIT PRICE").Value())

        If UnitPrice <= 0 Or Qty < 0 Or Sales < 0 Then 'Enter a -ve number to clear an entry
            'MsgBox("Either Unit Price is 0.00 or invalid. Please Check!!!")
            DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("QUANTITY").Value = ""
            DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("SALES").Value() = ""
            Exit Sub
        End If

        If Sales > 0 Then
            DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("QUANTITY").Value() = Sales / UnitPrice 'QTY
        Else
            DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells("SALES").Value() = UnitPrice * Qty 'SALES
        End If
        TotalSales()
    End Sub


    Private Sub TotalSales()
        'Calculate and display Totals
        Dim Total As Double = 0
        For i As Integer = 0 To DataGridView1.RowCount - 1
            Total += Val(DataGridView1.Rows(i).Cells("SALES").Value)
        Next
        txtTotalSales.Text = Format(Total, "Standard")
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        'CHECK ALL MANDATORY FIELDS ARE ENTERED

        If txtRefNumber.Text = "" Then
            MsgBox("Enter Ref Number First")
            txtRefNumber.Focus()

            Exit Sub
        End If


        For i As Integer = 0 To DataGridView1.RowCount() - 1


            Dim product As String = DataGridView1.Rows(i).Cells(1).Value()
            Dim Qty As Double = Val(DataGridView1.Rows(i).Cells(4).Value())
            Dim Sales As Double = Val(DataGridView1.Rows(i).Cells(5).Value())
            Dim UnitPrice As Double = Val(DataGridView1.Rows(i).Cells(3).Value())
            Dim description As String = DataGridView1.Rows(i).Cells(6).Value()

            If description = "" Then
                description = "----"
            End If

            If Sales > 0 Then
                Dim s As SalesTable = New SalesTable()

                s.EditSales(product, dtpDate.Text, UnitPrice, Qty, Sales, description, txtRefNumber.Text, txtRefNumberCurrent.Text)
            End If

        Next

        Dim rs As MsgBoxResult = MsgBox("SAVED!!!" & vbCrLf & "Do you want to Export to excel ? ", vbYesNo + vbQuestion, "Inventory Management System")

        If rs = vbYes Then
            Dim defaultName As String = "Sales for Ref Number " & txtRefNumber.Text

            Export(DataGridView1, defaultName)
        End If


        txtRefNumberCurrent.Text = txtRefNumber.Text
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click, Me.FormClosing
        SalesRecordsForm.LoadDataGridBySearch()
        Me.Dispose()

    End Sub


End Class