<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonthlySummariesForm
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panel3 = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtProfit = New System.Windows.Forms.TextBox()
        Me.txtTotalCost = New System.Windows.Forms.TextBox()
        Me.txtTotalSales = New System.Windows.Forms.TextBox()
        Me.comYear = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.comMonth = New System.Windows.Forms.ComboBox()
        Me.dgvMonthlySummaries = New System.Windows.Forms.DataGridView()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtDamages = New System.Windows.Forms.TextBox()
        Me.txtPurchasesVat = New System.Windows.Forms.TextBox()
        Me.txtSalesVat = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.panel3.SuspendLayout()
        CType(Me.dgvMonthlySummaries, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel3
        '
        Me.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.panel3.Controls.Add(Me.Label10)
        Me.panel3.Controls.Add(Me.Label9)
        Me.panel3.Controls.Add(Me.Label8)
        Me.panel3.Controls.Add(Me.txtProfit)
        Me.panel3.Controls.Add(Me.txtTotalCost)
        Me.panel3.Controls.Add(Me.txtTotalSales)
        Me.panel3.Location = New System.Drawing.Point(31, 441)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(999, 42)
        Me.panel3.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(685, 11)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(93, 20)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Gross Profit"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(371, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(118, 20)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Total Cost (MK)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 20)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Total Sales"
        '
        'txtProfit
        '
        Me.txtProfit.BackColor = System.Drawing.SystemColors.Control
        Me.txtProfit.Enabled = False
        Me.txtProfit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProfit.Location = New System.Drawing.Point(820, 8)
        Me.txtProfit.Name = "txtProfit"
        Me.txtProfit.Size = New System.Drawing.Size(164, 26)
        Me.txtProfit.TabIndex = 2
        '
        'txtTotalCost
        '
        Me.txtTotalCost.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalCost.Enabled = False
        Me.txtTotalCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCost.Location = New System.Drawing.Point(505, 8)
        Me.txtTotalCost.Name = "txtTotalCost"
        Me.txtTotalCost.Size = New System.Drawing.Size(171, 26)
        Me.txtTotalCost.TabIndex = 1
        '
        'txtTotalSales
        '
        Me.txtTotalSales.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalSales.Enabled = False
        Me.txtTotalSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSales.Location = New System.Drawing.Point(165, 11)
        Me.txtTotalSales.Name = "txtTotalSales"
        Me.txtTotalSales.Size = New System.Drawing.Size(171, 26)
        Me.txtTotalSales.TabIndex = 0
        '
        'comYear
        '
        Me.comYear.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.comYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comYear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comYear.FormattingEnabled = True
        Me.comYear.Location = New System.Drawing.Point(388, 3)
        Me.comYear.Name = "comYear"
        Me.comYear.Size = New System.Drawing.Size(88, 28)
        Me.comYear.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(154, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Select period to view"
        '
        'comMonth
        '
        Me.comMonth.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.comMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.comMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comMonth.FormattingEnabled = True
        Me.comMonth.Items.AddRange(New Object() {"January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.comMonth.Location = New System.Drawing.Point(190, 3)
        Me.comMonth.Name = "comMonth"
        Me.comMonth.Size = New System.Drawing.Size(192, 28)
        Me.comMonth.TabIndex = 11
        '
        'dgvMonthlySummaries
        '
        Me.dgvMonthlySummaries.AllowUserToAddRows = False
        Me.dgvMonthlySummaries.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ButtonFace
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dgvMonthlySummaries.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMonthlySummaries.BackgroundColor = System.Drawing.SystemColors.InactiveBorder
        Me.dgvMonthlySummaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMonthlySummaries.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMonthlySummaries.Location = New System.Drawing.Point(31, 49)
        Me.dgvMonthlySummaries.Name = "dgvMonthlySummaries"
        Me.dgvMonthlySummaries.ReadOnly = True
        Me.dgvMonthlySummaries.Size = New System.Drawing.Size(999, 386)
        Me.dgvMonthlySummaries.TabIndex = 10
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExcel.Location = New System.Drawing.Point(519, 2)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(121, 31)
        Me.btnExcel.TabIndex = 15
        Me.btnExcel.Text = "Export"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.panel2.Controls.Add(Me.Label1)
        Me.panel2.Controls.Add(Me.Label3)
        Me.panel2.Controls.Add(Me.Label4)
        Me.panel2.Controls.Add(Me.txtDamages)
        Me.panel2.Controls.Add(Me.txtPurchasesVat)
        Me.panel2.Controls.Add(Me.txtSalesVat)
        Me.panel2.Location = New System.Drawing.Point(32, 510)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(999, 42)
        Me.panel2.TabIndex = 16
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(685, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 20)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Damages Cost"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(371, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 20)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Purchases VAT"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(131, 20)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Total : Sales VAT"
        '
        'txtDamages
        '
        Me.txtDamages.BackColor = System.Drawing.SystemColors.Control
        Me.txtDamages.Enabled = False
        Me.txtDamages.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDamages.Location = New System.Drawing.Point(820, 11)
        Me.txtDamages.Name = "txtDamages"
        Me.txtDamages.Size = New System.Drawing.Size(164, 26)
        Me.txtDamages.TabIndex = 2
        '
        'txtPurchasesVat
        '
        Me.txtPurchasesVat.BackColor = System.Drawing.SystemColors.Control
        Me.txtPurchasesVat.Enabled = False
        Me.txtPurchasesVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurchasesVat.Location = New System.Drawing.Point(505, 11)
        Me.txtPurchasesVat.Name = "txtPurchasesVat"
        Me.txtPurchasesVat.Size = New System.Drawing.Size(171, 26)
        Me.txtPurchasesVat.TabIndex = 1
        '
        'txtSalesVat
        '
        Me.txtSalesVat.BackColor = System.Drawing.SystemColors.Control
        Me.txtSalesVat.Enabled = False
        Me.txtSalesVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSalesVat.Location = New System.Drawing.Point(165, 8)
        Me.txtSalesVat.Name = "txtSalesVat"
        Me.txtSalesVat.Size = New System.Drawing.Size(171, 26)
        Me.txtSalesVat.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.comMonth)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnExcel)
        Me.Panel1.Controls.Add(Me.comYear)
        Me.Panel1.Location = New System.Drawing.Point(32, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(873, 39)
        Me.Panel1.TabIndex = 17
        '
        'MonthlySummariesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1058, 569)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.panel3)
        Me.Controls.Add(Me.dgvMonthlySummaries)
        Me.Name = "MonthlySummariesForm"
        Me.Text = "Monthly Summaries"
        Me.panel3.ResumeLayout(False)
        Me.panel3.PerformLayout()
        CType(Me.dgvMonthlySummaries, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtProfit As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalCost As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalSales As System.Windows.Forms.TextBox
    Friend WithEvents comYear As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents comMonth As System.Windows.Forms.ComboBox
    Friend WithEvents dgvMonthlySummaries As System.Windows.Forms.DataGridView
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtDamages As System.Windows.Forms.TextBox
    Friend WithEvents txtPurchasesVat As System.Windows.Forms.TextBox
    Friend WithEvents txtSalesVat As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
