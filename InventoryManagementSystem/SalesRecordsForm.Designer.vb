<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesRecordsForm
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
        Me.comYear = New System.Windows.Forms.ComboBox()
        Me.comMonth = New System.Windows.Forms.ComboBox()
        Me.dgvSales = New System.Windows.Forms.DataGridView()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtRefNumber = New System.Windows.Forms.TextBox()
        Me.txtTotalGrossSales = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTotalVat = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalNetSales = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.comProduct = New System.Windows.Forms.ComboBox()
        Me.btnEditBatch = New System.Windows.Forms.Button()
        CType(Me.dgvSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'comYear
        '
        Me.comYear.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.comYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comYear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comYear.FormattingEnabled = True
        Me.comYear.Location = New System.Drawing.Point(12, 17)
        Me.comYear.Name = "comYear"
        Me.comYear.Size = New System.Drawing.Size(88, 28)
        Me.comYear.TabIndex = 9
        '
        'comMonth
        '
        Me.comMonth.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.comMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comMonth.FormattingEnabled = True
        Me.comMonth.Items.AddRange(New Object() {"All Months", "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"})
        Me.comMonth.Location = New System.Drawing.Point(134, 17)
        Me.comMonth.Name = "comMonth"
        Me.comMonth.Size = New System.Drawing.Size(192, 28)
        Me.comMonth.TabIndex = 8
        '
        'dgvSales
        '
        Me.dgvSales.AllowUserToAddRows = False
        Me.dgvSales.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvSales.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvSales.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = "---"
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvSales.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvSales.Location = New System.Drawing.Point(0, 0)
        Me.dgvSales.Name = "dgvSales"
        Me.dgvSales.ReadOnly = True
        Me.dgvSales.Size = New System.Drawing.Size(1003, 311)
        Me.dgvSales.TabIndex = 7
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(261, 5)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(67, 30)
        Me.btnExport.TabIndex = 4
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(80, 5)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(53, 30)
        Me.btnEdit.TabIndex = 3
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(6, 5)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(53, 30)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(940, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 33)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(630, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(150, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Search Ref Number"
        '
        'txtRefNumber
        '
        Me.txtRefNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNumber.Location = New System.Drawing.Point(795, 12)
        Me.txtRefNumber.Name = "txtRefNumber"
        Me.txtRefNumber.Size = New System.Drawing.Size(131, 32)
        Me.txtRefNumber.TabIndex = 0
        '
        'txtTotalGrossSales
        '
        Me.txtTotalGrossSales.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalGrossSales.Enabled = False
        Me.txtTotalGrossSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalGrossSales.Location = New System.Drawing.Point(526, 10)
        Me.txtTotalGrossSales.Name = "txtTotalGrossSales"
        Me.txtTotalGrossSales.Size = New System.Drawing.Size(120, 26)
        Me.txtTotalGrossSales.TabIndex = 50
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(424, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 20)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "Gross Sales"
        '
        'txtTotalVat
        '
        Me.txtTotalVat.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalVat.Enabled = False
        Me.txtTotalVat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalVat.Location = New System.Drawing.Point(698, 9)
        Me.txtTotalVat.Name = "txtTotalVat"
        Me.txtTotalVat.Size = New System.Drawing.Size(114, 26)
        Me.txtTotalVat.TabIndex = 52
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(652, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 20)
        Me.Label1.TabIndex = 51
        Me.Label1.Text = "VAT"
        '
        'txtTotalNetSales
        '
        Me.txtTotalNetSales.BackColor = System.Drawing.SystemColors.Control
        Me.txtTotalNetSales.Enabled = False
        Me.txtTotalNetSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNetSales.Location = New System.Drawing.Point(891, 7)
        Me.txtTotalNetSales.Name = "txtTotalNetSales"
        Me.txtTotalNetSales.Size = New System.Drawing.Size(114, 26)
        Me.txtTotalNetSales.TabIndex = 54
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(808, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Net Sales"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnEditBatch)
        Me.Panel1.Controls.Add(Me.btnDelete)
        Me.Panel1.Controls.Add(Me.txtTotalGrossSales)
        Me.Panel1.Controls.Add(Me.txtTotalNetSales)
        Me.Panel1.Controls.Add(Me.btnNew)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.btnEdit)
        Me.Panel1.Controls.Add(Me.txtTotalVat)
        Me.Panel1.Controls.Add(Me.btnExport)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(12, 382)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1015, 43)
        Me.Panel1.TabIndex = 55
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(334, 6)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(71, 30)
        Me.btnDelete.TabIndex = 55
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvSales)
        Me.Panel2.Location = New System.Drawing.Point(12, 51)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1003, 311)
        Me.Panel2.TabIndex = 56
        '
        'comProduct
        '
        Me.comProduct.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.comProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comProduct.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comProduct.FormattingEnabled = True
        Me.comProduct.Location = New System.Drawing.Point(355, 17)
        Me.comProduct.Name = "comProduct"
        Me.comProduct.Size = New System.Drawing.Size(192, 28)
        Me.comProduct.TabIndex = 57
        '
        'btnEditBatch
        '
        Me.btnEditBatch.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.btnEditBatch.Enabled = False
        Me.btnEditBatch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEditBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditBatch.Location = New System.Drawing.Point(150, 6)
        Me.btnEditBatch.Name = "btnEditBatch"
        Me.btnEditBatch.Size = New System.Drawing.Size(95, 30)
        Me.btnEditBatch.TabIndex = 56
        Me.btnEditBatch.Text = "Edit Batch"
        Me.btnEditBatch.UseVisualStyleBackColor = False
        '
        'SalesRecordsForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1027, 435)
        Me.Controls.Add(Me.comProduct)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtRefNumber)
        Me.Controls.Add(Me.comYear)
        Me.Controls.Add(Me.comMonth)
        Me.Name = "SalesRecordsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Records"
        CType(Me.dgvSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents comYear As System.Windows.Forms.ComboBox
    Friend WithEvents comMonth As System.Windows.Forms.ComboBox
    Friend WithEvents dgvSales As System.Windows.Forms.DataGridView
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRefNumber As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalGrossSales As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTotalVat As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtTotalNetSales As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents comProduct As System.Windows.Forms.ComboBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEditBatch As System.Windows.Forms.Button
End Class
