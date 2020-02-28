using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class Bag
    {
        private Destination bagTagDestination;

        public Destination BagTagDestination
        {
            get { return bagTagDestination; }
            set { bagTagDestination = value; }
        }


        private uint bagID;

        public uint BagID
        {
            get { return bagID; }
            set { bagID = value; }
        }


        public Bag(Destination destination)
        {
            this.BagTagDestination = destination;
        }

    }
}
