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
	public class TimeEdit : Control
	{
		private double m_Fps = 24;
		[Category("TimeEdit")]
		public double Fps
		{
			get { return m_Fps; }
			set
			{
				m_Fps = value;
				SetDuration(m_Duration);
			}
		}
		private double m_Duration = 0;
		[Category("TimeEdit")]
		public double Duration
		{
			get { return m_Duration; }
			set
			{
				SetDuration(value);
			}
		}
		private NumSVG[] m_num = new NumSVG[10];
		private int m_keta = 0;
		[Category("TimeEdit")]
		public new Color BackColor
		{
			get { return base.BackColor; }
			set
			{
				base.BackColor = value;
				for(int i = 0; i < m_num.Length; i++)
				{
					m_num[i].BackColor = value;
				}
			}
		}
		[Category("TimeEdit")]
		public new Color ForeColor
		{
			get { return base.ForeColor; }
			set
			{
				base.ForeColor = value;
				for (int i = 0; i < m_num.Length; i++)
				{
					m_num[i].ForeColor = value;
				}
			}
		}
		public TimeEdit()
		{
			DoubleBuffered = true;
			m_num[0] = new NumSVG();
			m_num[1] = new NumSVG();
			m_num[2] = new NumSVG();
			m_num[3] = new NumSVG();
			m_num[4] = new NumSVG();
			m_num[5] = new NumSVG();
			m_num[6] = new NumSVG();
			m_num[7] = new NumSVG();
			m_num[8] = new NumSVG();
			m_num[9] = new NumSVG();
			this.Size = new Size(20*10, 30);
			for (int i = 0; i < 10; i++)
			{
				m_num[i].SVG_ICON = SVG_ICON.None;
				m_num[i].Location = new Point((9-i)*20, 0);
				m_num[i].Size = new Size(20, 30);
				m_num[i].PushEnabled = false;
				this.Controls.Add(m_num[i]);
			}
		}
		public void AddNum(SVG_ICON idx)
		{
			if (idx == SVG_ICON.bs)
			{
				BackSpace();
				return;
			}
			else if (idx == SVG_ICON.cls)
			{
				Clear();
				return;
			}
			else if (idx == SVG_ICON.None)
			{
				return;
			}else if (idx== SVG_ICON.minus)
			{
				if (m_keta>0) return;
			}else if(idx== SVG_ICON.plus)
			{
				if (IsPlus()==true) return;
			}else if (idx == SVG_ICON.n0)
			{
				if (m_keta == 0) return;
			}
			if (m_keta >=m_num.Length) return;
			for(int i= m_num.Length-1; i>=1; i--)
			{
				m_num[i].SVG_ICON = m_num[i - 1].SVG_ICON;
			}
			m_num[0].SVG_ICON = idx;
			m_keta++;
			CalcFrom();
			this.Invalidate();
		}
		public void Clear()
		{
			for (int i = 0; i < 10; i++)
			{
				m_num[i].SVG_ICON = SVG_ICON.None;
			}
			m_keta = 0;
			m_Duration = 0;
		}
		public void BackSpace()
		{

			for (int i = 0; i < 10-1; i++)
			{
				m_num[i].SVG_ICON = m_num[i+1].SVG_ICON	;
			}
			m_num[m_num.Length-1].SVG_ICON = SVG_ICON.None;
			m_keta--;
			if(m_keta<0) m_keta = 0;
			CalcFrom();
		}
		private bool IsMinus()
		{
			bool ret = true;
			if(m_keta==0)
			{
				ret = false;
			}
			return ret;
		}
		private bool IsPlus()
		{
			bool ret = true;
			if(m_keta!=0)
			{
				for(int i = 0;i<m_keta;i++)
				{
					if (m_num[i].SVG_ICON == SVG_ICON.plus)
					{
						ret = false;
						break;
					}
				}
			}
			else
			{
				ret = false;
			}
			return ret;
		}

		private void ChkSize()
		{
			int w = base.Width/10;
			int h = base.Height;

			for(int i=0; i<10;i++)
			{
				m_num[i].Location = new Point((9 - i) * w, 0);
				m_num[i].Size = new Size(w, h);
			}

		}
		protected override void OnResize(EventArgs e)
		{
			ChkSize();
			base.OnResize(e);
		}
		private void CalcFrom()
		{
			double sec = 0;
			double msec = 0;

			for(int i= 9; i>=0;i--)
			{
				if (m_num[i].SVG_ICON== SVG_ICON.None) continue;
				if (m_num[i].SVG_ICON== SVG_ICON.plus)
				{
					sec = msec;
					msec = 0;
					continue;
				}
				int v = (int)m_num[i].SVG_ICON;
				if((v>=0)&&(msec<=9))
				{
					msec = msec * 10 + (double)v;
				}
			}
			m_Duration = sec + msec/m_Fps;
		}

		private void SetDuration(double v)
		{
			if (v > 9999999) v = 9999999;
			else if (v < -999999) v = -999999;
			m_Duration = v;
			bool mf = (v < 0);
			v = Math.Abs(v);
			int sec = (int)v;
			int msec = (int)((v - (double)sec) * m_Fps);
			string ss = "";
			if(sec>0)
			{
				ss = sec.ToString();
				ss += "+";
			}
			if (msec > 0)
			{
				ss += msec.ToString();
			}
			if (mf) ss = "-" + ss;
			for (int i = 0; i < 10; i++) m_num[i].SVG_ICON = SVG_ICON.None;

			int cnt = ss.Length;
			for(int i = 0; i<cnt; i++)
			{
				char c = ss[cnt-i-1];
				if (c=='-')
				{
					m_num[i].SVG_ICON = SVG_ICON.minus;
				}else if (c=='+')
				{
					m_num[i].SVG_ICON = SVG_ICON.plus;
				}
				else
				{
					SVG_ICON si = (SVG_ICON)(c - '0');
					m_num[i].SVG_ICON = si;
				}
			}
		}
	}
}
