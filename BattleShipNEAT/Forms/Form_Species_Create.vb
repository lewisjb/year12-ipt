Public Class Form_Species_Create
    Private Sub Form_Species_Create_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Checks if the person pressed the back button, or if they pressed X
        If open_form Is Me Then
            If MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNoCancel, "Exit?") = MsgBoxResult.Yes Then
                Form_Main.Close()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Form_Species_Create_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        open_form = Me 'Update main open form
        'Disables resizing
        Me.MinimumSize = Me.Size
        Me.MaximumSize = Me.Size
        Me.MaximizeBox = False
    End Sub

    'Saving a species
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Create the species, if no name given, call it "Unnamed Species"
        Dim s As New Species(0, If(txtName.Text.Length = 0, "Unnamed Species", txtName.Text), nupMutation.Value / 100, cbCrossovers.Checked)
        'Update the inputneuronflags
        If cbHits.Checked Then
            s.m_iInputNeuronFlags = s.m_iInputNeuronFlags Or INFLAG_HITS
        End If
        If cbOwnShip.Checked Then
            s.m_iInputNeuronFlags = s.m_iInputNeuronFlags Or INFLAG_OWN_SHIP_POS
        End If
        If cbEnemyShots.Checked Then
            s.m_iInputNeuronFlags = s.m_iInputNeuronFlags Or INFLAG_ENEMY_SHOTS
        End If
        If cbEnemyHits.Checked Then
            s.m_iInputNeuronFlags = s.m_iInputNeuronFlags Or INFLAG_ENEMY_HITS
        End If

        'Save it to a file
        Dim sfd As New SaveFileDialog()
        sfd.AddExtension = True
        sfd.DefaultExt = ".species"
        sfd.Title = "Save a species file"
        sfd.Filter = "Species (*.species)|*.species"
        sfd.FilterIndex = 1
        sfd.RestoreDirectory = True
        sfd.FileName = If(txtName.Text.Length = 0, "Unnamed Species", txtName.Text)

        If sfd.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(sfd.FileName, s, False)
            Form_Main.ShowFix()
            Me.Close()
        End If
    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Form_Main.ShowFix()
        Me.Close()
    End Sub
End Class