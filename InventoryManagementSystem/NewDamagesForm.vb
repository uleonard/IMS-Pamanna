Imports System.Data
Imports System.Data.OleDb
Public Class NewDamagesForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim comProducts As New DataGridViewComboBoxColumn()

    Private Sub NewDamagesForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub AddCashPurchasesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDate.MaxDate = Date.Now 'set the maximum date that can be picked
        dtpDate.Text = Date.Now ' set the default date to current date

        comProducts.HeaderText = "Product Code"
        comProducts.Name = "comProducts"
        comProducts.MaxDropDownItems = 4
        LoadProducts() 'ADD PRODUCTS INTO THE COMBO BOX
        DataGridView1.Columns.Add(comProducts)



        DataGridView1.ColumnCount = 5
        DataGridView1.Columns(1).Name = "Quantity"
        DataGridView1.Columns(2).Name = "Cost"
        DataGridView1.Columns(3).Name = "Unit Cost"
        DataGridView1.Columns(4).Name = "Description"

        'SET Unit Cost Column a READONLY
        DataGridView1.Columns(2).ReadOnly = True

    End Sub
    Private Sub LoadProducts()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [product_code], [name] FROM product ORDER BY [name]", myConnection)
        da.Fill(ds, "product")

        For i = 0 To ds.Tables("product").Rows.Count - 1

            comProducts.Items.Add(ds.Tables("product").Rows(i).Item(1) & " | " & ds.Tables("product").Rows(i).Item(0))
        Next
        myConnection.Close()
    End Sub
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim Qty As Double
        Dim UnitCost As Double
        If DataGridView1.CurrentCell.ColumnIndex = 3 Then

            UnitCost = Val(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(3).Value())
            'DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(3).Value() = UnitCost
            Qty = Val(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(1).Value())

            If Qty > 0 Then
                DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(2).Value() = UnitCost * Qty 'TOTAL COST
            End If

            Exit Sub
        End If

        Dim productCode As String = MainModule.splitProduct(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(0).Value())

        Dim monInt As Integer = Month(CType(dtpDate.Text, Date))
        Dim monName As String = MonthName(monInt)
        Dim yr As Integer = Year(CType(dtpDate.Text, Date))

        Dim p As PurchasesTable = New PurchasesTable()
        UnitCost = p.GetLastUnitCostByProductPerMonth(yr, monName, productCode)

        '============================START OF A REDUNDANT CODE TO GET UNIT PRICE=====================================
        Dim monthNum As Integer
        If UnitCost = 0 Then
            'GO BACK BY ONE MONTH TO GET UNIT COST
            monthNum = getMonthNumber(monName)

            If (monthNum = 1) Then
                monthNum = 12
                yr = yr - 1
            Else
                monthNum = monthNum - 1
            End If

            UnitCost = p.GetLastUnitCostByProductPerMonth(yr, MonthName(monthNum), productCode)
        End If
        'IF unit cost is still zero then go one step further
        If UnitCost = 0 Then
            'GO BACK BY ONE MONTH TO GET UNIT COST
            
            If (monthNum = 1) Then
                monthNum = 12
                yr = yr - 1
            Else
                monthNum = monthNum - 1
            End If

            UnitCost = p.GetLastUnitCostByProductPerMonth(yr, MonthName(monthNum), productCode)
        End If

        '============================END OF A REDUNDANT CODE TO GET UNIT PRICE=====================================

        DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(3).Value() = UnitCost
        Qty = Val(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(1).Value())

        If Qty > 0 Then
            DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(2).Value() = UnitCost * Qty 'TOTAL COST
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        DataGridView1.AllowUserToAddRows = False

        'CHECK ALL MANDATORY FIELDS ARE ENTERED

        If txtRefNumber.Text = "" Then
            MsgBox("Enter Ref Number First")
            DataGridView1.AllowUserToAddRows = True
            txtRefNumber.Focus()

            Exit Sub
        End If
        If DataGridView1.RowCount() = 0 Then
            MsgBox("No purchase is entered yet")
            DataGridView1.AllowUserToAddRows = True
            Exit Sub
        End If
        For i As Integer = 0 To DataGridView1.RowCount() - 1
            Dim product As String = DataGridView1.Rows(i).Cells(0).Value()
            Dim Qty As Double = Val(DataGridView1.Rows(i).Cells(1).Value())
            Dim Cost As Double = Val(DataGridView1.Rows(i).Cells(2).Value())

            If (product = "" Or Qty <= 0 Or Cost <= 0) Then
                MsgBox("Product Code, Quantity and Cost can't be empty.")
                DataGridView1.AllowUserToAddRows = True
                Exit Sub

            End If
        Next



        ' DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(0) 'RESETTING THE ROW CURSOR TO FIRST ROW

        For i As Integer = 0 To DataGridView1.RowCount() - 1
            Dim product As String = DataGridView1.Rows(i).Cells(0).Value()
            Dim Qty As Double = Val(DataGridView1.Rows(i).Cells(1).Value())
            Dim Cost As Double = Val(DataGridView1.Rows(i).Cells(2).Value())
            Dim description As String = DataGridView1.Rows(i).Cells(4).Value()
            If description = "" Then
                description = "----"
            End If
            If Not product = "" Then
                Dim productCode As String = MainModule.splitProduct(product)

                Dim p As PurchasesTable = New PurchasesTable()

                'p.AddPurchases(productCode, dtpDate.Text, Qty, Cost, description, txtGRN.Text, txtSupplier.Text, vbNull)

                p.AddDamages(productCode, dtpDate.Text, txtRefNumber.Text, Qty, Cost, description)
            End If
        Next
        MsgBox("SAVED!!!")
        DamagesForm.txtRefNumber.Text = txtRefNumber.Text
        DamagesForm.Search()
        Me.Dispose()


    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()

    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        DataGridView1.Rows.Clear()
    End Sub

   
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If Not DataGridView1.SelectedCells.Count > 0 Then
            Exit Sub
        End If
        If Not DataGridView1.CurrentRow.Index = DataGridView1.Rows.Count - 1 Then
            DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class