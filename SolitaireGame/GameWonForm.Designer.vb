<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameWonForm
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(GameWonForm))
        PictureBox2 = New PictureBox()
        CongratulationsLabes2 = New Label()
        TextBox1 = New TextBox()
        EnterButton = New Button()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        TimeLabel = New Label()
        ScoreLabel = New Label()
        PictureBox1 = New PictureBox()
        PictureBox3 = New PictureBox()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Image = My.Resources.Resources.sol
        PictureBox2.Location = New Point(336, 12)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(304, 157)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 4
        PictureBox2.TabStop = False
        ' 
        ' CongratulationsLabes2
        ' 
        CongratulationsLabes2.AutoSize = True
        CongratulationsLabes2.BackColor = Color.Transparent
        CongratulationsLabes2.Font = New Font("Copperplate Gothic Bold", 36F, FontStyle.Regular, GraphicsUnit.Point)
        CongratulationsLabes2.ForeColor = Color.Gold
        CongratulationsLabes2.Location = New Point(43, 183)
        CongratulationsLabes2.Name = "CongratulationsLabes2"
        CongratulationsLabes2.Size = New Size(927, 67)
        CongratulationsLabes2.TabIndex = 9
        CongratulationsLabes2.Text = "C O N G R A T U L A T I O N S"
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Copperplate Gothic Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox1.Location = New Point(373, 397)
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "Enter your name..."
        TextBox1.Size = New Size(228, 28)
        TextBox1.TabIndex = 10
        ' 
        ' EnterButton
        ' 
        EnterButton.BackColor = Color.OliveDrab
        EnterButton.Cursor = Cursors.Hand
        EnterButton.Font = New Font("Copperplate Gothic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        EnterButton.ForeColor = Color.Gold
        EnterButton.Location = New Point(397, 459)
        EnterButton.Name = "EnterButton"
        EnterButton.Size = New Size(184, 51)
        EnterButton.TabIndex = 11
        EnterButton.Text = "Enter"
        EnterButton.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Copperplate Gothic Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.SaddleBrown
        Label1.Location = New Point(373, 273)
        Label1.Name = "Label1"
        Label1.Size = New Size(228, 40)
        Label1.TabIndex = 12
        Label1.Text = "You've won the game!" & vbCrLf & vbCrLf
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Copperplate Gothic Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.SaddleBrown
        Label2.Location = New Point(373, 313)
        Label2.Name = "Label2"
        Label2.Size = New Size(117, 20)
        Label2.TabIndex = 13
        Label2.Text = "Your time: "
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Copperplate Gothic Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.SaddleBrown
        Label3.Location = New Point(373, 349)
        Label3.Name = "Label3"
        Label3.Size = New Size(131, 20)
        Label3.TabIndex = 14
        Label3.Text = "Your score:"
        ' 
        ' TimeLabel
        ' 
        TimeLabel.AutoSize = True
        TimeLabel.BackColor = Color.Transparent
        TimeLabel.Font = New Font("Copperplate Gothic Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        TimeLabel.ForeColor = Color.Gold
        TimeLabel.Location = New Point(502, 313)
        TimeLabel.Name = "TimeLabel"
        TimeLabel.Size = New Size(99, 20)
        TimeLabel.TabIndex = 15
        TimeLabel.Text = "00:00:00"
        TimeLabel.TextAlign = ContentAlignment.TopRight
        ' 
        ' ScoreLabel
        ' 
        ScoreLabel.AutoSize = True
        ScoreLabel.BackColor = Color.Transparent
        ScoreLabel.Font = New Font("Copperplate Gothic Bold", 10.8F, FontStyle.Regular, GraphicsUnit.Point)
        ScoreLabel.ForeColor = Color.Gold
        ScoreLabel.Location = New Point(553, 349)
        ScoreLabel.Name = "ScoreLabel"
        ScoreLabel.Size = New Size(48, 20)
        ScoreLabel.TabIndex = 16
        ScoreLabel.Text = "000"
        ScoreLabel.TextAlign = ContentAlignment.TopRight
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = My.Resources.Resources.fireworks
        PictureBox1.Location = New Point(12, 264)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(333, 246)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 17
        PictureBox1.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = My.Resources.Resources.fireworks
        PictureBox3.Location = New Point(616, 273)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(354, 255)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 18
        PictureBox3.TabStop = False
        ' 
        ' GameWonForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.bg5
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(982, 653)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox1)
        Controls.Add(ScoreLabel)
        Controls.Add(TimeLabel)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(EnterButton)
        Controls.Add(TextBox1)
        Controls.Add(CongratulationsLabes2)
        Controls.Add(PictureBox2)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "GameWonForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Game Won"
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents CongratulationsLabes2 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents EnterButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TimeLabel As Label
    Friend WithEvents ScoreLabel As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
End Class
