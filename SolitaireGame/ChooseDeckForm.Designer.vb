<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChooseDeckForm
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
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(ChooseDeckForm))
        GroupBox1 = New GroupBox()
        DeckCard = New PictureBox()
        PreviewButton = New Button()
        PreviewCard = New PictureBox()
        Label2 = New Label()
        Label1 = New Label()
        RankComboBox = New ComboBox()
        SuitComboBox = New ComboBox()
        UwURadioButton = New RadioButton()
        VintageRadioButton = New RadioButton()
        ClassicRadioButton = New RadioButton()
        PictureBox2 = New PictureBox()
        StartButton = New Button()
        GroupBox1.SuspendLayout()
        CType(DeckCard, ComponentModel.ISupportInitialize).BeginInit()
        CType(PreviewCard, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.Transparent
        GroupBox1.Controls.Add(DeckCard)
        GroupBox1.Controls.Add(PreviewButton)
        GroupBox1.Controls.Add(PreviewCard)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(RankComboBox)
        GroupBox1.Controls.Add(SuitComboBox)
        GroupBox1.Controls.Add(UwURadioButton)
        GroupBox1.Controls.Add(VintageRadioButton)
        GroupBox1.Controls.Add(ClassicRadioButton)
        GroupBox1.Font = New Font("Copperplate Gothic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        GroupBox1.ForeColor = Color.Gold
        GroupBox1.Location = New Point(81, 175)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(829, 266)
        GroupBox1.TabIndex = 2
        GroupBox1.TabStop = False
        GroupBox1.Text = "Choose Deck"
        ' 
        ' DeckCard
        ' 
        DeckCard.Location = New Point(647, 29)
        DeckCard.Name = "DeckCard"
        DeckCard.Size = New Size(145, 101)
        DeckCard.TabIndex = 13
        DeckCard.TabStop = False
        ' 
        ' PreviewButton
        ' 
        PreviewButton.BackColor = Color.OliveDrab
        PreviewButton.Cursor = Cursors.Hand
        PreviewButton.Font = New Font("Copperplate Gothic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        PreviewButton.ForeColor = Color.Gold
        PreviewButton.Location = New Point(337, 184)
        PreviewButton.Name = "PreviewButton"
        PreviewButton.Size = New Size(151, 37)
        PreviewButton.TabIndex = 12
        PreviewButton.Text = "Preview"
        PreviewButton.UseVisualStyleBackColor = False
        ' 
        ' PreviewCard
        ' 
        PreviewCard.Location = New Point(551, 51)
        PreviewCard.Name = "PreviewCard"
        PreviewCard.Size = New Size(145, 101)
        PreviewCard.TabIndex = 11
        PreviewCard.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(242, 123)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 23)
        Label2.TabIndex = 10
        Label2.Text = "Rank"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Copperplate Gothic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(258, 59)
        Label1.Name = "Label1"
        Label1.Size = New Size(55, 23)
        Label1.TabIndex = 9
        Label1.Text = "Suit"
        ' 
        ' RankComboBox
        ' 
        RankComboBox.BackColor = Color.Beige
        RankComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        RankComboBox.FormattingEnabled = True
        RankComboBox.Items.AddRange(New Object() {"Ace", "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King"})
        RankComboBox.Location = New Point(337, 121)
        RankComboBox.Name = "RankComboBox"
        RankComboBox.Size = New Size(151, 31)
        RankComboBox.TabIndex = 8
        ' 
        ' SuitComboBox
        ' 
        SuitComboBox.BackColor = Color.Beige
        SuitComboBox.DropDownStyle = ComboBoxStyle.DropDownList
        SuitComboBox.FormattingEnabled = True
        SuitComboBox.Items.AddRange(New Object() {"Spades ♠", "Hearts ♥", "Clubs ♣", "Diamonds ♦"})
        SuitComboBox.Location = New Point(337, 56)
        SuitComboBox.Name = "SuitComboBox"
        SuitComboBox.Size = New Size(151, 31)
        SuitComboBox.TabIndex = 5
        ' 
        ' UwURadioButton
        ' 
        UwURadioButton.AutoSize = True
        UwURadioButton.Cursor = Cursors.Hand
        UwURadioButton.Location = New Point(38, 185)
        UwURadioButton.Name = "UwURadioButton"
        UwURadioButton.Size = New Size(82, 27)
        UwURadioButton.TabIndex = 7
        UwURadioButton.TabStop = True
        UwURadioButton.Text = "UwU"
        UwURadioButton.UseVisualStyleBackColor = True
        ' 
        ' VintageRadioButton
        ' 
        VintageRadioButton.AutoSize = True
        VintageRadioButton.Cursor = Cursors.Hand
        VintageRadioButton.Location = New Point(38, 122)
        VintageRadioButton.Name = "VintageRadioButton"
        VintageRadioButton.Size = New Size(119, 27)
        VintageRadioButton.TabIndex = 6
        VintageRadioButton.TabStop = True
        VintageRadioButton.Text = "Vintage"
        VintageRadioButton.UseVisualStyleBackColor = True
        ' 
        ' ClassicRadioButton
        ' 
        ClassicRadioButton.AutoSize = True
        ClassicRadioButton.Cursor = Cursors.Hand
        ClassicRadioButton.Location = New Point(38, 58)
        ClassicRadioButton.Name = "ClassicRadioButton"
        ClassicRadioButton.Size = New Size(117, 27)
        ClassicRadioButton.TabIndex = 5
        ClassicRadioButton.TabStop = True
        ClassicRadioButton.Text = "Classic"
        ClassicRadioButton.UseVisualStyleBackColor = True
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Image = My.Resources.Resources.sol
        PictureBox2.Location = New Point(339, 12)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(304, 157)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 3
        PictureBox2.TabStop = False
        ' 
        ' StartButton
        ' 
        StartButton.BackColor = Color.OliveDrab
        StartButton.Cursor = Cursors.Hand
        StartButton.Font = New Font("Copperplate Gothic Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        StartButton.ForeColor = Color.Gold
        StartButton.Location = New Point(404, 463)
        StartButton.Name = "StartButton"
        StartButton.Size = New Size(184, 51)
        StartButton.TabIndex = 4
        StartButton.Text = "PLAY"
        StartButton.UseVisualStyleBackColor = False
        ' 
        ' ChooseDeckForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.bg5
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(982, 653)
        Controls.Add(StartButton)
        Controls.Add(PictureBox2)
        Controls.Add(GroupBox1)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "ChooseDeckForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Choose Deck"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(DeckCard, ComponentModel.ISupportInitialize).EndInit()
        CType(PreviewCard, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents StartButton As Button
    Friend WithEvents PreviewButton As Button
    Friend WithEvents PreviewCard As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents RankComboBox As ComboBox
    Friend WithEvents SuitComboBox As ComboBox
    Friend WithEvents UwURadioButton As RadioButton
    Friend WithEvents VintageRadioButton As RadioButton
    Friend WithEvents ClassicRadioButton As RadioButton
    Friend WithEvents DeckCard As PictureBox
End Class
