internal class Program
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        int[] result = new int[number];

        for (int i = 0; i < number; i++)
        {
            string text = Console.ReadLine();


            string Vowels = "auoeiAUOEI";

            for (int j = 0; j < text.Length; j++)
            {
                if (Vowels.Contains(text[j]))
                {
                    result[i] += ((int)text[j] * text.Length);
                }
                else
                {
                    result[i] += ((int)text[j] / text.Length);
                }
            }
        }

        //Array.Sort(result);
        for (int i = result.Length - 1; i >= 1; i--)
        {
            if (result[i] >= result[i - 1]) // 1 >= 2 false
            {
                continue;
            }

            int temp = result[i]; // =1
            result[i] = result[i - 1]; // =2
            result[i - 1] = temp;
            i = result.Length;

        }

        Console.WriteLine(string.Join("\n", result));
    }
}