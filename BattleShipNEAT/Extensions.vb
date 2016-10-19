Imports System.Runtime.CompilerServices

'Has all extensions (functions for default data types)
Module Extensions
    'Add(element), adds an element to the end of an array
    <Extension()> _
    Public Sub Add(Of T)(ByRef arr As T(), ByVal item As T)
        Array.Resize(arr, If(arr Is Nothing, 1, arr.Length + 1))
        arr(arr.Length - 1) = item
    End Sub

    'ConcatNew(second), concatenates two arrays together, there was already a default concat function but was causing problems.
    <Extension()> _
    Public Sub ConcatNew(Of T)(ByRef arr As T(), ByRef arr2 As T())
        If arr Is Nothing Then
            If arr2 IsNot Nothing Then
                arr = arr2
            End If
        Else
            If arr2 IsNot Nothing Then
                Dim temp As Integer = arr.Length
                Array.Resize(arr, arr.Length + arr2.Length)
                For Each element In arr2
                    arr(temp) = element
                    temp += 1
                Next
            End If
        End If
    End Sub

    'SetValueAtIndex(index, value), safely sets a value to a specific index, there was already SetValue(value, index), but wouldn't work with undefined arrays.
    <Extension()> _
    Public Sub SetValueAtIndex(Of T)(ByRef arr As T(), ByRef index As Integer, ByRef value As T)
        If arr Is Nothing OrElse arr.Length - 1 < index Then
            Array.Resize(arr, index + 1)
        End If
        arr(index) = value
    End Sub

    'CopyConvertFrom(arr), sets the array's value equal to the paramter, but converts the data type
    <Extension()> _
    Public Sub CopyConvertFrom(Of T)(ByRef arr As T(), ByRef arr2 As Object())
        If arr2 IsNot Nothing AndAlso arr2.Length > 0 Then
            For Each ele In arr2
                arr.Add(ele)
            Next
        End If
    End Sub
End Module
