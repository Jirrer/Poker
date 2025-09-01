namespace Poker;

using System;

static class Program
{
    private static Random random = new Random();
    private static HashSet<string> NPCNames = new HashSet<string>();
    private static List<Card> deck = new List<Card>();
    private static NPC[] npcs = new NPC[5];
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
        for (int npcIndex = 0; npcIndex < npcs.Length; npcIndex++)
        {
            int randomIndex = random.Next(NPCNames.Count);
            string randomName = new List<string>(NPCNames)[randomIndex];

            npcs[npcIndex] = new NPC(randomName, pullFromTheDeck(), pullFromTheDeck());
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
        int toPlay = 30;
        
        while (true)
        {
            for (int index = 0; index < npcs.Length; index++)
            {
                if (index == npcs.Length - 2) { npcs[index].bet = smallBlind; }
                else if (index == npcs.Length - 1) { npcs[index].bet = bigBlind; }

                npcs[index].placeBet();

                if (npcs[index].bet > toPlay) { toPlay = npcs[index].bet; }
            }



        }

    }

    static void flop()
    {

    }

    static void turn()
    {

    }

    static void river()
    {

    }
}