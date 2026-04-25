using System;
using System.Collections.Generic;
using System.Text;

namespace GameActivity.clsLogic
{
    public class player
    {
		private const int PlayerSpeed = 10;
		private static readonly Point PlayerStart = new Point(10, 525);
		private int JumpSpeed { get; set; }

		private bool GoLeft { get; set; }
		private bool GoRight { get; set; }




		private int Gravity { get; set; }
		private bool LastKeyLeft { get; set; }
		private bool LastKeyRight { get; set; }
	}
}
