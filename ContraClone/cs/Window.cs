using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace ContraClone
{
	public class Window : Form
	{
		public Graphics display;
		TextBox TextBox1 = new TextBox();

		public Window () : base()
		{


			FlowLayoutPanel panel = new FlowLayoutPanel();
			panel.FlowDirection = FlowDirection.TopDown;
			panel.Controls.Add(TextBox1);
			this.Controls.Add(panel);

			this.KeyDown += new KeyEventHandler(GameControl.gamePlayKeyPress);
			TextBox1.KeyDown += new KeyEventHandler(GameControl.gamePlayKeyPress);
			Build ();
			//display = this.CreateGraphics ();
		}

		public void Build()
		{
			this.WindowState = FormWindowState.Maximized;
			String imagePath = System.IO.Directory.GetCurrentDirectory () + "/../../Images/level1.png";
			Image background = (Bitmap)Image.FromFile (imagePath, true);
			Background bkgd = new Background (background, this);
			Sprite so = new Sprite (this.Width/2, this.Height/2);
			bkgd.calculatePosition (so);

			//this.BackgroundImage = ScaleImage(background, 4*background.Width, this.Height);
			
			BackgroundImageLayout = ImageLayout.Stretch;

			this.Text = "Contra Clone 5000";

			this.HelpButton = true;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics formGraphics;
			formGraphics = this.CreateGraphics();


			Init.scene.paint (formGraphics);
			Thread.Sleep (1);

			base.OnPaint (e);

			formGraphics.Dispose();
		}

	}
}

