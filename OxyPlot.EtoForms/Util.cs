using System;
namespace OxyPlot
{
	public static class Util
	{
		public static Eto.Drawing.Color ToEto(this OxyColor Color) => Eto.Drawing.Color.FromArgb(Color.R, Color.G, Color.B, Color.A);
		public static Eto.Drawing.RectangleF ToRect(this OxyRect Rect) 
			=> new Eto.Drawing.RectangleF((float)Rect.Left, (float)Rect.Top, (float)Rect.Width, (float)Rect.Height);
	}
}
