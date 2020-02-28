using System.Threading;
using System;

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



    class Terminal : IInsertIntoFreeSpace<Bag>
    {
        readonly object _lock = new object();

        public event EventHandler planeLanded;
        public event EventHandler planeTakenOff;
        public event EventHandler notEnoughSpaceOnThePlane;

        private uint terminalID;

        public uint TerminalID
        {
            get { return terminalID; }
            set { terminalID = value; }
        }


        private Destination flyDestination;

        public Destination FlyDestination
        {
            get { return flyDestination; }
            set
            {
                flyDestination = value;

                planeLanded?.Invoke("Plane landed with destination " + value + 
                                    " at terminal " + TerminalID, new EventArgs());
            }
        }

        Plane plane;

        public void LoadOnPlane(Bag bag)
        {
            InsertInFreeSpace(bag);
        }

        public Terminal()
        {
            plane = new Plane();
            FlyDestination = plane.PlaneDestination;

            // Start Thread to refresh plane
            Thread terminalThread = new Thread(GetANewPlane);
            terminalThread.Start();
        }

        void GetANewPlane()
        {
            while (true)
            {
                lock (_lock)
                {
                    Thread.Sleep(new Random(Guid.NewGuid().GetHashCode()).Next(10000,35000));
                    int amountOfBagsInPlane = plane.BagsInPlane.Length - plane.GetAvaibleSpaceInBuffer();

                    planeTakenOff?.Invoke("Plane to " + plane.PlaneDestination + 
                                         " Deperated from Terminal " + TerminalID +
                                         " with " + amountOfBagsInPlane + " bags", new EventArgs());

                    plane = new Plane();
                    FlyDestination = plane.PlaneDestination;
                }
            }

        }


        public uint InsertInFreeSpace(Bag bag)
        {
            int temp = plane.GetAvaibleSpaceInBuffer();

            if (temp == 0)
            {
                notEnoughSpaceOnThePlane?.Invoke("Not Enoug space item will be transfered to waiting area", new EventArgs());
                AirportManager.getInstance().WaitingArea.WaitingAreaBags.Add(bag);
                return 0;
            }

            for (uint i = 0; i < plane.BagsInPlane.Length; i++)
            {
                if (plane.BagsInPlane[i] == null)
                {
                    plane.BagsInPlane[i] = bag;
                    return i;
                }
            }
            return 0;
        }
    }
}
