// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using C_Sharp_Domaci_Ilario;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;

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

void PrintMenuStatistics()
{
    Console.WriteLine("\n \n ***************************************************************************************************" +
        "\n \n 1 - Ispis Svih Igraca \n 2 - Ispis Po Ratingu Uzlazno \n 3 - Ispis Po Ratingu Izlazno \n 4 - Ispis Igrača Po Imenu I Prezimenu (Ispis Pozicije i Ratinga) \n " +
        "5 - Ispis Igrača Po Ratingu \n 6 -  Ispis Igrača Po Poziciji \n 7 - Ispis trenutnih prvih 11 igrača \n 8 -  Ispis Strijelaca i Koliko Golova Imaju \n " +
        "9 - Ispis Svih Rezultata Ekipe \n 10 - Ispis Rezultat Svih Ekipa \n 11 -  Ispis Tablice Grupe (Mjesto Na Tablici, Ime Ekipe, Broj Bodova, Gol Razlika) " +
        "\n 0 - Izlaz Iz Statiskie \n *************************************************************************************************** \n \n");
}

void PrintMenuPlayerControl()
{
    Console.WriteLine("\n \n *************************************************************************************************** " +
        "\n \n 1 - Unos Novog Igraca \n 2 - Brisanje Igraca \n 3 - Uredivanje Igraca \n " +
        "0 - Izlaz Iz Kontrola Igraca \n *************************************************************************************************** \n \n");
}

void PrintAllPlayers(Dictionary<string, (string position, int rating)> players)
{
    foreach (var item in players)
    {
        Console.WriteLine($"\n Ime: {item.Key} --- Pozicija: {item.Value.position} --- Rating: {item.Value.rating}");
    }
}

void PrintAllPlayersByRatingAsceding(Dictionary<string, (string position, int rating)> players)
{
    var sortedDictionaryByRatingAscended = (
        from player in players
        orderby player.Value.rating ascending
        select player
        ).ToList();
    foreach (var item in sortedDictionaryByRatingAscended)
    {
        Console.WriteLine($"Ime: {item.Key} --- Pozicija: {item.Value.position} --- Rating: {item.Value.rating}");
    }
}

void PrintAllPlayersByName(Dictionary<string, (string position, int rating)> players)
{
    var sortedDictionaryByName = (
        from player in players
        orderby player.Key
        select player
        ).ToList();
    foreach (var item in sortedDictionaryByName)
    {
        Console.WriteLine($"Ime: {item.Key} --- Pozicija: {item.Value.position} --- Rating: {item.Value.rating}");
    }
}

void PrintAllPlayersByRating(Dictionary<string, (string position, int rating)> players)
{
    var sortedDictionaryByRating = (
        from player in players
        orderby player.Value.rating 
        select player
        ).ToList();
    foreach (var item in sortedDictionaryByRating)
    {
        Console.WriteLine($"Ime: {item.Key} --- Pozicija: {item.Value.position} --- Rating: {item.Value.rating}");
    }
}

void PrintAllPlayersByRatingDescending(Dictionary<string, (string position, int rating)> players)
{
    var sortedDictionaryByRatingDescended = (
        from player in players
        orderby player.Value.rating descending
        select player
        ).ToList();
    foreach (var item in sortedDictionaryByRatingDescended)
    {
        Console.WriteLine($"Ime: {item.Key} --- Pozicija: {item.Value.position} --- Rating: {item.Value.rating}");
    }
}

void PrintAllPlayersByPosition(Dictionary<string, (string position, int rating)> players, string Position)
{
    var sortedDictionaryByPosition = (
        from player in players
        where player.Value.position == Position
        select player
        ).ToList();
    foreach (var item in sortedDictionaryByPosition)
    {
        Console.WriteLine($"Ime: {item.Key} --- Pozicija: {item.Value.position} --- Rating: {item.Value.rating}");
    }
}

void PrintFirstElevenPlayers(Dictionary<string, (string position, int rating)> players)
{
    var sortedDictionaryByRating = (
        from player in players
        orderby player.Value.rating descending
        select player
        ).ToList();
    for(int i = 0; i < 11; i++)
    {
        Console.WriteLine($"Ime: {sortedDictionaryByRating[i].Key} --- Pozicija: {sortedDictionaryByRating[i].Value.position} --- Rating: {sortedDictionaryByRating[i].Value.rating}");
    }
}

void PrintAllShooters(Dictionary<string, (string Club, int Goals)> shooters)
{
    foreach(var item in shooters)
    {
        Console.WriteLine($"Ime: {item.Key} --- Broj Golova: {item.Value.Goals}");
    }
}

void PrintGroupTable(List<Team> teams)
{
    var tempTable = new List<(string Team, int score, double goalDifference)>();
    foreach(var team in teams)
    {
        var score = team.Given_Goals + team.Wins * 3;
        var goalDifference = (double) team.Given_Goals / team.Taken_Goals;
        tempTable.Add((team.Name, score, goalDifference));
    }
    Console.WriteLine("\n \n Pozicija \t\t Ekipa \t\t Bodovi \t\t Goal Razlika\n\n\n");
    var teamsTable = (
        from team in tempTable
        orderby team.score descending
        select team
        ).ToList();
    for(var i = 0; i< teamsTable.Count; i++)
    {
        Console.WriteLine($"    {i + 1}# \t\t     {teamsTable[i].Team} \t\t    {teamsTable[i].score} \t\t\t    {teamsTable[i].goalDifference} \n \n");
    }
}

void AddPlayerToTeam(Dictionary<string, (string position, int rating)> players)
{
    if(players.Count == 26)
    {
        Console.WriteLine("Previse Igraca u Ekipi!\n");
        return;
    }
    Console.WriteLine("-----------------------------------Sada cemo uniti igraca!-----------------------------------\n");
    var tempName = "";
    var tempPosition = "";
    var tempRating = "";
    var rating = 0;
    Console.WriteLine("-----------------------------------Unesi ime Igraca!-----------------------------------\n");
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
    Console.WriteLine("-----------------------------------Unesi ime Poziciju!-----------------------------------\n");
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
    Console.WriteLine("-----------------------------------Unesi ime Rating!-----------------------------------\n");
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

void DeletePlayerFromTeam(Dictionary<string, (string position, int rating)> players, string Player)
{
    if (!players.ContainsKey(Player))
    {
        Console.WriteLine("\n IGRAC NE POSTOJI!\n");
        return;
    }
    players.Remove(Player);
}

void UpdatePlayerInTeam(Dictionary<string, (string position, int rating)> players)
{
    Console.WriteLine("-----------------------------------Sada cemo uniti igraca!-----------------------------------\n");
    var tempName = "";
    var tempPosition = "";
    var tempRating = "";
    var oldName = "";
    var rating = 0;
    Console.WriteLine("-----------------------------------Unesi ime Igraca!-----------------------------------\n");
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
    Console.WriteLine("-----------------------------------Unesi ime Poziciju!-----------------------------------\n");
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
    Console.WriteLine("-----------------------------------Unesi ime Rating!-----------------------------------\n");
    tempRating = Console.ReadLine();
    if (int.TryParse(tempRating, out rating))
    {
        if (rating >= 0 && rating <= 100)
        {
            Console.WriteLine("\n ----------------------------------------------- Unesi Ime Igraca Kojeg Zelis Prominit! ----------------------------------------\n");
            oldName = Console.ReadLine() ?? "ERORR: Could not assign string";
            if (players.ContainsKey(oldName))
            {
                DeletePlayerFromTeam(players, oldName);
                players.Add(tempName, (tempPosition, rating));
            }
            else
            {
                Console.WriteLine("\n Igrac Nepostoji!\n");
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
                        Console.WriteLine("\n --------------------------------------------------------------- Unesi Ime Igraca ! -------------------------------------------------\n");
                        oldName = Console.ReadLine() ?? "ERORR: Could not assign string";
                        if (players.ContainsKey(oldName))
                        {
                            DeletePlayerFromTeam(players, oldName);
                            players.Add(tempName, (tempPosition, rating));
                        }
                        else
                        {
                            Console.WriteLine("\n Igrac Nepostoji!\n");
                        }
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
            if (rating >= 0 && rating <= 100)
            {
                Console.WriteLine("\n ------------------------------------------------ Unesi Ime Igraca Kojeg Zelis Prominit! -----------------------------------\n");
                oldName = Console.ReadLine() ?? "ERORR: Could not assign string";
                if (players.ContainsKey(oldName))
                {
                    DeletePlayerFromTeam(players, oldName);
                    players.Add(tempName, (tempPosition, rating));
                }
                else
                {
                    Console.WriteLine("\n Igrac Nepostoji!\n");
                }
                break;
            }
            else
            {
                continue;
            }
        }
    }
}

List<(string Name, string Position)> ReturnSortedListOfCertainPosition(Dictionary<string, (string position, int rating)> players, string Position)
{
    var sortedDictionary = (
            from player in players
            where player.Value.position == Position
            orderby player.Value.rating descending
            select player
        ).ToList();
    var sortedList = new List<(string Name, string Position)>();
    foreach(var item in sortedDictionary)
    {
        sortedList.Add((item.Key, item.Value.position));
    }
    return sortedList;
}

void PlayMatch(Team firstTeam, Team secondTeam, List<(string Winner, string Looser)> matchRecords, Dictionary<string, (string Club, int Goals)> strikers)
{
    var random = new Random();
    var playerFirstTeam = new List<(string Name, string Position)>();
    var playerSecondTeam = new List<(string Name, string Position)>();
    var tempPlayerStorage = new List<(string Name, string Position)>();
    tempPlayerStorage = ReturnSortedListOfCertainPosition(firstTeam.players, "GK");
    playerFirstTeam.Add(tempPlayerStorage[0]);
    tempPlayerStorage = ReturnSortedListOfCertainPosition(firstTeam.players, "DF");
    for(var i = 0; i < 4; i++)
    {
        playerFirstTeam.Add(tempPlayerStorage[i]);
    }
    tempPlayerStorage = ReturnSortedListOfCertainPosition(firstTeam.players, "MF");
    for (var i = 0; i < 3; i++)
    {
        playerFirstTeam.Add(tempPlayerStorage[i]);
    }
    tempPlayerStorage = ReturnSortedListOfCertainPosition(firstTeam.players, "FW");
    for (var i = 0; i < 3; i++)
    {
        playerFirstTeam.Add(tempPlayerStorage[i]);
    }
    tempPlayerStorage = ReturnSortedListOfCertainPosition(secondTeam.players, "GK");
    playerSecondTeam.Add(tempPlayerStorage[0]);
    tempPlayerStorage = ReturnSortedListOfCertainPosition(secondTeam.players, "DF");
    for (var i = 0; i < 4; i++)
    {
        playerSecondTeam.Add(tempPlayerStorage[i]);
    }
    tempPlayerStorage = ReturnSortedListOfCertainPosition(secondTeam.players, "MF");
    for (var i = 0; i < 3; i++)
    {
        playerSecondTeam.Add(tempPlayerStorage[i]);
    }
    tempPlayerStorage = ReturnSortedListOfCertainPosition(secondTeam.players, "FW");
    for (var i = 0; i < 3; i++)
    {
        playerSecondTeam.Add(tempPlayerStorage[i]);
    }
    Console.WriteLine("\n \n");
    var given_goals = 0;
    var taken_goals = 0;
    var numberOfStrikersFirstTeam = random.Next(1, 3);
    var numberOfStrikersSecondTeam = random.Next(1, 3);
    var strikersFirstTeam = new Dictionary<string, (string Club, int Goals)>();
    var strikersSecondTeam = new Dictionary<string, (string Club, int Goals)>();
    if (GetRandomBoolean())
    {
        Console.WriteLine($"The team that won the match was -> {firstTeam.Name} against -> {secondTeam.Name}");
        matchRecords.Add((firstTeam.Name, secondTeam.Name));
        firstTeam.Wins++;
        given_goals = random.Next(1, 11);
        while (true)
        {
            taken_goals = random.Next(0, 11);
            if (taken_goals > given_goals)
            {
                continue;
            }
            else
            {
                firstTeam.Given_Goals += given_goals;
                firstTeam.Taken_Goals += taken_goals;
                break;
            }
        }
        secondTeam.Losses++;
        secondTeam.Taken_Goals += given_goals;
        secondTeam.Given_Goals += taken_goals;
        if(numberOfStrikersFirstTeam > given_goals)
        {
            numberOfStrikersFirstTeam = given_goals;
        }
        if(numberOfStrikersFirstTeam == given_goals)
        {
            if(numberOfStrikersFirstTeam is 1)
            {
                strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, 1));
            }
            if(numberOfStrikersFirstTeam is 2)
            {
                strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, 1));
                strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, 1));
            }
            if (numberOfStrikersFirstTeam is 3)
            {
                strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, 1));
                strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, 1));
                strikersFirstTeam.Add(playerFirstTeam[10].Name, (firstTeam.Name, 1));
            }
        }
        else
        {
            if(given_goals % 2 is not 0)
            {
                if(numberOfStrikersFirstTeam is 1)
                {
                    strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, 1));
                }
                if(numberOfStrikersFirstTeam is 2)
                {
                    strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, given_goals % 2 + 1));
                    strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, (given_goals - (given_goals % 2)) + 2));
                }
                if(numberOfStrikersFirstTeam is 3)
                {
                    strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, given_goals % 2 + 1));
                    strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, (given_goals - (given_goals % 2)) + 2));
                    strikersFirstTeam.Add(playerFirstTeam[10].Name, (firstTeam.Name, (given_goals - (given_goals % 2)) + 3));
                }
            }
            else
            {
                if (numberOfStrikersFirstTeam is 1)
                {
                    strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, given_goals + 1));
                }
                if (numberOfStrikersFirstTeam is 2)
                {
                    strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, given_goals % 2 + 1));
                    strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, (given_goals % 2 + 2)));
                }
                if (numberOfStrikersFirstTeam is 3)
                {
                    strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, given_goals % 2 + 1));
                    strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, (given_goals % 2) + 2));
                    strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, (given_goals % 2) + 3));
                }
            }
        }
        if (numberOfStrikersSecondTeam > taken_goals)
        {
            numberOfStrikersSecondTeam = taken_goals;
        }
        if (numberOfStrikersSecondTeam == taken_goals)
        {
            if (numberOfStrikersSecondTeam is 1)
            {
                strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, 1));
            }
            if (numberOfStrikersSecondTeam is 2)
            {
                strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, 1));
                strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, 1));
            }
            if (numberOfStrikersSecondTeam is 3)
            {
                strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, 1));
                strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, 1));
                strikersSecondTeam.Add(playerSecondTeam[10].Name, (secondTeam.Name, 1));
            }
        }
        else
        {
            if (taken_goals % 2 is not 0)
            {
                if (numberOfStrikersSecondTeam is 1)
                {
                    strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, taken_goals + 1));
                }
                if (numberOfStrikersSecondTeam is 2)
                {
                    strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, taken_goals % 2 + 1));
                    strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, (taken_goals - (taken_goals % 2)) + 2));
                }
                if (numberOfStrikersSecondTeam is 3)
                {
                    strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, taken_goals % 2 + 1));
                    strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, (taken_goals - (taken_goals % 2)) + 2));
                    strikersSecondTeam.Add(playerSecondTeam[10].Name, (secondTeam.Name, (taken_goals - (taken_goals % 2)) + 3));
                }
            }
            else
            {
                if (numberOfStrikersSecondTeam is 1)
                {
                    strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, taken_goals + 1));
                }
                if (numberOfStrikersSecondTeam is 2)
                {
                    strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, taken_goals % 2 + 1));
                    strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, (taken_goals - (taken_goals % 2)) + 2));
                }
                if (numberOfStrikersSecondTeam is 3)
                {
                    strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, taken_goals % 2 + 1));
                    strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, (taken_goals - (taken_goals % 2)) + 2));
                    strikersSecondTeam.Add(playerSecondTeam[10].Name, (secondTeam.Name, (taken_goals - (taken_goals % 2)) + 3));
                }
            }
        }
        if(strikers.Count is 0)
        {
            foreach(var item in strikersFirstTeam)
            {
                strikers.Add(item.Key, (item.Value.Club, item.Value.Goals));
            }
            foreach(var item in strikersSecondTeam)
            {
                strikers.Add(item.Key, (item.Value.Club, item.Value.Goals));
            }
        }
        var tempStrikerGoals = 0;
        foreach(var item in strikers)
        {
            foreach(var item2 in strikersFirstTeam)
            {
                if((item.Key == item2.Key) && (item.Value.Club == item2.Value.Club))
                {
                    tempStrikerGoals = item.Value.Goals + item2.Value.Goals;
                    strikers[item.Key] = (item.Value.Club, tempStrikerGoals);
                }
            }
            foreach (var item2 in strikersSecondTeam)
            {
                if ((item.Key == item2.Key) && (item.Value.Club == item2.Value.Club))
                {
                    tempStrikerGoals = item.Value.Goals + item2.Value.Goals;
                    strikers[item.Key] = (item.Value.Club, tempStrikerGoals);
                }
            }
        }
        foreach(var item in strikersFirstTeam)
        {
            if (!strikers.ContainsKey(item.Key))
            {
                strikers.Add(item.Key, (item.Value.Club, item.Value.Goals));
            }
        }
        foreach (var item in strikersSecondTeam)
        {
            if (!strikers.ContainsKey(item.Key))
            {
                strikers.Add(item.Key, (item.Value.Club, item.Value.Goals));
            }
        }
        var newRating = 0;
        foreach(var item in firstTeam.players)
        {
            
            if(item.Value.position is not "FW")
            {
                newRating = item.Value.rating + (int)(item.Value.rating * 0.02);
                firstTeam.players[item.Key] = (item.Value.position, newRating);
            }
            else
            {
                foreach(var item2 in strikersFirstTeam)
                {
                    if(item.Key == item2.Key)
                    {
                        newRating = item.Value.rating + (int)(item.Value.rating * 0.05);
                        firstTeam.players[item.Key] = (item.Value.position, newRating);
                    }
                }
            }
        }
        foreach (var item in secondTeam.players)
        {

            if (item.Value.position is not "FW")
            {
                newRating = item.Value.rating - (int)(item.Value.rating * 0.02);
                secondTeam.players[item.Key] = (item.Value.position, newRating);
            }
            else
            {
                foreach (var item2 in strikersSecondTeam)
                {
                    if (item.Key == item2.Key)
                    {
                        newRating = item.Value.rating + (int)(item.Value.rating * 0.05);
                        secondTeam.players[item.Key] = (item.Value.position, newRating);
                    }
                }
            }
        }

    }
    else
    {
        Console.WriteLine($"The team that won the match was -> {secondTeam.Name} against -> {firstTeam.Name}");
        matchRecords.Add((secondTeam.Name, firstTeam.Name));
        secondTeam.Wins++;
        given_goals = random.Next(1, 11);
        while (true)
        {
            taken_goals = random.Next(0, 11);
            if (taken_goals > given_goals)
            {
                continue;
            }
            else
            {
                secondTeam.Given_Goals += given_goals;
                secondTeam.Taken_Goals += taken_goals;
                break;
            }
        }
        firstTeam.Losses++;
        firstTeam.Taken_Goals += given_goals;
        firstTeam.Given_Goals += taken_goals;
        if (numberOfStrikersSecondTeam > given_goals)
        {
            numberOfStrikersSecondTeam = given_goals;
        }
        if (numberOfStrikersSecondTeam == given_goals)
        {
            if (numberOfStrikersSecondTeam is 1)
            {
                strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, 1));
            }
            if (numberOfStrikersSecondTeam is 2)
            {
                strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, 1));
                strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, 1));
            }
            if (numberOfStrikersSecondTeam is 3)
            {
                strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, 1));
                strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, 1));
                strikersSecondTeam.Add(playerSecondTeam[10].Name, (secondTeam.Name, 1));
            }
        }
        else
        {
            if (given_goals % 2 is not 0)
            {
                if (numberOfStrikersSecondTeam is 1)
                {
                    strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, 1));
                }
                if (numberOfStrikersSecondTeam is 2)
                {
                    strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, given_goals % 2 + 1));
                    strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, (given_goals - (given_goals % 2)) + 2));
                }
                if (numberOfStrikersSecondTeam is 3)
                {
                    strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, given_goals % 2 + 1));
                    strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, (given_goals - (given_goals % 2)) + 2));
                    strikersSecondTeam.Add(playerSecondTeam[10].Name, (secondTeam.Name, (given_goals - (given_goals % 2)) + 3));
                }
            }
            else
            {
                if (numberOfStrikersSecondTeam is 1)
                {
                    strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, given_goals + 1));
                }
                if (numberOfStrikersSecondTeam is 2)
                {
                    strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, given_goals % 2 + 1));
                    strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, (given_goals % 2 + 2)));
                }
                if (numberOfStrikersSecondTeam is 3)
                {
                    strikersSecondTeam.Add(playerSecondTeam[8].Name, (secondTeam.Name, given_goals % 2 + 1));
                    strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, (given_goals % 2) + 2));
                    strikersSecondTeam.Add(playerSecondTeam[9].Name, (secondTeam.Name, (given_goals % 2) + 3));
                }
            }
        }
        if (numberOfStrikersFirstTeam > taken_goals)
        {
            numberOfStrikersFirstTeam = taken_goals;
        }
        if (numberOfStrikersFirstTeam == taken_goals)
        {
            if (numberOfStrikersFirstTeam is 1)
            {
                strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, 1));
            }
            if (numberOfStrikersFirstTeam is 2)
            {
                strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, 1));
                strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, 1));
            }
            if (numberOfStrikersFirstTeam is 3)
            {
                strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, 1));
                strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, 1));
                strikersFirstTeam.Add(playerFirstTeam[10].Name, (firstTeam.Name, 1));
            }
        }
        else
        {
            if (taken_goals % 2 is not 0)
            {
                if (numberOfStrikersFirstTeam is 1)
                {
                    strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, taken_goals + 1));
                }
                if (numberOfStrikersFirstTeam is 2)
                {
                    strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, taken_goals % 2 + 1));
                    strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, (taken_goals - (taken_goals % 2)) + 2));
                }
                if (numberOfStrikersFirstTeam is 3)
                {
                    strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, taken_goals % 2 + 1));
                    strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, (taken_goals - (taken_goals % 2)) + 2));
                    strikersFirstTeam.Add(playerFirstTeam[10].Name, (firstTeam.Name, (taken_goals - (taken_goals % 2)) + 3));
                }
            }
            else
            {
                if (numberOfStrikersFirstTeam is 1)
                {
                    strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, taken_goals + 1));
                }
                if (numberOfStrikersFirstTeam is 2)
                {
                    strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, taken_goals % 2 + 1));
                    strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, (taken_goals - (taken_goals % 2)) + 2));
                }
                if (numberOfStrikersFirstTeam is 3)
                {
                    strikersFirstTeam.Add(playerFirstTeam[8].Name, (firstTeam.Name, taken_goals % 2 + 1));
                    strikersFirstTeam.Add(playerFirstTeam[9].Name, (firstTeam.Name, (taken_goals - (taken_goals % 2)) + 2));
                    strikersFirstTeam.Add(playerFirstTeam[10].Name, (firstTeam.Name, (taken_goals - (taken_goals % 2)) + 3));
                }
            }
        }
        if (strikers.Count is 0)
        {
            foreach (var item in strikersFirstTeam)
            {
                strikers.Add(item.Key, (item.Value.Club, item.Value.Goals));
            }
            foreach (var item in strikersSecondTeam)
            {
                strikers.Add(item.Key, (item.Value.Club, item.Value.Goals));
            }
        }
        var tempStrikerGoals = 0;
        foreach (var item in strikers)
        {
            foreach (var item2 in strikersFirstTeam)
            {
                if ((item.Key == item2.Key) && (item.Value.Club == item2.Value.Club))
                {
                    tempStrikerGoals = item.Value.Goals + item2.Value.Goals;
                    strikers[item.Key] = (item.Value.Club, tempStrikerGoals);
                }
            }
            foreach (var item2 in strikersSecondTeam)
            {
                if ((item.Key == item2.Key) && (item.Value.Club == item2.Value.Club))
                {
                    tempStrikerGoals = item.Value.Goals + item2.Value.Goals;
                    strikers[item.Key] = (item.Value.Club, tempStrikerGoals);
                }
            }
        }
        foreach (var item in strikersFirstTeam)
        {
            if (!strikers.ContainsKey(item.Key))
            {
                strikers.Add(item.Key, (item.Value.Club, item.Value.Goals));
            }
        }
        foreach (var item in strikersSecondTeam)
        {
            if (!strikers.ContainsKey(item.Key))
            {
                strikers.Add(item.Key, (item.Value.Club, item.Value.Goals));
            }
        }
        var newRating = 0;
        foreach (var item in secondTeam.players)
        {
            if (item.Value.position is not "FW")
            {
                newRating = item.Value.rating + (int)(item.Value.rating * 0.02);
                secondTeam.players[item.Key] = (item.Value.position, newRating);
            }
            else
            {
                foreach (var item2 in strikersSecondTeam)
                {
                    if (item.Key == item2.Key)
                    {
                        newRating = item.Value.rating + (int)(item.Value.rating * 0.05);
                        secondTeam.players[item.Key] = (item.Value.position, newRating);
                    }
                }
            }
        }
        foreach (var item in firstTeam.players)
        {

            if (item.Value.position is not "FW")
            {
                newRating = item.Value.rating - (int)(item.Value.rating * 0.02);
                firstTeam.players[item.Key] = (item.Value.position, newRating);
            }
            else
            {
                foreach (var item2 in strikersFirstTeam)
                {
                    if (item.Key == item2.Key)
                    {
                        newRating = item.Value.rating + (int)(item.Value.rating * 0.05);
                        firstTeam.players[item.Key] = (item.Value.position, newRating);
                    }
                }
            }
        }
    }
}

void Start()
{
    var matchRecords = new List<(string Winner, string Looser)>();
    var allTeamsStrikers = new Dictionary<string, (string Club, int Goals)>();
    var allMatchesPlayed = false;
    var croatianTeam = new Team("Croatian");
    var morrocanTeam = new Team("Moroccan");
    var canadaianTeam = new Team("Canadian");
    var belgianTeam = new Team("Belgian");
    var flag = false;
    while (true)
    {
        PrintMenu();
        var input = Console.ReadLine();
        switch (input)
        {
            case "1":
                Console.WriteLine("\n Zelis li odgrati sve utakmice? \n\n Y - Da N - NE");
                input = Console.ReadLine();
                if (input is "Y")
                {
                    if (!allMatchesPlayed)
                    {
                        TrainPlayers(croatianTeam.players);
                    }
                    else
                    {
                        Console.WriteLine("\n \n Skupina je zavrsila! \n \n");
                    }
                }
                else if (input is "N")
                {
                    Console.WriteLine("\n----Otkaz radnje----\n");
                }
                else
                {
                    Console.WriteLine("\n----Nedozvoljena vrijednost!----\n");
                }
                break;
            case "2":
                Console.WriteLine("\n Zelis li odgrati sve utakmice? \n\n Y - Da N - NE");
                input = Console.ReadLine();
                if(input is "Y")
                {
                    if (!allMatchesPlayed)
                    {
                        PlayMatch(morrocanTeam, croatianTeam, matchRecords, allTeamsStrikers);
                        PlayMatch(belgianTeam, canadaianTeam, matchRecords, allTeamsStrikers);
                        PlayMatch(belgianTeam, morrocanTeam, matchRecords, allTeamsStrikers);
                        PlayMatch(croatianTeam, canadaianTeam, matchRecords, allTeamsStrikers);
                        PlayMatch(croatianTeam, belgianTeam, matchRecords, allTeamsStrikers);
                        PlayMatch(canadaianTeam, morrocanTeam, matchRecords, allTeamsStrikers);
                        allMatchesPlayed = true;
                    }
                    else
                    {
                        Console.WriteLine("\n \n Skupina je zavrsila! \n \n");
                    }
                } 
                else if(input is "N")
                {
                    Console.WriteLine("\n----Otkaz radnje----\n");
                }
                else
                {
                    Console.WriteLine("\n----Nedozvoljena vrijednost!----\n");
                }
                break;
            case "3":
                while (true)
                {
                    PrintMenuStatistics();
                    input = Console.ReadLine();
                    var statisticFlag = false;
                    switch (input)
                    {
                        case "1":
                            Console.WriteLine("\n \n 1 - Belgija \n 2 - Moroko \n 3 - Kanada \n 4 - Hrvatska \n \n");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    PrintAllPlayers(belgianTeam.players);
                                    break;
                                case "2":
                                    PrintAllPlayers(morrocanTeam.players);
                                    break;
                                case "3":
                                    PrintAllPlayers(canadaianTeam.players);
                                    break;
                                case "4":
                                    PrintAllPlayers(croatianTeam.players);
                                    break;
                                default:
                                    Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                    break;
                            }
                            break;
                        case "2":
                            Console.WriteLine("\n \n 1 - Belgija \n 2 - Moroko \n 3 - Kanada \n 4 - Hrvatska \n \n");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    PrintAllPlayersByRatingAsceding(belgianTeam.players);
                                    break;
                                case "2":
                                    PrintAllPlayersByRatingAsceding(morrocanTeam.players);
                                    break;
                                case "3":
                                    PrintAllPlayersByRatingAsceding(canadaianTeam.players);
                                    break;
                                case "4":
                                    PrintAllPlayersByRatingAsceding(croatianTeam.players);
                                    break;
                                default:
                                    Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                    break;
                            }
                            break;
                        case "3":
                            Console.WriteLine("\n \n 1 - Belgija \n 2 - Moroko \n 3 - Kanada \n 4 - Hrvatska \n \n");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    PrintAllPlayersByRatingDescending(belgianTeam.players);
                                    break;
                                case "2":
                                    PrintAllPlayersByRatingDescending(morrocanTeam.players);
                                    break;
                                case "3":
                                    PrintAllPlayersByRatingDescending(canadaianTeam.players);
                                    break;
                                case "4":
                                    PrintAllPlayersByRatingDescending(croatianTeam.players);
                                    break;
                                default:
                                    Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                    break;
                            }
                            break;
                        case "4":
                            Console.WriteLine("\n \n 1 - Belgija \n 2 - Moroko \n 3 - Kanada \n 4 - Hrvatska \n \n");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    PrintAllPlayersByName(belgianTeam.players);
                                    break;
                                case "2":
                                    PrintAllPlayersByName(morrocanTeam.players);
                                    break;
                                case "3":
                                    PrintAllPlayersByName(canadaianTeam.players);
                                    break;
                                case "4":
                                    PrintAllPlayersByName(croatianTeam.players);
                                    break;
                                default:
                                    Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                    break;
                            }
                            break;
                        case "5":
                            Console.WriteLine("\n \n 1 - Belgija \n 2 - Moroko \n 3 - Kanada \n 4 - Hrvatska \n \n");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    PrintAllPlayersByRating(belgianTeam.players);
                                    break;
                                case "2":
                                    PrintAllPlayersByRating(morrocanTeam.players);
                                    break;
                                case "3":
                                    PrintAllPlayersByRating(canadaianTeam.players);
                                    break;
                                case "4":
                                    PrintAllPlayersByRating(croatianTeam.players);
                                    break;
                                default:
                                    Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                    break;
                            }
                            break;
                        case "6":
                            Console.WriteLine("\n \n 1 - Belgija \n 2 - Moroko \n 3 - Kanada \n 4 - Hrvatska \n \n");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    Console.WriteLine("\n \n 1 - GK \n 2 - DF \n 3 - MF \n 4 - FW \n \n");
                                    input = Console.ReadLine();
                                    switch (input)
                                    {
                                        case "1":
                                            PrintAllPlayersByPosition(belgianTeam.players, "GK");
                                            break;
                                        case "2":
                                            PrintAllPlayersByPosition(belgianTeam.players, "DF");
                                            break;
                                        case "3":
                                            PrintAllPlayersByPosition(belgianTeam.players, "MF");
                                            break;
                                        case "4":
                                            PrintAllPlayersByPosition(belgianTeam.players, "FW");
                                            break;
                                        default:
                                            Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                            break;
                                    }
                                    break;
                                case "2":
                                    Console.WriteLine("\n \n 1 - GK \n 2 - DF \n 3 - MF \n 4 - FW \n \n");
                                    input = Console.ReadLine();
                                    switch (input)
                                    {
                                        case "1":
                                            PrintAllPlayersByPosition(belgianTeam.players, "GK");
                                            break;
                                        case "2":
                                            PrintAllPlayersByPosition(belgianTeam.players, "DF");
                                            break;
                                        case "3":
                                            PrintAllPlayersByPosition(belgianTeam.players, "MF");
                                            break;
                                        case "4":
                                            PrintAllPlayersByPosition(belgianTeam.players, "FW");
                                            break;
                                        default:
                                            Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                            break;
                                    }
                                    break;
                                case "3":
                                    Console.WriteLine("\n \n 1 - GK \n 2 - DF \n 3 - MF \n 4 - FW \n \n");
                                    input = Console.ReadLine();
                                    switch (input)
                                    {
                                        case "1":
                                            PrintAllPlayersByPosition(belgianTeam.players, "GK");
                                            break;
                                        case "2":
                                            PrintAllPlayersByPosition(belgianTeam.players, "DF");
                                            break;
                                        case "3":
                                            PrintAllPlayersByPosition(belgianTeam.players, "MF");
                                            break;
                                        case "4":
                                            PrintAllPlayersByPosition(belgianTeam.players, "FW");
                                            break;
                                        default:
                                            Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                            break;
                                    }
                                    break;
                                case "4":
                                    Console.WriteLine("\n \n 1 - GK \n 2 - DF \n 3 - MF \n 4 - FW \n \n");
                                    input = Console.ReadLine();
                                    switch (input)
                                    {
                                        case "1":
                                            PrintAllPlayersByPosition(belgianTeam.players, "GK");
                                            break;
                                        case "2":
                                            PrintAllPlayersByPosition(belgianTeam.players, "DF");
                                            break;
                                        case "3":
                                            PrintAllPlayersByPosition(belgianTeam.players, "MF");
                                            break;
                                        case "4":
                                            PrintAllPlayersByPosition(belgianTeam.players, "FW");
                                            break;
                                        default:
                                            Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                            break;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                    break;
                            }
                            break;
                        case "7":
                            Console.WriteLine("\n \n 1 - Belgija \n 2 - Moroko \n 3 - Kanada \n 4 - Hrvatska \n \n");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    PrintFirstElevenPlayers(belgianTeam.players);
                                    break;
                                case "2":
                                    PrintFirstElevenPlayers(morrocanTeam.players);
                                    break;
                                case "3":
                                    PrintFirstElevenPlayers(canadaianTeam.players);
                                    break;
                                case "4":
                                    PrintFirstElevenPlayers(croatianTeam.players);
                                    break;
                                default:
                                    Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                    break;
                            }
                            break;
                        case "8":
                            PrintAllShooters(allTeamsStrikers);
                            break;
                        case "9":
                            Console.WriteLine("\n \n 1 - Belgija \n 2 - Moroko \n 3 - Kanada \n 4 - Hrvatska \n \n");
                            input = Console.ReadLine();
                            switch (input)
                            {
                                case "1":
                                    Console.WriteLine($"Belgija -> pobjeda: {belgianTeam.Wins} --- gubitaka: {belgianTeam.Losses}\n");
                                    break;
                                case "2":
                                    Console.WriteLine($"Moroko -> pobjeda: {morrocanTeam.Wins} --- gubitaka: {morrocanTeam.Losses}\n");
                                    break;
                                case "3":
                                    Console.WriteLine($"Kanada -> pobjeda: {canadaianTeam.Wins} --- gubitaka: {canadaianTeam.Losses}\n");
                                    break;
                                case "4":
                                    Console.WriteLine($"Hrvatska -> pobjeda: {croatianTeam.Wins} --- gubitaka: {croatianTeam.Losses}\n");
                                    break;
                                default:
                                    Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                    break;
                            }
                            break;
                        case "10":
                            Console.WriteLine($"Belgija -> pobijeda: {belgianTeam.Wins} --- gubitci: {belgianTeam.Losses} \n" +
                                $"Moroko -> pobijeda: {morrocanTeam.Wins} --- gubitci: {morrocanTeam.Losses} \n" +
                                $"Kanada -> pobijeda: {canadaianTeam.Wins} --- gubitci: {canadaianTeam.Losses} \n" +
                                $"Hrvatska -> pobijeda: {croatianTeam.Wins} --- gubitci: {croatianTeam.Losses} \n");
                            break;
                        case "11":
                            var teamList = new List<Team> 
                            {
                                croatianTeam,
                                morrocanTeam,
                                canadaianTeam,
                                belgianTeam
                            };
                            PrintGroupTable(teamList);
                            break;
                        case "0":
                            statisticFlag = true;
                            break;
                        default:
                            Console.WriteLine("Unia si nedozvoljenu vrijednost!\n");
                            break;
                    }
                    if (statisticFlag)
                    {
                        break;
                    }
                }
                break;
            case "4":
                while (true)
                {
                    PrintMenuPlayerControl();
                    input = Console.ReadLine();
                    var controlFlag = false;
                    switch(input)
                    {
                        case "1":
                            Console.WriteLine("\n----Zelis li uniti novog igraca? Y -> DA N -> NE ----");
                            input = Console.ReadLine();
                            if(input is "Y")
                            {
                                Console.WriteLine("\n \n 1 - Belgija \n 2 - Moroko \n 3 - Kanada \n 4 - Hrvatska \n \n");
                                input = Console.ReadLine();
                                switch (input)
                                {
                                    case "1":
                                        AddPlayerToTeam(belgianTeam.players);
                                        break;
                                    case "2":
                                        AddPlayerToTeam(morrocanTeam.players);
                                        break;
                                    case "3":
                                        AddPlayerToTeam(canadaianTeam.players);
                                        break;
                                    case "4":
                                        AddPlayerToTeam(croatianTeam.players);
                                        break;
                                    default:
                                        Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                        break;
                                }
                            } 
                            else if(input is "N")
                            {
                                Console.WriteLine("\n---- Otkaz Ranje ----\n");
                            }
                            else
                            {
                                Console.WriteLine("\n---- Nedozvoljena Vrijednost! ----\n");
                            }
                            break;
                        case "2":
                            Console.WriteLine("\n----Zelis li uniti izbrisat igraca? Y -> DA N -> NE ----");
                            input = Console.ReadLine();
                            if(input is "Y")
                            {
                                Console.WriteLine("\n Unesi ime igraca i u koji klub se nalazi\n");
                                Console.WriteLine("\n \n 1 - Belgija \n 2 - Moroko \n 3 - Kanada \n 4 - Hrvatska \n \n");
                                input = Console.ReadLine() ?? "ERROR: Could not save String!";
                                var playerToDeleteFromTeam = Console.ReadLine() ?? "ERROR: Could not save String!";
                                switch (input)
                                {
                                    case "1":
                                        DeletePlayerFromTeam(belgianTeam.players, playerToDeleteFromTeam);
                                        break;
                                    case "2":
                                        DeletePlayerFromTeam(morrocanTeam.players, playerToDeleteFromTeam);
                                        break;
                                    case "3":
                                        DeletePlayerFromTeam(canadaianTeam.players, playerToDeleteFromTeam);
                                        break;
                                    case "4":
                                        DeletePlayerFromTeam(croatianTeam.players, playerToDeleteFromTeam);
                                        break;
                                    default:
                                        Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                        break;
                                }
                            }
                            else if(input is "N")
                            {
                                Console.WriteLine("\n---- Otkaz Ranje ----\n");
                            }
                            else
                            {
                                Console.WriteLine("\n---- Nedozvoljena Vrijednost! ----\n");
                            }
                            break;
                        case "3":
                            Console.WriteLine("\n----Zelis li uniti prominiti igraca? Y -> DA N -> NE ----");
                            input = Console.ReadLine();
                            if(input is "Y")
                            {
                                Console.WriteLine("\n \n 1 - Belgija \n 2 - Moroko \n 3 - Kanada \n 4 - Hrvatska \n \n");
                                input = Console.ReadLine();
                                switch (input)
                                {
                                    case "1":
                                        UpdatePlayerInTeam(belgianTeam.players);
                                        break;
                                    case "2":
                                        UpdatePlayerInTeam(morrocanTeam.players);
                                        break;
                                    case "3":
                                        UpdatePlayerInTeam(canadaianTeam.players);
                                        break;
                                    case "4":
                                        UpdatePlayerInTeam(croatianTeam.players);
                                        break;
                                    default:
                                        Console.WriteLine("\n Unia si nedozvoljenu vrijednost! \n");
                                        break;
                                }
                            }
                            else if(input is "N")
                            {
                                Console.WriteLine("\n---- Otkaz Ranje ----\n");
                            }
                            else
                            {
                                Console.WriteLine("\n---- Nedozvoljena Vrijednost! ----\n");
                            }
                            break;
                        case "0":
                            controlFlag = true;
                            break;
                        default:
                            Console.WriteLine("Unia si nedozvoljenu vrijednost!\n");
                            break;
                    }
                    if(controlFlag)
                    {
                        break;
                    }
                }
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
