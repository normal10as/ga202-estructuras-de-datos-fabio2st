using System;

static class Program
{
    public static void Main(string[] args)
    {
        short cantidadAlumnos = IngresarCantidadAlumnos();
        short cantidadNotas = IngresarCantidadNotas();
        string[] alumnos = new string[cantidadAlumnos - 1 + 1];
        byte[,] notas = new byte[cantidadAlumnos - 1 + 1, cantidadNotas - 1 + 1];
        decimal[] promedios = new decimal[cantidadAlumnos - 1 + 1];
        Process(alumnos, notas, promedios);
        OutputMejoresPromedios(alumnos, promedios);
    }

    private static short IngresarCantidadAlumnos()
    {
        Int16 cantidadAlumnos;
        do
        {
            Console.Write("Ingrese la cantidad de alumnos (40 máximo): ");
            cantidadAlumnos = Convert.ToInt16( Console.ReadLine());
        }
        while (cantidadAlumnos > 40);
        return cantidadAlumnos;
    }
    private static short IngresarCantidadNotas()
    {
        Int16 cantidadNotas;
        do
        {
            Console.Write("Ingrese la cantidad de Notas (4 máximo): ");
            cantidadNotas = Convert.ToInt16(Console.ReadLine());
        }
        while (cantidadNotas > 4);
        return cantidadNotas;
    }
    private static void Process(string[] alumnos, byte[,] notas, decimal[] promedios)
    {
        for (var alumnoIndex = 0; alumnoIndex <= alumnos.Length - 1; alumnoIndex++)
        {
            alumnos[alumnoIndex] = IngresarAlumno(alumnos);
            IngresarNotas(notas, alumnoIndex);
            promedios[alumnoIndex] = PromediarNotas(notas, alumnoIndex);
            OutputResultadoAlumno(promedios[alumnoIndex]);
        }
    }
    private static string IngresarAlumno(string[] alumnos)
    {
        string nombre;
        do
        {
            Console.Write("Ingrese el nombre: ");
            nombre = Console.ReadLine();
        }
        while (!IsNombreValido(nombre, alumnos));
        return nombre;
    }
    public static bool IsNombreValido(string nombre, string[] alumnos)
    {
        if (nombre.Length < 3)
        {
            Console.WriteLine("El nombre debe tener al menos 3 caracteres");
            return false;
        }
        foreach (string item in alumnos)
        {
            if (nombre == item)
            {
                Console.WriteLine("El alumno ya existe");
                return false;
            }
        }
        return true;
    }
    private static void IngresarNotas(byte[,] notas, int alumnoIndex)
    {
        for (var notaIndex = 0; notaIndex <= notas.GetLength(1) - 1; notaIndex++)
        {
            short nota;
            do
            {
                Console.Write($"Ingrese la {notaIndex + 1}º nota: ");
                nota = Convert.ToInt16(Console.ReadLine());
            }
            while (!IsNotaValida(nota));
            notas[alumnoIndex, notaIndex] = (byte)nota;
        }
    }
    private static bool IsNotaValida(short nota)
    {
        if (nota >= 0 & nota <= 10)
            return true;
        else
        {
            Console.WriteLine("Nota fuera de rango!");
            return false;
        }
    }
    private static decimal PromediarNotas(byte[,] notas, int alumnoIndex)
    {
        decimal total = 0;
        for (var notaIndex = 0; notaIndex <= notas.GetLength(1) - 1; notaIndex++)
            total += notas[alumnoIndex, notaIndex];
        return total / notas.GetLength(1);
    }
    private static void OutputResultadoAlumno(decimal promedio)
    {
        if (promedio >= 6)
            Console.WriteLine("El alumno Aprobo con " + promedio);
        else
            Console.WriteLine("El alumno Desaprobo con " + promedio);
    }
    private static void OutputMejoresPromedios(string[] alumnos, decimal[] promedios)
    {
        decimal mejorNota = GetMejorNota(promedios);
        Console.WriteLine($"Mejores alumnos con {mejorNota} de promedio");
        for (var index = 0; index <= promedios.Length - 1; index++)
        {
            if (promedios[index] == mejorNota)
                Console.WriteLine(alumnos[index]);
        }
    }
    private static decimal GetMejorNota(decimal[] promedios)
    {
        decimal mejorNota = 0;
        foreach (decimal promedio in promedios)
        {
            if (promedio > mejorNota)
                mejorNota = promedio;
        }
        return mejorNota;
    }
}