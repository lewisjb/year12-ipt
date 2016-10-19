Module Flags
    '<< is the bitshift operator. Example: 1 in binary is 00000001, but 1 << 1 is 00000010, thus equaling 2
    'Other bitwise operators are: And, Or, Xor, Not, etc and act as logic gates do.
    'Example:
    '10000000
    '   OR
    '00000001
    '=
    '10000001
    'A.K.A, if there is a 1 in that spot for either number, then there will be a 1 in the result


    '10000000
    '  AND
    '11110001
    '=
    '10000000
    'A.K.A, if there is a 1 in both numbers at the spot, there will be a 1 in the result

    'Xor is exclusive or, which means if there is a 1 in ONLY 1 of the numbers
    'Not is inverse, so there is only 1 number that Not is used on, and it switches the 1s into 0s and the 0s into 1s

    'Input Neuron Flags
    Public Const INFLAG_DEFAULT = 0 'Default is just own shots
    Public Const INFLAG_HITS = (1 << 0)
    Public Const INFLAG_OWN_SHIP_POS = (1 << 1)
    Public Const INFLAG_ENEMY_SHOTS = (1 << 2)
    Public Const INFLAG_ENEMY_HITS = (1 << 3)

    'Grid Flags
    Public Const GFLAG_C1_SHOT = 1
    Public Const GFLAG_C1_HIT = (1 << 1)
    Public Const GFLAG_C1_SHIP = (1 << 2)
    Public Const GFLAG_C2_SHOT = (1 << 3)
    Public Const GFLAG_C2_HIT = (1 << 4)
    Public Const GFLAG_C2_SHIP = (1 << 5)
End Module
