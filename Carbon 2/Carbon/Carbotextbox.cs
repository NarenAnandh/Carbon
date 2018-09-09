using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarboUiComponent
{

	public class Carbotextbox : TextBox
	{

		public Carbotextbox(string watermark = "", TextBox sampleTextBox = null)
		{
			if (sampleTextBox != null)
			{
				BackColor = sampleTextBox.BackColor;
				BorderStyle = sampleTextBox.BorderStyle;
				Font = sampleTextBox.Font;
				ForeColor = sampleTextBox.ForeColor;
				Location = sampleTextBox.Location;
				Multiline = sampleTextBox.Multiline;
				Size = sampleTextBox.Size;
				TextAlign = sampleTextBox.TextAlign;

				if (sampleTextBox.Parent != null)
					sampleTextBox.Parent.Controls.Remove(sampleTextBox);

				if (!sampleTextBox.IsDisposed)
					sampleTextBox.Dispose();
			}

			Enter += OnThisEnter;
			Leave += OnThisLeave;

			AcceptsTab = true;

			Watermark = watermark;
		}

		public override Color ForeColor
		{
			get => base.ForeColor;

			set => base.ForeColor = foreColor = value;
		}

		public override string Text
		{
			get => base.Text;

			set
			{
				base.Text = value;

				if (!Focused)
				{
					if (value == "")
						OnThisLeave(null, null);
					else
						OnThisEnter(null, null);
				}
			}
		}

		public string Watermark
		{
			get => watermark.Substring(watermark.Length - 4);

			set
			{
				if (value == null)
					throw new Exception("Property WaterPrint must be non-null.");

				watermark = value + "  \t ";

				if (!Focused)
					OnThisLeave(null, null); // update waterprint display
			}
		}

		public string RawText
		{
			get
			{
				if (Text == watermark)
					return "";

				return Text;
			}
		}

		protected Color foreColor;
		protected string watermark;

		protected void OnThisEnter(object target, EventArgs e)
		{
			if (Text == watermark)
				base.Text = "";

			base.ForeColor = foreColor;
		}

		protected void OnThisLeave(object target, EventArgs e)
		{
			if (Text == "")
			{
				base.Text = watermark;

				base.ForeColor = Color.Gray;
			}
		}

	}

}
