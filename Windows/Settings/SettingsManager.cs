using System;

namespace TBS.Windows.Settings
{
	public class SettingsManager
	{
	    private const string extension = ".xml";
		public string Directory { get; protected set; }

		public SettingsManager(string directory = "Content/Settings/")
		{
			Directory = directory;
		}
			
		/// <summary>
		/// Load a settings file
		/// </summary>
		public T Load<T>()
		{
			var t = typeof(T);
			return Load<T>(t.Name);
		}

		public T Load<T>(string name)
		{
			try
			{
				return Serializer.Read<T>(
					Directory +
					name +
					extension);
			}
			catch (Exception)
			{
				var t = typeof(T);
				return (T)Activator.CreateInstance(t);
			}
		}

		public void Save<T>(T o)
		{
			var t = typeof(T);
			Save(o, t.Name);
		}

		public void Save<T>(T o, string name)
		{
			Serializer.Write(o, Directory + name + extension);
		}
	}
}
