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

public class Player 
{
    // set initial palyer health to 0
    public int health = 0;

    void Start ()
    {
        // process begins when player encounters food
        EncounterFood();
    }

    public void EncounterFood()
    {
        // throw an exception if no food is encountered
        bool noFoodItems = false;

        if (noFoodItems) 
        {
            throw new InvalidOperationException("No food items available for the player to encounter.");
        }

        // else, method to generate and apply random food item
        GenerateFoodItem();
    }

    private void GenerateFoodItem()
    {        
        // array of food options with corresponding health values
        FoodItem[] foodItems = {
            new FoodItem("Apple", 25),
            new FoodItem("Watermelon", 10),
            new FoodItem("Pineapple", 100),
            new FoodItem("Strawberry", 50)

        };

        // select a food item randomly
        Random random = new Random();
        int randomIndex = random.Next(foodItems.Length);
        FoodItem selectedFood = foodItems[randomIndex];


        Console.WriteLine($"Player found: {selectedFood.Name}, Health: {selectedFood.Health}");
    }
}

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
