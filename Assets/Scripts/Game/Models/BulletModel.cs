using UnityEngine;

namespace Game.Models
{
    public class BulletModel
    {
        public Vector2 StartPosition { get; private set; }
        public float Angle { get; private set; }
        public float Speed { get; private set; }
        public bool Active { get; set; }
        public int ParentId { get; private set; }

        public BulletModel(Vector2 startPosition, float angle, float speed, int parentId)
        {
            StartPosition = startPosition;
            Angle = angle;
            Speed = speed;
            Active = true;
            ParentId = parentId;
        }
    }
}
