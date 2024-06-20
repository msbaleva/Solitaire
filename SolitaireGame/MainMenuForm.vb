Imports System.IO

Public Class MainMenuForm

    Private Sub Label1_MouseHover(sender As Object, e As EventArgs) Handles Label1.MouseHover
        Label1.ForeColor = Color.Gold
    End Sub

    Private Sub Label1_MouseLeave(sender As Object, e As EventArgs) Handles Label1.MouseLeave
        Label1.ForeColor = Color.Peru
    End Sub


    Private Sub NewGameButton_MouseHover(sender As Object, e As EventArgs) Handles NewGameButton.MouseHover
        NewGameButton.ForeColor = Color.Peru
        NewGameButton.BackColor = Color.PaleGoldenrod
    End Sub

    Private Sub HowToPlayButton_MouseHover(sender As Object, e As EventArgs) Handles ScoreboardButton.MouseHover
        ScoreboardButton.ForeColor = Color.Peru
        ScoreboardButton.BackColor = Color.PaleGoldenrod
    End Sub

    Private Sub QuitButton_MouseHover(sender As Object, e As EventArgs) Handles QuitButton.MouseHover
        QuitButton.ForeColor = Color.Peru
        QuitButton.BackColor = Color.PaleGoldenrod
    End Sub

    Private Sub NewGameButton_MouseLeave(sender As Object, e As EventArgs) Handles NewGameButton.MouseLeave
        NewGameButton.ForeColor = Color.Gold
        NewGameButton.BackColor = Color.OliveDrab
    End Sub

    Private Sub HowToPlayButton_MouseLeave(sender As Object, e As EventArgs) Handles ScoreboardButton.MouseLeave
        ScoreboardButton.ForeColor = Color.Gold
        ScoreboardButton.BackColor = Color.OliveDrab
    End Sub

    Private Sub QuitButton_MouseLeave(sender As Object, e As EventArgs) Handles QuitButton.MouseLeave
        QuitButton.ForeColor = Color.Gold
        QuitButton.BackColor = Color.OliveDrab
    End Sub

    Private Sub NewGameButton_Click(sender As Object, e As EventArgs) Handles NewGameButton.Click
        Dim newGame As ChooseDeckForm = New ChooseDeckForm()
        newGame.Show()
        Me.Hide()
    End Sub

    Private Sub ScoreboardButton_Click(sender As Object, e As EventArgs) Handles ScoreboardButton.Click

        Dim scoreboard As ScoreboardForm = New ScoreboardForm()
        scoreboard.Show()
        Me.Hide()
    End Sub

    Private Sub QuitButton_Click(sender As Object, e As EventArgs) Handles QuitButton.Click
        Dim Msg, Style, Title, Response
        Msg = "Do you really wish to quit?"
        Style = vbYesNo
        Title = "Quit"
        Response = MsgBox(Msg, Style, Title)
        If Response = vbYes Then
            Me.Close()
        End If
    End Sub


End Class