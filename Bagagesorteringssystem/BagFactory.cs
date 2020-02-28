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

        /// <summary>
        /// Creates and returns bag with random destination
        /// </summary>
        /// <returns></returns>
        public Bag CreateBag()
        {
            Bag bag = new Bag(GetRandomDestination());

            return bag;
        }

        /// <summary>
        /// Creates and returns bag with destination parameter
        /// </summary>
        /// <param name="destination"></param>
        /// <returns></returns>
        public Bag CreateBag(Destination destination)
        {
            Bag bag = new Bag(destination);

            return bag;
        }
    }
}
