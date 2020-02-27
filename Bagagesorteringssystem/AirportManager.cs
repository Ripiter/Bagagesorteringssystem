using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    static class AirportManager
    {
        // Maybe array of terminals?
        public static Dictionary<Destination, uint> avaibleTerminals = new Dictionary<Destination, uint>();


        public static void CloseTerminal(uint id)
        {
            // closes terminal by id
        }

        public static void CloseTerminal(Destination destination)
        {
            // closes terminal by destination
        }

        public static void ChangeDestination(Destination destination, uint onID)
        {
            // change destination on id
        }

        public static void AddTerminal(Terminal terminal)
        {
            avaibleTerminals.Add(terminal.FlyDesination, terminal.TerminalID);
        }


        public static Destination GetDestinationFromId(uint id)
        {
            throw new NotImplementedException();
        }

        public static uint GetIdFromDestination(Destination destination)
        {
            throw new NotImplementedException();
        }
        


        public static void GenerateTerminals()
        {
            //int x = Enum.GetNames(typeof(Destination)).Length;
            //Array a = Enum.GetValues(typeof(Destination));
            //uint temp = 1;

            //for (int i = 0; i < x; i++)
            //{
            //    places.Add((Destination)a.GetValue(i), temp);
            //    if (temp == 3)
            //        temp = 0;

            //    temp++;
            //}
        }
    }
}
