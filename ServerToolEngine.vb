Imports System.IO
Imports System.Net
Imports System.Runtime.CompilerServices
Imports System.ServiceProcess
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Microsoft.VisualBasic.ApplicationServices
Imports Microsoft.VisualBasic.CompilerServices
Module ServerToolEngine
    Public strExternalIP, strFile, strSettingsStartInTray, strStartInTray, strServiceName, strChecked, strTimeCheck, strServiceCheck, strProcessName, strFileSettings, strCheckedDomain, strDomain0, strDomain1, strDomain2, strDomain3, strDomain4, strDomain5, strDomain6, strDomain7, strDomain8, strDomain9, strDomain10, strDomain11, strDomain12, strDomain13, strDomain14, strDomain15, strDomain16, strDomain17, strDomain18, strDomain19, strDisplay0, strDisplay1, strDisplay2, strDisplay3, strDisplay4, strDisplay5, strDisplay6, strDisplay7, strDisplay8, strDisplay9, strDisplay10, strDisplay11, strDisplay12, strDisplay13, strDisplay14, strDisplay15, strDisplay16, strDisplay17, strDisplay18, strDisplay19, strReload, strUsername, strPassword, strSettingsUsername, strSettingsPassword, strSettingsTime, strSettingsFileLocation, strSettingsChecked, strSettingsAccess, strSettingsService, strSettingsProcess, strRawData, strDiagnostics0, strDiagnostics1, strDiagnostics2, strDiagnostics3, strDiagnostics4, strDiagnostics5, strDiagnostics6, strDiagnostics7, strDiagnostics8, strDiagnostics9, strDiagnostics10, strDiagnostics11, strDiagnostics12, strDiagnostics13, strDiagnostics14, strDiagnostics15, strDiagnostics20 As String
    Public intDomain, intOnlineTest0, intOnlineTest1, intOnlineSpammerTest, intRestartErrorCheck, intTimerFixService, intDiagnosticsClick, intStartTray, intAccount, intVisable, intTime, intDownX, intDownY, intUserTime, intCheckSP, intFixTime, intVideo, intGoogle, intRestart, intStop, intStart, intSettings, intControl, intError, intMessageError, intErrorCountStartUp, intExternalError, intStartUp, intErrorMessage, intErrorCount1, intErrorCount2, intErrorCount3, intErrorCount4, intErrorCount5, intErrorCount6, intErrorCount7, intErrorCount8, intErrorCount9, intErrorCount10, intErrorCount11, intErrorCount12, intErrorCount13, intErrorCount14, intErrorCount15, intErrorCount16, intErrorCount17, intErrorCount18, intErrorCount19, intErrorCount20, intErrorCount21, intErrorCount22, intErrorCount23, intErrorCount24, intErrorCount25, intErrorCount26, intErrorCount27, intErrorCount28, intErrorCount29, intErrorCount30, intErrorCount31, intErrorCount32, intErrorCount33, intErrorCount34, intErrorCount35, intErrorCount36, intErrorCount37, intErrorCount38, intErrorCount39, intErrorCount40, intErrorCount41, intErrorCount42, intErrorCount43, intErrorCount44, intErrorCount45, intErrorCount46, intErrorCount47, intErrorCount48, intErrorCount49 As Integer
    Public strDnsRawData As String()
    Public strSettingsRawData As String()
    Public procExecuting As Process
    Public procRunAdmin As ProcessStartInfo
    Public blnDragged As Boolean
    Public blnErrorMessage As Boolean
    Public strVersion, strDiagnostics16, strDiagnostics17, strDiagnostics18, strDiagnostics19, strDiagnostics21, strMnuIpDisplay As String
    Public Sub CheckConnection()
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(142, 68, 173)
        strMnuIpDisplay = My.Forms.frmServerToolMain.mnuIpDisplay.Text
        If (strMnuIpDisplay.Contains(".") Or strMnuIpDisplay.Contains(":")) = False Then
            intOnlineTest0 = 0
            intOnlineTest1 = 0
        Else
            If (strExternalIP = String.Empty) = False Then
                intOnlineTest0 = 1
                intOnlineSpammerTest = +1
            Else
                intOnlineTest0 = 0
            End If
            If My.Computer.Network.Ping("engine.xkillerclan.com") = True Then
                intOnlineTest1 = 1
                intOnlineSpammerTest = +1
            Else
                intOnlineTest1 = 0
            End If
        End If
        My.Forms.frmServerToolMain.stbServerTool.BackColor = Color.FromArgb(39, 174, 96)
    End Sub


End Module