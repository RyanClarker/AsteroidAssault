using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.IO;

namespace Asteroid_Belt_Assault
{
    public static class SpriteCreators
    {
        public static Dictionary<string, Rectangle> spriteSourceRectangles;
        public static Random rand = new Random(System.Environment.TickCount);

        public static void Load(string path)
        {
            SpriteCreators.spriteSourceRectangles = new Dictionary<string, Rectangle>();

            // open a StreamReader to read the index

            using (StreamReader reader = new StreamReader(path))
            {
                // while we're not done reading...
                while (!reader.EndOfStream)
                {
                    // get a line
                    string line = reader.ReadLine();

                    // split at the equals sign
                    string[] sides = line.Split('=');

                    // trim the right side and split based on spaces
                    string[] rectParts = sides[1].Trim().Split(' ');

                    // create a rectangle from those parts
                    Rectangle r = new Rectangle(
                       int.Parse(rectParts[0]),
                       int.Parse(rectParts[1]),
                       int.Parse(rectParts[2]),
                       int.Parse(rectParts[3]));

                    // add the name and rectangle to the dictionary
                    SpriteCreators.spriteSourceRectangles.Add(sides[0].Trim(), r);
                }
            }

        }

    }
}
