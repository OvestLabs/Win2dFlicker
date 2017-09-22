using System;
using Windows.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;

namespace Win2dFlicker
{
	public sealed partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private readonly Random _random = new Random();

		private byte CreateRandomByte()
		{
			return (byte)(_random.NextDouble() * 0xFF);
		}

		private Color CreateRandomColor()
		{
			var red = CreateRandomByte();
			var green = CreateRandomByte();
			var blue = CreateRandomByte();
			var color = Color.FromArgb(0xFF, red, green, blue);

			return color;
		}

		private void OnRegionsInvalidated(CanvasVirtualControl sender, CanvasRegionsInvalidatedEventArgs e)
		{
			foreach (var region in e.InvalidatedRegions)
			{
				using (var ds = sender.CreateDrawingSession(region))
				{
					var color = CreateRandomColor();
					ds.Clear(color);
				}
			}
		}
	}
}
