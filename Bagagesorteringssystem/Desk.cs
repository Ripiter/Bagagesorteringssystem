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
            bag.BagID = (uint)Guid.NewGuid().GetHashCode();

            Sorter.getInstance().InsertInFreeSpace(bag);
        }
    }
}
