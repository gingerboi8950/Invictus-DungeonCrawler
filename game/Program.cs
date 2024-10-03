using System;

public class FoodItem
{
    public string Name { get; set; }
    public int Health { get; set; }

    public FoodItem(string name, int health)
    {
        Name = name;
        Health = health;
    }
}

class Program
{
    static void Main(string[] args)
    {
        FoodItem apple = new FoodItem("Apple", 10);
        Console.WriteLine($"Food: {apple.Name}, Health: {apple.Health}");
    }
}
