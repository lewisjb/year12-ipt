Public Class Creature
    Public m_nnNeuralNetwork As NeuralNetwork 'The brain
    Public m_iELO As Integer 'It's ELO

    Public Sub New(ByVal flags As Integer)
        m_nnNeuralNetwork = New NeuralNetwork
        generateRandomNeuralNetwork(m_nnNeuralNetwork, flags)
        m_iELO = 1000
    End Sub

    Public Sub New()
        m_iELO = 1000
    End Sub
End Class
