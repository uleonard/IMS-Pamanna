<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PurchasesForm
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
        Me.btnLast = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnFirst = New System.Windows.Forms.Button()
        Me.comProduct = New System.Windows.Forms.ComboBox()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.comMonth = New System.Windows.Forms.ComboBox()
        Me.comYear = New System.Windows.Forms.ComboBox()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalNet = New System.Windows.Forms.TextBox()
        Me.txtTotalVat = New System.Windows.Forms.TextBox()
        Me.lbltotalVAT = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTotalCost = New System.Windows.Forms.TextBox()
        Me.txtTotalQuantity = New System.Windows.Forms.TextBox()
        Me.comPurchaseType = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dgvPurchases = New System.Windows.Forms.DataGridView()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvPurchases, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLast
        '
        Me.btnLast.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnLast.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLast.Location = New System.Drawing.Point(809, 14)
        Me.btnLast.Name = "btnLast"
        Me.btnLast.Size = New System.Drawing.Size(31, 26)
        Me.btnLast.TabIndex = 5
        Me.btnLast.Text = ">|"
        Me.btnLast.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNext.Location = New System.Drawing.Point(766, 15)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(36, 25)
        Me.btnNext.TabIndex = 4
        Me.btnNext.Text = ">>"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'btnPrevious
        '
        Me.btnPrevious.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnPrevious.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrevious.Location = New System.Drawing.Point(722, 17)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(37, 25)
        Me.btnPrevious.TabIndex = 3
        Me.btnPrevious.Text = "<<"
        Me.btnPrevious.UseVisualStyleBackColor = False
        '
        'btnFirst
        '
        Me.btnFirst.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnFirst.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFirst.Location = New System.Drawing.Point(677, 17)
        Me.btnFirst.Name = "btnFirst"
        Me.btnFirst.Size = New System.Drawing.Size(38, 25)
        Me.btnFirst.TabIndex = 2
        Me.btnFirst.Text = "|<"
        Me.btnFirst.UseVisualStyleBackColor = False
        '
        'comProduct
        '
        Me.comProduct.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.comProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comProduct.FormattingEnabled = True
        Me.comProduct.Items.AddRange(New Object() {"All Products"})
        Me.comProduct.Location = New System.Drawing.Point(385, 12)
        Me.comProduct.Name = "comProduct"
        Me.comProduct.Size = New System.Drawing.Size(218, 28)
        Me.comProduct.TabIndex = 1
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(3, 7)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(91, 31)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'comMonth
        '
        Me.comMonth.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.comMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comMonth.FormattingEnabled = True
        Me.comMonth.Items.AddRange(New Object() {"All Months", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.comMonth.Location = New System.Drawing.Point(182, 12)
        Me.comMonth.Name = "comMonth"
        Me.comMonth.Size = New System.Drawing.Size(169, 28)
        Me.comMonth.TabIndex = 2
        '
        'comYear
        '
        Me.comYear.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.comYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comYear.FormattingEnabled = True
        Me.comYear.Location = New System.Drawing.Point(12, 12)
        Me.comYear.Name = "comYear"
        Me.comYear.Size = New System.Drawing.Size(88, 28)
        Me.comYear.TabIndex = 6
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.txtTotalNet)
        Me.Panel3.Controls.Add(Me.txtTotalVat)
        Me.Panel3.Controls.Add(Me.btnExport)
        Me.Panel3.Controls.Add(Me.lbltotalVAT)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.txtTotalCost)
        Me.Panel3.Controls.Add(Me.txtTotalQuantity)
        Me.Panel3.Location = New System.Drawing.Point(12, 405)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1016, 47)
        Me.Panel3.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(793, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 20)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "NetCost (MK)"
        '
        'txtTotalNet
        '
        Me.txtTotalNet.Enabled = False
        Me.txtTotalNet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNet.Location = New System.Drawing.Point(903, 14)
        Me.txtTotalNet.Name = "txtTotalNet"
        Me.txtTotalNet.Size = New System.Drawing.Size(100, 26)
        Me.txtTotalNet.TabIndex = 8
        '
        'txtTotalVat
        '
        Me.txtTotalVat.Enabled = False
        Me.txtTotalVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalVat.Location = New System.Drawing.Point(675, 14)
        Me.txtTotalVat.Name = "txtTotalVat"
        Me.txtTotalVat.Size = New System.Drawing.Size(100, 26)
        Me.txtTotalVat.TabIndex = 7
        '
        'lbltotalVAT
        '
        Me.lbltotalVAT.AutoSize = True
        Me.lbltotalVAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalVAT.Location = New System.Drawing.Point(574, 17)
        Me.lbltotalVAT.Name = "lbltotalVAT"
        Me.lbltotalVAT.Size = New System.Drawing.Size(77, 20)
        Me.lbltotalVAT.TabIndex = 6
        Me.lbltotalVAT.Text = "VAT (MK)"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(329, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(118, 20)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Total Cost (MK)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(100, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 20)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Total Quantity"
        '
        'txtTotalCost
        '
        Me.txtTotalCost.Enabled = False
        Me.txtTotalCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalCost.Location = New System.Drawing.Point(453, 14)
        Me.txtTotalCost.Name = "txtTotalCost"
        Me.txtTotalCost.Size = New System.Drawing.Size(100, 26)
        Me.txtTotalCost.TabIndex = 1
        '
        'txtTotalQuantity
        '
        Me.txtTotalQuantity.Enabled = False
        Me.txtTotalQuantity.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalQuantity.Location = New System.Drawing.Point(213, 11)
        Me.txtTotalQuantity.Name = "txtTotalQuantity"
        Me.txtTotalQuantity.Size = New System.Drawing.Size(100, 26)
        Me.txtTotalQuantity.TabIndex = 0
        '
        'comPurchaseType
        '
        Me.comPurchaseType.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.comPurchaseType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comPurchaseType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comPurchaseType.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comPurchaseType.FormattingEnabled = True
        Me.comPurchaseType.Items.AddRange(New Object() {"All", "Cash", "Credit"})
        Me.comPurchaseType.Location = New System.Drawing.Point(951, 22)
        Me.comPurchaseType.Name = "comPurchaseType"
        Me.comPurchaseType.Size = New System.Drawing.Size(88, 28)
        Me.comPurchaseType.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dgvPurchases)
        Me.Panel1.Location = New System.Drawing.Point(12, 56)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1027, 343)
        Me.Panel1.TabIndex = 11
        '
        'dgvPurchases
        '
        Me.dgvPurchases.AllowUserToAddRows = False
        Me.dgvPurchases.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvPurchases.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPurchases.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvPurchases.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPurchases.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvPurchases.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvPurchases.Location = New System.Drawing.Point(0, 0)
        Me.dgvPurchases.Name = "dgvPurchases"
        Me.dgvPurchases.ReadOnly = True
        Me.dgvPurchases.Size = New System.Drawing.Size(1027, 343)
        Me.dgvPurchases.TabIndex = 1
        '
        'PurchasesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1058, 499)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnLast)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.comPurchaseType)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.btnFirst)
        Me.Controls.Add(Me.comYear)
        Me.Controls.Add(Me.comProduct)
        Me.Controls.Add(Me.comMonth)
        Me.Name = "PurchasesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Purchases"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dgvPurchases, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents comMonth As System.Windows.Forms.ComboBox
    Friend WithEvents btnLast As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnFirst As System.Windows.Forms.Button
    Friend WithEvents comProduct As System.Windows.Forms.ComboBox
    Friend WithEvents comYear As System.Windows.Forms.ComboBox
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalCost As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalQuantity As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalVat As System.Windows.Forms.TextBox
    Friend WithEvents lbltotalVAT As System.Windows.Forms.Label
    Friend WithEvents comPurchaseType As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalNet As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dgvPurchases As System.Windows.Forms.DataGridView
End Class
