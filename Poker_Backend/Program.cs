namespace Poker;

using System;

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

    static void Main()
    {
        createDeck();
        populateNpcNames();
        createNpcs();
        runGame();
    }

    private static void createDeck()
    {
        string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
        List<Card> newDeck = new List<Card>();

        for (int value = 1; value <= 13; value++) // 1-13 for card values
        {
            foreach (string suit in suits)
            {
                newDeck.Add(new Card(value, suit));
            }
        }

        deck = shuffleDeck(newDeck);
    }

    private static List<Card> shuffleDeck(List<Card> deckInput)
    {
        for (int i = deckInput.Count - 1; i > 0; i--)
        {
            int j = random.Next(i + 1);
            Card temp = deckInput[i];
            deckInput[i] = deckInput[j];
            deckInput[j] = temp;
        }

        return deckInput;
    }

    private static void populateNpcNames()
    {
        string filePath = @"NPC_Names.txt";

        try
        {
            foreach (string line in File.ReadLines(filePath))
            {
                NPCNames.Add(line);
            }
        }

        catch (Exception e)
        {
            Console.WriteLine($"Error: {e.Message}");
        }
    }

    private static void createNpcs()
    {
        for (int npcIndex = 0; npcIndex < 5; npcIndex++) // still 5 NPCs
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
        flop();
        turn();
        river();
    }

    static void preFlop()
    {
        Console.WriteLine("Pre-Flop");
        setBlinds();
        playRound(30);

    }

    static void setBlinds()
    {
        npcs[0].bet = smallBlind;
        npcs[1].bet = bigBlind;

        potSize = smallBlind + bigBlind;
    }

    static void flop()
    {
        Console.WriteLine("Flop");
        board[0] = pullFromTheDeck();
        board[1] = pullFromTheDeck();
        board[2] = pullFromTheDeck();

        playRound(0);
    }

    static void turn()
    {
        Console.WriteLine("Turn");
        board[3] = pullFromTheDeck();

        playRound(0);

    }

    static void river()
    {
        Console.WriteLine("River");
        board[4] = pullFromTheDeck();

        playRound(0);

    }

    static void playRound(int toPlay)
    {
        while (true)
        {
            Console.WriteLine($"Pot Size - {potSize}");


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
                if (npc.bet > 0 && npc.bet < toPlay) { continueRound = true; }
            }

            if (!continueRound) { break; }

            foreach (NPC npc in npcs)
            {
                if (npc.bet >= 0) { npc.bet = 0; }
            }
        }
    }
}