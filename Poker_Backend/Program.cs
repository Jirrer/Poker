namespace Poker;

using System;
using System.ComponentModel.DataAnnotations;

// To-Do: make ai work

static class Program
{
    private static Random random = new Random();
    private static HashSet<string> NPCNames = new HashSet<string>();
    private static List<Card> deck = new List<Card>();
    private static List<NPC> npcs = new List<NPC>();
    private static Card[] board = new Card[5];
    private static int potSize = 0;
    private static int smallBlind = 15;
    private static int bigBlind = 30;
    private static int numberOfNpcs = 5;

    static void Main()
    {
        createDeck();
        shuffleDeck();
        populateNpcNames();
        createNpcs();
        runGame();
    }

    private static void createDeck()
    {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };

        for (int value = 2; value <= 14; value++)
        {
            foreach (string suit in suits) { deck.Add(new Card(value, suit)); }
        }
    }

    private static void shuffleDeck()
    {
        for (int i = deck.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Card temp = deck[i];
            deck[i] = deck[j];
            deck[j] = temp;
        }
    }

    private static void populateNpcNames()
    {
        string filePath = @"NPC_Names.txt";

        try { foreach (string line in File.ReadLines(filePath)) { NPCNames.Add(line); } }
        catch (Exception e) { Console.WriteLine($"Error: {e.Message}"); }
    }

    private static void createNpcs()
    {
        for (int npcIndex = 0; npcIndex < numberOfNpcs; npcIndex++)
        {
            int randomIndex = random.Next(NPCNames.Count);
            string randomName = new List<string>(NPCNames)[randomIndex];

            npcs.Add(new NPC(randomName, pullFromTheDeck(), pullFromTheDeck(), 10000));
            NPCNames.Remove(randomName);
        }
    }


    private static Card pullFromTheDeck()
    {
        Card nextCard = deck[0];
        deck.RemoveAt(0);

        return nextCard;
    }

    static void runGame()
    {
        preFlop();
        // flop();
        // turn();
        // river();
    }

    static void preFlop()
    {
        Console.WriteLine("Pre-Flop");
        setBlinds();
        swapTableOrder();
        playNextRound(30);

    }

    static void setBlinds()
    {
        npcs[0].bet = smallBlind;
        npcs[1].bet = bigBlind;

        potSize = smallBlind + bigBlind;
    }

    static void swapTableOrder()
    {
        NPC tempSmallBlind = npcs[0];
        NPC tempBigBlind = npcs[1];

        npcs[0] = npcs[npcs.Count - 2];
        npcs[1] = npcs[npcs.Count - 1];

        npcs[npcs.Count - 2] = tempSmallBlind;
        npcs[npcs.Count - 1] = tempBigBlind;

    }


    static void flop()
    {
        Console.WriteLine("Flop");
        swapTableOrder();
        board[0] = pullFromTheDeck();
        board[1] = pullFromTheDeck();
        board[2] = pullFromTheDeck();

        playNextRound(0);
    }

    static void turn()
    {
        Console.WriteLine("Turn");
        board[3] = pullFromTheDeck();

        playNextRound(0);

    }

    static void river()
    {
        Console.WriteLine("River");
        board[4] = pullFromTheDeck();

        playNextRound(0);

    }

    static void playNextRound(int toPlay)
    {
        while (true)
        {
            Console.WriteLine("Went Around");
            Console.WriteLine($"Pot Size - {potSize}\n");

            foreach (NPC npc in npcs)
            {
                npc.placeBet(toPlay, board, potSize);

                if (npc.bet > toPlay) { toPlay = npc.bet; }

                if (npc.bet >= 0) { potSize += npc.bet; Console.WriteLine($"{npc.name} bet {npc.bet}"); }
                else { Console.WriteLine($"{npc.name} Folded"); }

                if (npc.bet > 0) { npc.money -= npc.bet; }

            }

            bool continueRound = false;
            foreach (NPC npc in npcs)
            {
                if (npc.bet > 0 && npc.bet < toPlay && npc.money > 0) { continueRound = true; }
            }

            if (!continueRound) { break; }

        }
    }
}