Imports System.Data
Imports System.Data.OleDb
Public Class SettingsForm

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        Dim myConnection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        For i As Integer = 0 To dgvSettings.RowCount() - 1
            Dim SettingName As String = dgvSettings.Rows(i).Cells(0).Value()
            Dim SettingValue As String = dgvSettings.Rows(i).Cells(1).Value()



            Dim str As String
            str = "UPDATE settings SET [value] = ? WHERE [name] = ?"
            Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
            cmd.Parameters.Add(New OleDbParameter("value", CType(SettingValue, String)))
            cmd.Parameters.Add(New OleDbParameter("name", CType(SettingName, String)))

            Try
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Next
        MsgBox("SAVED!!!")
        myConnection.Close()
        Me.Dispose()
    End Sub

    Private Sub SettingsForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim myConnection As OleDbConnection = New OleDbConnection

        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT * FROM settings ORDER BY [name]", myConnection)

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)

        dgvSettings.AutoGenerateColumns = True
        dgvSettings.DataSource = dt
        dgvSettings.Refresh()
        dgvSettings.AllowUserToAddRows = False
        dgvSettings.Columns(0).ReadOnly = True
        dgvSettings.Columns(2).ReadOnly = True
        reader.Close()

        myConnection.Close()

        ReadDatabasePath()
    End Sub
    Public Sub ReadDatabasePath()
        Dim FILE_NAME As String = Application.StartupPath & "\\database_path.txt"

        If System.IO.File.Exists(FILE_NAME) = True Then

            Dim objReader As New System.IO.StreamReader(FILE_NAME)

            txtDbPath.Text = objReader.ReadLine()
            objReader.Close()
        Else

            MsgBox("File Does Not Exist")

        End If
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click, Me.FormClosed

        Me.Dispose()

    End Sub

    Private Sub btnSaveDbPath_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveDbPath.Click
        Dim FILE_NAME As String = Application.StartupPath & "\\database_path.txt"

        If System.IO.File.Exists(FILE_NAME) = True Then

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

            objWriter.Write(txtDbPath.Text)
            objWriter.Close()
            MsgBox("Database Path saved!!!")
            Me.Dispose()

        Else

            MsgBox("File Does Not Exist")

        End If
    End Sub
End Class