Public Class HomeForm

    Private Sub HomeForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Width = MDIManager.Width
        Me.Top = MDIManager.Top + 200
        Me.Height = 500

    End Sub
End Class