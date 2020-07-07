Imports System.Data
Imports System.Data.OleDb
Public Class ReturnsOutForm

    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter


    Private Sub ReturnsOutForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDate.MaxDate = Date.Now 'set the maximum date that can be picked
        dtpDate.Text = Date.Now ' set the default date to current date

        txtGRN.Text = SuppliersForm.dgvSupplierTransactions.Rows(SuppliersForm.dgvSupplierTransactions.CurrentCell.RowIndex).Cells("GRN").Value()

        DataGridView1.ColumnCount = 10
        DataGridView1.Columns(0).Name = "PRODUCT"
        DataGridView1.Columns(1).Name = "TOTAL (QTY)"
        DataGridView1.Columns(2).Name = "RETURNED (QTY)"
        DataGridView1.Columns(3).Name = "BALANCE (QTY)"
        DataGridView1.Columns(4).Name = "ID"
        DataGridView1.Columns(5).Name = "TOTAL COST (MWK)"
        DataGridView1.Columns(6).Name = "RETURNED COST (MWK)"
        DataGridView1.Columns(7).Name = "VAT"
        DataGridView1.Columns(8).Name = "DESCRIPTION"
        DataGridView1.Columns(9).Name = "RETURNED_CURRENT" 'F or checking purposes

        'SET Unit Cost Column a READONLY
        DataGridView1.Columns(0).ReadOnly = True
        DataGridView1.Columns(1).ReadOnly = True
        DataGridView1.Columns(3).ReadOnly = True
        DataGridView1.Columns(5).ReadOnly = True
        DataGridView1.Columns(6).ReadOnly = True
        DataGridView1.Columns(7).ReadOnly = True



        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(9).Visible = False

        LoadDataGrid()
        DataGridView1.AllowUserToAddRows = False
    End Sub
    Private Sub LoadDataGrid()
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT pc.product, p.name, pc.quantity, pc.purchase_id, pc.gross_cost,pc.vat,r.description FROM (purchases pc INNER JOIN product p ON pc.product=p.product_code) LEFT JOIN returns_out r ON pc.purchase_id=r.purchase WHERE pc.grn = '" & txtGRN.Text & "'", myConnection)
        da.Fill(ds, "product")

        For i = 0 To ds.Tables("product").Rows.Count - 1
            Dim ReturnedStock As Double = 0
            If txtRefNumber.Text = "" Then
                ReturnedStock = GetReturned(ds.Tables("product").Rows(i).Item(3))
            End If
            Dim TotalStock As Double = ds.Tables("product").Rows(i).Item(2)
            Dim Balance As Double = TotalStock - ReturnedStock

            Dim Cost As Double = ds.Tables("product").Rows(i).Item(4)
            Dim ReturnCost As Double = (Cost / TotalStock) * ReturnedStock
            Dim description As String = ""
            If IsDBNull(ds.Tables("product").Rows(i).Item(6)) = False Then
                description = ds.Tables("product").Rows(i).Item(6)
            End If

            Dim row As String() = New String() {ds.Tables("product").Rows(i).Item(1), TotalStock, ReturnedStock, Balance, ds.Tables("product").Rows(i).Item(3), Cost, ReturnCost, ds.Tables("product").Rows(i).Item(5), description, ReturnedStock}
            DataGridView1.Rows.Add(row)
        Next
        myConnection.Close()
    End Sub
    Private Function GetReturned(ByVal purchase As Integer) As Double
        Dim connection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        connection.ConnectionString = dbCon.dbConnector()
        connection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT r.quantity FROM returns_out r INNER JOIN purchases pc ON r.purchase=pc.purchase_id WHERE pc.grn = ? AND r.purchase = ? ", connection)
        cmd.Parameters.Add(New OleDbParameter("grn", CType(txtGRN.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("product", CType(purchase, String)))

        Return cmd.ExecuteScalar()
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()

    End Sub

    

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(3).Value() = DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(1).Value() - Val(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(2).Value())
        DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(6).Value() = (DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(5).Value() / DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(1).Value()) * Val(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(2).Value())

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        DataGridView1.AllowUserToAddRows = False

        
        If DataGridView1.RowCount() = 0 Then
            MsgBox("No records found")
            Exit Sub
        End If


        Dim connection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        connection.ConnectionString = dbCon.dbConnector()
        connection.Open()

        Dim monInt As Integer = Month(CType(dtpDate.Text, Date))
        Dim monName As String = MonthName(monInt)
        Dim yr As Integer = Year(CType(dtpDate.Text, Date))
        For i As Integer = 0 To DataGridView1.RowCount() - 1
          
            Dim cmd As OleDbCommand
            If DataGridView1.Rows(i).Cells(9).Value() = 0 And DataGridView1.Rows(i).Cells(2).Value() > 0 Then 'returned_current vs returned

                
                Dim str As String
                str = "INSERT INTO returns_out ([purchase], [returns_out_date], [year], [month], [quantity], [cost], [description], [vat], [entered_by], [date_entered]) values (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)"
                cmd = New OleDbCommand(str, connection)
                cmd.Parameters.Add(New OleDbParameter("purchase", CType(DataGridView1.Rows(i).Cells("ID").Value(), String)))
                cmd.Parameters.Add(New OleDbParameter("returns_out_date", CType(dtpDate.Text, String)))
                cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
                cmd.Parameters.Add(New OleDbParameter("month", CType(monName, String)))
                cmd.Parameters.Add(New OleDbParameter("quantity", CType(DataGridView1.Rows(i).Cells(2).Value(), String)))
                cmd.Parameters.Add(New OleDbParameter("cost", CType(DataGridView1.Rows(i).Cells(6).Value(), String)))
                cmd.Parameters.Add(New OleDbParameter("description", CType(DataGridView1.Rows(i).Cells("DESCRIPTION").Value(), String)))
                cmd.Parameters.Add(New OleDbParameter("vat", CType(0.165 * DataGridView1.Rows(i).Cells("VAT").Value(), String)))
                cmd.Parameters.Add(New OleDbParameter("entered_by", CType(UserTable.userId, String)))
                cmd.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))

            ElseIf DataGridView1.Rows(i).Cells(9).Value() > 0 And DataGridView1.Rows(i).Cells(2).Value() = 0 Then 'returned_current > 0 and returned visibled = 0 (opp of above state)

                Dim str As String
                str = "DELETE FROM returns_out WHERE purchase = ?"
                cmd = New OleDbCommand(str, connection)
                cmd.Parameters.Add(New OleDbParameter("purchase", CType(DataGridView1.Rows(i).Cells("ID").Value(), String)))

            Else

                Dim str As String
                str = "UPDATE returns_out SET [returns_out_date] = ?, [year] = ?, [month] = ?, [quantity] = ?, [cost] = ?, [description] = ?, [vat] = ?, [entered_by] = ?, [date_entered] = ? WHERE purchase = ?"
                cmd = New OleDbCommand(str, connection)
                cmd.Parameters.Add(New OleDbParameter("returns_out_date", CType(dtpDate.Text, String)))
                cmd.Parameters.Add(New OleDbParameter("year", CType(yr, String)))
                cmd.Parameters.Add(New OleDbParameter("month", CType(monName, String)))
                cmd.Parameters.Add(New OleDbParameter("quantity", CType(DataGridView1.Rows(i).Cells(2).Value(), String)))
                cmd.Parameters.Add(New OleDbParameter("cost", CType(DataGridView1.Rows(i).Cells(6).Value(), String)))
                cmd.Parameters.Add(New OleDbParameter("description", CType(DataGridView1.Rows(i).Cells("DESCRIPTION").Value(), String)))
                cmd.Parameters.Add(New OleDbParameter("vat", CType(0.165 * DataGridView1.Rows(i).Cells("VAT").Value(), String)))
                cmd.Parameters.Add(New OleDbParameter("entered_by", CType(UserTable.userId, String)))
                cmd.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))
                cmd.Parameters.Add(New OleDbParameter("purchase", CType(DataGridView1.Rows(i).Cells("ID").Value(), String)))

            End If
            Try
                cmd.ExecuteNonQuery()
                DataGridView1.Rows(i).Cells(9).Value() = DataGridView1.Rows(i).Cells(2).Value()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

        MsgBox("SAVED!!!")
        connection.Close()
    End Sub
End Class