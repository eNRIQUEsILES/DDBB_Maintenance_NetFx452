'DDBBfunctions.vb
'Maintenance Expert Team APW
' (c) Kostal Eléctrica S.A.  2016

'Imports
Imports System.Data.OleDb

Module DDBBfunctions

    Public fecha As String = Format(Today, "dd-MM-yyyy")

    Public Sub DDBBconnect()
        Form1.Show()
        Try
            Form1.conn.Open()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub DDBBdisconnect()
        Form1.Show()
        If Form1.conn.State = ConnectionState.Open Then
            Try
                Form1.conn.Close()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Public Sub DDBBbackup()
        Form1.Show()
        'Dim fecha As String = Format(Today, "dd-MM-yyyy")
        If Form1.conn.State = ConnectionState.Open Then
            Try
                My.Computer.FileSystem.CopyFile(Form1.PathDDBB + Form1.datasource_name, Form1.BackupPath + Form1.datasource_name)
                My.Computer.FileSystem.RenameFile(Form1.BackupPath + Form1.datasource_name, Form1._name + "_" + fecha + ".mdb")
            Catch ex As Exception
                Form1.backup_fail = True
            End Try
        Else

        End If
    End Sub

    Public Sub DDBBempty()
        Form1.Show()
        If Form1.conn.State = ConnectionState.Open Then
            Dim cmd As New OleDb.OleDbCommand()
            Dim Clean As String
            cmd.Connection = Form1.conn
            cmd.CommandType = CommandType.Text
            Clean = "DELETE * FROM Results"
            cmd.CommandText = Clean
            Try
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Form1.emptyfail = True
            End Try
        Else

            Return
        End If
    End Sub

    Public Sub closeAPP()
        Form1.Show()
        'If Form1.conn.State = ConnectionState.Closed Then
        End
        'End If
    End Sub

End Module
