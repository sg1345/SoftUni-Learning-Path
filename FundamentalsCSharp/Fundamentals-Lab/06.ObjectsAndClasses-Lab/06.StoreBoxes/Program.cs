internal class Program
{
    static void Main()
    {
        List<Box> itemList = new();

        string input = string.Empty;
        while ((input = Console.ReadLine()) != "end")
        {
            string[] info = input.Split();

            Item newItem = new();
            newItem.Name = info[1];
            newItem.Price = decimal.Parse(info[3]);

            Box newBox = new();
            newBox.SerialNumber = info[0];
            newBox.Item = newItem;
            newBox.Quantity = int.Parse(info[2]);
            newBox.Price = newBox.Quantity * newItem.Price;

            itemList.Add(newBox);
        }

        itemList = itemList.OrderByDescending(x => x.Price).ToList();

        foreach (Box box in itemList)
        {
            Console.WriteLine($"{box.SerialNumber}");
            Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
            Console.WriteLine($"-- ${box.Price:f2}");
        }
    }
}

class Item
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

class Box
{
    public string SerialNumber { get; set; }
    public Item Item { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}