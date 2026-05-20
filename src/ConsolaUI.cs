using System;

/// <summary>
/// Maneja toda la interacción con la consola.
/// </summary>
public class ConsolaUI
{
    /// <summary>
    /// Muestra el menú principal.
    /// </summary>
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

    /// <summary>
    /// Lee la opción seleccionada por el usuario.
    /// </summary>
    /// <returns>Opción ingresada.</returns>
    public static int LeerOpcion()
    {
        try
        {
            return Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            return -1;
        }
    }

    /// <summary>
    /// Solicita un monto al usuario.
    /// </summary>
    /// <param name="mensaje">Mensaje a mostrar.</param>
    /// <returns>Monto ingresado.</returns>
    public static decimal LeerMonto(string mensaje)
    {
        Console.Write(mensaje);
        return Convert.ToDecimal(Console.ReadLine());
    }

    /// <summary>
    /// Solicita un texto al usuario.
    /// </summary>
    /// <param name="mensaje">Mensaje a mostrar.</param>
    /// <returns>Texto ingresado.</returns>
    public static string LeerTexto(string mensaje)
    {
        string texto = "";

        while (texto == "")
        {
            Console.Write(mensaje);
            texto = Console.ReadLine();
        }

        return texto;
    }

    /// <summary>
    /// Muestra el saldo actual.
    /// </summary>
    /// <param name="saldo">Saldo actual.</param>
    public static void MostrarSaldo(decimal saldo)
    {
        Console.WriteLine("\nSaldo actual: " + saldo + " COP");
    }

    /// <summary>
    /// Muestra un mensaje en consola.
    /// </summary>
    /// <param name="mensaje">Mensaje a mostrar.</param>
    public static void MostrarMensaje(string mensaje)
    {
        Console.WriteLine(mensaje);
    }
}