using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Desk desk = new Desk();
            Bag bag = new Bag();

            Terminal t1 = new Terminal();
            t1.FlyDesination = Destination.Russia;
            
            AirportManager.getInstance().AddTerminal(t1);

            Terminal t2 = new Terminal();
            t2.FlyDesination = Destination.Japan;

            AirportManager.getInstance().AddTerminal(t2);


            desk.InsertIntoSorter(bag);


            Console.ReadKey();
        }
    }
}
