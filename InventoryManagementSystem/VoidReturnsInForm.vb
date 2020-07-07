Public Class VoidReturnsInForm

    Private Sub VoidReturnsInForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub

    Private Sub VoidReturnsInForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtID.Text = ReturnsInForm.dgvReturnsIn.Rows(ReturnsInForm.dgvReturnsIn.CurrentCell.RowIndex).Cells(0).Value.ToString
        dtpDate.Text = ReturnsInForm.dgvReturnsIn.Rows(ReturnsInForm.dgvReturnsIn.CurrentCell.RowIndex).Cells(1).Value.ToString
        txtQuantity.Text = ReturnsInForm.dgvReturnsIn.Rows(ReturnsInForm.dgvReturnsIn.CurrentCell.RowIndex).Cells(2).Value.ToString
        txtSales.Text = ReturnsInForm.dgvReturnsIn.Rows(ReturnsInForm.dgvReturnsIn.CurrentCell.RowIndex).Cells(3).Value.ToString
        txtDescription.Text = ReturnsInForm.dgvReturnsIn.Rows(ReturnsInForm.dgvReturnsIn.CurrentCell.RowIndex).Cells(4).Value.ToString
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        Dim productCode As String = SalesForm.splitProduct()

        Dim s As SalesTable = New SalesTable()
        txtQuantity.Text = "-" & txtQuantity.Text
        txtSales.Text = "-" & txtSales.Text

        s.AddReturnsIn(productCode, dtpDate.Text, txtQuantity.Text, txtSales.Text, txtDescription.Text)

        'Update the voided record
        s.UpdateVoidedReturnsin(txtID.Text)

        s.loadDatagridReturnsIn(ReturnsInForm.comYear.Text, ReturnsInForm.comMonth.Text, productCode)

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub
End Class