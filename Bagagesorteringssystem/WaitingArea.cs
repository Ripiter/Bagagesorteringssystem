using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    class WaitingArea
    {
        private List<Bag> waitingAreaBags = new List<Bag>();


        public List<Bag> WaitingAreaBags
        {
            get { return waitingAreaBags; }
            set { waitingAreaBags = value; }
        }
    }
}
