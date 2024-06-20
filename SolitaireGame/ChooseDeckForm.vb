Public Class ChooseDeckForm


    Private Sub StartButton_MouseHover(sender As Object, e As EventArgs) Handles StartButton.MouseHover
        StartButton.ForeColor = Color.Peru
        StartButton.BackColor = Color.PaleGoldenrod
    End Sub

    Private Sub StartButton_MouseLeave(sender As Object, e As EventArgs) Handles StartButton.MouseLeave
        StartButton.ForeColor = Color.Gold
        StartButton.BackColor = Color.OliveDrab
    End Sub

    Private Sub PreviewButton_MouseHover(sender As Object, e As EventArgs) Handles PreviewButton.MouseHover
        PreviewButton.ForeColor = Color.Peru
        PreviewButton.BackColor = Color.PaleGoldenrod
    End Sub

    Private Sub PreviewButton_MouseLeave(sender As Object, e As EventArgs) Handles PreviewButton.MouseLeave
        PreviewButton.ForeColor = Color.Gold
        PreviewButton.BackColor = Color.OliveDrab
    End Sub

    Private Sub PreviewButton_Click(sender As Object, e As EventArgs) Handles PreviewButton.Click
        If ClassicRadioButton.Checked Then
            previewCards("-3")
        ElseIf VintageRadioButton.Checked Then
            previewCards("-2")
        ElseIf UwURadioButton.Checked Then
            previewCards("-1")
        Else
            Dim Msg, Style, Title, Response
            Msg = "Please choose a deck."
            Style = vbOK
            Title = "Choose Deck"
            Response = MsgBox(Msg, Style, Title)
        End If

    End Sub

    Private Sub previewCards(deck As String)
        If SuitComboBox.SelectedItem Is Nothing Or RankComboBox.SelectedItem Is Nothing Then
            Dim Msg, Style, Title, Response
            Msg = "Please choose suit and rank of card to preview."
            Style = vbOK
            Title = "Choose Deck"
            Response = MsgBox(Msg, Style, Title)
        Else
            Dim suit As Char = SuitComboBox.SelectedItem.ToString().ElementAt(0)
            Dim rank As Char = RankComboBox.SelectedItem.ToString().ElementAt(0)
            If (rank = "1") Then
                rank = "T"
            End If

            PreviewCard.Image = My.Resources.ResourceManager.GetObject(rank + suit + deck)
            DeckCard.Image = My.Resources.ResourceManager.GetObject("back" + deck)
            PreviewCard.Size = New Size(100, 150)
            PreviewCard.SizeMode = PictureBoxSizeMode.StretchImage
            PreviewCard.BringToFront()
            DeckCard.Size = New Size(100, 150)
            DeckCard.SizeMode = PictureBoxSizeMode.StretchImage
        End If

    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        Dim deck As String
        If ClassicRadioButton.Checked Then
            deck = "-3"
        ElseIf VintageRadioButton.Checked Then
            deck = "-2"
        Else
            deck = "-1"
        End If

        Dim newGame As GameForm = New GameForm(deck)
        newGame.Show()
        Me.Close()
    End Sub

    Private Sub previewCard_Click(sender As Object, e As EventArgs) Handles PreviewCard.Click
        PreviewCard.BringToFront()
    End Sub

    Private Sub DeckCard_Click(sender As Object, e As EventArgs) Handles DeckCard.Click
        DeckCard.BringToFront()
    End Sub


End Class