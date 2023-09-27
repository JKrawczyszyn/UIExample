using System.Collections.Generic;
using Game.Controllers;
using Game.Models;
using UnityEngine;
using UnityEngine.Assertions;
using Zenject;

namespace Game.Views
{
    public class ShootersView : MonoBehaviour
    {
        [SerializeField]
        private Transform parent;

        [Inject]
        private GameViewConfig config;

        [Inject]
        private GameController controller;

        [Inject]
        private BulletsView bulletsView;
        
        private readonly Dictionary<int, Shooter> shooters = new();

        private void Awake()
        {
            controller.OnCreateShooter += CreateShooter;
            controller.OnDestroyShooter += DestroyShooter;
            controller.OnUpdateShooter += UpdateShooter;
        }

        private void CreateShooter(ShooterModel model)
        {
            Shooter instance = Instantiate(config.ShooterPrefab, model.Position, Quaternion.identity, parent);
            instance.Initialize(model);
            instance.OnHit += ShooterHit;

            shooters.Add(model.Id, instance);
        }

        private void DestroyShooter(ShooterModel model)
        {
            Assert.IsTrue(shooters.ContainsKey(model.Id));

            Shooter shooter = shooters[model.Id];
            shooter.OnHit -= ShooterHit;
            Destroy(shooter.gameObject);

            shooters.Remove(model.Id);
        }

        private void UpdateShooter(ShooterModel model)
        {
            Assert.IsTrue(shooters.ContainsKey(model.Id));

            shooters[model.Id].UpdateFromModel(model);
        }

        private void ShooterHit(ShooterModel model, Bullet bullet)
        {
            controller.ShooterHit(model);
            
            bulletsView.RemoveBullet(bullet);
        }

        private void OnDestroy()
        {
            controller.OnCreateShooter -= CreateShooter;
            controller.OnDestroyShooter -= DestroyShooter;
            controller.OnUpdateShooter -= UpdateShooter;
        }
    }
}
