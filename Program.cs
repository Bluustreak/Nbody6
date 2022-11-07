// generate a lookup tabe with sin values
// this sim uses double, so try keeping all values below 1
using Nbody6;
using System.Linq.Expressions;

// A list of dots, the entire simulation collection
List<Dot> World = new List<Dot>();

//hardcoded testDots
World.Add(new Dot(1, 1, 1, 1, 0, 0.02));
World.Add(new Dot(-1, 1, 100000000, 1, 0, 0));
DrawingTools.DrawDots(World);


double timestep = 1;
bool runSim = true;
while (runSim)
{
	foreach (var dot in World)
	{
		dot.Update(World, timestep);
	}
    //draw the dots
    DrawingTools.DrawDots(World);

    Console.WriteLine(" XY are: " + World[0].Xcoord + " ," + World[0].Ycoord + " speed: "+ World[0].Speed);


}