Imports System.Data
Imports System.Data.OleDb
Public Class PurchasesForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Private Sub PurchasesForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim yr As Integer
        For yr = 2014 To Year(Date.Now)
            comYear.Items.Add(yr)
        Next
        comYear.Text = Year(Date.Now)
        Dim mon As Integer = Month(Date.Now)

        comMonth.Text = MonthName(mon)

        comPurchaseType.Text = "All"

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT [product_code], [name] FROM product ORDER BY [name]", myConnection)
        da.Fill(ds, "product")

        For i = 0 To ds.Tables("product").Rows.Count - 1

            comProduct.Items.Add(ds.Tables("product").Rows(i).Item(1) & " | " & ds.Tables("product").Rows(i).Item(0))
        Next
        myConnection.Close()

        comProduct.SelectedIndex = 0

        
        Dim productCode As String
        If comProduct.Text = "All Products" Then
            productCode = "%"
        Else
            productCode = MainModule.splitProduct(comProduct.Text)
        End If

        Dim p As PurchasesTable = New PurchasesTable()
        p.loadDatagridPurchases(comYear.Text, comMonth.Text, productCode, comPurchaseType.Text)

        'FORMAT DATE COLUMNS
        dgvPurchases.Columns("PURCHASE DATE").DefaultCellStyle.Format = "d"
        dgvPurchases.Columns("DATE ENTERED").DefaultCellStyle.Format = "g"
        dgvPurchases.Columns("DATE PAID").DefaultCellStyle.Format = "D"
        dgvPurchases.Columns("PAYMENT DATE").DefaultCellStyle.Format = "D"
    End Sub


    Private Sub comProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comProduct.SelectedIndexChanged
        Dim productCode As String
        If comProduct.Text = "All Products" Then
            productCode = "%"
        Else
            productCode = MainModule.splitProduct(comProduct.Text)
        End If

        Dim p As PurchasesTable = New PurchasesTable()
        p.loadDatagridPurchases(comYear.Text, comMonth.Text, productCode, comPurchaseType.Text)
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
            Dim productCode As String
            If comProduct.Text = "All Products" Then
                productCode = "%"
            Else
                productCode = MainModule.splitProduct(comProduct.Text)
            End If

            Dim p As PurchasesTable = New PurchasesTable()
            p.loadDatagridPurchases(comYear.Text, comMonth.Text, productCode, comPurchaseType.Text)
        End If
    End Sub

    Private Sub comYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comYear.SelectedIndexChanged
        If (comProduct.SelectedIndex <> -1) Then
            Dim productCode As String
            If comProduct.Text = "All Products" Then
                productCode = "%"
            Else
                productCode = MainModule.splitProduct(comProduct.Text)
            End If


            Dim p As PurchasesTable = New PurchasesTable()
            p.loadDatagridPurchases(comYear.Text, comMonth.Text, productCode, comPurchaseType.Text)

        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim defaultName As String = comPurchaseType.Text & " Purchases - " & comProduct.Text & " & For " & comMonth.Text & " " & comYear.Text

        Export(dgvPurchases, defaultName)
    End Sub
    

    Private Sub PurchasesForm_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        ' dgvPurchases.Width = Me.Width - 60
        'dgvPurchases.Height = Me.Height - 100
        Panel1.Left = 20
        Panel1.Width = Me.Width - 60
        Panel1.Height = Me.Height - 200
        Panel3.Top = Panel1.Height + 70
    End Sub

    Private Sub comPurchaseType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comPurchaseType.SelectedIndexChanged
        If (comProduct.SelectedIndex <> -1) Then
            Dim productCode As String
            If comProduct.Text = "All Products" Then
                productCode = "%"
            Else
                productCode = MainModule.splitProduct(comProduct.Text)
            End If


            Dim p As PurchasesTable = New PurchasesTable()
            p.loadDatagridPurchases(comYear.Text, comMonth.Text, productCode, comPurchaseType.Text)
        End If
    End Sub

   

   
End Class