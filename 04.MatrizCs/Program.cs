using System;

static class Program
{
    public static void Main(string[] args)
    {
        const byte filas = 4;
        const byte columnas = 5;
        int[,] numeros = new int[filas, columnas];
        Input(numeros);
        Output(numeros);
    }
    private static void Input(int[,] numeros)
    {
        for (int fila = 0; fila <= numeros.GetLength(0) - 1; fila++)
        {
            for (int columna = 0; columna <= numeros.GetLength(1) - 1; columna++)
            {
                Console.Write($"Ingrese posición {fila},{columna}: ");
                numeros[fila, columna] = Convert.ToInt32( Console.ReadLine());
            }
        }
    }
    private static void Output(int[,] numeros)
    {
        OutputMatriz(numeros);
        OutputTotalesColumnas(numeros);
        int maximo = GetMaximo(numeros);
        Console.WriteLine($"Posiciones del máximo: {maximo}");
        OutputPosicionValor(numeros, maximo);
        int minimo = GetMinimo(numeros);
        Console.WriteLine($"Posiciones del mínimo: {minimo}");
        OutputPosicionValor(numeros, minimo);
    }
    private static void OutputMatriz(int[,] numeros)
    {
        for (int fila = 0; fila <= numeros.GetLength(0) - 1; fila++)
        {
            int totalColumna = 0;
            for (int columna = 0; columna <= numeros.GetLength(1) - 1; columna++)
            {
                Console.Write($"{numeros[fila, columna],8:N0}");
                totalColumna += numeros[fila, columna];
            }
            Console.WriteLine($" --> {totalColumna,8:N0}");
        }
    }
    private static void OutputTotalesColumnas(int[,] numeros)
    {
        for (int columna = 0; columna <= numeros.GetLength(1) - 1; columna++)
        {
            int totalFila = 0;
            for (int fila = 0; fila <= numeros.GetLength(0) - 1; fila++)
                totalFila += numeros[fila, columna];
            Console.Write($"{totalFila,8:N0}");
        }
        Console.WriteLine("");
    }
    private static int GetMaximo(int[,] numeros)
    {
        int maximo = int.MinValue;
        foreach (int numero in numeros)
        {
            if (numero > maximo)
                maximo = numero;
        }
        return maximo;
    }
    private static int GetMinimo(int[,] numeros)
    {
        int minimo = int.MaxValue;
        foreach (int numero in numeros)
        {
            if (numero < minimo)
                minimo = numero;
        }
        return minimo;
    }
    private static void OutputPosicionValor(int[,] numeros, int valor)
    {
        for (int fila = 0; fila <= numeros.GetLength(0) - 1; fila++)
        {
            for (int columna = 0; columna <= numeros.GetLength(1) - 1; columna++)
            {
                if (numeros[fila, columna] == valor)
                    Console.WriteLine($"{fila},{columna}");
            }
        }
    }
}