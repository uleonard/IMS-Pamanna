Imports System.Data
Imports System.Data.OleDb
Public Class VoidSaleTransactionForm
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        txtTotalPrice.Text = Format(Val(txtQty.Text) * Val(txtUnitPrice2.Text), "Standard")
    End Sub

    Private Sub txtPLU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLU.TextChanged
        txtQty.Text = 1
        comType.Text = "Cash"

        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        ds.Clear()

        da = New OleDbDataAdapter("SELECT [product_code], [name], [unit_price] FROM product WHERE [plu_code] = " & Val(txtPLU.Text) & "", myConnection)
        da.Fill(ds, "product")

        If ds.Tables("product").Rows.Count = 1 Then
            txtProduct.Text = ds.Tables("product").Rows(0).Item("name")
            txtCode.Text = ds.Tables("product").Rows(0).Item("product_code")
            txtUnitPrice.Text = Format(ds.Tables("product").Rows(0).Item("unit_price"), "Standard")

            txtUnitPrice2.Text = ds.Tables("product").Rows(0).Item("unit_price") 'To be used in the text_changed event of txtQty control

            txtTotalPrice.Text = Format(Val(txtUnitPrice2.Text) * Val(txtQty.Text), "Standard")
            btnVoid.Enabled = True
        Else
            txtProduct.Text = ""
            txtUnitPrice.Text = "------"

            txtTotalPrice.Text = "------"
            txtCode.Text = ""
            btnVoid.Enabled = False
        End If
        myConnection.Close()
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click


        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim qty As Double = 0 - Val(txtQty.Text)
        Dim totalPrice As Double = 0 - Val(txtTotalPrice.Text)
        Dim str As String
        str = "INSERT INTO sales_transaction ([product], [quantity], [sales], [sales_type], [entered_by], [date_entered]) values (?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("product", CType(txtCode.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("quantity", CType(qty, String)))
        cmd.Parameters.Add(New OleDbParameter("sales", CType(totalPrice, String)))
        cmd.Parameters.Add(New OleDbParameter("sales_type", CType(comType.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("entered_by", CType(UserTable.userId, String)))
        cmd.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))

        Try
            cmd.ExecuteNonQuery()
            UpdateVoid()
            MsgBox("Voided")
            Me.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Private Sub UpdateVoid()
        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [void_sales], [void_frequency] FROM point_of_sale_summary_report WHERE [status] = 'Open' ", myConnection)
        da.Fill(ds, "void")

        Dim v As Double = ds.Tables("void").Rows(0).Item(0) + Val(txtTotalPrice.Text)
        Dim vf As Double = ds.Tables("void").Rows(0).Item(1) + 1

        myConnection.Close()



        myConnection.Open()

        Dim str As String
        str = "UPDATE point_of_sale_summary_report  SET void_sales = ?, void_frequency = ? WHERE status = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("void_sales", CType(v, String)))
        cmd.Parameters.Add(New OleDbParameter("void_frequency", CType(vf, String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("Open", String)))

        Try
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class