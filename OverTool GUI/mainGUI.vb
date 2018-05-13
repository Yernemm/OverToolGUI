Imports System.ComponentModel
Imports System.Net

Public Class mainGUI
    Dim livePath As String
    Dim ptrPath As String
    Dim lang As String
    Dim cmode As String
    Dim argument(6) As String
    Dim flags As String
    Dim otinf As Boolean
    Public cmdOutputVar As String
    Dim GUIVersion As String = "2.2"





    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button11.Text = "Overwatch Live"

        updater()

        '-----------------------
        'creating config file
        If My.Computer.FileSystem.FileExists(FileIO.FileSystem.CurrentDirectory & "\yernemm\overtoolGuiConfig.txt") Then
        Else

            If (Not System.IO.Directory.Exists(FileIO.FileSystem.CurrentDirectory & "\yernemm")) Then
                System.IO.Directory.CreateDirectory(FileIO.FileSystem.CurrentDirectory & "\yernemm")
            End If

            Dim FILE_NAME As String = FileIO.FileSystem.CurrentDirectory & "\yernemm\overtoolGuiConfig.txt"

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

            objWriter.Write("C:\Program Files (x86)\Overwatch" & vbNewLine & "C:\Program Files (x86)\Overwatch Test" & vbNewLine & "enUS" & vbNewLine & Application.StartupPath() & "\output")
            objWriter.Close()

        End If
        '--------------------------




        '-------------
        'Creating ww2ogg24 legal folder
        If My.Computer.FileSystem.FileExists(FileIO.FileSystem.CurrentDirectory & "\yernemm\legal\ww2ogg024\COPYING.txt") Then
        Else

            If (Not System.IO.Directory.Exists(FileIO.FileSystem.CurrentDirectory & "\yernemm\legal\ww2ogg024")) Then
                System.IO.Directory.CreateDirectory(FileIO.FileSystem.CurrentDirectory & "\yernemm\legal\ww2ogg024")
            End If

            Dim FILE_NAME As String = FileIO.FileSystem.CurrentDirectory & "\yernemm\legal\ww2ogg024\COPYING.txt"

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

            objWriter.Write(My.Resources.COPYING)
            objWriter.Close()

        End If
        '-------------



        '-------------
        'Creating Magick legal folder
        If My.Computer.FileSystem.FileExists(FileIO.FileSystem.CurrentDirectory & "\yernemm\legal\magick\Copyright.txt") Then
        Else

            If (Not System.IO.Directory.Exists(FileIO.FileSystem.CurrentDirectory & "\yernemm\legal\magick")) Then
                System.IO.Directory.CreateDirectory(FileIO.FileSystem.CurrentDirectory & "\yernemm\legal\magick")
            End If

            Dim FILE_NAME As String = FileIO.FileSystem.CurrentDirectory & "\yernemm\legal\magick\Copyright.txt"

            Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

            objWriter.Write(My.Resources.MagickCopyright)
            objWriter.Close()

        End If
        '-------------

        If My.Computer.FileSystem.FileExists(FileIO.FileSystem.CurrentDirectory & "\Magick.NET-Q16-AnyCPU.dll") Then
        Else
            IO.File.WriteAllBytes(FileIO.FileSystem.CurrentDirectory & "\Magick.NET-Q16-AnyCPU.dll", My.Resources.Magick_NET_Q16_AnyCPU)
        End If



        '  If My.Computer.FileSystem.FileExists(FileIO.FileSystem.CurrentDirectory & "\yernemm\lib\Magick_NET_Q16_AnyCPU.dll") Then
        '   Else
        '    If (Not System.IO.Directory.Exists(FileIO.FileSystem.CurrentDirectory & "\yernemm\lib")) Then
        '           System.IO.Directory.CreateDirectory(FileIO.FileSystem.CurrentDirectory & "\yernemm\lib")
        '      End If
        '     My.Computer.FileSystem.WriteAllBytes(FileIO.FileSystem.CurrentDirectory & "\yernemm\lib\Magick_NET_Q16_AnyCPU.dll", My.Resources.Magick_NET_Q16_AnyCPU, True)
        ' End If






        Dim fileReader As System.IO.StreamReader
        fileReader =
        My.Computer.FileSystem.OpenTextFileReader(FileIO.FileSystem.CurrentDirectory & "\yernemm\overtoolGuiConfig.txt")
        Dim stringReader(3) As String
        For i = 0 To 3
            stringReader(i) = fileReader.ReadLine()
        Next
        fileReader.Close()
        livePath = stringReader(0)
        ptrPath = stringReader(1)
        lang = stringReader(2)
        txtOutput.Text = stringReader(3)

        TextBox2.Text = livePath
        TextBox3.Text = ptrPath
        ComboBox1.Text = lang

        If txtOutput.Text = "" Then txtOutput.Text = Application.StartupPath() & "\output"


        otinf = False

    End Sub







    'UPDATER BELOW






    Public Shared Function CheckForInternetConnection() As Boolean
        Try
            Using client = New WebClient()
                Using stream = client.OpenRead("http://www.google.com")
                    Return True
                End Using
            End Using
        Catch
            Return False
        End Try
    End Function
    Private Sub updater()
        If CheckForInternetConnection() = True Then
            Try
                Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://yernemm.xyz/programs/OverToolGUI/version.txt")
                Dim response As System.Net.HttpWebResponse = request.GetResponse()

                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream)

                Dim newestversion As String = sr.ReadToEnd()
                Dim currentversion As String = GUIVersion

                If newestversion.Contains(currentversion) Then

                Else
                    MsgBox("New update detected. Please visit http://yernemm.xyz/projects/OverToolGUI to download.")
                    'checkUpdate.Stop()
                    LinkLabel1.Text = "CLICK HERE TO DOWNLOAD UPDATE"
                End If
            Catch
                MsgBox("Connection to yernemm.xyz failed. Cannot check for update.")
                'checkUpdate.Stop()
            End Try


        Else
            MsgBox("You do not have an internet connection. Cannot check for update.")
            'checkUpdate.Stop()
        End If
    End Sub






    '=============

    Private Function setArgs()
        argument(1) = """" & txtOutput.Text & """"
        argument(2) = TextBox9.Text
        argument(3) = TextBox9.Text
        argument(4) = TextBox9.Text
        argument(5) = TextBox9.Text
        argument(6) = TextBox9.Text
        flags = txtFlags.Text
    End Function

    Private Function openCMD(mode)

        setArgs()

        lbStatus.Text = "Preparing..."

        Me.Enabled = False

        '   Dim ctrl As Control
        '  For Each ctrl In Me.Controls
        ' If TypeOf ctrl Is Button Then
        '        ctrl.Enabled = False
        'End If
        'Next
        ' For Each ctrl In Panel1.Controls
        'If TypeOf ctrl Is Button Then
        'ctrl.Enabled = False
        'End If
        'Next

        wemToOgg.Hide()
        cmdOutput.Hide()

        lbStatus.Text = "Working..."

        For i = 0 To 1
            If i = 0 Then
                writeToConsole("Running Command..." & vbNewLine &
                               "Please wait and do not click any of the buttons..." & vbNewLine &
                                "It's normal for the program to freeze for a few seconds. If it's frozen for more than two minutes, consider terminating it with task manager." & vbNewLine &
                                vbNewLine & "------------------" & vbNewLine &
                               vbNewLine & "If it freezes or nothing happens for a long time, it may be a problem with OverTool itself. If OverTool.exe cannot run the command (perhaps due to an unsupported version of Overwatch), it may cause OverTool GUI to remain frozen indefinitely.")
            Else
                BackgroundWorker1.RunWorkerAsync()
                cmode = mode
            End If
        Next
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim ver As String
        If Button11.Text = "Overwatch Live" Then
            ver = livePath
        Else
            ver = ptrPath
        End If

        Dim proc As ProcessStartInfo = New ProcessStartInfo("cmd.exe")
        Dim pr As Process
        proc.CreateNoWindow = True
        proc.UseShellExecute = False
        proc.RedirectStandardInput = True
        proc.RedirectStandardOutput = True
        pr = Process.Start(proc)
        If otinf = False Then
            pr.StandardInput.WriteLine("OverTool.exe -L=" & lang & " " & flags & " " & " """ & ver & """ " & cmode)
        Else
            pr.StandardInput.WriteLine("OverTool.exe " & cmode)
            otinf = False
        End If
        pr.StandardInput.Close()
        'writeToConsole(pr.StandardOutput.ReadToEnd())

        Dim result As String = pr.StandardOutput.ReadToEnd()
        pr.StandardOutput.Close()
        e.Result = result

    End Sub
    ' This event handler deals with the results of the
    ' background operation.
    Private Sub backgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        ' First, handle the case where an exception was thrown.
        If (e.Error IsNot Nothing) Then
            MessageBox.Show(e.Error.Message)
        ElseIf e.Cancelled Then
            ' Next, handle the case where the user canceled the 
            ' operation.
            ' Note that due to a race condition in 
            ' the DoWork event handler, the Cancelled
            ' flag may not have been set, even though
            ' CancelAsync was called.
            cmdOutputVar = "Canceled"
        Else
            ' Finally, handle the case where the operation succeeded.
            cmdOutputVar = e.Result.ToString()


            Me.Enabled = True


            '  Dim ctrl As Control
            '   For Each ctrl In Me.Controls
            '     If TypeOf ctrl Is Button Then
            '          ctrl.Enabled = True
            '     End If
            '    Next
            '      For Each ctrl In Panel1.Controls
            '         If TypeOf ctrl Is Button Then
            '           ctrl.Enabled = True
            '     End If
            ' Next
        End If

        lbStatus.Text = "Ready."
        cmdOutput.Hide()
        cmdOutput.Show()

        ' Enable the UpDown control.
        'Me.numericUpDown1.Enabled = True

        ' Enable the Start button.
        'startAsyncButton.Enabled = True

        ' Disable the Cancel button.
        'cancelAsyncButton.Enabled = False
    End Sub 'backgroundWorker1_RunWorkerCompleted





    Private Function writeToConsole(a)
        cmdOutputVar = a
    End Function









    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim fileReader As System.IO.StreamReader
        fileReader =
        My.Computer.FileSystem.OpenTextFileReader(FileIO.FileSystem.CurrentDirectory & "\yernemm\overtoolGuiConfig.txt")
        Dim stringReader(3) As String
        For i = 0 To 3
            stringReader(i) = fileReader.ReadLine()
        Next
        fileReader.Close()
        livePath = stringReader(0)
        ptrPath = stringReader(1)
        lang = stringReader(2)
        txtOutput.Text = stringReader(3)

        TextBox2.Text = livePath
        TextBox3.Text = ptrPath
        ComboBox1.Text = lang
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim FILE_NAME As String = FileIO.FileSystem.CurrentDirectory & "\yernemm\overtoolGuiConfig.txt"

        Dim objWriter As New System.IO.StreamWriter(FILE_NAME)

        objWriter.Write(livePath & vbNewLine & ptrPath & vbNewLine & lang & vbNewLine & txtOutput.Text)
        objWriter.Close()
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        TextBox2.Text = "C:\Program Files (x86)\Overwatch"
        TextBox3.Text = "C:\Program Files (x86)\Overwatch Test"
        ComboBox1.Text = "enUS"

        txtOutput.Text = Application.StartupPath() & "\output"

    End Sub
    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        livePath = TextBox2.Text
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        ptrPath = TextBox3.Text
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        lang = ComboBox1.Text
    End Sub






    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim fileSaver As SaveFileDialog = New SaveFileDialog()
        fileSaver.Filter = "Text File|*.txt" 'Sets a filter to the fileSaver which makes it only save .txt files.
        fileSaver.Title = "Save Command Prompt Log"

        If fileSaver.ShowDialog() = System.Windows.Forms.DialogResult.OK Then 'Opens the file saving dialog and runs the code below when the OK button is pressed.
            'Saves the positions, unique words, punctuation and capitalisation to separate lines on the selected text file
            System.IO.File.WriteAllText(fileSaver.FileName, cmdOutputVar)
        End If
    End Sub





    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If Button11.Text = "Overwatch Live" Then
            Button11.Text = "Overwatch PTR"
        Else
            Button11.Text = "Overwatch Live"
        End If

    End Sub





    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://yernemm.xyz/projects/OverToolGUI")
    End Sub



    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        ddsToPng.Show()
    End Sub





    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Help.Show()
        'MsgBox("Some options require additional arguments which can be set here. The number next to the argument corresponds with the option that uses the argument." & vbNewLine & vbNewLine &
        '       "If the option has a number like this: <1> then the argument is required. If the number is displayed like this: [1] then the argument is optional.")
    End Sub




    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Dim webAddress As String = "http://yernemm.xyz/projects/OverToolGUI"
        Process.Start(webAddress)
    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If optLetter.Checked = True Then
            openCMD("g")
        Else
            openCMD("list-general")
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        If optLetter.Checked = True Then
            openCMD("m")
        Else
            openCMD("list-map")
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If optLetter.Checked = True Then
            openCMD("t")
        Else
            openCMD("list")
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If optLetter.Checked = True Then
            openCMD("Z")
        Else
            openCMD("keys")
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If optLetter.Checked = True Then
            openCMD("l")
        Else
            openCMD("list-lootbox")
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If optLetter.Checked = True Then
            openCMD("n")
        Else
            openCMD("list-npc")
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If optLetter.Checked = True Then
            openCMD("s")
        Else
            openCMD("strings")
        End If
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If optLetter.Checked = True Then
            openCMD("T" & argument(6))
        Else
            openCMD("find " & argument(6))
        End If
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click

        openCMD("~")

    End Sub
    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        If optLetter.Checked = True Then
            openCMD(RTrim("x " & argument(1) & " " & argument(3)))
        Else
            openCMD(RTrim("extract " & argument(1) & " " & argument(3)))
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        If optLetter.Checked = True Then
            openCMD(RTrim("L " & argument(1)))
        Else
            openCMD(RTrim("lootbox " & argument(1)))
        End If
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        If optLetter.Checked = True Then
            openCMD(RTrim("G " & argument(1)))
        Else
            openCMD(RTrim("general " & argument(1)))
        End If
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If optLetter.Checked = True Then
            openCMD(RTrim("M " & argument(1) & " " & argument(2)))
        Else
            openCMD(RTrim("map " & argument(1) & " " & argument(2)))
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If optLetter.Checked = True Then
            openCMD(RTrim("N " & argument(1) & " " & argument(5)))
        Else
            openCMD(RTrim("npc " & argument(1) & " " & argument(5)))
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        If optLetter.Checked = True Then
            openCMD(RTrim("v " & argument(1) & " " & argument(5)))
        Else
            openCMD(RTrim("npc-voice " & argument(1) & " " & argument(5)))
        End If
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click

        openCMD(TextBox10.Text)
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        wemToOgg.Show()
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        If optLetter.Checked = True Then
            openCMD(RTrim("V " & argument(1) & " " & argument(4)))
        Else
            openCMD(RTrim("voice " & argument(1) & " " & argument(4)))
        End If
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        otinf = True
        openCMD("")
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        cmdOutput.Show()
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        otinf = True

        openCMD(TextBox10.Text)

    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        If optLetter.Checked = True Then
            MsgBox("Game Modes not supported using letter command mode. Please use a version of OverTool which supports word-based commands and switch to the word command type.")
        Else
            openCMD("list-gamemode")
        End If
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        If optLetter.Checked = True Then
            MsgBox("Game Types not supported using letter command mode. Please use a version of OverTool which supports word-based commands and switch to the word command type.")
        Else
            openCMD("list-gametype")
        End If
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        If optLetter.Checked = True Then
            openCMD(RTrim("c " & argument(1)))
        Else
            openCMD(RTrim("announcer " & argument(1)))
        End If
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        If optLetter.Checked = True Then
            openCMD(RTrim("A " & argument(1)))
        Else
            openCMD(RTrim("audio " & argument(1)))
        End If
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        If optLetter.Checked = True Then
            openCMD(RTrim("a " & argument(1) & " " & argument(5)))
        Else
            openCMD(RTrim("map-audio " & argument(1) & " " & argument(5)))
        End If
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        If optLetter.Checked = True Then
            openCMD(RTrim("w " & argument(1) & " " & argument(5)))
        Else
            openCMD(RTrim("weaponskin " & argument(1) & " " & argument(5)))
        End If
    End Sub


End Class
