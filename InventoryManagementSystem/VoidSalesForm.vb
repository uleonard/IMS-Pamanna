Public Class VoidSalesForm

    Private Sub VoidSalesForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub


    Private Sub VoidSalesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtID.Text = SalesForm.dgvSales.Rows(SalesForm.dgvSales.CurrentCell.RowIndex).Cells(0).Value.ToString
        dtpDate.Text = SalesForm.dgvSales.Rows(SalesForm.dgvSales.CurrentCell.RowIndex).Cells(1).Value.ToString
        txtQuantity.Text = SalesForm.dgvSales.Rows(SalesForm.dgvSales.CurrentCell.RowIndex).Cells(2).Value.ToString
        txtUnitPrice.Text = SalesForm.dgvSales.Rows(SalesForm.dgvSales.CurrentCell.RowIndex).Cells(3).Value.ToString
        txtSales.Text = SalesForm.dgvSales.Rows(SalesForm.dgvSales.CurrentCell.RowIndex).Cells(4).Value.ToString
        txtDescription.Text = SalesForm.dgvSales.Rows(SalesForm.dgvSales.CurrentCell.RowIndex).Cells(7).Value.ToString
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click

        Dim productCode As String = SalesForm.splitProduct()

        Dim s As SalesTable = New SalesTable()
        txtQuantity.Text = "-" & txtQuantity.Text
        txtSales.Text = "-" & txtSales.Text
        's.AddSales(productCode, dtpDate.Text, txtUnitPrice.Text, txtSales.Text, txtDescription.Text)

        s.loadDatagridSales(SalesForm.comYear.Text, SalesForm.comMonth.Text, productCode)

        'Update the voided record
        s.UpdateVoidedSales(txtID.Text)

        Me.Close()
    End Sub
End Class