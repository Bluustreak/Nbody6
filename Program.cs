// generate a lookup tabe with sin values
// this sim uses double, so try keeping all values below 1
using Nbody6;
using System.Linq.Expressions;

// A list of dots, the entire simulation collection
List<Dot> World = new List<Dot>();

//hardcoded testDots
World.Add(new Dot(1,1,1,300,0,0));
World.Add(new Dot(0,0,1,300,0,0));

double timestep = 1;
bool runSim = true;
while (runSim)
{
	foreach (var dot in World)
	{
		dot.Update(World, timestep);
	}
}