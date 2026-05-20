using System;
using System.Collections.Generic;

public class SistemaMenu
{
    public static void IniciarSistema()
    {
        int opcion = 0;
        decimal saldo = 0;

        while (opcion != 5)
        {
            ConsolaUI.MostrarMenu();

            opcion = ConsolaUI.LeerOpcion();

            switch (opcion)
            {
                case 1:
                    saldo = ProcesarIngreso(saldo);
                    break;

                case 2:
                    saldo = ProcesarGasto(saldo);
                    break;

                case 3:
                    ConsolaUI.MostrarSaldo(saldo);
                    break;

                case 4:
                    MostrarMenuHistorial();
                    break;

                case 5:
                    ConsolaUI.MostrarMensaje("Saliendo del sistema...");
                    break;

                default:
                    ConsolaUI.MostrarMensaje("Opcion invalida");
                    break;
            }
        }
    }

    /// <summary>
    /// Procesa el registro de un ingreso.
    /// </summary>
    static decimal ProcesarIngreso(decimal saldo)
    {
        decimal monto = ConsolaUI.LeerMonto("Ingrese el monto del ingreso (COP): ");

        string categoria = ConsolaUI.LeerTexto("Ingrese la categoria: ");
        string descripcion = ConsolaUI.LeerTexto("Ingrese la descripcion: ");

        decimal nuevoSaldo = MovimientoService.RegistrarIngreso(saldo, monto);

        ConsolaUI.MostrarMensaje("Ingreso registrado correctamente");

        return nuevoSaldo;
    }

    /// <summary>
    /// Procesa el registro de un gasto.
    /// </summary>
    static decimal ProcesarGasto(decimal saldo)
    {
        decimal monto = ConsolaUI.LeerMonto("Ingrese el monto del gasto (COP): ");

        string categoria = ConsolaUI.LeerTexto("Ingrese categoria: ");
        string descripcion = ConsolaUI.LeerTexto("Ingrese descripcion: ");

        Movimiento movimiento = new Movimiento(categoria, descripcion, monto);

        decimal nuevoSaldo = MovimientoService.RegistrarGasto(saldo, movimiento);

        if (monto > 200000)
        {
            ConsolaUI.MostrarMensaje("Advertencia: gasto alto detectado");
        }

        if (nuevoSaldo < 0)
        {
            ConsolaUI.MostrarMensaje("Alerta: saldo negativo");
        }

        return nuevoSaldo;
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
