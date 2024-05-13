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
		public delegate void LockChangedEventHandler(object sender, LockChangedEventArgs e);

		//イベントデリゲートの宣言
		public event LockChangedEventHandler LockChanged;

		protected virtual void OnLockChanged(LockChangedEventArgs e)
		{
			LockChanged?.Invoke(this, e);
		}
		private NumSVG[] m_num = new NumSVG[2];
		private NumSVG m_lock = new NumSVG();
		private FPS m_Fps = FPS.fps24;
		[Category("SVG")]
		public FPS Fps
		{
			get { return m_Fps; }
			set
			{
				if (m_IsLocked == false)
				{
					m_Fps = value;
					if (m_Fps == FPS.fps24)
					{
						m_num[0].ForeColor = m_ActiveColor;
						m_num[0].BackColor = m_NoactiveColor;
						m_num[1].ForeColor = m_NoactiveColor;
						m_num[1].BackColor = m_ActiveColor;
					}
					else
					{
						m_num[0].ForeColor = m_NoactiveColor;
						m_num[0].BackColor = m_ActiveColor;
						m_num[1].ForeColor = m_ActiveColor;
						m_num[1].BackColor = m_NoactiveColor;
					}
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
		[Category("SVG")]
		public Color NoactiveColor
		{
			get { return m_NoactiveColor; }
			set { m_NoactiveColor = value; this.Invalidate(); }
		}
		private Color m_NoactiveColor = SystemColors.Window;
		[Category("SVG")]

		private bool m_IsLocked = false;
		public bool IsLocked
		{
			get { return m_IsLocked; }
			set 
			{ 
				m_IsLocked = value;
				if (m_IsLocked)
				{
					m_lock.SVG_ICON = SVG_ICON.lock_;
					m_num[0].PushEnabled = false;
					m_num[1].PushEnabled = false;

				}
				else
				{
					m_lock.SVG_ICON = SVG_ICON.lock_open_right;
					m_num[0].PushEnabled = true;
					m_num[1].PushEnabled = true;
				}
				m_lock.Redraw();
				m_num[0].Redraw();
				m_num[1].Redraw();
				this.Invalidate();
			}
		}
		public SwFps() 
		{
			DoubleBuffered = true;
			this.Controls.Add(m_lock);
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
			m_lock.SVG_ICON = SVG_ICON.lock_open_right;

			m_lock.MClick += (sender, e) =>
			{
				IsLocked = ! m_IsLocked;
			};
			m_num[0].MClick += (sender, e) =>
			{
				if (m_IsLocked)
				{
					Fps = FPS.fps24;
				}
			};

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
	public enum FPS
	{
		fps24=24,
		fps30=30
	}
	public class LockChangedEventArgs : EventArgs
	{
		public bool lockValue;
		public LockChangedEventArgs(bool lockValue)
		{
			this.lockValue = lockValue;
		}
	}
}
