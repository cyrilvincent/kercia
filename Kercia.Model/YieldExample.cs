using System;
using System.Collections.Generic;
using System.Text;

namespace Kercia.Model
{
    public class YieldExample
    {

        public IEnumerable<int> FilterByLambda(IEnumerable<int> ie, Func<int, bool> lambda)
        {
            foreach(int i in ie)
            {
                if(lambda(i))
                {
                    yield return i;
                }
            }
        }

    }
}
