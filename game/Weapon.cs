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

