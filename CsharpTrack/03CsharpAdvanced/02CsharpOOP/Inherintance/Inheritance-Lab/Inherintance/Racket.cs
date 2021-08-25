using System;
using System.Collections.Generic;
using System.Text;

namespace Inherintance
{
   public class Racket : GameObject
    {
        public Racket(int size,Position position)
        :base(position)
        {
            this.Size = size;
        }


        public int Size { get; set; }


        public override void Draw()
        {
            for (int i = 0; i < Size; i++)
            {
                Console.SetCursorPosition(Position.Y, Position.X+i);

                Console.Write("|");
            }

        }

    }
}
