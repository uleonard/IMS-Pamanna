<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashPurchasesForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnExportSupplies = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtSearchGRN = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgvPurchases = New System.Windows.Forms.DataGridView()
        Me.lblResults = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalCost = New System.Windows.Forms.TextBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.btnSearchByDate = New System.Windows.Forms.Button()
        Me.comProduct = New System.Windows.Forms.ComboBox()
        Me.btnSearchByProduct = New System.Windows.Forms.Button()
        CType(Me.dgvPurchases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnExportSupplies
        '
        Me.btnExportSupplies.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnExportSupplies.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExportSupplies.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportSupplies.Location = New System.Drawing.Point(502, 478)
        Me.btnExportSupplies.Name = "btnExportSupplies"
        Me.btnExportSupplies.Size = New System.Drawing.Size(79, 33)
        Me.btnExportSupplies.TabIndex = 22
        Me.btnExportSupplies.Text = "Export"
        Me.btnExportSupplies.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(302, 15)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(42, 29)
        Me.btnSearch.TabIndex = 20
        Me.btnSearch.Text = "Go"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(144, 20)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Search          : GRN"
        '
        'txtSearchGRN
        '
        Me.txtSearchGRN.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSearchGRN.Location = New System.Drawing.Point(167, 15)
        Me.txtSearchGRN.Name = "txtSearchGRN"
        Me.txtSearchGRN.Size = New System.Drawing.Size(131, 32)
        Me.txtSearchGRN.TabIndex = 18
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.Button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 2
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(12, 478)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(181, 33)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "New Cash Purchases"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'dgvPurchases
        '
        Me.dgvPurchases.AllowUserToAddRows = False
        Me.dgvPurchases.AllowUserToDeleteRows = False
        Me.dgvPurchases.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvPurchases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Format = "N2"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPurchases.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPurchases.Location = New System.Drawing.Point(12, 119)
        Me.dgvPurchases.Name = "dgvPurchases"
        Me.dgvPurchases.ReadOnly = True
        Me.dgvPurchases.Size = New System.Drawing.Size(896, 344)
        Me.dgvPurchases.TabIndex = 15
        '
        'lblResults
        '
        Me.lblResults.AutoSize = True
        Me.lblResults.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblResults.ForeColor = System.Drawing.Color.Crimson
        Me.lblResults.Location = New System.Drawing.Point(13, 70)
        Me.lblResults.Name = "lblResults"
        Me.lblResults.Size = New System.Drawing.Size(134, 20)
        Me.lblResults.TabIndex = 23
        Me.lblResults.Text = "Results for GRN :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(642, 491)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 20)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Total Cost (MK)"
        '
        'txtTotalCost
        '
        Me.txtTotalCost.Enabled = False
        Me.txtTotalCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCost.Location = New System.Drawing.Point(781, 485)
        Me.txtTotalCost.Name = "txtTotalCost"
        Me.txtTotalCost.Size = New System.Drawing.Size(127, 26)
        Me.txtTotalCost.TabIndex = 25
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(307, 478)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(80, 33)
        Me.btnDelete.TabIndex = 27
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'dtpDate
        '
        Me.dtpDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpDate.Location = New System.Drawing.Point(395, 19)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(105, 26)
        Me.dtpDate.TabIndex = 45
        '
        'btnSearchByDate
        '
        Me.btnSearchByDate.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnSearchByDate.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearchByDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchByDate.Location = New System.Drawing.Point(504, 19)
        Me.btnSearchByDate.Name = "btnSearchByDate"
        Me.btnSearchByDate.Size = New System.Drawing.Size(42, 27)
        Me.btnSearchByDate.TabIndex = 46
        Me.btnSearchByDate.Text = "Go"
        Me.btnSearchByDate.UseVisualStyleBackColor = False
        '
        'comProduct
        '
        Me.comProduct.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.comProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comProduct.FormattingEnabled = True
        Me.comProduct.Location = New System.Drawing.Point(584, 21)
        Me.comProduct.Name = "comProduct"
        Me.comProduct.Size = New System.Drawing.Size(218, 28)
        Me.comProduct.TabIndex = 47
        '
        'btnSearchByProduct
        '
        Me.btnSearchByProduct.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnSearchByProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearchByProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchByProduct.Location = New System.Drawing.Point(806, 21)
        Me.btnSearchByProduct.Name = "btnSearchByProduct"
        Me.btnSearchByProduct.Size = New System.Drawing.Size(41, 28)
        Me.btnSearchByProduct.TabIndex = 48
        Me.btnSearchByProduct.Text = "Go"
        Me.btnSearchByProduct.UseVisualStyleBackColor = False
        '
        'CashPurchasesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1082, 612)
        Me.Controls.Add(Me.btnSearchByProduct)
        Me.Controls.Add(Me.comProduct)
        Me.Controls.Add(Me.btnSearchByDate)
        Me.Controls.Add(Me.dtpDate)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.txtTotalCost)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblResults)
        Me.Controls.Add(Me.btnExportSupplies)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSearchGRN)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.dgvPurchases)
        Me.Name = "CashPurchasesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash Purchases"
        CType(Me.dgvPurchases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExportSupplies As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSearchGRN As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dgvPurchases As System.Windows.Forms.DataGridView
    Friend WithEvents lblResults As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCost As System.Windows.Forms.TextBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSearchByDate As System.Windows.Forms.Button
    Friend WithEvents comProduct As System.Windows.Forms.ComboBox
    Friend WithEvents btnSearchByProduct As System.Windows.Forms.Button
End Class
