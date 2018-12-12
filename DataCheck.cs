using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestKOSTA
{
    static class DataCheck
    {
        public static string CheckAndFixString (string value, int maxLength = 0, bool NULL = false)
        {
            if (value.Length > 0)
            {
                if ((value.Length > maxLength) && (maxLength > 0))
                {
                    value = value.Substring(0, Math.Min(maxLength, value.Length));
                }
                return value;                
            }
            else
            {
                if(NULL == true)
                {
                    return "";
                }
                else
                {
                    throw new InvalidDataException("Некорректныt данные");
                }
                
            }
        }
    }
}
