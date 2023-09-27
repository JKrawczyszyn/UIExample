using System.Collections.Generic;
using System.Linq;
using Entry;
using UnityEngine;
using Zenject;

namespace Game.Controllers
{
    public class ScenePositionHelper
    {
        [Inject]
        private Config config;

        [Inject]
        private Camera camera;

        private Vector2 screenMin;
        private Vector2 screenMax;
        private Vector2 shooterPositionMin;
        private Vector2 shooterPositionMax;

        [Inject]
        private void Construct()
        {
            screenMin = camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
            screenMax = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
            shooterPositionMin = screenMin + new Vector2(config.ShooterRadius, config.ShooterRadius);
            shooterPositionMax = screenMax - new Vector2(config.ShooterRadius, config.ShooterRadius);
        }

        public Vector2 GetFreePosition(IEnumerable<Vector2> existingPositions)
        {
            float margin = config.ShooterRadius;

            var maxAttempts = 100;

            Vector2[] existingPositionsArray = existingPositions as Vector2[] ?? existingPositions.ToArray();

            Vector2 position;

            do
            {
                position = GetRandomPosition(shooterPositionMin, shooterPositionMax);

                maxAttempts--;

                if (maxAttempts == 0)
                    break;
            } while (IsPositionOccupied(position, existingPositionsArray, margin));

            return position;
        }

        private Vector2 GetRandomPosition(Vector2 min, Vector2 max)
        {
            float x = Random.Range(min.x, max.x);
            float y = Random.Range(min.y, max.y);

            return new Vector2(x, y);
        }

        private bool IsPositionOccupied(Vector2 position, IEnumerable<Vector2> existingPositions, float radius)
        {
            float sqrRadius = radius * radius;

            foreach (Vector2 existingPosition in existingPositions)
                if (Vector2.SqrMagnitude(position - existingPosition) < sqrRadius)
                    return true;

            return false;
        }

        public bool IsOnScreen(Vector2 position, float margin) => position.x > screenMin.x - margin
            && position.x < screenMax.x + margin
            && position.y > screenMin.y - margin
            && position.y < screenMax.y + margin;
    }
}
