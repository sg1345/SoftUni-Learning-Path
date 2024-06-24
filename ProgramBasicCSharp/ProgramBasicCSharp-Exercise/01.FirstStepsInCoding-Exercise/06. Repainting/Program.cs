//prices
double protectivePlasticPerMeter = 1.50;
double paintPerLiter = 14.50;
double diluentPerLiter = 5.00;
double plasticBags = 0.40;

//input
int neededProtectivePlastic = int.Parse(Console.ReadLine());
int neededPaint = int.Parse(Console.ReadLine());
int neededDiluent = int.Parse(Console.ReadLine());
int neededHours = int.Parse(Console.ReadLine());

//calculations
double extraPaint = (neededPaint * 10.0 / 100) * paintPerLiter;
double extraProtectivePlastic = 2 * protectivePlasticPerMeter;

double totalPriceForProtectivePlastic = neededProtectivePlastic * protectivePlasticPerMeter + extraProtectivePlastic;
double totalPriceForPaint = neededPaint * paintPerLiter + extraPaint;
double totalPriceForDiluent = neededDiluent * diluentPerLiter;
double totalPriceForAllMaterials = totalPriceForProtectivePlastic + totalPriceForPaint + totalPriceForDiluent + plasticBags;

double totalPriceForWorkers = (totalPriceForAllMaterials * 30.0 / 100 )* neededHours;
double finalPrice = totalPriceForAllMaterials + totalPriceForWorkers;

//output
Console.WriteLine(finalPrice);