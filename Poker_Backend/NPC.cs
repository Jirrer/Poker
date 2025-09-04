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
        Random rng = new Random();
        double roll = rng.NextDouble();

        if (handValue <= 10)  
        {
            if (roll < 0.7) this.raise(potOdds, toCall, potSize);  
            else this.call(toCall);  
        }
        else if (handValue <= 25)  
        {
            if (roll < 0.3) this.raise(potOdds, toCall, potSize);  
            else this.call(toCall);
        }
        else if (handValue <= 40)  
        {
            if (potOdds < 0.25 && roll < 0.5) this.call(toCall);  
            else this.fold();
        }

        else if (this.bet == toCall)
        {
            return;
        }
        else 
        {
            if (roll < 0.1) this.call(toCall); 
            else this.fold();
        }
    }

    private double getPotOdds(int toPlay, int potSize)
    {
        return (double)toPlay / (potSize + toPlay);
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
        this.call(toCall);
        int raiseAmount = (int)(potOdds * potSize);
        this.bet += raiseAmount;
    }

    private void fold()
    {
        this.bet = -1;
    }

}