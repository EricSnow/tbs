﻿using System;
using System.Collections.Generic;

namespace TBS.Windows
{
    internal class Player
	{
		public int Number { get; protected set; }
		public bool IsAi { get; protected set; }
		public int Version { get; protected set; }
		public int Money { get; set; }
		public Building Headquarter { get; set; }
		public List<Building> Buildings { get; protected set; }
		public List<Unit> Units { get; protected set; }

		public Player(int number, int version, int money = 0)
		{
			Number = number;
			IsAi = false;
			Version = version;
			Money = money;
			Buildings = new List<Building>();
			Units = new List<Unit>();
		}

		public void NextTurn()
		{
			Money += Math.Min(Buildings.Count * 1000, 99000);
			foreach (var t in Units)
				t.Moved = false;
		}
	}
}
