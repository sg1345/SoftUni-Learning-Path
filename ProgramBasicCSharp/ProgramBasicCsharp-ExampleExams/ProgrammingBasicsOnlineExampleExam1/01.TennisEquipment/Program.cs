
//input
int priceTennisRacket = int.Parse(Console.ReadLine());
int countTennisRacket = int.Parse(Console.ReadLine());
int countSneakers = int.Parse(Console.ReadLine());

//calculations
double totalPriceTennisRackets = (double)priceTennisRacket * countTennisRacket;
double priceSneakets = (double)priceTennisRacket / 6;
double totalSneakers = (double)countSneakers * priceSneakets;
double totalOtherEquipment = (totalPriceTennisRackets + totalSneakers) * 0.2;
double totalPriceAllEquipment = totalPriceTennisRackets + totalSneakers + totalOtherEquipment;

double jokovicPaying = totalPriceAllEquipment / 8;
double sponsorsPaying = totalPriceAllEquipment * 7 / 8;


 
jokovicPaying = Math.Floor(jokovicPaying);
sponsorsPaying = Math.Ceiling(sponsorsPaying);


//output
Console.WriteLine($"Price to be paid by Djokovic {jokovicPaying}");
Console.WriteLine($"Price to be paid by sponsors {sponsorsPaying}");
