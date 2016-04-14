using System;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Drawing.Drawing2D;

//TODO: Repair initial background size error.
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

			this.Text = "Contra Clone 5000";

			this.ResizeRedraw = true;
			this.HelpButton = true;
			this.MaximizeBox = true;
			this.MinimizeBox = true;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics formGraphics;
			formGraphics = this.CreateGraphics();

			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

			Init.scene.paint (formGraphics);
			//Thread.Sleep (1);

			base.OnPaint (e);

			formGraphics.Dispose();
		}

		protected override void OnResize (EventArgs e)
		{
			Init.scene.bkgd.calculatePosition (Init.scene.view_target);
		}

	}
}

