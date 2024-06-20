<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainMenuForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMenuForm))
        PictureBox2 = New PictureBox()
        NewGameButton = New Button()
        ScoreboardButton = New Button()
        QuitButton = New Button()
        Label1 = New Label()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Image = My.Resources.Resources.sol
        PictureBox2.Location = New Point(-2, -22)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(982, 419)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' NewGameButton
        ' 
        NewGameButton.BackColor = Color.OliveDrab
        NewGameButton.Cursor = Cursors.Hand
        NewGameButton.Font = New Font("Copperplate Gothic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        NewGameButton.ForeColor = Color.Gold
        NewGameButton.Location = New Point(396, 322)
        NewGameButton.Name = "NewGameButton"
        NewGameButton.Size = New Size(184, 51)
        NewGameButton.TabIndex = 2
        NewGameButton.Text = "New Game"
        NewGameButton.UseVisualStyleBackColor = False
        ' 
        ' ScoreboardButton
        ' 
        ScoreboardButton.BackColor = Color.OliveDrab
        ScoreboardButton.Cursor = Cursors.Hand
        ScoreboardButton.Font = New Font("Copperplate Gothic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ScoreboardButton.ForeColor = Color.Gold
        ScoreboardButton.Location = New Point(396, 392)
        ScoreboardButton.Name = "ScoreboardButton"
        ScoreboardButton.Size = New Size(184, 51)
        ScoreboardButton.TabIndex = 3
        ScoreboardButton.Text = "Scoreboard"
        ScoreboardButton.UseVisualStyleBackColor = False
        ' 
        ' QuitButton
        ' 
        QuitButton.BackColor = Color.OliveDrab
        QuitButton.Cursor = Cursors.Hand
        QuitButton.Font = New Font("Copperplate Gothic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        QuitButton.ForeColor = Color.Gold
        QuitButton.Location = New Point(396, 462)
        QuitButton.Name = "QuitButton"
        QuitButton.Size = New Size(184, 51)
        QuitButton.TabIndex = 4
        QuitButton.Text = "Quit"
        QuitButton.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Copperplate Gothic Bold", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.DarkGoldenrod
        Label1.Location = New Point(749, 511)
        Label1.Name = "Label1"
        Label1.Size = New Size(221, 19)
        Label1.TabIndex = 5
        Label1.Text = "Made by Maria Baleva"
        ' 
        ' MainMenuForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.bg5
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(982, 653)
        Controls.Add(Label1)
        Controls.Add(QuitButton)
        Controls.Add(ScoreboardButton)
        Controls.Add(NewGameButton)
        Controls.Add(PictureBox2)
        Font = New Font("Vladimir Script", 9F, FontStyle.Regular, GraphicsUnit.Point)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "MainMenuForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Solitaire by Maria Baleva"
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents NewGameButton As Button
    Friend WithEvents ScoreboardButton As Button
    Friend WithEvents QuitButton As Button
    Friend WithEvents Label1 As Label
End Class
