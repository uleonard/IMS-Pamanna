Public Class EditUserForm

    Private Sub EditUserForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtStaffID.Text = ManageUsersForm.dgvUsers.Rows(ManageUsersForm.dgvUsers.CurrentRow.Index).Cells("STAFF ID").Value
        txtFirstname.Text = ManageUsersForm.dgvUsers.Rows(ManageUsersForm.dgvUsers.CurrentRow.Index).Cells("FIRSTNAME").Value
        txtSurname.Text = ManageUsersForm.dgvUsers.Rows(ManageUsersForm.dgvUsers.CurrentRow.Index).Cells("SURNAME").Value
        txtUsername.Text = ManageUsersForm.dgvUsers.Rows(ManageUsersForm.dgvUsers.CurrentRow.Index).Cells("USERNAME").Value
        comRole.Text = ManageUsersForm.dgvUsers.Rows(ManageUsersForm.dgvUsers.CurrentRow.Index).Cells("ROLE").Value
        txtUsernameCurrent.Text = ManageUsersForm.dgvUsers.Rows(ManageUsersForm.dgvUsers.CurrentRow.Index).Cells("USERNAME").Value
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtStaffID.Text = "" Then
            MsgBox("Staff ID cannot be empty")
            Exit Sub
        End If
        If txtUsername.Text = "" Then
            MsgBox("Username cannot be empty")
            Exit Sub
        End If
        If comRole.Text = "" Then
            MsgBox("Role cannot be empty")
            Exit Sub
        End If
        Dim Usr As UserTable = New UserTable()
        Usr.EditUser()
        Me.Close()

    End Sub
    'DO THIS WHEN CANCEL BUTTON OR DEFAULT X BUTTONS ARE CLICKED
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click, Me.FormClosing
        Dim Usr As UserTable = New UserTable()
        Usr.loadDatagridUsers() 'RELOAD DATAGRID
        Me.Dispose()
    End Sub
End Class