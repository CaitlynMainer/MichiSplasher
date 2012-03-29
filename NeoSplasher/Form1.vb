Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System
Imports System.Net
Imports System.Text
Imports System.Environment
Imports Microsoft.Win32

Public Class Form1

    Private m_bmp As System.Drawing.Bitmap
    Dim cohpath As String
    Private Sub AppendByteToDisk(ByVal FilepathToAppendTo As String, ByRef Content() As Byte)
        Dim s As New System.IO.FileStream(FilepathToAppendTo, System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.ReadWrite)
        s.Write(Content, 0, Content.Length)
        s.Close()
    End Sub

    Public Shared Function StrToByteArray(ByVal str As String) As Byte()
        Dim encoding As New System.Text.UTF8Encoding()
        Return encoding.GetBytes(str)
    End Function 'StrToByteArray

    Private Sub mnuFileOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileOpen.Click
        Dim ofd As New System.Windows.Forms.OpenFileDialog()
        ofd.Filter = "All Image Files(*.BMP;*.CUT;*.DCX;*.DDS;*.ICO;*.GIF;*.JPG;*.LBM;*.LIF;*.MDL;*.PCD;*.PCX;*.PIC;*.PNG;*.PNM;*.PSD;*.PSP;*.RAW;*.SGI;*.TGA;*.TIF;*.WAL;*.ACT;*.PAL;)|*.BMP;*.CUT;*.DCX;*.DDS;*.ICO;*.GIF;*.JPG;*.LBM;*.LIF;*.MDL;*.PCD;*.PCX;*.PIC;*.PNG;*.PNM;*.PSD;*.PSP;*.RAW;*.SGI;*.TGA;*.TIF;*.WAL;*.ACT;*.PAL|All files (*.*)|*.*"
        ofd.Filter += "|BMP files (*.BMP)|*.BMP"
        ofd.Filter += "|CUT files (*.CUT)|*.CUT"
        ofd.Filter += "|DCX files (*.DCX)|*.DCX"
        ofd.Filter += "|DDS files (*.DDS)|*.DDS"
        ofd.Filter += "|ICO files (*.ICO)|*.ICO"
        ofd.Filter += "|GIF files (*.GIF)|*.GIF"
        ofd.Filter += "|JPG files (*.JPG)|*.JPG"
        ofd.Filter += "|LBM files (*.LBM)|*.LBM"
        ofd.Filter += "|LIF files (*.LIF)|*.LIF"
        ofd.Filter += "|MDL files (*.MDL)|*.MDL"
        ofd.Filter += "|PCD files (*.PCD)|*.PCD"
        ofd.Filter += "|PCX files (*.PCX)|*.PCX"
        ofd.Filter += "|PIC files (*.PIC)|*.PIC"
        ofd.Filter += "|PNG files (*.PNG)|*.PNG"
        ofd.Filter += "|PNM files (*.PNM)|*.PNM"
        ofd.Filter += "|PSD files (*.PSD)|*.PSD"
        ofd.Filter += "|PSP files (*.PSP)|*.PSP"
        ofd.Filter += "|RAW files (*.RAW)|*.RAW"
        ofd.Filter += "|SGI files (*.SGI)|*.SGI"
        ofd.Filter += "|TGA files (*.TGA)|*.TGA"
        ofd.Filter += "|TIF files (*.TIF)|*.TIF"
        ofd.Filter += "|WAL files (*.WAL)|*.WAL"
        ofd.Filter += "|ACT files (*.ACT)|*.ACT"
        ofd.Filter += "|PAL files (*.PAL)|*.PAL"
        ofd.Filter += "|All files (*.*)|*.*"

        If (ofd.ShowDialog() = DialogResult.OK) Then
            m_bmp = DevIL.DevIL.LoadBitmap(ofd.FileName)

            Dim original As Image = m_bmp
            Dim resized As Image = ResizeImage(original, New Size(1024, 1024), False)

            Dim resized_small As Image = ResizeImage(original, New Size(256, 256), False)

            Dim memStream As MemoryStream = New MemoryStream()
            resized.Save(memStream, ImageFormat.Bmp)
            m_bmp = resized
            If Not (m_bmp Is Nothing) Then
                pictureBox.Image = resized_small
                Button2.Visible = True
            End If
        End If
    End Sub


    Private Sub mnuFileSaveAs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        Me.Close()
    End Sub

    Private Sub mnuHelpAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelpAbout.Click
        'MessageBox.Show("Program by Marco Mastropaolo\n\nThis is a VB.NET example for the DevIL.NET library.\n\nhttp://www.mastropaolo.com", "About")
    End Sub

    Private Sub frmImageView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button2.Visible = False
        cohpath = GetRegValue(RegistryHive.CurrentUser, "SOFTWARE\Cryptic\CoH\", "Installation Directory")
        If cohpath = "" Then
            cohpath = GetRegValue(RegistryHive.CurrentUser, "SOFTWARE\Cryptic\EUCoH\", "Installation Directory")
        End If
        TextBox1.Text = cohpath
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If File.Exists(System.Environment.CurrentDirectory & "\temp\output.png") Then
            File.Delete(System.Environment.CurrentDirectory & "\temp\output.png")
        End If

        If File.Exists(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds") Then
            File.Delete(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds")
        End If

        DevIL.DevIL.SaveBitmap(System.Environment.CurrentDirectory & "\temp\output.png", m_bmp)
        Dim proc As Process = New Process
        'System.IO.File.Create(System.Environment.CurrentDirectory & "/COH_LogInScreen_Background_temp.dds")
        proc.StartInfo.FileName = System.Environment.CurrentDirectory & "/nvcompress.exe"
        proc.StartInfo.Arguments() = "-rgb ""temp\output.png"" ""temp\COH_LogInScreen_Background_temp.dds"""
        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        proc.Start()
        proc.WaitForExit()
        'TextBox1.Text = ("-rgb " & System.Environment.CurrentDirectory & "/output.png " & System.Environment.CurrentDirectory & "/COH_LogInScreen_Background_temp.dds")
        If Not Directory.Exists(TextBox1.Text & "\data\texture_library\GUI\CREATION\HybridUI\LoginScreen\") Then
            Directory.CreateDirectory(TextBox1.Text & "\data\texture_library\GUI\CREATION\HybridUI\LoginScreen\")
        End If

        MergeFiles(TextBox1.Text & "\data\texture_library\GUI\CREATION\HybridUI\LoginScreen\COH_LogInScreen_Background.texture", System.Environment.CurrentDirectory & "/headers/COH_LogInScreen_Background.header", System.Environment.CurrentDirectory & "/temp/COH_LogInScreen_Background_temp.dds")

        If File.Exists(System.Environment.CurrentDirectory & "\temp\output.png") Then
            File.Delete(System.Environment.CurrentDirectory & "\temp\output.png")
        End If

        If File.Exists(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds") Then
            File.Delete(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds")
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog

        ' Descriptive text displayed above the tree view control in the dialog box
        MyFolderBrowser.Description = "Select the Folder"

        ' Sets the root folder where the browsing starts from
        'MyFolderBrowser.RootFolder = Environment.SpecialFolder.MyDocuments

        ' Do not show the button for new folder
        MyFolderBrowser.ShowNewFolderButton = False

        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()

        If dlgResult = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = MyFolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub mnuHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuHelp.Click

    End Sub
End Class
