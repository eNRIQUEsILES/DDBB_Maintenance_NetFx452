'DDBBfunctions.vb
'Maintenance Expert Team APW
' (c) Kostal Eléctrica S.A.  2016

#Region "IMPORTS__________________________________________________________________________"
'Imports
Imports System.Data.OleDb
Imports DAO
Imports DAO.EditModeEnum
#End Region

Module DDBBfunctions

#Region "PUBLIC MEMBERS_______________________________________________________________"
    'Dim fecha As String = Format(Today, "dd-MM-yyyy")
    Dim _DBEngine As New DAO.DBEngine
    Dim _programWS As Workspace
    Dim _programDB As Database
#End Region

#Region "PUBLIC METHODS___________________________________________________________________"
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
                My.Computer.FileSystem.RenameFile(Form1.BackupPath + Form1.datasource_name, Form1._name + "_" + Form1.FechaHoy + ".mdb")
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
            Clean = "DELETE * FROM Results WHERE Instant <#" & Form1.FechaHoy & "#"
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
        Dim JRO As JRO.JetEngine
        JRO = New JRO.JetEngine
        Dim SourcePath As String
        Dim DestinyPath As String
        SourcePath = Form1.PathDDBB + Form1.datasource_name
        DestinyPath = Form1.BackupPath + Form1.datasource_name
        Dim DDBB_source As String, DDBB_destiny As String
        'My.Application.DoEvents()
        DDBB_source = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & SourcePath & ";Jet OLEDB:Engine Type=5"
        DDBB_destiny = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DestinyPath & " ;Jet OLEDB:Engine Type=5"
        JRO.CompactDatabase(DDBB_source, DDBB_destiny)
        Form1._Compact = True
        My.Computer.FileSystem.DeleteFile(Form1.PathDDBB + Form1.datasource_name)
        My.Computer.FileSystem.MoveFile(Form1.BackupPath + Form1.datasource_name, Form1.PathDDBB + Form1.datasource_name)
    End Sub

    Public Sub DDBBCompact2()
        Form1.emptyfail = False
        Form1.Show()
        Dim dao As DAO.DBEngine
        dao = New DAO.DBEngine
        Dim SourcePath As String
        Dim DestinyPath As String
        SourcePath = Form1.PathDDBB + Form1.datasource_name
        DestinyPath = Form1.BackupPath + Form1.datasource_name
        Dim DDBB_source As String, DDBB_destiny As String
        DDBB_source = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & SourcePath & ";Jet OLEDB:Engine Type=5"
        DDBB_destiny = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & DestinyPath & " ;Jet OLEDB:Engine Type=5"
        dao.CompactDatabase(DDBB_source, DDBB_destiny, "dbLangGeneral ;pwd=kaos, dbVersion30, pwd=kaos")
        Form1._Compact = True
        My.Computer.FileSystem.DeleteFile(Form1.PathDDBB + Form1.datasource_name)
        My.Computer.FileSystem.MoveFile(Form1.BackupPath + Form1.datasource_name, Form1.PathDDBB + Form1.datasource_name)
    End Sub

    Public Function OpenProgramDB() As Boolean

        Try
            _DBEngine.SystemDB = Form1.PathDDBB + Form1.WorkGroup
            _programWS = _DBEngine.CreateWorkspace("program WS", Form1.User_ID, Form1.PassWord, WorkspaceTypeEnum.dbUseJet)
            _programDB = _programWS.OpenDatabase(Form1.PathDDBB + Form1.datasource_name, False, False, "")
            With _DBEngine
                .SetOption(SetOptionEnum.dbLockRetry, 1)    ' only one lock retry
                .SetOption(SetOptionEnum.dbMaxBufferSize, 4096)   ' RAM buffer size = 4 MByte
                .SetOption(SetOptionEnum.dbLockDelay, 100)
                .SetOption(SetOptionEnum.dbFlushTransactionTimeout, 10)
            End With
            Return True
        Catch
            'Tools.WarningBox(0, String.Format("'{0}' method failed, object '{1}'" & CrLf & CrLf & "{2}", GetCurrentMethod.Name, Err.Source, Err.Description))
            Return False
        End Try
    End Function

    Public Sub ClosePrgDB()
        On Error Resume Next
        _programDB.Close()
        _programWS.Close()
    End Sub


    Public Sub Task_Kill()
        Try
            Dim APPTest() As Process = Process.GetProcessesByName("MQB.exe")
            For Each Process As Process In APPTest
                Process.Kill()
            Next
            'For Each Process_p In System.Diagnostics.Process.GetProcessesByName("MQB.exe")
            'Process_p.Kill()
            'Next
        Catch ex As Exception

        End Try
    End Sub
#End Region

End Module
