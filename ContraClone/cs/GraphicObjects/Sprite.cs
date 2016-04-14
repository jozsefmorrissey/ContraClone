using System;
using System.Drawing;

namespace ContraClone
{
	public class Sprite : SceneObject
	{
		protected Image image;

		public Sprite ()
		{
		}

		public Sprite(int x, int y)
		{
			centerX = x;
			centerY = y;
		}

		public override void calculatePosition (SceneObject focalPoint)
		{

		}
	}
}

