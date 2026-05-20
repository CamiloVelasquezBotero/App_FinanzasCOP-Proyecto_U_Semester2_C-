using System;
using System.Collections.Generic;

/// <summary>
/// Contiene la lógica de negocio del sistema financiero.
/// </summary>
public class MovimientoService
{
    public static List<Movimiento> gastos = new List<Movimiento>();

    /// <summary>
    /// Calcula el nuevo saldo después de un ingreso.
    /// </summary>
    /// <param name="saldo">Saldo actual.</param>
    /// <param name="monto">Monto del ingreso.</param>
    /// <returns>Nuevo saldo.</returns>
    public static decimal RegistrarIngreso(decimal saldo, decimal monto)
    {
        if (monto <= 0)
        {
            return saldo;
        }

        return saldo + monto;
    }

    /// <summary>
    /// Registra un gasto y actualiza el saldo.
    /// </summary>
    /// <param name="saldo">Saldo actual.</param>
    /// <param name="movimiento">Movimiento de gasto.</param>
    /// <returns>Nuevo saldo.</returns>
    public static decimal RegistrarGasto(decimal saldo, Movimiento movimiento)
    {
        gastos.Add(movimiento);

        return saldo - movimiento.Monto;
    }

    /// <summary>
    /// Obtiene todos los gastos registrados.
    /// </summary>
    /// <returns>Lista de gastos.</returns>
    public static List<Movimiento> ObtenerGastos()
    {
        return gastos;
    }

    /// <summary>
    /// Filtra gastos por categoría.
    /// </summary>
    /// <param name="categoria">Categoría a buscar.</param>
    /// <returns>Lista filtrada.</returns>
    public static List<Movimiento> FiltrarPorCategoria(string categoria)
    {
        List<Movimiento> filtrados = new List<Movimiento>();

        foreach (Movimiento mov in gastos)
        {
            if (mov.Categoria.ToLower() == categoria.ToLower())
            {
                filtrados.Add(mov);
            }
        }

        return filtrados;
    }
}