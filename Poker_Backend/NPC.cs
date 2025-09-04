namespace Poker;

using System;
using System.Runtime.CompilerServices;

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

    public void placeBet(int toPlay, Card[] board, int potSize)
    {
        if (toPlay == 0) { toPlay = 1; }

        double potOdds = this.getPotOdds(toPlay, potSize);
        double handEquity = this.getHandEquity(board);

        if (handEquity < potOdds && this.bet < toPlay) { this.fold(); }
        // else if (handEquity >= 2 * potOdds) { this.raise(potOdds); }
        // else { this.call(toPlay); }

        this.call(toPlay);
    }

    private double getPotOdds(int toPlay, int potSize) {
        return toPlay / (potSize + toPlay);
    }

    private double getHandEquity(Card[] board) {
        return 0.1;
    }

    private void fold()
    {
        this.bet = -1;
    }

    private void call(int toCall)
    {
        if (this.bet < toCall) { this.bet = toCall; }
    }

    private void raise(double potOdds)
    {
        Console.WriteLine($"{this.name} Raised");
    }


}