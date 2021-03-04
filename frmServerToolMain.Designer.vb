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
        Me.cmnuServerTool = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuServerTool = New System.Windows.Forms.MenuStrip()
        Me.stbServerTool = New System.Windows.Forms.StatusStrip()
        Me.ToolStripProgressBar1 = New System.Windows.Forms.ToolStripProgressBar()
        Me.ofdServerTool = New System.Windows.Forms.OpenFileDialog()
        Me.nicServerTool = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.cmnuServerToolTray = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.tmrServerTool = New System.Windows.Forms.Timer(Me.components)
        Me.fodServerTool = New System.Windows.Forms.FontDialog()
        Me.cdigServerTool = New System.Windows.Forms.ColorDialog()
        Me.svcServerTool = New System.ServiceProcess.ServiceController()
        Me.ttpServerTool = New System.Windows.Forms.ToolTip(Me.components)
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripDropDownButton1 = New System.Windows.Forms.ToolStripDropDownButton()
        Me.stbServerTool.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmnuServerTool
        '
        Me.cmnuServerTool.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.cmnuServerTool.Name = "ContextMenuStrip1"
        Me.cmnuServerTool.Size = New System.Drawing.Size(61, 4)
        '
        'mnuServerTool
        '
        Me.mnuServerTool.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(48, Byte), Integer))
        Me.mnuServerTool.GripMargin = New System.Windows.Forms.Padding(2, 2, 0, 2)
        Me.mnuServerTool.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.mnuServerTool.Location = New System.Drawing.Point(0, 0)
        Me.mnuServerTool.Name = "mnuServerTool"
        Me.mnuServerTool.Size = New System.Drawing.Size(1077, 24)
        Me.mnuServerTool.TabIndex = 1
        Me.mnuServerTool.Text = "MenuStrip1"
        '
        'stbServerTool
        '
        Me.stbServerTool.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.stbServerTool.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.stbServerTool.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripProgressBar1, Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2, Me.ToolStripStatusLabel3, Me.ToolStripDropDownButton1})
        Me.stbServerTool.Location = New System.Drawing.Point(0, 719)
        Me.stbServerTool.Name = "stbServerTool"
        Me.stbServerTool.Padding = New System.Windows.Forms.Padding(2, 0, 14, 0)
        Me.stbServerTool.Size = New System.Drawing.Size(1077, 32)
        Me.stbServerTool.SizingGrip = False
        Me.stbServerTool.TabIndex = 2
        Me.stbServerTool.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New System.Drawing.Size(100, 24)
        '
        'ofdServerTool
        '
        Me.ofdServerTool.FileName = "OpenFileDialog1"
        '
        'nicServerTool
        '
        Me.nicServerTool.ContextMenuStrip = Me.cmnuServerToolTray
        Me.nicServerTool.Text = "NotifyIcon1"
        Me.nicServerTool.Visible = True
        '
        'cmnuServerToolTray
        '
        Me.cmnuServerToolTray.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.cmnuServerToolTray.Name = "cmnuToolTray"
        Me.cmnuServerToolTray.Size = New System.Drawing.Size(61, 4)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(180, 25)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(180, 25)
        Me.ToolStripStatusLabel2.Text = "ToolStripStatusLabel2"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(180, 25)
        Me.ToolStripStatusLabel3.Text = "ToolStripStatusLabel3"
        '
        'ToolStripDropDownButton1
        '
        Me.ToolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripDropDownButton1.Image = Global.xKiller_Clan_Server_Tool.My.Resources.Resources.xKiller_Clan___Logo_V3
        Me.ToolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripDropDownButton1.Name = "ToolStripDropDownButton1"
        Me.ToolStripDropDownButton1.Size = New System.Drawing.Size(42, 29)
        Me.ToolStripDropDownButton1.Text = "ToolStripDropDownButton1"
        '
        'frmServerToolMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1077, 751)
        Me.Controls.Add(Me.stbServerTool)
        Me.Controls.Add(Me.mnuServerTool)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.mnuServerTool
        Me.MaximizeBox = False
        Me.Name = "frmServerToolMain"
        Me.Text = "xKiller Clan Server Tool"
        Me.stbServerTool.ResumeLayout(False)
        Me.stbServerTool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmnuServerTool As ContextMenuStrip
    Friend WithEvents mnuServerTool As MenuStrip
    Friend WithEvents stbServerTool As StatusStrip
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents ofdServerTool As OpenFileDialog
    Friend WithEvents nicServerTool As NotifyIcon
    Friend WithEvents cmnuServerToolTray As ContextMenuStrip
    Friend WithEvents tmrServerTool As Timer
    Friend WithEvents fodServerTool As FontDialog
    Friend WithEvents cdigServerTool As ColorDialog
    Friend WithEvents svcServerTool As ServiceProcess.ServiceController
    Friend WithEvents ttpServerTool As ToolTip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel2 As ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As ToolStripStatusLabel
    Friend WithEvents ToolStripDropDownButton1 As ToolStripDropDownButton
End Class
