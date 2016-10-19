Public Class Form_Battle_Select
    Public s1, s2 As Species 'The two species being loaded

    'Open species and display information about it, if both species loaded, allow to battle
    Private Sub btnSpecies1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpecies1.Click
        s1 = loadSpecies()
        If s1 IsNot Nothing Then
            lblSpecies1.Text = "Species: " & s1.m_sName & "(" & s1.m_iGeneration & ")"
            If s2 IsNot Nothing Then
                btnBattle.Enabled = True
            End If
        Else
            btnBattle.Enabled = False
            lblSpecies1.Text = "Species: N/A"
        End If
    End Sub

    'Open species and display information about it, if both species loaded, allow to battle
    Private Sub btnSpecies2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpecies2.Click
        s2 = loadSpecies()
        If s2 IsNot Nothing Then
            lblSpecies2.Text = "Species: " & s2.m_sName & "(" & s2.m_iGeneration & ")"
            If s1 IsNot Nothing Then
                btnBattle.Enabled = True
            End If
        Else
            btnBattle.Enabled = False
            lblSpecies2.Text = "Species: N/A"
        End If
    End Sub
    'Function to open the file dialog, and interpret the file
    Function loadSpecies()
        Dim ofd As New OpenFileDialog
        Dim r As Species
        ofd.AddExtension = True
        ofd.DefaultExt = ".species"
        ofd.Title = "Save a species file"
        ofd.Filter = "Species (*.species)|*.species"
        ofd.FilterIndex = 1
        ofd.RestoreDirectory = True

        If ofd.ShowDialog() = DialogResult.OK Then
            r = System.IO.File.ReadAllText(ofd.FileName)
        End If
        Return r
    End Function
    'Go to Form_Battle and fight
    Private Sub btnBattle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBattle.Click
        Form_Battle.m_sSpecies1 = s1
        Form_Battle.m_sSpecies2 = s2
        Form_Battle.Show()
        Me.Close()
    End Sub

    'Form is closing
    Private Sub Form_Battle_Select_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Checks if the person pressed the back button, or if they pressed X
        If open_form Is Me Then
            If MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNoCancel, "Exit?") = MsgBoxResult.Yes Then
                Form_Main.Close()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Form_Battle_Select_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        open_form = Me 'Updates main open form
        'Disables resize
        Me.MinimumSize = Me.Size
        Me.MaximumSize = Me.Size
        Me.MaximizeBox = False
    End Sub

    'The back button pressed, go back to main
    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Form_Main.ShowFix()
        Me.Close()
    End Sub
End Class