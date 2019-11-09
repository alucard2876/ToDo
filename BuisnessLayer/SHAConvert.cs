using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace BuisnessLayer
{
    public static class SHAConvert
    {
        public static int Convert(string text)
        {
            var res = 0;
            foreach (var item in text)
            {
                res = text.Length * 31 + item.GetHashCode();
            }
            return res;
        }
    }
}
