namespace Poker;

using System;
using System.ComponentModel.DataAnnotations;

public class Card
{
    public int value;
    public string suit;

    public Card(int value, string suit)
    {
        this.value = value;
        this.suit = suit;
    }
}