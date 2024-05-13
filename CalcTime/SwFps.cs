using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CalcAE
{
	public class SwFps :Control
	{
		private NumSVG[] m_num = new NumSVG[2];
		private FPS m_Fps = FPS.fps24;
		public FPS Fps
		{
			get { return m_Fps; }
			set
			{
				m_Fps = value;
				if(m_Fps== FPS.fps24)
				{
					m_num[0].ForeColor = base.BackColor;
					m_num[0].BackColor = base.ForeColor;
					m_num[1].ForeColor = base.ForeColor;
					m_num[1].BackColor = base.BackColor;
				}
				else
				{
					m_num[0].ForeColor = base.ForeColor;
					m_num[0].BackColor = base.BackColor;
					m_num[1].ForeColor = base.BackColor;
					m_num[1].BackColor = base.ForeColor;
				}
			}
		}

		public SwFps() 
		{
			DoubleBuffered = true;
			for (int i = 0; i < m_num.Length; i++)
			{
				m_num[i] = new NumSVG();
				m_num[i].Location = new Point(i*38+3, 3);
				m_num[i].Size = new Size(32, 24);
				m_num[i].SideOffset = 1;
				m_num[i].TBOffset = 1;
				this.Controls.Add(m_num[i]);
			}
			m_num[0].SVG_ICON = SVG_ICON.fps24;
			m_num[1].SVG_ICON = SVG_ICON.fps30;
			Fps = FPS.fps24;
			this.Size = new Size(79, 26);
		}

		public void ChkSize()
		{
			int w = (this.Width) / 2;
			int h = this.Height;
			m_num[0].Location = new Point(3, 3);
			m_num[0].Size = new Size(w-6, h-6);
			m_num[1].Location = new Point(w+3, 3);
			m_num[1].Size = new Size(w-6, h - 6);
		}
		protected override void OnResize(EventArgs e)
		{
			ChkSize();
			base.OnResize(e);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			using(Pen p = new Pen(ForeColor, 1))
			{
				e.Graphics.DrawRectangle(
					p,
					new Rectangle(0, 0, this.Width - 1, this.Height - 1)
					);
			}
		}
	}
	public enum FPS
	{
		fps24=24,
		fps30=30
	}
}
