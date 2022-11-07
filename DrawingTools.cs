using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbody6
{
    public static class DrawingTools
    {
        // drat a dot at a specific size, position and color
        public static void DrawDots(List<Dot> World)
        {
            List<double> xs = new List<double>();
            List<double> ys = new List<double>();
            foreach (var item in World)
            {
                xs.Add(item.Xcoord);
                ys.Add(item.Ycoord);
            }

            var plt = new ScottPlot.Plot(400, 300);
            plt.AddScatter(xs.ToArray(), ys.ToArray(), lineStyle: ScottPlot.LineStyle.None);
            plt.SaveFig("asdasd.png");
            //plt.Render();
        }
    }
}
