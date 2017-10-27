using System.Collections.Generic;

namespace TBS.Windows
{
    internal class Terrain
	{
		public string Type { get; private set; }
		public int Defense { get; private set; }
		public bool Hiding { get; private set; }
		public Sprite Texture { get; set; }
		public Dictionary<MoveType, int> MoveCosts { get; private set; }

		public Terrain(string type, bool hiding, int defense, params int[] costs)
		{
			Type = type;
			Defense = defense;
			Hiding = hiding;
			MoveCosts = new Dictionary<MoveType, int>
			{
				{ MoveType.Infantry, costs[0] },
				{ MoveType.Bazooka, costs[1] },
				{ MoveType.TireA, costs[2] },
				{ MoveType.TireB, costs[3] },
				{ MoveType.Tank, costs[4] },
				{ MoveType.Air, costs[5] },
				{ MoveType.Ship, costs[6] },
				{ MoveType.Transport, costs[7] }
			};
		}

		public bool IsSea()
		{
			return (Type == "Sea"
				|| Type == "BridgeSea"
				|| Type == "Beach"
				|| Type == "RoughSea"
				|| Type == "Reef"
				|| Type == "Mist");
		}
		public bool IsRiver()
		{
			return (Type == "River"
				|| Type == "BridgeRiver");
		}
		public bool IsRoad()
		{
			return (Type == "Road"
				|| Type == "BridgeSea"
				|| Type == "BridgeRiver");
		}
	}
}
