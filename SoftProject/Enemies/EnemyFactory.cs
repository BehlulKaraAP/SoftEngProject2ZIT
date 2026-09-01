using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SoftProject.Levels;
using SoftProject.Animation;

using SoftProject.Physics;
using SoftProject.Enemies.EnemyStates;
using Microsoft.Xna.Framework;
namespace SoftProject.Enemies
{
    public class EnemyFactory
    {
        private ContentManager content;
        private GraphicsDevice graphics;

        public EnemyFactory(ContentManager content, GraphicsDevice graphics)
        {
            this.content = content;
            this.graphics = graphics;
        }

        public Enemy CreateSkeleton(Player target, Level level, Vector2 startPosition)
        {
            Enemy skeleton = new Enemy(target, level, graphics);
            skeleton.Position = startPosition;

            skeleton.Physics = new PhysicsComponent(20, 100, 60, 45);
            skeleton.SpriteDrawOffset = 55;
            skeleton.AddAnimation("Patrol", new SpriteAnimator(content.Load<Texture2D>("Enemy1Patrol"), 128, 96));
            skeleton.ChangeState(new PatrolState());
            return skeleton;
        }

        public Enemy CreateSkeletonWithShield(Player target, Level level, Vector2 startPosition)
        {
            Enemy skeletonShield = new Enemy(target, level, graphics);
            skeletonShield.Position = startPosition;

            skeletonShield.Physics = new PhysicsComponent(20, 100, 60, 45);
            skeletonShield.SpriteDrawOffset = 55;
            skeletonShield.AddAnimation("Patrol", new SpriteAnimator(content.Load<Texture2D>("Enemy2Patrol"), 128, 96));
            skeletonShield.ChangeState(new PatrolState());
            return skeletonShield;

        }

        public Enemy CreateSkeletonWithSpear(Player target, Level level, Vector2 startPosition)
        {
            Enemy skeletonSpear = new Enemy(target, level, graphics);
            skeletonSpear.Position = startPosition;
            skeletonSpear.Physics = new PhysicsComponent(20, 100, 60, 45);
            skeletonSpear.SpriteDrawOffset = 55;
            skeletonSpear.AddAnimation("Patrol", new SpriteAnimator(content.Load<Texture2D>("Enemy3Patrol"), 128, 96));
            skeletonSpear.ChangeState(new PatrolState());
            return skeletonSpear;
        }

        public Enemy CreateSkeletonArcher(Player target, Level level, Vector2 startPosition)
        {
            Enemy SkeletonArcher = new Enemy(target, level, graphics);
            SkeletonArcher.Position = startPosition;
            SkeletonArcher.Physics = new PhysicsComponent(35, 100, 60, 45);
            SkeletonArcher.SpriteDrawOffset = 35;
            SkeletonArcher.AddAnimation("Patrol", new SpriteAnimator(content.Load<Texture2D>("EnemyPatrol4"), 128, 96));
            SkeletonArcher.ChangeState(new PatrolState());
            return SkeletonArcher;
        }

    }
}
