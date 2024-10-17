using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string Name { get; set; }
    public Item(string name)

    { this.Name = name; }
}

// FoodItem class
public class FoodItem : Item
{
    public int Health { get; set; }
    public FoodItem(string name, int health) : base(name)
    { this.Health = health; }
}

// Weapon class
public class Weapon : Item
{
    public int Damage { get; set; }
    public Weapon (string name, int damage) : base(name) 
    { this.Damage = damage; }
}

// Potion class
public class Potion : Item
{
    public string Effect { get; set; }
    public Potion(string  name, string effect) : base(name)
    { this.Effect = effect; }
}

// Goldcoin class
public class GoldCoin : Item
{
    public int Value { get; set; }
    public GoldCoin(int  value) : base("Gold Coin")
    { this.Value = value; }
}

//public class Item : MonoBehaviour
//{
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    //void Update()
    //{
        
    //}
//}
