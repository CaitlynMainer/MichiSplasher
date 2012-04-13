<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.pictureBox = New System.Windows.Forms.PictureBox()
        Me.mnuFileExit = New System.Windows.Forms.MenuItem()
        Me.mnuFileSep1 = New System.Windows.Forms.MenuItem()
        Me.mainMenu = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuFile = New System.Windows.Forms.MenuItem()
        Me.mnuFileOpen = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.LinkLabel3 = New System.Windows.Forms.LinkLabel()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        CType(Me.pictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pictureBox
        '
        Me.pictureBox.Location = New System.Drawing.Point(3, 3)
        Me.pictureBox.Name = "pictureBox"
        Me.pictureBox.Size = New System.Drawing.Size(341, 256)
        Me.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox.TabIndex = 11
        Me.pictureBox.TabStop = False
        '
        'mnuFileExit
        '
        Me.mnuFileExit.Index = 2
        Me.mnuFileExit.Text = "E&xit"
        '
        'mnuFileSep1
        '
        Me.mnuFileSep1.Index = 1
        Me.mnuFileSep1.Text = "-"
        '
        'mainMenu
        '
        Me.mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFile})
        '
        'mnuFile
        '
        Me.mnuFile.Index = 0
        Me.mnuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFileOpen, Me.mnuFileSep1, Me.mnuFileExit, Me.MenuItem1})
        Me.mnuFile.Text = "&File"
        '
        'mnuFileOpen
        '
        Me.mnuFileOpen.Index = 0
        Me.mnuFileOpen.Text = "&Open..."
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 3
        Me.MenuItem1.Text = "Hash Files"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(0, 1)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(481, 318)
        Me.TabControl1.TabIndex = 18
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.ComboBox1)
        Me.TabPage1.Controls.Add(Me.CheckBox2)
        Me.TabPage1.Controls.Add(Me.CheckBox3)
        Me.TabPage1.Controls.Add(Me.CheckBox1)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.Button2)
        Me.TabPage1.Controls.Add(Me.pictureBox)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.Button8)
        Me.TabPage1.Controls.Add(Me.TextBox1)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(473, 292)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Loading Screen"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(350, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Game Region"
        Me.Label1.Visible = False
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"US", "UK", "FR", "DE"})
        Me.ComboBox1.Location = New System.Drawing.Point(349, 89)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 22
        Me.ComboBox1.Visible = False
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(354, 50)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(62, 17)
        Me.CheckBox2.TabIndex = 21
        Me.CheckBox2.Text = "Overlay"
        Me.CheckBox2.UseVisualStyleBackColor = True
        Me.CheckBox2.Visible = False
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(354, 27)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(72, 17)
        Me.CheckBox3.TabIndex = 20
        Me.CheckBox3.Text = "Trim to Fit"
        Me.CheckBox3.UseVisualStyleBackColor = True
        Me.CheckBox3.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(354, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(84, 17)
        Me.CheckBox1.TabIndex = 18
        Me.CheckBox1.Text = "Resize to Fit"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(400, 246)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Waiting..."
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(350, 220)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(118, 23)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "Save Loading Screen"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(357, 246)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Status:"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(416, 266)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(56, 23)
        Me.Button8.TabIndex = 14
        Me.Button8.Text = "Browse"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(101, 266)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(309, 20)
        Me.TextBox1.TabIndex = 12
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(0, 269)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(100, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "City of Heroes path:"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.RichTextBox1)
        Me.TabPage2.Controls.Add(Me.LinkLabel3)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.LinkLabel2)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.LinkLabel1)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(473, 292)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "About"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(11, 26)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Horizontal
        Me.RichTextBox1.Size = New System.Drawing.Size(459, 263)
        Me.RichTextBox1.TabIndex = 6
        Me.RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        '
        'LinkLabel3
        '
        Me.LinkLabel3.AutoSize = True
        Me.LinkLabel3.Location = New System.Drawing.Point(375, 10)
        Me.LinkLabel3.Name = "LinkLabel3"
        Me.LinkLabel3.Size = New System.Drawing.Size(38, 13)
        Me.LinkLabel3.TabIndex = 5
        Me.LinkLabel3.TabStop = True
        Me.LinkLabel3.Text = "NVidia"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(351, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = " And"
        '
        'LinkLabel2
        '
        Me.LinkLabel2.AutoSize = True
        Me.LinkLabel2.Location = New System.Drawing.Point(302, 10)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(54, 13)
        Me.LinkLabel2.TabIndex = 3
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "DevIL.net"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(293, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(10, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = ","
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(165, 10)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(131, 13)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "DevIL Image Manipulation"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(160, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Portions of code are provided by"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.WebBrowser1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(473, 292)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Change Log"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(473, 292)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.Url = New System.Uri("http://pc-logix.com/neosplasher/changes.php", System.UriKind.Absolute)
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(479, 318)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mainMenu
        Me.Name = "Form1"
        Me.Text = "title"
        CType(Me.pictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents mnuFileExit As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileSep1 As System.Windows.Forms.MenuItem
    Friend WithEvents mainMenu As System.Windows.Forms.MainMenu
    Friend WithEvents mnuFile As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFileOpen As System.Windows.Forms.MenuItem
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel3 As System.Windows.Forms.LinkLabel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser

End Class
