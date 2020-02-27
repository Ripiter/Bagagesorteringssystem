using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class Desk
    {
        public void InsertIntoSorter(Bag bag)
        {
            // Set bag desination
            // get info of destination from terminal



            Sorter.getInstance().InsertInFreeSpace(bag);
        }
    }
}
