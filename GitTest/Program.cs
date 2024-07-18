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


    internal class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player() { Name = "용사", level = 1; };   
            
        }
    }
}
