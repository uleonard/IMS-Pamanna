Public Class ReturnsInForm

    Private Sub ReturnsInForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub

    Private Sub ReturnsInForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim yr As Integer
        For yr = 2014 To Year(Date.Now)
            comYear.Items.Add(yr)
        Next
        comYear.Text = Year(Date.Now)
        Dim mon As Integer = Month(Date.Now)

        comMonth.Text = MonthName(mon)

        Dim productCode As String = SalesForm.splitProduct()

        Dim s As SalesTable = New SalesTable()
        s.loadDatagridReturnsIn(comYear.Text, comMonth.Text, productCode) 'load the datagrid

        lblProduct.Text = SalesForm.lblProduct.Text

        dtpDate.MaxDate = Date.Now 'set the maximum date that can be picked
        dtpDate.Text = Date.Now ' set the default date to current date
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Val(txtQuantity.Text) <= 0 Or Val(txtSales.Text) <= 0) Then
            MsgBox("Quantity or Sales Value can't be empty.")
            Exit Sub
        End If

        Dim productCode As String = SalesForm.splitProduct()

        Dim s As SalesTable = New SalesTable()
        s.AddReturnsIn(productCode, dtpDate.Text, txtQuantity.Text, txtSales.Text, txtDescription.Text)

        txtSales.Text = ""
        txtQuantity.Text = ""
        txtDescription.Text = ""

        s.loadDatagridReturnsIn(comYear.Text, comMonth.Text, productCode)

    End Sub

    Private Sub comMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comMonth.SelectedIndexChanged
        Dim productCode As String = SalesForm.splitProduct()

        Dim s As SalesTable = New SalesTable()
        s.loadDatagridReturnsIn(comYear.Text, comMonth.Text, productCode)
    End Sub

    Private Sub comYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comYear.SelectedIndexChanged
        Dim productCode As String = SalesForm.splitProduct()

        Dim s As SalesTable = New SalesTable()
        s.loadDatagridReturnsIn(comYear.Text, comMonth.Text, productCode)
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        txtSales.Text = Val(txtQuantity.Text) * Val(txtUnitPrice.Text)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Dispose()

    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If Not dgvReturnsIn.Rows.Count > 0 Then
            MsgBox("No records available")
            Exit Sub
        End If
        If Val(dgvReturnsIn.Rows(dgvReturnsIn.CurrentCell.RowIndex).Cells(2).Value) < 0 Or dgvReturnsIn.Rows(dgvReturnsIn.CurrentCell.RowIndex).Cells(7).Value.ToString = "VOIDED" Then
            MsgBox("You cannot void selected record")
            Exit Sub
        End If

        VoidReturnsInForm.ShowDialog()

    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        Dim monInt As Integer = Month(CType(dtpDate.Text, Date))
        Dim mon As String = MonthName(monInt)
        Dim yr As Integer = Year(CType(dtpDate.Text, Date))

        Dim productCode As String = SalesForm.splitProduct()

        Dim s As SalesTable = New SalesTable()
        Dim unitPrice As Double = s.GetLastUnitPriceByProductPerMonth(yr, mon, productCode) 'get the unit cost for the last record
        txtUnitPrice.Text = unitPrice

        txtSales.Text = Val(txtQuantity.Text) * Val(txtUnitPrice.Text)
    End Sub
End Class