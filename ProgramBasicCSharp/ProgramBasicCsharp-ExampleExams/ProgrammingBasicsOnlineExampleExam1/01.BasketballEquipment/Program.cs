
//input
int annualFee = int.Parse(Console.ReadLine());

//calculations
double sneakers = annualFee * 0.60;
double trainingClothes = sneakers * 0.80;
double ball = trainingClothes / 4;
double equipment = ball / 5;

double finalPrice = annualFee + sneakers + trainingClothes + ball + equipment;

//output

Console.WriteLine($"{finalPrice:F2}");