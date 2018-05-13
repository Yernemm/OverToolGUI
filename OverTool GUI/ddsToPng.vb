Imports ImageMagick
Imports System.IO
Public Class ddsToPng
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
            writeToConsole("Invalid folder path: " & path)
        Else
            clearConsole()
            'setup phase
            writeToConsole("Disabling controls...")

            Dim ctrl As Control
            For Each ctrl In Me.Controls
                If TypeOf ctrl Is Button Then
                    ctrl.Enabled = False
                End If
            Next

            cmdOutput.Hide()
            Help.Hide()
            mainGUI.Hide()
            wemToOgg.Hide()


            writeToConsole("Setting up...")

            writeToConsole("Searching files...")


            For Each i In Directory.GetFiles(path, "*.dds", SearchOption.AllDirectories)

                writeToConsole("File: " & i)

                Dim j As String = Microsoft.VisualBasic.Left(i, i.Length - 4)

                Using image As New MagickImage(i)
                    ' Save frame as jpg
                    image.Write(j & ".png")
                End Using

                writeToConsole("Done: " & j & ".png")

            Next

            If checkDel.Checked = True Then
                writeToConsole("Deleting .dds files...")

                For Each i In Directory.GetFiles(path, "*.dds", SearchOption.AllDirectories)
                    System.IO.File.Delete(i)
                    writeToConsole("Deleted: " & i)
                Next

            End If

            ' For Each i In ddsFilesArray
            '    Using image As New MagickImage(i)
            '   ' Save frame as jpg
            '    Image.Write("Snakeware.jpg")
            '        End Using
            '    Next




            '---------
            'run code here

            writeToConsole("Cleaning up...")

            writeToConsole("Re-enbaling controls...")

            For Each ctrl In Me.Controls
                If TypeOf ctrl Is Button Then
                    ctrl.Enabled = True
                End If
            Next

            mainGUI.Show()

            writeToConsole("Conversion completed!")

        End If

    End Sub
    Private Function writeToConsole(a)
        consoleWindow.AppendText(vbNewLine & a)
    End Function

    Private Function clearConsole()
        consoleWindow.Text = ""
    End Function

    Private Sub ddsToPng_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If (Not System.IO.Directory.Exists(FileIO.FileSystem.CurrentDirectory & "\yernemm\cache\magick")) Then
            System.IO.Directory.CreateDirectory(FileIO.FileSystem.CurrentDirectory & "\yernemm\cache\magick")
        End If
        MagickAnyCPU.CacheDirectory = FileIO.FileSystem.CurrentDirectory & "\yernemm\cache\magick"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Process.Start(FileIO.FileSystem.CurrentDirectory & "\yernemm\legal\magick\Copyright.txt")
    End Sub
End Class