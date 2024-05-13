using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Svg;

namespace CalcAE
{
	public class SVGFNT
	{
		static public void AAA()
		{
			var svgDoc = new SvgDocument
			{
				Width = 500,
				Height = 500
			};

			svgDoc.ViewBox = new SvgViewBox(0, 0, 250, 250);

			var group = new SvgGroup();
			svgDoc.Children.Add(group);

			string s = "M 10,60 L 30,10 90,10 110,60 z";
			var seglist = SvgPathBuilder.Parse(s.ToCharArray());

			group.Children.Add(new SvgPath
			{
				StrokeWidth = 1,
				Fill = new SvgColourServer(Color.FromArgb(152, 225, 125)),
				Stroke = new SvgColourServer(Color.DarkGray),
				PathData = seglist
			});


			group.Children.Add(new SvgText
			{
				Nodes = { new SvgContentNode { Content = "Sample" } },
				X = { 30 },
				Y = { 50 },
				Fill = new SvgColourServer(Color.White),
				FontSize = 18,
				FontFamily = "sans-serif"
			});

			svgDoc.Write("sample2.svg");
		}
	}
}
