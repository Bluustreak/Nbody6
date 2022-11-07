using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbody6
{
    public static class PhysMath
    {
        static double G = 6.67 * Math.Pow(10, -11);
        static int c = 299792458;
        public static double TimeDil(Dot dot)
        {
            // this returns a scalar for time dillation rather than an individual value for the dot's speed,
            // this scalar can then be applied to the sppeed if wanted
            double result = 1/(Math.Sqrt(1-(Math.Pow(dot.Speed,2) / Math.Pow(c,2))));
            return result;
        }
        public static double Hypo(double a, double b)
        {
            //ye ol pythagoras hypothenuse
            return Math.Sqrt(a * a + b * b);
        }

        public static double DotDistance(Dot a, Dot b)
        {
            // this takes in the dot objects for simplicity, rather than their locations
            double dx = a.Xcoord - b.Xcoord;
            double dy = a.Ycoord - b.Ycoord;
            return Hypo(dx, dy);
        }

        public static (double, double) XYdisplacement(Dot a, Dot b, double timestep)
        {
            // Note for later: if you reference dot a and b, you can ajust their values at once, instead of doing it one at a time, saving 2x the performance

            //gets the force and resulting acceleration due the two masses involved
            double force = (G * a.Mass * b.Mass)/Math.Pow(DotDistance(a,b),2);
            // here is also where you should add any extra forces that repells
            //force += -Math.Pow(DotDistance(a, b), 5);
            double acc = force / a.Mass;
            //acc *= TimeDil(a); // too activate lorentz scaling to the speed



            //these differences are used in the propotions of acceleration in X vs Y, VS dist
            double dx = a.Xcoord - b.Xcoord;
            double dy = a.Ycoord - b.Ycoord;
            double dist = Hypo(dx, dy);
            double AccX = Math.Cos(dx/dist);
            double AccY = Math.Sin(dy/dist);
            //directionality of acceleration is kept due to local calculation of dx and dy


            //s = ut + (1/2)at^2, the equation for displacement due to acceleration
            double sx = a.VelX * timestep + (0.5f) * AccX * Math.Pow(timestep, 2);
            double sy = a.VelY * timestep + (0.5f) * AccY * Math.Pow(timestep, 2);

            return (sx, sy);
        }

    }
}
