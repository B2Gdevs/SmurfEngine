using SmurfEngine.Items;
using SmurfEngine.UI;
using System;

namespace SmurfEngine.Characters
{
    public class Player : Character
    {
        public Player(string name, int health, Inventory inventory) : base(name, health, inventory){}
    }
}