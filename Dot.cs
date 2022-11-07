using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbody6
{
    public class Dot
    {
        public int ID { get; set; }
        public double Xcoord { get; set; }
        public double Ycoord { get; set; }
        public double Mass { get; set; }
        public double Temperature { get; set; }
        public double Speed { get; set; }
        public double VelX { get; set; }
        public double VelY { get; set; }
        public double Intertia { get; set; }
        public double TimeDillation { get; set; }


        public void Update(List<Dot> World, double timestep)
        {
            //takes in World, loops thorugh all the dots and sums up the total displacement and
            //other properties due to forces for only the object this function is called from
            double totDispX = 0;
            double totDispY = 0;
            foreach (var dot in World)
            {
                if(dot.ID != this.ID)
                {
                    var temp = PhysMath.XYdisplacement(this, dot, timestep);
                    totDispX += temp.Item1;
                    totDispY += temp.Item2;
                }
            }
            this.Xcoord += totDispX;
            this.Ycoord += totDispY;

            this.Speed = PhysMath.Hypo(totDispX, totDispY)/timestep;
        }

        public Dot(double intertia, double xcoord, double ycoord, double mass, double temperature, double velX, double velY)
        {
            ID++;
            Xcoord = xcoord;
            Ycoord = ycoord;
            Mass = mass;
            Temperature = temperature;
            Speed = PhysMath.Hypo(velX, velY);
            VelX = velX;
            VelY = velY;
            Intertia = (Mass * Math.Pow(Speed, 2)) /2;
            TimeDillation = 1;
        }
    }
}
