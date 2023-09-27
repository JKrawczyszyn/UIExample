using Game.Models;
using UnityEngine;

namespace Game.Views
{
    public class Bullet : MonoBehaviour
    {
        private BulletModel model;

        private Vector3 forward;
        
        public int ParentId => model.ParentId;

        public void Initialize(BulletModel model)
        {
            this.model = model;

            transform.position = model.StartPosition;
            transform.rotation = Quaternion.Euler(0, 0, model.Angle);

            forward = transform.up;
        }

        public void Move()
        {
            transform.position += forward * (Time.deltaTime * model.Speed);
        }
    }
}
