using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{

	public class ToolBox
	{

		static public Color ColorFromRgb(int color)
		{
			return Color.FromArgb(
				255,
				(byte)((color & 0xFF0000) >> 0x10),
				(byte)((color & 0x00FF00) >> 8),
				(byte)(color & 0x0000FF)
			);
		}

	}

}
