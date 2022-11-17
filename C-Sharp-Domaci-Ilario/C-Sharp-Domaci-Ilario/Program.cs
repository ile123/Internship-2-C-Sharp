// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

Dictionary<string, (string position, int rating)> ReturnPreMadeDictionaryOfCroatianPlayers()
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

Dictionary<string, (string position, int rating)> ReturnPreMadeDictionaryOfMorrocanPlayers()
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

Dictionary<string, (string position, int rating)> ReturnPreMadeDictionaryOfCanadianPlayers()
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

Dictionary<string, (string position, int rating)> ReturnPreMadeDictionaryOfBelgianPlayers()
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

Dictionary<string, (string position, int rating)> CreateNewDictionaryOfPlayers()
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

double GetRandomDouble()
{
    var random = new Random();
    var rDouble = random.NextDouble();
    var rRangeDouble = rDouble * 0.05;
    return rRangeDouble;
}

bool GetRandomBoolean()
{
    var random = new Random();
    return random.Next() > (Int32.MaxValue / 2);
}

int GetRandomRatingIncrease(int rating)
{
    var randomDouble = GetRandomDouble();
    rating += (int)(rating * randomDouble);
    return rating;
}

int GetRandomRatingDecrease(int rating)
{
    var randomDouble = GetRandomDouble();
    rating -= (int)(rating * randomDouble);
    return rating;
}

void TrainPlayers(Dictionary<string, (string position, int rating)> players)
{
    var previousPlayerScores = new List<(string Name, int Rating)>();
    var tempPlayers = new Dictionary<string, (string position, int rating)>();
    var tempRating = 0;
    var tempPosition = "";
    foreach (var player in players)
    {
        previousPlayerScores.Add((player.Key, player.Value.rating));
        tempPosition = player.Value.position;
        if (GetRandomBoolean())
        {
            tempRating = GetRandomRatingIncrease(player.Value.rating);
        }
        else
        {
            tempRating = GetRandomRatingDecrease(player.Value.rating);
        }
        //tempPlayers.Add(player.Key, (player.Value.position, tempRating));
        players[player.Key] = (tempPosition, tempRating);
    }
    //players = tempPlayers;
    Console.WriteLine("\n Prije Treninga: \n");
    foreach (var item in previousPlayerScores)
    {
        Console.WriteLine($"Ime: {item.Name} --- Rating: {item.Rating}");
    }
    Console.WriteLine("\n Nakon Treninga: \n");
    foreach (var item in players)
    {
        Console.WriteLine($"Ime: {item.Key} --- Rating: {item.Value.rating}");
    }
}

void PrintMenu()
{
    Console.WriteLine("\n \n 1 - Odaberi Trening \n 2 - Odigraj Utakmicu \n 3 - Statistika \n 4 - Kontrola Igraca \n 0 - Izlazi iz aplikacije \n \n");
}

void ListAllPlayers(Dictionary<string, (string position, int rating)> dictionary)
{
    foreach (var pair in dictionary)
    {
        Console.WriteLine($"Key: {pair.Key} --- Value: {pair.Value}\n");
    }
}

void ListAllPlayersByRatingAsceding(Dictionary<string, (string position, int rating)> dictionary)
{
    var sortedDictionaryByRatingAscended = (
        from pair in dictionary
        orderby pair.Value.rating ascending
        select pair
        ).ToList();
    foreach (var item in sortedDictionaryByRatingAscended)
    {
        Console.WriteLine($"Ime: {item.Key} --- Pozicija: {item.Value.position} --- Rating: {item.Value.rating}");
    }
}

void ListAllPlayersByRatingDescending(Dictionary<string, (string position, int rating)> dictionary)
{
    var sortedDictionaryByRatingDescended = (
        from pair in dictionary
        orderby pair.Value.rating descending
        select pair
        ).ToList();
    foreach (var item in sortedDictionaryByRatingDescended)
    {
        Console.WriteLine($"Ime: {item.Key} --- Pozicija: {item.Value.position} --- Rating: {item.Value.rating}");
    }
}

void AddPlayerToDictionary(Dictionary<string, (string position, int rating)> dictionary)
{
    Console.WriteLine("-----------------------------------Sada cemo uniti igraca!-----------------------------------\n");
    var tempName = "";
    var tempPosition = "";
    var tempRating = "";
    var rating = 0;
    Console.WriteLine($"\n\n\n Unesi: \n\n\n Puno ime igraca: \n");
    tempName = Console.ReadLine() ?? "Error: Player name could not be assigned!";
    if (dictionary.ContainsKey(tempName))
    {
        while (true)
        {
            Console.WriteLine("\n!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!" +
                "\n Unia si igraca koji postoji vec! Unesi opet! \n" +
                "!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n");
            tempName = Console.ReadLine() ?? "Error: Player name could not be assigned!";
            if (dictionary.ContainsKey(tempName))
            {
                continue;
            }
            else
            {
                break;
            }
        }
    }
    Console.WriteLine($"\n Unesi Poziciju Igraca, koristi sljedece kratic(GK - golman, DF - obrana, MF - sredina, FW - napadac): \n");
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
    Console.WriteLine($"\n Unesi Rating Igraca, triba Biti izmedu 0 - 100: \n");
    tempRating = Console.ReadLine();
    if (int.TryParse(tempRating, out rating))
    {
        if (rating >= 0 && rating <= 100)
        {
            dictionary.Add(tempName, (tempPosition, rating));
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
                        dictionary.Add(tempName, (tempPosition, rating));
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
                    dictionary.Add(tempName, (tempPosition, rating));
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



void Start()
{
    //var players = createNewDictionaryOfPlayers();
    var players = ReturnPreMadeDictionaryOfCroatianPlayers();
    var flag = false;
    while (true)
    {
        PrintMenu();
        var input = Console.ReadLine();
        switch (input)
        {
            case "1":
                TrainPlayers(players);
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
        if (flag is true)
        {
            Console.WriteLine("\n Gasenje Aplikacije! \n");
            break;
        }
    }
}

Start();

/*
var dictionary = new Dictionary<string, (string position, int rating)>()
{
    {"Alphonso Davies", ("DF", 84)},
};

Console.WriteLine(dictionary["Alphonso Davies"]);

dictionary.Remove("Alphonso Davies");

dictionary["Alphonso Davies"] = ("GK", 22);

Console.WriteLine(dictionary["Alphonso Davies"]);
*/