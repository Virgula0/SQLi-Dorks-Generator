Imports System.IO
Imports System.Threading


Public Class Form1

    'BY X-SLAYER
    'Youtube : https://www.youtube.com/channel/UC-lOXlEl67lxmYTH2PTFovA

    Public Sub New()
        InitializeComponent()
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim TT As New Thread(AddressOf Generator)
        TT.Start()
    End Sub

    Public Sub Generator()
        If Not Directory.Exists((Application.StartupPath & "\Results\")) Then
            Directory.CreateDirectory((Application.StartupPath & "\Results\"))
        End If
        Dim str As String = Strings.Format(DateAndTime.Now, "dd.MM.%y-HH.mm.ss")
        Dim path As String = (Application.StartupPath & "\Results\Dorks-" & str & ".txt")
        If Not File.Exists(path) Then
            Using writer As StreamWriter = File.CreateText(path)
                Dim str4 As String
                For Each str4 In Me.Page_Names.Lines
                    Dim str5 As String
                    For Each str5 In Me.pg2.Lines
                        Dim str6 As String
                        For Each str6 In Me.pg3.Lines
                            writer.WriteLine((str4 & str5 & str6))
                        Next
                    Next
                Next
                writer.Close()
                txtres.Text = String.Empty
                Thread.Sleep(25)
                txtres.Text = File.ReadAllText(path)
                MsgBox("Dorks Generated Succesfully", MsgBoxStyle.Information)
                If MessageBox.Show("Do You Want To Open Resultat Folder", "Message", MessageBoxButtons.YesNo) = DialogResult.Yes Then
                    Process.Start(Application.StartupPath & "\Results\", AppWinStyle.NormalFocus)
                End If
            End Using
        End If
    End Sub
End Class
