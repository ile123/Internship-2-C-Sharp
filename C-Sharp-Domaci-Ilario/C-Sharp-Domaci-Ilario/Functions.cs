using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Domaci_Ilario
{
    public static class Functions
    {
        public static Dictionary<string, (string position, int rating)> createNewDictionaryOfPlayers()
        {
            var players = new Dictionary<string, (string position, int rating)>();
            var tempName = "";
            var tempPosition = "";
            var tempRating = "";
            var rating = 0;
            for (int i = 0;i < 20; i++)
            {
                Console.WriteLine($"\n\n\n Unesi: \n\n\n Puno ime igraca {i+1}: \n");
                tempName = Console.ReadLine();
                if (players.ContainsKey(tempName))
                {
                    while (true)
                    {
                        Console.WriteLine("\n Unia si igraca koji postoji vec! Unesi opet! \n ");
                        tempName = Console.ReadLine();
                        if (players.ContainsKey(tempName))
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine($"\n Unesi Poziciju Igraca {i+1}, koristi N# format: \n");
                tempPosition = Console.ReadLine();
                if (!tempPosition.Contains("#"))
                {
                    while (true)
                    {
                        Console.WriteLine("\n Krivi format! Unesi opet(N#): \n ");
                        tempPosition = Console.ReadLine();
                        if (!tempPosition.Contains("#"))
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                Console.WriteLine($"\n Unesi Rating Igraca {i + 1}, triba Biti izmedu 0 - 100: \n");
                tempRating = Console.ReadLine();
                //promijeni kasnije tako da provjeri jeli rating unutar dozvoljene granice
                if (!int.TryParse(tempRating, out rating))
                {
                    while (true)
                    {
                        Console.WriteLine("\n Ili nisi upisa broj ili si upisa preko dozvoljene granice!(0 - 100) \n ");
                        tempRating = Console.ReadLine();
                        if (!int.TryParse(tempRating, out rating) && (rating < 0 || rating > 100))
                        {
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                players.Add(tempName, (tempPosition, rating));
            }
            return players;
        }


        public static void PrintMenu()
        {
            Console.WriteLine(" 1 - Odaberi Trening \n 2 - Odigraj Utakmicu \n 3 - Statistika \n 4 - Kontrola Igraca \n 0 - Izlazi iz aplikacije \n");
        }

        public static void TrainPlayers()
        {

        }

        public static void Start()
        {
            Console.WriteLine("-----------------------------------Sada cemo uniti igrace!-----------------------------------\n");
            var players = createNewDictionaryOfPlayers();
            var flag = false;
            while (true)
            {
                PrintMenu();
                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("1");
                        break;
                    case "2":
                        Console.WriteLine("2");
                        break;
                    case "3":
                        Console.WriteLine("3");
                        break;
                    case "4":
                        Console.WriteLine("4");
                        break;
                    case "0":
                        flag = true;
                        break;
                    default:
                        Console.WriteLine("Unia si nedozvoljenu vrijednost!\n");
                        break;
                }
                if(flag is true)
                {
                    Console.WriteLine("\n Gasenje Aplikacije! \n");
                    break;
                }
            }
        }
    }
}
