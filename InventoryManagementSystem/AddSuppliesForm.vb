Imports System.Data
Imports System.Data.OleDb
Public Class AddSuppliesForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim comProducts As New DataGridViewComboBoxColumn()

    Private Sub AddSuppliesForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub
    Private Sub AddSuppliesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        dtpDate.MaxDate = Date.Now 'set the maximum date that can be picked
        dtpDate.Text = Date.Now ' set the default date to current date

        txtSupplier.Text = SuppliersForm.lblSupplier.Text

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
        DataGridView1.Columns(3).ReadOnly = True

        If txtSupplier.Text = "" Then
            btnSave.Enabled = False
        End If

    End Sub
    Private Sub LoadProducts()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [product_code], [name] FROM product  ORDER BY [name]", myConnection)
        da.Fill(ds, "product")

        For i = 0 To ds.Tables("product").Rows.Count - 1

            comProducts.Items.Add(ds.Tables("product").Rows(i).Item(1) & " | " & ds.Tables("product").Rows(i).Item(0))
        Next
        myConnection.Close()
    End Sub

    'Private Sub DataGridView1_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
    '    Dim titleText As String = DataGridView1.Columns(5).HeaderText
    '    If titleText.Equals("Product") Then
    '        Dim autoText As TextBox = TryCast(e.Control, TextBox)
    '        If autoText IsNot Nothing Then
    '            autoText.AutoCompleteMode = AutoCompleteMode.Suggest
    '            autoText.AutoCompleteSource = AutoCompleteSource.CustomSource
    '            Dim DataCollection As New AutoCompleteStringCollection()
    '            addItems(DataCollection)
    '            autoText.AutoCompleteCustomSource = DataCollection
    '        End If
    '    End If
    'End Sub

    'Public Sub addItems(ByVal col As AutoCompleteStringCollection)

    '    Dim dbCon As DbConnection = New DbConnection()
    '    myConnection.ConnectionString = dbCon.dbConnector()
    '    myConnection.Open()

    '    da = New OleDbDataAdapter("SELECT [product_code], [name] FROM product", myConnection)
    '    da.Fill(ds, "product")

    '    For i = 0 To ds.Tables("product").Rows.Count - 1

    '        col.Add(ds.Tables("product").Rows(i).Item(1) & " | " & ds.Tables("product").Rows(i).Item(0))
    '    Next
    '    myConnection.Close()
    'End Sub

 

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter

        'If DataGridView1.CurrentCell.ColumnIndex = 3 Then
        '    Dim iCol As Integer = DataGridView1.CurrentCell.ColumnIndex + 1
        '    Dim iRow As Integer = DataGridView1.CurrentCell.RowIndex
        '    DataGridView1.CurrentCell = DataGridView1.Rows(iRow).Cells(4)
        'End If
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim Qty As Double = Val(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(1).Value())
        Dim cost As Double = Val(DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(2).Value())
        If Qty > 0 Then
            DataGridView1.Rows(DataGridView1.CurrentCell.RowIndex).Cells(3).Value() = cost / Qty 'UNIT COST
        End If
    End Sub

 

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        DataGridView1.AllowUserToAddRows = False

        'CHECK ALL MANDATORY FIELDS ARE ENTERED
        If dtpPaymentDate.Text = dtpDate.Text Then
            MsgBox("Purchase date and payment date cannot be the same")
            DataGridView1.AllowUserToAddRows = True
            dtpDate.Focus()

            Exit Sub
        End If

        If txtGRN.Text = "" Then
            MsgBox("Enter GRN First")
            DataGridView1.AllowUserToAddRows = True
            txtGRN.Focus()

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

        Dim InternalGRN As String = "----"
        Dim PaymentStatus As String = "Not Paid"
        Dim PaymentType As String = "Credit"

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
                
                p.AddPurchases(productCode, dtpDate.Text, Qty, Cost, description, txtGRN.Text, txtSupplier.Text, InternalGRN, PaymentType, PaymentStatus, dtpPaymentDate.Text)
            End If
        Next
        MsgBox("SAVED!!!")
        SuppliersForm.Trasactions()
        Me.Dispose()


    End Sub

   
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If Not DataGridView1.SelectedCells.Count > 0 Then
            Exit Sub
        End If
        If Not DataGridView1.CurrentRow.Index = DataGridView1.Rows.Count - 1 Then
            DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)
        End If
    End Sub
   
   
End Class