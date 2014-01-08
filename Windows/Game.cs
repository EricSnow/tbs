﻿using Microsoft.Xna.Framework;
using TBS.Screens;

namespace TBS
{
	public class GameStateManagementGame : Game
	{
		public GraphicsDeviceManager GraphicsDeviceManager;

		// By preloading any assets used by UI rendering, we avoid framerate glitches
		// when they suddenly need to be loaded in the middle of a menu transition.
		static readonly string[] PreloadAssets =
        {
            "Menu/Gradient"
        };

		/// <summary>
		/// The main game constructor.
		/// </summary>
		public GameStateManagementGame()
		{
			Content.RootDirectory = "Content";

			GraphicsDeviceManager = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferWidth = 800,
				PreferredBackBufferHeight = 480,
				IsFullScreen = false,
				SynchronizeWithVerticalRetrace = false
			};
			IsFixedTimeStep = true;
			IsMouseVisible = true;

			// Create the screen manager component
			var screenManager = new ScreenManager.ScreenManager(this);
			Components.Add(screenManager);

			// Activate the first screens.
			screenManager.AddScreen(new BackgroundScreen(), null);
			screenManager.AddScreen(new MainMenuScreen(), null);

			Static.Game = this;
		}

		/// <summary>
		/// Loads graphics content.
		/// </summary>
		protected override void LoadContent()
		{
			foreach (var asset in PreloadAssets)
			{
				Content.Load<object>(asset);
			}
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDeviceManager.GraphicsDevice.Clear(Color.Black);
			base.Draw(gameTime);
		}
	}
}
