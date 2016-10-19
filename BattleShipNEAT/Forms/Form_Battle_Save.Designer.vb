<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Battle_Save
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
        Me.btnSaveSpecies1 = New System.Windows.Forms.Button()
        Me.btnSaveSpecies2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSaveSpecies1
        '
        Me.btnSaveSpecies1.Location = New System.Drawing.Point(12, 63)
        Me.btnSaveSpecies1.Name = "btnSaveSpecies1"
        Me.btnSaveSpecies1.Size = New System.Drawing.Size(260, 55)
        Me.btnSaveSpecies1.TabIndex = 0
        Me.btnSaveSpecies1.UseVisualStyleBackColor = True
        '
        'btnSaveSpecies2
        '
        Me.btnSaveSpecies2.Location = New System.Drawing.Point(12, 129)
        Me.btnSaveSpecies2.Name = "btnSaveSpecies2"
        Me.btnSaveSpecies2.Size = New System.Drawing.Size(260, 55)
        Me.btnSaveSpecies2.TabIndex = 1
        Me.btnSaveSpecies2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 25)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Save Species"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(218, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "ELO and wins of creatures WON'T be saved"
        '
        'Form_Battle_Save
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 187)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSaveSpecies2)
        Me.Controls.Add(Me.btnSaveSpecies1)
        Me.Name = "Form_Battle_Save"
        Me.Text = "Save Species Progress"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSaveSpecies1 As System.Windows.Forms.Button
    Friend WithEvents btnSaveSpecies2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
