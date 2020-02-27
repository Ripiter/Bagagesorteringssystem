using System;

namespace Bagagesorteringssystem
{
    class AirportManager : IInsertIntoFreeSpace<Terminal>
    {
        private static AirportManager instance;
        static readonly object _lock = new object();

        private AirportManager()
        {

        }

        public static AirportManager getInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                    instance = new AirportManager();

                return instance;
            }
        }


        // Maybe array of terminals?
        public Terminal[] terminals = new Terminal[3];


        public void CloseTerminal(uint id)
        {
            // closes terminal by id
        }

        public void CloseTerminal(Destination destination)
        {
            // closes terminal by destination
        }

        public void ChangeDestination(Destination destination, uint onID)
        {
            // change destination on id
        }

        public void AddTerminal(Terminal terminal)
        {
            uint pos = InsertInFreeSpace(terminal);
            terminal.TerminalID = pos;
        }


        public Terminal GetTerminalFromId(uint id)
        {
            Terminal temp = null;

            for (int i = 0; i < terminals.Length; i++)
            {
                if(terminals[i] != null)
                {
                    if (terminals[i].TerminalID == id)
                        temp = terminals[i];
                }
            }
            return temp;
        }

        public Terminal GetTerminalFromDestination(Destination destination)
        {
            Terminal temp = null;

            for (int i = 0; i < terminals.Length; i++)
            {
                if (terminals[i] != null)
                {
                    if (terminals[i].FlyDesination == destination)
                        temp = terminals[i];
                }
            }
            return temp;
        }



        //public static void GenerateTerminals()
        //{
        //    int x = Enum.GetNames(typeof(Destination)).Length;
        //    Array a = Enum.GetValues(typeof(Destination));
        //    uint temp = 1;

        //    for (int i = 0; i < x; i++)
        //    {
        //        places.Add((Destination)a.GetValue(i), temp);
        //        if (temp == 3)
        //            temp = 0;

        //        temp++;
        //    }
        //}

        public uint InsertInFreeSpace(Terminal terminal)
        {
            for (uint i = 0; i < terminals.Length; i++)
            {
                if (terminals[i] == null)
                {
                    terminals[i] = terminal;
                    return i;
                }
            }
            return 0;
        }
    }
}

