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

    }
}
