Imports System

Module Ventas
    Sub Main(args As String())
        Dim codigos = New UShort() {1, 2, 5}
        Dim nombres = New String() {"papa", "manzana", "uva"}
        Dim precios = New Decimal() {2.6, 1.2, 4.5}
        Process(codigos, nombres, precios)
    End Sub
    Private Sub Process(codigos() As UShort, nombres() As String, precios() As Decimal)
        Dim codigo As UShort
        Dim total As Decimal
        codigo = LeerCodigo()
        Do Until codigo = 0
            If isCodigoExiste(codigo, codigos) Then
                total += ProcessProduct(codigos, nombres, precios, codigo)
                Console.WriteLine("Total: " & total)
            Else
                Console.WriteLine("Código no existe")
            End If
            codigo = LeerCodigo()
        Loop
    End Sub
    Private Function ProcessProduct(codigos() As UShort, nombres() As String, precios() As Decimal, codigo As UShort) As Decimal
        Dim index As UShort
        Dim cantidad, subtotal As Decimal
        index = GetIndex(codigo, codigos)
        Console.WriteLine("Producto: " & nombres(index))
        Console.WriteLine("Precio: " & precios(index))
        Console.Write("Ingrese cantidad: ")
        cantidad = Console.ReadLine()
        subtotal = precios(index) * cantidad
        Console.WriteLine("SubTotal: " & subtotal)
        Return subtotal
    End Function
    Function LeerCodigo() As UShort
        Console.Write("Ingrese un codigo de producto: ")
        Return Console.ReadLine()
    End Function
    Function isCodigoExiste(codigo As UShort, codigos() As UShort) As Boolean
        For Each valor In codigos
            If valor = codigo Then
                Return True
            End If
        Next
        Return False
    End Function
    Function GetIndex(codigo As UShort, codigos() As UShort) As UShort
        For x = 0 To codigos.Length - 1
            If codigo = codigos(x) Then
                Return x
            End If
        Next
        Return Nothing
    End Function
End Module