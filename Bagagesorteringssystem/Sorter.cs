using System;
using System.Collections.Generic;
using System.Threading;

namespace Bagagesorteringssystem
{
    class Sorter
    {
        static readonly object _lock = new object();
        private static Sorter instance;

        Bag[] buffer = new Bag[20];

        private List<Bag> waitingArea = new List<Bag>();

        public List<Bag> WaitingArea
        {
            get { return waitingArea; }
            set { waitingArea = value; }
        }

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

        public int GetAvaibleSpaceInBuffer()
        {
            int temp = 0;

            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == null)
                    temp++;
            }
            return temp;
        }

        int GetSpaceTakenInBuffer()
        {
            int temp = 0;

            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] != null)
                    temp++;
            }

            return temp;
        }


        /// <summary>
        /// Returns bag array inside buffer and all bags in waiting area
        /// </summary>
        /// <returns></returns>
        public Bag[] GetAvaibleBags()
        {
            List<Bag> temp = new List<Bag>(AirportManager.getInstance().WaitingArea.WaitingAreaBags);

            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] != null)
                    temp.Add(buffer[i]);
            }
            
            return temp.ToArray();
        }



        public void Sort()
        {
            while (true)
            {
                lock (_lock)
                {
                    for (int i = 0; i < GetAvaibleBags().Length; i++)
                    {
                        // Sorts
                        Thread.Sleep(100);
                        
                        // Go thru all items in sorter buffer
                        for (int j = 0; j < buffer.Length; j++)
                        {
                            SortBuffer(j);
                        }

                        for (int k = 0; k < AirportManager.getInstance().WaitingArea.WaitingAreaBags.Count; k++)
                        {
                            SortWaitingArea(k);
                        }

                    }
                }
            }
        }
        
        void SortBuffer(int j)
        {
            Terminal terminal = null;

            // Check if there is terminal that have the same destination as the bag
            if (buffer[j] != null)
                terminal = AirportManager.getInstance().GetTerminalFromDestination(buffer[j].BagDestination);
            
            // If there is termianl that have the same destination as the bag
            // Send the bag there
            if (terminal != null)
            {
                terminal.LoadOnPlane(buffer[j]);
                buffer[j] = null;
            }
            else
            {
                // Check if the bag is already in the waiting area
                if (!AirportManager.getInstance().WaitingArea.WaitingAreaBags.Contains(buffer[j]))
                {
                    AirportManager.getInstance().WaitingArea.WaitingAreaBags.Add(buffer[j]);
                    buffer[j] = null;

                    Monitor.PulseAll(_lock);
                }
            }
        }


        void SortWaitingArea(int k)
        {
            Terminal terminal = null;

            List<Bag> waiting = AirportManager.getInstance().WaitingArea.WaitingAreaBags;

            // Check if there is terminal that have the same destination as the bag
            if (waiting[k] != null)
                terminal = AirportManager.getInstance().GetTerminalFromDestination(waiting[k].BagDestination);

            // If there is termianl that have the same destination as the bag
            // Send the bag there
            if (terminal != null)
            {
                terminal.LoadOnPlane(waiting[k]);
                waiting.Remove(waiting[k]);
            }
            else
            {
                // Check if the bag is already in the waiting area
                if (!AirportManager.getInstance().WaitingArea.WaitingAreaBags.Contains(waiting[k]))
                {
                    AirportManager.getInstance().WaitingArea.WaitingAreaBags.Add(waiting[k]);

                    Monitor.PulseAll(_lock);
                }
            }
        }

    }
}
