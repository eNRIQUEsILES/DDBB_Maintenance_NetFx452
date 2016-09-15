﻿'DDBBfunctions.vb
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
            Form1.conn.Close()
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

    Public Sub DDBBCompact()
        Form1.Show()
        Dim SourcePath As String
        Dim DestinyPath As String
        SourcePath = Form1.PathDDBB + Form1.datasource_name
        DestinyPath = Form1.BackupPath + Form1.datasource_name
        Dim JRO As New JRO.JetEngine
        Dim DDBB_source As String, DDBB_destiny As String
        My.Application.DoEvents()
        DDBB_source = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & SourcePath
        DDBB_destiny = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DestinyPath & " ;Jet OLEDB:Engine Type=5"
        JRO.CompactDatabase(DDBB_source, DDBB_destiny)
        Form1._Compact = True
        My.Computer.FileSystem.DeleteFile(Form1.PathDDBB + Form1.datasource_name)
        My.Computer.FileSystem.MoveFile(Form1.BackupPath + Form1.datasource_name, Form1.PathDDBB + Form1.datasource_name)
    End Sub

End Module
