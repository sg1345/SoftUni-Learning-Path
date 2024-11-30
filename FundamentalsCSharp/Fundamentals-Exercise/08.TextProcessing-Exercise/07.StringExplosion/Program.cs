internal class Program
{
    static void Main()
    {
        string text = Console.ReadLine();

        int additionalPower = 0;
        for (int i = 0; i < text.Length; i++)
        {
            if (IsExplosion(text, i))
            {
                int explosion = ((int)text[i + 1] - 48) + additionalPower;

                for (int j = i + 1; j < text.Length; j++)
                {
                    if (IsExplosion(text,j))
                    {
                        additionalPower = explosion;
                        break;
                    }

                    if (explosion != 0)
                    {
                        text = text.Remove(j, 1);
                        j--;
                        explosion--;
                        continue;
                    }

                    additionalPower = 0;
                    break;
                }
            }
        }

        Console.WriteLine(text);
    }

    static bool IsExplosion(string text, int index)
    {
        return text[index] == '>';
    }
}