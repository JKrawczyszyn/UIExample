using Entry;
using Game.Controllers;
using UnityEngine;
using Zenject;

namespace Game.Models
{
    public class GameModelFactory
    {
        [Inject]
        private Config config;

        [Inject]
        private ScenePositionHelper positionProvider;

        [Inject]
        private IdProvider idProvider;

        private GameModel gameModel;

        public GameModel Get(int level)
        {
            gameModel = new GameModel();

            gameModel.CreateShooters(level, GetStartShooterModel);

            return gameModel;
        }

        private ShooterModel GetStartShooterModel()
        {
            int id = idProvider.Get();
            Vector2 position = GetFreePosition();
            float angle = config.Angle;
            int lives = config.Lives;
            float nextTurnTime = Time.time + config.TurnTime;
            float spawnTime = Time.time;
            float nextShootTime = Time.time + config.ShootTime;

            return new ShooterModel(id, position, angle, lives, nextTurnTime, spawnTime, nextShootTime);
        }

        public Vector2 GetFreePosition() => positionProvider.GetFreePosition(gameModel.GetActiveShootersPositions());

        public BulletModel GetBulletModel(ShooterModel model) => new(model.Position, model.Angle, config.BulletSpeed, model.Id);
    }
}
