namespace Weapon {
    public class Weapon
    {
        public string Name { get; private set; }
        public int Cost { get; private set; }

        public Weapon (string name, int cost )
        {
            Name = name;
            Cost = cost;
        }
    }
}

public class PlayerWeapon 
{
    // player starts with 100 coins
    public int coins = 100;

    // player's inventory of weapons
    public List<string> inventory = new List<string>(); 

    void Start () 
    {
        // player enters store
        EnterStore();
    }

    public void EnterStore()
    {
        Console.WriteLine("Player has entered the store");
        DisplayWeapons();
    }

    public void DisplayWeapons()
    {
        Console.WriteLine("Weapons available for purchase: Sword (50 coins), Dagger (30 coins), Magic Sword (70 coins)");

        PurchaseWeapon("Magic Sword");
    }

    void PurchaseWeapon(string weapon)
    {
        // check if player wants to purchase a weapon
        if (PlayerWantsToPurchase())
        {
            DeductCoinsAndPurchaseWeapon(weapon);
        }
        else
        {
            Console.WriteLine("Player is not purchasing any weapon.");
        }
    }

    bool PlayerWantsToPurchase()
    {
        // assume player wants to purchase a weapon
        return true;
    }

    void DeductCoinsAndPurchaseWeapon(string weapon)
    {
        int cost = 0;

        // determine the cost based on the weapon
        switch (weapon)
        {
            case "Sword":
                cost = 50;
                break;
            case "Dagger":
                cost = 30;
                break;
            case "Magic Sword":
                cost = 70;
                break;
            default: 
                Console.WriteLine("Unknown weapon selected");
            return;
        }

        // check if players have enough coins to purchase weapon
        if (coins >= cost)
        {
            coins -= cost;
            inventory.Add(weapon);
            Console.WriteLine($"{weapon} purchased for {cost} coins. Remaining coins: {coins}.");
            UpdateInventory(weapon);        
        }
        else
        {
            Console.WriteLine("Not enough coins to purchase this weapon");
        }
    }

    void UpdateInventory(string weapon)
    {
        // update players inventory
        Console.WriteLine($"Weapon added to inventory: {weapon}");
    }
}

