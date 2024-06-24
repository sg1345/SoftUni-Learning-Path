
int countOrders = int.Parse(Console.ReadLine());

int countWeightVan = 0;
int countWeightTruck = 0;
int countWeightTrain = 0;
int overallWeight = 0;
double overallPrice = 0;

for (int i = 0; i < countOrders; i++)
{
    int weight = int.Parse(Console.ReadLine());

    overallWeight += weight;

    if (weight <= 3)
    {
        overallPrice += 200.00 * weight;
        countWeightVan += weight;
    }
    else if (weight <= 11)
    {
        overallPrice += 175.00 * weight;
        countWeightTruck += weight;
    }
    else
    {
        overallPrice += 120.00 * weight;
        countWeightTrain += weight;
    }
}

Console.WriteLine($"{overallPrice/overallWeight:f2}");
Console.WriteLine($"{100.0*countWeightVan/(countWeightVan + countWeightTruck + countWeightTrain):f2}%");
Console.WriteLine($"{100.0*countWeightTruck/(countWeightVan + countWeightTruck + countWeightTrain):f2}%");
Console.WriteLine($"{100.0*countWeightTrain/(countWeightVan + countWeightTruck + countWeightTrain):f2}%");
