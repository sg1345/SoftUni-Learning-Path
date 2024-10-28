using System.Collections.Generic;

internal class Program
{
    static void Main()
    {
        List<string> deck = Console.ReadLine()
            .Split(':', StringSplitOptions.RemoveEmptyEntries)
            .Select(s => s.Trim())
            .ToList();

        List<string> newDeck = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "Ready")
        {
            string[] command = input.Split();

            switch (command[0])
            {
                case "Add":
                    AddToNewDeck(deck, newDeck, command[1]);
                    break;

                case "Insert":
                    InsertCardToTheNewDeck(deck, newDeck, command[1], int.Parse(command[2]));
                    break;

                case "Remove":
                    RemoveCardFromTheNewDeck(newDeck, command[1]);
                    break;

                case "Swap":
                    SwapCardInTheNewDeck(newDeck, command[1], command[2]);
                    break;

                case "Shuffle":
                    ReverseCardInTheNewDeck(newDeck);
                    break;
            }
        }

        Console.WriteLine(string.Join(' ',newDeck));
    }

    static void AddToNewDeck(List<string> deck, List<string> newDeck, string cardName)
    {
        if (deck.Find(card => card == cardName) != cardName)
        {
            Console.WriteLine("Card not found.");
            return;
        }
        newDeck.Add(cardName);
    }

    static void InsertCardToTheNewDeck(List<string> deck, List<string> newDeck, string cardName, int index)
    {
        if (deck.Find(card => card == cardName) != cardName || (index > deck.Count - 1 || index < 0))
        {
            Console.WriteLine("Error!");
            return;
        }
        newDeck.Insert(index, cardName);
    }

    static void RemoveCardFromTheNewDeck(List<string> newDeck, string cardName)
    {
        if (newDeck.Find(card => card == cardName) == cardName)
        {
            newDeck.Remove(cardName);
            return;
        }
        Console.WriteLine("Card not found.");
    }

    static void SwapCardInTheNewDeck(List<string> newDeck, string cardName1, string cardName2)
    {
        int indexCard1 = newDeck.IndexOf(cardName1);
        int indexCard2 = newDeck.IndexOf(cardName2);
        newDeck.Remove(cardName1);
        newDeck.Insert(indexCard1, cardName2);
        newDeck.Remove(cardName2);
        newDeck.Insert(indexCard2, cardName1);
    }

    static void ReverseCardInTheNewDeck(List<string> newDeck)
    {
        newDeck.Reverse();
    }
}