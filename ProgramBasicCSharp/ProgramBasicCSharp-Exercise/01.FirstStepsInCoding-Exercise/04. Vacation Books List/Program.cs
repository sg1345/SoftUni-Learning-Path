
//input
int numberOfPages = int.Parse(Console.ReadLine());
int pagesPerHour = int.Parse(Console.ReadLine());
int daysForOneBook  = int.Parse(Console.ReadLine());

//calculation
int hourForOneBook = numberOfPages / pagesPerHour;
int daysNeededForOneBook = hourForOneBook / daysForOneBook;

//output
Console.WriteLine(daysNeededForOneBook);
