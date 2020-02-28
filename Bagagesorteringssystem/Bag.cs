using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class Bag
    {
        private Destination bagDestination;

        public Destination BagDestination
        {
            get { return bagDestination; }
            set { bagDestination = value; }
        }


        private uint bagID;

        public uint BagID
        {
            get { return bagID; }
            set { bagID = value; }
        }


        public Bag(Destination destination)
        {
            this.BagDestination = destination;
        }

    }
}
