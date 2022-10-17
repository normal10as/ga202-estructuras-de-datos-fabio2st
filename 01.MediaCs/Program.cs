using System;

static class Program
{
    public static void Main(string[] args)
    {
        int[] numeros;
        numeros = IngresarNumeros();
        Output(numeros);
    }
    public static int[] IngresarNumeros() // Devuelve array de enteros
    {
        int[] numeros = new int[5];
        for (byte x = 1; x <= numeros.Length; x++)
        {
            Console.Write("Ingrese {0}º número: ", x);
            numeros[x - 1] = Convert.ToInt32( Console.ReadLine());
        }
        return numeros;
    }
    public static int CalcularSuma(int[] numeros)
    {
        int suma = 0;
        foreach (int numero in numeros)
            suma += numero;
        return suma;
    }
    public static float CalcularMedia(int[] numeros)
    {
        return CalcularSuma(numeros) / numeros.Length;
    }
    public static void Output(int[] numeros)
    {
        Console.WriteLine("Sumatoria: " + CalcularSuma(numeros));
        Console.WriteLine("Media: " + CalcularMedia(numeros));
        OutputDesviacion(numeros);
    }
    public static void OutputDesviacion(int[] numeros)
    {
        float media = CalcularMedia(numeros);
        Console.WriteLine("Valor - Desviacion");
        foreach (int numero in numeros)
            Console.WriteLine(numero + " " + (numero - media));
    }
}
