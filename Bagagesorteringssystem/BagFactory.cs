using System;

namespace Bagagesorteringssystem
{
    class BagFactory : IReturnRandomDestination
    {
        public Destination GetRandomDestination()
        {
            Array temp = Enum.GetValues(typeof(Destination));

            // Generates random destination from destination enum
            return (Destination)temp.GetValue(new Random(Guid.NewGuid().GetHashCode()).Next(0, temp.Length));
        }


        public Bag CreateBag()
        {
            Bag bag = new Bag(GetRandomDestination());

            return bag;
        }
    }
}
