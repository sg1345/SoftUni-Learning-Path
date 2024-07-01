var text = "";

var sum = 0;
while ((text = Console.ReadLine()) != "End")
{
    for (int i = 0; i < text.Length; i++)
    {
        sum += text[i];
    }
    Console.WriteLine(sum);
    sum = 0;
}
//Console.WriteLine(Math.Pow(1/500,100));
