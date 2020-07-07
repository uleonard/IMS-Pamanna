Public Class LoginForm

    Private Sub LoginForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Panel1.Left = Me.Width / 2 - Panel1.Width / 2
        Panel1.Top = Me.Height / 2 - Panel1.Height / 2
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        End
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim ut As UserTable = New UserTable()
        ut.authenticate()

    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim ut As UserTable = New UserTable()
            ut.authenticate()
        End If
    End Sub

    Private Sub txtPassword_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtPassword.TextChanged

    End Sub
End Class
