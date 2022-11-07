using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbody6
{
    public static class InitSim
    {
        // for us in PhysMath 
        public static List<double> InitAltArcSin(double increment)
        {
            List<double> result = new List<double>();

            for (double i = increment; i <= (360 / increment); i +=increment)
            {
                result.Add(Math.Sin(i));
            }
            return result;
        }
    }
}
