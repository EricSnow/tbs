using System;
using Microsoft.Xna.Framework;

namespace TBS.Windows.Screens
{
    /// <summary>
    /// Custom event argument which includes the index of the player who
    /// triggered the event. This is used by the MenuEntry.Selected event.
    /// </summary>
    internal class PlayerIndexEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public PlayerIndexEventArgs(PlayerIndex playerIndex)
        {
            PlayerIndex = playerIndex;
        }


	    /// <summary>
	    /// Gets the index of the player who triggered this event.
	    /// </summary>
	    public PlayerIndex PlayerIndex { get; private set; }
    }
}
