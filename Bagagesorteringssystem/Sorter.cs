using System.Collections.Generic;


namespace Bagagesorteringssystem
{
    class Sorter
    {
        static readonly object _lock = new object();
        private static Sorter instance;

        private Sorter()
        {

        }

        public static Sorter getInstance()
        {
            lock (_lock)
            {
                if (instance == null)
                    instance = new Sorter();

                return instance;
            }
        }

        Bag[] buffer = new Bag[20];

        /// <summary>
        /// Insert into array of your choosing
        /// </summary>
        /// <param name="bufferArray"></param>
        /// <param name="bag"></param>
        public void InsertInFreeSpace(Bag[] bufferArray, Bag bag)
        {
            for (int i = 0; i < bufferArray.Length; i++)
            {
                if (bufferArray[i] == null)
                {
                    bufferArray[i] = bag;
                    return;
                }
            }
        }

        /// <summary>
        /// Insert into sorter buffer 
        /// </summary>
        /// <param name="bag"></param>
        public void InsertInFreeSpace(Bag bag)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == null)
                {
                    buffer[i] = bag;
                    return;
                }
            }
        }

        void RemoveAllBagsOfType(Destination destination)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i].BagDestination == destination)
                    buffer[i] = null;
            }
        }


        public Bag[] GetBags(Destination destination)
        {
            List<Bag> temp = new List<Bag>();

            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i].BagDestination == destination)
                    temp.Add(buffer[i]);
            }

            RemoveAllBagsOfType(destination);

            return temp.ToArray();
        }
    }
}
