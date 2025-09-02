namespace Poker;

using System;

public class NPC
{
    public Card card1;
    public Card card2;
    public string name;
    public int bet = 0;
    public int money;

    public NPC(string name, Card card1, Card card2, int money)
    {
        this.card1 = card1;
        this.card2 = card2;
        this.name = name;
        this.money = money;
    }

    public void placeBet(int toPlay)
    {

        bet += toPlay;
    }


}