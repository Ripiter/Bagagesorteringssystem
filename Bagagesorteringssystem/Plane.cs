using System;

namespace Bagagesorteringssystem
{
    class Plane : IReturnRandomDestination
    {
        Bag[] bagsInPlane = new Bag[100];


        public Bag[] BagsInPlane
        {
            get { return bagsInPlane; }
            set { bagsInPlane = value; }
        }


        private Destination planeDestination;

        public Destination PlaneDestination
        {
            get { return planeDestination; }
            set { planeDestination = value; }
        }

        public Plane()
        {
            PlaneDestination = GetRandomDestination();
        }

        public Destination GetRandomDestination()
        {
            Array temp = Enum.GetValues(typeof(Destination));

            // Generates random destination from destination enum
            return (Destination)temp.GetValue(new Random(Guid.NewGuid().GetHashCode()).Next(0, temp.Length));
        }

        public int GetAvaibleSpaceInBuffer()
        {
            int temp = 0;
            for (int i = 0; i < BagsInPlane.Length; i++)
            {
                if (BagsInPlane[i] == null)
                    temp++;
            }

            return temp;
        }
    }
}

