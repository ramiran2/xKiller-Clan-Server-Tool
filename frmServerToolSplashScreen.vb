Public Class frmServerToolSplashScreen

    'TODO: This form can easily be set as the splash screen for the application by going to the "Application" tab
    '  of the Project Designer ("Properties" under the "Project" menu).


    Private Sub frmServerToolSplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Fixes a bug where lables dont go Transparent.
        lblCopyright.Parent = picSplashScreen
        lblCopyright.BackColor = Color.Transparent
        lblCopyright.ForeColor = Color.White
        lblCopyright.BringToFront()
        lblCopyright.Location = New Point(260, 330)
        lblTitle.Parent = picSplashScreen
        lblTitle.BackColor = Color.Transparent
        lblTitle.ForeColor = Color.White
        lblTitle.BringToFront()
        lblTitle.Location = New Point(180, 9)
        lblVersion.Parent = picSplashScreen
        lblVersion.BackColor = Color.Transparent
        lblVersion.ForeColor = Color.White
        lblVersion.BringToFront()
        lblVersion.Location = New Point(12, 330)
        lblStatus.Parent = picSplashScreen
        lblStatus.BackColor = Color.Transparent
        lblStatus.ForeColor = Color.White
        lblStatus.BringToFront()
        lblStatus.Location = New Point(565, 330)

        'Set up the dialog text at runtime according to the application's assembly information.  

        'TODO: Customize the application's assembly information in the "Application" pane of the project 
        '  properties dialog (under the "Project" menu).

        'Application title
        If My.Application.Info.Title <> "" Then
            lblTitle.Text = My.Application.Info.Title
        Else
            'If the application title is missing, use the application name, without the extension
            lblTitle.Text = IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Format the version information using the text set into the Version control at design time as the
        '  formatting string.  This allows for effective localization if desired.
        '  Build and revision information could be included by using the following code and changing the 
        '  Version control's designtime text to "Version {0}.{1:00}.{2}.{3}" or something similar.  See
        '  String.Format() in Help for more information.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        lblVersion.Text = String.Format(lblVersion.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Copyright info
        lblCopyright.Text = My.Application.Info.Copyright
    End Sub
End Class