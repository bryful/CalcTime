using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CalcTime
{
	public class SwFps :Control
	{
		public delegate void FpsChangedEventHandler(object sender, FpsChangedEventArgs e);

		//イベントデリゲートの宣言
		public event FpsChangedEventHandler FpsChanged;

		protected virtual void OnFpsChanged(FpsChangedEventArgs e)
		{
			FpsChanged?.Invoke(this, e);
		}
		private NumSVG[] m_num = new NumSVG[2];
		private LockBtn m_lock = new LockBtn();
		private FPS m_Fps = FPS.fps24;
		[Category("SVG")]
		public FPS Fps
		{
			get { return m_Fps; }
			set
			{
				if (m_IsLocked == false)
				{
					bool b = (m_Fps == value);
					m_Fps = value;
					if (m_Fps == FPS.fps24)
					{
						m_num[0].ForeColor = m_NoactiveColor;
						m_num[0].BackColor = m_ActiveColor;
						m_num[1].ForeColor = m_ActiveColor;
						m_num[1].BackColor = m_NoactiveColor;
					}
					else
					{
						m_num[0].ForeColor = m_ActiveColor;
						m_num[0].BackColor = m_NoactiveColor;
						m_num[1].ForeColor = m_NoactiveColor;
						m_num[1].BackColor = m_ActiveColor;
					}
					m_num[0].Redraw();
					m_num[1].Redraw();
					int f = (int)m_Fps;
					if (b) OnFpsChanged(new FpsChangedEventArgs((double)f));
				}
			}
		}
		private Color m_ActiveColor = SystemColors.ControlText;
		[Category("SVG")]
		public Color ActiveColor
		{
			get { return m_ActiveColor; }
			set { m_ActiveColor = value; this.Invalidate(); }
		}
		private Color m_NoactiveColor = SystemColors.Window;
		[Category("SVG")]
		public Color NoactiveColor
		{
			get { return m_NoactiveColor; }
			set { m_NoactiveColor = value; this.Invalidate(); }
		}
		[Category("SVG")]
		public new Color BackColor
		{
			get { return base.BackColor; }
			set 
			{ 
				base.BackColor = value;
				m_lock.BackColor = value;
				this.Invalidate(); 
			}
		}
		[Category("SVG")]
		public new Color ForeColor
		{
			get { return base.ForeColor; }
			set
			{
				base.ForeColor = value;
				m_lock.ForeColor = value;
				this.Invalidate();
			}
		}
		private bool m_IsLocked = false;
		[Category("SVG")]
		public bool IsLocked
		{
			get { return m_lock.IsLocked; }
			set 
			{ 
				m_lock.IsLocked = value;
			}
		}
		public SwFps() 
		{
			DoubleBuffered = true;
			m_lock.SideOffset = 2;
			m_lock.TBOffset = 2;
			this.Controls.Add(m_lock);
			for (int i = 0; i < m_num.Length; i++)
			{
				m_num[i] = new NumSVG();
				m_num[i].Location = new Point(i*38+3, 3);
				m_num[i].Size = new Size(32, 24);
				m_num[i].SideOffset = 1;
				m_num[i].TBOffset = 1;
				m_num[i].PushEnabled = false;
				this.Controls.Add(m_num[i]);
			}
			
			m_num[0].SVG_ICON = SVG_ICON.fps24;
			m_num[1].SVG_ICON = SVG_ICON.fps30;
			m_lock.SVG_ICON = SVG_ICON.lock_open_right;

			m_num[0].MouseUp += (sender, e) =>
			{
				if (IsLocked == false)
				{
					Fps = FPS.fps24;
				}
			};
			m_num[1].MouseUp += (sender, e) =>
			{
				if (IsLocked == false)
				{
					Fps = FPS.fps30;
				}
			};
			IsLocked = false;
			Fps = FPS.fps24;
			this.Size = new Size(79, 26);
			ChkSize();
		}

		public void ChkSize()
		{
			int w0 = this.Height;
			int w = (this.Width-w0) / 2;
			int h = this.Height;
			m_lock.Location = new Point(3, 3);
			m_lock.Size = new Size(w0-6, h-6);
			m_num[0].Location = new Point(w0+3, 3);
			m_num[0].Size = new Size(w-6, h-6);
			m_num[1].Location = new Point(w0 + w +3, 3);
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
			e.Graphics.Clear(BackColor);
			using(Pen p = new Pen(ForeColor, 1))
			{
				e.Graphics.DrawRectangle(
					p,
					new Rectangle(this.Height, 0, this.Width-this.Height - 1, this.Height - 1)
					);
			}
		}
	}
	public class FpsChangedEventArgs : EventArgs
	{
		public double Fps;
		public FpsChangedEventArgs(double fps)
		{
			this.Fps = fps;
		}
	}
	public enum FPS
	{
		fps24=24,
		fps30=30
	}
	
}
