// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using C_Sharp_Domaci_Ilario;

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
    var croatianTeam = new Teams("Croatian");
    var morrocanTeam = new Teams("Moroccan");
    var canadaianTeam = new Teams("Canadian");
    var belgianTeam = new Teams("Belgian");
    croatianTeam.ListAllPlayers();
    morrocanTeam.ListAllPlayers();
    canadaianTeam.ListAllPlayers();
    belgianTeam.ListAllPlayers();
    var flag = false;
    while (true)
    {
        PrintMenu();
        var input = Console.ReadLine();
        switch (input)
        {
            case "1":
                TrainPlayers(croatianTeam.players);
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

//Priko klase rjesavaj domaci