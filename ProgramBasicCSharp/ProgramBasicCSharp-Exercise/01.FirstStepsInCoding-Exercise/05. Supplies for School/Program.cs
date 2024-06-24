//prices
double pricePerPen = 5.80;
double pricePerMarker = 7.20;
double priceForSolutionPerLiter = 1.20;


//input
int countOfPens = int.Parse(Console.ReadLine());
int countOfMarkers = int.Parse(Console.ReadLine());
int litresSolution = int.Parse(Console.ReadLine());
int discountPercent = int.Parse(Console.ReadLine());

//Calculation

double totalPriceForPens  = countOfPens *  pricePerPen;
double totalPriceForMarkers = countOfMarkers * pricePerMarker;
double totalPriceForSolution = litresSolution * priceForSolutionPerLiter;
double totalPriceForAllWithoutDiscount = totalPriceForPens + totalPriceForMarkers + totalPriceForSolution;
double discount = totalPriceForAllWithoutDiscount * discountPercent / 100;
double finalPrice = totalPriceForAllWithoutDiscount - discount;

//output
Console.WriteLine(finalPrice);