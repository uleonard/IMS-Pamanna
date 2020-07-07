Imports System.Data
Imports System.Data.OleDb
Public Class MakeSalesForm

    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter

    Private Sub MakeSalesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.Left = Me.Width / 2 - Panel1.Width / 2
        Panel1.Top = 100

        Panel2.Left = Me.Width / 2 - Panel2.Width / 2
        Panel2.Top = Panel1.Height + 130

        LoadProducts()

        comProduct.Text = "------------------------"

        DataGridView1.ColumnCount = 6
        DataGridView1.Columns(0).Name = "PRODUCT"
        DataGridView1.Columns(1).Name = "PLU"
        DataGridView1.Columns(2).Name = "CODE"
        DataGridView1.Columns(3).Name = "QTY"
        DataGridView1.Columns(4).Name = "UNIT PRICE"
        DataGridView1.Columns(5).Name = "TOTAL PRICE"


   
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        LoginForm.Show()
        LoginForm.txtUsername.Text = ""
        LoginForm.txtPassword.Text = ""
        LoginForm.txtUsername.Focus()

        MDIManager.Dispose()
        Me.Dispose()
    End Sub
    Private Sub LoadProducts()

        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [product_code], [name] FROM product ORDER BY [name]", myConnection)
        da.Fill(ds, "product")

        For i = 0 To ds.Tables("product").Rows.Count - 1

            comProduct.Items.Add(ds.Tables("product").Rows(i).Item(1))
        Next
        myConnection.Close()
    End Sub


    Private Sub comProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comProduct.SelectedIndexChanged
        Dim connection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        connection.ConnectionString = dbCon.dbConnector()
        connection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT [plu_code] FROM product WHERE [name] = ? ", connection)
        cmd.Parameters.Add(New OleDbParameter("name", CType(comProduct.Text, String)))

        txtPLU.Text = cmd.ExecuteScalar()
        connection.Close()
    End Sub

    Private Sub txtPLU_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPLU.KeyDown
        If comProduct.Text = "------------------------" Then
            txtPLU.Focus()

            Exit Sub
        End If
        If e.KeyCode = Keys.Enter Then
            AddSales()
        End If
    End Sub

    Private Sub txtPLU_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPLU.TextChanged
        txtQty.Text = 1

        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        ds.Clear()

        da = New OleDbDataAdapter("SELECT [product_code], [name], [unit_price] FROM product WHERE [plu_code] = " & Val(txtPLU.Text) & "", myConnection)
        da.Fill(ds, "product")

        If ds.Tables("product").Rows.Count = 1 Then
            comProduct.Text = ds.Tables("product").Rows(0).Item("name")
            txtCode.Text = ds.Tables("product").Rows(0).Item("product_code")
            txtUnitPrice.Text = Format(ds.Tables("product").Rows(0).Item("unit_price"), "Standard")

            txtUnitPrice2.Text = ds.Tables("product").Rows(0).Item("unit_price") 'To be used in the text_changed event of txtQty control

            txtTotalPrice.Text = Format(Val(txtUnitPrice2.Text) * Val(txtQty.Text), "Standard")
            btnAdd.Enabled = True
        Else
            comProduct.Text = "------------------------"
            txtUnitPrice.Text = "------"

            txtTotalPrice.Text = "------"
            txtCode.Text = ""
            btnAdd.Enabled = False
        End If
        myConnection.Close()

    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        AddSales()
    End Sub
    Private Sub AddSales()
        DataGridView1.AllowUserToAddRows = True

        Dim row As String() = New String() {
                                            comProduct.Text,
                                            txtPLU.Text,
                                            txtCode.Text,
                                            txtQty.Text,
                                            txtUnitPrice.Text,
                                           txtTotalPrice.Text
                                            }
        DataGridView1.Rows.Add(row)
        Dim sum As Double = 0
        For i = 0 To DataGridView1.Rows.Count - 1
            sum += DataGridView1.Rows(i).Cells("TOTAL PRICE").Value
        Next
        lblGrandTotal.Text = Format(sum, "Standard")

        btnVoid.Enabled = False
        comProduct.Text = "------------------------"
        txtPLU.Focus()

        DataGridView1.AllowUserToAddRows = False

        lblTotal.Text = "Total"
    End Sub

    Private Sub txtCashTendered_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCashTendered.KeyDown
        If e.KeyCode = Keys.Enter Then
            SaveSales()
        End If
    End Sub

    Private Sub txtCashTendered_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCashTendered.TextChanged
        Dim sum As Double = 0
        For i = 0 To DataGridView1.Rows.Count - 1
            sum += DataGridView1.Rows(i).Cells("TOTAL PRICE").Value
        Next

        txtChange.Text = Format(Val(txtCashTendered.Text) - sum, "Standard")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click


        SaveSales()

       
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If Not DataGridView1.SelectedCells.Count > 0 Then
            Exit Sub
        End If

        DataGridView1.Rows.RemoveAt(DataGridView1.CurrentRow.Index)


        Dim sum As Double = 0
        For i = 0 To DataGridView1.Rows.Count - 1
            sum += DataGridView1.Rows(i).Cells("TOTAL PRICE").Value
        Next
        lblGrandTotal.Text = Format(sum, "Standard")

    End Sub

    Private Sub txtQty_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtQty.KeyDown
        If e.KeyCode = Keys.Enter Then
            AddSales()
            txtPLU.Focus()
        End If
    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        txtTotalPrice.Text = Format(Val(txtQty.Text) * Val(txtUnitPrice2.Text), "Standard")

    End Sub
    Private Sub SaveSales()
        Dim myConnection As OleDbConnection = New OleDbConnection

        For i As Integer = 0 To DataGridView1.RowCount() - 1
            Dim product As String = DataGridView1.Rows(i).Cells("CODE").Value()
            Dim Qty As Double = DataGridView1.Rows(i).Cells("QTY").Value()
            Dim Price As Double = DataGridView1.Rows(i).Cells("TOTAL PRICE").Value()


            Dim dbCon As DbConnection = New DbConnection()
            myConnection.ConnectionString = dbCon.dbConnector()
            myConnection.Open()

            Dim str As String
            str = "INSERT INTO sales_transaction ([product], [quantity], [sales], [entered_by], [date_entered]) values (?, ?, ?, ?, ?)"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            cmd.Parameters.Add(New OleDbParameter("product", CType(product, String)))
            cmd.Parameters.Add(New OleDbParameter("quantity", CType(Qty, String)))
            cmd.Parameters.Add(New OleDbParameter("sales", CType(Price, String)))
            cmd.Parameters.Add(New OleDbParameter("entered_by", CType(UserTable.userId, String)))
            cmd.Parameters.Add(New OleDbParameter("date_entered", CType(Date.Now, String)))

            Try
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            myConnection.Close()
        Next

        comProduct.Text = "------------------------"
        DataGridView1.Rows.Clear()

        lblGrandTotal.Text = "Customer"
        lblTotal.Text = "Next"
        btnVoid.Enabled = True

        txtCashTendered.Text = ""


    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btnRA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRA.Click
        RAForm.ShowDialog()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        POForm.ShowDialog()

    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If DataGridView1.Rows.Count = 0 Then
            VoidSaleTransactionForm.ShowDialog()

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim pd As New Printing.PrintDocument
        Try
            AddHandler pd.PrintPage, AddressOf PrintTheList
            pd.Print()
        Catch ex As Exception
            MessageBox.Show("Problem printing the Text")
        End Try
    End Sub

    Private Sub PrintTheList(ByVal sender As Object, ByVal ev As Printing.PrintPageEventArgs)
        Dim YPos As Integer = ev.MarginBounds.Top
        Dim XPos As Integer = ev.MarginBounds.Left

        Dim fnt As New Font("Verdana", 9)
        Dim lineHeight As Integer = CInt(fnt.GetHeight(ev.Graphics))

        ev.Graphics.DrawString("------------------------", fnt, Brushes.Black, XPos, YPos)
        YPos += lineHeight

        ev.Graphics.DrawString("  WELCOME TO PA-MANNA ", fnt, Brushes.Black, XPos, YPos)
        YPos += lineHeight

        ev.Graphics.DrawString("------------------------", fnt, Brushes.Black, XPos, YPos)
        YPos += lineHeight

        ev.Graphics.DrawString(Date.Now.ToString, fnt, Brushes.Black, XPos, YPos)
        YPos += lineHeight

        ev.Graphics.DrawString("", fnt, Brushes.Black, XPos, YPos)
        YPos += lineHeight

        Dim sum As Double = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1



            Dim line1 As String = DataGridView1.Rows(i).Cells(0).Value.ToString & " @ " & DataGridView1.Rows(i).Cells(4).Value.ToString
            ev.Graphics.DrawString(line1, fnt, Brushes.Black, XPos, YPos)
            YPos += lineHeight

            Dim line2 As String = " x " & DataGridView1.Rows(i).Cells(3).Value.ToString & " = " & DataGridView1.Rows(i).Cells(5).Value.ToString
            ev.Graphics.DrawString(line2, fnt, Brushes.Black, XPos, YPos)
            YPos += lineHeight

            ev.Graphics.DrawString("------------------------", fnt, Brushes.Black, XPos, YPos)
            YPos += lineHeight

            sum += CType(DataGridView1.Rows(i).Cells(5).Value, Double)
        Next
        ev.Graphics.DrawString("TOTAL = " & Format(sum, "Standard"), fnt, Brushes.Black, XPos, YPos)
        YPos += lineHeight

        ev.Graphics.DrawString("", fnt, Brushes.Black, XPos, YPos)
        YPos += lineHeight

        ev.Graphics.DrawString("Phone: 08881452476/457412544", fnt, Brushes.Black, XPos, YPos)
        YPos += lineHeight

        ev.Graphics.DrawString("Email: pamannafoods@gmail.com", fnt, Brushes.Black, XPos, YPos)
        YPos += lineHeight

    End Sub
End Class