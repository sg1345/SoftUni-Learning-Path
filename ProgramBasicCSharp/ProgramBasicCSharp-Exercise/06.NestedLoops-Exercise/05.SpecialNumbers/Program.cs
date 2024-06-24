
int number = int.Parse(Console.ReadLine());

for  (int i = 1111; i <= 9999; i++)
{
    string currentNumber = i.ToString();
    int specialNumberCounter = 0;

    for (int j = 0; j < 4; j++)
    {
        int currentDigit = int.Parse(currentNumber[j].ToString());
        if (currentDigit != 0)
        {

            if (number % currentDigit == 0)
            {
            specialNumberCounter++;
            }
        }
    }
    if (specialNumberCounter == 4)
    {
        Console.Write(i + " ");
    }
}