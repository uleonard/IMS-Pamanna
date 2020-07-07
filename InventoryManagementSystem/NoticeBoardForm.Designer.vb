<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NoticeBoardForm
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblDueSoon = New System.Windows.Forms.Label()
        Me.lblDueToday = New System.Windows.Forms.Label()
        Me.lblPastDue = New System.Windows.Forms.Label()
        Me.dgvDueSoon = New System.Windows.Forms.DataGridView()
        Me.dgvDueToday = New System.Windows.Forms.DataGridView()
        Me.dgvPastDue = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDueSoon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDueToday, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvPastDue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.GroupBox1.Controls.Add(Me.lblDueSoon)
        Me.GroupBox1.Controls.Add(Me.lblDueToday)
        Me.GroupBox1.Controls.Add(Me.lblPastDue)
        Me.GroupBox1.Controls.Add(Me.dgvDueSoon)
        Me.GroupBox1.Controls.Add(Me.dgvDueToday)
        Me.GroupBox1.Controls.Add(Me.dgvPastDue)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(410, 530)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'lblDueSoon
        '
        Me.lblDueSoon.AutoSize = True
        Me.lblDueSoon.Location = New System.Drawing.Point(11, 364)
        Me.lblDueSoon.Name = "lblDueSoon"
        Me.lblDueSoon.Size = New System.Drawing.Size(81, 20)
        Me.lblDueSoon.TabIndex = 7
        Me.lblDueSoon.Text = "Due Soon"
        '
        'lblDueToday
        '
        Me.lblDueToday.AutoSize = True
        Me.lblDueToday.Location = New System.Drawing.Point(6, 202)
        Me.lblDueToday.Name = "lblDueToday"
        Me.lblDueToday.Size = New System.Drawing.Size(86, 20)
        Me.lblDueToday.TabIndex = 6
        Me.lblDueToday.Text = "Due Today"
        '
        'lblPastDue
        '
        Me.lblPastDue.AutoSize = True
        Me.lblPastDue.Location = New System.Drawing.Point(11, 45)
        Me.lblPastDue.Name = "lblPastDue"
        Me.lblPastDue.Size = New System.Drawing.Size(75, 20)
        Me.lblPastDue.TabIndex = 5
        Me.lblPastDue.Text = "Past Due"
        '
        'dgvDueSoon
        '
        Me.dgvDueSoon.AllowUserToAddRows = False
        Me.dgvDueSoon.AllowUserToDeleteRows = False
        Me.dgvDueSoon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDueSoon.BackgroundColor = System.Drawing.SystemColors.InactiveBorder
        Me.dgvDueSoon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDueSoon.Location = New System.Drawing.Point(6, 387)
        Me.dgvDueSoon.Name = "dgvDueSoon"
        Me.dgvDueSoon.ReadOnly = True
        Me.dgvDueSoon.Size = New System.Drawing.Size(397, 122)
        Me.dgvDueSoon.TabIndex = 1
        '
        'dgvDueToday
        '
        Me.dgvDueToday.AllowUserToAddRows = False
        Me.dgvDueToday.AllowUserToDeleteRows = False
        Me.dgvDueToday.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDueToday.BackgroundColor = System.Drawing.SystemColors.InactiveBorder
        Me.dgvDueToday.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDueToday.Location = New System.Drawing.Point(6, 225)
        Me.dgvDueToday.Name = "dgvDueToday"
        Me.dgvDueToday.ReadOnly = True
        Me.dgvDueToday.Size = New System.Drawing.Size(397, 122)
        Me.dgvDueToday.TabIndex = 2
        '
        'dgvPastDue
        '
        Me.dgvPastDue.AllowUserToAddRows = False
        Me.dgvPastDue.AllowUserToDeleteRows = False
        Me.dgvPastDue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPastDue.BackgroundColor = System.Drawing.SystemColors.InactiveBorder
        Me.dgvPastDue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPastDue.Location = New System.Drawing.Point(6, 68)
        Me.dgvPastDue.Name = "dgvPastDue"
        Me.dgvPastDue.ReadOnly = True
        Me.dgvPastDue.Size = New System.Drawing.Size(397, 122)
        Me.dgvPastDue.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pay Your Suppliers"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(789, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(230, 530)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Other Reminders"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(214, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Phone calls. emails, and other appointments"
        '
        'NoticeBoardForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(434, 633)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "NoticeBoardForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Notice Board"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvDueSoon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDueToday, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvPastDue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvPastDue As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDueSoon As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDueToday As System.Windows.Forms.DataGridView
    Friend WithEvents lblDueSoon As System.Windows.Forms.Label
    Friend WithEvents lblDueToday As System.Windows.Forms.Label
    Friend WithEvents lblPastDue As System.Windows.Forms.Label
End Class
