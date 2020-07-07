
Module MainModule
    Public Function splitProduct(ByVal product As String) As String

        'Splitting  combo box item into the product id and product name
        Dim strCom As Array = product.Split("|")

        Return Trim(strCom(1).ToString) 'PRODUCT CODE

    End Function
    Public Function splitProductToGetName(ByVal product As String) As String

        'Splitting  combo box item into the product id and product name
        Dim strCom As Array = product.Split("|")

        Return Trim(strCom(0).ToString) 'PRODUCT CODE

    End Function
    Public Sub Export1(ByRef datagrid As DataGridView, ByVal defaultName As String)
        Dim dialog As System.Windows.Forms.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        'Set the Save dialog properties
        With dialog
            .DefaultExt = "xlsx"
            .FileName = defaultName
            .Filter = "Excel Workbook (*.xlsx)|*.xlsx|XLSX (*.*)|*.*"
            .OverwritePrompt = True
            .Title = "Save As"
        End With
        'Show the Save dialog and if the user clicks the Save button,
        'save the file
        Dim strFileName As String = Nothing


        If dialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            strFileName = dialog.FileName

            Try
                Dim xlApp As Microsoft.Office.Interop.Excel.Application
                Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook
                Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
                Dim misValue As Object = System.Reflection.Missing.Value
                Dim i As Integer
                Dim j As Integer

                xlApp = New Microsoft.Office.Interop.Excel.Application
                xlWorkBook = xlApp.Workbooks.Add(misValue)
                xlWorkSheet = xlWorkBook.Sheets("Sheet1")


                For i = 0 To datagrid.RowCount - 1
                    For j = 0 To datagrid.ColumnCount - 1
                        For k As Integer = 1 To datagrid.Columns.Count
                            xlWorkSheet.Cells(1, k) = datagrid.Columns(k - 1).HeaderText
                            xlWorkSheet.Cells(i + 2, j + 1) = datagrid(j, i).Value.ToString()
                        Next
                    Next
                Next

                xlWorkSheet.SaveAs(strFileName)
                xlWorkBook.Close()
                xlApp.Quit()

                releaseObject(xlApp)
                releaseObject(xlWorkBook)
                releaseObject(xlWorkSheet)

                'Dim res As MsgBoxResult
                'res = MsgBox("Process completed, Would you like to open file?", MsgBoxStyle.YesNo)
                'If (res = MsgBoxResult.Yes) Then
                Process.Start(strFileName)
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Sub Export(ByRef datagrid As DataGridView, ByVal defaultName As String)
        Dim dialog As System.Windows.Forms.SaveFileDialog = New System.Windows.Forms.SaveFileDialog
        'Set the Save dialog properties
        With dialog
            .DefaultExt = "xlsx"
            .FileName = defaultName
            .Filter = "Excel Workbook (*.csv)|*.csv|CSV (*.*)|*.*"
            .OverwritePrompt = True
            .Title = "Save As"
        End With
        'Show the Save dialog and if the user clicks the Save button,
        'save the file
        Dim strFileName As String = Nothing


        If dialog.ShowDialog = Windows.Forms.DialogResult.OK Then
            strFileName = dialog.FileName

            Try
                
                 Dim i As Integer
                Dim j As Integer
                Dim data As String = ""
                For k As Integer = 0 To datagrid.Columns.Count - 1
                    data = data & datagrid.Columns(k).HeaderText & ","
                Next
                data = data & vbCrLf

                For i = 0 To datagrid.RowCount - 1
                    For j = 0 To datagrid.ColumnCount - 1

                        data = data & datagrid(j, i).Value.ToString() & ","
                    Next
                    data = data & vbCrLf
                Next

                My.Computer.FileSystem.WriteAllText(strFileName, data, False)


                'Dim res As MsgBoxResult
                'res = MsgBox("Process completed, Would you like to open file?", MsgBoxStyle.YesNo)
                'If (res = MsgBoxResult.Yes) Then
                Process.Start(strFileName)
                'End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub


    Public Function getMonthNumber(ByVal mon As String) As Integer
        Dim num As Integer
        Select Case mon
            Case "January"
                num = 1
            Case "February"
                num = 2
            Case "March"
                num = 3
            Case "April"
                num = 4
            Case "May"
                num = 5
            Case "June"
                num = 6
            Case "July"
                num = 7
            Case "August"
                num = 8
            Case "September"
                num = 9
            Case "October"
                num = 10
            Case "November"
                num = 11
            Case "December"
                num = 12
        End Select
        Return num
    End Function
End Module
