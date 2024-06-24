// input taa plashta samo 5% dds we bace
int magnolias = int.Parse(Console.ReadLine());
int hyacinth  = int.Parse(Console.ReadLine()); // това е Зюмбюл
int roses = int.Parse(Console.ReadLine());
int cactus  = int.Parse(Console.ReadLine());
double giftPrice = double.Parse(Console.ReadLine());

//calculations
/*
 * Магнолиа - 3.25лв.
 * Зюмбюл - 4 лв.
 * Роза - 3.50лв.
 * Кактус - 8лв.
 * 5% ДДС майна
 */
double moneyEarned = (magnolias * 3.25 + hyacinth * 4 + roses * 3.50 + cactus * 8) * 0.95;
double difference = Math.Abs(moneyEarned - giftPrice);

//output
if (moneyEarned >= giftPrice)
{
    Console.WriteLine($"She is left with {Math.Floor(difference)} leva.");
}
else
{
    Console.WriteLine($"She will have to borrow {Math.Ceiling(difference)} leva.");
}