<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Species_Delete
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
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.cbEnemyHits = New System.Windows.Forms.CheckBox()
        Me.cbEnemyShots = New System.Windows.Forms.CheckBox()
        Me.cbOwnShip = New System.Windows.Forms.CheckBox()
        Me.cbHits = New System.Windows.Forms.CheckBox()
        Me.cbCrossovers = New System.Windows.Forms.CheckBox()
        Me.nupMutation = New System.Windows.Forms.NumericUpDown()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.nupGeneration = New System.Windows.Forms.NumericUpDown()
        Me.btnBack = New System.Windows.Forms.Button()
        CType(Me.nupMutation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupGeneration, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(19, 291)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(227, 45)
        Me.btnDelete.TabIndex = 26
        Me.btnDelete.Text = "DELETE"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'cbEnemyHits
        '
        Me.cbEnemyHits.AutoSize = True
        Me.cbEnemyHits.Enabled = False
        Me.cbEnemyHits.Location = New System.Drawing.Point(165, 268)
        Me.cbEnemyHits.Name = "cbEnemyHits"
        Me.cbEnemyHits.Size = New System.Drawing.Size(79, 17)
        Me.cbEnemyHits.TabIndex = 25
        Me.cbEnemyHits.Text = "Enemy Hits"
        Me.cbEnemyHits.UseVisualStyleBackColor = True
        '
        'cbEnemyShots
        '
        Me.cbEnemyShots.AutoSize = True
        Me.cbEnemyShots.Enabled = False
        Me.cbEnemyShots.Location = New System.Drawing.Point(165, 245)
        Me.cbEnemyShots.Name = "cbEnemyShots"
        Me.cbEnemyShots.Size = New System.Drawing.Size(88, 17)
        Me.cbEnemyShots.TabIndex = 24
        Me.cbEnemyShots.Text = "Enemy Shots"
        Me.cbEnemyShots.UseVisualStyleBackColor = True
        '
        'cbOwnShip
        '
        Me.cbOwnShip.AutoSize = True
        Me.cbOwnShip.Enabled = False
        Me.cbOwnShip.Location = New System.Drawing.Point(24, 268)
        Me.cbOwnShip.Name = "cbOwnShip"
        Me.cbOwnShip.Size = New System.Drawing.Size(117, 17)
        Me.cbOwnShip.TabIndex = 23
        Me.cbOwnShip.Text = "Own Ship Positions"
        Me.cbOwnShip.UseVisualStyleBackColor = True
        '
        'cbHits
        '
        Me.cbHits.AutoSize = True
        Me.cbHits.Enabled = False
        Me.cbHits.Location = New System.Drawing.Point(24, 245)
        Me.cbHits.Name = "cbHits"
        Me.cbHits.Size = New System.Drawing.Size(44, 17)
        Me.cbHits.TabIndex = 22
        Me.cbHits.Text = "Hits"
        Me.cbHits.UseVisualStyleBackColor = True
        '
        'cbCrossovers
        '
        Me.cbCrossovers.AutoSize = True
        Me.cbCrossovers.Enabled = False
        Me.cbCrossovers.Location = New System.Drawing.Point(123, 198)
        Me.cbCrossovers.Name = "cbCrossovers"
        Me.cbCrossovers.Size = New System.Drawing.Size(44, 17)
        Me.cbCrossovers.TabIndex = 21
        Me.cbCrossovers.Text = "Yes"
        Me.cbCrossovers.UseVisualStyleBackColor = True
        '
        'nupMutation
        '
        Me.nupMutation.DecimalPlaces = 2
        Me.nupMutation.Enabled = False
        Me.nupMutation.Location = New System.Drawing.Point(123, 169)
        Me.nupMutation.Name = "nupMutation"
        Me.nupMutation.Size = New System.Drawing.Size(123, 20)
        Me.nupMutation.TabIndex = 20
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(123, 143)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(123, 20)
        Me.txtName.TabIndex = 19
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 224)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Inputs:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Enable Crossovers?"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 172)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Mutation Rate (%)"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(67, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(179, 25)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Delete A Species"
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(17, 37)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(227, 55)
        Me.btnLoad.TabIndex = 27
        Me.btnLoad.Text = "LOAD SPECIES TO DELETE"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 95)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(257, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Below is the information about the species you chose"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(59, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Generation"
        '
        'nupGeneration
        '
        Me.nupGeneration.Enabled = False
        Me.nupGeneration.Location = New System.Drawing.Point(123, 118)
        Me.nupGeneration.Name = "nupGeneration"
        Me.nupGeneration.Size = New System.Drawing.Size(123, 20)
        Me.nupGeneration.TabIndex = 30
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(-1, -1)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(52, 25)
        Me.btnBack.TabIndex = 31
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Form_Species_Delete
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 339)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.nupGeneration)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.cbEnemyHits)
        Me.Controls.Add(Me.cbEnemyShots)
        Me.Controls.Add(Me.cbOwnShip)
        Me.Controls.Add(Me.cbHits)
        Me.Controls.Add(Me.cbCrossovers)
        Me.Controls.Add(Me.nupMutation)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form_Species_Delete"
        Me.Text = "Delete a Species"
        CType(Me.nupMutation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupGeneration, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents cbEnemyHits As System.Windows.Forms.CheckBox
    Friend WithEvents cbEnemyShots As System.Windows.Forms.CheckBox
    Friend WithEvents cbOwnShip As System.Windows.Forms.CheckBox
    Friend WithEvents cbHits As System.Windows.Forms.CheckBox
    Friend WithEvents cbCrossovers As System.Windows.Forms.CheckBox
    Friend WithEvents nupMutation As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents nupGeneration As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
