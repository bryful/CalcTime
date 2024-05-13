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

namespace CalcAE
{
    public class NumSVG : Control
    {
		public event EventHandler MClick;

		protected virtual void OnMClick(EventArgs e)
		{
			MClick?.Invoke(this, e);
		}
		public delegate void LockChangedEventHandler(object sender, LockChangedEventArgs e);

		//イベントデリゲートの宣言
		public event LockChangedEventHandler LockChanged;

		protected virtual void OnLockChanged(LockChangedEventArgs e)
		{
			LockChanged?.Invoke(this, e);
		}
		// ***************************************************************
		// ***************************************************************
		private Bitmap m_bitmap = new Bitmap(20, 30);
		private SVG_ICON m_SVG_ICON = SVG_ICON.n0;
		[Category("SVG")]
		public SVG_ICON SVG_ICON
		{
			get { return m_SVG_ICON; }
			set
			{
				m_SVG_ICON = value;
				ChkOffScr();
				this.Refresh();
			}
		}
		[Category("SVG")]
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
		[Category("SVG")]
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
		private Color m_RevColor = Color.White;
		[Category("SVG")]
		public Color RevColor
		{
			get { return m_RevColor; }
			set
			{
				m_RevColor = value;
				this.Invalidate();
			}
		}
		private Color m_RectColor = Color.Gray;
		[Category("SVG")]
		public Color RectColor
		{
			get { return m_RectColor; }
			set
			{
				m_RectColor = value;
				this.Invalidate();
			}
		}
		private bool m_PushEnabled = true;
		[Category("SVG")]
		public bool PushEnabled
		{
			get { return this.m_PushEnabled; }
			set
			{
				m_PushEnabled = value;
			}
		}
		private WAKU_STAT m_WAKU_STAT = WAKU_STAT.None;
		[Category("SVG")]
		public WAKU_STAT WAKU_STAT
		{
			get { return m_WAKU_STAT; }
			set
			{
				m_WAKU_STAT = value;
				this.Invalidate();
			}
		}

		private int m_SideOffset = 0;
		[Category("SVG")]
		public int SideOffset
		{
			get { return m_SideOffset; }
			set
			{
				m_SideOffset = value;
				ChkOffScr();
				this.Invalidate();
			}
		}
		private int m_TBOffset = 0;
		[Category("SVG")]
		public int TBOffset
		{
			get { return m_TBOffset; }
			set
			{
				m_TBOffset = value;
				ChkOffScr();
				this.Invalidate();
			}
		}

		public NumSVG()
		{

			DoubleBuffered = true;
			this.Size = new Size(20, 30);

			ChkOffScr();
		}
		public void Redraw()
		{
			ChkOffScr();
			this.Invalidate ();
		}
		private void ChkOffScr()
		{
			m_bitmap = new Bitmap(base.Width, base.Height);
			Graphics g = Graphics.FromImage(m_bitmap);
			g.Clear(BackColor);
			if (m_SVG_ICON != SVG_ICON.None)
			{
				var assembly = Assembly.GetExecutingAssembly();
				var resourceName = SVGFNAME(m_SVG_ICON);
				using (var stream = assembly.GetManifestResourceStream(resourceName))
				{
					if (stream != null)
					{
						var doc = SvgDocument.Open<SvgDocument>(stream, new SvgOptions());
						doc.Fill = new SvgColourServer(ForeColor);
						Bitmap bm = doc.Draw(m_bitmap.Width - m_SideOffset * 2, m_bitmap.Height - m_TBOffset * 2);
						g.DrawImage(bm, m_SideOffset, m_TBOffset);
					}
				}
			}
		}

		private string SVGFNAME(SVG_ICON idx)
		{
			return "CalcTime.svg." + Enum.GetName(typeof(SVG_ICON), idx) + ".svg";
		}
		protected override void OnResize(EventArgs e)
		{
			ChkOffScr();
			base.OnResize(e);
		}
		protected override void OnPaint(PaintEventArgs e)
		{
			//base.OnPaint(e);
			Graphics g = e.Graphics;
			g.DrawImage(m_bitmap, 0, 0);
			Rectangle rct;
			if (m_WAKU_STAT != WAKU_STAT.None)
			{
				using (Pen p = new Pen(m_RectColor, 1))
				{
					switch (m_WAKU_STAT)
					{
						case WAKU_STAT.Rect:
							rct = new Rectangle(0, 0, Width - 1, Height - 1);
							g.DrawRectangle(p, rct);
							break;
						case WAKU_STAT.TB:
							g.DrawLine(p, 0,0,Width-1,0);
							g.DrawLine(p, 0, Height-1, Width - 1, Height - 1);
							break;
						case WAKU_STAT.LR:
							g.DrawLine(p, 0, 0, 0, Height);
							g.DrawLine(p, Width - 1, 0, Width - 1, Height - 1);
							break;

					}
				}
			}
		}
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if ((m_SVG_ICON != SVG_ICON.None) && (m_PushEnabled == true))
			{
				Control senderControl = (Control)this;
				Rectangle screenRectangle = senderControl.RectangleToScreen(
					senderControl.ClientRectangle);
				ControlPaint.FillReversibleRectangle(screenRectangle,
					m_RevColor);
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			bool b = false;
			if ((m_SVG_ICON != SVG_ICON.None)&& (m_PushEnabled == true))
			{
				Control senderControl = (Control)this;
				Rectangle screenRectangle = senderControl.RectangleToScreen(
					senderControl.ClientRectangle);
				ControlPaint.FillReversibleRectangle(screenRectangle,
					m_RevColor);
				b = true;
			}
			base.OnMouseUp(e);
			if (b) OnMClick(new EventArgs());
		}
	}
	public enum SVG_ICON
	{
		None =-1,
		n0,
		n1,
		n2,
		n3,
		n4,
		n5,
		n6,
		n7,
		n8,
		n9,
		dot,
		minus,
		plus,
		colon,
		semicolon,
		bs,
		cls,
		fps24,
		fps30,
		sec,
		lock_,
		lock_open_right
	}
	public enum WAKU_STAT
	{
		None,
		Rect,
		TB,
		LR
	}
}
