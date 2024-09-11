using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie1;

public class PokerHandEvaluator
{
    private static readonly Dictionary<string, int> CardValues = new Dictionary<string, int>
    {
        { "2", 2 }, { "3", 3 }, { "4", 4 }, { "5", 5 }, { "6", 6 },
        { "7", 7 }, { "8", 8 }, { "9", 9 }, { "10", 10 }, { "jack", 11 },
        { "queen", 12 }, { "king", 13 }, { "ace", 14 }
    };

    public static string EvaluateHand(List<Card> cards)
    {
        if (IsRoyalFlush(cards)) return "Poker królewski";
        if (IsStraightFlush(cards)) return "Poker";
        if (IsFourOfAKind(cards)) return "Kareta";
        if (IsFullHouse(cards)) return "Full";
        if (IsFlush(cards)) return "Kolor";
        if (IsStraight(cards)) return "Strit";
        if (IsThreeOfAKind(cards)) return "Trójka";
        if (IsTwoPair(cards)) return "Dwie pary";
        if (IsOnePair(cards)) return "Para";
        return "Brak układu";
    }

    private static bool IsRoyalFlush(List<Card> cards)
    {
        return IsStraightFlush(cards) && cards.Any(card => card.Value == "A");
    }

    private static bool IsStraightFlush(List<Card> cards)
    {
        return IsFlush(cards) && IsStraight(cards);
    }

    private static bool IsFourOfAKind(List<Card> cards)
    {
        return cards.GroupBy(card => card.Value).Any(group => group.Count() == 4);
    }

    private static bool IsFullHouse(List<Card> cards)
    {
        var groups = cards.GroupBy(card => card.Value).ToList();
        return groups.Count == 2 && groups.Any(group => group.Count() == 3);
    }

    private static bool IsFlush(List<Card> cards)
    {
        return cards.GroupBy(card => card.Color).Any(group => group.Count() == 5);
    }

    private static bool IsStraight(List<Card> cards)
    {
        var cardValues = cards.Select(card => CardValues[card.Value]).OrderBy(value => value).ToList();
        for (int i = 0; i < cardValues.Count - 1; i++)
        {
            if (cardValues[i] + 1 != cardValues[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    private static bool IsThreeOfAKind(List<Card> cards)
    {
        return cards.GroupBy(card => card.Value).Any(group => group.Count() == 3);
    }

    private static bool IsTwoPair(List<Card> cards)
    {
        return cards.GroupBy(card => card.Value).Count(group => group.Count() == 2) == 2;
    }

    private static bool IsOnePair(List<Card> cards)
    {
        return cards.GroupBy(card => card.Value).Any(group => group.Count() == 2);
    }
}