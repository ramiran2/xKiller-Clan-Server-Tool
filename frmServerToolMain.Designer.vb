<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmServerToolMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmServerToolMain))
        Me.cmnuTool = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuTool = New System.Windows.Forms.MenuStrip()
        Me.stbTool = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ofdTool = New System.Windows.Forms.OpenFileDialog()
        Me.nicTool = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmnuToolTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tmrTool = New System.Windows.Forms.Timer(Me.components)
        Me.fodTool = New System.Windows.Forms.FontDialog()
        Me.cdigTool = New System.Windows.Forms.ColorDialog()
        Me.svcTool = New System.ServiceProcess.ServiceController()
        Me.stbTool.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmnuTool
        '
        Me.cmnuTool.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.cmnuTool.Name = "ContextMenuStrip1"
        Me.cmnuTool.Size = New System.Drawing.Size(61, 4)
        '
        'mnuTool
        '
        Me.mnuTool.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.mnuTool.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.mnuTool.Location = New System.Drawing.Point(0, 0)
        Me.mnuTool.Name = "mnuTool"
        Me.mnuTool.Padding = New System.Windows.Forms.Padding(4, 1, 0, 1)
        Me.mnuTool.Size = New System.Drawing.Size(718, 24)
        Me.mnuTool.TabIndex = 1
        Me.mnuTool.Text = "MenuStrip1"
        '
        'stbTool
        '
        Me.stbTool.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.stbTool.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.stbTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1})
        Me.stbTool.Location = New System.Drawing.Point(0, 466)
        Me.stbTool.Name = "stbTool"
        Me.stbTool.Padding = New System.Windows.Forms.Padding(1, 0, 9, 0)
        Me.stbTool.Size = New System.Drawing.Size(718, 22)
        Me.stbTool.TabIndex = 2
        Me.stbTool.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(67, 16)
        '
        'ofdTool
        '
        Me.ofdTool.FileName = "OpenFileDialog1"
        '
        'nicTool
        '
        Me.nicTool.Text = "NotifyIcon1"
        Me.nicTool.Visible = True
        '
        'cmnuToolTray
        '
        Me.cmnuToolTray.Name = "cmnuToolTray"
        Me.cmnuToolTray.Size = New System.Drawing.Size(61, 4)
        '
        'frmServerToolMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(718, 488)
        Me.Controls.Add(Me.stbTool)
        Me.Controls.Add(Me.mnuTool)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuTool
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "frmServerToolMain"
        Me.Text = "xKiller Clan Server Tool"
        Me.stbTool.ResumeLayout(False)
        Me.stbTool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmnuTool As ContextMenuStrip
    Friend WithEvents mnuTool As MenuStrip
    Friend WithEvents stbTool As StatusStrip
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents ofdTool As OpenFileDialog
    Friend WithEvents nicTool As NotifyIcon
    Friend WithEvents cmnuToolTray As ContextMenuStrip
    Friend WithEvents tmrTool As Timer
    Friend WithEvents fodTool As FontDialog
    Friend WithEvents cdigTool As ColorDialog
    Friend WithEvents svcTool As ServiceProcess.ServiceController
End Class
