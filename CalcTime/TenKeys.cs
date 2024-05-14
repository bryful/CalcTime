using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using Svg;
using System.Diagnostics;
using System.Xml;

namespace CalcTime
{
	public class TenKeys :Control
	{
		private NumSVG[] m_keys = new NumSVG[20]; 

		public TenKeys()
		{
			for(int i = 0; i < m_keys.Length; i++)
			{
				m_keys[i] = new NumSVG();
				m_keys[i].SideOffset = 5;
				m_keys[i].TBOffset = 5;
				m_keys[i].WAKU_STAT = WAKU_STAT.Rect;
				this.Controls.Add(m_keys[i]);
			}
			this.Size = new Size(120, 120);
			CHkSize();
		}
		private int Xpos(int c)
		{
			return 10;
		}
		private void CHkSize()
		{
			int xx = 2; int yy = 2;
			int w = (this.Width - xx*5) / 4;
			int h = (this.Height - yy*5) / 4;
			int x = xx;
			int y = yy;
			m_keys[0].Location = new Point(x,y);
			m_keys[0].Size = new Size(w, h);
			m_keys[0].SVG_ICON = SVG_ICON.n7;
			x += w + xx;
			m_keys[1].Location = new Point(x, y);
			m_keys[1].Size = new Size(w, h);
			m_keys[1].SVG_ICON = SVG_ICON.n8;
			x += w + xx;
			m_keys[2].Location = new Point(x, y);
			m_keys[2].Size = new Size(w, h);
			m_keys[2].SVG_ICON = SVG_ICON.n9;
			x += w + xx;
			m_keys[3].Location = new Point(x, y);
			m_keys[3].Size = new Size(w, h);
			m_keys[3].SVG_ICON = SVG_ICON.minus;
			x = xx;
			y += h + yy;
			m_keys[4].Location = new Point(x, y);
			m_keys[4].Size = new Size(w, h);
			m_keys[4].SVG_ICON = SVG_ICON.n4;
			x += w + xx;
			m_keys[5].Location = new Point(x, y);
			m_keys[5].Size = new Size(w, h);
			m_keys[5].SVG_ICON = SVG_ICON.n5;
			x += w + xx;
			m_keys[6].Location = new Point(x, y);
			m_keys[6].Size = new Size(w, h);
			m_keys[6].SVG_ICON = SVG_ICON.n6;
			x += w + xx;
			m_keys[7].Location = new Point(x, y);
			m_keys[7].Size = new Size(w, h*2 + yy);
			m_keys[7].SVG_ICON = SVG_ICON.plus;
			x = xx;
			y += h + yy;
			m_keys[8].Location = new Point(x, y);
			m_keys[8].Size = new Size(w, h);
			m_keys[8].SVG_ICON = SVG_ICON.n1;
			x += w + xx;
			m_keys[9].Location = new Point(x, y);
			m_keys[9].Size = new Size(w, h);
			m_keys[9].SVG_ICON = SVG_ICON.n2;
			x += w + xx;
			m_keys[10].Location = new Point(x, y);
			m_keys[10].Size = new Size(w, h);
			m_keys[10].SVG_ICON = SVG_ICON.n3;
			x = xx;
			y += h + yy;
			m_keys[11].Location = new Point(x, y);
			m_keys[11].Size = new Size(w*2+xx, h);
			m_keys[11].SVG_ICON = SVG_ICON.n0;
			m_keys[11].SideOffset = w/2;
			x += w + xx;
			x += w + xx;
			m_keys[12].Location = new Point(x, y);
			m_keys[12].Size = new Size(w, h);
			m_keys[12].SVG_ICON = SVG_ICON.sec;
			x += w + xx;
			m_keys[13].Location = new Point(x, y);
			m_keys[13].Size = new Size(w, h);
			m_keys[13].SVG_ICON = SVG_ICON.colon;
		}
		protected override void OnResize(EventArgs e)
		{
			CHkSize();
			base.OnResize(e);
		}
	}
}
