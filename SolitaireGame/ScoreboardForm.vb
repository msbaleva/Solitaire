Imports System.IO

Public Class ScoreboardForm
    Dim cntPerPage As Integer = 7
    Dim currentPage As Integer = 1
    Dim empty As String = ""
    Dim entries() As String
    Dim cntEntries As Integer = 0
    Dim cntPages As Integer = 1

    Private Sub initLabels(index As Integer, info() As String)
        CType(Me.Controls("Player" + Convert.ToString(index)), Label).Text = info(0)
        CType(Me.Controls("Time" + Convert.ToString(index)), Label).Text = info(1)
        CType(Me.Controls("Score" + Convert.ToString(index)), Label).Text = info(2)
        CType(Me.Controls("Date" + Convert.ToString(index)), Label).Text = info(3)
    End Sub

    Private Sub emptyLabels(index As Integer)
        CType(Me.Controls("Player" + Convert.ToString(index)), Label).Text = empty
        CType(Me.Controls("Time" + Convert.ToString(index)), Label).Text = empty
        CType(Me.Controls("Score" + Convert.ToString(index)), Label).Text = empty
        CType(Me.Controls("Date" + Convert.ToString(index)), Label).Text = empty
    End Sub

    Private Sub initPage()
        PageLabel.Text = Convert.ToString(currentPage) + "/" + Convert.ToString(cntPages)

        For indexInPage As Integer = 0 To cntPerPage - 1
            Dim indexInEntries = (currentPage - 1) * 7 + indexInPage
            If indexInEntries < cntEntries Then
                Dim info() As String = entries(indexInEntries).Split()
                initLabels(indexInPage, info)
            Else
                emptyLabels(indexInPage)
            End If

        Next
    End Sub
    Private Sub ScoreboardForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        entries = File.ReadAllLines("..\Scoreboard\Scoreboard.csv")
        If entries.Length > 0 Then
            cntEntries = entries.Length()
            cntPages = entries.Length / cntPerPage + 1
            If cntPages > 1 Then
                NextButton.Enabled = True
            End If
        End If

        initPage()
    End Sub

    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        currentPage = currentPage + 1
        If currentPage = cntPages Then
            NextButton.Enabled = False
        End If

        prevButton.Enabled = True

        initPage()
    End Sub

    Private Sub prevButton_Click(sender As Object, e As EventArgs) Handles prevButton.Click
        currentPage = currentPage - 1
        If currentPage = 1 Then
            prevButton.Enabled = False
        End If

        NextButton.Enabled = True

        initPage()
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        MainMenuForm.Show()
        Me.Close()
    End Sub
End Class