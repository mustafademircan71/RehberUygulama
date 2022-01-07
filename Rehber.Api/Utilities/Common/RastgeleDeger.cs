using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rehber.Api.Utilities.Common
{
    public static class RastgeleDeger
    {
        public static string DoysaAdiOlustur(string extension)
        {
            return Guid.NewGuid().ToString().Replace(" ", "-") + extension;
        } 
    }
}
