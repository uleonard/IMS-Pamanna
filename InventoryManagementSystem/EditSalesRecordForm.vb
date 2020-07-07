Public Class EditSalesRecordForm

    Private Sub EditSalesRecordForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDate.Text = SalesRecordsForm.dgvSales.Rows(SalesRecordsForm.dgvSales.CurrentCell.RowIndex).Cells("SALES DATE").Value()
        txtName.Text = SalesRecordsForm.dgvSales.Rows(SalesRecordsForm.dgvSales.CurrentCell.RowIndex).Cells("PRODUCT NAME").Value()
        txtCode.Text = SalesRecordsForm.dgvSales.Rows(SalesRecordsForm.dgvSales.CurrentCell.RowIndex).Cells("PRODUCT CODE").Value()
        txtPLU.Text = SalesRecordsForm.dgvSales.Rows(SalesRecordsForm.dgvSales.CurrentCell.RowIndex).Cells("PRODUCT PLU").Value()
        txtRefNumber.Text = SalesRecordsForm.dgvSales.Rows(SalesRecordsForm.dgvSales.CurrentCell.RowIndex).Cells("REF NUMBER").Value()
        txtQuantity.Text = SalesRecordsForm.dgvSales.Rows(SalesRecordsForm.dgvSales.CurrentCell.RowIndex).Cells("QUANTITY").Value()
        txtUnitPrice.Text = SalesRecordsForm.dgvSales.Rows(SalesRecordsForm.dgvSales.CurrentCell.RowIndex).Cells("UNIT PRICE").Value()
        txtSales.Text = SalesRecordsForm.dgvSales.Rows(SalesRecordsForm.dgvSales.CurrentCell.RowIndex).Cells("GROSS SALES").Value()
        txtDescription.Text = SalesRecordsForm.dgvSales.Rows(SalesRecordsForm.dgvSales.CurrentCell.RowIndex).Cells("DESCRIPTION").Value()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()

    End Sub

    Private Sub txtSales_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSales.TextChanged
        If txtUnitPrice.Text <> "" And txtSales.Text <> "" Then
            txtQuantity.Text = CType(txtSales.Text, Double) / CType(txtUnitPrice.Text, Double)
        End If

    End Sub

    Private Sub txtUnitPrice_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUnitPrice.TextChanged
        If txtUnitPrice.Text <> "" And txtSales.Text <> "" Then
            txtQuantity.Text = CType(txtSales.Text, Double) / CType(txtUnitPrice.Text, Double)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtUnitPrice.Text = "" And txtSales.Text = "" Then
            MsgBox("Unit price and sales cannot be empty")
        End If

        Dim s As SalesTable = New SalesTable()

        s.EditSales(txtCode.Text, dtpDate.Text, txtUnitPrice.Text, txtQuantity.Text, txtSales.Text, txtDescription.Text, txtRefNumber.Text, txtRefNumber.Text)

        MsgBox("Saved!!!")

        If Not SalesRecordsForm.txtRefNumber.Text = "" Then
            SalesRecordsForm.LoadDataGridBySearch()
        Else
            SalesRecordsForm.LoadDataGridByYearAndMonth()

        End If

        Me.Close()

    End Sub
End Class