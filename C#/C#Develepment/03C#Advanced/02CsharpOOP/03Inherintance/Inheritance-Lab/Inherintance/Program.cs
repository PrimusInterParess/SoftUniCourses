using System;
using System.Collections.Generic;

namespace Inherintance
{
    class Program
    {
        static void Main(string[] args)
        {
            List<GameObject> obcObjects = new List<GameObject>();

            obcObjects.Add(new Ball(new Position(5,6),Direction.Right));
            obcObjects.Add(new Racket(5,new Position(4,3)));
            obcObjects.Add(new Racket(5,new Position(4,30)));

            foreach (var gameObjects in obcObjects)
            {
                gameObjects.Draw();
            }
        }
    }
}
