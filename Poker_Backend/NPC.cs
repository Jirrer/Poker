namespace Poker;

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

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

        if (board.Count(x => x != null) == 0) { this.betPreFlop(toPlay, this.getPotOdds(toPlay, potSize), potSize); return; }

        // all after flop:
        double potOdds = this.getPotOdds(toPlay, potSize);
        double handEquity = this.getHandEquity(board);

        if (handEquity < potOdds && this.bet < toPlay) { this.fold(); }
        // else if (handEquity >= 2 * potOdds) { this.raise(potOdds); }
        // else { this.call(toPlay); }

        this.call(toPlay);
    }

    private void betPreFlop(int toCall, double potOdds, int potSize)
    {

        int handValue = PreFlopValue.getPreflopValue(this.card1, this.card2);
        Console.Write($"{handValue}  - ");

        if (handValue <= 10) { this.raise(potOdds, toCall, potSize); }
        else if (handValue <= 30) { this.call(toCall); }
        else if (handValue <= 45 && this.bet >= (int)0.5 * toCall) { this.call(toCall); }
        else if (this.bet == toCall) { this.check(); }
        else { this.fold(); }
    }
    
    private double getPotOdds(int toPlay, int potSize)
    {
        return toPlay / (potSize + toPlay);
    }

    private double getHandEquity(Card[] board) {
       


        return 0.1;
    }



    private void call(int toCall)
    {
        if (this.bet < toCall) { this.bet = toCall; }
    }

    private void raise(double potOdds, int toCall, int potSize)
    {
        Console.WriteLine("test");
        this.bet = (int)(toCall + Math.Round(potOdds * potSize));
    }

    private void check()
    {
        return;
    }

    private void fold()
    {
        this.bet = -1;
    }

}