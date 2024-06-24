
//Тестова методидка
//int num = int.Parse(Console.ReadLine());

//int a1 = num % 10 / 1;
//int a2 = num % 100 / 10;
//int a3 = num % 1000 / 100;
//int a4 = num % 10000 / 1000;
//int a5 = num % 100000 / 10000;
//int a6 = num % 1000000 / 100000;

//Console.WriteLine(a1);
//Console.WriteLine(a2);
//Console.WriteLine(a3);
//Console.WriteLine(a4);
//Console.WriteLine(a5);
//Console.WriteLine(a6);


// моеро решение да задачата
//int firstNumber = int.Parse(Console.ReadLine());
//int secondNumber = int.Parse(Console.ReadLine());

//for (int i = firstNumber; i <= secondNumber; i++)
//{
//    int odd1  = i % 10 / 1;  
//    int even1 = i % 100 / 10;
//    int odd2  = i % 1_000 / 100;
//    int even2 = i % 10_000 / 1_000;
//    int odd3  = i % 100_000 / 10_000;
//    int even3 = i % 1_000_000 / 100_000;

//    int sumOdd = odd1 + odd2 + odd3;
//    int sumEven = even1 + even2 + even3;

//    if (sumOdd == sumEven)
//    {
//        Console.Write(i + " ");
//    }

//}

//примерно решение по задание
int firstNumber = int.Parse(Console.ReadLine());
int secondNumber = int.Parse(Console.ReadLine());

for (int i = firstNumber;  i <= secondNumber; i++)
{
    string currentNumber = i.ToString();
    int sumOdd = 0;
    int sumEven = 0;

    for (int j = 0; j < currentNumber.Length; j++)
    {
        int currentDigit = int.Parse(currentNumber[j].ToString());

        if (j % 2 == 0)
        {
            sumEven += currentDigit;
        }
        else
        {
            sumOdd += currentDigit;
        }
    }
    if (sumOdd == sumEven)
    {
        Console.Write(i + " ");
    }
}