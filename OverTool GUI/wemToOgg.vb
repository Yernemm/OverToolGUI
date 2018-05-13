Imports System.ComponentModel
Public Class wemToOgg
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Process.Start(FileIO.FileSystem.CurrentDirectory & "\yernemm\legal\ww2ogg024\COPYING.txt")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim folderdialog As New FolderBrowserDialog
        folderdialog.SelectedPath = FileIO.FileSystem.CurrentDirectory
        folderdialog.ShowDialog()
        Dim path As String = folderdialog.SelectedPath
        TextBox1.Text = path
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim path As String = TextBox1.Text

        If (Not System.IO.Directory.Exists(path)) Then
            MsgBox("Invalid folder path.")
        Else
            'setup phase
            My.Computer.FileSystem.WriteAllBytes(path & "\packed_codebooks_aoTuV_603.bin", My.Resources.packed_codebooks_aoTuV_603, True)
            My.Computer.FileSystem.WriteAllBytes(path & "\revorb.exe", My.Resources.revorb, True)
            My.Computer.FileSystem.WriteAllBytes(path & "\ww2ogg.exe", My.Resources.ww2ogg, True)
            My.Computer.FileSystem.WriteAllText(path & "\script.bat", My.Resources.script, True)


            '---------
            'run code here




            Dim ctrl As Control
            For Each ctrl In Me.Controls
                If TypeOf ctrl Is Button Then
                    ctrl.Enabled = False
                End If
            Next

            mainGUI.Hide()

            For i = 0 To 1
                If i = 0 Then
                    writeToConsole("Running Command..." & vbNewLine &
                               "Please wait and do not click any of the buttons..." & vbNewLine &
                                "It's normal for the program to freeze for a few seconds. If it's frozen for more than a few minutes, consider terminating it with task manager." & vbNewLine &
                                vbNewLine & "------------------" & vbNewLine &
                               vbNewLine & "If it freezes or nothing happens for a long time, it may be a problem with the file conversion programs.")
                Else
                    BackgroundWorker1.RunWorkerAsync()

                End If
            Next













            'textbox2.text = "converting..."

            'dim ctrl as control
            'for each ctrl in me.controls
            '    if typeof ctrl is button then
            '        ctrl.enabled = false
            '    end if
            'next

            'form1.hide()


            'dim proc as processstartinfo = new processstartinfo("cmd.exe")
            'dim pr as process
            'proc.createnowindow = true
            'proc.useshellexecute = false
            'proc.redirectstandardinput = true
            'proc.redirectstandardoutput = true
            'pr = process.start(proc)
            'pr.standardinput.writeline("cd " & path)
            'pr.standardinput.writeline("script.bat")
            'pr.standardinput.close()
            ''writetoconsole(pr.standardoutput.readtoend())

            'dim result as string = pr.standardoutput.readtoend()
            'pr.standardoutput.close()

            'textbox2.text = result



            '---------



            'cleanup
            'My.Computer.FileSystem.DeleteFile(path & "\packed_codebooks_aoTuV_603.bin", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            'My.Computer.FileSystem.DeleteFile(path & "\revorb.exe", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            'My.Computer.FileSystem.DeleteFile(path & "\ww2ogg.exe", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            'My.Computer.FileSystem.DeleteFile(path & "\script.bat", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)

        End If

    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Dim path = TextBox1.Text
        Dim proc As ProcessStartInfo = New ProcessStartInfo("cmd.exe") ', path & "\script.bat")
        Dim pr As Process
        proc.CreateNoWindow = True
        proc.UseShellExecute = False
        proc.RedirectStandardInput = True
        proc.RedirectStandardOutput = True
        pr = Process.Start(proc)
        pr.StandardInput.WriteLine("cd " & path)
        pr.StandardInput.WriteLine("script.bat")
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
            TextBox2.Text = "Canceled"
        Else
            ' Finally, handle the case where the operation succeeded.
            TextBox2.Text = e.Result.ToString()

            'cleanup
            Dim path As String = TextBox1.Text
            My.Computer.FileSystem.DeleteFile(path & "\packed_codebooks_aoTuV_603.bin", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(path & "\revorb.exe", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(path & "\ww2ogg.exe", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)
            My.Computer.FileSystem.DeleteFile(path & "\script.bat", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently)



            Dim ctrl As Control
            For Each ctrl In Me.Controls
                If TypeOf ctrl Is Button Then
                    ctrl.Enabled = True
                End If
            Next
        End If

        mainGUI.Show()


        ' Enable the UpDown control.
        'Me.numericUpDown1.Enabled = True

        ' Enable the Start button.
        'startAsyncButton.Enabled = True

        ' Disable the Cancel button.
        'cancelAsyncButton.Enabled = False
    End Sub 'backgroundWorker1_RunWorkerCompleted

    Private Function writeToConsole(a)
        TextBox2.Text = a
    End Function
End Class