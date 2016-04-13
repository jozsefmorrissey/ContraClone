using System;
using System.Windows.Forms;
using System.Drawing;

namespace ContraClone
{
	public class Character : SceneObject
	{
		protected float velocityX;
		protected float velocityY;
		protected bool alive;
		protected int Damage;
		protected int Health;
		protected Weapon weapon;
		protected Animation anim;
		protected Image image;

		public Character ()
		{
		}

		public Character(int startx, int starty, String imageName)
		{
			String imagePath = System.IO.Directory.GetCurrentDirectory () + "/../../Images/cropped_contra_images/idle1.png";
			image = (Bitmap)Image.FromFile (imagePath, true);
			image = Utilities.ScaleImage (image, 75, 75);
			staticX = Init.window.Width / 2 - image.Width;
			staticY = Init.window.Height / 2 - image.Height;

			centerX = x = (float)startx;
			centerY = y = (float)starty;
		}

		public override void calculatePosition (SceneObject focalPoint)
		{

		}

		public void paint(Graphics formGraphics)
		{
			staticX = Init.window.Width / 2 - image.Width;
			staticY = Init.window.Height / 2 - image.Height;
			formGraphics.DrawImage (image, staticX, staticY);
		}

		public bool move(int right, int left, int up, int down)
		{
			this.x += right + left;
			this.y += up + down;
				lastX = x;
				lastY = y;

				return false;
		}
	}
}