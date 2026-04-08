using System;

public class SistemaMenu
{
    public static void IniciarSistema()
    {
        int opcion = 0;
        decimal saldo = 0;

        while (opcion != 4)
        {
            MostrarMenu();
            opcion = LeerOpcion();

            if (opcion == 1)
            {
                saldo = Movimientos.RegistrarIngreso(saldo);
            }
            else if (opcion == 2)
            {
                saldo = Movimientos.RegistrarGasto(saldo);
            }
            else if (opcion == 3)
            {
                MostrarSaldo(saldo);
            }
            else if (opcion == 4)
            {
                Console.WriteLine("Saliendo del sistema...");
            }
            else
            {
                Console.WriteLine("Opcion invalida");
            }
        }
    }

    public static void MostrarMenu()
    {
        Console.WriteLine("\n===== Sistema de Finanzas Personales (COP) =====");
        Console.WriteLine("1. Registrar ingreso");
        Console.WriteLine("2. Registrar gasto");
        Console.WriteLine("3. Ver saldo actual");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opcion: ");
    }

    public static int LeerOpcion()
    {
        int opcion;

        try
        {
            opcion = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            opcion = -1;
        }

        return opcion;
    }

    public static void MostrarSaldo(decimal saldo)
    {
        Console.WriteLine("\nSaldo actual: " + saldo + " COP");
    }
}
