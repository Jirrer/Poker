namespace Poker;

using System;

public class NPC
{
    Card card1;
    Card card2;
    public string name;

    public NPC(string name, Card card1, Card card2)
    {
        this.card1 = card1;
        this.card2 = card2;
        this.name = name;
    }


}