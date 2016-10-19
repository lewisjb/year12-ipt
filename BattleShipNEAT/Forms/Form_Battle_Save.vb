Public Class Form_Battle_Save

    Public m_sSpecies1, m_sSpecies2 As Species 'The two species that can be saved
    'Called when the species are loaded, so the buttons are updated
    Public Sub updateButtons()
        If m_sSpecies1 IsNot Nothing AndAlso m_sSpecies2 IsNot Nothing Then
            btnSaveSpecies1.Text = "Save: " & m_sSpecies1.m_sName
            btnSaveSpecies2.Text = "Save: " & m_sSpecies2.m_sName
        End If
    End Sub

    Private Sub btnSaveSpecies1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSpecies1.Click
        'Save it to a file
        Dim sfd As New SaveFileDialog()
        sfd.AddExtension = True
        sfd.DefaultExt = ".species"
        sfd.Title = "Save a species file"
        sfd.Filter = "Species (*.species)|*.species"
        sfd.FilterIndex = 1
        sfd.RestoreDirectory = True
        sfd.FileName = m_sSpecies1.m_sName

        If sfd.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(sfd.FileName, m_sSpecies1, False)
        End If
    End Sub

    Private Sub btnSaveSpecies2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveSpecies2.Click
        'Save it to a file
        Dim sfd As New SaveFileDialog()
        sfd.AddExtension = True
        sfd.DefaultExt = ".species"
        sfd.Title = "Save a species file"
        sfd.Filter = "Species (*.species)|*.species"
        sfd.FilterIndex = 1
        sfd.RestoreDirectory = True
        sfd.FileName = m_sSpecies2.m_sName

        If sfd.ShowDialog() = DialogResult.OK Then
            My.Computer.FileSystem.WriteAllText(sfd.FileName, m_sSpecies2, False)
        End If
    End Sub

    Private Sub Form_Battle_Save_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Stops resizing
        Me.MinimumSize = Me.Size
        Me.MaximumSize = Me.Size
        Me.MaximizeBox = False
    End Sub
End Class