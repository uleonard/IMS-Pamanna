<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIManager
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIManager))
        Me.ToolStrip = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripSales = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripPurchases = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CashPurchasesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SuppliersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PurchasesSheetToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DamagToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripbtnReports = New System.Windows.Forms.ToolStripDropDownButton()
        Me.CloseDayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DaySalesSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PLUReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StockTakingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseMonthToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MonthReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YearProductReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.YearReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripUsers = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManageUsersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LogoutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripData = New System.Windows.Forms.ToolStripDropDownButton()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusRole = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripSplitButton1 = New System.Windows.Forms.ToolStripSplitButton()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NoticeBoardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MakeSalesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolStrip.SuspendLayout()
        Me.StatusStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip
        '
        Me.ToolStrip.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Italic)
        Me.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ToolStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripSeparator9, Me.ToolStripSales, Me.ToolStripSeparator1, Me.ToolStripPurchases, Me.ToolStripSeparator4, Me.ToolStripbtnReports, Me.ToolStripSeparator2, Me.ToolStripUsers, Me.ToolStripSeparator5, Me.ToolStripData})
        Me.ToolStrip.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip.Name = "ToolStrip"
        Me.ToolStrip.Size = New System.Drawing.Size(1260, 67)
        Me.ToolStrip.TabIndex = 6
        Me.ToolStrip.Text = "ToolStrip"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = Global.InventoryManagementSystem.My.Resources.Resources.products_icon1
        Me.ToolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(147, 64)
        Me.ToolStripButton1.Text = "Products"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(6, 67)
        '
        'ToolStripSales
        '
        Me.ToolStripSales.Image = Global.InventoryManagementSystem.My.Resources.Resources.images__3_
        Me.ToolStripSales.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripSales.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSales.Name = "ToolStripSales"
        Me.ToolStripSales.Size = New System.Drawing.Size(114, 64)
        Me.ToolStripSales.Text = "Sales"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 67)
        '
        'ToolStripPurchases
        '
        Me.ToolStripPurchases.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CashPurchasesToolStripMenuItem, Me.SuppliersToolStripMenuItem, Me.PurchasesSheetToolStripMenuItem, Me.DamagToolStripMenuItem})
        Me.ToolStripPurchases.Image = Global.InventoryManagementSystem.My.Resources.Resources.images
        Me.ToolStripPurchases.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripPurchases.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripPurchases.Name = "ToolStripPurchases"
        Me.ToolStripPurchases.Size = New System.Drawing.Size(158, 64)
        Me.ToolStripPurchases.Text = "Purchases"
        '
        'CashPurchasesToolStripMenuItem
        '
        Me.CashPurchasesToolStripMenuItem.Name = "CashPurchasesToolStripMenuItem"
        Me.CashPurchasesToolStripMenuItem.Size = New System.Drawing.Size(289, 30)
        Me.CashPurchasesToolStripMenuItem.Text = "Cash Purchases"
        '
        'SuppliersToolStripMenuItem
        '
        Me.SuppliersToolStripMenuItem.Name = "SuppliersToolStripMenuItem"
        Me.SuppliersToolStripMenuItem.Size = New System.Drawing.Size(289, 30)
        Me.SuppliersToolStripMenuItem.Text = "Suppliers"
        '
        'PurchasesSheetToolStripMenuItem
        '
        Me.PurchasesSheetToolStripMenuItem.Name = "PurchasesSheetToolStripMenuItem"
        Me.PurchasesSheetToolStripMenuItem.Size = New System.Drawing.Size(289, 30)
        Me.PurchasesSheetToolStripMenuItem.Text = "Purchases Analysis Sheet"
        '
        'DamagToolStripMenuItem
        '
        Me.DamagToolStripMenuItem.Name = "DamagToolStripMenuItem"
        Me.DamagToolStripMenuItem.Size = New System.Drawing.Size(289, 30)
        Me.DamagToolStripMenuItem.Text = "Damages"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 67)
        '
        'ToolStripbtnReports
        '
        Me.ToolStripbtnReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseDayToolStripMenuItem, Me.DaySalesSummaryToolStripMenuItem, Me.PLUReportToolStripMenuItem, Me.StockTakingToolStripMenuItem, Me.CloseMonthToolStripMenuItem, Me.MonthReportToolStripMenuItem, Me.YearProductReportToolStripMenuItem, Me.YearReportToolStripMenuItem})
        Me.ToolStripbtnReports.Image = Global.InventoryManagementSystem.My.Resources.Resources.reports
        Me.ToolStripbtnReports.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripbtnReports.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripbtnReports.Name = "ToolStripbtnReports"
        Me.ToolStripbtnReports.Size = New System.Drawing.Size(162, 64)
        Me.ToolStripbtnReports.Text = "Period End"
        '
        'CloseDayToolStripMenuItem
        '
        Me.CloseDayToolStripMenuItem.Name = "CloseDayToolStripMenuItem"
        Me.CloseDayToolStripMenuItem.Size = New System.Drawing.Size(247, 30)
        Me.CloseDayToolStripMenuItem.Text = "Close Day"
        '
        'DaySalesSummaryToolStripMenuItem
        '
        Me.DaySalesSummaryToolStripMenuItem.Name = "DaySalesSummaryToolStripMenuItem"
        Me.DaySalesSummaryToolStripMenuItem.Size = New System.Drawing.Size(247, 30)
        Me.DaySalesSummaryToolStripMenuItem.Text = "Day Sales Summary"
        '
        'PLUReportToolStripMenuItem
        '
        Me.PLUReportToolStripMenuItem.Name = "PLUReportToolStripMenuItem"
        Me.PLUReportToolStripMenuItem.Size = New System.Drawing.Size(247, 30)
        Me.PLUReportToolStripMenuItem.Text = "PLU Report"
        '
        'StockTakingToolStripMenuItem
        '
        Me.StockTakingToolStripMenuItem.Name = "StockTakingToolStripMenuItem"
        Me.StockTakingToolStripMenuItem.Size = New System.Drawing.Size(247, 30)
        Me.StockTakingToolStripMenuItem.Text = "Stock Taking"
        '
        'CloseMonthToolStripMenuItem
        '
        Me.CloseMonthToolStripMenuItem.Image = Global.InventoryManagementSystem.My.Resources.Resources.images31
        Me.CloseMonthToolStripMenuItem.Name = "CloseMonthToolStripMenuItem"
        Me.CloseMonthToolStripMenuItem.Size = New System.Drawing.Size(247, 30)
        Me.CloseMonthToolStripMenuItem.Text = "Close Month"
        '
        'MonthReportToolStripMenuItem
        '
        Me.MonthReportToolStripMenuItem.Name = "MonthReportToolStripMenuItem"
        Me.MonthReportToolStripMenuItem.Size = New System.Drawing.Size(247, 30)
        Me.MonthReportToolStripMenuItem.Text = "Month Report"
        '
        'YearProductReportToolStripMenuItem
        '
        Me.YearProductReportToolStripMenuItem.Name = "YearProductReportToolStripMenuItem"
        Me.YearProductReportToolStripMenuItem.Size = New System.Drawing.Size(247, 30)
        Me.YearProductReportToolStripMenuItem.Text = "Year Product Report"
        '
        'YearReportToolStripMenuItem
        '
        Me.YearReportToolStripMenuItem.Name = "YearReportToolStripMenuItem"
        Me.YearReportToolStripMenuItem.Size = New System.Drawing.Size(247, 30)
        Me.YearReportToolStripMenuItem.Text = "Year Report"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 67)
        '
        'ToolStripUsers
        '
        Me.ToolStripUsers.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem, Me.ManageUsersToolStripMenuItem, Me.LogoutToolStripMenuItem})
        Me.ToolStripUsers.Image = Global.InventoryManagementSystem.My.Resources.Resources.images__2_2
        Me.ToolStripUsers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripUsers.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripUsers.Name = "ToolStripUsers"
        Me.ToolStripUsers.Size = New System.Drawing.Size(120, 64)
        Me.ToolStripUsers.Text = "Users"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(230, 30)
        Me.ChangePasswordToolStripMenuItem.Text = "Change Password"
        '
        'ManageUsersToolStripMenuItem
        '
        Me.ManageUsersToolStripMenuItem.Name = "ManageUsersToolStripMenuItem"
        Me.ManageUsersToolStripMenuItem.Size = New System.Drawing.Size(230, 30)
        Me.ManageUsersToolStripMenuItem.Text = "Manage Users"
        '
        'LogoutToolStripMenuItem
        '
        Me.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem"
        Me.LogoutToolStripMenuItem.Size = New System.Drawing.Size(230, 30)
        Me.LogoutToolStripMenuItem.Text = "Logout"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 67)
        '
        'ToolStripData
        '
        Me.ToolStripData.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BackupToolStripMenuItem, Me.RestoreToolStripMenuItem})
        Me.ToolStripData.Image = Global.InventoryManagementSystem.My.Resources.Resources.data2
        Me.ToolStripData.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripData.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripData.Name = "ToolStripData"
        Me.ToolStripData.Size = New System.Drawing.Size(114, 64)
        Me.ToolStripData.Text = "Data"
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(144, 30)
        Me.BackupToolStripMenuItem.Text = "Backup"
        '
        'RestoreToolStripMenuItem
        '
        Me.RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem"
        Me.RestoreToolStripMenuItem.Size = New System.Drawing.Size(144, 30)
        Me.RestoreToolStripMenuItem.Text = "Restore"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel, Me.ToolStripStatusLabel1, Me.ToolStripStatusRole, Me.ToolStripStatusLabel2, Me.ToolStripStatusUser, Me.ToolStripSplitButton1})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 502)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1260, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(36, 17)
        Me.ToolStripStatusLabel1.Text = "Role :"
        '
        'ToolStripStatusRole
        '
        Me.ToolStripStatusRole.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.ToolStripStatusRole.Name = "ToolStripStatusRole"
        Me.ToolStripStatusRole.Size = New System.Drawing.Size(53, 17)
        Me.ToolStripStatusRole.Text = "role here"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Margin = New System.Windows.Forms.Padding(100, 3, 0, 2)
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(36, 17)
        Me.ToolStripStatusLabel2.Text = "User :"
        '
        'ToolStripStatusUser
        '
        Me.ToolStripStatusUser.Margin = New System.Windows.Forms.Padding(10, 3, 0, 2)
        Me.ToolStripStatusUser.Name = "ToolStripStatusUser"
        Me.ToolStripStatusUser.Size = New System.Drawing.Size(55, 17)
        Me.ToolStripStatusUser.Text = "user here"
        '
        'ToolStripSplitButton1
        '
        Me.ToolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripSplitButton1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SettingsToolStripMenuItem, Me.NoticeBoardToolStripMenuItem, Me.MakeSalesToolStripMenuItem})
        Me.ToolStripSplitButton1.Image = CType(resources.GetObject("ToolStripSplitButton1.Image"), System.Drawing.Image)
        Me.ToolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripSplitButton1.Margin = New System.Windows.Forms.Padding(200, 2, 0, 0)
        Me.ToolStripSplitButton1.Name = "ToolStripSplitButton1"
        Me.ToolStripSplitButton1.Size = New System.Drawing.Size(54, 20)
        Me.ToolStripSplitButton1.Text = "Menu"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'NoticeBoardToolStripMenuItem
        '
        Me.NoticeBoardToolStripMenuItem.Name = "NoticeBoardToolStripMenuItem"
        Me.NoticeBoardToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.NoticeBoardToolStripMenuItem.Text = "Notice Board"
        '
        'MakeSalesToolStripMenuItem
        '
        Me.MakeSalesToolStripMenuItem.Name = "MakeSalesToolStripMenuItem"
        Me.MakeSalesToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.MakeSalesToolStripMenuItem.Text = "Make Sales"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "Data Restoration File|*.BAK;*.mdb"
        '
        'MDIManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1260, 524)
        Me.Controls.Add(Me.ToolStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "MDIManager"
        Me.Text = "IAM - Inventory Management System (IMS) "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ToolStrip.ResumeLayout(False)
        Me.ToolStrip.PerformLayout()
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStrip As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusRole As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripbtnReports As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripUsers As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ManageUsersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogoutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripData As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents BackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RestoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripPurchases As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents CashPurchasesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SuppliersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PurchasesSheetToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DamagToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSales As System.Windows.Forms.ToolStripButton
    Friend WithEvents CloseMonthToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MonthReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YearProductReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents YearReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StockTakingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSplitButton1 As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoticeBoardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents MakeSalesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseDayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PLUReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DaySalesSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
