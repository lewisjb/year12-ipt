Public Class Form_Battle
    'The 2 species fighting
    Public m_sSpecies1 As Species
    Public m_sSpecies2 As Species

    'The two creatures currently fighting
    Dim m_iCreature1 As Integer
    Dim m_iCreature2 As Integer

    Dim m_iC1Wins As Integer = 0 'How many wins does the first creature have?
    Dim m_iC2Wins As Integer = 0 'How many wins does the second creature have?

    Dim m_rGrid1(), m_rGrid2() As Rectangle 'Efficiency of graphics

    Dim bck, sav As New Button 'Back and Save buttons

    'The actual playing grid, uses Bitwise (check Flags.vb)
    Dim m_iGrid As Integer()

    Dim isc1move As Boolean = True 'Determines whos turn it is

    'For efficiency, the rectangles used to display the playing grid are pre-generated
    Sub loadGridRects()
        '10x10 grid, 30px each
        For i As Integer = 1 To 10
            For j As Integer = 1 To 10
                'The +25 is because of the buttons up the top, so everything goes down 25 px
                m_rGrid1.Add(New Rectangle(i * 30, j * 30 + 25, 30, 30))
                m_rGrid2.Add(New Rectangle(i * 30 + 400, j * 30 + 25, 30, 30)) '+400, because 2nd grid is more to the right
            Next
        Next
    End Sub

    'Function to place a random ship of size s, by creature c
    Sub placeShip(ByVal s As Integer, ByVal c As Integer)
        Dim x, y, rot As Integer 'x,y are top left coords of the ship, rot is the rotation

        While True
            'Random rotation, and random x and y vals inside the grid
            rot = rng.Next(2) '0: horiz, 1: vert
            If rot = 0 Then
                x = rng.Next(11 - s) 'Maximum of 10 - s
                y = rng.Next(10)
            Else
                x = rng.Next(10)
                y = rng.Next(11 - s)
            End If
            For i As Integer = 0 To s - 1
                'Checks if the random rotation, x and y combination collides with another ship, if so re-find random vals
                If rot = 0 Then
                    'Below are bitwise checks (Flags.vb explains)
                    If (m_iGrid((x + i) + y * 10) And If(c = 1, GFLAG_C1_SHIP, GFLAG_C2_SHIP)) = If(c = 1, GFLAG_C1_SHIP, GFLAG_C2_SHIP) Then
                        Continue While
                    End If
                Else
                    If (m_iGrid(x + (y + i) * 10) And If(c = 1, GFLAG_C1_SHIP, GFLAG_C2_SHIP)) = If(c = 1, GFLAG_C1_SHIP, GFLAG_C2_SHIP) Then
                        Continue While
                    End If
                End If
            Next
            'Allowed x,y,rot, so stop finding a new one
            Exit While
        End While

        'Place the ship
        For i As Integer = 0 To s - 1
            If rot = 0 Then
                m_iGrid((x + i) + y * 10) = m_iGrid((x + i) + y * 10) Or If(c = 1, GFLAG_C1_SHIP, GFLAG_C2_SHIP) 'Bitwise
            Else
                m_iGrid(x + (y + i) * 10) = m_iGrid(x + (y + i) * 10) Or If(c = 1, GFLAG_C1_SHIP, GFLAG_C2_SHIP) 'Bitwise
            End If
        Next
    End Sub

    'Generates random ships for both creatures
    Sub genRandomShips()
        'Creature 1
        placeShip(5, 1)
        placeShip(4, 1)
        placeShip(3, 1)
        placeShip(3, 1)
        placeShip(2, 1)

        'Creature 2
        placeShip(5, 2)
        placeShip(4, 2)
        placeShip(3, 2)
        placeShip(3, 2)
        placeShip(2, 2)
    End Sub

    'Check who won
    Function whoWon()
        Dim isC1Alive As Boolean = False 'Does creature 1 still have ships?
        Dim isC2Alive As Boolean = False
        For Each cell In m_iGrid
            If (cell And GFLAG_C1_SHIP) = GFLAG_C1_SHIP Then
                If (cell And GFLAG_C2_SHOT) = 0 Then
                    'There is a cell with part of a ship from Creature 1 that hasn't been shot at, therefor C1 is alive
                    isC1Alive = True
                End If
            End If

            If (cell And GFLAG_C2_SHIP) = GFLAG_C2_SHIP Then
                If (cell And GFLAG_C1_SHOT) = 0 Then
                    'There is a cell with part of a ship from Creature 2 that hasn't been shto at, therefor C2 is alive
                    isC2Alive = True
                End If
            End If
        Next

        If Not isC1Alive Then
            Return 2 'C2 wins
        End If

        If Not isC2Alive Then
            Return 1 'C1 wins
        End If
        Return 0 'No winner yet
    End Function

    'The form is closing
    Private Sub Form_Battle_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Checks if the person pressed the back button, or if they pressed X
        If open_form Is Me Then
            If MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNoCancel, "Exit?") = MsgBoxResult.Yes Then
                Form_Main.Close()
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        open_form = Me 'Update which form is open

        'Initialise the form
        Me.DoubleBuffered = True 'Stops graphics flicker
        Me.ClientSize = New Point(760, 385) 'Client size is the inner-boundaries, and the two sizes are so that all info fits perfectly
        Me.MinimumSize = Me.Size 'Disables resize
        Me.MaximumSize = Me.Size
        Me.MaximizeBox = False 'Greys out maximize
        ReDim m_iGrid(99) 'Give playing grid a size
        loadGridRects() 'Load the graphics rectangles

        'Create Back and Save Buttons
        With bck
            .Size = New Point(52, 25)
            .Location = New Point(-1, -1)
            .Text = "Back"
        End With

        With sav
            .Size = New Point(52, 25)
            .Location = New Point(761 - 52, -1) 'Needs to be 761, so thats its 1 px too far
            .Text = "Save"
        End With
        AddHandler bck.Click, AddressOf Me.back_Click
        AddHandler sav.Click, AddressOf Me.save_Click
        Me.Controls.Add(bck)
        Me.Controls.Add(sav)

        'Start
        m_iCreature1 = 0
        m_iCreature2 = 0
        genRandomShips()
        TmrBattle.Start()
    End Sub

    'Idea for using this method, and the components thanks to Max :)
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'Graphics settings for speed
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighSpeed
        e.Graphics.CompositingMode = Drawing2D.CompositingMode.SourceCopy
        e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighSpeed
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.Low
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAliasGridFit

        'Draw the text at the top: "Name(Generation) - Creature/Generation size (ELO)"
        e.Graphics.DrawString(m_sSpecies1.m_sName & "(" & m_sSpecies1.m_iGeneration & ") - " & (m_iCreature1 + 1) & "/" & m_sSpecies1.m_cCurrentGeneration.Length & " (" & m_sSpecies1.m_cCurrentGeneration(m_iCreature1).m_iELO & ")", New Font("Trebuchet MS", 10), Brushes.Black, 30, 10 + 25)
        e.Graphics.DrawString(m_sSpecies2.m_sName & "(" & m_sSpecies2.m_iGeneration & ") - " & (m_iCreature2 + 1) & "/" & m_sSpecies2.m_cCurrentGeneration.Length & " (" & m_sSpecies2.m_cCurrentGeneration(m_iCreature2).m_iELO & ")", New Font("Trebuchet MS", 10), Brushes.Black, 430, 10 + 25)

        'Draw the text at the bottom: "Wins/30"
        e.Graphics.DrawString(m_iC1Wins & "/30", New Font("Trebuchet MS", 10), Brushes.Black, 30, 330 + 25)
        e.Graphics.DrawString(m_iC2Wins & "/30", New Font("Trebuchet MS", 10), Brushes.Black, 430, 330 + 25)
        'Draw the playing grids
        For i As Integer = 0 To 99
            If (m_iGrid(i) And GFLAG_C2_HIT) = GFLAG_C2_HIT Then
                e.Graphics.FillRectangle(Brushes.OrangeRed, m_rGrid1(i))
            ElseIf (m_iGrid(i) And GFLAG_C2_SHOT) = GFLAG_C2_SHOT Then
                e.Graphics.FillRectangle(Brushes.Yellow, m_rGrid1(i))
            ElseIf (m_iGrid(i) And GFLAG_C1_SHIP) = GFLAG_C1_SHIP Then
                e.Graphics.FillRectangle(Brushes.ForestGreen, m_rGrid1(i))
            Else
                e.Graphics.FillRectangle(Brushes.Blue, m_rGrid1(i))
            End If

            If (m_iGrid(i) And GFLAG_C1_HIT) = GFLAG_C1_HIT Then
                e.Graphics.FillRectangle(Brushes.OrangeRed, m_rGrid2(i))
            ElseIf (m_iGrid(i) And GFLAG_C1_SHOT) = GFLAG_C1_SHOT Then
                e.Graphics.FillRectangle(Brushes.Yellow, m_rGrid2(i))
            ElseIf (m_iGrid(i) And GFLAG_C2_SHIP) = GFLAG_C2_SHIP Then
                e.Graphics.FillRectangle(Brushes.ForestGreen, m_rGrid2(i))
            Else
                e.Graphics.FillRectangle(Brushes.Blue, m_rGrid2(i))
            End If
        Next
    End Sub

    'Timer to control moves
    Private Sub TmrBattle_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrBattle.Tick
        'Check whos turn, then get their move and act on it
        If isc1move Then
            Dim c1_move As Integer = m_sSpecies1.m_cCurrentGeneration(m_iCreature1).m_nnNeuralNetwork.getMove(gridToInput(m_iGrid, m_sSpecies1.m_iInputNeuronFlags, 1))
            m_iGrid(c1_move) = m_iGrid(c1_move) Or GFLAG_C1_SHOT 'Update grid for the shot
            If (m_iGrid(c1_move) And GFLAG_C2_SHIP) = GFLAG_C2_SHIP Then
                m_iGrid(c1_move) = m_iGrid(c1_move) Or GFLAG_C1_HIT 'Hit, so update grid
            End If
        Else
            Dim c2_move As Integer = m_sSpecies2.m_cCurrentGeneration(m_iCreature2).m_nnNeuralNetwork.getMove(gridToInput(m_iGrid, m_sSpecies2.m_iInputNeuronFlags, 2))
            m_iGrid(c2_move) = m_iGrid(c2_move) Or GFLAG_C2_SHOT 'Update grid for the shot
            If (m_iGrid(c2_move) And GFLAG_C1_SHIP) = GFLAG_C1_SHIP Then
                m_iGrid(c2_move) = m_iGrid(c2_move) Or GFLAG_C2_HIT 'Hit, so update grid
            End If
        End If
        isc1move = Not isc1move 'Changes whos turn it is

        'Update graphics, Thanks Max
        Me.Refresh()

        Dim winner As Integer = whoWon() 'If there is a winner then the battle will end, and the winner will be stored in the variable

        'If there is a winner, update wins and call onroundend
        If winner = 1 Then
            m_iC1Wins += 1
            onRoundEnd()
        ElseIf winner = 2 Then
            m_iC2Wins += 1
            onRoundEnd()
        End If
    End Sub

    'Round ended
    Sub onRoundEnd()
        'Pause it
        TmrBattle.Stop()
        'Clean grid
        For i As Integer = 0 To m_iGrid.Length - 1
            m_iGrid(i) = 0
        Next
        'If thats the last match, call onBattleEnd
        If m_iC1Wins + m_iC2Wins = 30 Then
            onBattleEnd()
        Else
            'Gen new ships
            genRandomShips()
            'Update screen
            Me.Refresh()

            'Change who starts
            'Even rounds, c1 first, odd rounds, c2 first
            If (m_iC1Wins + m_iC2Wins) Mod 2 = 0 Then
                isc1move = True
            Else
                isc1move = False
            End If

            'Start it again
            TmrBattle.Start()
        End If
    End Sub

    Public Sub onBattleEnd()
        'Update the ELO of the creatures
        updateELO(m_sSpecies1.m_cCurrentGeneration(m_iCreature1), m_sSpecies2.m_cCurrentGeneration(m_iCreature2), m_iC1Wins / (m_iC1Wins + m_iC2Wins))

        'Get next opponent/s
        If m_iCreature2 = m_sSpecies2.m_cCurrentGeneration.Length - 1 Then
            'Is last creature 2
            If m_iCreature1 = m_sSpecies1.m_cCurrentGeneration.Length - 1 Then
                'Is last of both, new generation
                m_iCreature1 = 0
                m_iCreature2 = 0
                m_sSpecies1.nextGeneration()
                m_sSpecies2.nextGeneration()
                'Since new generation, allow the user to save the species
                sav.Enabled = True
            Else
                m_iCreature1 += 1
                m_iCreature2 = 0 'Reset c2 as c1 went to next one
            End If
        Else
            'Is last not last of creature2
            m_iCreature2 += 1
        End If
        'Reset wins, and generate new ships
        m_iC1Wins = 0
        m_iC2Wins = 0
        genRandomShips()
        isc1move = True 'New match, c1 starts
        Me.Refresh()
        TmrBattle.Start()
    End Sub

    'Back button clicked, reload Form_Battle_Select
    Private Sub back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form_Battle_Select.Show()
        Form_Battle_Select.s1 = m_sSpecies1
        Form_Battle_Select.s2 = m_sSpecies2
        Form_Battle_Select.lblSpecies1.Text = "Species: " & m_sSpecies1.m_sName & "(" & m_sSpecies1.m_iGeneration & ")"
        Form_Battle_Select.lblSpecies2.Text = "Species: " & m_sSpecies2.m_sName & "(" & m_sSpecies2.m_iGeneration & ")"
        Form_Battle_Select.btnBattle.Enabled = True
        Me.Close()
    End Sub

    'Save button clicked, open up Form_Battle_Save
    Private Sub save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Form_Battle_Save.Show()
        Form_Battle_Save.m_sSpecies1 = m_sSpecies1
        Form_Battle_Save.m_sSpecies2 = m_sSpecies2
        Form_Battle_Save.updateButtons()
    End Sub
End Class
