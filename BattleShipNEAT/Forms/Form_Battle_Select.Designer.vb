<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Battle_Select
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
        Me.btnSpecies1 = New System.Windows.Forms.Button()
        Me.btnSpecies2 = New System.Windows.Forms.Button()
        Me.lblSpecies1 = New System.Windows.Forms.Label()
        Me.lblSpecies2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnBattle = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnSpecies1
        '
        Me.btnSpecies1.Location = New System.Drawing.Point(12, 70)
        Me.btnSpecies1.Name = "btnSpecies1"
        Me.btnSpecies1.Size = New System.Drawing.Size(112, 53)
        Me.btnSpecies1.TabIndex = 0
        Me.btnSpecies1.Text = "SELECT SPECIES"
        Me.btnSpecies1.UseVisualStyleBackColor = True
        '
        'btnSpecies2
        '
        Me.btnSpecies2.Location = New System.Drawing.Point(160, 70)
        Me.btnSpecies2.Name = "btnSpecies2"
        Me.btnSpecies2.Size = New System.Drawing.Size(112, 53)
        Me.btnSpecies2.TabIndex = 1
        Me.btnSpecies2.Text = "SELECT SPECIES"
        Me.btnSpecies2.UseVisualStyleBackColor = True
        '
        'lblSpecies1
        '
        Me.lblSpecies1.AutoSize = True
        Me.lblSpecies1.Location = New System.Drawing.Point(14, 54)
        Me.lblSpecies1.Name = "lblSpecies1"
        Me.lblSpecies1.Size = New System.Drawing.Size(71, 13)
        Me.lblSpecies1.TabIndex = 2
        Me.lblSpecies1.Text = "Species: N/A"
        '
        'lblSpecies2
        '
        Me.lblSpecies2.AutoSize = True
        Me.lblSpecies2.Location = New System.Drawing.Point(157, 54)
        Me.lblSpecies2.Name = "lblSpecies2"
        Me.lblSpecies2.Size = New System.Drawing.Size(71, 13)
        Me.lblSpecies2.TabIndex = 3
        Me.lblSpecies2.Text = "Species: N/A"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(60, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(212, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "PICK THE SPECIES"
        '
        'btnBattle
        '
        Me.btnBattle.Enabled = False
        Me.btnBattle.Location = New System.Drawing.Point(12, 129)
        Me.btnBattle.Name = "btnBattle"
        Me.btnBattle.Size = New System.Drawing.Size(260, 39)
        Me.btnBattle.TabIndex = 5
        Me.btnBattle.Text = "BATTLE"
        Me.btnBattle.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(-1, -1)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(52, 25)
        Me.btnBack.TabIndex = 6
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'Form_Battle_Select
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 180)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnBattle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblSpecies2)
        Me.Controls.Add(Me.lblSpecies1)
        Me.Controls.Add(Me.btnSpecies2)
        Me.Controls.Add(Me.btnSpecies1)
        Me.Name = "Form_Battle_Select"
        Me.Text = "Pick Species to Battle"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSpecies1 As System.Windows.Forms.Button
    Friend WithEvents btnSpecies2 As System.Windows.Forms.Button
    Friend WithEvents lblSpecies1 As System.Windows.Forms.Label
    Friend WithEvents lblSpecies2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnBattle As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
End Class
