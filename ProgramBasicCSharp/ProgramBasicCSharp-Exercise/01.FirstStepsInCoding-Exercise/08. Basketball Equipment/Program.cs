//input
int priceForTrainingYearly = int.Parse(Console.ReadLine());

//calculations
double priceForSneakers = priceForTrainingYearly - (priceForTrainingYearly * 0.4);
double priceForJerseyKit = priceForSneakers - (priceForSneakers * 0.2);
double priceForBall = priceForJerseyKit / 4.0;
double priceForAccessories = priceForBall / 5.0;
double priceForEquipment = priceForTrainingYearly + priceForSneakers + priceForJerseyKit + priceForBall + priceForAccessories;

//output
Console.WriteLine(priceForEquipment);

Console.WriteLine("Hello SoftUni");