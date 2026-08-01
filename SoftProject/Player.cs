using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using SoftProject.Animation;
using SoftProject.Input;
using SoftProject.Interfaces;
using System;

namespace SoftProject
{
    public class Player : IGameObject
    {
        Texture2D playerTexture;
        Animations animatie;
        private Vector2 positie;
        private Vector2 snelheid;

        IInputReader inputReader;
        
        public Player(Texture2D texture, IInputReader reader)
        {
            playerTexture = texture;
            animatie = new Animations();
            animatie.AddFrame(new AnimationFrame(new Rectangle(0, 0, 280, 385)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(280, 0, 280, 385)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(560, 0, 280, 385)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(840, 0, 280, 385)));
            animatie.AddFrame(new AnimationFrame(new Rectangle(1120, 0, 280, 385)));
            positie = new Vector2(10, 10);
            snelheid = new Vector2(10, 1);
            this.inputReader = reader;

        }

        public void Update()
        {
            Move();
            animatie.Update();
        }

        private void Move()
        {
            var direction = inputReader.ReadInput();
            direction *= 4;
            positie += direction;
        }

        //private Vector2 Limit(Vector2 v, float max)
        //{
        //    if (v.Length() > max)
        //    {
        //        var ratio = max / v.Length();
        //        v.X *= ratio;
        //        v.Y *= ratio;
        //    }
        //    return v;
        //}

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, positie, animatie.CurrentFrame.SourceRectangle, Color.White);
        }
    }
}
