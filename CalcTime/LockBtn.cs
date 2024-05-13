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
using CalcTime;


namespace CalcTime
{
	public class LockBtn :NumSVG
	{
		public delegate void LockChangedEventHandler(object sender, LockChangedEventArgs e);

		//イベントデリゲートの宣言
		public event LockChangedEventHandler LockChanged;

		protected virtual void OnLockChanged(LockChangedEventArgs e)
		{
			LockChanged?.Invoke(this, e);
		}
		private bool m_IsLocked = false;
		[Category("SVG")]
		public bool IsLocked
		{
			get { return m_IsLocked; }
			set
			{
				bool b = (m_IsLocked != value);
				m_IsLocked = value;

				if(m_IsLocked)
				{
					this.SVG_ICON = SVG_ICON.lock_;
				}
				else
				{
					this.SVG_ICON = SVG_ICON.lock_open_right;
				}
				if (b) OnLockChanged(new LockChangedEventArgs(m_IsLocked));
			}
		}
		public LockBtn()
		{
			this.SideOffset = 6;
			this.TBOffset = 6;
			this.SVG_ICON = SVG_ICON.lock_open_right;
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			IsLocked = ! m_IsLocked;
			//base.OnMouseDown(e);
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			//base.OnMouseUp(e);
		}
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
