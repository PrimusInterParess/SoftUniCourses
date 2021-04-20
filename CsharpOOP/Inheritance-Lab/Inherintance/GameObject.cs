using System;
using System.Collections.Generic;
using System.Text;

namespace Inherintance
{
   public class GameObject
    {
        public Position Position { get; set; }


        public void Draw()
        {
            Console.WriteLine($"Drawing at {Position.X}:{Position.Y}");
        }
 
    }
} 
