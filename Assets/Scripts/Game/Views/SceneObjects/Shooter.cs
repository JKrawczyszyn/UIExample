using System;
using Game.Models;
using UnityEngine;
using UnityEngine.Assertions;

namespace Game.Views
{
    public class Shooter : MonoBehaviour
    {
        public event Action<ShooterModel, Bullet> OnHit;

        [SerializeField]
        private GameObject[] livesIndicators;

        private ShooterModel model;

        public void Initialize(ShooterModel model)
        {
            this.model = model;

            UpdateLives(model.Lives);
        }

        private void UpdateLives(int lives)
        {
            for (var i = 0; i < livesIndicators.Length; i++)
                livesIndicators[i].SetActive(i < lives);
        }

        public void UpdateFromModel(ShooterModel model)
        {
            transform.position = model.Position;
            transform.rotation = Quaternion.Euler(0, 0, model.Angle);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            bool success = collider.TryGetComponent(out Bullet bullet);
            
            Assert.IsTrue(success);
            
            if (bullet.ParentId == model.Id)
                return;
            
            OnHit?.Invoke(model, bullet);
        }
    }
}
