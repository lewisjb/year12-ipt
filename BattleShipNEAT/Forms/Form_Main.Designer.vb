<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Main
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
        Me.btnSpeciesVs = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnSpeciesDelete = New System.Windows.Forms.Button()
        Me.btnSpeciesCreate = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnSpeciesVs
        '
        Me.btnSpeciesVs.Location = New System.Drawing.Point(12, 29)
        Me.btnSpeciesVs.Name = "btnSpeciesVs"
        Me.btnSpeciesVs.Size = New System.Drawing.Size(258, 61)
        Me.btnSpeciesVs.TabIndex = 2
        Me.btnSpeciesVs.Text = "Species v Species"
        Me.btnSpeciesVs.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Species"
        '
        'btnSpeciesDelete
        '
        Me.btnSpeciesDelete.Location = New System.Drawing.Point(166, 153)
        Me.btnSpeciesDelete.Name = "btnSpeciesDelete"
        Me.btnSpeciesDelete.Size = New System.Drawing.Size(100, 23)
        Me.btnSpeciesDelete.TabIndex = 13
        Me.btnSpeciesDelete.Text = "Delete"
        Me.btnSpeciesDelete.UseVisualStyleBackColor = True
        '
        'btnSpeciesCreate
        '
        Me.btnSpeciesCreate.Location = New System.Drawing.Point(65, 153)
        Me.btnSpeciesCreate.Name = "btnSpeciesCreate"
        Me.btnSpeciesCreate.Size = New System.Drawing.Size(100, 23)
        Me.btnSpeciesCreate.TabIndex = 12
        Me.btnSpeciesCreate.Text = "Create"
        Me.btnSpeciesCreate.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 25)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "BATTLE!"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 25)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "EDIT"
        '
        'Form_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(278, 185)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnSpeciesVs)
        Me.Controls.Add(Me.btnSpeciesDelete)
        Me.Controls.Add(Me.btnSpeciesCreate)
        Me.Name = "Form_Main"
        Me.Text = "Main Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSpeciesVs As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSpeciesDelete As System.Windows.Forms.Button
    Friend WithEvents btnSpeciesCreate As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
