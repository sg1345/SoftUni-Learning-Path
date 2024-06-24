
int countPages = int.Parse(Console.ReadLine());
int salary = int.Parse(Console.ReadLine());

bool isValid = false;

for (int i = 0; i < countPages; i++)
{
    string pages = Console.ReadLine();
    
    switch (pages)
    {
        case "Facebook":
            salary -= 150;
            break;
        case "Instagram":
            salary -= 100;
            break;
        case "Reddit":
            salary -= 50;
            break;
    }

    if (salary <= 0)
    {
        isValid = true;
        Console.WriteLine("You have lost your salary.");
        break;
    }
}
if (isValid != true)
{
Console.WriteLine(salary);
}