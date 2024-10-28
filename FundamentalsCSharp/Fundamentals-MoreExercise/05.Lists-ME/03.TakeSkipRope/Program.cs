using System.Threading.Tasks.Dataflow;

internal class Program
{
    static void Main()
    {
        string encryptedMessage = Console.ReadLine();

        char[] chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        List<int> numbersList = new();
        List<char> nonNumbersList = new();
        List<int> takeList = new();
        List<int> skipList = new();

        encryptedMessage = SplitNumbersAndNonNumbersAndSplitTakeAndSkipIndexes
            (encryptedMessage, chars, numbersList, takeList, skipList);

        nonNumbersList.AddRange(encryptedMessage);
        List<char> decryptedMessage = new();

        for (int i = 0; i < takeList.Count; i++)
        {
            int take = takeList[i];

            if (take > nonNumbersList.Count)
            {
                take = nonNumbersList.Count;
            }

            decryptedMessage.AddRange(nonNumbersList.GetRange(0, take));
            nonNumbersList.RemoveRange(0, take);

            int skip = skipList[i];

            if (skip > nonNumbersList.Count)
            {
                skip = nonNumbersList.Count;
            }

            nonNumbersList.RemoveRange(0, skip);
        }

        Console.WriteLine(string.Join ("",decryptedMessage));
    }

    private static string SplitNumbersAndNonNumbersAndSplitTakeAndSkipIndexes
        (string message, char[] chars, List<int> numbersList, List<int> takeList, List<int> skipList)
    {
        for (int i = 0; i < message.Length; i++)
        {
            for (int j = 0; j < chars.Length; j++)
            {
                if (message[i] == chars[j])
                {
                    message = message.Remove(i, 1);
                    numbersList.Add(chars[j] - 48);

                    if (numbersList.Count % 2 == 1)
                    {
                        takeList.Add(chars[j] - 48);
                    }
                    else
                    {
                        skipList.Add(chars[j] - 48);
                    }
                    i--;
                    break;
                }
            }
        }

        return message;
    }
}

