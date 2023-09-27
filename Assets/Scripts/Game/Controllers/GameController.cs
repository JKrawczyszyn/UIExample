using System;
using Cysharp.Threading.Tasks;
using Entry;
using Entry.Controllers;
using Entry.Models;
using Game.Models;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class GameController : ITickable
    {
        public event Action<ShooterModel> OnCreateShooter;
        public event Action<ShooterModel> OnDestroyShooter;
        public event Action<ShooterModel> OnUpdateShooter;
        public event Action<BulletModel> OnCreateBullet;

        [Inject]
        private GameState gameState;

        [Inject]
        private Config config;

        [Inject]
        private GameModelFactory gameModelFactory;

        [Inject]
        private GameFlowController gameFlowController;

        private GameModel gameModel;

        public void Initialize()
        {
            CreateShooters(gameState.Level);
        }

        private void CreateShooters(int level)
        {
            gameModel = gameModelFactory.Get(level);
        }

        public void Tick()
        {
            if (gameModel.ShootersCount() <= 1)
            {
                gameFlowController.LoadGameOver().Forget();

                return;
            }

            foreach (ShooterModel model in gameModel.Shooters)
            {
                if (!model.Active)
                    ProcessRespawn(model);
                else
                {
                    ProcessTurn(model);
                    ProcessShoot(model);
                }
            }
        }

        private void ProcessRespawn(ShooterModel model)
        {
            if (Time.time < model.SpawnTime)
                return;

            model.Active = true;
            model.Position = gameModelFactory.GetFreePosition();

            OnCreateShooter?.Invoke(model);
        }

        private void ProcessTurn(ShooterModel model)
        {
            if (Time.time < model.NextTurnTime)
                return;

            model.NextTurnTime = Time.time + config.TurnTime;
            model.Angle = config.Angle;

            OnUpdateShooter?.Invoke(model);
        }

        private void ProcessShoot(ShooterModel model)
        {
            if (Time.time < model.NextShootTime)
                return;

            model.NextShootTime = Time.time + config.ShootTime;

            OnCreateBullet?.Invoke(gameModelFactory.GetBulletModel(model));
        }

        public void ShooterHit(ShooterModel model)
        {
            if (!model.Active)
                return;

            model.Active = false;
            model.Lives--;
            model.SpawnTime = Time.time + config.RespawnTime;

            if (model.Lives <= 0)
                gameModel.RemoveShooter(model);

            OnDestroyShooter?.Invoke(model);
        }
    }
}
