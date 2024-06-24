//prices
double chickenMenu = 10.35;
double fishMenu = 12.40;
double vegetarianMenu = 8.15;
double delivery = 2.50;

//input
int countChickenMenus = int.Parse(Console.ReadLine());
int countFishMenus = int.Parse(Console.ReadLine());
int countVegetarianMenus = int.Parse(Console.ReadLine());

//calculations
double totalChickenMenus = countChickenMenus * chickenMenu;
double totalFishMenus = countFishMenus * fishMenu;
double totalVegetarianMenus = countVegetarianMenus * vegetarianMenu;
double totalPrice = totalChickenMenus + totalFishMenus + totalVegetarianMenus;
double priceForDesert = totalPrice * 0.2;
double finalPrice = totalPrice + priceForDesert + delivery;

//output
Console.WriteLine(finalPrice);