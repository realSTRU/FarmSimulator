using System;
using System.Threading;

class Program
{
    static void Main()
    {
        //Procedimientos para pedir los datos al usuario para lograr una simulacion mas terminada.
        Console.WriteLine("Simulación de sistema ecológico:");

        Console.Write("Ingrese la población inicial de zorros: ");
        int poblacionZorros = int.Parse(Console.ReadLine());

        Console.Write("Ingrese la población inicial de conejos: ");
        int poblacionConejos = int.Parse(Console.ReadLine());

        Console.Write("Ingrese la cantidad inicial de zanahorias: ");
        int cantidadZanahorias = int.Parse(Console.ReadLine());

        Console.Write("Ingrese el porcentaje de incremento diario de zanahorias (ej. 2 para 2%): ");
        double tasaReproduccionZanahorias = double.Parse(Console.ReadLine()) / 100.0;

        // Tasas de que tanto comen los animales en referencia a los animales existentes.

        double tasaComidaZorros = 0.4; 
        double tasaComidaConejos = 1.0; 

        int diasSimulacion = 31;

        Console.WriteLine();
        Console.WriteLine($"Población inicial de zorros: {poblacionZorros}");
        Console.WriteLine($"Población inicial de conejos: {poblacionConejos}");
        Console.WriteLine($"Cantidad inicial de zanahorias: {cantidadZanahorias}");
        Console.WriteLine();

        // Repeticion simulada con el paso de los dias para un mes.
        for (int dia = 1; dia <= diasSimulacion; dia++)
        {
            Console.WriteLine($"Día {dia}");
            
            
            Console.WriteLine($"Estado inicial - Zorros: {poblacionZorros}, Conejos: {poblacionConejos}, Zanahorias: {cantidadZanahorias}");

            // Calcular comida necesaria y real para zorros
            int comidaZorrosNecesaria = (int)(tasaComidaZorros * poblacionZorros);
            int comidaZorrosReal = Math.Min(comidaZorrosNecesaria, poblacionConejos);
            Console.WriteLine($"Zorros necesitan {comidaZorrosNecesaria} conejos, pero solo pueden comer {comidaZorrosReal} conejos.");

            
            poblacionConejos -= comidaZorrosReal;
            if (poblacionConejos < 0) poblacionConejos = 0;
            Console.WriteLine($"Población de conejos después de ser comidos: {poblacionConejos}");

            // Calcular comida necesaria y real para conejos
            int comidaConejosNecesaria = (int)(tasaComidaConejos * poblacionConejos);
            int comidaConejosReal = Math.Min(comidaConejosNecesaria, cantidadZanahorias);
            Console.WriteLine($"Conejos necesitan {comidaConejosNecesaria} zanahorias, pero solo pueden comer {comidaConejosReal} zanahorias.");

            
            cantidadZanahorias -= comidaConejosReal;
            if (cantidadZanahorias < 0) cantidadZanahorias = 0;
            Console.WriteLine($"Cantidad de zanahorias después de ser comidas: {cantidadZanahorias}");

          
            cantidadZanahorias += (int)(cantidadZanahorias * tasaReproduccionZanahorias);
            Console.WriteLine($"Cantidad de zanahorias después de reproducirse: {cantidadZanahorias}");

            
            if (comidaZorrosReal < comidaZorrosNecesaria)
            {
                poblacionZorros -= 1; // Se produce la realacion si no hay suficientes conejos no habra una estabilidad y empezaran a disminuirse.
            }
            if (poblacionZorros < 0) poblacionZorros = 0;
            Console.WriteLine($"Población de zorros después de ajustar por comida: {poblacionZorros}");
            Console.WriteLine();

            
            Thread.Sleep(2000);
        }

        // Por datos de prueba se puede evaluar la condicion de la siguiente manera
        if (poblacionZorros > 10 || poblacionConejos > 20)
        {
            Console.WriteLine("Se recomienda controlar la población de zorros o conejos.");
        }
        else
        {
            Console.WriteLine("No es necesario controlar la población de zorros ni conejos.");
        }
    }
}
