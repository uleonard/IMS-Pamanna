Public Class DbConnection
    Public Function dbConnector() As String
        Dim provider As String
        Dim dataFile As String
        Dim connString As String

        'provider = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source ="
        'dataFile = Application.StartupPath & "\\ims.accdb"
        provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source ="

        If GetPath() = "0" Then
            dataFile = Application.StartupPath & "\\ims.mdb"
            'dataFile = "\\10.10.48.90\db\ims.mdb"
        Else
            dataFile = GetPath() & "\\ims.mdb"
            '    'dataFile = "\\10.10.48.90\db\ims.mdb"
        End If
        connString = provider & dataFile
        connString = provider & dataFile
        Return connString
    End Function
    Private Function GetPath() As String

        Dim objReader As New System.IO.StreamReader(Application.StartupPath & "\\database_path.txt")

        Dim DbPath As String = objReader.ReadLine()
        objReader.Close()
        Return DbPath
    End Function
End Class
