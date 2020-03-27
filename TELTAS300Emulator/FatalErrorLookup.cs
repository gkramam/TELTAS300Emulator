using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TELTAS300Emulator
{
    public class FatalErrors 
    {
        public static List<string> All;

        static FatalErrors()
        {
            All = new List<string>();
            All.Add("AIRSN");
            All.Add("PROTS");
            All.Add("INTER");
        }
    }
}
