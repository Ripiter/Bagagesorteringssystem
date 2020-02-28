using System;
using System.Threading;

namespace Bagagesorteringssystem
{
    class Program
    {
        static Desk desk = new Desk();
        static BagFactory bagFactory = new BagFactory();
        static readonly object _lock = new object();


        static void Main(string[] args)
        {
            Terminal t1 = new Terminal();
            Terminal t2 = new Terminal();
            Terminal t3 = new Terminal();

            AirportManager.getInstance().AddTerminal(t1);
            AirportManager.getInstance().AddTerminal(t2);
            AirportManager.getInstance().AddTerminal(t3);

            Console.WriteLine("Termial " + t1.TerminalID + " starts with destination " + t1.FlyDestination);
            Console.WriteLine("Termial " + t2.TerminalID + " starts with destination " + t2.FlyDestination);
            Console.WriteLine("Termial " + t3.TerminalID + " starts with destination " + t3.FlyDestination);

            Terminal[] temp = AirportManager.getInstance().GetAvaibleTerminals();

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i].planeLanded += PrintMessage;
                temp[i].planeTakenOff += PrintMessage;
                temp[i].notEnoughSpaceOnThePlane += PrintMessage;
            }
            
            Thread deskThread = new Thread(AddBagsToDesk);
            Thread sortThread = new Thread(Sorter.getInstance().Sort);

            deskThread.Start();
            sortThread.Start();


            Console.ReadKey();
        }

        private static void PrintMessage(object sender, EventArgs e)
        {
            string msg = (string)sender;

            Console.WriteLine(msg);
        }


        static void AddBagsToDesk()
        {
            while (true)
            {
                lock (_lock)
                {
                    if (Sorter.getInstance().GetAvaibleSpaceInBuffer() != 0)
                        desk.InsertIntoSorter(bagFactory.CreateBag());
                    
                    Thread.Sleep(150);
                }
            }
        }
    }
}
