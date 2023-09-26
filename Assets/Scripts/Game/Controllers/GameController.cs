using System;
using Entry;
using Entry.Models;
using Game.Models;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class GameController : ITickable
    {
        public event Action<ShooterModel> OnCreateShooter;
        public event Action<ShooterModel> OnUpdateShooter;
        public event Action<BulletModel> OnCreateBullet;

        [Inject]
        private GameState gameState;

        [Inject]
        private Config config;

        [Inject]
        private GameModelFactory gameModelFactory;

        private GameModel gameModel;

        public void Initialize()
        {
            CreateShooters(gameState.Level);
        }

        private void CreateShooters(int level)
        {
            gameModel = gameModelFactory.Get(level);

            foreach (ShooterModel model in gameModel.GetShootersToCreate())
            {
                model.Active = true;

                OnCreateShooter?.Invoke(model);
            }
        }

        public void Tick()
        {
            foreach (ShooterModel model in gameModel.GetActiveShooters())
            {
                UpdateTurn(model);
                UpdateShoot(model);
            }
        }

        private void UpdateTurn(ShooterModel model)
        {
            if (Time.time < model.NextTurnTime)
                return;

            model.NextTurnTime = Time.time + config.TurnTime;
            model.Angle = config.Angle;

            OnUpdateShooter?.Invoke(model);
        }

        private void UpdateShoot(ShooterModel model)
        {
            if (Time.time < model.NextShootTime)
                return;

            model.NextShootTime = Time.time + config.ShootTime;

            OnCreateBullet?.Invoke(gameModelFactory.GetBulletModel(model));
        }
    }
}
