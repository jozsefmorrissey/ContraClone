using System;
using System.Windows.Forms;
using System.Drawing;


namespace ContraClone
{
	public class GameControl
	{
		// Detect all keys used during game play.
		public static void gamePlayKeyPress(object sender, KeyEventArgs e)
		{
			int movementOffset = 10;
			switch ((int)e.KeyCode)
			{
				case (int)Keys.Right:
					Init.scene.updateGraphics (movementOffset, 0, 0, 0);
					break;
				case (int)Keys.Left:
				Init.scene.updateGraphics (0, -movementOffset, 0, 0);
					break;
				case (int)Keys.Up:
				Init.scene.updateGraphics (0, 0, movementOffset, 0);
					break;
				case (int)Keys.Down:
				Init.scene.updateGraphics (0, 0, 0, -movementOffset);
					break;
				case (int)Keys.Space:
				Init.scene.updateGraphics (0, 0, 0, movementOffset);
					break;
			}
			Init.window.Invalidate ();
		}
	}
}

