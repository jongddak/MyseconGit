using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitTest
{
    struct Player {

        public string Name;
        public int level;
    
    }
    struct Monster
    {

        public string Name;
        public int hp;

    }


    struct Item 
    {
        public string Name;
        public int Equipmentlevel;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player() { Name = "용사", level = 1 };
            Monster monster = new Monster() { Name = "슬라임", hp = 1 };
            Item item = new Item() { Name = "검", Equipmentlevel = 1 };
            Item item = new Item() { Name = "방패", Equipmentlevel = 1 };
        }
    }
}
