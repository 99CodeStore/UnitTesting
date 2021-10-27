using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fundamentals
{
    public class Math 
    {
        public IEnumerable<int> GetOddNumbers(int limit)
        {
            for (int i = 0; i < limit; i++)
            {
                if (i%2==1)
                {
                    yield return i;
                }
            }
        }
    }
}
