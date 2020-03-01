using System;

namespace ConsoleApp11
{
    class Program
    {
        static void Main()
        {
            string continuarJuego = "s";
            while (continuarJuego == "s")
            {
                string ganador = "";
                int mayor = 0;
                Console.WriteLine("Dijite la cantidad de juagdores (minimo 2, maximo 7)");
                int n = int.Parse(Console.ReadLine());
                while (n <= 1 || n >= 8)
                {
                    Console.WriteLine("Es imposible jugar con " + n + " jugador(es). Dijite nuevamente la cantidad de juagdores");
                    n = int.Parse(Console.ReadLine());
                }
                Console.WriteLine("\nEl jugador que llegue lo mas cerca de 21 gana, si se pasa de 21 perdera");

                string[] nombres = new string[n];
                int[] puntaje = new int[n];

                for (int i = 0; i < n; i++)
                {
                    Console.Write("\nJugador " + (i + 1) + " dijite su nombre: ");
                    nombres[i] = Console.ReadLine();
                }

                for (int i = 0; i < n; i++)
                {
                    Random aleatorio = new Random();
                    int carta1 = 0, carta2 = 0, total = 0, contador = 0;
                    Console.WriteLine("\n" + nombres[i] + ", dijite 's' para empezar su turno");
                    string continuar = Console.ReadLine();
                    while (continuar != "s")
                    {
                        Console.WriteLine("Dijite 's' para empezar su turno");
                        continuar = Console.ReadLine();
                    }

                    while (continuar == "s" && total < 21)
                    {
                        
                        if (contador == 0)
                        {
                            carta1 = aleatorio.Next(1, 11);
                            carta2 = aleatorio.Next(1, 11);
                            contador += 2;
                            Console.WriteLine("Carta 1: " + carta1);
                            Console.WriteLine("Carta 2: " + carta2);
                            total += carta1 + carta2;
                            Console.WriteLine("Total: " + total);
                        }
                        else
                        {
                            carta1 = aleatorio.Next(1, 11);
                            contador++;
                            Console.WriteLine("Carta " + (contador) + ": " + carta1);
                            total += carta1;
                            Console.WriteLine("Total: " + total);
                        }
                        if (total >= 21)
                            continuar = "f";
                        else
                        {
                            Console.WriteLine("Dijite 's' para obtenter otra carta o 'f' para retirarse");
                            continuar = Console.ReadLine();
                            while (continuar != "s" && continuar != "f")
                            {
                                Console.WriteLine("Error, digite 's' o 'f'.");
                                continuar = Console.ReadLine();
                            }
                        }
                    }

                    if (total == 21)
                    {
                        Console.WriteLine("\n" + nombres[i] + " obtuvo un total de: " + total);
                        Console.WriteLine("BlackJack");
                    }
                    else if (total > 21)
                    {
                        Console.WriteLine("\nPerdió");
                        total = 0;
                    }
                    else
                        Console.WriteLine("\n" + nombres[i] + " obtuvo un total de: " + total);

                    puntaje[i] = total;
                    if (total > mayor)
                    {
                        ganador = nombres[i];
                        mayor = puntaje[i];
                    }
                    else if (total == mayor)
                        ganador += " y " + nombres[i];
                }

                if (mayor == 0)
                    Console.WriteLine("\nTodos perdieron");
                else
                    Console.WriteLine("\nGano: " + ganador + " con " + mayor + " puntos.");

                Console.WriteLine("\n¿Desea jugar otra vez? (digite 's' para si o 'n' para no)");
                continuarJuego = Console.ReadLine();
                while (continuarJuego != "s" && continuarJuego != "n")
                {
                    Console.WriteLine("Error, digite 's' o 'n'.");
                    continuarJuego = Console.ReadLine();
                }
            }
        }
    }
}
