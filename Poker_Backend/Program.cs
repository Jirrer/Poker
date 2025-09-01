namespace Poker;

using System;
using System.Dynamic;

static class Program
{
    private static HashSet<string> NPCNames = new HashSet<string>();
    private static NPC[] npcs = new NPC[5];
    static void Main()
    {
        populateNpcNames();
        createNpcs();

        foreach (NPC n in npcs)
        {
            Console.WriteLine(n.name);
        }


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
            Random random = new Random();

            int randomIndex = random.Next(NPCNames.Count);
            string randomName = new List<string>(NPCNames)[randomIndex];

            npcs[npcIndex] = new NPC(randomName, getRandomCard(), getRandomCard());
            NPCNames.Remove(randomName);
        }
    }

    private static Card getRandomCard()
    {
        return new Card();
    }
}