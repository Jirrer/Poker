namespace Poker;

using System;
using Microsoft.VisualBasic;

public class PreFlopValue
{
    private static Dictionary<(int, int, int), int> preFlopRankings = new Dictionary<(int, int, int), int>();

    static PreFlopValue()
    {
        populateHand();
    }

    public static int getPreflopValue(Card card1, Card card2)
    {
        int suited = 0;

        if (card1.suit.Equals(card2.suit)) { suited = 1; }

        try { return preFlopRankings[(card1.value, card2.value, suited)]; }
        catch (System.Collections.Generic.KeyNotFoundException) { return preFlopRankings[(card2.value, card1.value, suited)]; }
    }

    private static void populateHand()
    {
        preFlopRankings.Add((14, 14, 0), 0);
        preFlopRankings.Add((14, 13, 1), 2);
        preFlopRankings.Add((14, 12, 1), 2);
        preFlopRankings.Add((14, 11, 1), 3);
        preFlopRankings.Add((14, 10, 1), 5);
        preFlopRankings.Add((14, 9, 1), 8);
        preFlopRankings.Add((14, 8, 1), 10);
        preFlopRankings.Add((14, 7, 1), 13);
        preFlopRankings.Add((14, 6, 1), 14);
        preFlopRankings.Add((14, 5, 1), 12);
        preFlopRankings.Add((14, 4, 1), 14);
        preFlopRankings.Add((14, 3, 1), 14);
        preFlopRankings.Add((14, 2, 1), 17);
        preFlopRankings.Add((14, 13, 0), 5);
        preFlopRankings.Add((13, 13, 0), 1);
        preFlopRankings.Add((13, 12, 1), 3);
        preFlopRankings.Add((13, 11,1), 3);
        preFlopRankings.Add((13, 10, 1), 6);
        preFlopRankings.Add((13, 9, 1), 10);
        preFlopRankings.Add((13, 8, 1), 16);
        preFlopRankings.Add((13, 7, 1), 19);
        preFlopRankings.Add((13, 6, 1), 24);
        preFlopRankings.Add((13, 5, 1), 25);
        preFlopRankings.Add((13, 4, 1), 25);
        preFlopRankings.Add((13, 3, 1), 26);
        preFlopRankings.Add((13, 2, 1), 26);
        preFlopRankings.Add((14, 12, 0), 8);
        preFlopRankings.Add((13, 12, 0), 9);
        preFlopRankings.Add((12, 12, 0), 1);
        preFlopRankings.Add((12, 11, 1), 5);
        preFlopRankings.Add((12, 10, 1), 6);
        preFlopRankings.Add((12, 9, 1), 10);
        preFlopRankings.Add((12, 8, 1), 19);
        preFlopRankings.Add((12, 7, 1), 26);
        preFlopRankings.Add((12, 6, 1), 28);
        preFlopRankings.Add((12, 5, 1), 29);
        preFlopRankings.Add((12, 4, 1), 29);
        preFlopRankings.Add((12, 3, 1), 30);
        preFlopRankings.Add((12, 2, 1), 31);
        preFlopRankings.Add((14, 11, 0), 12);
        preFlopRankings.Add((13, 11, 0), 14);
        preFlopRankings.Add((12, 11, 0), 15);
        preFlopRankings.Add((11, 11, 0), 2);
        preFlopRankings.Add((11, 10, 1), 6);
        preFlopRankings.Add((11, 9, 1), 11);
        preFlopRankings.Add((11, 8, 1), 17);
        preFlopRankings.Add((11, 7, 1), 27);
        preFlopRankings.Add((11, 6, 1), 33);
        preFlopRankings.Add((11, 5, 1), 35);
        preFlopRankings.Add((11, 4, 1), 37);
        preFlopRankings.Add((11, 3, 1), 37);
        preFlopRankings.Add((11, 2, 1), 38);
        preFlopRankings.Add((14, 10, 0), 18);
        preFlopRankings.Add((13, 10, 0), 20);
        preFlopRankings.Add((12, 10, 0), 22);
        preFlopRankings.Add((11, 10, 0), 21);
        preFlopRankings.Add((10, 10, 0), 4);
        preFlopRankings.Add((10, 9, 1), 10);
        preFlopRankings.Add((10, 8, 1), 16);
        preFlopRankings.Add((10, 7, 1), 25);
        preFlopRankings.Add((10, 6, 1), 31);
        preFlopRankings.Add((10, 5, 1), 40);
        preFlopRankings.Add((10, 4, 1), 40);
        preFlopRankings.Add((10, 3, 1), 41);
        preFlopRankings.Add((10, 2, 1), 41);
        preFlopRankings.Add((14, 9, 0), 32);
        preFlopRankings.Add((13, 9, 0), 35);
        preFlopRankings.Add((12, 9, 0), 36);
        preFlopRankings.Add((11, 9, 0), 34);
        preFlopRankings.Add((10, 9, 0), 31);
        preFlopRankings.Add((9, 9, 0), 7);
        preFlopRankings.Add((9, 8, 1), 17);
        preFlopRankings.Add((9, 7, 1), 24);
        preFlopRankings.Add((9, 6, 1), 29);
        preFlopRankings.Add((9, 5, 1), 38);
        preFlopRankings.Add((9, 4, 1), 47);
        preFlopRankings.Add((9, 3, 1), 47);
        preFlopRankings.Add((9, 2, 1), 49);
        preFlopRankings.Add((14, 8, 0), 39);
        preFlopRankings.Add((13, 8, 0), 50);
        preFlopRankings.Add((12, 8, 0), 53);
        preFlopRankings.Add((11, 8, 0), 48);
        preFlopRankings.Add((10, 8, 0), 43);
        preFlopRankings.Add((9, 8, 0), 42);
        preFlopRankings.Add((8, 8, 0), 9);
        preFlopRankings.Add((8, 7, 1), 21);
        preFlopRankings.Add((8, 6, 1), 27);
        preFlopRankings.Add((8, 5, 1), 33);
        preFlopRankings.Add((8, 4, 1), 40);
        preFlopRankings.Add((8, 3, 1), 53);
        preFlopRankings.Add((8, 2, 1), 54);
        preFlopRankings.Add((14, 7, 0), 45);
        preFlopRankings.Add((13, 7, 0), 57);
        preFlopRankings.Add((12, 7, 0), 66);
        preFlopRankings.Add((11, 7, 0), 64);
        preFlopRankings.Add((10, 7, 0), 59);
        preFlopRankings.Add((9, 7, 0), 55);
        preFlopRankings.Add((8, 7, 0), 52);
        preFlopRankings.Add((7, 7, 0), 12);
        preFlopRankings.Add((7, 6, 1), 25);
        preFlopRankings.Add((7, 5, 1), 28);
        preFlopRankings.Add((7, 4, 1), 37);
        preFlopRankings.Add((7, 3, 1), 45);
        preFlopRankings.Add((7, 2, 1), 56);
        preFlopRankings.Add((14, 6, 0), 51);
        preFlopRankings.Add((13, 6, 0), 60);
        preFlopRankings.Add((12, 6, 0), 71);
        preFlopRankings.Add((11, 6, 0), 80);
        preFlopRankings.Add((10, 6, 0), 74);
        preFlopRankings.Add((9, 6, 0), 68);
        preFlopRankings.Add((8, 6, 0), 61);
        preFlopRankings.Add((7, 6, 0), 57);
        preFlopRankings.Add((6, 6, 0), 16);
        preFlopRankings.Add((6, 5, 1), 27);
        preFlopRankings.Add((6, 4, 1), 29);
        preFlopRankings.Add((6, 3, 1), 38);
        preFlopRankings.Add((6, 2, 1), 49);
        preFlopRankings.Add((14, 5, 0), 44);
        preFlopRankings.Add((13, 5, 0), 63);
        preFlopRankings.Add((12, 5, 0), 75);
        preFlopRankings.Add((11, 5, 0), 82);
        preFlopRankings.Add((10, 5, 0), 89);
        preFlopRankings.Add((9, 5, 0), 83);
        preFlopRankings.Add((8, 5, 0), 73);
        preFlopRankings.Add((7, 5, 0), 65);
        preFlopRankings.Add((6, 5, 0), 58);
        preFlopRankings.Add((5, 5, 0), 20);
        preFlopRankings.Add((5, 4, 1), 28);
        preFlopRankings.Add((5, 3, 1), 32);
        preFlopRankings.Add((5, 2, 1), 39);
        preFlopRankings.Add((14, 4,0), 46);
        preFlopRankings.Add((13, 4, 0), 67);
        preFlopRankings.Add((12, 4, 0), 76);
        preFlopRankings.Add((11, 4, 0), 85);
        preFlopRankings.Add((10, 4, 0), 90);
        preFlopRankings.Add((9, 4, 0), 95);
        preFlopRankings.Add((8, 4, 0), 88);
        preFlopRankings.Add((7, 4, 0), 78);
        preFlopRankings.Add((6, 4, 0), 70);
        preFlopRankings.Add((5, 4, 0), 62);
        preFlopRankings.Add((4, 4, 0), 23);
        preFlopRankings.Add((4, 3, 1), 36);
        preFlopRankings.Add((4, 2, 1), 41);
        preFlopRankings.Add((14, 3, 0), 49);
        preFlopRankings.Add((13, 3, 0), 67);
        preFlopRankings.Add((12, 3, 0), 77);
        preFlopRankings.Add((11, 3, 0), 86);
        preFlopRankings.Add((10, 3, 0), 92);
        preFlopRankings.Add((9, 3, 0), 96);
        preFlopRankings.Add((8, 3, 0), 98);
        preFlopRankings.Add((7, 3, 0), 93);
        preFlopRankings.Add((6, 3, 0), 81);
        preFlopRankings.Add((5, 3, 0), 72);
        preFlopRankings.Add((4, 3, 0), 76);
        preFlopRankings.Add((3, 3, 0), 23);
        preFlopRankings.Add((3, 2, 1), 46);
        preFlopRankings.Add((14, 2, 0), 54);
        preFlopRankings.Add((13, 2, 0), 69);
        preFlopRankings.Add((12, 2, 0), 79);
        preFlopRankings.Add((11, 2, 0), 87);
        preFlopRankings.Add((10, 2, 0), 94);
        preFlopRankings.Add((9, 2, 0), 97);
        preFlopRankings.Add((8, 2, 0), 99);
        preFlopRankings.Add((7, 2, 0), 100);
        preFlopRankings.Add((6, 2, 0), 95);
        preFlopRankings.Add((5, 2, 0), 84);
        preFlopRankings.Add((4, 2, 0), 86);
        preFlopRankings.Add((3, 2, 0), 91);
        preFlopRankings.Add((2, 2, 0), 24);
    }
}