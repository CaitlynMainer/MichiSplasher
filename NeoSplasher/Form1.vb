Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System
Imports System.Threading
Imports System.Net
Imports System.Text
Imports System.Environment
Imports Microsoft.Win32

Public Class Form1

    Private m_bmp As Bitmap
    Dim original As Image
    Dim cohpath As String
    Dim gamelocale As String
    Dim url As String = "http://pc-logix.com/neosplasher/"
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not Directory.Exists(System.Environment.CurrentDirectory & "\temp") Then
            Directory.CreateDirectory(System.Environment.CurrentDirectory & "\temp")
        End If
        ComboBox1.SelectedItem = "US"
        DownloadFile(url & "md5.xml", CurDir() & "/md5.xml")
        Dim ver As String = "0.2.2"
        Me.Text = "NeoSplasher Version: " & ver
        Dim updaterversion As String = LoadSiteContent(url & "version.ini")
        If updaterversion > ver Then
            MsgBox("Now Updating to " & updaterversion)
            DownloadFile(url & "neosplasher.exe", System.Environment.CurrentDirectory & "\neosplasher.updater")
            File.Move(System.Environment.CurrentDirectory & "\neosplasher.exe", System.Environment.CurrentDirectory & "\neosplasher.old")
            File.Move(System.Environment.CurrentDirectory & "\neosplasher.updater", System.Environment.CurrentDirectory & "\neosplasher.exe")
            Process.Start(System.Environment.CurrentDirectory & "\neosplasher.exe")
            Thread.Sleep(2000)
            Me.Close()
        End If


        cohpath = GetRegValue(RegistryHive.CurrentUser, "SOFTWARE\Cryptic\CoH\", "Installation Directory")
        If cohpath = "" Then
            cohpath = GetRegValue(RegistryHive.CurrentUser, "SOFTWARE\Cryptic\EUCoH\", "Installation Directory")
            gamelocale = GetRegValue(RegistryHive.CurrentUser, "SOFTWARE\Cryptic\EUCoH\", "locale")
            If gamelocale = "4147" Then
                ComboBox1.SelectedItem = "UK"
            ElseIf gamelocale = "4145" Then
                ComboBox1.SelectedItem = "DE"
            ElseIf gamelocale = "4150" Then
                ComboBox1.SelectedItem = "FR"
            End If
        End If

        If cohpath = "" Then
            MsgBox("Unable to find your City of Heroes install in your registry!")
            Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
            MyFolderBrowser.Description = "Select the Folder"
            MyFolderBrowser.ShowNewFolderButton = False
            Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()
            If dlgResult = Windows.Forms.DialogResult.OK Then
                TextBox1.Text = MyFolderBrowser.SelectedPath
            End If

        End If

        TextBox1.Text = cohpath

        Dim hashfail As String = 0
        Dim xmlDoc As New Xml.XmlDocument
        xmlDoc.Load(CurDir() & "\md5.xml")
        Dim nodes As Xml.XmlNodeList = xmlDoc.SelectNodes("/files/file")

        For Each n As Xml.XmlNode In nodes
            If Not IO.Directory.Exists(System.IO.Path.GetDirectoryName(CurDir() & "\" & n.ChildNodes(0).InnerText)) Then
                IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(CurDir() & "\" & n.ChildNodes(0).InnerText))
            End If

            If File.Exists(CurDir() & "\" & n.ChildNodes(0).InnerText) Then
                If MD5CalcFile(CurDir() & "\" & n.ChildNodes(0).InnerText) = n.ChildNodes(1).InnerText Then
                Else
                    Try
                        DownloadFile(url & n.ChildNodes(0).InnerText, CurDir() & "\" & n.ChildNodes(0).InnerText)
                        'MsgBox(row(0))
                    Catch ex As Exception
                        MessageBox.Show("Error: " & n.ChildNodes(0).InnerText & ex.Message)
                    End Try
                    hashfail = hashfail + 1
                End If

            Else

                Try
                    If Not Directory.Exists(Path.GetDirectoryName(CurDir() & "\" & n.ChildNodes(0).InnerText)) Then
                        Directory.CreateDirectory(Path.GetDirectoryName(CurDir() & "\" & n.ChildNodes(0).InnerText))
                    End If

                    DownloadFile(url & n.ChildNodes(0).InnerText, CurDir() & "\" & n.ChildNodes(0).InnerText)
                    'MsgBox(row(0))
                Catch ex As Exception
                    MessageBox.Show("Error: " & n.ChildNodes(0).InnerText & ex.Message)
                End Try
            End If
        Next

    End Sub

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

            If File.Exists(System.Environment.CurrentDirectory & "\temp\output.png") Then
                File.Delete(System.Environment.CurrentDirectory & "\temp\output.png")
            End If

            If File.Exists(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds") Then
                File.Delete(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds")
            End If

            m_bmp = DevIL.DevIL.LoadBitmap(ofd.FileName)

            original = m_bmp
            Dim resized As Image

            Dim memStream As MemoryStream = New MemoryStream()

            'm_bmp = resized

            imageresize()
            If Not (m_bmp Is Nothing) Then
                Button2.Visible = True
            End If
            CheckBox1.Visible = True
            CheckBox2.Visible = True
            CheckBox3.Visible = True
            CheckBox1.Checked = True
            CheckBox2.Checked = False
            Label1.Visible = True
            ComboBox1.Visible = True


            If Not original Is Nothing Then
                If Not (m_bmp Is Nothing) Then
                    pictureBox.Image = CropImage(imageresize(), New Size(1024, 768), New Point(0, 0))
                    Button2.Visible = True
                End If
                DevIL.DevIL.SaveBitmap(System.Environment.CurrentDirectory & "\temp\output.png", imageresize())
            End If
        End If

    End Sub

    Private Sub mnuFileExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuFileExit.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Label12.Text = "Working..."

        Dim proc As Process = New Process
        proc.StartInfo.FileName = System.Environment.CurrentDirectory & "/nvcompress.exe"
        proc.StartInfo.Arguments() = "-dxt1 -nomips ""temp\output.png"" ""temp\COH_LogInScreen_Background_temp.dds"""
        proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        proc.Start()
        proc.WaitForExit()

        If Not Directory.Exists(TextBox1.Text & "\data\texture_library\GUI\CREATION\HybridUI\LoginScreen\") Then
            Directory.CreateDirectory(TextBox1.Text & "\data\texture_library\GUI\CREATION\HybridUI\LoginScreen\")
        End If

        If ComboBox1.SelectedItem = "US" Then
            MergeFiles(TextBox1.Text & "\data\texture_library\GUI\CREATION\HybridUI\LoginScreen\COH_LogInScreen_Background.texture", System.Environment.CurrentDirectory & "/headers/COH_LogInScreen_Background.header", System.Environment.CurrentDirectory & "/temp/COH_LogInScreen_Background_temp.dds")
        ElseIf ComboBox1.SelectedItem = "EU" Then
            MergeFiles(TextBox1.Text & "\data\texture_library\GUI\CREATION\HybridUI\LoginScreen\COH_LogInScreen_Background_UK.texture", System.Environment.CurrentDirectory & "/headers/COH_LogInScreen_Background_UK.header", System.Environment.CurrentDirectory & "/temp/COH_LogInScreen_Background_temp.dds")
        ElseIf ComboBox1.SelectedItem = "FR" Then
            MergeFiles(TextBox1.Text & "\data\texture_library\GUI\CREATION\HybridUI\LoginScreen\COH_LogInScreen_Background_French.texture", System.Environment.CurrentDirectory & "/headers/COH_LogInScreen_Background_French.header", System.Environment.CurrentDirectory & "/temp/COH_LogInScreen_Background_temp.dds")
        ElseIf ComboBox1.SelectedItem = "DE" Then
            MergeFiles(TextBox1.Text & "\data\texture_library\GUI\CREATION\HybridUI\LoginScreen\COH_LogInScreen_Background_German.texture", System.Environment.CurrentDirectory & "/headers/COH_LogInScreen_Background_German.header", System.Environment.CurrentDirectory & "/temp/COH_LogInScreen_Background_temp.dds")
        End If

        If File.Exists(System.Environment.CurrentDirectory & "\temp\output.png") Then
            File.Delete(System.Environment.CurrentDirectory & "\temp\output.png")
        End If

        If File.Exists(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds") Then
            File.Delete(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds")
        End If
        Label12.Text = "Done!"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        Dim MyFolderBrowser As New System.Windows.Forms.FolderBrowserDialog
        MyFolderBrowser.Description = "Select the Folder"
        MyFolderBrowser.ShowNewFolderButton = False
        Dim dlgResult As DialogResult = MyFolderBrowser.ShowDialog()
        If dlgResult = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = MyFolderBrowser.SelectedPath
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        Try
            If File.Exists(System.Environment.CurrentDirectory & "\neosplasher.old") Then
                File.Delete(System.Environment.CurrentDirectory & "\neosplasher.old")
            End If
            If File.Exists(System.Environment.CurrentDirectory & "\neosplasher.updater") Then
                File.Delete(System.Environment.CurrentDirectory & "\neosplasher.updater")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Dim strFileSize As String = ""
        Dim FILE_NAME As String = CurDir() & "\md5.xml"

        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

        objWriter.Write("<?xml version=""1.0"" encoding=""ISO-8859-1""?>" & vbCrLf & "<files>" & vbCrLf)

        If System.IO.File.Exists(FILE_NAME) = True Then

            Dim di As New IO.DirectoryInfo(System.Environment.CurrentDirectory & "/headers")
            Dim aryFi As IO.FileInfo() = di.GetFiles("*.*")
            Dim fi As IO.FileInfo
            For Each fi In aryFi
                objWriter.Write("<file>" & vbCrLf & Chr(9) & "<filename>\headers\" & fi.Name & "</filename>" & vbCrLf & Chr(9) & "<md5>" & MD5CalcFile(System.Environment.CurrentDirectory & "\headers\" & fi.Name) & "</md5>" & vbCrLf & "</file>" & vbCrLf)
            Next

            Dim dioverlay As New IO.DirectoryInfo(System.Environment.CurrentDirectory & "/overlay")
            Dim aryFioverlay As IO.FileInfo() = dioverlay.GetFiles("*.*")
            Dim fioverlay As IO.FileInfo
            For Each fioverlay In aryFioverlay
                objWriter.Write("<file>" & vbCrLf & Chr(9) & "<filename>\overlay\" & fioverlay.Name & "</filename>" & vbCrLf & Chr(9) & "<md5>" & MD5CalcFile(System.Environment.CurrentDirectory & "\overlay\" & fioverlay.Name) & "</md5>" & vbCrLf & "</file>" & vbCrLf)
            Next

            Dim di2 As New IO.DirectoryInfo(System.Environment.CurrentDirectory & "/")
            Dim aryFi2 As IO.FileInfo() = di2.GetFiles("*.*")
            Dim fi2 As IO.FileInfo
            For Each fi2 In aryFi2
                If Not fi2.Name = "md5.xml" Then
                    objWriter.Write("<file>" & vbCrLf & Chr(9) & "<filename>\" & fi2.Name & "</filename>" & vbCrLf & Chr(9) & "<md5>" & MD5CalcFile(System.Environment.CurrentDirectory & "\" & fi2.Name) & "</md5>" & vbCrLf & "</file>" & vbCrLf)
                End If
            Next
        Else
        End If

        objWriter.Write("</files>")
        objWriter.Close()
        MsgBox("Text written to file")
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Process.Start("http://openil.sourceforge.net/license.php")
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Process.Start("http://www.mastropaolo.com/devildotnet/")
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Process.Start("http://code.google.com/p/nvidia-texture-tools/wiki/CommandLineTools")
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            imageresize()
            If CheckBox2.Checked = True Then
                overlayimage()
            End If
        Else
            If File.Exists(System.Environment.CurrentDirectory & "\temp\output.png") Then
                File.Delete(System.Environment.CurrentDirectory & "\temp\output.png")
            End If

            If File.Exists(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds") Then
                File.Delete(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds")
            End If
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked = True Then
            trimimage()
            If CheckBox2.Checked = True Then
                overlayimage()
            End If
        Else
            If File.Exists(System.Environment.CurrentDirectory & "\temp\output.png") Then
                File.Delete(System.Environment.CurrentDirectory & "\temp\output.png")
            End If

            If File.Exists(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds") Then
                File.Delete(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds")
            End If
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            overlayimage()
        Else

            If File.Exists(System.Environment.CurrentDirectory & "\temp\output.png") Then
                File.Delete(System.Environment.CurrentDirectory & "\temp\output.png")
            End If

            If File.Exists(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds") Then
                File.Delete(System.Environment.CurrentDirectory & "\temp\COH_LogInScreen_Background_temp.dds")
            End If

            imageresize()
            trimimage()
        End If
    End Sub
    Public Function overlayimage()

        'If CheckBox1.Checked = True Then
        '    imageresize()
        'Else
        '    trimimage()
        'End If

        Dim overlay As Bitmap = DevIL.DevIL.LoadBitmap(System.Environment.CurrentDirectory & "\overlay\frame.png")
        'Dim screen As Bitmap = DevIL.DevIL.LoadBitmap(System.Environment.CurrentDirectory & "\temp\output.png")
        Dim newimage As Bitmap
        If imageresize() Is Nothing Then
            newimage = trimimage()
        Else
            newimage = imageresize()
        End If

        Dim g As Graphics = Graphics.FromImage(newimage)
        'g.DrawImage(Screen, 0, 0)
        g.DrawImage(overlay, 0, 0)

        newimage = CropImage(newimage, New Size(1024, 1024), New Point(0, 0))

        pictureBox.Image = CropImage(newimage, New Size(1024, 768), New Point(0, 0))
        If File.Exists(System.Environment.CurrentDirectory & "\temp\output.png") Then
            File.Delete(System.Environment.CurrentDirectory & "\temp\output.png")
        End If
        DevIL.DevIL.SaveBitmap(System.Environment.CurrentDirectory & "\temp\output.png", newimage)
        g.Dispose()
    End Function

    Public Function imageresize()
        If CheckBox1.Checked = True Then
            CheckBox3.Checked = False
            If Not original Is Nothing Then
                Dim resized As Image = ResizeImage(original, New Size(1024, 768), False)

                Dim memStream As MemoryStream = New MemoryStream()
                resized.Save(memStream, ImageFormat.Bmp)
                m_bmp = resized
                If Not (m_bmp Is Nothing) Then
                    pictureBox.Image = CropImage(resized, New Size(1024, 768), New Point(0, 0))
                    Button2.Visible = True
                End If
                DevIL.DevIL.SaveBitmap(System.Environment.CurrentDirectory & "\temp\output.png", m_bmp)
                Return m_bmp
            End If
        End If
    End Function

    Public Function trimimage()
        If CheckBox3.Checked = True Then
            CheckBox1.Checked = False
            If Not original Is Nothing Then
                'Dim resized As Image = ResizeImage(original, New Size(1024, 768), New Size(1024, 1024), False)

                Dim resized As Image = TransformImage(ResizeImage(original, New Size(1024, 1024), True), 1024, 1024)

                Dim memStream As MemoryStream = New MemoryStream()
                resized.Save(memStream, ImageFormat.Bmp)
                m_bmp = resized
                If Not (m_bmp Is Nothing) Then
                    pictureBox.Image = CropImage(resized, New Size(1024, 768), New Point(0, 0))
                    Button2.Visible = True
                End If
                DevIL.DevIL.SaveBitmap(System.Environment.CurrentDirectory & "\temp\output.png", m_bmp)
                Return m_bmp
            End If
        End If
    End Function

End Class
