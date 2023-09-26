using UnityEngine;

namespace Game.Models
{
    public class BulletModel
    {
        public Vector2 StartPosition { get; private set; }
        public int Angle { get; private set; }
        public float Speed { get; private set; }
        public bool Active { get; set; }

        public BulletModel(Vector2 startPosition, int angle, float speed)
        {
            StartPosition = startPosition;
            Angle = angle;
            Speed = speed;
            Active = true;
        }

        public bool IsOnScreen(Vector2 position) =>
            position.x > -10 && position.x < 10 && position.y > -5 && position.y < 5;
    }
}
