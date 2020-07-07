<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SalesSummaryReportForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SalesSummaryReportForm))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCheck = New System.Windows.Forms.TextBox()
        Me.txtCredit = New System.Windows.Forms.TextBox()
        Me.txtCash = New System.Windows.Forms.TextBox()
        Me.txtCharge = New System.Windows.Forms.TextBox()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPOCount = New System.Windows.Forms.TextBox()
        Me.txtPO = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRACount = New System.Windows.Forms.TextBox()
        Me.txtRA = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtVoidCount = New System.Windows.Forms.TextBox()
        Me.txtVoidAmount = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtCID = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.txtRefNumber = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtVAT = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.PrintForm = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.lblClose = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 24)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cash Sales"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtCheck)
        Me.GroupBox1.Controls.Add(Me.txtCredit)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtCash)
        Me.GroupBox1.Controls.Add(Me.txtCharge)
        Me.GroupBox1.Controls.Add(Me.txtTotal)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(66, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(509, 222)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sales"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(20, 174)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(199, 24)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Total Sales (Net Sales)"
        '
        'txtCheck
        '
        Me.txtCheck.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtCheck.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCheck.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCheck.Location = New System.Drawing.Point(294, 139)
        Me.txtCheck.Name = "txtCheck"
        Me.txtCheck.ReadOnly = True
        Me.txtCheck.Size = New System.Drawing.Size(183, 29)
        Me.txtCheck.TabIndex = 18
        '
        'txtCredit
        '
        Me.txtCredit.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtCredit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCredit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCredit.Location = New System.Drawing.Point(294, 104)
        Me.txtCredit.Name = "txtCredit"
        Me.txtCredit.ReadOnly = True
        Me.txtCredit.Size = New System.Drawing.Size(183, 29)
        Me.txtCredit.TabIndex = 17
        '
        'txtCash
        '
        Me.txtCash.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtCash.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCash.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCash.Location = New System.Drawing.Point(294, 31)
        Me.txtCash.Name = "txtCash"
        Me.txtCash.ReadOnly = True
        Me.txtCash.Size = New System.Drawing.Size(183, 29)
        Me.txtCash.TabIndex = 16
        '
        'txtCharge
        '
        Me.txtCharge.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtCharge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCharge.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCharge.Location = New System.Drawing.Point(294, 69)
        Me.txtCharge.Name = "txtCharge"
        Me.txtCharge.ReadOnly = True
        Me.txtCharge.Size = New System.Drawing.Size(183, 29)
        Me.txtCharge.TabIndex = 15
        '
        'txtTotal
        '
        Me.txtTotal.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotal.Location = New System.Drawing.Point(294, 174)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(183, 32)
        Me.txtTotal.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(20, 139)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 24)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Check Sales"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 24)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Credit Sales"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 24)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Charge Sales"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPOCount)
        Me.GroupBox2.Controls.Add(Me.txtPO)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtRACount)
        Me.GroupBox2.Controls.Add(Me.txtRA)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(66, 368)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(509, 182)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "RA And PO"
        '
        'txtPOCount
        '
        Me.txtPOCount.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtPOCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPOCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPOCount.Location = New System.Drawing.Point(294, 135)
        Me.txtPOCount.Name = "txtPOCount"
        Me.txtPOCount.ReadOnly = True
        Me.txtPOCount.Size = New System.Drawing.Size(183, 29)
        Me.txtPOCount.TabIndex = 19
        '
        'txtPO
        '
        Me.txtPO.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtPO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPO.Location = New System.Drawing.Point(294, 100)
        Me.txtPO.Name = "txtPO"
        Me.txtPO.ReadOnly = True
        Me.txtPO.Size = New System.Drawing.Size(183, 29)
        Me.txtPO.TabIndex = 18
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(20, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 24)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "PO Count"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 24)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "PO"
        '
        'txtRACount
        '
        Me.txtRACount.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtRACount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRACount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRACount.Location = New System.Drawing.Point(294, 65)
        Me.txtRACount.Name = "txtRACount"
        Me.txtRACount.ReadOnly = True
        Me.txtRACount.Size = New System.Drawing.Size(183, 29)
        Me.txtRACount.TabIndex = 15
        '
        'txtRA
        '
        Me.txtRA.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtRA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRA.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRA.Location = New System.Drawing.Point(294, 30)
        Me.txtRA.Name = "txtRA"
        Me.txtRA.ReadOnly = True
        Me.txtRA.Size = New System.Drawing.Size(183, 29)
        Me.txtRA.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(20, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 24)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "RA Count"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(20, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 24)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "RA"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtVoidCount)
        Me.GroupBox3.Controls.Add(Me.txtVoidAmount)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(66, 570)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(509, 115)
        Me.GroupBox3.TabIndex = 20
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Voided Sales"
        '
        'txtVoidCount
        '
        Me.txtVoidCount.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtVoidCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVoidCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVoidCount.Location = New System.Drawing.Point(294, 65)
        Me.txtVoidCount.Name = "txtVoidCount"
        Me.txtVoidCount.ReadOnly = True
        Me.txtVoidCount.Size = New System.Drawing.Size(183, 29)
        Me.txtVoidCount.TabIndex = 15
        '
        'txtVoidAmount
        '
        Me.txtVoidAmount.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtVoidAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVoidAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVoidAmount.Location = New System.Drawing.Point(294, 30)
        Me.txtVoidAmount.Name = "txtVoidAmount"
        Me.txtVoidAmount.ReadOnly = True
        Me.txtVoidAmount.Size = New System.Drawing.Size(183, 29)
        Me.txtVoidAmount.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(20, 65)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 24)
        Me.Label12.TabIndex = 12
        Me.Label12.Text = "Count"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(20, 30)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 24)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Amount"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtCID)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(66, 701)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(509, 71)
        Me.GroupBox4.TabIndex = 21
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Cash In Drawer"
        '
        'txtCID
        '
        Me.txtCID.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtCID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCID.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCID.Location = New System.Drawing.Point(294, 30)
        Me.txtCID.Name = "txtCID"
        Me.txtCID.ReadOnly = True
        Me.txtCID.Size = New System.Drawing.Size(183, 32)
        Me.txtCID.TabIndex = 14
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(20, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 24)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "C.I.D."
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnPrint.Enabled = False
        Me.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(-1, -1)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 27)
        Me.btnPrint.TabIndex = 22
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(86, 2)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(263, 24)
        Me.lblTitle.TabIndex = 20
        Me.lblTitle.Text = "Sales Report For Ref Number "
        '
        'txtRefNumber
        '
        Me.txtRefNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRefNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRefNumber.Location = New System.Drawing.Point(360, 3)
        Me.txtRefNumber.Name = "txtRefNumber"
        Me.txtRefNumber.Size = New System.Drawing.Size(131, 29)
        Me.txtRefNumber.TabIndex = 23
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(497, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(78, 30)
        Me.btnSearch.TabIndex = 24
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtVAT)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(66, 277)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(509, 71)
        Me.GroupBox5.TabIndex = 22
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "VAT"
        '
        'txtVAT
        '
        Me.txtVAT.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtVAT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVAT.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVAT.Location = New System.Drawing.Point(294, 30)
        Me.txtVAT.Name = "txtVAT"
        Me.txtVAT.ReadOnly = True
        Me.txtVAT.Size = New System.Drawing.Size(183, 29)
        Me.txtVAT.TabIndex = 14
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(20, 30)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(94, 24)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Total VAT"
        '
        'PrintForm
        '
        Me.PrintForm.DocumentName = "document"
        Me.PrintForm.Form = Me
        Me.PrintForm.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm.PrinterSettings = CType(resources.GetObject("PrintForm.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm.PrintFileName = Nothing
        '
        'lblClose
        '
        Me.lblClose.AutoSize = True
        Me.lblClose.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.lblClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClose.ForeColor = System.Drawing.Color.Red
        Me.lblClose.Location = New System.Drawing.Point(614, 2)
        Me.lblClose.Name = "lblClose"
        Me.lblClose.Size = New System.Drawing.Size(25, 24)
        Me.lblClose.TabIndex = 20
        Me.lblClose.Text = "X"
        '
        'SalesSummaryReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(641, 810)
        Me.Controls.Add(Me.lblClose)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtRefNumber)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SalesSummaryReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sales Summary Report"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCheck As System.Windows.Forms.TextBox
    Friend WithEvents txtCredit As System.Windows.Forms.TextBox
    Friend WithEvents txtCash As System.Windows.Forms.TextBox
    Friend WithEvents txtCharge As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPOCount As System.Windows.Forms.TextBox
    Friend WithEvents txtPO As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtRACount As System.Windows.Forms.TextBox
    Friend WithEvents txtRA As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtVoidCount As System.Windows.Forms.TextBox
    Friend WithEvents txtVoidAmount As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCID As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtRefNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtVAT As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents PrintForm As Microsoft.VisualBasic.PowerPacks.Printing.PrintForm
    Friend WithEvents lblClose As System.Windows.Forms.Label
End Class
