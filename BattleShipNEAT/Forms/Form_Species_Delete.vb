Public Class Form_Species_Delete

    Dim filename As String
    'Loads the species, and displays information about it
    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Dim ofd As New OpenFileDialog
        Dim s As Species
        ofd.AddExtension = True
        ofd.DefaultExt = ".species"
        ofd.Title = "Save a species file"
        ofd.Filter = "Species (*.species)|*.species"
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True

        If ofd.ShowDialog() = DialogResult.OK Then
            filename = ofd.FileName
            s = System.IO.File.ReadAllText(ofd.FileName)
            'Update info
            nupGeneration.Value = s.m_iGeneration
            txtName.Text = s.m_sName
            nupMutation.Value = s.m_fMutationRate * 100
            cbCrossovers.Checked = s.m_bCrossOver
            cbHits.Checked = ((s.m_iInputNeuronFlags And INFLAG_HITS) = INFLAG_HITS)
            cbOwnShip.Checked = ((s.m_iInputNeuronFlags And INFLAG_OWN_SHIP_POS) = INFLAG_OWN_SHIP_POS)
            cbEnemyShots.Checked = ((s.m_iInputNeuronFlags And INFLAG_ENEMY_SHOTS) = INFLAG_ENEMY_SHOTS)
            cbEnemyHits.Checked = ((s.m_iInputNeuronFlags And INFLAG_ENEMY_HITS) = INFLAG_ENEMY_HITS)

            'Allow to delete
            btnDelete.Enabled = True
        End If
    End Sub

    'Delete the species, after confirmation
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Are you sure you want to delete this species?", MsgBoxStyle.YesNoCancel, "Are you sure?") = MsgBoxResult.Yes Then
            'They do want to delete, so delete
            My.Computer.FileSystem.DeleteFile(filename)
            MsgBox("The species is now extinct", MsgBoxStyle.Information, "Extinct")
            Form_Main.ShowFix()
            Me.Close()
        End If
    End Sub

    Private Sub Form_Species_Delete_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Checks if the person pressed the back button, or if they pressed X
        If open_form Is Me Then
            If MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNoCancel, "Exit?") = MsgBoxResult.Yes Then
                Form_Main.Close()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Form_Species_Delete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        open_form = Me 'Update main open form
        'Disables resizing
        Me.MinimumSize = Me.Size
        Me.MaximumSize = Me.Size
        Me.MaximizeBox = False
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Form_Main.ShowFix()
        Me.Close()
    End Sub
End Class