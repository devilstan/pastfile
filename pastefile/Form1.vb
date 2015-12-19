Imports System.IO
Public Class Form1
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Modifiers = Keys.Control AndAlso e.KeyCode = Keys.V Then

            MsgBox("hi")
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent(DataFormats.FileDrop) Then
                For Each s As String In data.GetData(DataFormats.FileDrop)
                    Dim newFile As String = Path.Combine("C:\Users\devilstan\Dropbox\app", Path.GetFileName(s))

                    Try
                        File.Copy(s, newFile)
                    Catch ex As Exception
                        Dim myfn As String, myext As String
                        Dim mystr As String
                        myfn = Path.GetFileNameWithoutExtension(s)
                        myext = Path.GetExtension(s)
                        mystr = InputBox("請輸入簡單說明", "歸檔提示")
                        newFile = Path.Combine("C:\Users\devilstan\Dropbox\app", Path.GetFileName(myfn & "_" & mystr & myext))
                        File.Copy(s, newFile)
                    Finally
                    End Try
                Next
            End If

            e.Handled = True
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        'First minimize the form
        'Me.WindowState = FormWindowState.Minimized
        'Me.ShowInTaskbar = True
        'Now make it invisible (make it look like it went into the system tray)
        'Me.Visible = False
        'Cancel the closing of the application
        'e.Cancel = True
        'NotifyIcon1.Visible = True
        'MsgBox("FTProgram has been minimized to the task bar.")
    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
            Me.NotifyIcon1.Visible = True
        End If
    End Sub

    Private Sub NotifyIcon1_Click(sender As Object, e As EventArgs) Handles NotifyIcon1.Click
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        Me.NotifyIcon1.Visible = False
        Me.Show()
    End Sub
End Class
