Public Class VoidStockForm

    Private Sub VoidStockForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub


    Private Sub VoidStockForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtID.Text = PurchasesForm.dgvPurchases.Rows(PurchasesForm.dgvPurchases.CurrentCell.RowIndex).Cells(0).Value.ToString
        dtpDate.Text = PurchasesForm.dgvPurchases.Rows(PurchasesForm.dgvPurchases.CurrentCell.RowIndex).Cells(1).Value.ToString
        txtQuantity.Text = PurchasesForm.dgvPurchases.Rows(PurchasesForm.dgvPurchases.CurrentCell.RowIndex).Cells(2).Value.ToString
        txtCost.Text = PurchasesForm.dgvPurchases.Rows(PurchasesForm.dgvPurchases.CurrentCell.RowIndex).Cells(3).Value.ToString
        txtDescription.Text = PurchasesForm.dgvPurchases.Rows(PurchasesForm.dgvPurchases.CurrentCell.RowIndex).Cells(6).Value.ToString
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Dispose()
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click

        'Dim productCode As String = PurchasesForm.splitProduct()

        'Dim p As PurchasesTable = New PurchasesTable()
        'txtQuantity.Text = "-" & txtQuantity.Text
        'txtCost.Text = "-" & txtCost.Text
        '' p.AddPurchases(productCode, dtpDate.Text, txtQuantity.Text, txtCost.Text, txtDescription.Text)

        'p.loadDatagridPurchases(PurchasesForm.comYear.Text, PurchasesForm.comMonth.Text, productCode, PurchasesForm.comPurchaseType.Text)

        ''Update the voided record
        'p.UpdateVoidedPurchases(txtID.Text)

        'Me.Close()

    End Sub
End Class