using System;

public class SistemaMenu
{
    public static void IniciarSistema()
    {
        int opcion = 0;
        decimal saldo = 0;

        while (opcion != 5)
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
            else if(opcion == 4) {
                Movimientos.VerGastos();
            }
            else if (opcion == 5)
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
        Console.WriteLine("4. Ver historial de gastos");
        Console.WriteLine("5. Salir");
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

    /// <summary>
    /// Muestra el menú del historial.
    /// </summary>
    static void MostrarMenuHistorial()
    {
        Console.WriteLine("\n1. Ver historial completo");
        Console.WriteLine("2. Filtrar por categoria");

        int opcion = ConsolaUI.LeerOpcion();

        if (opcion == 1)
        {
            MostrarHistorialCompleto();
        }
        else if (opcion == 2)
        {
            FiltrarHistorial();
        }
    }

    static void MostrarHistorialCompleto()
    {
        List<Movimiento> gastos = MovimientoService.ObtenerGastos();

        if (gastos.Count == 0)
        {
            ConsolaUI.MostrarMensaje("No hay gastos registrados");
            return;
        }

        foreach (Movimiento mov in gastos)
        {
            Console.WriteLine("\n====================");
            Console.WriteLine("Categoria: " + mov.Categoria);
            Console.WriteLine("Descripcion: " + mov.Descripcion);
            Console.WriteLine("Monto: " + mov.Monto);
        }
    }

    static void FiltrarHistorial()
    {
        string categoria = ConsolaUI.LeerTexto("Ingrese la categoria: ");

        List<Movimiento> filtrados = MovimientoService.FiltrarPorCategoria(categoria);

        if (filtrados.Count == 0)
        {
            ConsolaUI.MostrarMensaje("No se encontraron gastos");
            return;
        }

        foreach (Movimiento mov in filtrados)
        {
            Console.WriteLine("\n====================");
            Console.WriteLine("Categoria: " + mov.Categoria);
            Console.WriteLine("Descripcion: " + mov.Descripcion);
            Console.WriteLine("Monto: " + mov.Monto);
        }
    }
}
