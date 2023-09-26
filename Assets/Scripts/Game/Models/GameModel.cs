using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Models
{
    public class GameModel
    {
        private ShooterModel[] shooters;

        public void CreateShooters(int level, Func<ShooterModel> shooterGetter)
        {
            shooters = new ShooterModel[level];

            for (var i = 0; i < shooters.Length; i++)
                shooters[i] = shooterGetter();
        }

        public IEnumerable<ShooterModel> GetShootersToCreate()
        {
            foreach (ShooterModel model in shooters)
                if (model != null && Time.time >= model.SpawnTime)
                    yield return model;
        }

        public IEnumerable<Vector2> GetShooterPositions()
        {
            foreach (ShooterModel model in shooters)
                if (model != null)
                    yield return model.Position;
        }

        public IEnumerable<ShooterModel> GetActiveShooters()
        {
            foreach (ShooterModel model in shooters)
                if (model is { Active: true })
                    yield return model;
        }
    }
}
