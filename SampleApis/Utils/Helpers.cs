using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApis.Utils
{
    public static class Helpers
    {
        public static string ToTinyUuid(this Guid guid)
        {
            return Convert.ToBase64String(guid.ToByteArray())[0..^2]  
                .Replace('+', '-')                       
                .Replace('/', '_');  
        }
    }
}
