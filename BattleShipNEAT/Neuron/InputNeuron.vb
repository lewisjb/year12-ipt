Public Class InputNeuron
    Inherits Neuron
    'Just gives the correct default info
    Sub New()
        MyBase.New(1.0)
        m_iInputNeurons = 1
    End Sub
End Class
