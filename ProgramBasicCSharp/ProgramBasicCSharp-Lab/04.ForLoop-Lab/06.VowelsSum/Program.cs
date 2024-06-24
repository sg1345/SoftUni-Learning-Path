
string text = Console.ReadLine();

int result = 0;
char letter = ' ';

for (int i = 0; i < text.Length; i++)
{
    letter = text[i];

    if (letter == 'a')
    {
        result++;
    }
    else if(letter == 'e')
    {
        result+=2;
    }
    else if (letter == 'i')
    {
        result+=3;
    }
    else if (letter == 'o')
    {
        result+=4;
    }
    else if(letter == 'u')
    {
        result+=5;
    }
}
Console.WriteLine(result);