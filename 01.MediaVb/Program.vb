Imports System

Module Program
    Sub Main(args As String())
        Dim numeros() As Integer
        numeros = IngresarNumeros()
        Output(numeros)
    End Sub
    Function IngresarNumeros() As Integer() 'Devuelve array de enteros
        Dim numeros(4) As Integer
        For x = 1 To numeros.Length
            Console.Write("Ingrese {0}º número: ", x)
            numeros(x - 1) = Console.ReadLine()
        Next
        Return numeros
    End Function
    Function CalcularSuma(numeros() As Integer) As Integer
        Dim suma As Integer
        For Each numero In numeros
            suma += numero
        Next
        Return suma
    End Function
    Function CalcularMedia(numeros() As Integer) As Single
        Return CalcularSuma(numeros) / numeros.Length
    End Function
    Sub Output(numeros() As Integer)
        Console.WriteLine("Sumatoria: " & CalcularSuma(numeros))
        Console.WriteLine("Media: " & CalcularMedia(numeros))
        OutputDesviacion(numeros)
    End Sub
    Sub OutputDesviacion(numeros() As Integer)
        Dim media As Single = CalcularMedia(numeros)
        Console.WriteLine("Valor - Desviacion")
        For Each numero In numeros
            Console.WriteLine(numero & vbTab & numero - media)
        Next
    End Sub
End Module