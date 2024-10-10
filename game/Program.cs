using FoodItem;
using Weapon;
class Program
{
    static void Main(string[] args)
    {
        Player player = new Player();

        try {
            player.EncounterFood();
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
