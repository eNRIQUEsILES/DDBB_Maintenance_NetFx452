<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Lbl_datasource = New System.Windows.Forms.Label()
        Me.TextBox_datasource = New System.Windows.Forms.TextBox()
        Me.LblProgress_DB = New System.Windows.Forms.Label()
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar()
        Me.CheckedListBox = New System.Windows.Forms.CheckedListBox()
        Me.Anagrama2 = New System.Windows.Forms.PictureBox()
        Me.LogoKOSTAL2 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Anagrama2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoKOSTAL2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_datasource
        '
        Me.Lbl_datasource.AutoSize = True
        Me.Lbl_datasource.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl_datasource.Location = New System.Drawing.Point(12, 133)
        Me.Lbl_datasource.Name = "Lbl_datasource"
        Me.Lbl_datasource.Size = New System.Drawing.Size(149, 24)
        Me.Lbl_datasource.TabIndex = 13
        Me.Lbl_datasource.Text = "Lbl_datasource"
        '
        'TextBox_datasource
        '
        Me.TextBox_datasource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox_datasource.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox_datasource.Enabled = False
        Me.TextBox_datasource.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox_datasource.ForeColor = System.Drawing.Color.DodgerBlue
        Me.TextBox_datasource.Location = New System.Drawing.Point(81, 133)
        Me.TextBox_datasource.Name = "TextBox_datasource"
        Me.TextBox_datasource.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBox_datasource.Size = New System.Drawing.Size(320, 32)
        Me.TextBox_datasource.TabIndex = 14
        Me.TextBox_datasource.Text = "datasource_name"
        Me.TextBox_datasource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblProgress_DB
        '
        Me.LblProgress_DB.AutoSize = True
        Me.LblProgress_DB.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblProgress_DB.Location = New System.Drawing.Point(16, 202)
        Me.LblProgress_DB.Name = "LblProgress_DB"
        Me.LblProgress_DB.Size = New System.Drawing.Size(279, 24)
        Me.LblProgress_DB.TabIndex = 15
        Me.LblProgress_DB.Text = "LblProgress_DB                        "
        '
        'ProgressBar2
        '
        Me.ProgressBar2.Location = New System.Drawing.Point(12, 239)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(389, 23)
        Me.ProgressBar2.Step = 30
        Me.ProgressBar2.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar2.TabIndex = 16
        '
        'CheckedListBox
        '
        Me.CheckedListBox.BackColor = System.Drawing.Color.SkyBlue
        Me.CheckedListBox.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckedListBox.ForeColor = System.Drawing.Color.White
        Me.CheckedListBox.FormattingEnabled = True
        Me.CheckedListBox.Items.AddRange(New Object() {"Conectado a DB", "Backup DB Realizado", "Vaciado DB Realizado", "Desconectado de DB", "Operación Finalizada"})
        Me.CheckedListBox.Location = New System.Drawing.Point(12, 281)
        Me.CheckedListBox.Name = "CheckedListBox"
        Me.CheckedListBox.Size = New System.Drawing.Size(263, 139)
        Me.CheckedListBox.TabIndex = 17
        '
        'Anagrama2
        '
        Me.Anagrama2.Image = CType(resources.GetObject("Anagrama2.Image"), System.Drawing.Image)
        Me.Anagrama2.Location = New System.Drawing.Point(281, 281)
        Me.Anagrama2.Name = "Anagrama2"
        Me.Anagrama2.Size = New System.Drawing.Size(120, 139)
        Me.Anagrama2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Anagrama2.TabIndex = 18
        Me.Anagrama2.TabStop = False
        '
        'LogoKOSTAL2
        '
        Me.LogoKOSTAL2.Image = CType(resources.GetObject("LogoKOSTAL2.Image"), System.Drawing.Image)
        Me.LogoKOSTAL2.Location = New System.Drawing.Point(64, 12)
        Me.LogoKOSTAL2.Name = "LogoKOSTAL2"
        Me.LogoKOSTAL2.Size = New System.Drawing.Size(279, 72)
        Me.LogoKOSTAL2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LogoKOSTAL2.TabIndex = 12
        Me.LogoKOSTAL2.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 2000
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SkyBlue
        Me.ClientSize = New System.Drawing.Size(417, 432)
        Me.Controls.Add(Me.Anagrama2)
        Me.Controls.Add(Me.CheckedListBox)
        Me.Controls.Add(Me.ProgressBar2)
        Me.Controls.Add(Me.LblProgress_DB)
        Me.Controls.Add(Me.TextBox_datasource)
        Me.Controls.Add(Me.Lbl_datasource)
        Me.Controls.Add(Me.LogoKOSTAL2)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mantenimiento DDBB"
        Me.TransparencyKey = System.Drawing.Color.Gray
        CType(Me.Anagrama2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoKOSTAL2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LogoKOSTAL2 As PictureBox
    Friend WithEvents Lbl_datasource As Label
    Friend WithEvents TextBox_datasource As TextBox
    Friend WithEvents LblProgress_DB As Label
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents CheckedListBox As CheckedListBox
    Friend WithEvents Anagrama2 As PictureBox
    Friend WithEvents Timer1 As Timer
End Class
