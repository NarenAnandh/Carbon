using System;
using System.Drawing;
using System.Windows.Forms;

namespace CarboUiComponent
{

	public class CarbolistItem : Carbobutton
	{

		public CarbolistItem(
			string title,
			Color color,
			Color selectedColor,
			Size size,
			Point location,
			Font font,
			object data,
			Carbolist parent)
			: base(title, color, size, location, font, data)
		{
			normalBackColor = Background.BackColor;

			if (selectedColor == null)
				selectedBackColor = Color.Green;
			else
				selectedBackColor = selectedColor;

			ParentList = parent;
		}

		public bool Selected
		{
			get
			{
				return Background.BackColor == selectedBackColor;
			}
			set
			{
				if (value)
					Background.BackColor = selectedBackColor;
				else
					Background.BackColor = normalBackColor;
			}
		}

		public Carbolist ParentList { get; protected set; }

		protected Color normalBackColor;
		protected Color selectedBackColor;

		public void ChangeBackColor(Color color)
		{
			normalBackColor = color;

			if (!Selected)
				Background.BackColor = color;
		}

	}

}
