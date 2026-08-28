using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SoftProject.Input;
using SoftProject.Levels;
using System;
using System.Collections.Generic;
using TiledCS;

namespace SoftProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Player player;

        //private TiledMap map;
        //private Texture2D tileSetTexture;
        //private Dictionary<int, TiledTileset> tilesets;
        //private Texture2D debugTexture;
        private LevelManager levelManager;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        //private void DrawMap()
        //{
        //    int tileWidth = 16;
        //    int tileHeight = 16;
        //    int tileSetColumns = 84;

        //    foreach (var layer in map.Layers)
        //    {
        //        if (layer.type != TiledLayerType.TileLayer)
        //            continue;

        //        for (int i = 0; i < layer.data.Length; i++)
        //        {
        //            int gid = layer.data[i];

        //            if (gid == 0)
        //                continue;

        //            int tileIndex = gid - 1;

        //            int sourceX = (tileIndex % tileSetColumns) * tileWidth;
        //            int sourceY = (tileIndex / tileSetColumns) * tileHeight;

        //            int mapX = (i % map.Width) * tileWidth;
        //            int mapY = (i / map.Width) * tileHeight;

        //            Rectangle sourceRectangle = new Rectangle(
        //                sourceX,
        //                sourceY,
        //                tileWidth,
        //                tileHeight
        //            );

        //            Rectangle destinationRectangle = new Rectangle(
        //                mapX,
        //                mapY,
        //                tileWidth,
        //                tileHeight
        //            );

        //            _spriteBatch.Draw(tileSetTexture, destinationRectangle, sourceRectangle, Color.White);
        //        }
        //    }
        //}

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            InitializeGameObject();
            // TODO: use this.Content to load your game content here

            //map = new TiledMap("Maps/Level1.tmx");
            //tilesets = map.GetTiledTilesets(Content.RootDirectory + "/");
            //tileSetTexture = Content.Load<Texture2D>("main_lev_buildA");

            //debugTexture = new Texture2D(GraphicsDevice, 1, 1);
            //debugTexture.SetData(new[] { Color.White });
            levelManager = new LevelManager(this.Content, GraphicsDevice);
            levelManager.LoadLevel(1);
        }

        //private void DrawCollisionDebug()
        //{
        //    foreach (var layer in map.Layers)
        //    {
        //        if (layer.name != "Collision")
        //            continue;

        //        foreach (var obj in layer.objects)
        //        {
        //            Rectangle rectangle = new Rectangle(
        //                (int)obj.x,
        //                (int)obj.y,
        //                (int)obj.width,
        //                (int)obj.height
        //            );

        //            _spriteBatch.Draw(
        //                debugTexture,
        //                rectangle,
        //                Color.White * 0.4f
        //            );
        //        }
        //    }
        //}

        private void InitializeGameObject()
        {
            player = new Player(new KeyboardReader());
            player.LoadContent(this.Content);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkViolet);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            //DrawMap();
            //DrawCollisionDebug();
            levelManager.currentLevel?.Draw(_spriteBatch);
            player.Draw(_spriteBatch);

            _spriteBatch.End();

            


            base.Draw(gameTime);
        }
    }
}
