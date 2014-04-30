using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroid_Belt_Assault
{
    class Planets
    {
        private List<Sprite> planets = new List<Sprite>();
        private int screenWidth = 800;
        private int screenHeight = 600;
        private Random rand = new Random(System.Environment.TickCount);
        private Color[] colors = { Color.White, Color.Yellow, 
                           Color.Wheat, Color.WhiteSmoke, 
                           Color.SlateGray, Color.Blue,
                                 Color.Pink, Color.Purple, Color.PowderBlue};
        private float rotation = 0f;

        public Planets(
            int screenWidth,
            int screenHeight,
            int planetsCount,
            Vector2 planetVelocity,
            Texture2D texture)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            for (int x = 0; x < planetsCount; x++)
            {
                planets.Add(new Sprite(
                    new Vector2(rand.Next(0, screenWidth),
                        rand.Next(0, screenHeight)),
                    texture,
                    SpriteCreators.spriteSourceRectangles["planet (12)"],
                    planetVelocity));
                Color planetColor = colors[rand.Next(0, colors.Count())];
                planetColor *= (float)(rand.Next(30, 80) / 100f); 
                
                //planets[planets.Count() - 1].TintColor = planetColor;
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (Sprite planet in planets)
            {
                planet.Update(gameTime);
                if (planet.Location.Y > screenHeight)
                {
                    List<KeyValuePair<string,Rectangle>> rects = SpriteCreators.spriteSourceRectangles.ToList();
                    planet.SetNewFrame(rects[rand.Next(0, rects.Count)].Value);

                    planet.Location = new Vector2(rand.Next(0, screenWidth), -planet.BoundingBoxRect.Height);
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Sprite planet in planets)
            {
                float rot = planet.Rotation;
                planet.Draw(spriteBatch);

                planet.Rotation = rotation;
                planet.Draw(spriteBatch);

                planet.Rotation = rot;
                rotation += 0.0005f;
            }
        }

    }
}
