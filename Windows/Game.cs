﻿using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using TBS.Windows.Screens;

namespace TBS.Windows
{
	public class GameStateManagementGame : Game
	{
		public GraphicsDeviceManager GraphicsDeviceManager;

		// By preloading any assets used by UI rendering, we avoid framerate glitches
		// when they suddenly need to be loaded in the middle of a menu transition.
	    private static readonly string[] preloadAssets =
        {
            "Menu/Gradient"
        };

		/// <summary>
		/// The main game constructor.
		/// </summary>
		public GameStateManagementGame()
		{
			Content.RootDirectory = "Content";

			var manager = new Settings.SettingsManager();
			var settings = manager.Load<Settings.GeneralSettings>();

			GraphicsDeviceManager = new GraphicsDeviceManager(this)
			{
				PreferredBackBufferWidth = settings.Width,
				PreferredBackBufferHeight = settings.Height,
				IsFullScreen = settings.Fullscreen,
				SynchronizeWithVerticalRetrace = false
			};
			IsFixedTimeStep = true;
			IsMouseVisible = true;

			if (settings.Fullscreen)
			{
				var screen = Screen.AllScreens.First(n => n.Primary);
				Window.IsBorderless = true;
				Window.Position = new Point(screen.Bounds.X, screen.Bounds.Y);
				GraphicsDeviceManager.PreferredBackBufferWidth = screen.Bounds.Width;
				GraphicsDeviceManager.PreferredBackBufferHeight = screen.Bounds.Height;
				GraphicsDeviceManager.ApplyChanges();
			}

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
			foreach (var asset in preloadAssets)
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
