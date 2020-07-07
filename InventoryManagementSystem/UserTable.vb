Imports System.Data
Imports System.Data.OleDb
Imports System.Security.Cryptography 'for md5
Imports System.Text 'for md5
Imports System.IO ' for copying db file

Public Class UserTable
    Dim myConnection As OleDbConnection = New OleDbConnection
    Dim ds As DataSet = New DataSet
    Dim da As OleDbDataAdapter
    Dim tables As DataTableCollection = ds.Tables
    Dim source1 As New BindingSource()

    Public Shared username As String
    Public Shared role As String
    Public Shared firstname As String
    Public Shared surname As String
    Public Shared userId As String

    Public Shared DatabasePath As String
    Public Shared SupplierReminderDays As String

    Public Sub AddUser()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        If UsernameExists(ManageUsersForm.txtUsername.Text) Then
            MsgBox("This Username already exists. Please change!!!")
            Exit Sub
        End If
        Dim strPassword As String = EncriptPassword(ManageUsersForm.txtPassword.Text) 'Calls EncryptPassword function

        Dim str As String
        str = "INSERT INTO staff_member ([staff_id], [firstname], [surname], [username], [password], [role]) values (?, ?, ?, ?, ?, ?)"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("staff_id", CType(ManageUsersForm.txtStaffID.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("firstname", CType(ManageUsersForm.txtFirstname.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("surname", CType(ManageUsersForm.txtSurname.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("username", CType(ManageUsersForm.txtUsername.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("password", CType(strPassword, String)))
        cmd.Parameters.Add(New OleDbParameter("role", CType(ManageUsersForm.comRole.Text, String)))

        Try
            cmd.ExecuteNonQuery()
            MsgBox("User with username : " & ManageUsersForm.txtUsername.Text & " has been saved successfully!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()

    End Sub
    Public Sub EditUser()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        If EditUserForm.txtUsername.Text <> EditUserForm.txtUsernameCurrent.Text And UsernameExists(EditUserForm.txtUsername.Text) Then
            MsgBox("This Username already exists. Please change!!!")
            Exit Sub
        End If
        
        Dim str As String
        str = "UPDATE staff_member SET [staff_id] = ?, [firstname] = ?, [surname] =? , [username] = ?, [role] = ? WHERE [username] = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("staff_id", CType(EditUserForm.txtStaffID.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("firstname", CType(EditUserForm.txtFirstname.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("surname", CType(EditUserForm.txtSurname.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("username", CType(EditUserForm.txtUsername.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("role", CType(EditUserForm.comRole.Text, String)))
        cmd.Parameters.Add(New OleDbParameter("username", CType(EditUserForm.txtUsernameCurrent.Text, String)))

        Try
            cmd.ExecuteNonQuery()
            MsgBox("User has been updated.")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()

    End Sub
    Private Function UsernameExists(ByVal user As String) As Boolean
        Dim connection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        connection.ConnectionString = dbCon.dbConnector()
        connection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT COUNT(username) FROM staff_member WHERE [username] = ? ", connection)
        cmd.Parameters.Add(New OleDbParameter("username", CType(user, String)))

        If cmd.ExecuteScalar() = 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Sub authenticate()



        Try

            Dim dbCon As DbConnection = New DbConnection()
            myConnection.ConnectionString = dbCon.dbConnector()
            myConnection.Open()


            Dim strUsername As String = LoginForm.txtUsername.Text
            Dim strPassword As String = EncriptPassword(LoginForm.txtPassword.Text) 'Calls EncryptPassword function

            da = New OleDbDataAdapter("SELECT * FROM [staff_member] WHERE username = '" & strUsername & "' AND password = '" & strPassword & "'", myConnection)
            da.Fill(ds, "user")

            Dim Count As Integer = 0
            For i = 0 To ds.Tables("user").Rows.Count - 1
                Count = Count + 1
            Next

            'if count = 1 (user found) then login user
            If Count = 1 Then
                If ds.Tables("user").Rows(0).Item("status") = "Active" Then
                    'Set Shared (Static) variables to user details
                    username = ds.Tables("user").Rows(0).Item("username")
                    role = ds.Tables("user").Rows(0).Item("role")
                    firstname = ds.Tables("user").Rows(0).Item("firstname")
                    surname = ds.Tables("user").Rows(0).Item("surname")
                    userId = ds.Tables("user").Rows(0).Item("staff_id")

                    ' If role = "MANAGER" Then

                    LoginForm.Hide()

                    MDIManager.Show()

                Else
                    MsgBox("You are not active user. Contact Manager to be activated.")
                    LoginForm.txtUsername.Text = ""
                    LoginForm.txtPassword.Text = ""
                    LoginForm.txtUsername.Focus()
                End If
            Else
                MsgBox("Invalid Credentials")
                LoginForm.txtUsername.Text = ""
                LoginForm.txtPassword.Text = ""
                LoginForm.txtUsername.Focus()

            End If

            myConnection.Close()
        Catch ex As Exception


            If LoginForm.OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try

                    Dim strLocation As String = Nothing
                    strLocation = LoginForm.OpenFileDialog1.FileName

                    File.Copy(strLocation, Application.StartupPath & "\\ims.mdb", True)
                    MsgBox("Database inclusion successful!!")

                Catch ex2 As Exception
                    MessageBox.Show(ex2.Message, My.Application.Info.Title, _
                    MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Try
    End Sub



    Public Function EncriptPassword(ByVal password As String) As String
        'ENCRPT PASSWORD USING MD5
        Dim bytHashedData As Byte()
        Dim encoder As New UTF8Encoding()
        Dim md5Hasher As New MD5CryptoServiceProvider
        bytHashedData = md5Hasher.ComputeHash(encoder.GetBytes(password))

        Return Convert.ToBase64String(bytHashedData)

    End Function
    Public Function getUserByUsername() As DataTable
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        da = New OleDbDataAdapter("SELECT * FROM [staff_member] WHERE username = '" & username & "'", myConnection)
        da.Fill(ds, "user")
        myConnection.Close()

        Return ds.Tables("user")

    End Function
    Public Sub ChangePassword(ByVal password As String)
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim strPassword As String = EncriptPassword(password) 'Calls EncryptPassword function

        Dim str As String
        str = "UPDATE staff_member SET [password] = ? WHERE [username] = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("password", CType(strPassword, String)))
        cmd.Parameters.Add(New OleDbParameter("username", CType(username, String)))

        Try
            cmd.ExecuteNonQuery()

            MessageBox.Show("Password Changed Successfully!!!")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub ResetPassword(ByVal user As String)
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim strPassword As String = EncriptPassword(user) 'Calls EncryptPassword function

        Dim str As String
        str = "UPDATE staff_member SET [password] = ? WHERE [username] = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("password", CType(strPassword, String)))
        cmd.Parameters.Add(New OleDbParameter("username", CType(user, String)))

        Try
            cmd.ExecuteNonQuery()

            MessageBox.Show("Password Changed Successfully!!!")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub ChangeStatus(ByVal User As String, ByVal Status As String)
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim str As String
        str = "UPDATE staff_member SET [status] = ? WHERE [username] = ?"
        Dim cmd As OleDbCommand = New OleDbCommand(str, myConnection)
        cmd.Parameters.Add(New OleDbParameter("status", CType(Status, String)))
        cmd.Parameters.Add(New OleDbParameter("username", CType(User, String)))

        Try
            cmd.ExecuteNonQuery()

            MessageBox.Show("Status for User : " & User & " has been changed to " & Status)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        myConnection.Close()
    End Sub
    Public Sub loadDatagridUsers()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()
        ds.Reset()

        da = New OleDbDataAdapter("SELECT [staff_id] AS [STAFF ID], [firstname] AS [FIRSTNAME], [surname] AS [SURNAME], [username] AS [USERNAME], [role] AS [ROLE], [status] AS [STATUS] FROM staff_member", myConnection)
        da.Fill(ds, "users")
        Dim view1 As New DataView(tables(0))
        source1.DataSource = view1
        ManageUsersForm.dgvUsers.DataSource = view1
        ManageUsersForm.Refresh()

        myConnection.Close()
    End Sub
End Class
