using System;
using System.Collections.Generic;
using System.Text;

namespace Inherintance
{
   public class GameObject
    {
        

        public GameObject(Position startingPosition)
        {
            this.Position = startingPosition;
        }

        public Position Position { get; set; }


        public virtual void Draw()
        {
            Console.WriteLine($"Drawing at {Position.X}:{Position.Y}");
        }
 
    }
} 
