static class Ventas
{
    public static void Main(string[] args)
    {
        ushort[] codigos = new ushort[] { 1, 2, 5 };
        string[] nombres = new string[] { "papa", "manzana", "uva" };
        decimal[] precios = new decimal[] { 2.6M, 1.2M, 4.5M };
        Process(codigos, nombres, precios);
    }
    private static void Process(ushort[] codigos, string[] nombres, decimal[] precios)
    {
        ushort codigo;
        decimal total = 0;
        codigo = LeerCodigo();
        while (codigo != 0)
        {
            if (isCodigoExiste(codigo, codigos))
            {
                total += ProcessProduct(codigos, nombres, precios, codigo);
                Console.WriteLine("Total: " + total);
            }
            else
                Console.WriteLine("Código no existe");
            codigo = LeerCodigo();
        }
    }
    private static decimal ProcessProduct(ushort[] codigos, string[] nombres, decimal[] precios, ushort codigo)
    {
        ushort index;
        decimal cantidad, subtotal;
        index = GetIndex(codigo, codigos);
        Console.WriteLine("Producto: " + nombres[index]);
        Console.WriteLine("Precio: " + precios[index]);
        Console.Write("Ingrese cantidad: ");
        cantidad = Convert.ToDecimal( Console.ReadLine());
        subtotal = precios[index] * cantidad;
        Console.WriteLine("SubTotal: " + subtotal);
        return subtotal;
    }
    public static ushort LeerCodigo()
    {
        Console.Write("Ingrese un codigo de producto: ");
        return Convert.ToUInt16( Console.ReadLine());
    }
    public static bool isCodigoExiste(ushort codigo, ushort[] codigos)
    {
        foreach (var valor in codigos)
        {
            if (valor == codigo)
                return true;
        }
        return false;
    }
    public static ushort GetIndex(ushort codigo, ushort[] codigos)
    {
        for (ushort x = 0; x <= codigos.Length - 1; x++)
        {
            if (codigo == codigos[x])
                return x;
        }
        return default(ushort);
    }
}