Public Class Form_Main
    Private Sub Form_Main_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Checks if the person pressed the back button, or if they pressed X
        If open_form Is Me Then
            If MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNoCancel, "Exit?") <> MsgBoxResult.Yes Then
                e.Cancel = True
            End If
        End If
    End Sub
    Private Sub Form_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        open_form = Me 'Update main open form
        'Disables resizing
        Me.MinimumSize = Me.Size
        Me.MaximumSize = Me.Size
        Me.MaximizeBox = False
    End Sub

    'Since Form_Main never closes, the load sub isn't called when it is shown, so to tell when form_main is the open form, this must be used
    Public Sub ShowFix()
        open_form = Me
        Me.Show()
    End Sub

    'Deal with each button press and their respective forms
    Private Sub btnSpeciesVs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpeciesVs.Click
        Form_Battle_Select.Show()
        Me.Hide()
    End Sub

    Private Sub btnSpeciesCreate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpeciesCreate.Click
        Form_Species_Create.Show()
        Me.Hide()
    End Sub

    Private Sub btnSpeciesDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpeciesDelete.Click
        Form_Species_Delete.Show()
        Me.Hide()
    End Sub
End Class