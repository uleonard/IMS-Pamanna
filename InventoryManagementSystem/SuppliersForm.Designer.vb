<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SuppliersForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnExportSuppliers = New System.Windows.Forms.Button()
        Me.btnNewSupplier = New System.Windows.Forms.Button()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.dgvSuppliers = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.btnPay = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.txtSearchGRN = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtcurrentBalance = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnlTransactions = New System.Windows.Forms.Panel()
        Me.pnlExport = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvSupplierTransactions = New System.Windows.Forms.DataGridView()
        Me.lblSupplier = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.comViewRecords = New System.Windows.Forms.ComboBox()
        Me.btnExportSupplies = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.btnReturnOut = New System.Windows.Forms.Button()
        Me.btnNotActiveSuppliers = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvSuppliers, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlTransactions.SuspendLayout()
        Me.pnlExport.SuspendLayout()
        CType(Me.dgvSupplierTransactions, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnNotActiveSuppliers)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.btnExportSuppliers)
        Me.Panel1.Controls.Add(Me.btnNewSupplier)
        Me.Panel1.Controls.Add(Me.txtSearch)
        Me.Panel1.Controls.Add(Me.dgvSuppliers)
        Me.Panel1.Location = New System.Drawing.Point(24, 40)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(546, 1092)
        Me.Panel1.TabIndex = 0
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(112, 1006)
        Me.btnEdit.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(89, 67)
        Me.btnEdit.TabIndex = 4
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnExportSuppliers
        '
        Me.btnExportSuppliers.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnExportSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExportSuppliers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportSuppliers.Location = New System.Drawing.Point(217, 1010)
        Me.btnExportSuppliers.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnExportSuppliers.Name = "btnExportSuppliers"
        Me.btnExportSuppliers.Size = New System.Drawing.Size(121, 65)
        Me.btnExportSuppliers.TabIndex = 3
        Me.btnExportSuppliers.Text = "Export"
        Me.btnExportSuppliers.UseVisualStyleBackColor = False
        '
        'btnNewSupplier
        '
        Me.btnNewSupplier.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnNewSupplier.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnNewSupplier.FlatAppearance.BorderSize = 2
        Me.btnNewSupplier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnNewSupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnNewSupplier.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNewSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewSupplier.Location = New System.Drawing.Point(6, 1004)
        Me.btnNewSupplier.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnNewSupplier.Name = "btnNewSupplier"
        Me.btnNewSupplier.Size = New System.Drawing.Size(94, 67)
        Me.btnNewSupplier.TabIndex = 2
        Me.btnNewSupplier.Text = "New"
        Me.btnNewSupplier.UseVisualStyleBackColor = False
        '
        'txtSearch
        '
        Me.txtSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearch.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.txtSearch.Location = New System.Drawing.Point(6, 6)
        Me.txtSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(534, 56)
        Me.txtSearch.TabIndex = 1
        Me.txtSearch.Text = "Search Supplier Here"
        '
        'dgvSuppliers
        '
        Me.dgvSuppliers.AllowUserToAddRows = False
        Me.dgvSuppliers.AllowUserToDeleteRows = False
        Me.dgvSuppliers.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvSuppliers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSuppliers.Location = New System.Drawing.Point(0, 71)
        Me.dgvSuppliers.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.dgvSuppliers.Name = "dgvSuppliers"
        Me.dgvSuppliers.ReadOnly = True
        Me.dgvSuppliers.RowHeadersVisible = False
        Me.dgvSuppliers.Size = New System.Drawing.Size(544, 912)
        Me.dgvSuppliers.TabIndex = 0
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 2
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(600, 1048)
        Me.Button2.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(150, 63)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "New Supply"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'btnPay
        '
        Me.btnPay.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnPay.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnPay.FlatAppearance.BorderSize = 2
        Me.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPay.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPay.Location = New System.Drawing.Point(814, 1046)
        Me.btnPay.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnPay.Name = "btnPay"
        Me.btnPay.Size = New System.Drawing.Size(150, 63)
        Me.btnPay.TabIndex = 4
        Me.btnPay.Text = "Pay"
        Me.btnPay.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDelete.FlatAppearance.BorderSize = 2
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(1054, 1046)
        Me.btnDelete.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(158, 63)
        Me.btnDelete.TabIndex = 5
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'txtSearchGRN
        '
        Me.txtSearchGRN.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchGRN.Location = New System.Drawing.Point(1980, 29)
        Me.txtSearchGRN.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtSearchGRN.Name = "txtSearchGRN"
        Me.txtSearchGRN.Size = New System.Drawing.Size(258, 56)
        Me.txtSearchGRN.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1778, 42)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(198, 37)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Search GRN"
        '
        'txtcurrentBalance
        '
        Me.txtcurrentBalance.Enabled = False
        Me.txtcurrentBalance.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcurrentBalance.Location = New System.Drawing.Point(2240, 1050)
        Me.txtcurrentBalance.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.txtcurrentBalance.Name = "txtcurrentBalance"
        Me.txtcurrentBalance.Size = New System.Drawing.Size(196, 44)
        Me.txtcurrentBalance.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1876, 1062)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(357, 37)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Current Balance (MWK)"
        '
        'pnlTransactions
        '
        Me.pnlTransactions.Controls.Add(Me.pnlExport)
        Me.pnlTransactions.Controls.Add(Me.dgvSupplierTransactions)
        Me.pnlTransactions.Location = New System.Drawing.Point(600, 112)
        Me.pnlTransactions.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.pnlTransactions.Name = "pnlTransactions"
        Me.pnlTransactions.Size = New System.Drawing.Size(1840, 912)
        Me.pnlTransactions.TabIndex = 11
        '
        'pnlExport
        '
        Me.pnlExport.BackColor = System.Drawing.Color.LightGreen
        Me.pnlExport.Controls.Add(Me.Label1)
        Me.pnlExport.Location = New System.Drawing.Point(122, 363)
        Me.pnlExport.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.pnlExport.Name = "pnlExport"
        Me.pnlExport.Size = New System.Drawing.Size(1056, 148)
        Me.pnlExport.TabIndex = 15
        Me.pnlExport.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(40, 46)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(971, 63)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Exporting Data To Excel. Please Wait..."
        '
        'dgvSupplierTransactions
        '
        Me.dgvSupplierTransactions.AllowUserToAddRows = False
        Me.dgvSupplierTransactions.AllowUserToDeleteRows = False
        Me.dgvSupplierTransactions.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvSupplierTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSupplierTransactions.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSupplierTransactions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSupplierTransactions.Location = New System.Drawing.Point(0, 0)
        Me.dgvSupplierTransactions.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.dgvSupplierTransactions.Name = "dgvSupplierTransactions"
        Me.dgvSupplierTransactions.ReadOnly = True
        Me.dgvSupplierTransactions.Size = New System.Drawing.Size(1840, 912)
        Me.dgvSupplierTransactions.TabIndex = 2
        '
        'lblSupplier
        '
        Me.lblSupplier.AutoSize = True
        Me.lblSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSupplier.Location = New System.Drawing.Point(610, 54)
        Me.lblSupplier.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.lblSupplier.Name = "lblSupplier"
        Me.lblSupplier.Size = New System.Drawing.Size(103, 37)
        Me.lblSupplier.TabIndex = 4
        Me.lblSupplier.Text = "Name"
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(2270, 29)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(150, 63)
        Me.btnSearch.TabIndex = 12
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'comViewRecords
        '
        Me.comViewRecords.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.comViewRecords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comViewRecords.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comViewRecords.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comViewRecords.FormattingEnabled = True
        Me.comViewRecords.Items.AddRange(New Object() {"All", "Not Paid", "Paid"})
        Me.comViewRecords.Location = New System.Drawing.Point(1468, 29)
        Me.comViewRecords.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.comViewRecords.Name = "comViewRecords"
        Me.comViewRecords.Size = New System.Drawing.Size(238, 50)
        Me.comViewRecords.TabIndex = 13
        '
        'btnExportSupplies
        '
        Me.btnExportSupplies.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnExportSupplies.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportSupplies.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportSupplies.Location = New System.Drawing.Point(1546, 1044)
        Me.btnExportSupplies.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnExportSupplies.Name = "btnExportSupplies"
        Me.btnExportSupplies.Size = New System.Drawing.Size(158, 63)
        Me.btnExportSupplies.TabIndex = 14
        Me.btnExportSupplies.Text = "Export"
        Me.btnExportSupplies.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'btnReturnOut
        '
        Me.btnReturnOut.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnReturnOut.Enabled = False
        Me.btnReturnOut.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnReturnOut.FlatAppearance.BorderSize = 2
        Me.btnReturnOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnReturnOut.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReturnOut.Location = New System.Drawing.Point(1300, 1044)
        Me.btnReturnOut.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.btnReturnOut.Name = "btnReturnOut"
        Me.btnReturnOut.Size = New System.Drawing.Size(158, 63)
        Me.btnReturnOut.TabIndex = 15
        Me.btnReturnOut.Text = "Return"
        Me.btnReturnOut.UseVisualStyleBackColor = False
        '
        'btnNotActiveSuppliers
        '
        Me.btnNotActiveSuppliers.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnNotActiveSuppliers.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNotActiveSuppliers.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNotActiveSuppliers.Location = New System.Drawing.Point(357, 1010)
        Me.btnNotActiveSuppliers.Margin = New System.Windows.Forms.Padding(6)
        Me.btnNotActiveSuppliers.Name = "btnNotActiveSuppliers"
        Me.btnNotActiveSuppliers.Size = New System.Drawing.Size(175, 65)
        Me.btnNotActiveSuppliers.TabIndex = 5
        Me.btnNotActiveSuppliers.Text = "Not Active"
        Me.btnNotActiveSuppliers.UseVisualStyleBackColor = False
        '
        'SuppliersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(2464, 1138)
        Me.Controls.Add(Me.btnReturnOut)
        Me.Controls.Add(Me.btnExportSupplies)
        Me.Controls.Add(Me.comViewRecords)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.pnlTransactions)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtcurrentBalance)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSearchGRN)
        Me.Controls.Add(Me.lblSupplier)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnPay)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel1)
        Me.Margin = New System.Windows.Forms.Padding(6, 6, 6, 6)
        Me.Name = "SuppliersForm"
        Me.Text = "Suppliers"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvSuppliers, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlTransactions.ResumeLayout(False)
        Me.pnlExport.ResumeLayout(False)
        Me.pnlExport.PerformLayout()
        CType(Me.dgvSupplierTransactions, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvSuppliers As System.Windows.Forms.DataGridView
    Friend WithEvents btnNewSupplier As System.Windows.Forms.Button
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents btnPay As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents txtSearchGRN As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtcurrentBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pnlTransactions As System.Windows.Forms.Panel
    Friend WithEvents dgvSupplierTransactions As System.Windows.Forms.DataGridView
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents btnExportSuppliers As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents comViewRecords As System.Windows.Forms.ComboBox
    Friend WithEvents btnExportSupplies As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents pnlExport As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents btnReturnOut As System.Windows.Forms.Button
    Friend WithEvents btnNotActiveSuppliers As System.Windows.Forms.Button
End Class
