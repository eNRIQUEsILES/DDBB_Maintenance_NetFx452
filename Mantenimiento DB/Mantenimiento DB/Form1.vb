'Form1.vb
'Maintenance Expert Team APW
' (c) Kostal Eléctrica S.A.  2016

'Imports
Imports System.Threading
Imports System.Windows.Forms
Imports System.Data.OleDb

Public Class Form1

    'Initializing System Var
    Public IniFile As New Ini(AppDomain.CurrentDomain.BaseDirectory + "Data.ini")
    Public PathDDBB As String = IniFile.GetString("DDBB", "Path", "")
    Public BackupPath As String = IniFile.GetString("DDBB", "BackupPath", "")
    Public datasource As String = IniFile.GetString("DDBB", "Type", "")
    Public datasource_name As String = IniFile.GetString("DDBB", "File", "")
    Public WorkGroup As String = IniFile.GetString("DDBB", "Workgroup", "")
    Public User_ID As String = IniFile.GetString("DDBB", "UserID", "")
    Public PassWord As String = IniFile.GetString("DDBB", "Password", "")
    Public _name As String = IniFile.GetString("DDBB", "Name", "")
    Public paso1 As String = IniFile.GetString("PROGRESS", "Paso1", "")
    Public paso2 As String = IniFile.GetString("PROGRESS", "Paso2", "")
    Public paso3 As String = IniFile.GetString("PROGRESS", "Paso3", "")
    Public paso4 As String = IniFile.GetString("PROGRESS", "Paso4", "")
    Public paso5 As String = IniFile.GetString("PROGRESS", "Paso5", "")
    Public paso6 As String = IniFile.GetString("PROGRESS", "Paso6", "")
    Public paso7 As String = IniFile.GetString("PROGRESS", "Paso7", "")
    Public error1 As String = IniFile.GetString("ERROR", "Error1", "")
    Public error2 As String = IniFile.GetString("ERROR", "Error2", "")
    Public error3 As String = IniFile.GetString("ERROR", "Error3", "")
    Public error4 As String = IniFile.GetString("ERROR", "Error4", "")
    Public error5 As String = IniFile.GetString("ERROR", "Error5", "")
    Public error6 As String = IniFile.GetString("ERROR", "Error6", "")
    Public backup_fail As Boolean
    Public emptyfail As Boolean
    Public conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & PathDDBB + datasource_name & ";Jet OLEDB:System Database=" & PathDDBB + WorkGroup & ";User ID=" & User_ID & ";Password=" & PassWord & ";")
    Public _step As String
    Public _Compact As Boolean


    Private Sub TestDoEvents()
        Dim n As Byte
        Dim valorn As Boolean
        For i As Integer = 0 To 8
            'CONEXIÓN DDBB
            If i = 1 Then
                ProgressBar2.PerformStep()
                _step = paso1
                DDBBconnect()
            End If
            'BACKUP DDBB
            If i = 2 And conn.State = ConnectionState.Open And Not My.Computer.FileSystem.FileExists(BackupPath + datasource_name + fecha + ".mdb") Then
                n = 0
                valorn = True
                ProgressBar2.PerformStep()
                _step = paso2
                DDBBbackup()
            ElseIf i = 2 And conn.State = ConnectionState.Open And My.Computer.FileSystem.FileExists(BackupPath + datasource_name + fecha + ".mdb") Then
                n = 0
                valorn = True
                _step = error5
                MessageBox.Show("Backup ya existe!!, Avisar a equipo Expert""APW")
                closeAPP()
            ElseIf i = 2 And conn.State = ConnectionState.Closed Then
                n = 0
                valorn = False
                _step = error1
                MessageBox.Show("Imposible conectar con DDBB!!, Avisar a equipo Expert!!", "APW1")
                closeAPP()
            End If
            'VACIADO DDBB
            If i = 3 And backup_fail = False Then
                n = 1
                valorn = True
                ProgressBar2.PerformStep()
                _step = paso3
                DDBBempty()
            ElseIf i = 3 And backup_fail = True Then
                n = 1
                valorn = False
                _step = error2
                MessageBox.Show("Imposible realizar Backup!! Avisar a equipo Expert", "APW1")
                closeAPP()
            End If
            'COMPACTAR DDBB
            If i = 4 And emptyfail = False Then
                n = 2
                valorn = True
                ProgressBar2.PerformStep()
                _step = paso4
                DDBBCompact()
            ElseIf i = 4 And emptyfail = True Then
                _step = error3
                n = 2
                valorn = False
                MessageBox.Show("Imposible vaciar DDBB!! Avisar a equipo Expert", "APW1")
                closeAPP()
            End If
            'DESCONECTAR
            If i = 5 And _step = paso4 And _Compact = True Then
                n = 3
                valorn = True
                ProgressBar2.PerformStep()
                _step = paso5
            ElseIf i = 5 And _Compact = False Then
                _step = error4
                n = 3
                valorn = False
                MessageBox.Show("Imposible compactar!! Avisar a equipo Expert", "APW1")
                closeAPP()
            End If
            'OPERACIÓN FINALIZADA
            If i = 6 And _step = paso5 And conn.State = ConnectionState.Closed Then
                n = 4
                valorn = True
                ProgressBar2.PerformStep()
                _step = paso6
            ElseIf i = 6 And conn.State = ConnectionState.Open Then
                _step = error5
                n = 4
                valorn = False
                MessageBox.Show("Imposible desconectar!! Avisar a equipo Expert", "APW1")
                closeAPP()
            End If
            'CERRAR APLICACIÓN
            If i = 7 Then
                ProgressBar2.PerformStep()
                _step = paso7
                n = 5
                valorn = True
            End If
            If i = 8 Then
                _step = paso7
                Thread.Sleep(2000)
                closeAPP()
            End If
            LblProgress_DB.Text = _step
            CheckedListBox.SetItemChecked(n, valorn)
            My.Application.DoEvents()
            Me.Show()
            Thread.Sleep(3000)
        Next
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Show()
        TextBox_datasource.Text = PathDDBB + datasource_name
        Lbl_datasource.Text = datasource
        TestDoEvents()
    End Sub


End Class
