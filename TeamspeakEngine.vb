Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.ServiceProcess
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices
Module TeamspeakEngine
    Public strExternalIP, strFile, strSettingsStartInTray, strStartInTray, strServiceName, strChecked, strTimeCheck, strServiceCheck, strProcessName, strFileSettings, strCheckedDomain, strDomain0, strDomain1, strDomain2, strDomain3, strDomain4, strDomain5, strDomain6, strDomain7, strDomain8, strDomain9, strDomain10, strDomain11, strDomain12, strDomain13, strDomain14, strDomain15, strDomain16, strDomain17, strDomain18, strDomain19, strDisplay0, strDisplay1, strDisplay2, strDisplay3, strDisplay4, strDisplay5, strDisplay6, strDisplay7, strDisplay8, strDisplay9, strDisplay10, strDisplay11, strDisplay12, strDisplay13, strDisplay14, strDisplay15, strDisplay16, strDisplay17, strDisplay18, strDisplay19, strReload, strUsername, strPassword, strSettingsUsername, strSettingsPassword, strSettingsTime, strSettingsFileLocation, strSettingsChecked, strSettingsAccess, strSettingsService, strSettingsProcess, strRawData, strDiagnostics0, strDiagnostics1, strDiagnostics2, strDiagnostics3, strDiagnostics4, strDiagnostics5, strDiagnostics6, strDiagnostics7, strDiagnostics8, strDiagnostics9, strDiagnostics10, strDiagnostics11, strDiagnostics12, strDiagnostics13, strDiagnostics14, strDiagnostics15, strDiagnostics20 As String
    Public intDomain, intOnlineTest0, intOnlineTest1, intOnlineSpammerTest, intRestartErrorCheck, intTimerFixService, intDiagnosticsClick, intStartTray, intAccount, intVisable, intTime, intDownX, intDownY, intUserTime, intCheckSP, intFixTime, intVideo, intGoogle, intRestart, intStop, intStart, intSettings, intControl, intError, intMessageError, intErrorCountStartUp, intExternalError, intStartUp, intErrorMessage, intErrorCount1, intErrorCount2, intErrorCount3, intErrorCount4, intErrorCount5, intErrorCount6, intErrorCount7, intErrorCount8, intErrorCount9, intErrorCount10, intErrorCount11, intErrorCount12, intErrorCount13, intErrorCount14, intErrorCount15, intErrorCount16, intErrorCount17, intErrorCount18, intErrorCount19, intErrorCount20, intErrorCount21, intErrorCount22, intErrorCount23, intErrorCount24, intErrorCount25, intErrorCount26, intErrorCount27, intErrorCount28, intErrorCount29, intErrorCount30, intErrorCount31, intErrorCount32, intErrorCount33, intErrorCount34, intErrorCount35, intErrorCount36, intErrorCount37, intErrorCount38, intErrorCount39, intErrorCount40, intErrorCount41, intErrorCount42, intErrorCount43, intErrorCount44, intErrorCount45, intErrorCount46, intErrorCount47, intErrorCount48, intErrorCount49 As Integer
    Public strDnsRawData As String()
    Public strSettingsRawData As String()
    Public procExecuting As Process
    Public procRunAdmin As ProcessStartInfo
    Public blnDragged As Boolean
    Public blnErrorMessage As Boolean
    Public strVersion, strDiagnostics16, strDiagnostics17, strDiagnostics18, strDiagnostics19, strDiagnostics21, strMnuIpDisplay As String

    Public Sub StartupSettings()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If File.Exists(strFileSettings) Then
            strSettingsRawData = File.ReadAllLines(strFileSettings)
            intSettings = strSettingsRawData.Length
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub UpdateMessage()
        If (intOnlineSpammerTest <= 10) = True Then
            If (intOnlineTest0 >= 1) = True Then
                If (intOnlineTest1 >= 1) = True Then
                    Try
                        strRawData = New WebClient().DownloadString("http://engine.xkillerclan.com/updates/XKillerTSAToolUpdater.xml")
                        strRawData = New Regex("\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}").Matches(strRawData)(0).ToString()
                    Catch exUpdate As Exception
                        Dim exErrorData As Exception = exUpdate
                        My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Warning
                        My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Cant Connect Online"
                        My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "Can't connect online to check for updates."
                        My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                        strDiagnostics0 = exErrorData.Message
                        DiagnosticsLoad()
                    End Try
                    If Operators.CompareString(strRawData, String.Empty, False) = 0 Then
                        My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
                        My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Unable to check for updates"
                        My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "There was an error connecting to your server."
                        My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                    Else
                        If strRawData.Contains(strVersion) = True Then
                            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
                            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Up to date"
                            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "Wow you have the latest version of Teamspeak Assistant Tool :-)."
                            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                        Else
                            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
                            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Update Found"
                            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "Wow there is an update for Teamspeak Assistant Tool and we recommend you to download it as it may contain new features or bug fixes."
                            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                        End If
                    End If
                Else

                End If
            Else

            End If
        Else

        End If
    End Sub

    Public Sub StartTray()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If File.Exists(strFileSettings) Then
            strSettingsRawData = File.ReadAllLines(strFileSettings)
            intSettings = strSettingsRawData.Length
            If intSettings = 9 Then
                Try
                    strSettingsStartInTray = strSettingsRawData(8)
                    If Operators.CompareString(strSettingsStartInTray, "Start=NULL", False) = 0 Then
                        intStartTray = 0
                    Else
                        strStartInTray = strSettingsStartInTray.Substring(strSettingsStartInTray.IndexOf("="c) + 1)
                        Integer.TryParse(strStartInTray, intStartTray)
                    End If
                Catch exStart As Exception
                    Dim exErrorData As Exception = exStart
                    intErrorMessage = 46
                    ErrorMessage()
                    intErrorMessage = 0
                    intStartTray = 0
                    strDiagnostics1 = exErrorData.Message
                    DiagnosticsLoad()
                End Try
            Else
                intErrorMessage = 2
                ErrorMessage()
                intErrorMessage = 0
            End If
        End If
        If intStartTray = 1 Then
            My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(211, 84, 0)
            My.Forms.frmServerToolMain.mnuStartInTray.Enabled = False
            My.Forms.frmServerToolMain.WindowState = FormWindowState.Minimized
            My.Forms.frmServerToolMain.ShowInTaskbar = False
        End If
        If intStartTray > 1 Then
            intErrorMessage = 47
            ErrorMessage()
            intErrorMessage = 0
            intStartTray = 0
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub MessageInfo()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(22, 160, 133)
        If intMessageError = 1 Then
            intErrorMessage = 14
            ErrorMessage()
            intErrorMessage = 0
        End If
        If intMessageError = 2 Then
            intErrorMessage = 31
            ErrorMessage()
            intErrorMessage = 0
        End If
        If intMessageError = 3 Then
            intErrorMessage = 34
            ErrorMessage()
            intErrorMessage = 0
        End If
        If intMessageError = 4 Then
            intErrorMessage = 35
            ErrorMessage()
            intErrorMessage = 0
        End If
        If intMessageError = 5 Then
            intErrorMessage = 36
            ErrorMessage()
            intErrorMessage = 0
        End If
        If intMessageError = 6 Then
            intErrorMessage = 37
            ErrorMessage()
            intErrorMessage = 0
        End If
        If intMessageError = 7 Then
            intErrorMessage = 38
            ErrorMessage()
            intErrorMessage = 0
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub CleanStartUp()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If RuntimeHelpers.GetObjectValue(My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).GetValue(Application.ProductName)) Is Nothing Then
            My.Forms.frmServerToolMain.mnuDisableStartUp.Enabled = False
        Else
            My.Forms.frmServerToolMain.mnuEnableStartUp.Enabled = False
        End If
        If My.User.IsInRole(BuiltInRole.Administrator) Then
            My.Forms.frmServerToolMain.mnuAdmin.Enabled = False
            My.Forms.frmServerToolMain.cmnuAdmin.Enabled = False
            My.Forms.frmServerToolMain.cmnuAdminTray.Enabled = False
        End If
        If intAccount = 0 Then
            My.Forms.frmServerToolMain.mnuTimerAdjustments.Enabled = False
            My.Forms.frmServerToolMain.mnuDiagnosticViewer.Enabled = False
            My.Forms.frmTeamspeakDiagnostic.chkActive.Enabled = False
            My.Forms.frmTeamspeakSettingEditor.btnOpenDiagnostics.Enabled = False
        End If
        If intAccount > 0 Then
            My.Forms.frmServerToolMain.mnuTimerAdjustments.Enabled = True
            My.Forms.frmServerToolMain.mnuDiagnosticViewer.Enabled = True
            My.Forms.frmTeamspeakDiagnostic.chkActive.Enabled = True
            My.Forms.frmTeamspeakSettingEditor.btnOpenDiagnostics.Enabled = True
        End If
        If intControl = 0 Then
            My.Forms.frmServerToolMain.mnuServiceRestart.Enabled = False
            My.Forms.frmServerToolMain.mnuServiceStart.Enabled = False
            My.Forms.frmServerToolMain.mnuServiceStop.Enabled = False
        End If
        If intControl = 1 Then
            My.Forms.frmServerToolMain.mnuServiceRestart.Enabled = True
            My.Forms.frmServerToolMain.mnuServiceStart.Enabled = True
            My.Forms.frmServerToolMain.mnuServiceStop.Enabled = True
        End If
        If intControl = 2 Then
            My.Forms.frmServerToolMain.mnuServiceRestart.Enabled = False
            My.Forms.frmServerToolMain.mnuServiceStart.Enabled = True
            My.Forms.frmServerToolMain.mnuServiceStop.Enabled = True
        End If
        My.Forms.frmServerToolMain.lblEasterEgg2.Text = ""
        My.Forms.frmServerToolMain.lblEasterEgg3.Text = ""
        intUserTime = 5
        intErrorCountStartUp = 2
        strVersion = "4.5.28.4"
        My.Forms.frmServerToolMain.mnuVersion.Text = "V." + strVersion
        My.Forms.frmServerToolMain.nicServerTool.Text = "Dynamic DNS for Teamspeak DNS"
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub ButtonCheck()
        If RuntimeHelpers.GetObjectValue(My.Computer.Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).GetValue(Application.ProductName)) Is Nothing Then
            My.Forms.frmServerToolMain.mnuDisableStartUp.Enabled = False
        Else
            My.Forms.frmServerToolMain.mnuEnableStartUp.Enabled = False
        End If
        If My.User.IsInRole(BuiltInRole.Administrator) Then
            My.Forms.frmServerToolMain.mnuAdmin.Enabled = False
            My.Forms.frmServerToolMain.cmnuAdmin.Enabled = False
            My.Forms.frmServerToolMain.cmnuAdminTray.Enabled = False
        End If
        If intAccount = 0 Then
            My.Forms.frmServerToolMain.mnuTimerAdjustments.Enabled = False
        End If
        If intAccount > 0 Then
            My.Forms.frmServerToolMain.mnuTimerAdjustments.Enabled = True
        End If
        If intControl = 0 Then
            My.Forms.frmServerToolMain.mnuServiceRestart.Enabled = False
            My.Forms.frmServerToolMain.mnuServiceStart.Enabled = False
            My.Forms.frmServerToolMain.mnuServiceStop.Enabled = False
        End If
        If intControl = 1 Then
            My.Forms.frmServerToolMain.mnuServiceRestart.Enabled = True
            My.Forms.frmServerToolMain.mnuServiceStart.Enabled = True
            My.Forms.frmServerToolMain.mnuServiceStop.Enabled = True
        End If
        If intControl = 2 Then
            My.Forms.frmServerToolMain.mnuServiceRestart.Enabled = False
            My.Forms.frmServerToolMain.mnuServiceStart.Enabled = True
            My.Forms.frmServerToolMain.mnuServiceStop.Enabled = True
        End If
    End Sub

    Public Sub ServiceRun()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If File.Exists(strFileSettings) Then
            If intSettings = 9 Then
                Try
                    strSettingsAccess = strSettingsRawData(5)
                    If Operators.CompareString(strSettingsAccess, "Access=NULL", False) <> 0 Then
                        strServiceCheck = strSettingsAccess.Substring(strSettingsAccess.IndexOf("="c) + 1)
                        Integer.TryParse(strServiceCheck, intControl)
                        If intControl = 2 Then
                            My.Forms.frmServerToolMain.mnuServiceRestart.Enabled = False
                        End If
                    End If
                Catch exAccess As Exception
                    Dim exErrorData As Exception = exAccess
                    intErrorMessage = 17
                    ErrorMessage()
                    intErrorMessage = 0
                    intControl = 0
                    strDiagnostics2 = exErrorData.Message
                    DiagnosticsLoad()
                End Try
            Else
                intErrorMessage = 2
                ErrorMessage()
                intErrorMessage = 0
            End If
        End If
        If File.Exists(strFileSettings) Then
            If intSettings = 9 Then
                Try
                    strSettingsService = strSettingsRawData(6)
                    If Operators.CompareString(strSettingsService, "Service=NULL", False) <> 0 Then
                        strServiceName = strSettingsService.Substring(strSettingsService.IndexOf("="c) + 1)
                    End If
                Catch exService As Exception
                    Dim exErrorData As Exception = exService
                    intErrorMessage = 18
                    ErrorMessage()
                    intErrorMessage = 0
                    strDiagnostics3 = exErrorData.Message
                    DiagnosticsLoad()
                End Try
            Else
                intErrorMessage = 2
                ErrorMessage()
                intErrorMessage = 0
            End If
        End If
        If File.Exists(strFileSettings) Then
            If intSettings = 9 Then
                Try
                    strSettingsProcess = strSettingsRawData(7)
                    If Operators.CompareString(strSettingsProcess, "Program=NULL", False) <> 0 Then
                        strProcessName = strSettingsProcess.Substring(strSettingsProcess.IndexOf("="c) + 1)
                    End If
                Catch exProgram As Exception
                    Dim exErrorData As Exception = exProgram
                    intErrorMessage = 19
                    ErrorMessage()
                    intErrorMessage = 0
                    strDiagnostics4 = exErrorData.Message
                    DiagnosticsLoad()
                End Try
            Else
                intErrorMessage = 2
                ErrorMessage()
                intErrorMessage = 0
            End If
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub CreateSettings()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        strFileSettings = Path.Combine(Application.StartupPath, "Settings.ini")
        If Not File.Exists(strFileSettings) Then
            strFile = Path.Combine(Application.StartupPath, "tsdns_settings.ini")
            Using streamWriter As StreamWriter = New StreamWriter(strFileSettings)
                streamWriter.WriteLine("Username=NULL")
                streamWriter.WriteLine("Password=NULL")
                streamWriter.WriteLine("Time=NULL")
                streamWriter.WriteLine("DNSSettings=NULL")
                streamWriter.WriteLine("Checked=NULL")
                streamWriter.WriteLine("Access=NULL")
                streamWriter.WriteLine("Service=NULL")
                streamWriter.WriteLine("Program=NULL")
                streamWriter.Write("Start=NULL")
            End Using
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
        StartupSettings()
    End Sub

    Public Sub ServiceStatus()
        If My.User.IsInRole(BuiltInRole.Administrator) Then
            If intControl <> 1 Then
            End If
            Try
                Dim svcTeamspeak As ServiceController = New ServiceController(strServiceName, ".")
                If svcServerTool.Status.Equals(ServiceControllerStatus.Stopped) Then
                    My.Forms.frmServerToolMain.mnuServiceStop.Enabled = False
                    My.Forms.frmServerToolMain.mnuServiceStart.Enabled = True
                End If
                If svcServerTool.Status.Equals(ServiceControllerStatus.Running) Then
                    My.Forms.frmServerToolMain.mnuServiceStart.Enabled = False
                    My.Forms.frmServerToolMain.mnuServiceStop.Enabled = True
                End If
            Catch exServiceStatus As Exception
                Dim exErrorData As Exception = exServiceStatus
                intErrorMessage = 48
                If intTimerFixService = 0 Then
                    ErrorMessage()
                End If
                intErrorMessage = 0
                strDiagnostics20 = exErrorData.Message
                DiagnosticsLoad()
            End Try
        End If
        My.Forms.frmServerToolMain.mnuServiceRestart.Enabled = False
        My.Forms.frmServerToolMain.mnuServiceStart.Enabled = False
        My.Forms.frmServerToolMain.mnuServiceStop.Enabled = False
        If intControl = 2 Then
            My.Forms.frmServerToolMain.mnuServiceRestart.Enabled = False
            My.Forms.frmServerToolMain.mnuServiceStart.Enabled = True
            My.Forms.frmServerToolMain.mnuServiceStop.Enabled = True
        End If
    End Sub

    Public Sub ServiceProcess()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        ServiceStatus()
        If intControl = 0 Or intControl > 2 Then
            intErrorMessage = 15
            If intTimerFixService = 0 Then
                ErrorMessage()
            End If
            intErrorMessage = 0
        End If
        If intControl = 2 Then
            If Operators.CompareString(strProcessName, String.Empty, False) = 0 Then
                intErrorMessage = 25
                If intTimerFixService = 0 Then
                    ErrorMessage()
                End If
                intErrorMessage = 0
            Else
                If intRestart = 1 Then
                    intCheckSP = 0
                    intErrorMessage = 16
                    If intTimerFixService = 0 Then
                        ErrorMessage()
                    End If
                    intErrorMessage = 0
                    If intStart = 1 Then
                        Try
                            procExecuting = New Process()
                            procExecuting.StartInfo.FileName = strProcessName
                            procExecuting.Start()
                            procExecuting.EnableRaisingEvents = True
                            AddHandler procExecuting.Exited, AddressOf ProcessExited
                            intMessageError = 4
                        Catch exServiceRestartStart As Exception
                            Dim exErrorData As Exception = exServiceRestartStart
                            intErrorMessage = 20
                            If intTimerFixService = 0 Then
                                ErrorMessage()
                            End If
                            intErrorMessage = 0
                            strDiagnostics5 = exErrorData.Message
                            DiagnosticsLoad()
                        End Try
                    End If
                End If
                If intStop = 1 Then
                    Try
                        If procExecuting IsNot Nothing AndAlso Not procExecuting.HasExited Then
                            procExecuting.CloseMainWindow()
                            procExecuting.WaitForExit(1000)
                            If Not procExecuting.HasExited Then
                                procExecuting.Kill()
                            End If
                        End If
                        intMessageError = 5
                    Catch exServiceRestartStop As Exception
                        Dim exErrorData As Exception = exServiceRestartStop
                        intErrorMessage = 21
                        If intTimerFixService = 0 Then
                            ErrorMessage()
                        End If
                        intErrorMessage = 0
                        strDiagnostics6 = exErrorData.Message
                        DiagnosticsLoad()
                    End Try
                End If
            End If
        End If
        If intControl = 1 Then
            If Operators.CompareString(strServiceName, String.Empty, False) = 0 Then
                intErrorMessage = 26
                If intTimerFixService = 0 Then
                    ErrorMessage()
                End If
                intErrorMessage = 0
            Else
                If intRestart = 1 Then
                    intCheckSP = 1
                    Try
                        Dim serviceController As ServiceController = New ServiceController(strServiceName, ".")
                        If Not serviceController.Status.Equals(ServiceControllerStatus.Stopped) Then
                            serviceController.[Stop]()
                        Else
                            intErrorMessage = 45
                            If intTimerFixService = 0 Then
                                ErrorMessage()
                            End If
                            intErrorMessage = 0
                        End If
                        Thread.Sleep(2000)
                        If serviceController.Status.Equals(ServiceControllerStatus.Stopped) Then
                            serviceController.Start()
                        End If
                    Catch exServiceRestart As Exception
                        Dim exErrorData As Exception = exServiceRestart
                        intCheckSP = 0
                        intErrorMessage = 22
                        If intTimerFixService = 0 Then
                            ErrorMessage()
                        End If
                        intErrorMessage = 0
                        strDiagnostics7 = exErrorData.Message
                        DiagnosticsLoad()
                    End Try
                End If
                If intStart = 1 Then
                    Try
                        Dim serviceController2 As ServiceController = New ServiceController(strServiceName, ".")
                        If serviceController2.Status.Equals(ServiceControllerStatus.Stopped) Then
                            serviceController2.Start()
                            intMessageError = 4
                        Else
                            intErrorMessage = 43
                            If intTimerFixService = 0 Then
                                ErrorMessage()
                            End If
                            intErrorMessage = 0
                        End If
                    Catch exServiceStart As Exception
                        Dim exErrorData As Exception = exServiceStart
                        intErrorMessage = 23
                        If intTimerFixService = 0 Then
                            ErrorMessage()
                        End If
                        intErrorMessage = 0
                        strDiagnostics8 = exErrorData.Message
                        DiagnosticsLoad()
                    End Try
                End If
                If intStop = 1 Then
                    Try
                        Dim serviceController3 As ServiceController = New ServiceController(strServiceName, ".")
                        If Not serviceController3.Status.Equals(ServiceControllerStatus.Stopped) Then
                            serviceController3.[Stop]()
                            intMessageError = 5
                        Else
                            intErrorMessage = 44
                            If intTimerFixService = 0 Then
                                ErrorMessage()
                            End If
                            intErrorMessage = 0
                        End If
                    Catch exServiceStop As Exception
                        Dim exErrorData As Exception = exServiceStop
                        intErrorMessage = 24
                        If intTimerFixService = 0 Then
                            ErrorMessage()
                        End If
                        intErrorMessage = 0
                        strDiagnostics9 = exErrorData.Message
                        DiagnosticsLoad()
                    End Try
                End If
            End If
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub ErrorMessage()
        If intErrorMessage = 1 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Settings Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We could not get a valid file path from DNSSettings in settings."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount1 += 1
            If intErrorCount1 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We could not get a valid file path from DNSSettings in settings", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 2 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Settings Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "You have mess with settings file and have not correctly changed it to represent valid data."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCountStartUp += 1
            If intErrorCountStartUp <= 3 Then
                intErrorCount2 = 1
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("You have mess with settings file and have not correctly changed it to represent valid data", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If intErrorCount2 > 0 And intErrorCount2 < 4 - intErrorCountStartUp Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("You have mess with settings file and have not correctly changed it to represent valid data", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 3 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Settings Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We could not get the checked domains for update data from settings."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount3 += 1
            If intErrorCount3 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We could not get the checked domains for update data from settings", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 4 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Settings Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "There was an error reading Username and or Password in settings."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount4 += 1
            If intErrorCount4 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("There was an error reading Username and or Password in settings", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 5 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - File Read Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We can't edit this file as it contains # or any other character that is not necessary for the main function of teamspeak dns server and we ask you to remove the commented part of the text so we may properly read the file."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount5 += 1
            If intErrorCount5 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We can't edit this file as it contains # or any other character that is not necessary for the main function of teamspeak dns server and we ask you to remove the commented part of the text so we may properly read the file", "File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 6 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - File Path Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We could not find the file, Please go define it in the file tab."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount6 += 1
            If intErrorCount6 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We could not find the file, Please go define it in the file tab", "File Path Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 7 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Domain Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "You have no domains in the ini file, Please add a domain or build a new ini file."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount7 += 1
            If intErrorCount7 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("You have no domains in the ini file, Please add a domain or build a new ini file", "Domain Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 8 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Settings Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "There was an error get a valid number from time in settings."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount8 += 1
            If intErrorCount8 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("There was an error get a valid number from time in settings", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 9 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - File Read Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "The teamspeak dns file has not been properly formatted to work, Please revise the file."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount9 += 1
            If intErrorCount9 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("The teamspeak dns file has not been properly formatted to work, Please revise the file", "File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 10 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Current User Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "You are curently login and cant not update more than 10 dns at a time."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount10 += 1
            If intErrorCount10 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("You are curently login and cant not update more than 10 dns at a time", "Current User Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 11 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Internet Connection Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We could not connect to the internet to get the ip address, Please try again at a later time."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount11 += 1
            If intErrorCount11 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We could not connect to the internet to get the ip address, Please try again at a later time", "Internet Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 12 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - File Read Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "This is not Teamspeak's DNS Settings File, Please try again."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount12 += 1
            If intErrorCount12 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("This is not Teamspeak's DNS Settings File, Please try again", "File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 13 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Application Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "You have not loaded a Teamspeak DNS File, Please load the file before trying to reload."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount13 += 1
            If intErrorCount13 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("You have not loaded a Teamspeak DNS File, Please load the file before trying to reload", "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 14 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Reset Complete"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We have completed the reset all data has been cleaned."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount14 += 1
            If intErrorCount14 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We have completed the reset all data has been cleaned", "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 15 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Service Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "You have not specified a service name or process file location."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount15 += 1
            If intErrorCount15 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("You have not specified a service name or process file location", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 16 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Restart Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We can't restart a process please just manually stop and start the process, sorry for the inconvenience but at least this only affects manual restart."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount16 += 1
            If intErrorCount16 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We can't restart a process please just manually stop and start the process, sorry for the inconvenience but at least this only affects manual restart", "Restart Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 17 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Settings Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We could not use access to get a valid number in the settings file."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount17 += 1
            If intErrorCount17 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We could not use access to get a valid number in the settings file", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 18 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Settings Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We could not use the service name specified in the settings file."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount18 += 1
            If intErrorCount18 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We could not use the service name specified in the settings file", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 19 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Settings Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We could not use the file specified in the settings file."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount19 += 1
            If intErrorCount19 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We could not use the file specified in the settings file", "Settings Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 20 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Process Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We failed to start that process, Please try again later."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount20 += 1
            If intErrorCount20 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We failed to start that process, Please try again later", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 21 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Process Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We failed to stop that process, Please try again later."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount21 += 1
            If intErrorCount21 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We failed to stop that process, Please try again later", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 22 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Service Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We failed to restart that service, Please try again later."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intRestartErrorCheck += 1
            intErrorCount22 += 1
            If intErrorCount22 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We failed to restart that service, Please try again later", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 23 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Service Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We failed to start that service, Please try again later."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount23 += 1
            If intErrorCount23 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We failed to start that service, Please try again later", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 24 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Service Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We failed to stop that service, Please try again later."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount24 += 1
            If intErrorCount24 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We failed to stop that service, Please try again later", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 25 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Process Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We could not use this file, Please try again or pick a new file."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount25 += 1
            If intErrorCount25 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We could not use this file, Please try again or pick a new file", "Process Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 26 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Service Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We could not use this service name, Please try again or pick a new service name."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount26 += 1
            If intErrorCount26 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We could not use this service name, Please try again or pick a new service name", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 27 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Reset Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "Not much has changed so there is no need for a reset, Please load a file then you may reset the data."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount27 += 1
            If intErrorCount27 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("Not much has changed so there is no need for a reset, Please load a file then you may reset the data", "Reset Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 28 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Settings Saved"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "Your setting have been saved to the settings file."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount28 += 1
            If intErrorCount28 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("Your setting have been saved to the settings file", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 29 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Write Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "You have not given a valid file to write too, Please go define the file and try again."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount29 += 1
            If intErrorCount29 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("You have not given a valid file to write too, Please go define the file and try again", "Write Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 30 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Exit Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We ask you wait till the operation is completed."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount30 += 1
            If intErrorCount30 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We ask you wait till the till the operation is completed", "Exit Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 31 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Startup Message"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "You will only see the same message 3 times before the message stops popping up."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount31 += 1
            If intErrorCount31 <= 1 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("You will only see the same message 3 times before the message stops popping up", "Startup Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 32 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Guest User Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "You can't change the timer unless you login in to an account."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount32 += 1
            If intErrorCount32 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("You can't change the timer unless you login in to an account", "Guest User Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 33 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Wipe Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "No file found to wipe clean, Please find the file and try again."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount33 += 1
            If intErrorCount33 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("No file found to wipe clean, Please find the file and try again", "Wipe Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 34 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Data Reloaded"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We have reloaded all data successfully."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount34 += 1
            If intErrorCount34 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We have reloaded all data successfully", "Data Reloaded", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 35 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Teamspeak DNS Started"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "The service or process has successfully started."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount35 += 1
            If intErrorCount35 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("The service or process has successfully started", "Teamspeak DNS Started", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 36 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Teamspeak DNS Stoped"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "The service or process has successfully stoped."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount36 += 1
            If intErrorCount36 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("The service or process has successfully stoped", "Teamspeak DNS Stoped", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 37 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Teamspeak DNS Restarted"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "The service has successfully restarted."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount37 += 1
            If intErrorCount37 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("The service has successfully restarted", "Teamspeak DNS Restarted", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 38 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Teamspeak DNS File Updated"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "Teamspeak dns file has been updated."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount38 += 1
            If intErrorCount38 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("Teamspeak dns file has been updated", "Teamspeak DNS File Updated", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 39 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Domain Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We can only support up to 20 domains, Continue at your own discretion."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount39 += 1
            If intErrorCount39 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We can only support up to 20 domains, Continue at your own discretion", "Domain Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 40 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Startup Control"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "The registry has been updated so Teamspeak Assistant Tool Application will start up with your computer."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount40 += 1
            If intErrorCount40 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("The registry has been updated so Teamspeak Assistant Tool Application will start up with your computer", "Startup Control", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 41 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Info
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Startup Control"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "The registry has been updated so the Teamspeak Assistant Tool Application does not start with your computer."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount41 += 1
            If intErrorCount41 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("The registry has been updated so the Teamspeak Assistant Tool Application does not start with your computer", "Startup Control", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 42 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Startup Control Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "No registry value of the Teamspeak Assistant Tool Application was found."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount42 += 1
            If intErrorCount42 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("No registry value of the Teamspeak Assistant Tool Application was found", "Startup Control Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 43 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Service Startup Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "The service is already running, please stop the service before asking to start it again."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount43 += 1
            If intErrorCount43 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("The service is already running, please stop the service before asking to start it again", "Service Startup Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 44 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Service Stoping Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "The service has already been stoped, please start the service before asking to stop it again."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount44 += 1
            If intErrorCount44 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("The service has already been stoped, please start the service before asking to stop it again", "Service Stoping Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 45 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Service Restarting Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "To restart a service you need to have the service running."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount45 += 1
            If intErrorCount45 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("To restart a service you need to have the service running", "Service Restarting Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 46 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Start in Tray Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "We could not get a valid integer for the start in tray variable."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount46 += 1
            If intErrorCount46 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("We could not get a valid integer for the start in tray variable", "Start in Tray Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 47 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Start in Tray Error"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "The start in tray variable has exceeded it allowed integer limit."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount47 += 1
            If intErrorCount47 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("The start in tray variable has exceeded it allowed integer limit", "Start in Tray Error", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 48 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Warning
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Service Does Not Exists"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "The Service Name you provided does not exists in this machine."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount48 += 1
            If intErrorCount48 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("The Service Name you provided does not exists in this machine", "Service Does Not Exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
        If intErrorMessage = 49 Then
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.Warning
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - No Need to wipe settings file"
            My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = "The settings file has no user saved setting on it yet."
            My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
            intErrorCount49 += 1
            If intErrorCount49 <= 3 Then
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(192, 57, 43)
                MessageBox.Show("The settings file as no user saved setting on it yet", "No Custom User Settings Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
        End If
    End Sub

    Public Sub ResetSettings()
        intError = 1
        ErrorReset()
        intError = 0
    End Sub

    Public Sub FileLocation()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If File.Exists(strFileSettings) Then
            If intSettings = 9 Then
                Try
                    strSettingsFileLocation = strSettingsRawData(3)
                    If Operators.CompareString(strSettingsFileLocation, "DNSSettings=NULL", False) = 0 Then
                        strFile = Path.Combine(Application.StartupPath, "tsdns_settings.ini")
                    Else
                        strFile = strSettingsFileLocation.Substring(strSettingsFileLocation.IndexOf("="c) + 1)
                    End If
                Catch exDDNSSettings As Exception
                    Dim exErrorData As Exception = exDDNSSettings
                    intErrorMessage = 1
                    ErrorMessage()
                    intErrorMessage = 0
                    strDiagnostics10 = exErrorData.Message
                    DiagnosticsLoad()
                End Try
            Else
                intErrorMessage = 2
                ErrorMessage()
                intErrorMessage = 0
            End If
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub Message()
        Dim strCurrentTime As String = System.DateTime.Now.ToString("MM/dd/yyyy, hh:mm tt")
        Dim strLabelTime As String = strCurrentTime
        If intAccount = 0 Then
            My.Forms.frmServerToolMain.mnuLogo.Image = My.Resources.teamspeak
            My.Forms.frmServerToolMain.lblSpace.Text = "    " + "Date/Time: " + strLabelTime + "    "
            My.Forms.frmServerToolMain.lblSpace.ForeColor = Color.White
            My.Forms.frmServerToolMain.lblMessage.Text = "Welcome Guest User :-)"
            My.Forms.frmServerToolMain.lblMessage.ForeColor = Color.White
        End If
        If intAccount = 1 Then
            My.Forms.frmServerToolMain.mnuLogo.Image = My.Resources.logo
            My.Forms.frmServerToolMain.lblSpace.Text = "   " + "Date/Time: " + strLabelTime + " "
            My.Forms.frmServerToolMain.lblSpace.ForeColor = Color.White
            My.Forms.frmServerToolMain.lblMessage.Text = "Welcome xKiller Admin :-)"
            My.Forms.frmServerToolMain.lblMessage.ForeColor = Color.White
        End If
        If intAccount = 2 Then
            My.Forms.frmServerToolMain.mnuLogo.Image = My.Resources.logo
            My.Forms.frmServerToolMain.lblSpace.Text = "    " + "Date/Time: " + strLabelTime + "   "
            My.Forms.frmServerToolMain.lblSpace.ForeColor = Color.White
            My.Forms.frmServerToolMain.lblMessage.Text = "Welcome xKiller User :-)"
            My.Forms.frmServerToolMain.lblMessage.ForeColor = Color.White
        End If
        If intAccount = 3 Then
            My.Forms.frmServerToolMain.mnuLogo.Image = My.Resources.logo
            My.Forms.frmServerToolMain.lblSpace.Text = "   " + "Date/Time: " + strLabelTime + "  "
            My.Forms.frmServerToolMain.lblSpace.ForeColor = Color.White
            My.Forms.frmServerToolMain.lblMessage.Text = "Welcome Trusted User :-)"
            My.Forms.frmServerToolMain.lblMessage.ForeColor = Color.White
        End If
    End Sub

    Public Sub UserControl()
        intExternalError = frmTeamspeakService.intError
        intControl = frmTeamspeakService.intSendInfo
        If intControl = 2 Then
            strProcessName = frmTeamspeakService.strProcess
        End If
        If intControl = 1 Then
            strServiceName = frmTeamspeakService.strServiceName
        End If
        If intExternalError = 1 Then
            strProcessName = String.Empty
            strServiceName = String.Empty
            intExternalError = 0
        End If
    End Sub

    Public Sub AccountVarable()
        If intAccount = 0 Then
            strUsername = "NULL"
            strPassword = "NULL"
        End If
        If intAccount = 1 Then
            strUsername = "xKillerAdmin"
            strPassword = "K!w%XJS3N7Xw*7A*A^zDOCiqs"
        End If
        If intAccount = 2 Then
            strUsername = "xKillerMember"
            strPassword = "Ik1rSlnS&xpC5L*UT$Yd1X@UE"
        End If
        If intAccount = 3 Then
            strUsername = "Trusted User"
            strPassword = "rPw66vk$@!J#BMIhh9P6FWGj4"
        End If
    End Sub

    Public Sub ErrorReset()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If intError = 1 Then
            Using streamWriter As StreamWriter = New StreamWriter(strFileSettings)
                streamWriter.WriteLine("Username=NULL")
                streamWriter.WriteLine("Password=NULL")
                streamWriter.WriteLine("Time=NULL")
                streamWriter.WriteLine("DNSSettings=NULL")
                streamWriter.WriteLine("Checked=NULL")
                streamWriter.WriteLine("Access=NULL")
                streamWriter.WriteLine("Service=NULL")
                streamWriter.WriteLine("Program=NULL")
                streamWriter.Write("Start=NULL")
            End Using
        End If
        If File.Exists(strFile) Then
            intMessageError = 1
            My.Forms.frmServerToolMain.tmrServerTool.Enabled = False
            My.Forms.frmServerToolMain.chkDomain0.Checked = False
            My.Forms.frmServerToolMain.chkDomain1.Checked = False
            My.Forms.frmServerToolMain.chkDomain2.Checked = False
            My.Forms.frmServerToolMain.chkDomain3.Checked = False
            My.Forms.frmServerToolMain.chkDomain4.Checked = False
            My.Forms.frmServerToolMain.chkDomain5.Checked = False
            My.Forms.frmServerToolMain.chkDomain6.Checked = False
            My.Forms.frmServerToolMain.chkDomain7.Checked = False
            My.Forms.frmServerToolMain.chkDomain8.Checked = False
            My.Forms.frmServerToolMain.chkDomain9.Checked = False
            My.Forms.frmServerToolMain.chkDomain10.Checked = False
            My.Forms.frmServerToolMain.chkDomain11.Checked = False
            My.Forms.frmServerToolMain.chkDomain12.Checked = False
            My.Forms.frmServerToolMain.chkDomain13.Checked = False
            My.Forms.frmServerToolMain.chkDomain14.Checked = False
            My.Forms.frmServerToolMain.chkDomain15.Checked = False
            My.Forms.frmServerToolMain.chkDomain16.Checked = False
            My.Forms.frmServerToolMain.chkDomain17.Checked = False
            My.Forms.frmServerToolMain.chkDomain18.Checked = False
            My.Forms.frmServerToolMain.chkDomain19.Checked = False
            My.Forms.frmServerToolMain.chkDomain0.Enabled = False
            My.Forms.frmServerToolMain.chkDomain1.Enabled = False
            My.Forms.frmServerToolMain.chkDomain2.Enabled = False
            My.Forms.frmServerToolMain.chkDomain3.Enabled = False
            My.Forms.frmServerToolMain.chkDomain4.Enabled = False
            My.Forms.frmServerToolMain.chkDomain5.Enabled = False
            My.Forms.frmServerToolMain.chkDomain6.Enabled = False
            My.Forms.frmServerToolMain.chkDomain7.Enabled = False
            My.Forms.frmServerToolMain.chkDomain8.Enabled = False
            My.Forms.frmServerToolMain.chkDomain9.Enabled = False
            My.Forms.frmServerToolMain.chkDomain10.Enabled = False
            My.Forms.frmServerToolMain.chkDomain11.Enabled = False
            My.Forms.frmServerToolMain.chkDomain12.Enabled = False
            My.Forms.frmServerToolMain.chkDomain13.Enabled = False
            My.Forms.frmServerToolMain.chkDomain14.Enabled = False
            My.Forms.frmServerToolMain.chkDomain15.Enabled = False
            My.Forms.frmServerToolMain.chkDomain16.Enabled = False
            My.Forms.frmServerToolMain.chkDomain17.Enabled = False
            My.Forms.frmServerToolMain.chkDomain18.Enabled = False
            My.Forms.frmServerToolMain.chkDomain19.Enabled = False
            My.Forms.frmServerToolMain.chkDomain0.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain1.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain2.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain3.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain4.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain5.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain6.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain7.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain8.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain9.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain10.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain11.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain12.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain13.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain14.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain15.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain16.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain17.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain18.Text = "Not Available"
            My.Forms.frmServerToolMain.chkDomain19.Text = "Not Available"
            strDisplay0 = String.Empty
            strDisplay1 = String.Empty
            strDisplay2 = String.Empty
            strDisplay3 = String.Empty
            strDisplay4 = String.Empty
            strDisplay5 = String.Empty
            strDisplay6 = String.Empty
            strDisplay7 = String.Empty
            strDisplay8 = String.Empty
            strDisplay9 = String.Empty
            strDisplay10 = String.Empty
            strDisplay11 = String.Empty
            strDisplay12 = String.Empty
            strDisplay13 = String.Empty
            strDisplay14 = String.Empty
            strDisplay15 = String.Empty
            strDisplay16 = String.Empty
            strDisplay17 = String.Empty
            strDisplay18 = String.Empty
            strDisplay19 = String.Empty
            strFile = String.Empty
            strFileSettings = String.Empty
            strServiceName = String.Empty
            strProcessName = String.Empty
            strDiagnostics0 = String.Empty
            strDiagnostics1 = String.Empty
            strDiagnostics2 = String.Empty
            strDiagnostics3 = String.Empty
            strDiagnostics4 = String.Empty
            strDiagnostics5 = String.Empty
            strDiagnostics6 = String.Empty
            strDiagnostics7 = String.Empty
            strDiagnostics8 = String.Empty
            strDiagnostics9 = String.Empty
            strDiagnostics10 = String.Empty
            strDiagnostics11 = String.Empty
            strDiagnostics12 = String.Empty
            strDiagnostics13 = String.Empty
            strDiagnostics14 = String.Empty
            strDiagnostics15 = String.Empty
            strDiagnostics16 = String.Empty
            CleanStartUp()
            TimeChange()
            FileLocation()
            Loadup()
            Startup()
            ButtonCheck()
        Else
            intErrorMessage = 27
            ErrorMessage()
            intErrorMessage = 0
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub Account()
        intAccount = frmTeamspeakLogin.intAccountLogin
        Message()
    End Sub

    Public Sub Time()
        intUserTime = My.Forms.frmTeamspeakTime.intUserTime
        TimeChange()
    End Sub

    Public Sub TimeChange()
        intFixTime = intUserTime * 60
        My.Forms.frmServerToolMain.psbTeamspeakProgress.Maximum = intFixTime
    End Sub

    Public Sub AccountSave()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If Operators.CompareString(strUsername, "xKillerAdmin", False) = 0 And Operators.CompareString(strPassword, "K!w%XJS3N7Xw*7A*A^zDOCiqs", False) = 0 Then
            intAccount = 1
        End If
        If Operators.CompareString(strUsername, "xKillerMember", False) = 0 And Operators.CompareString(strPassword, "Ik1rSlnS&xpC5L*UT$Yd1X@UE", False) = 0 Then
            intAccount = 2
        End If
        If Operators.CompareString(strUsername, "Trusted User", False) = 0 And Operators.CompareString(strPassword, "rPw66vk$@!J#BMIhh9P6FWGj4", False) = 0 Then
            intAccount = 3
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub ReadSettings()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If File.Exists(strFileSettings) Then
            If intSettings = 9 Then
                Try
                    strChecked = strSettingsRawData(4)
                    If Operators.CompareString(strChecked, "Checked=NULL", False) <> 0 Then
                        strSettingsChecked = strChecked
                        If intAccount = 0 Then
                            If strSettingsChecked.Contains("chk0") AndAlso My.Forms.frmServerToolMain.chkDomain0.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain0.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk1") AndAlso My.Forms.frmServerToolMain.chkDomain1.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain1.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk2") AndAlso My.Forms.frmServerToolMain.chkDomain2.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain2.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk3") AndAlso My.Forms.frmServerToolMain.chkDomain3.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain3.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk4") AndAlso My.Forms.frmServerToolMain.chkDomain4.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain4.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk5") AndAlso My.Forms.frmServerToolMain.chkDomain5.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain5.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk6") AndAlso My.Forms.frmServerToolMain.chkDomain6.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain6.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk7") AndAlso My.Forms.frmServerToolMain.chkDomain7.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain7.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk8") AndAlso My.Forms.frmServerToolMain.chkDomain8.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain8.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk9") AndAlso My.Forms.frmServerToolMain.chkDomain9.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain9.Checked = True
                            End If
                        End If
                        If intAccount > 0 Then
                            If strSettingsChecked.Contains("chk0") AndAlso My.Forms.frmServerToolMain.chkDomain0.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain0.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk1") AndAlso My.Forms.frmServerToolMain.chkDomain1.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain1.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk2") AndAlso My.Forms.frmServerToolMain.chkDomain2.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain2.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk3") AndAlso My.Forms.frmServerToolMain.chkDomain3.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain3.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk4") AndAlso My.Forms.frmServerToolMain.chkDomain4.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain4.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk5") AndAlso My.Forms.frmServerToolMain.chkDomain5.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain5.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk6") AndAlso My.Forms.frmServerToolMain.chkDomain6.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain6.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk7") AndAlso My.Forms.frmServerToolMain.chkDomain7.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain7.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk8") AndAlso My.Forms.frmServerToolMain.chkDomain8.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain8.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk9") AndAlso My.Forms.frmServerToolMain.chkDomain9.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain9.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk10") AndAlso My.Forms.frmServerToolMain.chkDomain10.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain10.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk11") AndAlso My.Forms.frmServerToolMain.chkDomain11.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain11.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk12") AndAlso My.Forms.frmServerToolMain.chkDomain12.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain12.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk13") AndAlso My.Forms.frmServerToolMain.chkDomain13.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain13.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk14") AndAlso My.Forms.frmServerToolMain.chkDomain14.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain14.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk15") AndAlso My.Forms.frmServerToolMain.chkDomain15.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain15.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk16") AndAlso My.Forms.frmServerToolMain.chkDomain16.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain16.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk17") AndAlso My.Forms.frmServerToolMain.chkDomain17.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain17.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk18") AndAlso My.Forms.frmServerToolMain.chkDomain18.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain18.Checked = True
                            End If
                            If strSettingsChecked.Contains("chk19") AndAlso My.Forms.frmServerToolMain.chkDomain19.Enabled Then
                                My.Forms.frmServerToolMain.chkDomain19.Checked = True
                            End If
                        End If
                    End If
                Catch exChecked As Exception
                    Dim exErrorData As Exception = exChecked
                    intErrorMessage = 3
                    ErrorMessage()
                    intErrorMessage = 0
                    strDiagnostics11 = exErrorData.Message
                    DiagnosticsLoad()
                End Try
            Else
                intErrorMessage = 2
                ErrorMessage()
                intErrorMessage = 0
            End If
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub CheckedDomain()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If My.Forms.frmServerToolMain.chkDomain0.Checked Then
            strCheckedDomain = "chk0,"
        End If
        If My.Forms.frmServerToolMain.chkDomain1.Checked Then
            strCheckedDomain += "chk1,"
        End If
        If My.Forms.frmServerToolMain.chkDomain2.Checked Then
            strCheckedDomain += "chk2,"
        End If
        If My.Forms.frmServerToolMain.chkDomain3.Checked Then
            strCheckedDomain += "chk3,"
        End If
        If My.Forms.frmServerToolMain.chkDomain4.Checked Then
            strCheckedDomain += "chk4,"
        End If
        If My.Forms.frmServerToolMain.chkDomain5.Checked Then
            strCheckedDomain += "chk5,"
        End If
        If My.Forms.frmServerToolMain.chkDomain6.Checked Then
            strCheckedDomain += "chk6,"
        End If
        If My.Forms.frmServerToolMain.chkDomain7.Checked Then
            strCheckedDomain += "chk7,"
        End If
        If My.Forms.frmServerToolMain.chkDomain8.Checked Then
            strCheckedDomain += "chk8,"
        End If
        If My.Forms.frmServerToolMain.chkDomain9.Checked Then
            strCheckedDomain += "chk9,"
        End If
        If My.Forms.frmServerToolMain.chkDomain10.Checked Then
            strCheckedDomain += "chk10,"
        End If
        If My.Forms.frmServerToolMain.chkDomain11.Checked Then
            strCheckedDomain += "chk11,"
        End If
        If My.Forms.frmServerToolMain.chkDomain12.Checked Then
            strCheckedDomain += "chk12,"
        End If
        If My.Forms.frmServerToolMain.chkDomain13.Checked Then
            strCheckedDomain += "chk13,"
        End If
        If My.Forms.frmServerToolMain.chkDomain14.Checked Then
            strCheckedDomain += "chk14,"
        End If
        If My.Forms.frmServerToolMain.chkDomain15.Checked Then
            strCheckedDomain += "chk15,"
        End If
        If My.Forms.frmServerToolMain.chkDomain16.Checked Then
            strCheckedDomain += "chk16,"
        End If
        If My.Forms.frmServerToolMain.chkDomain17.Checked Then
            strCheckedDomain += "chk17,"
        End If
        If My.Forms.frmServerToolMain.chkDomain18.Checked Then
            strCheckedDomain += "chk18,"
        End If
        If My.Forms.frmServerToolMain.chkDomain19.Checked Then
            strCheckedDomain += "chk19"
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub WriteSettings()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If Operators.CompareString(strSettingsUsername, "Username=NULL", False) = 0 And Operators.CompareString(strSettingsPassword, "Password=NULL", False) = 0 And Operators.CompareString(strSettingsTime, "Time=NULL", False) = 0 And Operators.CompareString(strSettingsFileLocation, "DNSSettings=NULL", False) = 0 And Operators.CompareString(strSettingsChecked, "Checked=NULL", False) = 0 And Operators.CompareString(strSettingsAccess, "Access=NULL", False) = 0 And Operators.CompareString(strSettingsService, "Service=NULL", False) = 0 And Operators.CompareString(strSettingsProcess, "Program=NULL", False) = 0 And Operators.CompareString(strSettingsStartInTray, "Start=NULL", False) = 0 Then
            File.WriteAllText(strFileSettings, "")
            CheckedDomain()
            AccountVarable()
            Using streamWriter As StreamWriter = New StreamWriter(strFileSettings)
                streamWriter.WriteLine("Username=" + strUsername)
                streamWriter.WriteLine("Password=" + strPassword)
                If intUserTime = 5 Then
                    streamWriter.WriteLine("Time=NULL")
                Else
                    streamWriter.WriteLine("Time=" + Conversions.ToString(intUserTime))
                End If
                If File.Exists(strFile) And strFile.Contains("tsdns_settings.ini") Then
                    streamWriter.WriteLine("DNSSettings=" + strFile)
                Else
                    streamWriter.WriteLine("DNSSettings=NULL")
                End If
                If Operators.CompareString(strCheckedDomain, String.Empty, False) = 0 Then
                    streamWriter.WriteLine("Checked=NULL")
                Else
                    streamWriter.WriteLine("Checked=" + strCheckedDomain)
                End If
                If intControl = 0 Then
                    streamWriter.WriteLine("Access=NULL")
                Else
                    streamWriter.WriteLine("Access=" + Conversions.ToString(intControl))
                End If
                If Operators.CompareString(strServiceName, String.Empty, False) = 0 Then
                    streamWriter.WriteLine("Service=NULL")
                Else
                    streamWriter.WriteLine("Service=" + strServiceName)
                End If
                If Operators.CompareString(strProcessName, String.Empty, False) = 0 Then
                    streamWriter.WriteLine("Program=NULL")
                Else
                    streamWriter.WriteLine("Program=" + strProcessName)
                End If
                If intStartTray = 0 Then
                    streamWriter.Write("Start=NULL")
                Else
                    streamWriter.WriteLine("Start=" + Conversions.ToString(intStartTray))
                End If
            End Using
        Else
            intErrorMessage = 49
            ErrorMessage()
            intErrorMessage = 0
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub WriteIP()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If File.Exists(strFile) Then
            intMessageError = 7
            File.WriteAllText(strFile, "")
            Using streamWriter As StreamWriter = New StreamWriter(strFile)
                If My.Forms.frmServerToolMain.chkDomain0.Checked Then
                    streamWriter.WriteLine(strDisplay0 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain0, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain0)
                End If
                If My.Forms.frmServerToolMain.chkDomain1.Checked Then
                    streamWriter.WriteLine(strDisplay1 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain1, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain1)
                End If
                If My.Forms.frmServerToolMain.chkDomain2.Checked Then
                    streamWriter.WriteLine(strDisplay2 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain2, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain2)
                End If
                If My.Forms.frmServerToolMain.chkDomain3.Checked Then
                    streamWriter.WriteLine(strDisplay3 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain3, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain3)
                End If
                If My.Forms.frmServerToolMain.chkDomain4.Checked Then
                    streamWriter.WriteLine(strDisplay4 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain4, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain4)
                End If
                If My.Forms.frmServerToolMain.chkDomain5.Checked Then
                    streamWriter.WriteLine(strDisplay5 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain5, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain5)
                End If
                If My.Forms.frmServerToolMain.chkDomain6.Checked Then
                    streamWriter.WriteLine(strDisplay6 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain6, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain6)
                End If
                If My.Forms.frmServerToolMain.chkDomain7.Checked Then
                    streamWriter.WriteLine(strDisplay7 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain7, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain7)
                End If
                If My.Forms.frmServerToolMain.chkDomain8.Checked Then
                    streamWriter.WriteLine(strDisplay8 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain8, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain8)
                End If
                If My.Forms.frmServerToolMain.chkDomain9.Checked Then
                    streamWriter.WriteLine(strDisplay9 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain9, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain9)
                End If
                If My.Forms.frmServerToolMain.chkDomain10.Checked Then
                    streamWriter.WriteLine(strDisplay10 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain10, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain10)
                End If
                If My.Forms.frmServerToolMain.chkDomain11.Checked Then
                    streamWriter.WriteLine(strDisplay11 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain11, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain11)
                End If
                If My.Forms.frmServerToolMain.chkDomain12.Checked Then
                    streamWriter.WriteLine(strDisplay12 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain12, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain12)
                End If
                If My.Forms.frmServerToolMain.chkDomain13.Checked Then
                    streamWriter.WriteLine(strDisplay13 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain13, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain13)
                End If
                If My.Forms.frmServerToolMain.chkDomain14.Checked Then
                    streamWriter.WriteLine(strDisplay14 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain14, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain14)
                End If
                If My.Forms.frmServerToolMain.chkDomain15.Checked Then
                    streamWriter.WriteLine(strDisplay15 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain15, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain15)
                End If
                If My.Forms.frmServerToolMain.chkDomain16.Checked Then
                    streamWriter.WriteLine(strDisplay16 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain16, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain16)
                End If
                If My.Forms.frmServerToolMain.chkDomain17.Checked Then
                    streamWriter.WriteLine(strDisplay17 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain17, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain17)
                End If
                If My.Forms.frmServerToolMain.chkDomain18.Checked Then
                    streamWriter.WriteLine(strDisplay18 + "=" + strExternalIP)
                ElseIf Operators.CompareString(strDomain18, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain18)
                End If
                If My.Forms.frmServerToolMain.chkDomain19.Checked Then
                    streamWriter.WriteLine(strDisplay19 + "=" + strExternalIP)
                End If
                If Operators.CompareString(strDomain19, "", False) <> 0 Then
                    streamWriter.WriteLine(strDomain19)
                End If
            End Using
        End If
        intErrorMessage = 29
        ErrorMessage()
        intErrorMessage = 0
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub Loadup()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        CreateSettings()
        If File.Exists(strFileSettings) Then
            If intSettings = 9 Then
                Try
                    strSettingsUsername = strSettingsRawData(0)
                    strSettingsPassword = strSettingsRawData(1)
                    If Not (Operators.CompareString(strSettingsUsername, "Username=NULL", False) = 0 Or Operators.CompareString(strSettingsPassword, "Password=NULL", False) = 0) Then
                        strUsername = strSettingsUsername.Substring(strSettingsUsername.IndexOf("="c) + 1)
                        strPassword = strSettingsPassword.Substring(strSettingsUsername.IndexOf("="c) + 1)
                        AccountSave()
                    End If
                Catch exUsername As Exception
                    Dim exErrorData As Exception = exUsername
                    intErrorMessage = 4
                    ErrorMessage()
                    intErrorMessage = 0
                    strDiagnostics12 = exErrorData.Message
                    DiagnosticsLoad()
                End Try
            Else
                intErrorMessage = 2
                ErrorMessage()
                intErrorMessage = 0
            End If
        End If
        Message()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub Startup()
        intStartUp = 0
        Status()
        IPAddress()
        CheckConnection()
    End Sub

    Public Sub LenghtFix()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If intDomain = 1 AndAlso Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
            intDomain -= 1
        End If
        If intDomain = 2 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 3 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 4 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 5 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 6 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 7 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 8 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 9 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(8), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 10 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(8), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(9), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 11 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(8), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(9), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(10), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 12 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(8), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(9), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(10), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(11), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 13 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(8), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(9), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(10), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(11), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(12), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 14 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(8), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(9), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(10), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(11), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(12), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(13), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 15 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(8), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(9), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(10), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(11), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(12), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(13), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(14), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 16 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(8), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(9), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(10), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(11), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(12), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(13), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(14), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(15), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 17 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(8), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(9), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(10), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(11), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(12), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(13), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(14), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(15), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(16), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 18 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(8), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(9), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(10), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(11), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(12), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(13), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(14), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(15), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(16), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(17), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 19 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(8), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(9), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(10), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(11), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(12), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(13), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(14), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(15), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(16), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(17), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(18), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        If intDomain = 20 Then
            If Operators.CompareString(strDnsRawData(0), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(1), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(2), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(3), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(4), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(5), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(6), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(7), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(8), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(9), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(10), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(11), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(12), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(13), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(14), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(15), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(16), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(17), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(18), "", False) = 0 Then
                intDomain -= 1
            End If
            If Operators.CompareString(strDnsRawData(19), "", False) = 0 Then
                intDomain -= 1
            End If
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub Status()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If File.Exists(strFile) Then
            strDnsRawData = File.ReadAllLines(strFile)
            intDomain = strDnsRawData.Length
            If intDomain > 20 Then
                intErrorMessage = 39
                ErrorMessage()
                intErrorMessage = 0
            End If
            LenghtFix()
            Null()
            If strDnsRawData.Contains("#") Or strDnsRawData.Contains("$") Or strDnsRawData.Contains("%") Or strDnsRawData.Contains("!") Or strDnsRawData.Contains("@") Or strDnsRawData.Contains("^") Or strDnsRawData.Contains("&") Or strDnsRawData.Contains("(") Or strDnsRawData.Contains(")") Or strDnsRawData.Contains("-") Or strDnsRawData.Contains("+") Or strDnsRawData.Contains("/") Or strDnsRawData.Contains(",") Or strDnsRawData.Contains(";") Or strDnsRawData.Contains(":") Or strDnsRawData.Contains("'") Or strDnsRawData.Contains("`") Or strDnsRawData.Contains("~") Or strDnsRawData.Contains("_") Or strDnsRawData.Contains("?") Or strDnsRawData.Contains("<") Or strDnsRawData.Contains(">") Then
                intErrorMessage = 5
                ErrorMessage()
                intErrorMessage = 0
            Else
                intStartUp = 1
                Engine()
                ReadSettings()
            End If
        Else
            If intStartUp > 0 Then
                intErrorMessage = 6
                ErrorMessage()
                intErrorMessage = 0
            End If
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub Null()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If intDomain = 1 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 19 + 1 - 1) {}), String())
            strDnsRawData(1) = "Not Available"
            strDnsRawData(2) = "Not Available"
            strDnsRawData(3) = "Not Available"
            strDnsRawData(4) = "Not Available"
            strDnsRawData(5) = "Not Available"
            strDnsRawData(6) = "Not Available"
            strDnsRawData(7) = "Not Available"
            strDnsRawData(8) = "Not Available"
            strDnsRawData(9) = "Not Available"
            strDnsRawData(10) = "Not Available"
            strDnsRawData(11) = "Not Available"
            strDnsRawData(12) = "Not Available"
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 2 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 18 + 1 - 1) {}), String())
            strDnsRawData(2) = "Not Available"
            strDnsRawData(3) = "Not Available"
            strDnsRawData(4) = "Not Available"
            strDnsRawData(5) = "Not Available"
            strDnsRawData(6) = "Not Available"
            strDnsRawData(7) = "Not Available"
            strDnsRawData(8) = "Not Available"
            strDnsRawData(9) = "Not Available"
            strDnsRawData(10) = "Not Available"
            strDnsRawData(11) = "Not Available"
            strDnsRawData(12) = "Not Available"
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 3 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 17 + 1 - 1) {}), String())
            strDnsRawData(3) = "Not Available"
            strDnsRawData(4) = "Not Available"
            strDnsRawData(5) = "Not Available"
            strDnsRawData(6) = "Not Available"
            strDnsRawData(7) = "Not Available"
            strDnsRawData(8) = "Not Available"
            strDnsRawData(9) = "Not Available"
            strDnsRawData(10) = "Not Available"
            strDnsRawData(11) = "Not Available"
            strDnsRawData(12) = "Not Available"
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 4 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 16 + 1 - 1) {}), String())
            strDnsRawData(4) = "Not Available"
            strDnsRawData(5) = "Not Available"
            strDnsRawData(6) = "Not Available"
            strDnsRawData(7) = "Not Available"
            strDnsRawData(8) = "Not Available"
            strDnsRawData(9) = "Not Available"
            strDnsRawData(10) = "Not Available"
            strDnsRawData(11) = "Not Available"
            strDnsRawData(12) = "Not Available"
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 5 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 15 + 1 - 1) {}), String())
            strDnsRawData(5) = "Not Available"
            strDnsRawData(6) = "Not Available"
            strDnsRawData(7) = "Not Available"
            strDnsRawData(8) = "Not Available"
            strDnsRawData(9) = "Not Available"
            strDnsRawData(10) = "Not Available"
            strDnsRawData(11) = "Not Available"
            strDnsRawData(12) = "Not Available"
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 6 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 14 + 1 - 1) {}), String())
            strDnsRawData(6) = "Not Available"
            strDnsRawData(7) = "Not Available"
            strDnsRawData(8) = "Not Available"
            strDnsRawData(9) = "Not Available"
            strDnsRawData(10) = "Not Available"
            strDnsRawData(11) = "Not Available"
            strDnsRawData(12) = "Not Available"
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 7 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 13 + 1 - 1) {}), String())
            strDnsRawData(7) = "Not Available"
            strDnsRawData(8) = "Not Available"
            strDnsRawData(9) = "Not Available"
            strDnsRawData(10) = "Not Available"
            strDnsRawData(11) = "Not Available"
            strDnsRawData(12) = "Not Available"
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 8 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 12 + 1 - 1) {}), String())
            strDnsRawData(8) = "Not Available"
            strDnsRawData(9) = "Not Available"
            strDnsRawData(10) = "Not Available"
            strDnsRawData(11) = "Not Available"
            strDnsRawData(12) = "Not Available"
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 9 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 11 + 1 - 1) {}), String())
            strDnsRawData(9) = "Not Available"
            strDnsRawData(10) = "Not Available"
            strDnsRawData(11) = "Not Available"
            strDnsRawData(12) = "Not Available"
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 10 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 10 + 1 - 1) {}), String())
            strDnsRawData(10) = "Not Available"
            strDnsRawData(11) = "Not Available"
            strDnsRawData(12) = "Not Available"
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 11 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 9 + 1 - 1) {}), String())
            strDnsRawData(11) = "Not Available"
            strDnsRawData(12) = "Not Available"
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 12 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 8 + 1 - 1) {}), String())
            strDnsRawData(12) = "Not Available"
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 13 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 7 + 1 - 1) {}), String())
            strDnsRawData(13) = "Not Available"
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 14 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 6 + 1 - 1) {}), String())
            strDnsRawData(14) = "Not Available"
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 15 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 5 + 1 - 1) {}), String())
            strDnsRawData(15) = "Not Available"
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 16 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 4 + 1 - 1) {}), String())
            strDnsRawData(16) = "Not Available"
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 17 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 3 + 1 - 1) {}), String())
            strDnsRawData(17) = "Not Available"
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 18 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 2 + 1 - 1) {}), String())
            strDnsRawData(18) = "Not Available"
            strDnsRawData(19) = "Not Available"
        End If
        If intDomain = 19 Then
            strDnsRawData = CType(Utils.CopyArray(strDnsRawData, New String(strDnsRawData.Length + 1 + 1 - 1) {}), String())
            strDnsRawData(19) = "Not Available"
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub Engine()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If intDomain = 0 Then
            intErrorMessage = 7
            ErrorMessage()
            intErrorMessage = 0
        Else
            If File.Exists(strFileSettings) Then
                If intSettings = 9 Then
                    Try
                        strSettingsTime = strSettingsRawData(2)
                        If Operators.CompareString(strSettingsTime, "Time=NULL", False) <> 0 AndAlso intAccount > 0 Then
                            strTimeCheck = strSettingsTime.Substring(strSettingsTime.IndexOf("="c) + 1)
                            Integer.TryParse(strTimeCheck, intUserTime)
                            TimeChange()
                        End If
                    Catch exTime As Exception
                        Dim exErrorData As Exception = exTime
                        intErrorMessage = 8
                        ErrorMessage()
                        intErrorMessage = 0
                        intUserTime = 5
                        TimeChange()
                        strDiagnostics13 = exErrorData.Message
                        DiagnosticsLoad()
                    End Try
                Else
                    intErrorMessage = 2
                    ErrorMessage()
                    intErrorMessage = 0
                End If
            End If
            My.Forms.frmServerToolMain.psbTeamspeakProgress.Maximum = intFixTime
            My.Forms.frmServerToolMain.tmrServerTool.Enabled = True
            If intAccount = 0 Then
                If intDomain > 10 Then
                    intErrorMessage = 10
                    ErrorMessage()
                    intErrorMessage = 0
                End If
                If strDnsRawData(0).Contains("Not Available") Then
                    strDisplay0 = ""
                Else
                    strDomain0 = strDnsRawData(0).ToString()
                    If strDomain0.Contains("=") Then
                        strDisplay0 = strDomain0.Substring(0, strDomain0.IndexOf("="))
                        If strDomain0.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain0.Text = strDisplay0
                            My.Forms.frmServerToolMain.chkDomain0.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain0.Text = strDisplay0
                            My.Forms.frmServerToolMain.chkDomain0.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain0, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(1).Contains("Not Available") Then
                    strDisplay1 = ""
                Else
                    strDomain1 = strDnsRawData(1).ToString()
                    If strDomain1.Contains("=") Then
                        strDisplay1 = strDomain1.Substring(0, strDomain1.IndexOf("="))
                        If strDomain1.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain1.Text = strDisplay1
                            My.Forms.frmServerToolMain.chkDomain1.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain1.Text = strDisplay1
                            My.Forms.frmServerToolMain.chkDomain1.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain1, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(2).Contains("Not Available") Then
                    strDisplay2 = ""
                Else
                    strDomain2 = strDnsRawData(2).ToString()
                    If strDomain2.Contains("=") Then
                        strDisplay2 = strDomain2.Substring(0, strDomain2.IndexOf("="))
                        If strDomain2.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain2.Text = strDisplay2
                            My.Forms.frmServerToolMain.chkDomain2.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain2.Text = strDisplay2
                            My.Forms.frmServerToolMain.chkDomain2.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain2, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(3).Contains("Not Available") Then
                    strDisplay3 = ""
                Else
                    strDomain3 = strDnsRawData(3).ToString()
                    If strDomain3.Contains("=") Then
                        strDisplay3 = strDomain3.Substring(0, strDomain3.IndexOf("="))
                        If strDomain3.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain3.Text = strDisplay3
                            My.Forms.frmServerToolMain.chkDomain3.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain3.Text = strDisplay3
                            My.Forms.frmServerToolMain.chkDomain3.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain3, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(4).Contains("Not Available") Then
                    strDisplay4 = ""
                Else
                    strDomain4 = strDnsRawData(4).ToString()
                    If strDomain4.Contains("=") Then
                        strDisplay4 = strDomain4.Substring(0, strDomain4.IndexOf("="))
                        If strDomain4.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain4.Text = strDisplay4
                            My.Forms.frmServerToolMain.chkDomain4.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain4.Text = strDisplay4
                            My.Forms.frmServerToolMain.chkDomain4.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain4, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(5).Contains("Not Available") Then
                    strDisplay5 = ""
                Else
                    strDomain5 = strDnsRawData(5).ToString()
                    If strDomain5.Contains("=") Then
                        strDisplay5 = strDomain5.Substring(0, strDomain5.IndexOf("="))
                        If strDomain5.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain5.Text = strDisplay5
                            My.Forms.frmServerToolMain.chkDomain5.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain5.Text = strDisplay5
                            My.Forms.frmServerToolMain.chkDomain5.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain5, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(6).Contains("Not Available") Then
                    strDisplay6 = ""
                Else
                    strDomain6 = strDnsRawData(6).ToString()
                    If strDomain6.Contains("=") Then
                        strDisplay6 = strDomain6.Substring(0, strDomain6.IndexOf("="))
                        If strDomain6.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain6.Text = strDisplay6
                            My.Forms.frmServerToolMain.chkDomain6.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain6.Text = strDisplay6
                            My.Forms.frmServerToolMain.chkDomain6.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain6, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(7).Contains("Not Available") Then
                    strDisplay7 = ""
                Else
                    strDomain7 = strDnsRawData(7).ToString()
                    If strDomain7.Contains("=") Then
                        strDisplay7 = strDomain7.Substring(0, strDomain7.IndexOf("="))
                        If strDomain7.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain7.Text = strDisplay7
                            My.Forms.frmServerToolMain.chkDomain7.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain7.Text = strDisplay7
                            My.Forms.frmServerToolMain.chkDomain7.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain7, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(8).Contains("Not Available") Then
                    strDisplay8 = ""
                Else
                    strDomain8 = strDnsRawData(8).ToString()
                    If strDomain8.Contains("=") Then
                        strDisplay8 = strDomain8.Substring(0, strDomain8.IndexOf("="))
                        If strDomain8.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain8.Text = strDisplay8
                            My.Forms.frmServerToolMain.chkDomain8.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain8.Text = strDisplay8
                            My.Forms.frmServerToolMain.chkDomain8.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain8, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(9).Contains("Not Available") Then
                    strDisplay9 = ""
                Else
                    strDomain9 = strDnsRawData(9).ToString()
                    If strDomain9.Contains("=") Then
                        strDisplay9 = strDomain9.Substring(0, strDomain9.IndexOf("="))
                        If strDomain9.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain9.Text = strDisplay9
                            My.Forms.frmServerToolMain.chkDomain9.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain9.Text = strDisplay9
                            My.Forms.frmServerToolMain.chkDomain9.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain9, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(10).Contains("Not Available") Then
                    strDisplay10 = ""
                Else
                    strDomain10 = strDnsRawData(10).ToString()
                    If strDomain10.Contains("=") Then
                        strDisplay10 = strDomain10.Substring(0, strDomain10.IndexOf("="))
                        If strDomain10.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain10.Text = strDisplay10
                            My.Forms.frmServerToolMain.chkDomain10.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain10.Text = strDisplay10
                            My.Forms.frmServerToolMain.chkDomain10.Enabled = False
                        End If
                    ElseIf Operators.CompareString(strDomain10, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(11).Contains("Not Available") Then
                    strDisplay11 = ""
                Else
                    strDomain11 = strDnsRawData(11).ToString()
                    If strDomain11.Contains("=") Then
                        strDisplay11 = strDomain11.Substring(0, strDomain11.IndexOf("="))
                        If strDomain11.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain11.Text = strDisplay11
                            My.Forms.frmServerToolMain.chkDomain11.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain11.Text = strDisplay11
                            My.Forms.frmServerToolMain.chkDomain11.Enabled = False
                        End If
                    ElseIf Operators.CompareString(strDomain11, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(12).Contains("Not Available") Then
                    strDisplay12 = ""
                Else
                    strDomain12 = strDnsRawData(12).ToString()
                    If strDomain12.Contains("=") Then
                        strDisplay12 = strDomain12.Substring(0, strDomain12.IndexOf("="))
                        If strDomain12.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain12.Text = strDisplay12
                            My.Forms.frmServerToolMain.chkDomain12.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain12.Text = strDisplay12
                            My.Forms.frmServerToolMain.chkDomain12.Enabled = False
                        End If
                    ElseIf Operators.CompareString(strDomain12, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(13).Contains("Not Available") Then
                    strDisplay13 = ""
                Else
                    strDomain13 = strDnsRawData(13).ToString()
                    If strDomain13.Contains("=") Then
                        strDisplay13 = strDomain13.Substring(0, strDomain13.IndexOf("="))
                        If strDomain13.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain13.Text = strDisplay13
                            My.Forms.frmServerToolMain.chkDomain13.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain13.Text = strDisplay13
                            My.Forms.frmServerToolMain.chkDomain13.Enabled = False
                        End If
                    ElseIf Operators.CompareString(strDomain13, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(14).Contains("Not Available") Then
                    strDisplay14 = ""
                Else
                    strDomain14 = strDnsRawData(14).ToString()
                    If strDomain14.Contains("=") Then
                        strDisplay14 = strDomain14.Substring(0, strDomain14.IndexOf("="))
                        If strDomain14.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain14.Text = strDisplay14
                            My.Forms.frmServerToolMain.chkDomain14.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain14.Text = strDisplay14
                            My.Forms.frmServerToolMain.chkDomain14.Enabled = False
                        End If
                    ElseIf Operators.CompareString(strDomain14, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(15).Contains("Not Available") Then
                    strDisplay15 = ""
                Else
                    strDomain15 = strDnsRawData(15).ToString()
                    If strDomain15.Contains("=") Then
                        strDisplay15 = strDomain15.Substring(0, strDomain15.IndexOf("="))
                        If strDomain15.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain15.Text = strDisplay15
                            My.Forms.frmServerToolMain.chkDomain15.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain15.Text = strDisplay15
                            My.Forms.frmServerToolMain.chkDomain15.Enabled = False
                        End If
                    ElseIf Operators.CompareString(strDomain15, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(16).Contains("Not Available") Then
                    strDisplay16 = ""
                Else
                    strDomain16 = strDnsRawData(16).ToString()
                    If strDomain16.Contains("=") Then
                        strDisplay16 = strDomain16.Substring(0, strDomain16.IndexOf("="))
                        If strDomain16.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain16.Text = strDisplay16
                            My.Forms.frmServerToolMain.chkDomain16.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain16.Text = strDisplay16
                            My.Forms.frmServerToolMain.chkDomain16.Enabled = False
                        End If
                    ElseIf Operators.CompareString(strDomain16, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(17).Contains("Not Available") Then
                    strDisplay17 = ""
                Else
                    strDomain17 = strDnsRawData(17).ToString()
                    If strDomain17.Contains("=") Then
                        strDisplay17 = strDomain17.Substring(0, strDomain17.IndexOf("="))
                        If strDomain17.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain17.Text = strDisplay17
                            My.Forms.frmServerToolMain.chkDomain17.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain17.Text = strDisplay17
                            My.Forms.frmServerToolMain.chkDomain17.Enabled = False
                        End If
                    ElseIf Operators.CompareString(strDomain17, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(18).Contains("Not Available") Then
                    strDisplay18 = ""
                Else
                    strDomain18 = strDnsRawData(18).ToString()
                    If strDomain18.Contains("=") Then
                        strDisplay18 = strDomain18.Substring(0, strDomain18.IndexOf("="))
                        If strDomain18.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain18.Text = strDisplay18
                            My.Forms.frmServerToolMain.chkDomain18.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain18.Text = strDisplay18
                            My.Forms.frmServerToolMain.chkDomain18.Enabled = False
                        End If
                    ElseIf Operators.CompareString(strDomain18, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(19).Contains("Not Available") Then
                    strDisplay19 = ""
                Else
                    strDomain19 = strDnsRawData(19).ToString()
                    If strDomain19.Contains("=") Then
                        strDisplay19 = strDomain19.Substring(0, strDomain19.IndexOf("="))
                        If strDomain19.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain19.Text = strDisplay19
                            My.Forms.frmServerToolMain.chkDomain19.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain19.Text = strDisplay19
                            My.Forms.frmServerToolMain.chkDomain19.Enabled = False
                        End If
                    ElseIf Operators.CompareString(strDomain19, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
            End If
            If intAccount > 0 Then
                If strDnsRawData(0).Contains("Not Available") Then
                    strDisplay0 = ""
                Else
                    strDomain0 = strDnsRawData(0).ToString()
                    If strDomain0.Contains("=") Then
                        strDisplay0 = strDomain0.Substring(0, strDomain0.IndexOf("="))
                        If strDomain0.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain0.Text = strDisplay0
                            My.Forms.frmServerToolMain.chkDomain0.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain0.Text = strDisplay0
                            My.Forms.frmServerToolMain.chkDomain0.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain0, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(1).Contains("Not Available") Then
                    strDisplay1 = ""
                Else
                    strDomain1 = strDnsRawData(1).ToString()
                    If strDomain1.Contains("=") Then
                        strDisplay1 = strDomain1.Substring(0, strDomain1.IndexOf("="))
                        If strDomain1.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain1.Text = strDisplay1
                            My.Forms.frmServerToolMain.chkDomain1.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain1.Text = strDisplay1
                            My.Forms.frmServerToolMain.chkDomain1.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain1, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(2).Contains("Not Available") Then
                    strDisplay2 = ""
                Else
                    strDomain2 = strDnsRawData(2).ToString()
                    If strDomain2.Contains("=") Then
                        strDisplay2 = strDomain2.Substring(0, strDomain2.IndexOf("="))
                        If strDomain2.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain2.Text = strDisplay2
                            My.Forms.frmServerToolMain.chkDomain2.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain2.Text = strDisplay2
                            My.Forms.frmServerToolMain.chkDomain2.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain2, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(3).Contains("Not Available") Then
                    strDisplay3 = ""
                Else
                    strDomain3 = strDnsRawData(3).ToString()
                    If strDomain3.Contains("=") Then
                        strDisplay3 = strDomain3.Substring(0, strDomain3.IndexOf("="))
                        If strDomain3.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain3.Text = strDisplay3
                            My.Forms.frmServerToolMain.chkDomain3.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain3.Text = strDisplay3
                            My.Forms.frmServerToolMain.chkDomain3.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain3, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(4).Contains("Not Available") Then
                    strDisplay4 = ""
                Else
                    strDomain4 = strDnsRawData(4).ToString()
                    If strDomain4.Contains("=") Then
                        strDisplay4 = strDomain4.Substring(0, strDomain4.IndexOf("="))
                        If strDomain4.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain4.Text = strDisplay4
                            My.Forms.frmServerToolMain.chkDomain4.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain4.Text = strDisplay4
                            My.Forms.frmServerToolMain.chkDomain4.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain4, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(5).Contains("Not Available") Then
                    strDisplay5 = ""
                Else
                    strDomain5 = strDnsRawData(5).ToString()
                    If strDomain5.Contains("=") Then
                        strDisplay5 = strDomain5.Substring(0, strDomain5.IndexOf("="))
                        If strDomain5.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain5.Text = strDisplay5
                            My.Forms.frmServerToolMain.chkDomain5.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain5.Text = strDisplay5
                            My.Forms.frmServerToolMain.chkDomain5.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain5, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(6).Contains("Not Available") Then
                    strDisplay6 = ""
                Else
                    strDomain6 = strDnsRawData(6).ToString()
                    If strDomain6.Contains("=") Then
                        strDisplay6 = strDomain6.Substring(0, strDomain6.IndexOf("="))
                        If strDomain6.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain6.Text = strDisplay6
                            My.Forms.frmServerToolMain.chkDomain6.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain6.Text = strDisplay6
                            My.Forms.frmServerToolMain.chkDomain6.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain6, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(7).Contains("Not Available") Then
                    strDisplay7 = ""
                Else
                    strDomain7 = strDnsRawData(7).ToString()
                    If strDomain7.Contains("=") Then
                        strDisplay7 = strDomain7.Substring(0, strDomain7.IndexOf("="))
                        If strDomain7.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain7.Text = strDisplay7
                            My.Forms.frmServerToolMain.chkDomain7.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain7.Text = strDisplay7
                            My.Forms.frmServerToolMain.chkDomain7.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain7, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(8).Contains("Not Available") Then
                    strDisplay8 = ""
                Else
                    strDomain8 = strDnsRawData(8).ToString()
                    If strDomain8.Contains("=") Then
                        strDisplay8 = strDomain8.Substring(0, strDomain8.IndexOf("="))
                        If strDomain8.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain8.Text = strDisplay8
                            My.Forms.frmServerToolMain.chkDomain8.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain8.Text = strDisplay8
                            My.Forms.frmServerToolMain.chkDomain8.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain8, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(9).Contains("Not Available") Then
                    strDisplay9 = ""
                Else
                    strDomain9 = strDnsRawData(9).ToString()
                    If strDomain9.Contains("=") Then
                        strDisplay9 = strDomain9.Substring(0, strDomain9.IndexOf("="))
                        If strDomain9.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain9.Text = strDisplay9
                            My.Forms.frmServerToolMain.chkDomain9.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain9.Text = strDisplay9
                            My.Forms.frmServerToolMain.chkDomain9.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain9, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(10).Contains("Not Available") Then
                    strDisplay10 = ""
                Else
                    strDomain10 = strDnsRawData(10).ToString()
                    If strDomain10.Contains("=") Then
                        strDisplay10 = strDomain10.Substring(0, strDomain10.IndexOf("="))
                        If strDomain10.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain10.Text = strDisplay10
                            My.Forms.frmServerToolMain.chkDomain10.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain10.Text = strDisplay10
                            My.Forms.frmServerToolMain.chkDomain10.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain10, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(11).Contains("Not Available") Then
                    strDisplay11 = ""
                Else
                    strDomain11 = strDnsRawData(11).ToString()
                    If strDomain11.Contains("=") Then
                        strDisplay11 = strDomain11.Substring(0, strDomain11.IndexOf("="))
                        If strDomain11.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain11.Text = strDisplay11
                            My.Forms.frmServerToolMain.chkDomain11.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain11.Text = strDisplay11
                            My.Forms.frmServerToolMain.chkDomain11.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain11, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(12).Contains("Not Available") Then
                    strDisplay12 = ""
                Else
                    strDomain12 = strDnsRawData(12).ToString()
                    If strDomain12.Contains("=") Then
                        strDisplay12 = strDomain12.Substring(0, strDomain12.IndexOf("="))
                        If strDomain12.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain12.Text = strDisplay12
                            My.Forms.frmServerToolMain.chkDomain12.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain12.Text = strDisplay12
                            My.Forms.frmServerToolMain.chkDomain12.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain12, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(13).Contains("Not Available") Then
                    strDisplay13 = ""
                Else
                    strDomain13 = strDnsRawData(13).ToString()
                    If strDomain13.Contains("=") Then
                        strDisplay13 = strDomain13.Substring(0, strDomain13.IndexOf("="))
                        If strDomain13.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain13.Text = strDisplay13
                            My.Forms.frmServerToolMain.chkDomain13.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain13.Text = strDisplay13
                            My.Forms.frmServerToolMain.chkDomain13.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain13, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(14).Contains("Not Available") Then
                    strDisplay14 = ""
                Else
                    strDomain14 = strDnsRawData(14).ToString()
                    If strDomain14.Contains("=") Then
                        strDisplay14 = strDomain14.Substring(0, strDomain14.IndexOf("="))
                        If strDomain14.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain14.Text = strDisplay14
                            My.Forms.frmServerToolMain.chkDomain14.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain14.Text = strDisplay14
                            My.Forms.frmServerToolMain.chkDomain14.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain14, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(15).Contains("Not Available") Then
                    strDisplay15 = ""
                Else
                    strDomain15 = strDnsRawData(15).ToString()
                    If strDomain15.Contains("=") Then
                        strDisplay15 = strDomain15.Substring(0, strDomain15.IndexOf("="))
                        If strDomain15.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain15.Text = strDisplay15
                            My.Forms.frmServerToolMain.chkDomain15.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain15.Text = strDisplay15
                            My.Forms.frmServerToolMain.chkDomain15.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain15, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(16).Contains("Not Available") Then
                    strDisplay16 = ""
                Else
                    strDomain16 = strDnsRawData(16).ToString()
                    If strDomain16.Contains("=") Then
                        strDisplay16 = strDomain16.Substring(0, strDomain16.IndexOf("="))
                        If strDomain16.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain16.Text = strDisplay16
                            My.Forms.frmServerToolMain.chkDomain16.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain16.Text = strDisplay16
                            My.Forms.frmServerToolMain.chkDomain16.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain16, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(17).Contains("Not Available") Then
                    strDisplay17 = ""
                Else
                    strDomain17 = strDnsRawData(17).ToString()
                    If strDomain17.Contains("=") Then
                        strDisplay17 = strDomain17.Substring(0, strDomain17.IndexOf("="))
                        If strDomain17.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain17.Text = strDisplay17
                            My.Forms.frmServerToolMain.chkDomain17.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain17.Text = strDisplay17
                            My.Forms.frmServerToolMain.chkDomain17.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain17, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(18).Contains("Not Available") Then
                    strDisplay18 = ""
                Else
                    strDomain18 = strDnsRawData(18).ToString()
                    If strDomain18.Contains("=") Then
                        strDisplay18 = strDomain18.Substring(0, strDomain18.IndexOf("="))
                        If strDomain18.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain18.Text = strDisplay18
                            My.Forms.frmServerToolMain.chkDomain18.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain18.Text = strDisplay18
                            My.Forms.frmServerToolMain.chkDomain18.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain18, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
                If strDnsRawData(19).Contains("Not Available") Then
                    strDisplay19 = ""
                Else
                    strDomain19 = strDnsRawData(19).ToString()
                    If strDomain19.Contains("=") Then
                        strDisplay19 = strDomain19.Substring(0, strDomain19.IndexOf("="))
                        If strDomain19.Contains("NORESPONSE") Then
                            My.Forms.frmServerToolMain.chkDomain19.Text = strDisplay19
                            My.Forms.frmServerToolMain.chkDomain19.Enabled = False
                        Else
                            My.Forms.frmServerToolMain.chkDomain19.Text = strDisplay19
                            My.Forms.frmServerToolMain.chkDomain19.Enabled = True
                        End If
                    ElseIf Operators.CompareString(strDomain19, "", False) <> 0 Then
                        intErrorMessage = 9
                        ErrorMessage()
                        intErrorMessage = 0
                    End If
                End If
            End If
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub IPAddress()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        Try
            strExternalIP = New WebClient().DownloadString("https://www.l2.io/ip")
            strExternalIP = New Regex("\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}").Matches(strExternalIP)(0).ToString()
            My.Forms.frmServerToolMain.mnuIpDisplay.Image = My.Resources.online
            My.Forms.frmServerToolMain.mnuIpDisplay.Text = strExternalIP
        Catch exIPAddress As Exception
            Dim exErrorData As Exception = exIPAddress
            My.Forms.frmServerToolMain.mnuIpDisplay.Image = My.Resources.offline
            My.Forms.frmServerToolMain.mnuIpDisplay.Text = "Not Available"
            strDiagnostics14 = exErrorData.Message
            DiagnosticsLoad()
            If (strExternalIP = String.Empty) = True Then
                IPAddressBackup()
            End If
        End Try
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub IPAddressBackup()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        Try
            strExternalIP = New WebClient().DownloadString("http://checkip.amazonaws.com/")
            strExternalIP = New Regex("\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}").Matches(strExternalIP)(0).ToString()
            My.Forms.frmServerToolMain.mnuIpDisplay.Image = My.Resources.online
            My.Forms.frmServerToolMain.mnuIpDisplay.Text = strExternalIP
        Catch exIPAddress As Exception
            Dim exErrorData As Exception = exIPAddress
            intErrorMessage = 11
            ErrorMessage()
            intErrorMessage = 0
            My.Forms.frmServerToolMain.mnuIpDisplay.Image = My.Resources.offline
            My.Forms.frmServerToolMain.mnuIpDisplay.Text = "Not Available"
            strDiagnostics14 = exErrorData.Message
            DiagnosticsLoad()
        End Try
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub Open()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(41, 128, 185)
        If My.Forms.frmServerToolMain.ofdServerTool.ShowDialog() = DialogResult.OK Then
            If Not strFile.Contains("tsdns_settings.ini") Then
                intErrorMessage = 12
                ErrorMessage()
                intErrorMessage = 0
            Else
                strFile = My.Forms.frmServerToolMain.ofdServerTool.FileName
                Startup()
            End If
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub Reload()
        If Not File.Exists(strFile) Then
            intErrorMessage = 13
            ErrorMessage()
            intErrorMessage = 0
            Return
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        intMessageError = 3
        CreateSettings()
        CleanStartUp()
        TimeChange()
        StartTray()
        FileLocation()
        Loadup()
        Startup()
        Message()
        ServiceRun()
        ButtonCheck()
        UpdateMessage()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub RunAdmin()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        If Not My.User.IsInRole(BuiltInRole.Administrator) Then
            procRunAdmin = New ProcessStartInfo()
            procRunAdmin.UseShellExecute = True
            procRunAdmin.WorkingDirectory = Environment.CurrentDirectory
            procRunAdmin.FileName = Application.ExecutablePath
            procRunAdmin.Verb = "runas"
            Try
                Process.Start(procRunAdmin)
            Catch exAdmin As Exception
                Dim exErrorData As Exception = exAdmin
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
                strDiagnostics15 = exErrorData.Message
                DiagnosticsLoad()
                Return
            End Try
            My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            Application.[Exit]()
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub

    Public Sub DiagnosticsLoad()
        If intDiagnosticsClick = 1 Then
            My.Forms.frmServerToolMain.mnuErrorMessageControl.Text = "Disable &Diagnostics"
            blnErrorMessage = True
        Else
            blnErrorMessage = False
        End If
        If intDiagnosticsClick = 2 Then
            My.Forms.frmServerToolMain.mnuErrorMessageControl.Text = "Enable &Diagnostics"
            intDiagnosticsClick = 0
        End If
        If blnErrorMessage Then
            If Operators.CompareString(strDiagnostics0, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics0
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics0, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics1, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics1
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics1, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics2, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics2
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics2, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics3, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics3
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics3, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics4, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics4
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics4, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics5, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics5
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics5, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics6, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics6
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics6, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics7, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics7
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics7, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics8, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics8
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics8, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics9, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics9
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics9, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics10, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics10
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics10, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics11, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics11
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics11, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics12, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics12
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics12, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics13, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics13
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics13, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics14, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics14
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics14, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics15, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics15
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics15, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics16, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics16
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics16, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics17, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics17
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics17, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics18, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics18
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics18, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics19, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics19
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics19, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics20, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics20
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics20, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            If Operators.CompareString(strDiagnostics21, String.Empty, False) <> 0 Then
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipIcon = ToolTipIcon.[Error]
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipTitle = "xKiller Teamspeak Assistant Tool - Diagnostics Message"
                My.Forms.frmServerToolMain.nicServerTool.BalloonTipText = strDiagnostics20
                My.Forms.frmServerToolMain.nicServerTool.ShowBalloonTip(50000)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(210, 82, 127)
                MessageBox.Show(strDiagnostics21, "Diagnostics Message", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
            End If
            strDiagnostics0 = String.Empty
            strDiagnostics1 = String.Empty
            strDiagnostics2 = String.Empty
            strDiagnostics3 = String.Empty
            strDiagnostics4 = String.Empty
            strDiagnostics5 = String.Empty
            strDiagnostics6 = String.Empty
            strDiagnostics7 = String.Empty
            strDiagnostics8 = String.Empty
            strDiagnostics9 = String.Empty
            strDiagnostics10 = String.Empty
            strDiagnostics11 = String.Empty
            strDiagnostics12 = String.Empty
            strDiagnostics13 = String.Empty
            strDiagnostics14 = String.Empty
            strDiagnostics15 = String.Empty
            strDiagnostics16 = String.Empty
            strDiagnostics17 = String.Empty
            strDiagnostics18 = String.Empty
            strDiagnostics19 = String.Empty
            strDiagnostics20 = String.Empty
            strDiagnostics21 = String.Empty
        End If
    End Sub

    Public Sub ProcessExited(sender As Object, e As EventArgs)
        procExecuting.Close()
    End Sub
End Module