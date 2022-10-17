Imports System

Module Program
    Sub Main(args As String())
        Dim cantidadAlumnos As Short = IngresarCantidadAlumnos()
        Dim cantidadNotas As Short = IngresarCantidadNotas()
        Dim alumnos(cantidadAlumnos - 1) As String
        Dim notas(cantidadAlumnos - 1, cantidadNotas - 1) As Byte
        Dim promedios(cantidadAlumnos - 1) As Decimal
        Process(alumnos, notas, promedios)
        OutputMejoresPromedios(alumnos, promedios)
    End Sub

    Private Function IngresarCantidadAlumnos() As Short
        Dim cantidadAlumnos As Int16
        Do
            Console.Write("Ingrese la cantidad de alumnos (40 máximo): ")
            cantidadAlumnos = Console.ReadLine()
        Loop Until cantidadAlumnos <= 40
        Return cantidadAlumnos
    End Function
    Private Function IngresarCantidadNotas() As Short
        Dim cantidadNotas As Int16
        Do
            Console.Write("Ingrese la cantidad de Notas (4 máximo): ")
            cantidadNotas = Console.ReadLine()
        Loop Until cantidadNotas <= 4
        Return cantidadNotas
    End Function
    Private Sub Process(alumnos() As String, notas(,) As Byte, promedios() As Decimal)
        For alumnoIndex = 0 To alumnos.Length - 1
            alumnos(alumnoIndex) = IngresarAlumno(alumnos)
            IngresarNotas(notas, alumnoIndex)
            promedios(alumnoIndex) = PromediarNotas(notas, alumnoIndex)
            OutputResultadoAlumno(promedios(alumnoIndex))
        Next
    End Sub
    Private Function IngresarAlumno(alumnos() As String) As String
        Dim nombre As String
        Do
            Console.Write("Ingrese el nombre: ")
            nombre = Console.ReadLine()
        Loop Until IsNombreValido(nombre, alumnos)
        Return nombre
    End Function
    Function IsNombreValido(nombre As String, alumnos() As String) As Boolean
        If nombre.Length < 3 Then
            Console.WriteLine("El nombre debe tener al menos 3 caracteres")
            Return False
        End If
        For Each item As String In alumnos
            If nombre = item Then
                Console.WriteLine("El alumno ya existe")
                Return False
            End If
        Next
        Return True
    End Function
    Private Sub IngresarNotas(notas(,) As Byte, alumnoIndex As Integer)
        For notaIndex = 0 To notas.GetLength(1) - 1
            Dim nota As Short
            Do
                Console.Write($"Ingrese la {notaIndex + 1}º nota: ")
                nota = Console.ReadLine()
            Loop Until IsNotaValida(nota)
            notas(alumnoIndex, notaIndex) = nota
        Next
    End Sub
    Private Function IsNotaValida(nota As Short) As Boolean
        If nota >= 0 And nota <= 10 Then
            Return True
        Else
            Console.WriteLine("Nota fuera de rango!")
            Return False
        End If
    End Function
    Private Function PromediarNotas(notas(,) As Byte, alumnoIndex As Integer) As Decimal
        Dim total As Decimal
        For notaIndex = 0 To notas.GetLength(1) - 1
            total += notas(alumnoIndex, notaIndex)
        Next
        Return total / notas.GetLength(1)
    End Function
    Private Sub OutputResultadoAlumno(promedio As Decimal)
        If promedio >= 6 Then
            Console.WriteLine("El alumno Aprobo con " & promedio)
        Else
            Console.WriteLine("El alumno Desaprobo con " & promedio)
        End If
    End Sub
    Private Sub OutputMejoresPromedios(alumnos() As String, promedios() As Decimal)
        Dim mejorNota As Decimal = GetMejorNota(promedios)
        Console.WriteLine($"Mejores alumnos con {mejorNota} de promedio")
        For index = 0 To promedios.Length - 1
            If promedios(index) = mejorNota Then
                Console.WriteLine(alumnos(index))
            End If
        Next
    End Sub
    Private Function GetMejorNota(promedios() As Decimal) As Decimal
        Dim mejorNota As Decimal
        For Each promedio As Decimal In promedios
            If promedio > mejorNota Then
                mejorNota = promedio
            End If
        Next
        Return mejorNota
    End Function
End Module
