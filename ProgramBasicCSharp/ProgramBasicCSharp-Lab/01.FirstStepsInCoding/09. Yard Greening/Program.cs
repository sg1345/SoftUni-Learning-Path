double area = double.Parse(Console.ReadLine());

double price = area * 7.61;
double discount = 0.18 * price;
double total = price-discount;

Console.WriteLine($"The final price is : {total} lv.");
Console.WriteLine($"The discount is: {discount} lv.");
