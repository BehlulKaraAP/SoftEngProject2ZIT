using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SoftProject.Animation;
using SoftProject.Enemies.EnemyStates;
using SoftProject.Interfaces;
using SoftProject.Levels;
using SoftProject.Physics;
using System.Collections.Generic;

namespace SoftProject.Enemies
{
    public class Enemy : IGameObject
    {
        private Texture2D debugTexture;
        public Vector2 Position;
        public PhysicsComponent Physics { get; set; }
        public Player TargetPlayer { get; private set; }
        public bool FacingLeft = false;
        public IAttackBehaviour AttackBehavior { get; set; }
        public int SpriteDrawOffset { get; set; } = 0;

        private Dictionary<string, SpriteAnimator> animators = new Dictionary<string, SpriteAnimator>();
        public SpriteAnimator CurrentAnimator { get; private set; }
        private IEnemyState currentState;

        public int Health { get; set; }
        public bool IsDead => Health <= 0;
        public bool AnimationFinished { get; set; } = false;
        public Level Level { get; set; }

        public Enemy(Player player, Level level, GraphicsDevice graphicsDevice)
        {
            TargetPlayer = player;
            Level = level;

            debugTexture = new Texture2D(graphicsDevice, 1, 1);
            debugTexture.SetData(new[] { Color.Red });
        }
        public void AddAnimation(string name, SpriteAnimator animator)
        {
            animators.Add(name, animator);
        }
        public void PlayAnimation(string animationName)
        {
            CurrentAnimator = animators[animationName];
        }
        public void ChangeState(IEnemyState newState)
        {
            currentState = newState;
            currentState.Enter(this);
        }

        public void Update(GameTime gameTime)
        {
            Physics.ApplyPhysics(ref Position, Level.CollisionRectangles);

            if (IsDead && !(currentState is DeathState))
            {
                ChangeState(new DeathState());
            }

            currentState.Update(this, gameTime);
            CurrentAnimator?.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 drawPosition = Position;

            if (FacingLeft)
            {
                drawPosition.X -= SpriteDrawOffset;
            }
            CurrentAnimator?.Draw(spriteBatch, drawPosition, FacingLeft);
            //spriteBatch.Draw(
            //    debugTexture,
            //    Physics.CollisionBox,
            //    Color.Red * 0.5f
            //);
        }
    }
}
