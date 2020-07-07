Imports System.Windows.Forms
Imports System.IO

Public Class MDIManager

    Private Sub MDIManager_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        
    End Sub

    Private Sub MDIManager_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub

    Private Sub MDIManager_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim C As Control
        For Each C In Me.Controls
            If TypeOf C Is MdiClient Then
                ' C.BackColor = Color.FloralWhite
                C.BackColor = Color.WhiteSmoke
                Exit For

            End If
        Next
        C = Nothing


        ToolStripStatusRole.Text = UserTable.role
        If Not UserTable.role = "MANAGER" Then
            ManageUsersToolStripMenuItem.Enabled = False
            BackupToolStripMenuItem.Enabled = False
            RestoreToolStripMenuItem.Enabled = False
            SettingsToolStripMenuItem.Visible = False
            CloseDayToolStripMenuItem.Enabled = False
            CloseMonthToolStripMenuItem.Enabled = False


        End If

        ToolStripStatusUser.Text = UserTable.firstname & " " & UserTable.surname & " [ " & UserTable.username & " ]"
        NoticeBoardForm.MdiParent = Me
        NoticeBoardForm.Show()

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        ProductsForm.MdiParent = Me
        ProductsForm.Show()
    End Sub


    Private Sub ToolStripSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripSales.Click
        SalesRecordsForm.MdiParent = Me
        SalesRecordsForm.Show()
    End Sub


   


    Private Sub ToolStripbtnReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripbtnReports.Click

    End Sub


    Private Sub ToolStripbtnAnalysis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

  


    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        ChangePasswordForm.ShowDialog()

    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        LoginForm.Show()
        LoginForm.txtUsername.Text = ""
        LoginForm.txtPassword.Text = ""
        LoginForm.txtUsername.Focus()

        Me.Dispose()

    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click

        If FolderBrowserDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Try

                Dim strLocation As String = Nothing
                strLocation = FolderBrowserDialog1.SelectedPath
                Dim TimeNow As String = Year(Now) & "-" & Month(Now) & "-" & Date.Now.Day & "-" & Date.Now.Hour & "-" & Date.Now.Minute & "-" & Date.Now.Second

                File.Copy(Application.StartupPath & "\\ims.mdb", strLocation & "\ims-" & TimeNow & ".BAK", True)
                ' File.Copy("\\10.10.48.90\db\ims.mdb", strLocation & "\ims-" & TimeNow & ".BAK", True)
                MsgBox("Backup Complete!!" & vbCrLf & "BACKUP FILE LOCATION IS : " & strLocation & "\ims-" & TimeNow & ".BAK")

            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub RestoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RestoreToolStripMenuItem.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Dim res As MsgBoxResult = MsgBox("You have selected to restore the following file : " & vbCrLf & OpenFileDialog1.FileName & vbCrLf & " IS THIS IN ORDER ?" & vbCrLf & vbCrLf & "WARNING!!! Restoring a wrong file will result in DATA LOSS.", vbYesNo + vbQuestion, "Inventory Management System")
            If res = vbNo Then
                Exit Sub
            End If
            Try

                Dim strLocation As String = Nothing
                strLocation = OpenFileDialog1.FileName

                File.Copy(strLocation, Application.StartupPath & "\\ims.mdb", True)
                MsgBox("Data Restoration Complete!!")

            Catch ex As Exception
                MessageBox.Show(ex.Message, My.Application.Info.Title, _
                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub ManageUsersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManageUsersToolStripMenuItem.Click
        ManageUsersForm.MdiParent = Me
        ManageUsersForm.Show()
    End Sub


    Private Sub CashPurchasesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashPurchasesToolStripMenuItem.Click
        CashPurchasesForm.MdiParent = Me
        CashPurchasesForm.Show()
    End Sub

    Private Sub SuppliersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SuppliersToolStripMenuItem.Click
        SuppliersForm.MdiParent = Me
        SuppliersForm.Show()
    End Sub

    Private Sub PurchasesSheetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasesSheetToolStripMenuItem.Click
        PurchasesForm.MdiParent = Me
        PurchasesForm.Show()
    End Sub

    Private Sub DamagToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DamagToolStripMenuItem.Click
        DamagesForm.MdiParent = Me

        DamagesForm.Show()

    End Sub

    Private Sub CloseMonthToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles CloseMonthToolStripMenuItem.Click
        CloseMonthForm.MdiParent = Me
        CloseMonthForm.Show()
    End Sub

    Private Sub MonthReportToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MonthReportToolStripMenuItem.Click
        MonthlySummariesForm.MdiParent = Me
        MonthlySummariesForm.Show()
    End Sub

    Private Sub YearProductReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles YearProductReportToolStripMenuItem.Click
        AnalysisReportsForm.MdiParent = Me
        AnalysisReportsForm.Show()
    End Sub

    
    Private Sub StockTakingToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles StockTakingToolStripMenuItem.Click
        StockTakingForm.MdiParent = Me
        StockTakingForm.Show()
    End Sub

    Private Sub NoticeBoardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NoticeBoardToolStripMenuItem.Click
        NoticeBoardForm.MdiParent = Me
        NoticeBoardForm.Show()

    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        SettingsForm.MdiParent = Me
        SettingsForm.Show()
    End Sub

    Private Sub MakeSalesToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles MakeSalesToolStripMenuItem.Click
        MakeSalesForm.ShowDialog()

    End Sub

    Private Sub CloseDayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseDayToolStripMenuItem.Click
        CloseDayForm.ShowDialog()

    End Sub

    Private Sub PLUReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PLUReportToolStripMenuItem.Click
        PLUReportForm.ShowDialog()

    End Sub

    Private Sub DaySalesSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaySalesSummaryToolStripMenuItem.Click
        'SalesSummaryReportForm.ShowDialog()
        SalesSummaryReportForm.MdiParent = Me
        SalesSummaryReportForm.Show()
    End Sub
End Class
