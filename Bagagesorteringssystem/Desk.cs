using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class Desk
    {
        /// <summary>
        /// Inserts bag into sorter and gives the bad unique bagId
        /// </summary>
        /// <param name="bag"></param>
        public void InsertIntoSorter(Bag bag)
        {
            bag.BagID = (uint)Guid.NewGuid().GetHashCode();

            Sorter.getInstance().InsertInFreeSpace(bag);
        }
    }
}
