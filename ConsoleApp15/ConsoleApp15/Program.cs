using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{

    internal class Program
    {
        static void Beacon(Terran terran)
        {
            terran.Recovery();
        }

        static void Main(string[] args)
        {
            //Github Pull
            
            Marine marine = new Marine();
            Firebet firebet = new Firebet();
            Ghost ghost = new Ghost();

            marine.Health -= 10;
            firebet.Health -= 10;
            ghost.Health -= 10;

            Beacon(marine);
            Beacon(firebet);
            Beacon(ghost);
        }
    }
}
