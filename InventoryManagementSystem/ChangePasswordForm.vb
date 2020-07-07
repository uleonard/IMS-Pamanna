Imports System.Data
Imports System.Data.OleDb
Imports System.Data.DataTable
Public Class ChangePasswordForm
    Dim ds As DataSet = New DataSet

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click, Me.FormClosing
        Me.Dispose()


    End Sub

    Private Sub btnSavePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePassword.Click
        Dim usr As UserTable = New UserTable()
        Dim dt As DataTable = usr.getUserByUsername()
        If dt.Rows.Count = 1 Then
            'MsgBox(dt.Rows(0).Item("username"))
            If Not dt.Rows(0).Item("password") = usr.EncriptPassword(txtOldPassword.Text) Then
                MsgBox("Current password is invalid")
                txtOldPassword.Text = ""
                txtOldPassword.Focus()

            Else
                If Not txtNewPassword.Text = txtNewPasswordAgain.Text Then
                    MsgBox("New passwords do not match")
                    txtNewPassword.Text = ""
                    txtNewPasswordAgain.Text = ""
                    txtNewPassword.Focus()

                Else
                    'MsgBox("Password changed")
                    usr.ChangePassword(txtNewPassword.Text)
                    Me.Close()

                End If
            End If
        Else
            MsgBox("Username not found")
        End If

    End Sub
End Class