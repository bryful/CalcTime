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
using System.Reflection;
namespace CalcTime
{
	public class NumFrame :Control
	{
		private int m_Value = 0;
		public int Value
		{
			get { return m_Value; }
			set 
			{ 
				m_Value = value; 
				this.Invalidate();
			}
		}
		private Bitmap[] bitmaps = new Bitmap[11];
		private Size m_NumSize = new Size(16, 24);
		public Size NumSize
		{
			get { return m_NumSize; }
			set
			{
				m_NumSize = value;
				ChkOffScr();
				ChkResize();
				this.Invalidate();
			}
		}

		public new Color ForeColor
		{
			get { return base.ForeColor; }
			set
			{
				base.ForeColor = value;
				ChkOffScr();
				this.Invalidate();
			}
		}
		public new Color BackColor
		{
			get { return base.BackColor; }
			set
			{
				base.BackColor = value;
				ChkOffScr();
				this.Invalidate();
			}
		}
		public NumFrame()
		{
			this.Size = new Size(120, 24);
			ChkOffScr();
			ChkResize();
		}
		private void ChkOffScr()
		{
			var assembly = Assembly.GetExecutingAssembly();
			
			for (int i = 0; i < 11; i++)
			{
				bitmaps[i] = new Bitmap(m_NumSize.Width, m_NumSize.Height);
				Graphics g = Graphics.FromImage(bitmaps[i]);
				g.Clear(BackColor);
				var resourceName = SVGFNAME((SVG_ICON)i);
				if (i==10)
				{
					resourceName = SVGFNAME(SVG_ICON.minus);
				}
				using (var stream = assembly.GetManifestResourceStream(resourceName))
				{
					if (stream != null)
					{
						var doc = SvgDocument.Open<SvgDocument>(stream, new SvgOptions());
						doc.Fill = new SvgColourServer(ForeColor);
						bitmaps[i] = doc.Draw(m_NumSize.Width, m_NumSize.Height);
					}
				}
			}
		}
		private string SVGFNAME(SVG_ICON idx)
		{
			return "CalcTime.svg." + Enum.GetName(typeof(SVG_ICON), idx) + ".svg";
		}
		private void ChkResize()
		{
			base.Width = (base.Width / m_NumSize.Width) * m_NumSize.Width;
			if (base.Height != m_NumSize.Height) base.Height = m_NumSize.Height;

		}
		protected override void OnResize(EventArgs e)
		{
			ChkResize();
			base.OnResize(e);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			using(Pen p = new Pen(ForeColor, 1))
			using (SolidBrush sb = new SolidBrush(BackColor))
			{
				Graphics g = e.Graphics;

				g.Clear(BackColor);

				if (m_Value != 0)
				{
					string s = m_Value.ToString();
					int x = Width - m_NumSize.Width * s.Length;
					for (int i = 0;i<s.Length;i++)
					{
						char c = s[i];
						if(c== '-') 
						{
							g.DrawImage(bitmaps[10], x, 0);
						}else if ((c>= '0')&&(c<='9'))
						{
							int idx = (int)(c - '0');
							g.DrawImage(bitmaps[idx], x, 0);
						}
						x += m_NumSize.Width;
					}
				}
			}
		}

	}
}
