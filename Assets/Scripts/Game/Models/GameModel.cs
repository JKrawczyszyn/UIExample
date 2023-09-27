using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Models
{
    public class GameModel
    {
        private List<ShooterModel> shooters;
        public IEnumerable<ShooterModel> Shooters => shooters;

        public void CreateShooters(int level, Func<ShooterModel> shooterGetter)
        {
            shooters = new List<ShooterModel>(level);

            for (var i = 0; i < level; i++)
                shooters.Add(shooterGetter());
        }


        public IEnumerable<Vector2> GetActiveShootersPositions()
        {
            foreach (ShooterModel model in shooters)
                if (model.Active)
                    yield return model.Position;
        }

        public void RemoveShooter(ShooterModel model)
        {
            shooters.Remove(model);
        }

        public int ShootersCount() => shooters.Count;
    }
}
