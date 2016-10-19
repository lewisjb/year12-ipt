<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Species_Create
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.nupMutation = New System.Windows.Forms.NumericUpDown()
        Me.cbCrossovers = New System.Windows.Forms.CheckBox()
        Me.cbHits = New System.Windows.Forms.CheckBox()
        Me.cbOwnShip = New System.Windows.Forms.CheckBox()
        Me.cbEnemyShots = New System.Windows.Forms.CheckBox()
        Me.cbEnemyHits = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        CType(Me.nupMutation, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(62, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Create A Species"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Mutation Rate (%)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Enable Crossovers?"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Inputs:"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(121, 31)
        Me.txtName.MaxLength = 15
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(123, 20)
        Me.txtName.TabIndex = 5
        '
        'nupMutation
        '
        Me.nupMutation.DecimalPlaces = 2
        Me.nupMutation.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.nupMutation.Location = New System.Drawing.Point(121, 57)
        Me.nupMutation.Name = "nupMutation"
        Me.nupMutation.Size = New System.Drawing.Size(123, 20)
        Me.nupMutation.TabIndex = 6
        Me.nupMutation.Value = New Decimal(New Integer() {8, 0, 0, 0})
        '
        'cbCrossovers
        '
        Me.cbCrossovers.AutoSize = True
        Me.cbCrossovers.Location = New System.Drawing.Point(121, 86)
        Me.cbCrossovers.Name = "cbCrossovers"
        Me.cbCrossovers.Size = New System.Drawing.Size(44, 17)
        Me.cbCrossovers.TabIndex = 7
        Me.cbCrossovers.Text = "Yes"
        Me.cbCrossovers.UseVisualStyleBackColor = True
        '
        'cbHits
        '
        Me.cbHits.AutoSize = True
        Me.cbHits.Location = New System.Drawing.Point(22, 133)
        Me.cbHits.Name = "cbHits"
        Me.cbHits.Size = New System.Drawing.Size(44, 17)
        Me.cbHits.TabIndex = 8
        Me.cbHits.Text = "Hits"
        Me.cbHits.UseVisualStyleBackColor = True
        '
        'cbOwnShip
        '
        Me.cbOwnShip.AutoSize = True
        Me.cbOwnShip.Location = New System.Drawing.Point(22, 156)
        Me.cbOwnShip.Name = "cbOwnShip"
        Me.cbOwnShip.Size = New System.Drawing.Size(117, 17)
        Me.cbOwnShip.TabIndex = 9
        Me.cbOwnShip.Text = "Own Ship Positions"
        Me.cbOwnShip.UseVisualStyleBackColor = True
        '
        'cbEnemyShots
        '
        Me.cbEnemyShots.AutoSize = True
        Me.cbEnemyShots.Location = New System.Drawing.Point(163, 133)
        Me.cbEnemyShots.Name = "cbEnemyShots"
        Me.cbEnemyShots.Size = New System.Drawing.Size(88, 17)
        Me.cbEnemyShots.TabIndex = 11
        Me.cbEnemyShots.Text = "Enemy Shots"
        Me.cbEnemyShots.UseVisualStyleBackColor = True
        '
        'cbEnemyHits
        '
        Me.cbEnemyHits.AutoSize = True
        Me.cbEnemyHits.Location = New System.Drawing.Point(163, 156)
        Me.cbEnemyHits.Name = "cbEnemyHits"
        Me.cbEnemyHits.Size = New System.Drawing.Size(79, 17)
        Me.cbEnemyHits.TabIndex = 12
        Me.cbEnemyHits.Text = "Enemy Hits"
        Me.cbEnemyHits.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(17, 179)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(227, 45)
        Me.btnSave.TabIndex = 13
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(-1, -1)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(52, 25)
        Me.btnBack.TabIndex = 14
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Form_Species_Create
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 227)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnSave)
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
        Me.Name = "Form_Species_Create"
        Me.Text = "Create Species"
        CType(Me.nupMutation, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents nupMutation As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbCrossovers As System.Windows.Forms.CheckBox
    Friend WithEvents cbHits As System.Windows.Forms.CheckBox
    Friend WithEvents cbOwnShip As System.Windows.Forms.CheckBox
    Friend WithEvents cbEnemyShots As System.Windows.Forms.CheckBox
    Friend WithEvents cbEnemyHits As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
