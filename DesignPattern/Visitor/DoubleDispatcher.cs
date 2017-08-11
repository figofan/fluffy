using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Visitor
{
	namespace DoubleDispatcher
	{

		public class SpaceShip
		{
			public virtual string GetShipType()
			{
				return "SpaceShip";
			}
		}

		public class ApolloSpacecraft : SpaceShip
		{
			public virtual string GetShipType()
			{
				return "ApolloSpacecraft";
			}
		}

		public class Asteroid
		{
			public virtual void CollideWith(SpaceShip ship)
			{
				Console.WriteLine("Asteroid hit a SpaceShip");
			}
			public virtual void CollideWith(ApolloSpacecraft ship)
			{
				Console.WriteLine("Asteroid hit an ApolloSpacecraft");
			}
		}

		public class ExplodingAsteroid : Asteroid
		{
			public override void CollideWith(SpaceShip ship)
			{
				Console.WriteLine("ExplodingAsteroid hit a SpaceShip");
			}
			public override void CollideWith(ApolloSpacecraft ship)
			{
				Console.WriteLine("ExplodingAsteroid hit an ApolloSpacecraft");
			}
		}


		public class SpaceShipTest
		{
			public static void Main1(string[] args)
			{
				Asteroid theAsteroid = new Asteroid();
				ExplodingAsteroid theExplodingAsteroid = new ExplodingAsteroid();
				SpaceShip theSpaceShip = new SpaceShip();
				ApolloSpacecraft theApolloSpacecraft = new ApolloSpacecraft();
				theAsteroid.CollideWith(theSpaceShip);
				theAsteroid.CollideWith(theApolloSpacecraft);
				theExplodingAsteroid.CollideWith(theSpaceShip);
				theExplodingAsteroid.CollideWith(theApolloSpacecraft);
				Console.WriteLine("-------------------------");

				Asteroid theExplodingAsteroidRef = new ExplodingAsteroid();
				SpaceShip theApolloSpacecraftRef = new ApolloSpacecraft();
				theExplodingAsteroidRef.CollideWith(theApolloSpacecraftRef);
			}
		}
	}
}
