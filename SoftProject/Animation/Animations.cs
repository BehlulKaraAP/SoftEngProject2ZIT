using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftProject.Animation
{
    public class Animations
    {
        public AnimationFrame CurrentFrame { get; set; }
        public bool IsComplete { get; private set; }

        private List<AnimationFrame> frames;

        private int counter;
        private int timer;
        private int animationSpeed = 7;
        public bool IsLooping { get; set; } = true;

        public Animations()
        {
            frames = new List<AnimationFrame>();

        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            CurrentFrame = frames[0];
        }

        public void Reset()
        {
            counter = 0;
            timer = 0;
            IsComplete = false;
            CurrentFrame = frames[0];
        }

        public void Update()
        {
            timer++;
            if (timer >= animationSpeed)
            {
                CurrentFrame = frames[counter];
                counter++;

                if (counter >= frames.Count)
                {
                    if (IsLooping)
                    {
                        counter = 0;

                    }
                    else
                    {
                        counter = frames.Count - 1;
                    }
                    IsComplete = true;
                }
                timer = 0;
            }
        }
    }
}
