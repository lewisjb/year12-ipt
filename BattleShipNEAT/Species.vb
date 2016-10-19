Public Class Species
    Public m_iGeneration As Integer 'Current species generation
    Public m_cCurrentGeneration As Creature() 'All the creatures in the current generation

    Public m_iInputNeuronFlags As Integer 'The input flags
    Public m_sName As String 'Name
    Public m_fMutationRate As Decimal 'Mutation rate
    Public m_bCrossOver As Boolean 'Apply crossover?

    Public Sub New(ByVal flags As Integer, ByVal name As String, ByVal mutation As Decimal, ByVal crossover As Boolean)
        m_iGeneration = 1
        m_iInputNeuronFlags = flags
        m_sName = name
        m_fMutationRate = mutation
        m_bCrossOver = crossover
        'Generate 50 random creatures
        For i As Integer = 1 To 50
            m_cCurrentGeneration.Add(New Creature(m_iInputNeuronFlags))
        Next
    End Sub

    Public Sub New()
        m_iGeneration = 1
    End Sub

    'Convert to string, new line for every bit  of info, then every creature brain seperated by _ on a new line
    Public Shared Widening Operator CType(ByVal s As Species) As String
        Dim r As String
        r = s.m_iGeneration & Environment.NewLine
        r &= s.m_iInputNeuronFlags & Environment.NewLine
        r &= s.m_sName & Environment.NewLine
        r &= s.m_fMutationRate & Environment.NewLine
        r &= s.m_bCrossOver
        For Each cr In s.m_cCurrentGeneration
            r += Environment.NewLine & "_" & Environment.NewLine
            r += CType(cr.m_nnNeuralNetwork, String)
        Next
        Return r
    End Operator

    'Convert from string
    Public Shared Narrowing Operator CType(ByVal str As String) As Species
        Dim chunks As String() = str.Split("_") 'The species file is split into chunks, seperated by _, the first chunk is info on the species, rest are current generation
        'Deal with info chunk
        Dim info As String() = chunks(0).Split(Environment.NewLine)
        Dim r As New Species
        '.Replace(Chr(10), "") removes the new line
        r.m_iGeneration = info(0).Replace(Chr(10), "")
        r.m_iInputNeuronFlags = info(1).Replace(Chr(10), "")
        r.m_sName = info(2).Replace(Chr(10), "")
        r.m_fMutationRate = info(3).Replace(Chr(10), "")
        r.m_bCrossOver = info(4).Replace(Chr(10), "")
        'Deal with current gen
        For i As Integer = 1 To chunks.Length - 1
            Dim c As New Creature
            c.m_nnNeuralNetwork = chunks(i)
            r.m_cCurrentGeneration.Add(c)
        Next
        Return r
    End Operator

    'Called to apply genetic algorithms to create a new generation
    Public Sub nextGeneration()
        m_iGeneration += 1
        Dim r As Creature()

        Dim c1, c2 As Creature
        'Do it 15 times, as it will give 2 children, therefor a generation of size 50
        For i As Integer = 1 To 25
            c1 = roulleteWheelSelection(m_cCurrentGeneration) 'Get first creature
            'Making sure second creature is different to the first one
            Dim gen As Creature() = m_cCurrentGeneration.Clone()
            gen.Except(New Creature() {c1})
            c2 = roulleteWheelSelection(gen)
            'Got 2 parents, mutate them, but only if rng allows it
            If rng.NextDouble() < m_fMutationRate Then
                applyMutation(c1.m_nnNeuralNetwork, m_iInputNeuronFlags)
            End If
            If rng.NextDouble() < m_fMutationRate Then
                applyMutation(c2.m_nnNeuralNetwork, m_iInputNeuronFlags)
            End If
            'If crossovers enabled, then apply crossover
            If m_bCrossOver Then
                applyCrossover(c1.m_nnNeuralNetwork, c2.m_nnNeuralNetwork)
            End If
            'Add the 2 children to the next generation
            r.Add(c1)
            r.Add(c2)
        Next

        m_cCurrentGeneration = r
    End Sub
End Class