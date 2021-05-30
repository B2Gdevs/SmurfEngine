using SmurfEngine.Items;

namespace SmurfEngine.Characters
{
    public class Player : Character
    {
        public Player(string name, int health, Inventory inventory) : base(name, health, inventory)
        {
            this.Name = name;
            this.Health = health;
            this.Inventory = inventory;
        }
    }
}