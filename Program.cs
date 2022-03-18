using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Ahorcado
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 30);

            //Logo();

            //Animacion();

            Console.Clear();
            Console.WriteLine("╔═ Jugador 1 ══════════════╗");
            string jugador1, jugador2;
            Console.Write(" Nombre: ");
            jugador1 = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("╔═ Jugador 2 ══════════╗");
            Console.Write(" Nombre: ");
            jugador2 = Console.ReadLine();
            int jugador1Puntos = 0, jugador2Puntos = 0;
            Console.Clear();
            int longitud = 3;
            musica();

            do
            {

                jugador1Puntos += Juego(jugador1, jugador2, jugador1Puntos, jugador2Puntos, longitud);
                Console.Clear();
                jugador2Puntos += Juego(jugador2, jugador1, jugador2Puntos, jugador1Puntos, longitud);
                Console.Clear();

                if (longitud < 11)
                {
                    longitud++;
                }

            } while (longitud < 11);

            Console.SetCursorPosition(10, 0);
            Console.WriteLine("..######......###....##....##....###....########...#######..########.");
            Console.SetCursorPosition(10, 1);
            Console.WriteLine(".##....##....##.##...###...##...##.##...##.....##.##.....##.##.....##");
            Console.SetCursorPosition(10, 2);
            Console.WriteLine(".##.........##...##..####..##..##...##..##.....##.##.....##.##.....##");
            Console.SetCursorPosition(10, 3);
            Console.WriteLine(".##...####.##.....##.##.##.##.##.....##.##.....##.##.....##.########.");
            Console.SetCursorPosition(10, 4);
            Console.WriteLine(".##....##..#########.##..####.#########.##.....##.##.....##.##...##..");
            Console.SetCursorPosition(10, 5);
            Console.WriteLine(".##....##..##.....##.##...###.##.....##.##.....##.##.....##.##....##.");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("..######...##.....##.##....##.##.....##.########...#######..##.....##");
            Console.WriteLine();
            Console.SetCursorPosition(15, 8);
            Console.WriteLine("                            \\|||/");
            Console.SetCursorPosition(15, 9);
            Console.WriteLine("                            (o o)");
            Console.SetCursorPosition(15, 10);
            Console.WriteLine("                 ------ooO - (_) - Ooo------");
            Console.SetCursorPosition(15, 11);
            if(jugador1Puntos > jugador2Puntos)
            { 
                Console.WriteLine($"                            {jugador1}");
                Console.SetCursorPosition(15, 12);
                Console.WriteLine($"                         con {jugador1Puntos} pts");
            }
            else
            {
                Console.WriteLine($"                            {jugador2}");
                Console.SetCursorPosition(15, 12);
                Console.WriteLine($"                         con {jugador2Puntos} pts");
            }
                

            Console.ReadLine();

            














        }

        public static void Animacion()
        {
           Console.SetCursorPosition(10, 5);
            Console.WriteLine("##  ##   ##  ##  ##   ##   ## ##   ##   ##   ##  ##   ##  ##  ##   ##"); //5
            Thread.Sleep(500);
            Console.SetCursorPosition(10, 1);
            Console.WriteLine(" ####    ##  ##  ##   ##   ##  ##  ##   ##    ####    ##  ##  ##   ##"); //1
            Thread.Sleep(500);
            Console.SetCursorPosition(10, 3);
            Console.WriteLine("######   ######  ##   ##   #####   ##        ######   ##  ##  ##   ##"); //3
           Thread.Sleep(500);
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("##  ##   ##  ##   #####    ##  ##   #####    ##  ##  ######    #####   V 1.01"); //6
            Thread.Sleep(500);
            Console.SetCursorPosition(10, 4);
            Console.WriteLine("##  ##   ##  ##  ##   ##   ####    ##        ##  ##   ##  ##  ##   ##"); //4
            Thread.Sleep(500);
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("##  ##   ##  ##  ##   ##   ##  ##  ##        ##  ##   ##  ##  ##   ##"); //2
            Thread.Sleep(500);
            Console.SetCursorPosition(10, 0);
            Console.WriteLine("  ##     ##  ##   #####   ######    #####      ##    ######    #####"); //0
            Thread.Sleep(500);
            
            
            do
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(25, 8);
                Console.WriteLine("Presione una tecla para continuar");
                Thread.Sleep(500);
                Console.SetCursorPosition(25, 8);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Presione una tecla para continuar");
                Thread.Sleep(500);


            } while (!Console.KeyAvailable);
            Console.ReadKey();
            return;

        }

        static int Juego(string jugador, string retador, int puntos, int puntos2, int longitud)
        {
            Console.WriteLine($"Le toca adivinar a: \n");
            Console.WriteLine("        (0 0)");
            Console.WriteLine(".---oOO--(_)------.");
            Console.WriteLine("╔═════════════════╗");
            Console.WriteLine($"   {jugador}      ");
            Console.WriteLine("╚═════════════════╝");
            Console.WriteLine("'--------------oOO.");
            Console.WriteLine("     | __ | __ |");
            Console.WriteLine("       ||   ||");
            Console.WriteLine("      ooO   Ooo");
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\n{jugador} ¡ Pss, NO MIRES ! (>_<) ");

            string palabra = null;
            do
            {
                Console.SetCursorPosition(0, 12);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(0, 11);
                Console.Write($"\n{retador} Escribe una palabra de {longitud} letras: ");
                Console.ForegroundColor = ConsoleColor.White;
                palabra = Console.ReadLine();
            } while (palabra.Length != longitud || palabra == null);

            

            int abc = 0;
            int letrasDichas = 0;

            char[] letras = new char[palabra.Length];
            char[] letrasOcultas = new char[palabra.Length];
            char[] elegidas = new char[27];

            for (int x = 0; x < letras.Length; x++)
            {
                letras[x] = palabra[x];
                letrasOcultas[x] = '_';

            }

            int vidas = 4;
            bool descubierta = true;

            do
            {

                Console.Clear();
                Console.Write($"\n  {jugador}: {puntos} pts // {retador}: {puntos2} pts ");
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Write("\n\n\nLetras Elegidas: ");
                for (int x = 0; x < elegidas.Length && elegidas[x] != '\0'; x++)
                {

                    Console.Write($"{elegidas[x]} ");
                    

                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.SetCursorPosition(0, 5);
                Ahorcado(vidas);

                Console.SetCursorPosition(20, 7);
                Console.Write("Palabra: ");

                Mostrar(letrasOcultas);
                Creditos();

                
                int seg = 5;
                int cronometro;
                ConsoleKey eleccion = ConsoleKey.D1;
                
                do {
                    
                    Console.SetCursorPosition(20, 9);
                    Console.Write(new string(' ', Console.WindowWidth));
                    Console.SetCursorPosition(20, 9);
                    Console.Write("Letra: ");

                    bool truco;
                    
                    do
                    {
                        truco = false;
                        cronometro = Tiempo(seg);
                        if (cronometro <= 0)
                        {
                            vidas--;
                            break;
                        }
                        else
                        {

                            Console.SetCursorPosition(27, 9);
                            eleccion = Console.ReadKey().Key;
                                if (eleccion == ConsoleKey.Escape)
                                {
                                    seg = cronometro;
                                    Truco();
                                    truco = true;
                                    Console.SetCursorPosition(20, 9);
                                    Console.Write(new string(' ', Console.WindowWidth));
                                    Console.SetCursorPosition(20, 9);
                                    Console.Write("Letra: ");
                                }
                            seg = cronometro;
                            Thread.Sleep(100);
                        }
                    } while (truco == true);
                } while (cronometro != 0 && (eleccion < ConsoleKey.A || eleccion > ConsoleKey.Z || eleccion == ConsoleKey.Enter || eleccion == ConsoleKey.Escape));

                descubierta = false;

                if (cronometro != 0)
                { 
                    bool repetida = false;
                    for (int x = 0; x < elegidas.Length && repetida == false; x++)
                    {
                        if (Convert.ToChar(eleccion) == char.ToUpper(elegidas[x]))
                        {
                            Console.SetCursorPosition(20,11);
                            Console.WriteLine("¡Letra ya elegida!");
                            repetida = true;
                            Thread.Sleep(2000);
                        }
                    }

                    if (repetida == false)
                    {
                        letrasDichas++;
                        bool encontrada = false;
                        elegidas[abc] = Convert.ToChar(eleccion);
                        abc++;

                        for (int x = 0; x < letras.Length; x++)
                        {
                            if (Convert.ToChar(eleccion) == char.ToUpper(letras[x]))
                            {
                                letrasOcultas[x] = letras[x];
                                encontrada = true;
                            }
                        }

                        if (encontrada == false)
                        {
                            vidas--;
                        }
                    }


                    descubierta = true;

                    for (int x = 0; x < letrasOcultas.Length && descubierta; x++)
                    {
                        if (letrasOcultas[x] == '_')
                            descubierta = false;
                    }
                }

            } while (descubierta == false && vidas > 0);

            

            if (vidas == 0)
            {
                Console.SetCursorPosition(20, 7);
                Console.Write("Palabra: ");
                Mostrar(letras);
                Console.SetCursorPosition(0, 5);
                Ahorcado(vidas);
                Console.SetCursorPosition(20, 11);
                Console.WriteLine("(X_x) Mejor suerte la proxima !!");
                Console.SetCursorPosition(20, 12);
                Console.WriteLine($"{jugador} hiciste -15 pts");
                Console.ReadKey();
                return -15;
            }
            else
            {
                int puntaje = (100 - (10 * (letrasDichas - palabra.Length))) + (vidas * 5);
                Console.SetCursorPosition(20, 7);
                Console.Write("Palabra: ");
                Mostrar(letras);
                Console.SetCursorPosition(20, 11);
                Console.WriteLine("(^_^) ADIVINASTE !!");
                Console.SetCursorPosition(20, 12);
                Console.WriteLine($"{jugador} hiciste {puntaje} pts");
                Console.ReadKey();
                return puntaje;
            }
            
        }

        public static void Ahorcado(int vidas)
        {
            Console.WriteLine(" _______");
            Console.WriteLine(" |/    |");
            Console.Write(" |");
            if (vidas < 4)
                Console.Write("    (_)\n");
            else
                Console.WriteLine("");
                Console.Write(" |");
            if (vidas < 3)
                Console.Write("    \\|/\n");
            else
                Console.WriteLine("");
            Console.Write(" |");
            if (vidas < 2)
                Console.Write("     | \n");
            else
                Console.WriteLine("");

                Console.Write(" |");
            if (vidas < 1)
                Console.Write("    / \\\n");
            else
                Console.WriteLine("");
            Console.WriteLine(" |");
            Console.WriteLine("_|____");


        }

        public static void Mostrar(char[] arreglo)
        {
            for (int x = 0; x < arreglo.Length; x++)
            {
                Console.Write($"{arreglo[x]} ");
            }
        }

        public static void musica()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\Codigos Fuentes\\Repositorio\\Ahorcado\\Properties\\musica.wav"); player.PlayLooping();

        }

        public static void Creditos()
        {
            Console.SetCursorPosition(7, 14);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Realizado por LF Soluciones Informaticas - año 2022");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Logo()
        {
            Console.WriteLine("                              |@@@@@|");                           
            Console.WriteLine("                              |@@@@@|");
            Console.WriteLine("                              |@@@@@|                           ");
            Console.WriteLine("                              |@@@@@|                           ");
            Console.WriteLine("                           @@@@@@@@@@@@@                      ");
            Console.WriteLine("                         @@@@@@@@@@@@@@@@@                        ");
            Console.WriteLine("                        @@@@@@@@@@@@@@@@@@@                   ");
            Console.WriteLine("                      @@@@@@@@@@@@@@@@@@@@@@@                  ");
            Console.WriteLine("                    |@@@   @@@@@@@         @@@|");
            Console.WriteLine("                    |@@@   @@@@@@@   @@@@@@@@@|  ");
            Console.WriteLine("                    |@@@   @@@@@@@         @@@|                 ");
            Console.WriteLine("                    |@@@   @@@@@@@   @@@@@@@@@|                 ");
            Console.WriteLine("                    |@@@        @@   @@@@@@@@@|                 ");
            Console.WriteLine("                    |@@@@@@@@@@@@@@@@@@@@@@@@@|                 ");
            Console.WriteLine("                    |@Soluciones Informaticas@|                 ");
            Console.WriteLine("                    |@@@@@@@@@@@@@@@@@@@@@@@@@|                 ");
            Console.WriteLine("                        |@@@@@@@@@@@@@@@@@|                    ");
            Console.WriteLine("                        |@@@   @@@@@@   @@|                    ");
            Console.WriteLine("                        |@@@   @@@@@@   @@|                    ");
            Console.WriteLine("                        |@@@@@@@@@@@@@@@@@|   ");

            Console.WriteLine("");
            Console.WriteLine("                               PRESENTA  ");
            Thread.Sleep(5000);
            Console.Clear();
        }

        public static int Tiempo(int seg)
        {
            int time = seg;
            do
                {
                Console.SetCursorPosition(20, 5);
                Console.WriteLine($"{time} segundos");
                Console.SetCursorPosition(27, 9);
                Thread.Sleep(1000);
                time--;
            } while (!Console.KeyAvailable && time > 0);
            return time;

        }

        public static void Truco()
        {
                ConsoleKey letra = Console.ReadKey().Key;
                if (letra == ConsoleKey.D1)
                {
                    ConsoleKey eleccion = Console.ReadKey().Key;
                    if (eleccion == ConsoleKey.D2)
                    {
                        eleccion = Console.ReadKey().Key;
                        if (eleccion == ConsoleKey.D3)
                        {
                        Console.SetCursorPosition(20, 16);
                        Console.WriteLine("▌▌▌░▄████████▄░▐▐▐");
                        Console.SetCursorPosition(20, 17);
                        Console.WriteLine("██▄ ███º██º███▄██");
                        Console.SetCursorPosition(20, 18);
                        Console.WriteLine("▐░░██▀▀████▀▀██░░▌");
                        Console.SetCursorPosition(20, 19);
                        Console.WriteLine("▐░░▐█░░░░░▄▄░█▌░░▌");
                        Console.SetCursorPosition(20, 20);
                        Console.WriteLine("▐▄▄▄▀████████▀▄▄▄▌");
                        Console.SetCursorPosition(12, 22);
                        Console.WriteLine("Guardas la harina en la heladera??");

                        Thread.Sleep(3000);
                        Console.SetCursorPosition(20, 16);
                        Console.Write(new string(' ', Console.WindowWidth));
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        Console.WriteLine(new string(' ', Console.WindowWidth));
                        return;
                        }
                    }
                return;

                }
            return;

        } 


    }
}       
    

