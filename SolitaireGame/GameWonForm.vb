Imports System.Formats.Asn1.AsnWriter
Imports System.IO

Public Class GameWonForm

    Dim time As String
    Dim score As String
    Public Sub New(_score As String, _time As String)
        InitializeComponent()
        time = _time
        score = _score
    End Sub
    Private Sub EnterButton_Click(sender As Object, e As EventArgs) Handles EnterButton.Click
        If TextBox1.Text <> "" Then
            My.Computer.FileSystem.WriteAllText("..\Scoreboard\Scoreboard.csv", TextBox1.Text & " " & time & " " & score & " " & Now.Date() & vbNewLine, True)
            ScoreboardForm.Show()
            Me.Close()
        Else
            Dim Msg, Style, Title, Response
            Msg = "You haven't entered player name yet."
            Style = vbOK
            Title = "Empty player name"
            Response = MsgBox(Msg, Style, Title)
        End If

    End Sub

    Private Sub GameWonForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TimeLabel.Text = time
        ScoreLabel.Text = score
        My.Computer.Audio.Play(My.Resources.tada, AudioPlayMode.WaitToComplete)
    End Sub
End Class