using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravellerBot.Utils
{
    public class ListUtils
    {
        public static TResult Shift<TResult>(List<TResult> array)
        {
            TResult first = array[0];
            array.RemoveAt(0);
            return first;
        }
    }
}
