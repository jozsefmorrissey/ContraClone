using System;
using System.Drawing;
using System.Windows.Forms;

namespace ContraClone
{
	public class Background : SceneObject
	{
		public int endOfMap;
		protected int bottomOffset;
		protected int topOffset;
		protected Bitmap image;
		protected Window window;

		public Background (Image img, Window win)
		{
			double scale = (double)win.Height / (double)img.Height;
			image = new Bitmap(img, new Size((int)(img.Width*scale), (int)(img.Height*scale)));			
			window = win;
			layer = 0;
			visible = true;
		}

		public override void calculatePosition (SceneObject focalPoint)
		{
			if (update_bacground (focalPoint)) {
				bottomOffset = 0;
				float height = image.Height - bottomOffset;	

				double scale = (double)window.Height / (double)height;
				Bitmap clip = new Bitmap (image, new Size ((int)(image.Width * scale), (int)(height * scale)));

				endOfMap = clip.Width;

				int minHeight = 0;
				int maxHeight = (int)(clip.Height - bottomOffset*scale);

				int garb = window.Width;

				int halfWinWidth = (window.Width) / 2;
				int minWidth = (int)(focalPoint.x) - halfWinWidth;
				int maxWidth = (int)(focalPoint.x) + halfWinWidth;
				int tot = maxWidth - minWidth;

				if (minWidth < 0) {
					maxWidth -= minWidth;
					minWidth = 0;
				}
				if (maxWidth >= clip.Width - 1) {
					minWidth = clip.Width - halfWinWidth*2;
					minWidth = clip.Width;
				}

				lastX = focalPoint.x;


				Rectangle cropTangle = new Rectangle (minWidth, minHeight, tot, maxHeight);
				clip = clip.Clone (cropTangle, clip.PixelFormat);

				window.BackgroundImage = clip;
				window.Invalidate (); 
			}
		}

		public void paint_background(Graphics g, SceneObject focalPoint)
		{

		}

		protected bool update_bacground (SceneObject focalPoint)	
		{
			if (lastX < focalPoint.x - refreshDist || lastX > focalPoint.x + refreshDist)
				return true;
			return false;
		}
	}
}

