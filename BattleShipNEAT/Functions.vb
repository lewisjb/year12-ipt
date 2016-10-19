Module Functions
    'Recursive function which returns an array of neurons. This array contains every neuron which is connected to the input neurons, and only contains them once.
    'dontcall, because there it should only be done via plain getArrOfNeurons
    Function dontcall_getArrOfNeurons(ByRef inputs As Object())
        Dim arr As Object() 'The array to be returned
        Dim temp As Object() 'Temporary array, used for whenever an array is needed only for a short while

        For Each inp In inputs
            'Since the neurons are placed in the index of their id, we will have some null neurons we need to skip
            If inp Is Nothing Then
                Continue For
            End If
            If inp.m_bScanned = False Then
                inp.m_bScanned = True
                arr.Add(inp) 'Add the current neuron to the return array
                If inp.GetType() IsNot GetType(OutputNeuron) Then
                    temp = dontcall_getArrOfNeurons(inp.getOutputNeurons()) 'Using the temp array for efficiency
                    If temp IsNot Nothing AndAlso temp.Length > 0 Then 'If the array has been set and isn't empty
                        arr.ConcatNew(temp) 'Add the array retrieved from the recursive function call to get all the neurons connected
                    End If
                End If
            End If
        Next
        Return arr
    End Function

    'To be called straight after getArrOfNeurons, as it undoes the changes to m_bScanned, this allows for getArrOfNeurons to be called multiple times
    Sub dontcall_cleanNeuralNetwork(ByRef inputs As Object())
        For Each inp In inputs
            'Since the neurons are placed in the index of their id, we will have some null neurons we need to skip
            If inp Is Nothing Then
                Continue For
            End If
            If inp.m_bScanned = True Then
                inp.m_bScanned = False
                If inp.GetType() IsNot GetType(OutputNeuron) Then
                    dontcall_cleanNeuralNetwork(inp.getOutputNeurons())
                End If
            End If
        Next
    End Sub

    'Gets arr then cleans the neurons
    Function getArrOfNeurons(ByRef inputs As Object())
        Dim r As Object()
        r = dontcall_getArrOfNeurons(inputs)
        dontcall_cleanNeuralNetwork(inputs)
        Return r
    End Function

    'Returns an array of input neurons from an array of neurons.
    Function getInputNeuronsFromArray(ByVal arr As Object())
        Dim inputs As Object()
        For Each element In arr
            If element.GetType() Is GetType(InputNeuron) Then
                inputs.SetValueAtIndex(element.getID(), element)
            End If
        Next
        Return inputs
    End Function

    'Returns an array of hidden neurons from an array of neurons.
    Function getHiddenNeuronsFromArray(ByVal arr As Object())
        Dim hiddens As Object()
        For Each element In arr
            If element.GetType() Is GetType(Neuron) Then
                hiddens.SetValueAtIndex(element.getID(), element)
            End If
        Next
        Return hiddens
    End Function

    'Returns an array of output neurons from an array of neurons.
    Function getOutputNeuronsFromArray(ByVal arr As Object())
        Dim outputs As Object()
        For Each element In arr
            If element.GetType() Is GetType(OutputNeuron) Then
                outputs.SetValueAtIndex(element.getID(), element)
            End If
        Next
        Return outputs
    End Function

    'Generates a random neural network, stored in nn, with the input flags "flags"
    Sub generateRandomNeuralNetwork(ByRef nn As NeuralNetwork, ByVal flags As Integer)
        'Just apply mutations 10 times
        For i As Integer = 0 To 10
            applyMutation_Create(nn, flags)
        Next
    End Sub

    'Called to apply mutations on nn with flags
    Sub applyMutation(ByRef nn As NeuralNetwork, ByVal flags As Integer)
        Dim type As Integer = rng.Next(2) '0: Create new connection, 1: Edit existing connection
        If type = 0 Then
            applyMutation_Create(nn, flags)
        Else
            applyMutation_Edit(nn)
        End If
    End Sub

    Sub applyMutation_Create(ByRef nn As NeuralNetwork, ByVal flags As Integer)
        Dim type As Integer = rng.Next(2) '0: Create a connection, 1: Create a neuron (with connections)
        If type = 0 Then
            applyMutation_Create_Connection(nn, flags)
        Else
            applyMutation_Create_Neuron(nn, flags)
        End If
    End Sub

    'Used for getNumerics, stores every activation value and connection weight in a neural network, and its start and end pos
    Structure genetic_valuesStruct
        Public m_iStart As Integer
        Public m_iEnd As Integer
        Public m_fNumber As Decimal
    End Structure

    'Get every activation value and connection weight in a neural network, and its start and end pos in the form of a genetic_valueStruct array
    Function getNumerics(ByVal str As String)
        Dim r As genetic_valuesStruct() 'To return
        Dim curnum As String = "" 'Current number
        Dim curstart As Integer = -1 'Current start
        Dim ignore As Boolean = False 'Should ignore this number?
        For i As Integer = 0 To str.Length - 1
            'If it is "i" "h" or "o", then the number following will be an ID, we want to ignore them
            If str(i) = "i" OrElse str(i) = "h" OrElse str(i) = "o" Then
                ignore = True
                Continue For 'Efficiency
            End If
            'If number
            '45 -> 57 is -./0123456789   since / isnt anywhere in the brain format it doesnt need to be checked for
            If Asc(str(i)) >= 45 AndAlso Asc(str(i)) <= 57 Then
                If curstart = -1 Then
                    'Start of a number
                    curstart = i
                End If
                curnum &= str(i)
            Else
                If curstart > -1 Then
                    'End of a number
                    'Check that its not the - from the arrow symbol, and if not, add the number to the array
                    If curnum <> "-" Then
                        If ignore = True Then
                            ignore = False
                        Else
                            Dim newval As New genetic_valuesStruct
                            With newval
                                .m_iStart = curstart
                                .m_iEnd = i
                                .m_fNumber = curnum
                            End With
                            r.Add(newval)
                        End If
                    End If
                    curstart = -1 'Resetting
                End If
                curnum = "" 'Resetting
            End If
        Next
        Return r
    End Function

    'Applies an array of genetic_valuesStruct to a string of a neural network
    Function applyNewValues(ByVal str As String, ByRef vals As genetic_valuesStruct())
        Dim r As String = str
        Dim offset As Integer = 0 'Takes care of changes in number length changes
        For Each v In vals
            r = r.Substring(0, v.m_iStart + offset) & v.m_fNumber & r.Substring(v.m_iEnd + offset)
            offset += (CType(v.m_fNumber, String).Length - (v.m_iEnd - v.m_iStart)) 'If the physical length of the new number differs from the old one, then increase the offset
        Next
        Return r
    End Function

    'Edit values in an array of genetic_valuesStruct
    Sub applyMutation_Edit(ByRef nn As NeuralNetwork)
        Dim numbers As genetic_valuesStruct() = getNumerics(nn)

        'We have an arr containing every number, loop through and randomly adjust the values
        For i As Integer = 0 To numbers.Length - 1
            'Decide how much to inc or dec by, highest is +0.5, lowest is -0.5
            numbers(i).m_fNumber += (rng.NextDouble - 0.5)
        Next

        'Now we have new values, sub them into the string
        nn = CType(applyNewValues(nn, numbers), String)
    End Sub

    'Create a connection in the neural network
    Sub applyMutation_Create_Connection(ByRef nn As NeuralNetwork, ByVal flags As Integer)
        Dim n As Object() 'Neurons
        Dim inp As InputNeuron() 'Input neurons
        Dim hid As Neuron() 'Hidden neurons
        Dim out As OutputNeuron() 'Output neurons

        If nn IsNot Nothing AndAlso nn.m_inInputNeurons IsNot Nothing AndAlso nn.m_inInputNeurons.Length > 0 Then
            n = getArrOfNeurons(nn.m_inInputNeurons)
            inp.CopyConvertFrom(getInputNeuronsFromArray(n))
            hid.CopyConvertFrom(getHiddenNeuronsFromArray(n))
            out.CopyConvertFrom(getOutputNeuronsFromArray(n))
        End If

        'n1 connects to n2
        Dim n1 As Integer = rng.Next(If(hid IsNot Nothing AndAlso hid.Length > 0, 2, 1)) '0: Input, 1: Hidden
        Dim n2 As Integer = rng.Next(If(hid IsNot Nothing AndAlso hid.Length > 0, 2, 1)) '0: Output, 1: Hidden

        Dim neuron1 As Neuron
        Dim neuron2 As Neuron

        'Gets a random neuron1 and a random neuron2 depending on n1 and n2

        Select Case n1
            Case 0
                Dim num As Integer = rng.Next(getNumberOfInputs(flags))
                'Is there already an input neuron for the desired input? if not, make one
                If inp IsNot Nothing AndAlso inp.Length - 1 >= num AndAlso inp(num) IsNot Nothing Then
                    neuron1 = inp(num)
                Else
                    neuron1 = New InputNeuron()
                    neuron1.setID(num)
                    nn.m_inInputNeurons.SetValueAtIndex(num, neuron1)
                End If

            Case 1
                neuron1 = hid(rng.Next(hid.Length)) 'Random hidden neuron
        End Select

        Select Case n2
            Case 0
                Dim num As Integer = rng.Next(100)
                'Is there already an output neuron for the desired output? if not, make one
                If out IsNot Nothing AndAlso out.Length - 1 >= num AndAlso out(num) IsNot Nothing Then
                    neuron2 = out(num)
                Else
                    neuron2 = New OutputNeuron(rng.NextDouble() * 10)
                    neuron2.setID(num)
                End If
            Case 1
                neuron2 = hid(rng.Next(hid.Length))
        End Select

        'Connect them
        neuron1.addOutputConnection(neuron2, rng.NextDouble() * 20 - 10)
    End Sub

    'Create a new neuron and its connections in a neural network
    Sub applyMutation_Create_Neuron(ByRef nn As NeuralNetwork, ByVal flags As Integer)
        'A neuron can't exist without connections, due to getArrOfNeurons()
        'Therefor, once a neuron has been created, connections must be made

        'The code is basically the same as applyMutation_Create_Connection, except with a new neuron
        'Only differences in the code will be commented

        Dim n As Object()
        Dim inp As InputNeuron()
        Dim hid As Neuron()
        Dim out As OutputNeuron()

        If nn IsNot Nothing AndAlso nn.m_inInputNeurons IsNot Nothing AndAlso nn.m_inInputNeurons.Length > 0 Then
            n = getArrOfNeurons(nn.m_inInputNeurons)
            inp.CopyConvertFrom(getInputNeuronsFromArray(n))
            hid.CopyConvertFrom(getHiddenNeuronsFromArray(n))
            out.CopyConvertFrom(getOutputNeuronsFromArray(n))
        End If

        Dim new_neuron As New Neuron(rng.NextDouble() * 10) 'The new hidden neuron
        new_neuron.setID(If(hid Is Nothing, 0, hid.Length)) 'Give it an ID
        Dim neuron1 As Neuron
        Dim neuron2 As Neuron

        'n1 connects to n2
        Dim n1 As Integer = rng.Next(If(hid IsNot Nothing AndAlso hid.Length > 0, 2, 1)) '0: Input, 1: Hidden
        Dim n2 As Integer = rng.Next(If(hid IsNot Nothing AndAlso hid.Length > 0, 2, 1)) '0: Output, 1: Hidden

        Select Case n1
            Case 0
                Dim num As Integer = rng.Next(getNumberOfInputs(Flags))

                If inp IsNot Nothing AndAlso inp.Length - 1 >= num AndAlso inp(num) IsNot Nothing Then
                    neuron1 = inp(num)
                Else
                    neuron1 = New InputNeuron()
                    neuron1.setID(num)
                    nn.m_inInputNeurons.SetValueAtIndex(num, neuron1)
                End If

            Case 1
                neuron1 = hid(rng.Next(hid.Length))
        End Select

        Select Case n2
            Case 0
                Dim num As Integer = rng.Next(100)

                If out IsNot Nothing AndAlso out.Length - 1 >= num AndAlso out(num) IsNot Nothing Then
                    neuron2 = out(num)
                Else
                    neuron2 = New OutputNeuron(rng.NextDouble() * 10)
                    neuron2.setID(num)
                End If
            Case 1
                neuron2 = hid(rng.Next(hid.Length))
        End Select

        'Connect neuron1 to new neuron, and new neuron to neuron2
        neuron1.addOutputConnection(new_neuron, rng.NextDouble * 20 - 10)
        new_neuron.addOutputConnection(neuron2, rng.NextDouble * 20 - 10)
    End Sub

    'Switch the values between two networks
    Sub applyCrossover(ByRef nn1 As NeuralNetwork, ByRef nn2 As NeuralNetwork)
        'Get all the numbers
        Dim values1 As genetic_valuesStruct() = getNumerics(nn1)
        Dim values2 As genetic_valuesStruct() = getNumerics(nn2)

        'Store the actual numbers from the values
        Dim numbers1, numbers2 As Decimal()
        For i As Integer = 0 To values1.Length - 1
            numbers1.Add(values1(i).m_fNumber)
        Next
        For i As Integer = 0 To values2.Length - 1
            numbers2.Add(values2(i).m_fNumber)
        Next

        'Sub numbers1 into values2
        For i As Integer = 0 To values2.Length - 1
            If numbers1.Length <= i Then
                Exit For 'Ran out of numbers1
            End If
            values2(i).m_fNumber = numbers1(i)
        Next

        'Sub numbers2 into values1
        For i As Integer = 0 To values1.Length - 1
            If numbers2.Length <= i Then
                Exit For 'Ran out of numbers1
            End If
            values1(i).m_fNumber = numbers2(i)
        Next

        'Apply changes
        nn1 = CType(applyNewValues(nn1, values1), String)
        nn2 = CType(applyNewValues(nn2, values2), String)
    End Sub

    'From input flags, get how many actual inputs can be fed into the neural network
    Function getNumberOfInputs(ByVal flags As Integer)
        'Uses Bitwise. Explained in Flags.vb
        Dim r As Integer = 100
        If (flags And INFLAG_HITS) = INFLAG_HITS Then
            r += 100
        End If
        If (flags And INFLAG_OWN_SHIP_POS) = INFLAG_OWN_SHIP_POS Then
            r += 100
        End If
        If (flags And INFLAG_ENEMY_SHOTS) = INFLAG_ENEMY_SHOTS Then
            r += 100
        End If
        If (flags And INFLAG_ENEMY_HITS) = INFLAG_ENEMY_HITS Then
            r += 100
        End If
        Return r
    End Function

    'Gets the current input offset, what this means is, if the program is dealing with HITS, what index does the input start at for hits?
    'Uses bitwise, explained in Flags.vb
    Function getCurOffset(ByVal flags As Integer, ByVal curflag As Integer)
        Dim cur As Integer = 100
        If (flags And INFLAG_HITS) = INFLAG_HITS Then
            If curflag = INFLAG_HITS Then
                Return cur
            Else
                cur += 100
            End If
        End If
        If (flags And INFLAG_OWN_SHIP_POS) = INFLAG_OWN_SHIP_POS Then
            If curflag = INFLAG_OWN_SHIP_POS Then
                Return cur
            Else
                cur += 100
            End If
        End If
        If (flags And INFLAG_ENEMY_SHOTS) = INFLAG_ENEMY_SHOTS Then
            If curflag = INFLAG_ENEMY_SHOTS Then
                Return cur
            Else
                cur += 100
            End If
        End If
        If (flags And INFLAG_ENEMY_HITS) = INFLAG_ENEMY_HITS Then
            If curflag = INFLAG_ENEMY_HITS Then
                Return cur
            Else
                cur += 100
            End If
        End If
        Return cur
    End Function

    'Gives an array of booleans to be fed directly into a neural network, from the playing grid and the creature number (1 or 2)
    Function gridToInput(ByRef grid As Integer(), ByVal flags As Integer, ByVal c As Integer)
        Dim r As Boolean()
        'Initialise all values to false
        For i As Integer = 0 To getNumberOfInputs(flags) - 1
            r.Add(False)
        Next

        For i As Integer = 0 To grid.Length - 1
            'If it shot
            If (grid(i) And If(c = 1, GFLAG_C1_SHOT, GFLAG_C2_SHOT)) = If(c = 1, GFLAG_C1_SHOT, GFLAG_C2_SHOT) Then
                r(i) = True
            End If
            'If it is a hit, and it cares about hits
            If (grid(i) And If(c = 1, GFLAG_C1_HIT, GFLAG_C2_HIT)) = If(c = 1, GFLAG_C1_HIT, GFLAG_C2_HIT) Then
                If (flags And INFLAG_HITS) = INFLAG_HITS Then
                    r(getCurOffset(flags, INFLAG_HITS) + i) = True
                End If
            End If
            'If it is its own ship, and it cares
            If (grid(i) And If(c = 1, GFLAG_C1_SHIP, GFLAG_C2_SHIP)) = If(c = 1, GFLAG_C1_SHIP, GFLAG_C2_SHIP) Then
                If (flags And INFLAG_OWN_SHIP_POS) = INFLAG_OWN_SHIP_POS Then
                    r(getCurOffset(flags, INFLAG_OWN_SHIP_POS) + i) = True
                End If
            End If
            'If it is an enemy shot and it cares
            If (grid(i) And If(c = 1, GFLAG_C2_SHOT, GFLAG_C1_SHOT)) = If(c = 1, GFLAG_C2_SHOT, GFLAG_C1_SHOT) Then
                If (flags And INFLAG_ENEMY_SHOTS) = INFLAG_ENEMY_SHOTS Then
                    r(getCurOffset(flags, INFLAG_ENEMY_SHOTS) + i) = True
                End If
            End If
            'If it is an enemy hit and it cares
            If (grid(i) And If(c = 1, GFLAG_C2_HIT, GFLAG_C1_HIT)) = If(c = 1, GFLAG_C2_HIT, GFLAG_C1_HIT) Then
                If (flags And INFLAG_ENEMY_HITS) = INFLAG_ENEMY_HITS Then
                    r(getCurOffset(flags, INFLAG_ENEMY_HITS) + i) = True
                End If
            End If
        Next
        Return r
    End Function

    'Called to update the ELO of creatures depending on the winrates
    Public Sub updateELO(ByRef c1 As Creature, ByRef c2 As Creature, ByVal c1winrate As Decimal)
        Dim q1 As Decimal = Math.Pow(10, c1.m_iELO / 400) 'Elo equation
        Dim q2 As Decimal = Math.Pow(10, c2.m_iELO / 400)
        Dim e1 As Decimal = q1 / (q1 + q2) 'Expected score for c1
        Dim e2 As Decimal = q2 / (q1 + q2) 'Expected score for c2

        'Adjust ELOs
        c1.m_iELO += 32 * (c1winrate - e1) 'Elo equation
        c2.m_iELO += 32 * ((1 - c1winrate) - e2) '1-c1winrate = c2winrate
    End Sub

    'Each creature gets a slice of pie, the better the creature is, the bigger the slice.
    'Randomly picks a creature, the bigger its slice of pie, the more likely it is to be picked.
    Public Function roulleteWheelSelection(ByRef gen As Creature())
        Dim elosum As Integer = 0 'The total ELO in the generation, used for percentage later
        For Each c In gen
            elosum += c.m_iELO
        Next
        Dim curoffset As Integer = 0 'Current offset
        Dim rand As Integer = rng.Next(101) '0-100
        For Each c In gen
            Dim pospercent = curoffset + (c.m_iELO / elosum) * 100 'offset + percent of pie
            'if its picked, return it
            If rand <= pospercent Then
                Return c
            End If
            curoffset = pospercent 'increase curoffset, so that two creatures dont get part of the same pie
        Next
    End Function
End Module