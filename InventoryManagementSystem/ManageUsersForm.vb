Public Class ManageUsersForm

    Private Sub ManageUsersForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim Usr As UserTable = New UserTable()
        Usr.loadDatagridUsers()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
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
        Usr.AddUser()

        Usr.loadDatagridUsers() 'RELOAD DATAGRID
        txtFirstname.Text = ""
        txtPassword.Text = ""
        txtStaffID.Text = ""
        txtSurname.Text = ""
        txtUsername.Text = ""
        txtStaffID.Focus()
    End Sub

    Private Sub txtUsername_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsername.TextChanged
        txtPassword.Text = txtUsername.Text

    End Sub

    Private Sub btnChangeStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeStatus.Click
        If dgvUsers.Rows(dgvUsers.CurrentRow.Index).Cells("USERNAME").Value = UserTable.username Then
            MsgBox("You cannot change your own activity status.", vbOK + vbCritical)
            Exit Sub
        End If
        Dim user As String = dgvUsers.Rows(dgvUsers.CurrentRow.Index).Cells("USERNAME").Value

        If dgvUsers.Rows(dgvUsers.CurrentRow.Index).Cells("STATUS").Value = "Active" Then
            Dim res As MsgBoxResult = MsgBox("You have selected to deactivate user : " & user & vbCrLf & "IS THIS IN ORDER ? ", vbYesNo + vbQuestion, "Inventory Management System")
            If res = vbYes Then
                Dim Usr As UserTable = New UserTable()
                Usr.ChangeStatus(user, "Not Active")
                Usr.loadDatagridUsers() 'RELOAD DATAGRID
            End If
        Else
            Dim res As MsgBoxResult = MsgBox("You have selected to activate user : " & user & vbCrLf & "IS THIS IN ORDER ? ", vbYesNo + vbQuestion, "Inventory Management System")
            If res = vbYes Then
                Dim Usr As UserTable = New UserTable()
                Usr.ChangeStatus(user, "Active")
                Usr.loadDatagridUsers() 'RELOAD DATAGRID
            End If
        End If

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        EditUserForm.ShowDialog()

    End Sub

    Private Sub btnResetPassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetPassword.Click
        Dim user As String = dgvUsers.Rows(dgvUsers.CurrentRow.Index).Cells("USERNAME").Value

        Dim res As MsgBoxResult = MsgBox("You have selected to reset password for user : " & user & vbCrLf & "IS THIS IN ORDER ? ", vbYesNo + vbQuestion, "Inventory Management System")
            If res = vbYes Then
                Dim Usr As UserTable = New UserTable()
            Usr.ResetPassword(user)
                Usr.loadDatagridUsers() 'RELOAD DATAGRID
            End If

    End Sub
End Class