
class Piece
{
    public Piece(string pieceName, string composer, string key)
    {
        PieceName = pieceName;
        Composer = composer;
        Key = key;
    }

    public string PieceName;
    public string Composer;
    public string Key;

}

internal class Program
{
    private static object stringSplitOptions;

    static void Main()
    {
        int numberOfPieces = int.Parse(Console.ReadLine());

        Dictionary<string,Piece> listOfPieces = new();

        for (int i = 0; i < numberOfPieces; i++)
        {
            string[] newPiece = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            Piece addPiece = new Piece(newPiece[0], newPiece[1], newPiece[2]);
            listOfPieces.Add(addPiece.PieceName, addPiece);
        }

        string input =string.Empty;
        while((input = Console.ReadLine()) != "Stop")
        {
            string[] command = input.Split('|', StringSplitOptions.RemoveEmptyEntries);

            switch (command[0])
            {
                case "Add":

                    if (listOfPieces.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"{command[1]} is already in the collection!");
                        continue;
                    }

                    Piece addPiece = new Piece(command[1], command[2], command[3]);
                    listOfPieces.Add(addPiece.PieceName, addPiece);

                    Console.WriteLine($"{command[1]} by {command[2]} in {command[3]} added to the collection!");
                    break;

                case "Remove":

                    if (!listOfPieces.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
                        continue;
                    }

                    listOfPieces.Remove(command[1]);

                    Console.WriteLine($"Successfully removed {command[1]}!");
                    break;

                case "ChangeKey":

                    if (!listOfPieces.ContainsKey(command[1]))
                    {
                        Console.WriteLine($"Invalid operation! {command[1]} does not exist in the collection.");
                        continue;
                    }

                    listOfPieces[command[1]].Key = command[2];

                    Console.WriteLine($"Changed the key of {command[1]} to {command[2]}!");
                    break;
            }
        }

        foreach (var piece in listOfPieces)
        {
            Console.WriteLine($"{piece.Value.PieceName} -> Composer: {piece.Value.Composer}, Key: {piece.Value.Key}");
        }
    }
}
