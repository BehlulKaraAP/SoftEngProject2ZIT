using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiledCS;

namespace SoftProject.Levels
{
    public class Level
    {
        private TiledMap map;
        private Texture2D tileSetTexture;
        private Texture2D debugTexture;

        public Level(string mapPath, string textureName, ContentManager content, GraphicsDevice graphicsdevice)
        {
            map = new TiledMap(mapPath);

            tileSetTexture = content.Load<Texture2D>(textureName);

            debugTexture = new Texture2D(graphicsdevice, 1, 1);
            debugTexture.SetData(new[] { Color.White });
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawMap(spriteBatch);
            DrawCollisionDebug(spriteBatch);
        }

        private void DrawMap(SpriteBatch spriteBatch)
        {
            int tileWidth = 16;
            int tileHeight = 16;
            int tileSetColumns = 84;

            foreach (var layer in map.Layers)
            {
                if (layer.type != TiledLayerType.TileLayer)
                    continue;

                for (int i = 0; i < layer.data.Length; i++)
                {
                    int gid = layer.data[i];

                    if (gid == 0)
                        continue;

                    int tileIndex = gid - 1;

                    int sourceX = (tileIndex % tileSetColumns) * tileWidth;
                    int sourceY = (tileIndex / tileSetColumns) * tileHeight;

                    int mapX = (i % map.Width) * tileWidth;
                    int mapY = (i / map.Width) * tileHeight;

                    Rectangle sourceRectangle = new Rectangle(
                        sourceX,
                        sourceY,
                        tileWidth,
                        tileHeight
                    );

                    Rectangle destinationRectangle = new Rectangle(
                        mapX,
                        mapY,
                        tileWidth,
                        tileHeight
                    );

                    spriteBatch.Draw(tileSetTexture, destinationRectangle, sourceRectangle, Color.White);
                }
            }
        }

        private void DrawCollisionDebug(SpriteBatch spriteBatch)
        {
            foreach (var layer in map.Layers)
            {
                if (layer.name != "Collision")
                    continue;

                foreach (var obj in layer.objects)
                {
                    Rectangle rectangle = new Rectangle(
                        (int)obj.x,
                        (int)obj.y,
                        (int)obj.width,
                        (int)obj.height
                    );

                    spriteBatch.Draw(
                        debugTexture,
                        rectangle,
                        Color.White * 0.4f
                    );
                }
            }
        }
    }
}
