﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Inherintance
{
   public class Ball : GameObject
    {
        public Ball(Position position,Direction direction)
        :base(position)

        {
            this.Position = position;
            this.Direction = direction;
        }

        public Direction Direction { get; set; }

        public override void Draw()
        {
            Console.SetCursorPosition(Position.Y,Position.X);

            Console.Write("@");
        }
    }

  
}
