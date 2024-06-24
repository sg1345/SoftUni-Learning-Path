double vegetablesPerKilogram = double.Parse(Console.ReadLine());
double fruitsPerKilogram = double.Parse(Console.ReadLine());
double weightOfVegetables = double.Parse(Console.ReadLine());
double weightOfFruits = double.Parse(Console.ReadLine());

double totalVegetablesInLeva = vegetablesPerKilogram * weightOfVegetables;
double totalFruitsInLeva = fruitsPerKilogram * weightOfFruits;
double totalInEuro = (totalFruitsInLeva + totalVegetablesInLeva) / 1.94;
Console.WriteLine(totalInEuro.ToString("0.00"));