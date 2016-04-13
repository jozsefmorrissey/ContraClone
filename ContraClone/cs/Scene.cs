using System;
using System.Windows.Forms;
using System.Drawing;


namespace ContraClone
{
	public class Scene
	{
		protected Object[] objects;
		public static Timer time;
		public static SceneObject view_target;
		public static Character hero;
		protected Background[] backgrounds;
		protected Background bkgd;

		public Scene ()
		{
			backgrounds = new Background[5];
			objects = new Object[20];
			level1 ();
		}

		protected void level1()
		{
			String imagePath = System.IO.Directory.GetCurrentDirectory () + "/../../Images/level1.png";
			Image background = (Bitmap)Image.FromFile (imagePath, true);

			hero = new Character (Init.window.Width/2, Init.window.Height/2, "");
			view_target = hero;
			bkgd = new Background (background, Init.window);
			bkgd.calculatePosition (view_target);
			backgrounds [backgrounds.Length - 1] = bkgd;
		}

		public bool move_heros(int right, int left, int up, int down)
		{
			return hero.move (right, left, up, down);
		}

		public void paint(Graphics graphics)
		{
			bkgd.paint_background (graphics, hero);
			hero.paint (graphics);
		}
	}

}

