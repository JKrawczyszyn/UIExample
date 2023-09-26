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

        private readonly Dictionary<int, Shooter> shooters = new();

        private void Awake()
        {
            controller.OnCreateShooter += CreateShooter;
            controller.OnUpdateShooter += UpdateShooter;
        }

        private void CreateShooter(ShooterModel model)
        {
            Shooter instance = Instantiate(config.ShooterPrefab, model.Position, Quaternion.identity, parent);
            shooters.Add(model.Id, instance);
        }

        private void UpdateShooter(ShooterModel model)
        {
            Assert.IsTrue(shooters.ContainsKey(model.Id));

            shooters[model.Id].UpdateFromModel(model);
        }

        private void OnDestroy()
        {
            controller.OnCreateShooter -= CreateShooter;
            controller.OnUpdateShooter -= UpdateShooter;
        }
    }
}
