<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ddsToPng
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
        Me.Button3 = New System.Windows.Forms.Button()
        Me.consoleWindow = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.checkDel = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Button3
        '
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(370, 470)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 23)
        Me.Button3.TabIndex = 11
        Me.Button3.Text = "copyright info"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'consoleWindow
        '
        Me.consoleWindow.BackColor = System.Drawing.Color.Black
        Me.consoleWindow.Font = New System.Drawing.Font("Courier New", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consoleWindow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.consoleWindow.Location = New System.Drawing.Point(9, 164)
        Me.consoleWindow.Multiline = True
        Me.consoleWindow.Name = "consoleWindow"
        Me.consoleWindow.ReadOnly = True
        Me.consoleWindow.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.consoleWindow.Size = New System.Drawing.Size(449, 300)
        Me.consoleWindow.TabIndex = 10
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(235, 108)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(223, 50)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Convert"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(10, 108)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(219, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Browse folder..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Folder path:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(10, 82)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(448, 20)
        Me.TextBox1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(47, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(361, 31)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = ".dds to .png File Converter"
        '
        'checkDel
        '
        Me.checkDel.AutoSize = True
        Me.checkDel.Location = New System.Drawing.Point(13, 138)
        Me.checkDel.Name = "checkDel"
        Me.checkDel.Size = New System.Drawing.Size(180, 17)
        Me.checkDel.TabIndex = 13
        Me.checkDel.Text = "Delete .dds files after conversion"
        Me.checkDel.UseVisualStyleBackColor = True
        '
        'ddsToPng
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(470, 505)
        Me.Controls.Add(Me.checkDel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.consoleWindow)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ddsToPng"
        Me.Text = ".dds to .png converter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button3 As Button
    Friend WithEvents consoleWindow As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents checkDel As CheckBox
End Class
