using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Domaci_Ilario
{
    public class Team
    {
        public string Name { get; set; } = string.Empty;
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Given_Goals { get; set; }
        public int Taken_Goals { get; set; }
        public Dictionary<string, (string position, int rating)> players { get; set; } = new Dictionary<string, (string position, int rating)>();
        public Team()
        {
            Name = string.Empty;
            Wins = 0;
            Losses = 0;
            Given_Goals = 0;
            Taken_Goals = 0;
            players = CreateNewDictionaryOfPlayers();
        }

        public Team(string Nationality)
        {
            Name = Nationality;
            Wins= 0;
            Losses=0;
            Given_Goals= 0;
            Taken_Goals= 0;
            switch(Nationality)
            {
                case "Canadian":
                    players = ReturnPreMadeDictionaryOfCanadianPlayers(); 
                    break;
                case "Belgian":
                    players = ReturnPreMadeDictionaryOfBelgianPlayers();
                    break;
                case "Moroccan":
                    players = ReturnPreMadeDictionaryOfMorrocanPlayers();
                    break;
                case "Croatian":
                    players = ReturnPreMadeDictionaryOfCroatianPlayers();
                    break;
                default:
                    Console.WriteLine("Invalid Nationality Given, empty player list will be returned!\n");
                    break;
            }
        }
        private Dictionary<string, (string position, int rating)> ReturnPreMadeDictionaryOfCroatianPlayers()
        {
            return new Dictionary<string, (string position, int rating)>()
            {
                {"Luka Modrić", ("MF", 88)},
                {"Marcelo Brozović", ("DF", 86)},
                {"Maeto Kovačić", ("MF", 84)},
                {"Ivan Perišić", ("DF", 84)},
                {"Jopko Gvardiol", ("DF", 81)},
                {"Mario Pašačić", ("FW", 81)},
                {"Lovro Majer", ("FW", 80)},
                {"Dominik Livakovič", ("GK", 80)},
                {"Ante Rebić", ("FW", 80)},
                {"Josip Brekalo", ("FW", 79)},
                {"Borna Sosa", ("DF", 78)},
                {"Nikola Vlašić", ("FW", 78)},
                {"Duje Ćaleta-Car", ("DF", 78)},
                {"Dejan Lovren", ("DF", 78)},
                {"Mislav Oršić", ("FW", 77)},
                {"Marko Livaja", ("FW", 77)},
                {"Domagoj Vida", ("DF", 76)},
                {"Ante Budimir", ("FW", 76)},
                {"Kristijan Jakić", ("MF", 76)},
                {"Marko Pjaca", ("MF", 75)}
            };
        }
        private Dictionary<string, (string position, int rating)> ReturnPreMadeDictionaryOfMorrocanPlayers()
        {
            return new Dictionary<string, (string position, int rating)>()
            {
                {"Yassine Bounou", ("GK", 84)},
                {"Achraf Hakimi", ("DF", 84)},
                {"Hakim Ziyech", ("MF", 83)},
                {"Noussair Mazraoui", ("DF", 82)},
                {"Youssef En-Nesyri", ("FW", 80)},
                {"Nayef Aguerd", ("DF", 80)},
                {"Munir", ("DF", 79)},
                {"Sofiane Boufal", ("MF", 77)},
                {"Zouhair Feddal", ("DF", 77)},
                {"Romain Saïss", ("DF", 77)},
                {"Tarik Tissoudali", ("FW", 76)},
                {"Abderazzak Hamdallah", ("FW", 76)},
                {"Sofyan Amrabat", ("MF", 76)},
                {"Yunis Abdelhamid", ("DF", 76)},
                {"Oussama Idrissi", ("FW", 76)},
                {"Jawad El Yamiq", ("DF", 75)},
                {"Soufiane Rahimi", ("DF", 75)},
                {"Amine Harit", ("MF", 75)},
                {"Oussama Tannane", ("MF", 74)},
                {"Imrân Louza", ("MF", 74)},
            };
        }
        private Dictionary<string, (string position, int rating)> ReturnPreMadeDictionaryOfCanadianPlayers()
        {
            return new Dictionary<string, (string position, int rating)>()
            {
                {"Alphonso Davies", ("DF", 84)},
                {"Jonathan David", ("FW", 79)},
                {"Milan Borjan", ("GK", 77)},
                {"Thierry Zoreaux", ("GK", 76)},
                {"Stephen Eustáquio", ("DF", 76)},
                {"Cyle Larin", ("FW", 74)},
                {"Jonathan Osorio", ("MF", 74)},
                {"Maxime Crépeau", ("GK", 74)},
                {"Tajon Buchanan", ("DF", 72)},
                {"Atiba Hutchinson", ("DF", 72)},
                {"Iké Ugbo", ("FW", 72)},
                {"Richie Laryea", ("DF", 72)},
                {"Dayne St. Clair", ("GK", 71)},
                {"Mark-Anthony Kaye", ("MF", 71)},
                {"Scott Arfield", ("MF", 71)},
                {"Kamal Miller", ("MF", 71)},
                {"Lucas Cavallini", ("FW", 71)},
                {"Sam Adekugbe", ("DF", 70)},
                {"Alistair Johnston", ("DF", 70)},
                {"Junior Hoilett", ("FW", 70)},
                {"Samuel Piette", ("DF", 70)},
                {"Scott Kennedy", ("DF", 69)},
            };
        }
        private Dictionary<string, (string position, int rating)> ReturnPreMadeDictionaryOfBelgianPlayers()
        {
            return new Dictionary<string, (string position, int rating)>()
            {
                {"Kevin De Bruyne", ("MF", 91)},
                {"Thibaut Courtois", ("GK", 90)},
                {"Romelu Lukaku", ("FW", 86)},
                {"Yannick Carrasco", ("DF", 85)},
                {"Dries Mertens", ("MF", 84)},
                {"Koen Casteels", ("GK", 84)},
                {"Eden Hazard", ("FW", 84)},
                {"Youri Tielemans", ("MF", 84)},
                {"Toby Alderweireld", ("DF", 82)},
                {"Jan Vertonghen", ("DF", 81)},
                {"Hans Vanaken", ("MF", 80)},
                {"Thorgan Hazard", ("DF", 80)},
                {"Simon Mignolet", ("GK", 80)},
                {"Axel Witsel", ("DF", 79)},
                {"Matz Sels", ("GK", 79)},
                {"Adnan Januzaj", ("FW", 79)},
                {"Leandro Trossard", ("DF", 79)},
                {"Charles De Ketelaere", ("FW", 78)},
                {"Alexis Saelemaekers", ("DF", 78)},
                {"Mats Rits", ("DF", 78)},
                {"Timothy Castagne", ("DF", 78)},
                {"Thomas Meunier", ("DF", 78)},
            };
        }
        private Dictionary<string, (string position, int rating)> CreateNewDictionaryOfPlayers()
        {
            Console.WriteLine("-----------------------------------Sada cemo uniti igrace!-----------------------------------\n");
            var players = new Dictionary<string, (string position, int rating)>();
            var tempName = "";
            var tempPosition = "";
            var tempRating = "";
            var rating = 0;
            for (int i = 0; i < 22; i++)
            {
                Console.WriteLine($"\n\n\n Unesi: \n\n\n Puno ime igraca {i + 1}: \n");
                tempName = Console.ReadLine() ?? "Error: Player name could not be assigned!";
                if (players.ContainsKey(tempName))
                {
                    while (true)
                    {
                        Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" +
                            "\n Unia si igraca koji postoji vec! Unesi opet! \n" +
                            "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n");
                        tempName = Console.ReadLine() ?? "Error: Player name could not be assigned!";
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
                Console.WriteLine($"\n Unesi Poziciju Igraca {i + 1}, koristi sljedece kratic(GK - golman, DF - obrana, MF - sredina, FW - napadac): \n");
                tempPosition = Console.ReadLine();
                if (tempPosition is not "GK" && tempPosition is not "DF" && tempPosition is not "MF" && tempPosition is not "FW")
                {
                    while (true)
                    {
                        Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" +
                            "\n Krivi format! Unesi opet(GK - golman, DF - obrana, MF - sredina, FW - napadac): \n" +
                            "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n ");
                        tempPosition = Console.ReadLine();
                        if (tempPosition is not "GK" && tempPosition is not "DF" && tempPosition is not "MF" && tempPosition is not "FW")
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
                if (int.TryParse(tempRating, out rating))
                {
                    if (rating >= 0 && rating <= 100)
                    {
                        players.Add(tempName, (tempPosition, rating));
                    }
                    else
                    {
                        while (true)
                        {
                            Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" +
                                "\n Ili nisi upisa broj ili si upisa preko dozvoljene granice!(0 - 100) \n" +
                                "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n ");
                            tempRating = Console.ReadLine();
                            if (int.TryParse(tempRating, out rating))
                            {
                                if (rating >= 0 && rating <= 100)
                                {
                                    players.Add(tempName, (tempPosition, rating));
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }
                else
                {
                    while (true)
                    {
                        Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" +
                            "\n Ili nisi upisa broj ili si upisa preko dozvoljene granice!(0 - 100) \n" +
                            "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n ");
                        tempRating = Console.ReadLine();
                        if (int.TryParse(tempRating, out rating))
                        {
                            if (rating >= 0 && rating <= 100)
                            {
                                players.Add(tempName, (tempPosition, rating));
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }
            return players;
        }
        public void ListAllPlayers()
        {
            foreach (var pair in this.players)
            {
                Console.WriteLine($"Name: {pair.Key} --- Position: {pair.Value.position} --- Rating: {pair.Value.rating}\n");
            }
        }
    }
}
