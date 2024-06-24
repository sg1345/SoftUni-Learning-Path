double deposit = double.Parse(Console.ReadLine());
int periodOfDeposit = int.Parse(Console.ReadLine());
double yearInterestPercent  = double.Parse(Console.ReadLine());

double yearInterest = deposit * yearInterestPercent / 100;
double monthInterest = yearInterest / 12;
double totalIncome = deposit + periodOfDeposit * monthInterest;

Console.WriteLine(totalIncome);