Imports System.Data.Common
Imports System.Reflection.Metadata.Ecma335

Public Class GameForm
    Const TO_FOUNDATION_POINTS As Integer = 10
    Const FROM_FOUNDATION_POINTS As Integer = -10
    Const TO_TABLEAU_POINTS As Integer = 5
    Dim usedDeck As String
    Dim originalLocation As Point
    Dim originalRow As Integer
    Dim originalCol As Integer
    Dim indexLastOpenCard() As Integer = {0, 1, 2, 3, 4, 5, 6}
    Dim indexFirstOpenCard() As Integer = {0, 1, 2, 3, 4, 5, 6}
    Dim tableau(17, 6) As String
    Dim stockCard As PictureBox
    Dim drawPile(23) As String
    Dim emptySlots(11) As PictureBox
    Dim foundationPiles(3) As String
    Dim suit() As String = {"S", "H", "C", "D"}
    Dim rank() As String = {"2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K", "A"}
    Dim empty As String = "    "
    Dim allCards(51) As String
    Dim remainingCards As Integer = 52
    Dim remainingDrawCards As Integer = 24
    Dim drawCardIndex As Integer = -1
    Dim closedCards As Integer = 21
    Dim isTableauCard As Boolean = False
    Dim isDrawCard As Boolean = False
    Dim isFoundationCard As Boolean = False
    Dim movingCard As Boolean = False
    Dim movedCard As String
    Dim startingTime As DateTime
    Dim score As Integer = 0
    Dim buttonBackColor As Color
    Dim isDoubleClick As Boolean = False
    Dim currentPage As Integer = 1
    Dim isHelp As Boolean = False
    Dim cntPages As Integer = 8
    Dim hint As String = ""
    Public Sub New(deck As String)
        InitializeComponent()
        usedDeck = deck
    End Sub
    Private Sub loadCards()
        Dim cnt As Integer = 0
        For i As Integer = 0 To 12
            For j As Integer = 0 To 3
                allCards(cnt) = rank(i) + suit(j)
                cnt = cnt + 1
            Next
        Next
    End Sub

    Function generateCard()
        Randomize()
        Dim cardIndex = Int(remainingCards * Rnd())
        Dim card As String = allCards(cardIndex) + usedDeck
        remainingCards = remainingCards - 1
        allCards(cardIndex) = allCards(remainingCards)
        Return card
    End Function

    Function createCard(name As String, src As String, location As Point)
        Dim cardImage = New PictureBox
        cardImage.Image = My.Resources.ResourceManager.GetObject(src)
        cardImage.Name = name
        cardImage.Size = New Size(110, 160)
        cardImage.SizeMode = PictureBoxSizeMode.StretchImage
        cardImage.Location = location
        Controls.Add(cardImage)
        cardImage.BringToFront()
        Return cardImage
    End Function

    Private Sub dealCards()
        stockCard.Visible = True
        For dealingRow As Integer = 0 To 6
            For dealingCol As Integer = dealingRow To 6
                CType(Me.Controls(tableau(dealingRow, dealingCol)), PictureBox).Visible = True
            Next
        Next

    End Sub

    Function isValidMoveToTableau(locCard As String) As Boolean
        If locCard.StartsWith("tableauSlot") Then
            Return movedCard.ElementAt(0) = "K"
        End If
        Dim movedCardSuit As Char = movedCard.ElementAt(1)
        Dim locCardSuit As Char = locCard.ElementAt(1)
        Select Case locCardSuit
            Case "S", "C"
                If movedCardSuit = "C" Or movedCardSuit = "S" Then
                    hint = "You can only place red cards (♥ & ♦) on top of black ones (♠ & ♣) in tableau."
                    Return False
                End If
            Case "D", "H"
                If movedCardSuit = "D" Or movedCardSuit = "H" Then
                    hint = "You can only place black cards (♠ & ♣) on top of red ones (♥ & ♦) in tableau."
                    Return False
                End If
        End Select

        Dim movedCardRank As String = movedCard.ElementAt(0)
        Dim locCardRank As String = locCard.ElementAt(0)

        Select Case locCardRank
            Case "T"
                If movedCardRank <> "9" Then
                    hint = "You can only place a 9 on top of a 10 in tableau."
                    Return False

                End If
            Case "J"
                If movedCardRank <> "T" Then
                    Return False
                    hint = "You can only place a 10 on top of a Jack (J) in tableau."
                End If
            Case "Q"
                If movedCardRank <> "J" Then
                    hint = "You can only place a Jack (J) on top of a Queen (Q) in tableau."
                    Return False

                End If
            Case "K"
                If movedCardRank <> "Q" Then
                    hint = "You can only place a Queen (Q) on top of a King (K) in tableau."
                    Return False

                End If
            Case "2"
                If movedCardRank <> "A" Then
                    hint = "You can only place an Ace (A) on top of a 2 in tableau."
                    Return False
                End If
            Case "A"
                hint = "You can't place any cards on top of an Ace (A) in tableau."
                Return False

            Case Else
                Dim moved As Integer = CInt(movedCardRank)
                Dim loc As Integer = CInt(locCardRank)
                If moved = loc - 1 Then
                    Return True
                Else
                    hint = "You can only place a(n) " + Convert.ToString(loc - 1) + " on top of a(n) " + Convert.ToString(loc) + " in tableau."
                    Return False
                End If
        End Select

        Return True
    End Function

    Function isValidMoveToFoundation(locCard As String) As Boolean
        If Not isDoubleClick And isTableauCard And indexLastOpenCard(originalCol) <> originalRow Then
            For i As Integer = originalRow To indexLastOpenCard(originalCol)
                CType(Me.Controls(tableau(i, originalCol)), PictureBox).Location = New Point(originalLocation.X, originalLocation.Y + 30 * (i - originalRow))
                CType(Me.Controls(tableau(i, originalCol)), PictureBox).BorderStyle = BorderStyle.None
            Next
            Return False
        End If


        If locCard.StartsWith("foundationSlot") Then
            If movedCard.ElementAt(0) = "A" Then
                Return True
            Else
                hint = "You can only place an Ace (A) on an empty foundation pile."
                Return False
            End If
        End If

        If Not isDoubleClick Then
            Dim movedCardSuit As Char = movedCard.ElementAt(1)
            Dim locCardSuit As Char = locCard.ElementAt(1)
            If movedCardSuit <> locCardSuit Then
                hint = "You can only place cards of matching suits on a particular foundation pile."
                Return False
            End If
        End If


        Dim movedCardRank As String = movedCard.ElementAt(0)
        Dim locCardRank As String = locCard.ElementAt(0)

        Select Case locCardRank
            Case "9"
                If movedCardRank <> "T" Then
                    hint = "You can only place a 10 on top of a 9 in the foundation piles."
                    Return False
                End If
            Case "T"
                If movedCardRank <> "J" Then
                    hint = "You can only place a Jack (J) on top of a 10 in the foundation piles."
                    Return False
                End If
            Case "J"
                If movedCardRank <> "Q" Then
                    hint = "You can only place a Queen (Q) on top of a Jack (J) in the foundation piles."
                    Return False
                End If
            Case "Q"
                If movedCardRank <> "K" Then
                    hint = "You can only place a King (K) on top of a Queen (Q) in the foundation piles."
                    Return False
                End If
            Case "K"
                hint = "You can't place any cards on top of a King (K) in the foundation piles."
                Return False
            Case "A"
                If movedCardRank <> "2" Then
                    hint = "You can only place a 2 on top of an Ace (A) in the foundation piles."
                    Return False
                End If
            Case Else
                Dim moved As Integer = CInt(movedCardRank)
                Dim loc As Integer = CInt(locCardRank)
                ' debug
                Debug.WriteLine("isValidMoveToFoundation()")
                Debug.WriteLine("moving " + movedCard + " to " + locCard)
                '
                If moved <> loc + 1 Then
                    hint = "You can only place a(n) " + Convert.ToString(loc + 1) + " on top of a(n) " + Convert.ToString(loc) + " in the foundation piles."
                    Return False
                End If
        End Select

        Return True
    End Function

    Private Sub updateTableau()
        tableau(originalRow, originalCol) = empty
        If originalRow > indexFirstOpenCard(originalCol) Then
            indexLastOpenCard(originalCol) = originalRow - 1
        ElseIf originalRow = indexFirstOpenCard(originalCol) And originalRow > 0 Then
            indexLastOpenCard(originalCol) = originalRow - 1
            indexFirstOpenCard(originalCol) = originalRow - 1
        ElseIf originalRow = 0 Then
            indexLastOpenCard(originalCol) = -1
            indexFirstOpenCard(originalCol) = -1
        End If

        ' debug
        currentStateCheck("updateTableau()")
        '
    End Sub

    Private Sub moveCardToTableau(loc As Point)
        Dim row As Integer = (loc.Y - 220) / 30 + 1
        Dim col As Integer = (loc.X - 30) / 120
        If movedCard.ElementAt(0) = "K" Then
            row = 0
            indexFirstOpenCard(col) = 0
            indexLastOpenCard(col) = 0
        End If
        tableau(row, col) = movedCard
        ' debug
        Debug.WriteLine("moveCardToTableau()")
        Debug.WriteLine("Initial card should be updated.")
        '
        If isTableauCard Then
            tableau(originalRow, originalCol) = empty
            For i As Integer = originalRow + 1 To indexLastOpenCard(originalCol)
                row = row + 1
                tableau(row, col) = tableau(i, originalCol)
                tableau(i, originalCol) = empty
                ' debug
                Debug.WriteLine("Updated tableau successful. original row: " + Convert.ToString(i) + "new row: " + Convert.ToString(row))
                Debug.WriteLine(indexLastOpenCard(originalCol))
                '
            Next

            updateTableau()
        End If
        indexLastOpenCard(col) = row

    End Sub

    Private Sub openCardInTableau()
        If originalRow = indexFirstOpenCard(originalCol) And originalRow > 0 Then
            ' debug
            Debug.WriteLine("openCardInTableau()")
            Debug.WriteLine("original row" + Convert.ToString(originalRow))
            Debug.WriteLine(tableau(originalRow - 1, originalCol) + " is being opened")
            '
            CType(Me.Controls(tableau(originalRow - 1, originalCol)), PictureBox).Image =
                My.Resources.ResourceManager.GetObject(CType(Me.Controls(tableau(originalRow - 1, originalCol)), PictureBox).Name)
            AddHandler CType(Me.Controls(tableau(originalRow - 1, originalCol)), PictureBox).MouseDown, AddressOf TableauCard_MouseDown
            AddHandler CType(Me.Controls(tableau(originalRow - 1, originalCol)), PictureBox).MouseUp, AddressOf TableauCard_MouseUp
            AddHandler CType(Me.Controls(tableau(originalRow - 1, originalCol)), PictureBox).DoubleClick, AddressOf TableauCard_DoubleClick
            closedCards = closedCards - 1
            If closedCards = 0 And remainingDrawCards = 0 Then
                GameTimer.Stop()
                SolveButton.Visible = True
            End If
        End If

    End Sub

    Private Sub moveCardToFoundationPile(locCard As PictureBox)
        Dim index As Integer = (locCard.Location.X - 30) / 120 - 3
        foundationPiles(index) = movedCard
        If isTableauCard Then
            updateTableau()
        End If

    End Sub


    Private Sub updateDrawPile()
        remainingDrawCards = remainingDrawCards - 1
        For i As Integer = drawCardIndex To remainingDrawCards - 1
            drawPile(i) = drawPile(i + 1)
        Next
        ' debug
        Debug.WriteLine("Draw pile update. drawcardindex: " + Convert.ToString(drawCardIndex))
        '
        drawCardIndex = drawCardIndex - 1
        ' debug
        currentStateCheck("updateDrawPile()")
        '
        isDrawCard = False
    End Sub

    Private Sub swapFoundationPile(loc As Point)
        Dim index As Integer = (loc.X - 30) / 120 - 3
        Dim oldIndex As Integer = (originalLocation.X - 30) / 120 - 3
        foundationPiles(index) = movedCard
        foundationPiles(oldIndex) = empty
        isFoundationCard = False
    End Sub

    Private Sub updateFoundationPile()
        Dim oldIndex As Integer = (originalLocation.X - 30) / 120 - 3
        Dim rank As String = movedCard.ElementAt(0)
        Select Case rank
            Case "T"
                foundationPiles(oldIndex) = "9" + movedCard.Substring(1, 3)
            Case "J"
                foundationPiles(oldIndex) = "T" + movedCard.Substring(1, 3)
            Case "Q"
                foundationPiles(oldIndex) = "J" + movedCard.Substring(1, 3)
            Case "K"
                foundationPiles(oldIndex) = "Q" + movedCard.Substring(1, 3)
            Case "2"
                foundationPiles(oldIndex) = "A" + movedCard.Substring(1, 3)
            Case "A"
                foundationPiles(oldIndex) = empty
            Case Else
                Dim newRank As Integer = CInt(rank) - 1
                foundationPiles(oldIndex) = Convert.ToString(newRank) + movedCard.Substring(1, 3)
        End Select
        isFoundationCard = False
    End Sub



    Private Sub cardMouseDown(sender As Object)
        If Not isDoubleClick Then
            mouseTimer.Start()
        End If

        originalLocation = sender.Location
        movedCard = DirectCast(sender, PictureBox).Name
        CType(Me.Controls(movedCard), PictureBox).BorderStyle = BorderStyle.FixedSingle
        CType(Me.Controls(movedCard), PictureBox).BringToFront()
        movingCard = True
        isDrawCard = False
        isFoundationCard = False
        isTableauCard = False
    End Sub

    Private Sub moveToFoundationPile(sender As Object)
        If Not isDoubleClick Then
            mouseTimer.Stop()
        End If

        If movingCard Then
            Dim loc As PictureBox = DirectCast(sender, PictureBox)

            If isValidMoveToFoundation(loc.Name) Then

                CType(Me.Controls(movedCard), PictureBox).Location = loc.Location
                'My.Computer.Audio.Play(My.Resources.flip, AudioPlayMode.WaitToComplete)
                CType(Me.Controls(movedCard), PictureBox).BringToFront()
                If isDrawCard Then
                    updateDrawPile()
                    updateScore(TO_FOUNDATION_POINTS)
                    RemoveHandler CType(Me.Controls(movedCard), PictureBox).DoubleClick, AddressOf DrawCard_DoubleClick
                    RemoveHandler CType(Me.Controls(movedCard), PictureBox).Click, AddressOf DrawCard_Click
                    RemoveHandler CType(Me.Controls(movedCard), PictureBox).MouseDown, AddressOf DrawCard_MouseDown
                ElseIf isTableauCard Then
                    openCardInTableau()
                    updateScore(TO_FOUNDATION_POINTS)
                    RemoveHandler CType(Me.Controls(movedCard), PictureBox).DoubleClick, AddressOf TableauCard_DoubleClick
                    RemoveHandler CType(Me.Controls(movedCard), PictureBox).MouseUp, AddressOf TableauCard_MouseUp
                    RemoveHandler CType(Me.Controls(movedCard), PictureBox).MouseDown, AddressOf TableauCard_MouseDown
                ElseIf isFoundationCard Then
                    swapFoundationPile(loc.Location)
                End If

                moveCardToFoundationPile(loc)

                hint = "You can move cards to foundation piles by double-clicking them."
                showHint()

                AddHandler CType(Me.Controls(movedCard), PictureBox).MouseUp, AddressOf FoundationCard_MouseUp
                AddHandler CType(Me.Controls(movedCard), PictureBox).MouseDown, AddressOf FoundationCard_MouseDown
            Else

                CType(Me.Controls(movedCard), PictureBox).Location = originalLocation
                showHint()
            End If

            CType(Me.Controls(movedCard), PictureBox).BorderStyle = BorderStyle.None
            movingCard = False
            isDoubleClick = False
            If gameEnded() Then
                congratulationsScreen()
            End If
        End If

        ' debug
        currentStateCheck("moveToFoundationPile()")
        '
    End Sub


    Private Sub DrawCard_DoubleClick(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            isDoubleClick = True
            cardMouseDown(sender)
            isDrawCard = True
            For i As Integer = 0 To 3
                If foundationPiles(i).ElementAt(1) = movedCard.ElementAt(1) Then
                    moveToFoundationPile(CType(Me.Controls(foundationPiles(i)), PictureBox))
                    Exit For
                ElseIf foundationPiles(i) = empty And movedCard.ElementAt(0) = "A" Then
                    moveToFoundationPile(CType(Me.Controls("foundationSlot" + Convert.ToString(i)), PictureBox))
                    Exit For
                End If
            Next
        End If


    End Sub

    Private Sub TableauCard_DoubleClick(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Right Then
            isDoubleClick = True
            cardMouseDown(sender)
            isTableauCard = True
            originalRow = (originalLocation.Y - 220) / 30
            originalCol = (originalLocation.X - 30) / 120

            For i As Integer = 0 To 3
                If foundationPiles(i).ElementAt(1) = movedCard.ElementAt(1) Then
                    moveToFoundationPile(CType(Me.Controls(foundationPiles(i)), PictureBox))
                    Exit For
                ElseIf foundationPiles(i) = empty And movedCard.ElementAt(0) = "A" Then
                    moveToFoundationPile(CType(Me.Controls("foundationSlot" + Convert.ToString(i)), PictureBox))
                    Exit For
                End If
            Next
        End If



    End Sub

    Private Sub TableauCard_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            cardMouseDown(sender)
            originalRow = (originalLocation.Y - 220) / 30
            originalCol = (originalLocation.X - 30) / 120


            For i As Integer = originalRow To indexLastOpenCard(originalCol)
                ' debug
                Debug.WriteLine("TableauCard_MouseDown")
                Debug.WriteLine("Card: " + tableau(i, originalCol))
                '
                CType(Me.Controls(tableau(i, originalCol)), PictureBox).BorderStyle = BorderStyle.FixedSingle
            Next

            isTableauCard = True
        End If


    End Sub

    Private Sub DrawCard_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            cardMouseDown(sender)
            originalLocation = New Point(150, 40)
            'movedCard = CType(Me.Controls(drawPile(drawCardIndex)), PictureBox).Name
            'CType(Me.Controls(movedCard), PictureBox).BorderStyle = BorderStyle.FixedSingle
            'stockCard.BorderStyle = BorderStyle.None
            isDrawCard = True
        End If

    End Sub

    Private Sub FoundationCard_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            cardMouseDown(sender)
            isFoundationCard = True
        End If

    End Sub

    Private Sub updateScore(points As Integer)
        Dim curr As Integer = Integer.Parse(ScoreLabel.Text)
        ScoreLabel.Text = Convert.ToString(curr + points)
    End Sub


    Private Sub FoundationCard_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            moveToFoundationPile(sender)
        End If

    End Sub

    Private Sub TableauCard_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            If Not isDoubleClick Then
                mouseTimer.Stop()
            End If

            If movingCard Then
                Dim loc As PictureBox = DirectCast(sender, PictureBox)
                If isValidMoveToTableau(loc.Name) Then
                    If movedCard.StartsWith("K") Then
                        CType(Me.Controls(movedCard), PictureBox).Location = loc.Location
                    Else
                        CType(Me.Controls(movedCard), PictureBox).Location = New Point(loc.Location.X, loc.Location.Y + 30)
                    End If
                    'My.Computer.Audio.Play(My.Resources.flip, AudioPlayMode.WaitToComplete)
                    CType(Me.Controls(movedCard), PictureBox).BringToFront()
                    If isTableauCard Then
                        For i As Integer = originalRow + 1 To indexLastOpenCard(originalCol)
                            CType(Me.Controls(tableau(i, originalCol)), PictureBox).Location =
                                New Point(CType(Me.Controls(movedCard), PictureBox).Location.X, CType(Me.Controls(movedCard), PictureBox).Location.Y + 30 * (i - originalRow))
                            CType(Me.Controls(tableau(i, originalCol)), PictureBox).BorderStyle = BorderStyle.None
                            CType(Me.Controls(tableau(i, originalCol)), PictureBox).BringToFront()

                        Next

                        openCardInTableau()
                        updateScore(TO_TABLEAU_POINTS)
                    ElseIf isDrawCard Then
                        updateDrawPile()
                        updateScore(TO_TABLEAU_POINTS)
                        RemoveHandler CType(Me.Controls(movedCard), PictureBox).Click, AddressOf DrawCard_Click
                        RemoveHandler CType(Me.Controls(movedCard), PictureBox).MouseDown, AddressOf DrawCard_MouseDown
                        RemoveHandler CType(Me.Controls(movedCard), PictureBox).DoubleClick, AddressOf DrawCard_DoubleClick
                    ElseIf isFoundationCard Then
                        updateFoundationPile()
                        updateScore(FROM_FOUNDATION_POINTS)
                        RemoveHandler CType(Me.Controls(movedCard), PictureBox).MouseUp, AddressOf FoundationCard_MouseUp
                        RemoveHandler CType(Me.Controls(movedCard), PictureBox).MouseDown, AddressOf FoundationCard_MouseDown
                    End If

                    moveCardToTableau(loc.Location)


                    AddHandler CType(Me.Controls(movedCard), PictureBox).MouseUp, AddressOf TableauCard_MouseUp
                    AddHandler CType(Me.Controls(movedCard), PictureBox).MouseDown, AddressOf TableauCard_MouseDown
                    AddHandler CType(Me.Controls(movedCard), PictureBox).DoubleClick, AddressOf TableauCard_DoubleClick
                Else

                    CType(Me.Controls(movedCard), PictureBox).Location = originalLocation
                    If isTableauCard Then
                        For i As Integer = originalRow + 1 To indexLastOpenCard(originalCol)
                            CType(Me.Controls(tableau(i, originalCol)), PictureBox).Location = New Point(originalLocation.X, originalLocation.Y + 30 * (i - originalRow))
                            CType(Me.Controls(tableau(i, originalCol)), PictureBox).BorderStyle = BorderStyle.None
                        Next

                    End If

                    showHint()
                End If

                CType(Me.Controls(movedCard), PictureBox).BorderStyle = BorderStyle.None
                movingCard = False

            End If

        End If

        ' debug
        currentStateCheck("TableauCard_MouseUp")
        '
    End Sub

    Private Sub Form_MouseUp(sender As Object, e As MouseEventArgs) Handles MyBase.MouseUp
        If e.Button = MouseButtons.Left Then
            If movingCard Then
                mouseTimer.Stop()
                CType(Me.Controls(movedCard), PictureBox).Location = originalLocation
                CType(Me.Controls(movedCard), PictureBox).BorderStyle = BorderStyle.None
                If isTableauCard Then
                    For i As Integer = originalRow + 1 To indexLastOpenCard(originalCol)
                        CType(Me.Controls(tableau(i, originalCol)), PictureBox).Location = New Point(originalLocation.X, originalLocation.Y + 30 * (i - originalRow))
                        CType(Me.Controls(tableau(i, originalCol)), PictureBox).BorderStyle = BorderStyle.None
                    Next

                End If

                movingCard = False
            End If
        End If

        'debug
        currentStateCheck("Form_MouseUp")
        '

    End Sub


    Private Sub mouseTimer_tick(sender As Object, e As EventArgs) Handles mouseTimer.Tick
        If movingCard Then
            'Dim diffX As Double = (My.Computer.Screen.Bounds.Size.Width - Me.Size.Width) / 2
            'Dim diffY As Double = (My.Computer.Screen.Bounds.Size.Height - Me.Size.Height) / 2

            Dim newLoc As Point = New Point(MousePosition.X, MousePosition.Y)
            ' debug
            Debug.WriteLine("mousetimer_tick")
            Debug.WriteLine(Convert.ToString(movedCard) + "is moving")
            '
            CType(Me.Controls(movedCard), PictureBox).Location = newLoc
            If isTableauCard Then
                For i As Integer = originalRow + 1 To indexLastOpenCard(originalCol)
                    'debug
                    Debug.WriteLine(Convert.ToString(indexLastOpenCard(originalCol)) + "is moving")
                    '
                    CType(Me.Controls(tableau(i, originalCol)), PictureBox).BringToFront()
                    CType(Me.Controls(tableau(i, originalCol)), PictureBox).Location = New Point(MousePosition.X, MousePosition.Y + 30 * (i - originalRow))
                Next
            End If

        End If
    End Sub
    Private Sub AssociateCardEventHandler()
        For Each c As Control In Me.Controls
            If TypeOf c Is PictureBox Then
                AddHandler c.MouseHover, AddressOf Cursor_MouseHover
                AddHandler c.MouseLeave, AddressOf Cursor_MouseLeave
                c.BackColor = Color.Transparent
            End If
        Next
    End Sub

    Private Sub Cursor_MouseHover(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.Hand
    End Sub

    Private Sub Cursor_MouseLeave(sender As Object, e As EventArgs)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub changeBackground()
        If usedDeck = "-1" Then
            Me.BackColor = Color.LightSteelBlue
            Menu.BackColor = Color.RoyalBlue
            Menu.ForeColor = Color.Gold
            SolveButton.BackColor = Color.RoyalBlue
            buttonBackColor = Color.RoyalBlue
            ScoreNameLabel.ForeColor = Color.RoyalBlue
            TimeNameLabel.ForeColor = Color.RoyalBlue
        ElseIf usedDeck = "-2" Then
            Me.BackColor = Color.Beige
            Menu.BackColor = Color.CadetBlue
            Menu.ForeColor = Color.Gold
            SolveButton.BackColor = Color.CadetBlue
            buttonBackColor = Color.CadetBlue
            ScoreNameLabel.ForeColor = Color.CadetBlue
            TimeNameLabel.ForeColor = Color.CadetBlue
        Else
            Me.BackColor = Color.ForestGreen
            Menu.BackColor = Color.OliveDrab
            Menu.ForeColor = Color.Gold
            SolveButton.BackColor = Color.OliveDrab
            buttonBackColor = Color.OliveDrab
            ScoreNameLabel.ForeColor = Color.Gold
            TimeNameLabel.ForeColor = Color.Gold
        End If
    End Sub
    Private Sub GameForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        startGame()
    End Sub

    Public Sub startGame()
        changeBackground()
        loadCards()
        For i As Integer = 0 To 6
            emptySlots(i) = createCard("tableauSlot" + Convert.ToString(i), "base" + usedDeck, New Point(120 * i + 30, 220))
            AddHandler emptySlots(i).MouseUp, AddressOf TableauCard_MouseUp

            If i >= 3 Then
                emptySlots(i + 4) = createCard("foundationSlot" + Convert.ToString(i - 3), "base" + usedDeck, New Point(120 * i + 30, 40))
                foundationPiles(i - 3) = empty
                AddHandler emptySlots(i + 4).MouseUp, AddressOf FoundationCard_MouseUp
            End If
        Next

        emptySlots(11) = createCard("drawPileLSlot", "base" + usedDeck, New Point(30, 40))
        AddHandler emptySlots(11).Click, AddressOf drawPileLSlot_Click
        stockCard = createCard("animationCard", "back" + usedDeck, New Point(30, 40))
        stockCard.Visible = False
        AddHandler stockCard.Click, AddressOf DrawCard_Click

        For i As Integer = 23 To 0 Step -1
            drawPile(i) = generateCard()
            Dim drawPileCard As PictureBox = createCard(drawPile(i), drawPile(i), New Point(150, 40))
            drawPileCard.BringToFront()
            drawPileCard.Visible = False
            AddHandler drawPileCard.MouseDown, AddressOf DrawCard_MouseDown
            AddHandler drawPileCard.DoubleClick, AddressOf DrawCard_DoubleClick
        Next



        For row As Integer = 0 To 17
            For col As Integer = 0 To 6
                tableau(row, col) = empty
                If col >= row And row <= 6 Then
                    tableau(row, col) = generateCard()
                    Dim card As PictureBox
                    Dim point As Point = New Point(120 * col + 30, 30 * row + 220)
                    If row = col Then
                        card = createCard(tableau(row, col), tableau(row, col), point)
                        AddHandler card.MouseDown, AddressOf TableauCard_MouseDown
                        AddHandler card.MouseUp, AddressOf TableauCard_MouseUp
                        AddHandler card.DoubleClick, AddressOf TableauCard_DoubleClick
                    Else
                        card = createCard(tableau(row, col), "back" + usedDeck, point)
                    End If

                    card.Visible = False
                End If

            Next
        Next

        HowToPlayPanel.BringToFront()

    End Sub


    Private Sub drawPileLSlot_Click(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            For i As Integer = remainingDrawCards - 1 To 0 Step -1
                CType(Me.Controls(drawPile(i)), PictureBox).Visible = False
                CType(Me.Controls(drawPile(i)), PictureBox).BringToFront()
            Next

            drawCardIndex = -1
            stockCard.Visible = True
        End If

        ' debug
        Debug.WriteLine("Draw Pile:")
        For j As Integer = 0 To remainingDrawCards - 1
            Debug.Write(drawPile(j) + " ")
        Next
        Debug.WriteLine(".")
        '
    End Sub

    Private Sub DrawCard_Click(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            drawCardIndex = drawCardIndex + 1
            If drawCardIndex = remainingDrawCards - 1 Then
                stockCard.Visible = False
            End If

            CType(Me.Controls(drawPile(drawCardIndex)), PictureBox).Visible = True
            CType(Me.Controls(drawPile(drawCardIndex)), PictureBox).BringToFront()
            My.Computer.Audio.Play(My.Resources.flip, AudioPlayMode.WaitToComplete)
        End If

        ' debug
        For j As Integer = 0 To remainingDrawCards - 1
            Debug.Write(drawPile(j) + " ")
        Next
        Debug.WriteLine(".")
        Debug.WriteLine(movedCard + " being moved")
        If drawCardIndex > -1 Then
            Debug.WriteLine(drawPile(drawCardIndex) + " draw")
        End If
        '
    End Sub



    Private Sub QuitGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles QuitGameToolStripMenuItem.Click
        Dim Msg, Style, Title, Response
        GameTimer.Stop()
        Msg = "Do you really wish to end the current game?"
        Style = vbYesNo
        Title = "Quit Game"
        Response = MsgBox(Msg, Style, Title)
        If Response = vbYes Then
            MainMenuForm.Show()
            Me.Close()
        Else
            GameTimer.Start()
        End If
    End Sub

    Private Sub showHint()
        If hint <> "" And Not isDoubleClick Then
            GameTimer.Stop()
            Dim Response As String = MsgBox(hint, vbOK, "Hint")
            If Response = vbOK Then
                hint = ""
                GameTimer.Start()
            End If
        End If

    End Sub


    Private Sub NewGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewGameToolStripMenuItem.Click
        Dim Msg, Style, Title, Response
        GameTimer.Stop()
        Msg = "Do you really wish to start a new game?"
        Style = vbYesNo
        Title = "Start New Game"
        Response = MsgBox(Msg, Style, Title)
        If Response = vbYes Then
            Dim newGame As ChooseDeckForm = New ChooseDeckForm()
            newGame.Show()
            Me.Close()
        Else
            GameTimer.Start()
        End If
    End Sub

    Private Sub PauseGameToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PauseGameToolStripMenuItem.Click
        GameTimer.Stop()
        Dim Msg, Style, Title, Response
        Msg = "Do you wish to resume?"
        Style = vbYesNo
        Title = "Game Paused"
        Response = MsgBox(Msg, Style, Title)
        If Response = vbNo Then
            MainMenuForm.Show()
            Me.Close()
        Else
            GameTimer.Start()
        End If
    End Sub

    Private Sub ClassicToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClassicToolStripMenuItem.Click
        changeDeck("-3")
    End Sub

    Private Sub VintageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VintageToolStripMenuItem.Click
        changeDeck("-2")
    End Sub

    Private Sub UwUToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UwUToolStripMenuItem.Click
        changeDeck("-1")
    End Sub

    Private Sub changeDeck(newDeck As String)
        If newDeck = usedDeck Then
            GameTimer.Stop()
            Dim Msg, Style, Title, Response
            Msg = "The chosen deck is already in use."
            Style = vbOK
            Title = "Change Deck"
            Response = MsgBox(Msg, Style, Title)
            GameTimer.Start()
        Else

            For i As Integer = 0 To 11
                emptySlots(i).Image = My.Resources.ResourceManager.GetObject("base" + newDeck)
            Next

            stockCard.Image = My.Resources.ResourceManager.GetObject("back" + newDeck)

            For i As Integer = 0 To remainingDrawCards - 1
                Dim currRank As String = drawPile(i).ElementAt(0)
                Dim currSuit As String = drawPile(i).ElementAt(1)
                Dim newName = currRank + currSuit + newDeck

                CType(Me.Controls(drawPile(i)), PictureBox).Name = newName
                CType(Me.Controls(newName), PictureBox).Image = My.Resources.ResourceManager.GetObject(newName)
                drawPile(i) = newName
            Next

            For j As Integer = 0 To 6
                For i As Integer = 0 To indexLastOpenCard(j)
                    Dim currRank As String = tableau(i, j).ElementAt(0)
                    Dim currSuit As String = tableau(i, j).ElementAt(1)
                    Dim newName = currRank + currSuit + newDeck
                    CType(Me.Controls(tableau(i, j)), PictureBox).Name = newName
                    If (i < indexFirstOpenCard(j)) Then
                        CType(Me.Controls(newName), PictureBox).Image = My.Resources.ResourceManager.GetObject("back" + newDeck)
                    Else
                        CType(Me.Controls(newName), PictureBox).Image = My.Resources.ResourceManager.GetObject(newName)
                    End If

                    tableau(i, j) = newName
                Next
            Next

            For i As Integer = 0 To 3
                If (foundationPiles(i) <> empty) Then
                    Dim currRank As String = foundationPiles(i).ElementAt(0)
                    Dim currSuit As String = foundationPiles(i).ElementAt(1)
                    Dim newName = currRank + currSuit + newDeck
                    For j As Integer = 0 To 12
                        If (currRank <= rank(j)) Then
                            CType(Me.Controls(foundationPiles(i)), PictureBox).Name = newName
                            CType(Me.Controls(newName), PictureBox).Image = My.Resources.ResourceManager.GetObject(newName)
                            foundationPiles(i) = newName
                        End If
                    Next
                End If

            Next

            usedDeck = newDeck
            changeBackground()
            My.Computer.Audio.Play(My.Resources.shuffle, AudioPlayMode.WaitToComplete)


        End If
    End Sub

    Private Sub ChangeBackgroundToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChangeBackgroundToolStripMenuItem.Click
        Dim colors As ColorDialog = New ColorDialog()
        If colors.ShowDialog() = DialogResult.OK Then
            Me.BackColor = colors.Color
        End If
    End Sub

    Private Sub GameTimer_Tick(sender As Object, e As EventArgs) Handles GameTimer.Tick
        Dim ts As TimeSpan = TimeSpan.Parse(TimerLabel.Text).Add(TimeSpan.Parse("00:00:01"))
        TimerLabel.Text = ts.ToString("hh\:mm\:ss")
    End Sub


    Private Sub SolveButton_MouseHover(sender As Object, e As EventArgs) Handles SolveButton.MouseHover
        SolveButton.ForeColor = Color.Peru
        SolveButton.BackColor = Color.PaleGoldenrod
    End Sub

    Private Sub SolveButton_MouseLeave(sender As Object, e As EventArgs) Handles SolveButton.MouseLeave
        SolveButton.ForeColor = Color.Gold
        SolveButton.BackColor = buttonBackColor
    End Sub

    Private Sub congratulationsScreen()
        Dim congratsScreen As GameWonForm = New GameWonForm(ScoreLabel.Text, TimerLabel.Text)
        congratsScreen.Show()
        Me.Close()
    End Sub

    Function gameEnded() As Boolean
        For i As Integer = 0 To 3
            If Not foundationPiles(i).StartsWith("K") Then
                Return False
            End If
        Next

        Return True
    End Function

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        HowToPlayPanel.Visible = False
        If isHelp Then
            GameTimer.Start()
        Else
            dealCards()

            AssociateCardEventHandler()

            ' debug
            currentStateCheck("CloseButton_Click")
            '

            startingTime = DateTime.Now
            TimerLabel.BringToFront()

            GameTimer.Start()
            My.Computer.Audio.Play(My.Resources.shuffle, AudioPlayMode.WaitToComplete)
        End If
    End Sub

    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        currentPage = currentPage + 1
        If currentPage = cntPages Then
            NextButton.Enabled = False
        End If

        BackButton.Enabled = True
        initText()
    End Sub

    Private Sub BackButton_Click(sender As Object, e As EventArgs) Handles BackButton.Click
        currentPage = currentPage - 1
        If currentPage = 1 Then
            BackButton.Enabled = False
        End If

        NextButton.Enabled = True
        initText()
    End Sub

    Private Function initText()
        PageLabel.Text = Convert.ToString(currentPage) + "/" + Convert.ToString(cntPages)
        Select Case currentPage
            Case 1
                HowToPlayText.Text = "The goal of Solitaire is to create a stack of cards from low to high in each of the four foundation piles. Each pile can contain only one suit."
            Case 2
                HowToPlayText.Text = "In Solitaire, Aces are low and Kings are high. The four foundation piles must besgin with Aces and end with Kings."
            Case 3
                HowToPlayText.Text = "Below the foundation piles, you can move cards from one column to another. Cards in columns must be places in descending order and must alternate between red and black. For example, you can put a red 7 on a black 8."
            Case 4
                HowToPlayText.Text = "You can also move sequential runs of cards between columns. Just tap the deepest card in the run and drag them to another column."
            Case 5
                HowToPlayText.Text = "If you ever have an empty column, you can place a King there or any sequential stack with a King at its head."
            Case 6
                HowToPlayText.Text = "If you get stuck, tap the deck in the upper-left corner to draw more cards. If you exhaust the deck, you can deal it again by tapping the empty deck space."
            Case 7
                HowToPlayText.Text = "You can move cards by clicking and dragging them to the desired spot. You can also double-click on a card with the right mouse button to automatically move it to a foundation pile."
            Case 8
                HowToPlayText.Text = "Good luck and have fun! :)"
        End Select
    End Function

    Private Sub HelpToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HelpToolStripMenuItem.Click
        currentPage = 1
        BackButton.Enabled = False
        NextButton.Enabled = True
        initText()
        isHelp = True
        HowToPlayPanel.Visible = True
        GameTimer.Stop()
        HowToPlayPanel.BringToFront()
    End Sub

    Private Sub SolveButton_Click(sender As Object, e As EventArgs) Handles SolveButton.Click
        For col As Integer = 0 To 6
            For row As Integer = 0 To indexLastOpenCard(col)
                'CType(Me.Controls(tableau(row, col)), PictureBox).Visible = False
                score = score + TO_FOUNDATION_POINTS
                ' debug
                Debug.WriteLine("socre: " + Convert.ToString(score))
                '
            Next
        Next

        ' for future : can add some animation here 

        congratulationsScreen()
    End Sub

    Private Sub currentStateCheck(fromFunc As String)
        Debug.WriteLine("From " + fromFunc)
        Debug.WriteLine("Tableau:")
        For i As Integer = 0 To 17
            For j As Integer = 0 To 6
                Debug.Write(tableau(i, j) + " ")
            Next
            Debug.WriteLine(".")
        Next

        For i As Integer = 0 To 6
            Debug.WriteLine("col: " + Convert.ToString(i) + " last row: " + Convert.ToString(indexLastOpenCard(i)) + " first row: " + Convert.ToString(indexFirstOpenCard(i)))
        Next

        Debug.WriteLine("Draw Pile:")
        For j As Integer = 0 To remainingDrawCards - 1
            Debug.Write(drawPile(j) + " ")
        Next
        Debug.WriteLine(".")

        Debug.WriteLine(movedCard + " was being moved")
        Debug.WriteLine("Remaining cards drawpile: " + Convert.ToString(remainingDrawCards))
        Debug.WriteLine("Draw pile update. drawcardindex: " + Convert.ToString(drawCardIndex))
        If drawCardIndex > -1 Then
            Debug.WriteLine(drawPile(drawCardIndex) + " is open in stock")
        End If

        Debug.WriteLine("Foundation piles:")
        For j As Integer = 0 To 3
            Debug.Write(foundationPiles(j) + " ")
        Next
        Debug.WriteLine(".")
    End Sub


End Class
