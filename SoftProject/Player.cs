using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using SharpDX.MediaFoundation;
using SoftProject.Animation;
using SoftProject.Input;
using SoftProject.Interfaces;
using SoftProject.Movement;
using SoftProject.PlayerState;
using SoftProject.PlayerStates;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;

namespace SoftProject
{
    public class Player : IGameObject
    {
        private Vector2 positie;
        private Vector2 snelheid;
        private bool facingLeft = false;
        IPlayerState currentState;
        public SpriteAnimator CurrentAnimator { get; private set; }
        private Dictionary<string, SpriteAnimator> _animators = new Dictionary<string, SpriteAnimator>();

        public IInputReader InputReader { get; set; }
        public Player(IInputReader reader)
        {
            positie = new Vector2(10, 10);
            snelheid = new Vector2(10, 1);
            this.InputReader = reader;
        }
        public void LoadContent(ContentManager content)
        {
            _animators.Add("Idle", new SpriteAnimator(content.Load<Texture2D>("Idle"), 128, 64));
            _animators.Add("Run", new SpriteAnimator(content.Load<Texture2D>("Run"), 128, 64));
            _animators.Add("Attack", new SpriteAnimator(content.Load<Texture2D>("Attacks"), 128, 64));

            ChangeState(new IdleState());
        }
        public void PlayAnimation(string animationName)
        {
            CurrentAnimator = _animators[animationName];
        }
        public void ChangeState(IPlayerState newState)
        {
            currentState = newState;
            currentState.Enter(this);
        }
        public void Update(GameTime gameTime)
        {
            Move();
            currentState.Update(this);
            CurrentAnimator?.Update();
        }

        private void Move()
        {
            var direction = InputReader.ReadInput();

            if(direction.X < 0)
            {
                facingLeft = true;
            }
            else if (direction.X > 0)
            {
                facingLeft = false;
            }

            direction *= 4;
            positie += direction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentAnimator?.Draw(spriteBatch, positie, facingLeft);
        }
    }
}
