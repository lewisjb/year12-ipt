Public Class Neuron
    Protected m_nOutputNeurons As Object() 'All the neurons that it sends info to
    Protected m_fOutputWeights As Decimal() 'The weights it sends the info at
    Protected m_fActivationValue As Decimal 'The neuron activation value
    Protected m_iInputNeurons As Integer 'How many input neuron it has
    Protected m_afInputValues As Decimal() 'Current input values received
    Protected m_iID As Integer = -1 'Neuron ID
    Public m_bScanned As Boolean = False 'Has it been scanned? Used for getArrOfNeurons() in Functions.vb

    'When new one is made
    Sub New(ByVal activation As Decimal)
        m_fActivationValue = activation
    End Sub

    'Getters and setters

    Public Function getOutputNeurons()
        Return m_nOutputNeurons
    End Function

    Public Function getOutputWeights()
        Return m_fOutputWeights
    End Function

    Public Function getActivationValue()
        Return m_fActivationValue
    End Function

    Public Sub setID(ByVal id As Integer)
        m_iID = id
    End Sub

    Public Function getID()
        Return m_iID
    End Function

    'Sub called to add an output connection
    Public Overridable Sub addOutputConnection(ByRef output As Neuron, ByVal weight As Decimal)
        m_nOutputNeurons.Add(output)
        m_fOutputWeights.Add(weight)
        output.m_iInputNeurons += 1
    End Sub

    'Sub called when an input is sent to neuron
    Public Overridable Sub sendInput(ByVal input As Decimal)
        m_afInputValues.Add(input)
        If m_afInputValues.Length = m_iInputNeurons Then
            'All inputs have been sent
            If m_afInputValues.Sum() >= m_fActivationValue Then
                'Neuron is activated, send input to output neurons
                For i As Integer = 0 To m_nOutputNeurons.Length - 1
                    'The output value is always either 1 or 0, and since we know that it is activated, 1 * x = x, thus 1 * connection_weight = connection_weight
                    m_nOutputNeurons(i).sendInput(m_fOutputWeights(i))
                Next
            Else
                'Neuron was not activated, send a null input to output neurons
                For i As Integer = 0 To m_nOutputNeurons.Length - 1
                    'A null input must be sent so that the output neuron isn't waiting forever for an input from this neuron
                    m_nOutputNeurons(i).sendInput(0)
                Next
            End If
            'Reset neuron to be used again
            m_afInputValues = Nothing
        End If
    End Sub
End Class
