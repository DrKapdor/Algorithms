using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public interface IComparator<T>
    {
        public int Compare(T a, T b);
    }
}
