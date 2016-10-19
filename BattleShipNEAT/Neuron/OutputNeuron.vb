Public Class OutputNeuron
    Inherits Neuron
    Public m_fOutputValue As Decimal
    Sub New(ByVal activation As Decimal)
        MyBase.New(activation)
    End Sub

    Public Overrides Sub addOutputConnection(ByRef obj As Neuron, ByVal f As Decimal)
        'Nothing, just blocks the user from calling it on an output neuron
    End Sub

    Public Overrides Sub sendInput(ByVal input As Decimal)
        'Get all of the inputs (which are actually the outputs), and find the largest one.
        m_afInputValues.Add(input)
        If m_afInputValues.Length = m_iInputNeurons Then
            'Received all inputs send value to the network
            m_fOutputValue = m_afInputValues.Sum()
            'Reset to be used again
            m_afInputValues = Nothing
        End If
    End Sub
End Class
