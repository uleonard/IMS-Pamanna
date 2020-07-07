Imports System.Data
Imports System.Data.OleDb
Public Class PLUReportForm
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim source1 As New BindingSource()

    'TO BE USED IN PRINTDOCUMENT1 SUB BELOW
    Dim mRow As Integer = 0
    Dim newpage As Boolean = True

    Private Sub PLUReportForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()

    End Sub
   

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Search()

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If txtRefNumber.Text = "" Or DataGridView1.Rows.Count = 0 Then
            MsgBox("Enter Reference number and search first. ")
            Exit Sub

        End If
        Dim defaultName As String = "PLU Report With Ref Number " & txtRefNumber.Text

        Export(DataGridView1, defaultName)
    End Sub

    Private Sub txtRefNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtRefNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            Search()
        End If
    End Sub
    Private Sub Search()
        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        ds.Clear()

        da = New OleDbDataAdapter("SELECT p.name AS [NAME], p.product_code AS [CODE], p.plu_code AS [PLU CODE], s.quantity AS [QUANTITY], s.gross_sales AS [SALES (MK)] FROM product p INNER JOIN sales s ON p.product_code=s.product WHERE s.ref_number = '" & txtRefNumber.Text & "'", myConnection)
        da.Fill(ds, "product")

        Dim view1 As New DataView(ds.Tables(0))
        source1.DataSource = view1
        DataGridView1.DataSource = view1
        myConnection.Close()

        Dim total As Double = 0
        For i = 0 To DataGridView1.Rows.Count - 1
            total += DataGridView1.Rows(i).Cells("SALES (MK)").Value
        Next
        txtTotalsales.Text = Format(total, "Standard")

        'FORMAT DATE COLUMNS
        DataGridView1.Columns("SALES (MK)").DefaultCellStyle.Format = "N2"
        DataGridView1.Columns("QUANTITY").DefaultCellStyle.Format = "N2"

    End Sub

    Private Sub txtRefNumber_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRefNumber.TextChanged

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As System.Object, e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fmt As StringFormat = New StringFormat(StringFormatFlags.LineLimit)

        With DataGridView1

            fmt.LineAlignment = StringAlignment.Center
            fmt.Trimming = StringTrimming.EllipsisCharacter
            Dim y As Single = e.MarginBounds.Top
            Do While mRow < .RowCount
                Dim row As DataGridViewRow = .Rows(mRow)
                Dim x As Single = e.MarginBounds.Left
                Dim h As Single = 0
                For Each cell As DataGridViewCell In row.Cells
                    Dim rc As RectangleF = New RectangleF(x, y, cell.Size.Width, cell.Size.Height)
                    e.Graphics.DrawRectangle(Pens.Black, rc.Left, rc.Top, rc.Width, rc.Height)
                    If (newpage) Then
                        e.Graphics.DrawString(DataGridView1.Columns(cell.ColumnIndex).HeaderText, .Font, Brushes.Black, rc, fmt)
                    Else
                        e.Graphics.DrawString(DataGridView1.Rows(cell.RowIndex).Cells(cell.ColumnIndex).FormattedValue.ToString(), .Font, Brushes.Black, rc, fmt)
                    End If
                    x += rc.Width
                    h = Math.Max(h, rc.Height)
                Next
                newpage = False
                y += h
                mRow += 1
                If y + h > e.MarginBounds.Bottom Then
                    e.HasMorePages = True
                    mRow -= 1
                    newpage = True
                    Exit Sub
                End If
            Loop
            mRow = 0

            ' Dim pos As Integer() = {100, y}
            'e.Graphics.DrawString("Total Sales MWK  : " & txtTotalsales.Text, Font, Brushes.Black, pos, fmt)
        End With

        
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub
   
  
    Private Sub PLUReportForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        
    End Sub
End Class