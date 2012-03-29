Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System
Imports System.Net
Imports System.Text
Imports System.Environment
Imports Microsoft.Win32

Module Module1


    Public Function GetRegValue(ByVal thisHive As RegistryHive, _
    ByVal thisKey As String, ByVal thisValueName As String) As String
        Dim objParent As RegistryKey
        Dim objSubkey As RegistryKey
        Dim sAns As String
        objParent = Registry.LocalMachine
        Select Case thisHive
            Case RegistryHive.ClassesRoot
                objParent = Registry.ClassesRoot
            Case RegistryHive.CurrentConfig
                objParent = Registry.CurrentConfig
            Case RegistryHive.CurrentUser
                objParent = Registry.CurrentUser
            Case RegistryHive.DynData
                objParent = Registry.DynData
            Case RegistryHive.LocalMachine
                objParent = Registry.LocalMachine
            Case RegistryHive.PerformanceData
                objParent = Registry.PerformanceData
            Case RegistryHive.Users
                objParent = Registry.Users
        End Select
        sAns = ""
        Try
            objSubkey = objParent.OpenSubKey(thisKey)
            'Check to see if the object is in the registry.
            If Not objSubkey Is Nothing Then
                sAns = (objSubkey.GetValue(thisValueName))
            End If
        Catch ex As Exception
        End Try
        Return sAns
    End Function

    Public Ver As String = "0.1.5"


    Public Sub MergeFiles(ByVal OutFile As String, ByVal ParamArray Files() As String)
        File.Copy(Files(0), OutFile, True) 'overwrites if exists.
        Const ChunkSize As Integer = 1024 * 1024
        Dim bw As BinaryWriter = Nothing
        Try
            bw = New BinaryWriter(New FileStream(OutFile, FileMode.Append))
            For i As Integer = 1 To Files.GetUpperBound(0)
                Dim br As BinaryReader = Nothing
                Try
                    br = New BinaryReader(New FileStream(Files(i), FileMode.Open))
                    Do While br.BaseStream.Position < br.BaseStream.Length - 1
                        Dim b(ChunkSize - 1) As Byte
                        Dim ReadLen As Integer = br.Read(b, 0, ChunkSize)
                        bw.Write(b, 0, ReadLen)
                    Loop
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally
                    If Not br Is Nothing Then
                        If Not br.BaseStream Is Nothing Then br.BaseStream.Dispose()
                        br.Close()
                    End If
                End Try
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not bw Is Nothing Then
                If Not bw.BaseStream Is Nothing Then bw.BaseStream.Dispose()
                bw.Close()
            End If
        End Try
    End Sub

    Public Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Dim newWidth As Integer
        Dim newHeight As Integer
        If preserveAspectRatio Then
            Dim originalWidth As Integer = image.Width
            Dim originalHeight As Integer = image.Height
            Dim percentWidth As Single = CSng(size.Width) / CSng(originalWidth)
            Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
            Dim percent As Single = If(percentHeight < percentWidth,
        percentHeight, percentWidth)
            newWidth = CInt(originalWidth * percent)
            newHeight = CInt(originalHeight * percent)
        Else
            newWidth = size.Width
            newHeight = size.Height
        End If
        Dim newImage As New Bitmap(newWidth, newHeight, PixelFormat.Format32bppArgb)
        Dim rect As New Rectangle(0, 0, newImage.Width, newImage.Height)
        'Dim bmpData As System.Drawing.Imaging.BitmapData = newImage.LockBits(rect, Drawing.Imaging.ImageLockMode.ReadWrite, newImage.PixelFormat)
        Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
            graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
            graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight)
        End Using
        Return newImage
    End Function

    ''' <summary>
    ''' Convert an image to array of bytes
    ''' </summary>
    ''' <param name="NewImage">Image to be converted</param>
    ''' <param name="ByteArr">Returns bytes</param>
    ''' <remarks></remarks>
    Public Sub Image2Byte(ByRef NewImage As Image, ByRef ByteArr() As Byte)
        '
        Dim ImageStream As MemoryStream

        Try
            ReDim ByteArr(0)
            If NewImage IsNot Nothing Then
                ImageStream = New MemoryStream
                NewImage.Save(ImageStream, ImageFormat.Jpeg)
                ReDim ByteArr(CInt(ImageStream.Length - 1))
                ImageStream.Position = 0
                ImageStream.Read(ByteArr, 0, CInt(ImageStream.Length))
            End If
        Catch ex As Exception

        End Try

    End Sub

End Module
