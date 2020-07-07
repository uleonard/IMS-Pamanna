Imports System.Data
Imports System.Data.OleDb
Public Class NoticeBoardForm
    Dim myConnection As OleDbConnection = New OleDbConnection
    
    Private Sub NoticeBoardForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PastDue()
        DueToday()
        DueSoon()
    End Sub
    Private Sub PastDue()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim dateString As String = Now.Month & "/" & Now.Day & "/" & Now.Year
        Dim DateNow As Date = Date.Parse(dateString)
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT DISTINCT grn AS [GRN], supplied_by AS [SUPPLIER], payment_due AS [PAYMENT DUE] FROM purchases WHERE payment_due < ? AND payment_status= ?  AND status = ?", myConnection)
        cmd.Parameters.Add(New OleDbParameter("payment_due", CType(DateNow, String)))
        cmd.Parameters.Add(New OleDbParameter("payment_status", CType("Not Paid", String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("ACTIVE", String)))

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)

        dgvPastDue.AutoGenerateColumns = True
        dgvPastDue.DataSource = dt
        dgvPastDue.Refresh()
        dgvPastDue.AllowUserToAddRows = False
      
        lblPastDue.Text = "Past Due - " & dgvPastDue.RowCount & " GRNs"

        reader.Close()

        myConnection.Close()
    End Sub
    Private Sub DueToday()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim dateString As String = Now.Month & "/" & Now.Day & "/" & Now.Year
        Dim DateNow As Date = Date.Parse(dateString)
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT DISTINCT grn AS [GRN], supplied_by AS [SUPPLIER], payment_due AS [PAYMENT DUE] FROM purchases WHERE payment_due = ? AND payment_status= ? AND status = ?", myConnection)
        cmd.Parameters.Add(New OleDbParameter("payment_due", CType(DateNow, String)))
        cmd.Parameters.Add(New OleDbParameter("payment_status", CType("Not Paid", String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("ACTIVE", String)))

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()

        Dim dt = New DataTable()
        dt.Load(reader)

        dgvDueToday.AutoGenerateColumns = True
        dgvDueToday.DataSource = dt
        dgvDueToday.Refresh()
        dgvDueToday.AllowUserToAddRows = False

        lblDueToday.Text = "Due Today - " & dgvDueToday.RowCount & " GRNs"

        reader.Close()

        myConnection.Close()
    End Sub
    Private Sub DueSoon()
        Dim dbCon As DbConnection = New DbConnection()
        myConnection.ConnectionString = dbCon.dbConnector()
        myConnection.Open()

        Dim dateString As String = Now.Month & "/" & Now.Day & "/" & Now.Year
        Dim DateNow As Date = Date.Parse(dateString)
        Dim cmd As OleDbCommand = New OleDbCommand("SELECT DISTINCT grn AS [GRN], supplied_by AS [SUPPLIER], payment_due AS [PAYMENT DUE] FROM purchases WHERE payment_due > ? AND payment_status= ? AND status = ?", myConnection)
        cmd.Parameters.Add(New OleDbParameter("payment_due", CType(DateNow, String)))
        cmd.Parameters.Add(New OleDbParameter("payment_status", CType("Not Paid", String)))
        cmd.Parameters.Add(New OleDbParameter("status", CType("ACTIVE", String)))

        Dim reader As OleDbDataReader
        reader = cmd.ExecuteReader()
        Dim RowCount As Integer = 0
        Dim reminderdays As Integer = GetNumberOfDays()

        dgvDueSoon.ColumnCount = 3
        dgvDueSoon.Columns(0).Name = "GRN"
        dgvDueSoon.Columns(1).Name = "SUPPLIER"
        dgvDueSoon.Columns(2).Name = "PAYMENT DUE"

        While reader.Read()
            Dim PaymentDate As DateTime = Convert.ToDateTime(reader.Item("PAYMENT DUE"))
            Dim ts As TimeSpan = PaymentDate.Subtract(DateNow)
            If Convert.ToInt32(ts.Days) <= reminderdays Then 'Calling a function to get the days for the reminder

                Dim row As String() = New String() {reader.Item("GRN"), reader.Item("SUPPLIER"), reader.Item("PAYMENT DUE")}
                dgvDueSoon.Rows.Add(row)

                RowCount = RowCount + 1

            End If
        End While
        dgvDueSoon.AllowUserToAddRows = False

        lblDueSoon.Text = "Due Soon - " & RowCount & " GRNs"

        reader.Close()

        myConnection.Close()
    End Sub
    Private Function GetNumberOfDays() As Integer
        Dim connection As OleDbConnection = New OleDbConnection
        Dim dbCon As DbConnection = New DbConnection()
        connection.ConnectionString = dbCon.dbConnector()
        connection.Open()

        Dim cmd As OleDbCommand = New OleDbCommand("SELECT [value] FROM settings WHERE [name] = ? ", connection)
        cmd.Parameters.Add(New OleDbParameter("name", CType("supplier_payment_reminder_days", String)))

        Return cmd.ExecuteScalar()
    End Function
    
End Class