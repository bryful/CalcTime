namespace CalcTime
{
	partial class Form1
	{
		/// <summary>
		/// 必要なデザイナー変数です。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 使用中のリソースをすべてクリーンアップします。
		/// </summary>
		/// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows フォーム デザイナーで生成されたコード

		/// <summary>
		/// デザイナー サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディターで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.numFrame2 = new CalcTime.NumFrame();
			this.numFrame1 = new CalcTime.NumFrame();
			this.swFps1 = new CalcTime.SwFps();
			this.tenKeys1 = new CalcTime.TenKeys();
			this.timeEdit2 = new CalcTime.TimeEdit();
			this.timeEdit1 = new CalcTime.TimeEdit();
			this.SuspendLayout();
			// 
			// numFrame2
			// 
			this.numFrame2.ForeColor = System.Drawing.SystemColors.ControlDark;
			this.numFrame2.Location = new System.Drawing.Point(121, 12);
			this.numFrame2.Name = "numFrame2";
			this.numFrame2.NumSize = new System.Drawing.Size(12, 20);
			this.numFrame2.Size = new System.Drawing.Size(96, 20);
			this.numFrame2.TabIndex = 8;
			this.numFrame2.Text = "numFrame2";
			this.numFrame2.Value = -9875;
			// 
			// numFrame1
			// 
			this.numFrame1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
			this.numFrame1.Location = new System.Drawing.Point(125, 84);
			this.numFrame1.Name = "numFrame1";
			this.numFrame1.NumSize = new System.Drawing.Size(12, 20);
			this.numFrame1.Size = new System.Drawing.Size(108, 20);
			this.numFrame1.TabIndex = 7;
			this.numFrame1.Text = "numFrame1";
			this.numFrame1.Value = 12;
			// 
			// swFps1
			// 
			this.swFps1.ActiveColor = System.Drawing.SystemColors.ControlText;
			this.swFps1.Fps = CalcTime.FPS.fps24;
			this.swFps1.IsLocked = false;
			this.swFps1.Location = new System.Drawing.Point(12, 12);
			this.swFps1.Name = "swFps1";
			this.swFps1.NoactiveColor = System.Drawing.SystemColors.Window;
			this.swFps1.Size = new System.Drawing.Size(100, 20);
			this.swFps1.TabIndex = 6;
			this.swFps1.Text = "swFps1";
			// 
			// tenKeys1
			// 
			this.tenKeys1.Location = new System.Drawing.Point(55, 156);
			this.tenKeys1.Name = "tenKeys1";
			this.tenKeys1.Size = new System.Drawing.Size(178, 169);
			this.tenKeys1.TabIndex = 4;
			this.tenKeys1.Text = "tenKeys1";
			// 
			// timeEdit2
			// 
			this.timeEdit2.BackColor = System.Drawing.SystemColors.Window;
			this.timeEdit2.Duration = 1.3D;
			this.timeEdit2.Fps = 24D;
			this.timeEdit2.Location = new System.Drawing.Point(12, 110);
			this.timeEdit2.Name = "timeEdit2";
			this.timeEdit2.Size = new System.Drawing.Size(221, 40);
			this.timeEdit2.TabIndex = 2;
			this.timeEdit2.Text = "timeEdit2";
			// 
			// timeEdit1
			// 
			this.timeEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.timeEdit1.Duration = 0D;
			this.timeEdit1.Fps = 24D;
			this.timeEdit1.Location = new System.Drawing.Point(12, 38);
			this.timeEdit1.Name = "timeEdit1";
			this.timeEdit1.Size = new System.Drawing.Size(221, 40);
			this.timeEdit1.TabIndex = 1;
			this.timeEdit1.Text = "timeEdit1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(428, 380);
			this.Controls.Add(this.numFrame2);
			this.Controls.Add(this.numFrame1);
			this.Controls.Add(this.swFps1);
			this.Controls.Add(this.tenKeys1);
			this.Controls.Add(this.timeEdit2);
			this.Controls.Add(this.timeEdit1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion
		private TimeEdit timeEdit1;
		private TimeEdit timeEdit2;
		private TenKeys tenKeys1;
		private SwFps swFps1;
		private NumFrame numFrame1;
		private NumFrame numFrame2;
	}
}

