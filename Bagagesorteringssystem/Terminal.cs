using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{

    public enum Destination
    {
        Russia,
        Spain,
        Germany,
        India,
        China,
        Japan,
        Denmark,
        Poland,
        Portugal,
        UsOfA,
        Australia,
        Argentina,
        Greece
    }

    

    class Terminal
    {
        private uint terminalID;

        public uint TerminalID
        {
            get { return terminalID; }
            set { terminalID = value; }
        }


        private Destination flyDestination;

        public Destination FlyDesination
        {
            get { return flyDestination; }
            set { flyDestination = value; }
        }


        public void Depart()
        {
            Sorter.getInstance().GetBags(FlyDesination);
        }




    }
}
