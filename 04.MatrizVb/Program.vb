Imports System

Module Program
    Sub Main(args As String())
        Const filas = 4
        Const columnas = 5
        Dim numeros(filas - 1, columnas - 1) As Integer
        Input(numeros)
        Output(numeros)
    End Sub
    Private Sub Input(numeros(,) As Integer)
        For fila = 0 To numeros.GetLength(0) - 1
            For columna = 0 To numeros.GetLength(1) - 1
                Console.Write($"Ingrese posición {fila},{columna}: ")
                numeros(fila, columna) = Console.ReadLine()
            Next
        Next
    End Sub
    Private Sub Output(numeros(,) As Integer)
        OutputMatriz(numeros)
        OutputTotalesColumnas(numeros)
        Dim maximo As Integer = GetMaximo(numeros)
        Console.WriteLine($"Posiciones del máximo: {maximo}")
        OutputPosicionValor(numeros, maximo)
        Dim minimo As Integer = GetMinimo(numeros)
        Console.WriteLine($"Posiciones del mínimo: {minimo}")
        OutputPosicionValor(numeros, minimo)
    End Sub
    Private Sub OutputMatriz(numeros(,) As Integer)
        For fila = 0 To numeros.GetLength(0) - 1
            Dim totalColumna = 0
            For columna = 0 To numeros.GetLength(1) - 1
                Console.Write($"{numeros(fila, columna),8:N0}")
                totalColumna += numeros(fila, columna)
            Next
            Console.WriteLine($" --> {totalColumna,8:N0}")
        Next
    End Sub
    Private Sub OutputTotalesColumnas(numeros(,) As Integer)
        For columna = 0 To numeros.GetLength(1) - 1
            Dim totalFila = 0
            For fila = 0 To numeros.GetLength(0) - 1
                totalFila += numeros(fila, columna)
            Next
            Console.Write($"{totalFila,8:N0}")
        Next
        Console.WriteLine("")
    End Sub
    Private Function GetMaximo(numeros(,) As Integer) As Integer
        Dim maximo As Integer = Integer.MinValue
        For Each numero As Integer In numeros
            If numero > maximo Then
                maximo = numero
            End If
        Next
        Return maximo
    End Function
    Private Function GetMinimo(numeros(,) As Integer) As Integer
        Dim minimo As Integer = Integer.MaxValue
        For Each numero As Integer In numeros
            If numero < minimo Then
                minimo = numero
            End If
        Next
        Return minimo
    End Function
    Private Sub OutputPosicionValor(numeros(,) As Integer, valor As Integer)
        For fila = 0 To numeros.GetLength(0) - 1
            For columna = 0 To numeros.GetLength(1) - 1
                If numeros(fila, columna) = valor Then
                    Console.WriteLine($"{fila},{columna}")
                End If
            Next
        Next
    End Sub
End Module
