# App Finanzas COP

Sistema de finanzas personales desarrollado en C#.

## Arquitectura

| Archivo | Responsabilidad |
|---|---|
| Program.cs | Punto de entrada |
| SistemaMenu.cs | Orquestación del flujo |
| ConsolaUI.cs | Entrada y salida por consola |
| MovimientoService.cs | Lógica del negocio |
| Movimiento.cs | Modelo de datos |

## Funcionalidades

- Registrar ingresos
- Registrar gastos
- Ver saldo
- Ver historial completo
- Filtrar gastos por categoría
- Alertas de saldo negativo
- Alertas de gastos altos

## Casos de prueba

| Caso | Resultado esperado |
|---|---|
| Registrar gasto negativo | Error |
| Registrar gasto alto | Advertencia |
| Saldo negativo | Alerta |
| Filtrar categoría existente | Lista filtrada |

## Integrantes

- Camilo Velasquez Botero
- Heiner Goez Urrego

#                                               ----- Proyecto Universitario ---