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

        void RemoveAllBagsOfType(Destination destination)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i].BagDestination == destination)
                    buffer[i] = null;
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
            Terminal des = null;

            if (buffer[j] != null)
                des = AirportManager.getInstance().GetTerminalFromDestination(buffer[j].BagDestination);
            

            if (des != null)
            {
                des.LoadOnPlane(buffer[j]);
                buffer[j] = null;
            }
            else
            {
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

            if (waiting[k] != null)
                terminal = AirportManager.getInstance().GetTerminalFromDestination(waiting[k].BagDestination);

            if (terminal != null)
            {
                terminal.LoadOnPlane(waiting[k]);
                waiting.Remove(waiting[k]);
            }
            else
            {
                if (!AirportManager.getInstance().WaitingArea.WaitingAreaBags.Contains(waiting[k]))
                {
                    AirportManager.getInstance().WaitingArea.WaitingAreaBags.Add(waiting[k]);
                    waiting.Remove(waiting[k]);

                    Monitor.PulseAll(_lock);
                }
            }
        }

    }
}
