
double change = double.Parse(Console.ReadLine());

int changeInCoins = (int)(change * 100);
int countCoins = 0;

while (changeInCoins != 0)
{
  
    if (changeInCoins >= 200)
    {
        changeInCoins -= 200;
        countCoins++;
    }
    else if(changeInCoins >= 100)
    {
        changeInCoins -= 100;
        countCoins++;
    }
    else if (changeInCoins >= 50)
    {
        changeInCoins -= 50;
        countCoins++;
    }
    else if (changeInCoins >= 20)
    {
        changeInCoins -= 20;
        countCoins++;
    }
    else if (changeInCoins >= 10)
    {
        changeInCoins -=10;
        countCoins++;
    }
    else if (changeInCoins >= 5)
    {
        changeInCoins -=5;
        countCoins++;
    }
    else if (changeInCoins >= 2)
    {
        changeInCoins -=2;
        countCoins++;
    }
    else if (changeInCoins >= 1)
    {
        changeInCoins -=1;
        countCoins++;
    }
}
Console.WriteLine(countCoins);