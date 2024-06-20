<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GameForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GameForm))
        mouseTimer = New Timer(components)
        Menu = New MenuStrip()
        GameToolStripMenuItem = New ToolStripMenuItem()
        NewGameToolStripMenuItem = New ToolStripMenuItem()
        PauseGameToolStripMenuItem = New ToolStripMenuItem()
        QuitGameToolStripMenuItem = New ToolStripMenuItem()
        ViewToolStripMenuItem = New ToolStripMenuItem()
        ChangeDeckToolStripMenuItem = New ToolStripMenuItem()
        ClassicToolStripMenuItem = New ToolStripMenuItem()
        VintageToolStripMenuItem = New ToolStripMenuItem()
        UwUToolStripMenuItem = New ToolStripMenuItem()
        ChangeBackgroundToolStripMenuItem = New ToolStripMenuItem()
        HelpToolStripMenuItem = New ToolStripMenuItem()
        ColorDialog1 = New ColorDialog()
        GameTimer = New Timer(components)
        TimerLabel = New Label()
        ScoreLabel = New Label()
        ScoreNameLabel = New Label()
        TimeNameLabel = New Label()
        SolveButton = New Button()
        HowToPlayPanel = New Panel()
        PageLabel = New Label()
        CloseButton = New Button()
        NextButton = New Button()
        BackButton = New Button()
        HowToPlayText = New Label()
        Label1 = New Label()
        Menu.SuspendLayout()
        HowToPlayPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' mouseTimer
        ' 
        ' 
        ' Menu
        ' 
        Menu.BackColor = Color.Ivory
        Menu.ImageScalingSize = New Size(20, 20)
        Menu.Items.AddRange(New ToolStripItem() {GameToolStripMenuItem, ViewToolStripMenuItem, HelpToolStripMenuItem})
        Menu.Location = New Point(0, 0)
        Menu.Name = "Menu"
        Menu.Size = New Size(1012, 24)
        Menu.TabIndex = 1
        Menu.Text = "MenuStrip1"
        ' 
        ' GameToolStripMenuItem
        ' 
        GameToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {NewGameToolStripMenuItem, PauseGameToolStripMenuItem, QuitGameToolStripMenuItem})
        GameToolStripMenuItem.Font = New Font("Copperplate Gothic Bold", 9F, FontStyle.Regular, GraphicsUnit.Point)
        GameToolStripMenuItem.Name = "GameToolStripMenuItem"
        GameToolStripMenuItem.Size = New Size(66, 20)
        GameToolStripMenuItem.Text = "Game"
        ' 
        ' NewGameToolStripMenuItem
        ' 
        NewGameToolStripMenuItem.Name = "NewGameToolStripMenuItem"
        NewGameToolStripMenuItem.Size = New Size(187, 26)
        NewGameToolStripMenuItem.Text = "New Game"
        ' 
        ' PauseGameToolStripMenuItem
        ' 
        PauseGameToolStripMenuItem.Name = "PauseGameToolStripMenuItem"
        PauseGameToolStripMenuItem.Size = New Size(187, 26)
        PauseGameToolStripMenuItem.Text = "Pause Game"
        ' 
        ' QuitGameToolStripMenuItem
        ' 
        QuitGameToolStripMenuItem.Name = "QuitGameToolStripMenuItem"
        QuitGameToolStripMenuItem.Size = New Size(187, 26)
        QuitGameToolStripMenuItem.Text = "Quit Game"
        ' 
        ' ViewToolStripMenuItem
        ' 
        ViewToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ChangeDeckToolStripMenuItem, ChangeBackgroundToolStripMenuItem})
        ViewToolStripMenuItem.Font = New Font("Copperplate Gothic Bold", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ViewToolStripMenuItem.Name = "ViewToolStripMenuItem"
        ViewToolStripMenuItem.Size = New Size(61, 20)
        ViewToolStripMenuItem.Text = "View"
        ' 
        ' ChangeDeckToolStripMenuItem
        ' 
        ChangeDeckToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ClassicToolStripMenuItem, VintageToolStripMenuItem, UwUToolStripMenuItem})
        ChangeDeckToolStripMenuItem.Name = "ChangeDeckToolStripMenuItem"
        ChangeDeckToolStripMenuItem.Size = New Size(264, 26)
        ChangeDeckToolStripMenuItem.Text = "Change Deck"
        ' 
        ' ClassicToolStripMenuItem
        ' 
        ClassicToolStripMenuItem.Name = "ClassicToolStripMenuItem"
        ClassicToolStripMenuItem.Size = New Size(155, 26)
        ClassicToolStripMenuItem.Text = "Classic"
        ' 
        ' VintageToolStripMenuItem
        ' 
        VintageToolStripMenuItem.Name = "VintageToolStripMenuItem"
        VintageToolStripMenuItem.Size = New Size(155, 26)
        VintageToolStripMenuItem.Text = "Vintage"
        ' 
        ' UwUToolStripMenuItem
        ' 
        UwUToolStripMenuItem.Name = "UwUToolStripMenuItem"
        UwUToolStripMenuItem.Size = New Size(155, 26)
        UwUToolStripMenuItem.Text = "UwU"
        ' 
        ' ChangeBackgroundToolStripMenuItem
        ' 
        ChangeBackgroundToolStripMenuItem.Name = "ChangeBackgroundToolStripMenuItem"
        ChangeBackgroundToolStripMenuItem.Size = New Size(264, 26)
        ChangeBackgroundToolStripMenuItem.Text = "Change Background"
        ' 
        ' HelpToolStripMenuItem
        ' 
        HelpToolStripMenuItem.Font = New Font("Copperplate Gothic Bold", 9F, FontStyle.Regular, GraphicsUnit.Point)
        HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        HelpToolStripMenuItem.Size = New Size(63, 20)
        HelpToolStripMenuItem.Text = "Help"
        ' 
        ' GameTimer
        ' 
        GameTimer.Interval = 1050
        ' 
        ' TimerLabel
        ' 
        TimerLabel.AutoSize = True
        TimerLabel.BackColor = Color.Transparent
        TimerLabel.FlatStyle = FlatStyle.Popup
        TimerLabel.Font = New Font("Copperplate Gothic Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        TimerLabel.Location = New Point(314, 203)
        TimerLabel.Name = "TimerLabel"
        TimerLabel.Size = New Size(122, 25)
        TimerLabel.TabIndex = 2
        TimerLabel.Text = "00:00:00"
        ' 
        ' ScoreLabel
        ' 
        ScoreLabel.AutoSize = True
        ScoreLabel.BackColor = Color.Transparent
        ScoreLabel.FlatStyle = FlatStyle.Popup
        ScoreLabel.Font = New Font("Copperplate Gothic Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        ScoreLabel.Location = New Point(344, 109)
        ScoreLabel.Name = "ScoreLabel"
        ScoreLabel.Size = New Size(60, 25)
        ScoreLabel.TabIndex = 3
        ScoreLabel.Text = "000"
        ' 
        ' ScoreNameLabel
        ' 
        ScoreNameLabel.AutoSize = True
        ScoreNameLabel.BackColor = Color.Transparent
        ScoreNameLabel.FlatStyle = FlatStyle.Popup
        ScoreNameLabel.Font = New Font("Copperplate Gothic Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        ScoreNameLabel.ForeColor = Color.Gold
        ScoreNameLabel.Location = New Point(326, 72)
        ScoreNameLabel.Name = "ScoreNameLabel"
        ScoreNameLabel.Size = New Size(92, 25)
        ScoreNameLabel.TabIndex = 4
        ScoreNameLabel.Text = "Score"
        ' 
        ' TimeNameLabel
        ' 
        TimeNameLabel.AutoSize = True
        TimeNameLabel.BackColor = Color.Transparent
        TimeNameLabel.FlatStyle = FlatStyle.Popup
        TimeNameLabel.Font = New Font("Copperplate Gothic Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        TimeNameLabel.ForeColor = Color.Gold
        TimeNameLabel.Location = New Point(335, 164)
        TimeNameLabel.Name = "TimeNameLabel"
        TimeNameLabel.Size = New Size(69, 25)
        TimeNameLabel.TabIndex = 5
        TimeNameLabel.Text = "Time"
        ' 
        ' SolveButton
        ' 
        SolveButton.BackColor = Color.OliveDrab
        SolveButton.Cursor = Cursors.Hand
        SolveButton.Font = New Font("Copperplate Gothic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        SolveButton.ForeColor = Color.Gold
        SolveButton.Location = New Point(179, 124)
        SolveButton.Name = "SolveButton"
        SolveButton.Size = New Size(116, 51)
        SolveButton.TabIndex = 6
        SolveButton.Text = "Solve"
        SolveButton.UseVisualStyleBackColor = False
        SolveButton.Visible = False
        ' 
        ' HowToPlayPanel
        ' 
        HowToPlayPanel.BackColor = Color.Wheat
        HowToPlayPanel.BorderStyle = BorderStyle.FixedSingle
        HowToPlayPanel.Controls.Add(PageLabel)
        HowToPlayPanel.Controls.Add(CloseButton)
        HowToPlayPanel.Controls.Add(NextButton)
        HowToPlayPanel.Controls.Add(BackButton)
        HowToPlayPanel.Controls.Add(HowToPlayText)
        HowToPlayPanel.Controls.Add(Label1)
        HowToPlayPanel.Location = New Point(73, 533)
        HowToPlayPanel.Name = "HowToPlayPanel"
        HowToPlayPanel.Size = New Size(873, 278)
        HowToPlayPanel.TabIndex = 7
        ' 
        ' PageLabel
        ' 
        PageLabel.BackColor = Color.Transparent
        PageLabel.FlatStyle = FlatStyle.Popup
        PageLabel.Font = New Font("Copperplate Gothic Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        PageLabel.Location = New Point(35, 206)
        PageLabel.Name = "PageLabel"
        PageLabel.Size = New Size(66, 46)
        PageLabel.TabIndex = 10
        PageLabel.Text = "1/8"
        PageLabel.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' CloseButton
        ' 
        CloseButton.BackColor = Color.BurlyWood
        CloseButton.Cursor = Cursors.Hand
        CloseButton.Font = New Font("Copperplate Gothic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        CloseButton.ForeColor = SystemColors.ActiveCaptionText
        CloseButton.Location = New Point(735, 206)
        CloseButton.Name = "CloseButton"
        CloseButton.Size = New Size(116, 51)
        CloseButton.TabIndex = 9
        CloseButton.Text = "Close"
        CloseButton.UseVisualStyleBackColor = False
        ' 
        ' NextButton
        ' 
        NextButton.BackColor = Color.BurlyWood
        NextButton.Cursor = Cursors.Hand
        NextButton.Font = New Font("Copperplate Gothic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        NextButton.ForeColor = SystemColors.ActiveCaptionText
        NextButton.Location = New Point(602, 206)
        NextButton.Name = "NextButton"
        NextButton.Size = New Size(116, 51)
        NextButton.TabIndex = 8
        NextButton.Text = "Next"
        NextButton.UseVisualStyleBackColor = False
        ' 
        ' BackButton
        ' 
        BackButton.BackColor = Color.BurlyWood
        BackButton.Cursor = Cursors.Hand
        BackButton.Enabled = False
        BackButton.Font = New Font("Copperplate Gothic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        BackButton.ForeColor = SystemColors.ActiveCaptionText
        BackButton.Location = New Point(470, 206)
        BackButton.Name = "BackButton"
        BackButton.Size = New Size(116, 51)
        BackButton.TabIndex = 7
        BackButton.Text = "Back"
        BackButton.UseVisualStyleBackColor = False
        ' 
        ' HowToPlayText
        ' 
        HowToPlayText.BackColor = Color.Transparent
        HowToPlayText.FlatStyle = FlatStyle.Popup
        HowToPlayText.Font = New Font("Copperplate Gothic Bold", 13.8F, FontStyle.Regular, GraphicsUnit.Point)
        HowToPlayText.Location = New Point(35, 71)
        HowToPlayText.Name = "HowToPlayText"
        HowToPlayText.Size = New Size(816, 132)
        HowToPlayText.TabIndex = 5
        HowToPlayText.Text = resources.GetString("HowToPlayText.Text")
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.FlatStyle = FlatStyle.Popup
        Label1.Font = New Font("Copperplate Gothic Bold", 16.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(35, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(205, 31)
        Label1.TabIndex = 4
        Label1.Text = "How to play"
        ' 
        ' GameForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.ForestGreen
        ClientSize = New Size(1012, 1036)
        Controls.Add(HowToPlayPanel)
        Controls.Add(SolveButton)
        Controls.Add(TimeNameLabel)
        Controls.Add(ScoreNameLabel)
        Controls.Add(ScoreLabel)
        Controls.Add(TimerLabel)
        Controls.Add(Menu)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = Menu
        MinimizeBox = False
        Name = "GameForm"
        StartPosition = FormStartPosition.Manual
        Text = "Solitaire by Maria Baleva"
        Menu.ResumeLayout(False)
        Menu.PerformLayout()
        HowToPlayPanel.ResumeLayout(False)
        HowToPlayPanel.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents mouseTimer As Timer
    Friend WithEvents Menu As MenuStrip
    Friend WithEvents GameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents NewGameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PauseGameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitGameToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ViewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeDeckToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ClassicToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents VintageToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UwUToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ChangeBackgroundToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents GameTimer As Timer
    Friend WithEvents TimerLabel As Label
    Friend WithEvents ScoreLabel As Label
    Friend WithEvents ScoreNameLabel As Label
    Friend WithEvents TimeNameLabel As Label
    Friend WithEvents SolveButton As Button
    Friend WithEvents HowToPlayPanel As Panel
    Friend WithEvents CloseButton As Button
    Friend WithEvents NextButton As Button
    Friend WithEvents BackButton As Button
    Friend WithEvents HowToPlayText As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PageLabel As Label
End Class
