using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bagagesorteringssystem
{
    interface IInsertIntoFreeSpace<T>
    {
        uint InsertInFreeSpace(T bag);
    }
}
