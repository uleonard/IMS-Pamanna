Imports System.Data
Imports System.Data.OleDb
Public Class SalesForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Private Sub SalesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim yr As Integer
        For yr = 2014 To Year(Date.Now)
            comYear.Items.Add(yr)
        Next
        comYear.Text = Year(Date.Now)
        Dim mon As Integer = Month(Date.Now)

        comMonth.Text = MonthName(mon)


        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [product_code], [name] FROM product", myConnection)
        da.Fill(ds, "product")

        For i = 0 To ds.Tables("product").Rows.Count - 1

            comProduct.Items.Add(ds.Tables("product").Rows(i).Item(1) & " | " & ds.Tables("product").Rows(i).Item(0))
        Next
        myConnection.Close()

        comProduct.SelectedIndex = 0

        dtpDate.MaxDate = Date.Now 'set the maximum date that can be picked
        dtpDate.Text = Date.Now ' set the default date to current date

        Dim productCode As String = splitProduct()

        Dim s As SalesTable = New SalesTable()
        s.loadDatagridSales(comYear.Text, comMonth.Text, productCode)
    End Sub


    Private Sub comProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comProduct.SelectedIndexChanged
        Dim productCode As String = splitProduct()

        Dim s As SalesTable = New SalesTable()
        s.loadDatagridSales(comYear.Text, comMonth.Text, productCode)
    End Sub

    Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click

        comProduct.SelectedIndex = comProduct.Items.Count - 1
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        If (comProduct.SelectedIndex > 0) Then
            comProduct.SelectedIndex = comProduct.SelectedIndex - 1
        End If
    End Sub


    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If (comProduct.SelectedIndex < comProduct.Items.Count - 1) Then
            comProduct.SelectedIndex = comProduct.SelectedIndex + 1
        End If
    End Sub

    Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
        comProduct.SelectedIndex = 0
    End Sub

    Private Sub comMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comMonth.SelectedIndexChanged
        If (comProduct.SelectedIndex <> -1) Then
            Dim productCode As String = splitProduct()

            Dim s As SalesTable = New SalesTable()
            s.loadDatagridSales(comYear.Text, comMonth.Text, productCode)
        End If
    End Sub

    Private Sub comYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comYear.SelectedIndexChanged
        If (comProduct.SelectedIndex <> -1) Then
            Dim productCode As String = splitProduct()

            Dim s As SalesTable = New SalesTable()
            s.loadDatagridSales(comYear.Text, comMonth.Text, productCode)

        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Val(txtUnitPrice.Text) <= 0 Or Val(txtSales.Text) <= 0) Then
            MsgBox("Unit Price and Sales can't be empty or zero.")
            Exit Sub
        End If

        Dim productCode As String = splitProduct()

        Dim s As SalesTable = New SalesTable()
        's.AddSales(productCode, dtpDate.Text, txtUnitPrice.Text, txtSales.Text, txtDescription.Text)
        MsgBox("SAVED!!!")
        txtSales.Text = ""
        txtDescription.Text = ""


        s.loadDatagridSales(comYear.Text, comMonth.Text, productCode)
    End Sub
    Public Function splitProduct() As String

        'Splitting  combo box item into the product id and product name
        Dim strCom As Array = comProduct.Text.Split("|")

        lblProduct.Text = strCom(0).ToString.ToUpper

        Return Trim(strCom(1).ToString) 'PRODUCT CODE

    End Function

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
       
        If Not dgvSales.Rows.Count > 0 Then
            MsgBox("No record is selected")
            Exit Sub
        End If

        If Val(dgvSales.Rows(dgvSales.CurrentCell.RowIndex).Cells(2).Value) < 0 Or dgvSales.Rows(dgvSales.CurrentCell.RowIndex).Cells(10).Value.ToString = "VOIDED" Then
            MsgBox("You cannot void selected record")
            Exit Sub
        End If

        VoidSalesForm.ShowDialog()

    End Sub

    Private Sub txtExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExcel.Click
        'Set the Save dialog properties
        With SaveFileDialog1
            .DefaultExt = "txt"
            .FileName = Trim("Sales - " & lblProduct.Text.ToLower)
            .Filter = "Text Documents (*.csv)|*.csv|CSV (*.*)|*.*"
            .FilterIndex = 1
            .OverwritePrompt = True
            .Title = "Save As - Purchases"
        End With
        'Show the Save dialog and if the user clicks the Save button,
        'save the file

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try
                'Save the file path and name
                Dim strFileName As String = Nothing
                Dim content As String = getExportData()
                strFileName = SaveFileDialog1.FileName
                My.Computer.FileSystem.WriteAllText(strFileName, content, False)

                Dim res As MsgBoxResult
                res = MsgBox("Process completed, Would you like to open file now?", MsgBoxStyle.YesNo)
                If (res = MsgBoxResult.Yes) Then
                    Process.Start(strFileName)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
    Private Function getExportData() As String
        Dim content As String
        content = vbCrLf & vbCrLf & comYear.Text & " : " & comMonth.Text & ",,PRODUCT : ," & lblProduct.Text & " - " & splitProduct() & vbCrLf & vbCrLf
        content = content & "SALES DATE , QUANTITY , UNIT PRICE , GROSS SALES , VAT, NET SALES, DESCRIPTION , ENTERED BY , DATE ENTERED" & vbCrLf

        Dim i As Integer
        Dim j As Integer

        For i = 0 To dgvSales.RowCount - 1
            For j = 0 To dgvSales.ColumnCount - 1
                content = content & dgvSales(j, i).Value.ToString() & ","
            Next
            content = content & vbCrLf
        Next

        Return content
    End Function

    Private Sub txtSales_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSales.TextChanged
        Dim stock As Double = Format(Val(txtSales.Text) / Val(txtUnitPrice.Text), "0.00")
        If stock > Val(txtStockAvailable.Text) Then
            MsgBox("There is no enough stock. Make sure all stock is entered first" & vbCrLf & "Sales entered requires a minimum stock of " & stock & vbCrLf & " But only " & txtStockAvailable.Text & " available")
            txtSales.Text = ""
        End If

    End Sub

    Private Sub btnReturnsIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnsIn.Click
        ReturnsInForm.ShowDialog()

    End Sub

   
End Class