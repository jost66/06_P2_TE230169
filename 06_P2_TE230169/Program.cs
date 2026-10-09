// Muestra el título del programa en consola
Console.WriteLine("SISTEMA DE INSPECCIÓN DE LOTE DE PIEZAS");
Console.WriteLine();

// Crea el objeto lote1 de la clase InspeccionLote
InspeccionLote lote1 = new InspeccionLote();

// Ciclo for que se ejecuta 10 veces para evaluar 10 piezas del lote
for (int i = 1; i <= 10; i++)
{
    int valor;
    // Ciclo while interno para validar que el usuario ingrese únicamente 1 o 0
    while (true)
    {
        Console.Write($"Pieza #{i} (Ingrese 1 para correcta, 0 para defectuosa): ");
        valor = Convert.ToInt32(Console.ReadLine());

        if (valor == 1 || valor == 0) break; // Si es válido, sale del ciclo de validación
        Console.WriteLine("Valor inválido. Solo se permite 1 o 0.");
    }

    // Evalúa si la pieza es correcta (1) o defectuosa (0) y aumenta el contador respectivo
    if (valor == 1) lote1.PiezasCorrectas++;
    else lote1.PiezasDefectuosas++;
}

// Muestra los resultados totales, el porcentaje y el dictamen del lote
Console.WriteLine();
Console.WriteLine($"Total de piezas correctas: {lote1.PiezasCorrectas}");
Console.WriteLine($"Total de piezas defectuosas: {lote1.PiezasDefectuosas}");
Console.WriteLine($"Porcentaje de correctas: {lote1.CalcularPorcentaje():F2}%");
Console.WriteLine($"Estado del lote: {lote1.ObtenerEstadoLote()}");

// Definición de la clase InspeccionLote
class InspeccionLote
{
    // Propiedad para llevar la cuenta de piezas correctas (inicia en 0)
    public int PiezasCorrectas { get; set; } = 0;
    // Propiedad para llevar la cuenta de piezas defectuosas (inicia en 0)
    public int PiezasDefectuosas { get; set; } = 0;

    // Método que calcula el porcentaje de piezas correctas sobre el total de 10
    public double CalcularPorcentaje()
    {
        int total = PiezasCorrectas + PiezasDefectuosas;
        if (total == 0) return 0;
        return ((double)PiezasCorrectas / total) * 100.0;
    }

    // Método que evalúa si el porcentaje cumple con el mínimo del 90% para ser aceptado
    public string ObtenerEstadoLote()
    {
        if (CalcularPorcentaje() >= 90) return "ACEPTADO";
        else return "RECHAZADO";
    }
}