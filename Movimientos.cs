using System;

public class Movimientos
{
    public static decimal RegistrarIngreso(decimal saldo)
    {
        decimal monto;
        string categoria;
        string descripcion;

        Console.Write("Ingrese el monto del ingreso (COP): ");
        monto = Convert.ToDecimal(Console.ReadLine());

        if (monto <= 0)
        {
            Console.WriteLine("Error: el monto debe ser mayor que 0");
            return saldo;
        }

        Console.Write("Ingrese la categoria del ingreso: ");
        categoria = Console.ReadLine();

        Console.Write("Descripcion del ingreso: ");
        descripcion = Console.ReadLine();

        saldo = saldo + monto;

        Console.WriteLine("\nIngreso registrado correctamente");
        Console.WriteLine("Categoria: " + categoria);
        Console.WriteLine("Descripcion: " + descripcion);
        Console.WriteLine("Monto: " + monto + " COP");
        Console.WriteLine("Saldo actual: " + saldo + " COP");

        return saldo;
    }

    public static decimal RegistrarGasto(decimal saldo)
    {
        decimal monto;
        string categoria;
        string descripcion;

        Console.Write("Ingrese el monto del gasto (COP): ");
        monto = Convert.ToDecimal(Console.ReadLine());

        if (monto <= 0)
        {
            Console.WriteLine("Error: el monto debe ser mayor que 0");
            return saldo;
        }

        Console.Write("Ingrese la categoria del gasto: ");
        categoria = Console.ReadLine();

        Console.Write("Descripcion del gasto: ");
        descripcion = Console.ReadLine();

        saldo = saldo - monto;

        if (monto > 200000)
        {
            Console.WriteLine("Advertencia: gasto alto detectado");
        }

        if (saldo < 0)
        {
            Console.WriteLine("Alerta: saldo negativo");
        }

        Console.WriteLine("\nGasto registrado correctamente");
        Console.WriteLine("Categoria: " + categoria);
        Console.WriteLine("Descripcion: " + descripcion);
        Console.WriteLine("Monto: " + monto + " COP");
        Console.WriteLine("Saldo actual: " + saldo + " COP");

        return saldo;
    }
}
