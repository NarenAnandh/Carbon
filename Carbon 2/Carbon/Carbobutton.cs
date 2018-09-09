using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarboUiComponent
{

	public class Carbobutton : UserControl
	{

		public Carbobutton(
			object titleOrSampleButton = null,
			object color = null,
			object size = null,
			object location = null,
			Font font = null,
			object data = null)
		{
			object foreColor = null;

			if (titleOrSampleButton is Button)
			{
				Button sample = titleOrSampleButton as Button;

				font = sample.Font;
				location = sample.Location;
				size = sample.Size;
				color = sample.BackColor;
				foreColor = sample.ForeColor;
				titleOrSampleButton = sample.Text;

				if (sample.Parent != null)
					sample.Parent.Controls.Remove(sample);

				if (!sample.IsDisposed)
					sample.Dispose();
			}
			else if (!(titleOrSampleButton is String))
			{
				throw new Exception("Argument sizeOrSampleButton must be the type of either Size or Button.");
			}

			Background = new Button()
			{
				BackColor = Color.Black,
				FlatStyle = FlatStyle.Flat,
				ForeColor = Color.Gainsboro,
				Size = new Size(150, 50),
				Text = (string)titleOrSampleButton,
			};

			Background.FlatAppearance.BorderSize = 0;
			Background.Click += OnBackgroundClick;

			Controls.Add(Background);

			if (color != null)
				Background.BackColor = (Color)color;

			if (foreColor != null)
				Background.ForeColor = (Color)foreColor;

			if (size != null)
				Background.Size = (Size)size;

			if (font != null)
				Background.Font = font;

			Location = (Point)location;
			Size = Background.Size;
			Data = data;
		}

		new public Action<Carbobutton> OnClick;
		public object Data { get; set; }
		public string Title
		{
			get => Background.Text;

			set => Background.Text = value;
		}

		public Button Background { get; protected set; }

		protected void OnBackgroundClick(object target, EventArgs e)
		{
			OnClick?.Invoke(this);
		}

	}

}
