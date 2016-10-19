Imports System.Text.RegularExpressions
Public Class NeuralNetwork
    Public m_inInputNeurons() As InputNeuron

    Public Shared Widening Operator CType(ByVal nn As NeuralNetwork) As String
        'Turn the neural net into a string (to be stored in file)
        Dim r As String = ""
        Dim neurons As Object() = getArrOfNeurons(nn.m_inInputNeurons) 'Get all neurons connected to the input neurons
        Dim inputs As InputNeuron()
        Dim hiddens As Neuron()
        Dim outputs As OutputNeuron()
        inputs.CopyConvertFrom(getInputNeuronsFromArray(neurons)) 'Get all of the input neurons in the neuron array
        hiddens.CopyConvertFrom(getHiddenNeuronsFromArray(neurons)) 'Get all the hidden neurons in the neuron array
        outputs.CopyConvertFrom(getOutputNeuronsFromArray(neurons)) 'Get all the output neurons in the neuron array
        Dim n_temp As Object() 'Temporary array for neurons
        Dim f_temp As Decimal() 'Temporary array for floats

        'r += nn.m_iInputNeuronFlags & Environment.NewLine 'Start the string with the input neuron flags and a new line

        'For each neuron in inputs
        For Each n In inputs
            If n Is Nothing Then
                Continue For
            End If
            'Create the line giving all info needed for a neuron. e.g. i10 -> 0.3:h10 0.1:h3
            r += "i" & n.getID() & " ->"
            n_temp = n.getOutputNeurons()
            f_temp = n.getOutputWeights()
            For i As Integer = 0 To n_temp.Length - 1
                r += " " & f_temp(i) & ":" & If(n_temp(i).GetType() = GetType(OutputNeuron), "o", "h") & n_temp(i).getID()
            Next
            r += Environment.NewLine
        Next

        'For each neuron in hiddens
        For Each n In hiddens
            If n Is Nothing Then
                Continue For
            End If
            'Create the line giving all the info needed for a neuron. e.g. h3(0.3) -> 0.1:h1 10:o10
            r += "h" & n.getID() & "(" & n.getActivationValue() & ")" & " ->"
            n_temp = n.getOutputNeurons()
            f_temp = n.getOutputWeights()
            For i As Integer = 0 To n_temp.Length - 1
                r += " " & f_temp(i) & ":" & If(n_temp(i).GetType() = GetType(OutputNeuron), "o", "h") & n_temp(i).getID()
            Next
            r += Environment.NewLine
        Next

        'For each neuron in outputs
        For Each n In outputs
            If n Is Nothing Then
                Continue For
            End If
            'Create the line giving all the info needed for a neuron. e.g. o10(0.3)
            r += "o" & n.getID() & "(" & n.getActivationValue() & ")" & Environment.NewLine
        Next
        Return r
    End Operator

    Public Shared Narrowing Operator CType(ByVal str As String) As NeuralNetwork
        'Turn the string into a neural net (for loading from file)
        Dim r As New NeuralNetwork
        Dim lines As String()
        lines = str.Split(Environment.NewLine)
        'r.m_iInputNeuronFlags = lines(0)

        Dim inputNeurons As InputNeuron()
        Dim hiddenNeurons As Neuron()
        Dim outputNeurons As OutputNeuron()

        For Each line In lines
            line = line.Replace(Chr(10), "") 'Replace the newline ascii character with nothing, thus removing it
            If line.Length = 0 Then
                'Nothing
            ElseIf line(0) = "i" Then
                'Input neuron "i3 -> 0.1:h1"
                Dim n As New InputNeuron()
                Dim m As Match = Regex.Match(line, "i(?<neuron_id>\d+) ->")
                n.setID(m.Result("${neuron_id}"))
                inputNeurons.SetValueAtIndex(n.getID(), n)
            ElseIf line(0) = "h" Then
                'Hidden neuron "h3(0.4) -> 0.2:h4"
                Dim m As Match = Regex.Match(line, "h(?<neuron_id>\d+)\((?<activation_value>(-)?[0-9.]+)\) ->")
                Dim n As New Neuron(m.Result("${activation_value}"))
                n.setID(m.Result("${neuron_id}"))
                hiddenNeurons.SetValueAtIndex(n.getID(), n)
            ElseIf line(0) = "o" Then
                'Output neuron "o1(0.1)"
                Dim m As Match = Regex.Match(line, "o(?<neuron_id>\d+)\((?<activation_value>(-)?[0-9.]+)\)")
                Dim n As New OutputNeuron(m.Result("${activation_value}"))
                n.setID(m.Result("${neuron_id}"))
                outputNeurons.SetValueAtIndex(n.getID(), n)
            End If
        Next

        'Every neuron has now been created, given an id and stored in an array at the index of its id
        'Now link all neurons together
        For Each line In lines
            line = line.Replace(Chr(10), "") 'Replace the newline ascii character with nothing, thus removing it.
            'This is needed as the newline character was the first in the line for certain lines, so this allows the first character to be checked easily.

            Dim con_n As String 'Connection neuron name
            Dim weight As Decimal 'Weight of connection
            Dim connections As String()
            If line.Length = 0 Then
                'Nothing
            ElseIf line(0) = "i" Then
                Dim m As Match = Regex.Match(line, "i(?<neuron_id>\d+) ->")
                Dim n As InputNeuron = inputNeurons(m.Result("${neuron_id}")) 'Get neuron to connect others to
                line = Regex.Replace(line, "i[0-9]* -> ", "") 'Just get the connections
                connections = line.Split(" ")
                For Each con In connections
                    'Connect em
                    weight = con.Split(":")(0)
                    con_n = con.Split(":")(1)
                    n.addOutputConnection(If(con_n(0) = "h", hiddenNeurons(con_n.Replace("h", "")), outputNeurons(con_n.Replace("o", ""))), weight)
                Next
            ElseIf line(0) = "h" Then
                Dim m As Match = Regex.Match(line, "h(?<neuron_id>\d+)\((?<activation_value>(-)?[0-9.]+)\) ->")
                Dim n As Neuron = hiddenNeurons(m.Result("${neuron_id}")) 'Get neuron to connect others to
                line = Regex.Replace(line, "h[0-9]*\((-)?[0-9.]+\) -> ", "") 'Just get the connections
                connections = line.Split(" ")
                For Each con In connections
                    'Connect em
                    weight = con.Split(":")(0)
                    con_n = con.Split(":")(1)
                    n.addOutputConnection(If(con_n(0) = "h", hiddenNeurons(con_n.Replace("h", "")), outputNeurons(con_n.Replace("o", ""))), weight)
                Next
            End If
        Next
        r.m_inInputNeurons = inputNeurons
        Return r
    End Operator

    'Get a move from the brain
    Public Function getMove(ByRef inp As Boolean())
        'Send all the inputs to the neurons
        For i As Integer = 0 To m_inInputNeurons.Length - 1
            If m_inInputNeurons(i) IsNot Nothing Then
                m_inInputNeurons(i).sendInput(inp(i))
            End If
        Next
        'Get all the outputs, they will be a decimal value representing how much the brain wants to move there
        Dim outputs As OutputNeuron()
        outputs.CopyConvertFrom(getOutputNeuronsFromArray(getArrOfNeurons(m_inInputNeurons)))
        Dim values As Decimal()
        For i As Integer = 0 To 99
            'If there isn't an output neuron for this cell, set decimal value to 0
            If outputs.Length - 1 < i OrElse outputs(i) Is Nothing Then
                values.SetValueAtIndex(i, 0)
            Else
                values.SetValueAtIndex(i, outputs(i).m_fOutputValue)
            End If
        Next

        Dim n_highest As Integer()
        Dim f_highest As Decimal
        'values is an array with all the output values of the neurons, find the highest allowed
        For i As Integer = 0 To 99
            If inp(i) = False Then
                'Haven't shot at this location, so its an allowed option
                If n_highest Is Nothing Then
                    'First iteration, give it a place to start
                    n_highest.Add(i)
                    f_highest = values(i)
                Else
                    'Check if the value is higher than the current highest, if so, update it, if its a tie, then add the neuron to the highest array
                    If values(i) = f_highest Then
                        n_highest.Add(i)
                    ElseIf values(i) > f_highest Then
                        n_highest = Nothing
                        n_highest.Add(i)
                        f_highest = values(i)
                    End If
                End If
            End If
        Next

        'Got an array of the highest outputs (they are all tied), so randomly pick one
        Return n_highest(rng.Next(n_highest.Length))
    End Function
End Class
