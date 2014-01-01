﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace TBS
{
	class Unit
	{
		public enum MoveType
		{
			Infantry,
			Bazooka,
			TireA,
			TireB,
			Tank,
			Transport,
			Ship,
			Air
		}
		public enum UnitType
		{
			Infantry,
			Vehicle,
			Ship,
			Sub,
			Helicopter,
			Air
		}
		public enum Weapon
		{
			None,
			MachineGun,
			Bazooka,
			VulcanCannon,
			Cannon,
			Rockets,
			TankGun,
			HeavyTankGun,
			MegaGun,
			AntiShipMissiles,
			Torpedo,
			AntiAirGun,
			AntiAirMissiles,
			AirToGroundMissile,
			Bomb
		}

		public string Type { get; private set; }
		public int MovingDistance { get; private set; }
		public int VisionDistance { get; private set; }
		public Vector2 Position { get; private set; }
		public Player Player { get; private set; }
		public bool Moved { get; set; }
		public bool CanCapture { get; private set; }
		public int Price { get; private set; }
		public int Ammo { get; private set; }
		public int Range { get; private set; }
		public int Gas { get; private set; }
		public int Life { get; private set; }
		public MoveType MovementType { get; private set; }
		public UnitType UType { get; private set; }
		public Weapon MainWeapon { get; private set; }
		public Weapon SecondaryWeapon { get; private set; }
		public Building Capturing { get; private set; }

		public Unit(string type, int movingDistance, int visionDistance, Player player,
					Vector2 position, bool canCapture, int price, int ammo, int range, int gas,
					MoveType moveType, UnitType unitType, Weapon weapon1, Weapon weapon2)
		{
			Type = type;
			MovingDistance = movingDistance;
			VisionDistance = visionDistance;
			Position = position;
			Player = player;
			Player.Units.Add(this);
			Moved = false;
			CanCapture = canCapture;
			Price = price;
			Ammo = ammo;
			Range = range;
			Gas = gas;
			Life = 10;
			MovementType = moveType;
			UType = unitType;
			MainWeapon = weapon1;
			SecondaryWeapon = weapon2;
			Capturing = null;
		}

		public void Move(Vector2 position)
		{
			if (Moved)
				return;
			if (Capturing != null && position != Position)
				Capturing.StopCapture();
			Position = position;
			Moved = true;
		}

		public int WeightFromType(Terrain terrain)
		{
			return Math.Min(terrain.MoveCosts[MovementType], MovingDistance);
		}

		public void Attack(Unit other)
		{
			Ammo--;
			var ol = other.Life;
			other.Life -= Life / 2;
			Life -= ol / 3;
		}

		public void Capture(Building target)
		{
			target.Capture(this);
			Capturing = target;
			Moved = true;
		}

		public void Heal(int number = 2)
		{
			Life = Math.Min(10, Life + 2);
		}
	}
}