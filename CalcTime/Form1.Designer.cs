namespace CalcAE
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
			this.tenKeys1 = new CalcAE.TenKeys();
			this.timeEdit2 = new CalcAE.TimeEdit();
			this.timeEdit1 = new CalcAE.TimeEdit();
			this.swFps1 = new CalcAE.SwFps();
			this.SuspendLayout();
			// 
			// tenKeys1
			// 
			this.tenKeys1.Location = new System.Drawing.Point(12, 142);
			this.tenKeys1.Name = "tenKeys1";
			this.tenKeys1.Size = new System.Drawing.Size(221, 175);
			this.tenKeys1.TabIndex = 4;
			this.tenKeys1.Text = "tenKeys1";
			// 
			// timeEdit2
			// 
			this.timeEdit2.BackColor = System.Drawing.SystemColors.Window;
			this.timeEdit2.Duration = 1.3D;
			this.timeEdit2.Fps = 24D;
			this.timeEdit2.Location = new System.Drawing.Point(12, 95);
			this.timeEdit2.Name = "timeEdit2";
			this.timeEdit2.Size = new System.Drawing.Size(221, 41);
			this.timeEdit2.TabIndex = 2;
			this.timeEdit2.Text = "timeEdit2";
			// 
			// timeEdit1
			// 
			this.timeEdit1.BackColor = System.Drawing.SystemColors.Window;
			this.timeEdit1.Duration = 0D;
			this.timeEdit1.Fps = 24D;
			this.timeEdit1.Location = new System.Drawing.Point(12, 44);
			this.timeEdit1.Name = "timeEdit1";
			this.timeEdit1.Size = new System.Drawing.Size(221, 45);
			this.timeEdit1.TabIndex = 1;
			this.timeEdit1.Text = "timeEdit1";
			// 
			// swFps1
			// 
			this.swFps1.BackColor = System.Drawing.SystemColors.Window;
			this.swFps1.Fps = CalcAE.FPS.fps24;
			this.swFps1.Location = new System.Drawing.Point(12, 9);
			this.swFps1.Name = "swFps1";
			this.swFps1.Size = new System.Drawing.Size(78, 29);
			this.swFps1.TabIndex = 0;
			this.swFps1.Text = "swFps1";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(237, 322);
			this.Controls.Add(this.tenKeys1);
			this.Controls.Add(this.timeEdit2);
			this.Controls.Add(this.timeEdit1);
			this.Controls.Add(this.swFps1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}

		#endregion

		private SwFps swFps1;
		private TimeEdit timeEdit1;
		private TimeEdit timeEdit2;
		private TenKeys tenKeys1;
	}
}

