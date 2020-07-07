<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VoidSaleTransactionForm
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtUnitPrice2 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.btnVoid = New System.Windows.Forms.Button()
        Me.txtTotalPrice = New System.Windows.Forms.TextBox()
        Me.txtUnitPrice = New System.Windows.Forms.TextBox()
        Me.txtQty = New System.Windows.Forms.TextBox()
        Me.txtPLU = New System.Windows.Forms.TextBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtProduct = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.comType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.comType)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtProduct)
        Me.Panel1.Controls.Add(Me.btnCancel)
        Me.Panel1.Controls.Add(Me.txtUnitPrice2)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtCode)
        Me.Panel1.Controls.Add(Me.btnVoid)
        Me.Panel1.Controls.Add(Me.txtTotalPrice)
        Me.Panel1.Controls.Add(Me.txtUnitPrice)
        Me.Panel1.Controls.Add(Me.txtQty)
        Me.Panel1.Controls.Add(Me.txtPLU)
        Me.Panel1.Location = New System.Drawing.Point(12, 33)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(787, 157)
        Me.Panel1.TabIndex = 12
        '
        'txtUnitPrice2
        '
        Me.txtUnitPrice2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtUnitPrice2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitPrice2.Location = New System.Drawing.Point(318, 70)
        Me.txtUnitPrice2.Name = "txtUnitPrice2"
        Me.txtUnitPrice2.Size = New System.Drawing.Size(129, 35)
        Me.txtUnitPrice2.TabIndex = 14
        Me.txtUnitPrice2.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(481, 14)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(130, 29)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "Total Price"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(313, 14)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(117, 29)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Unit Price"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(124, 29)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "PLU Code"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(157, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 29)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Quantity"
        '
        'txtCode
        '
        Me.txtCode.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(17, 74)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(120, 35)
        Me.txtCode.TabIndex = 8
        Me.txtCode.Visible = False
        '
        'btnVoid
        '
        Me.btnVoid.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnVoid.Enabled = False
        Me.btnVoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnVoid.Location = New System.Drawing.Point(483, 108)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(137, 46)
        Me.btnVoid.TabIndex = 2
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = False
        '
        'txtTotalPrice
        '
        Me.txtTotalPrice.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtTotalPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPrice.Location = New System.Drawing.Point(486, 46)
        Me.txtTotalPrice.Name = "txtTotalPrice"
        Me.txtTotalPrice.ReadOnly = True
        Me.txtTotalPrice.Size = New System.Drawing.Size(134, 35)
        Me.txtTotalPrice.TabIndex = 6
        '
        'txtUnitPrice
        '
        Me.txtUnitPrice.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtUnitPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnitPrice.Location = New System.Drawing.Point(318, 46)
        Me.txtUnitPrice.Name = "txtUnitPrice"
        Me.txtUnitPrice.ReadOnly = True
        Me.txtUnitPrice.Size = New System.Drawing.Size(129, 35)
        Me.txtUnitPrice.TabIndex = 5
        '
        'txtQty
        '
        Me.txtQty.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(162, 46)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(120, 35)
        Me.txtQty.TabIndex = 1
        '
        'txtPLU
        '
        Me.txtPLU.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtPLU.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPLU.Location = New System.Drawing.Point(9, 46)
        Me.txtPLU.Name = "txtPLU"
        Me.txtPLU.Size = New System.Drawing.Size(126, 35)
        Me.txtPLU.TabIndex = 0
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(638, 105)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(134, 46)
        Me.btnCancel.TabIndex = 15
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(525, 29)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Enter PLU code and quantity of a product to void"
        '
        'txtProduct
        '
        Me.txtProduct.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txtProduct.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProduct.Location = New System.Drawing.Point(110, 114)
        Me.txtProduct.Name = "txtProduct"
        Me.txtProduct.Size = New System.Drawing.Size(337, 35)
        Me.txtProduct.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 29)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Product"
        '
        'comType
        '
        Me.comType.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.comType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comType.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.comType.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comType.FormattingEnabled = True
        Me.comType.Items.AddRange(New Object() {"Cash", "Charge", "Credit", "Check"})
        Me.comType.Location = New System.Drawing.Point(651, 46)
        Me.comType.Name = "comType"
        Me.comType.Size = New System.Drawing.Size(121, 37)
        Me.comType.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(642, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(135, 29)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Sales Type"
        '
        'VoidSaleTransactionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(811, 196)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "VoidSaleTransactionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VoidSaleTransactionForm"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtUnitPrice2 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents btnVoid As System.Windows.Forms.Button
    Friend WithEvents txtTotalPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtUnitPrice As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents txtPLU As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtProduct As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents comType As System.Windows.Forms.ComboBox
End Class
