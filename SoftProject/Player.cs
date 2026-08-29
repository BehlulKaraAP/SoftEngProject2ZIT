using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SoftProject.Animation;
using SoftProject.Input;
using SoftProject.Interfaces;
using SoftProject.Physics;
using SoftProject.PlayerState;
using SoftProject.PlayerStates;
using System.Collections.Generic;

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

        public PhysicsComponent Physics { get; set; }

        public IInputReader InputReader { get; set; }
        public Player(IInputReader reader)
        {
            Physics = new PhysicsComponent();
            positie = new Vector2(10, 10);
            snelheid = new Vector2(10, 1);
            this.InputReader = reader;
        }
        public void LoadContent(ContentManager content)
        {
            _animators.Add("Idle", new SpriteAnimator(content.Load<Texture2D>("Idle"), 128, 64));
            _animators.Add("Run", new SpriteAnimator(content.Load<Texture2D>("Run"), 128, 64));
            _animators.Add("Attack", new SpriteAnimator(content.Load<Texture2D>("Attacks"), 128, 64));
            _animators.Add("Jump", new SpriteAnimator(content.Load<Texture2D>("Jump"), 128, 64));

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
            Physics.ApplyPhysics(ref positie);

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

            Physics.Velocity.X = direction.X * 4;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentAnimator?.Draw(spriteBatch, positie, facingLeft);
        }
    }
}
