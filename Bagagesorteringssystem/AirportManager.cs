using System;
using System.Collections.Generic;

namespace Bagagesorteringssystem
{
    class AirportManager : IInsertIntoFreeSpace<Terminal>
    {
        private static AirportManager instance;
        static readonly object _lock = new object();

        private WaitingArea waitingArea = new WaitingArea();
        
        public WaitingArea WaitingArea
        {
            get { return waitingArea; }
            set { waitingArea = value; }
        }


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
            // change destination by id
        }

        /// <summary>
        /// Adds terminal to the array avaible space
        /// Returns 0 if the are no more slots avaible
        /// </summary>
        /// <param name="terminal"></param>
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
                    if (terminals[i].FlyDestination == destination)
                        temp = terminals[i];
                }
            }
            return temp;
        }

        /// <summary>
        /// Returns array with terminals that are not null
        /// </summary>
        /// <returns></returns>
        public Terminal[] GetAvaibleTerminals()
        {
            List<Terminal> temp = new List<Terminal>();

            for (int i = 0; i < terminals.Length; i++)
            {
                if (terminals[i] != null)
                    temp.Add(terminals[i]);
            }

            return temp.ToArray();
        }

        public uint InsertInFreeSpace(Terminal terminal)
        {
            for (uint i = 0; i < terminals.Length; i++)
            {
                if (terminals[i] == null)
                {
                    terminals[i] = terminal;
                    return i += 1;
                }
            }
            return 0;
        }
    }
}

