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

        private Vector3 screenMin;
        private Vector3 screenMax;

        [Inject]
        public void Construct()
        {
            screenMin = camera.ScreenToWorldPoint(new Vector3(0, 0, 0));
            screenMax = camera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        }

        public Vector2 GetFreePosition(IEnumerable<Vector2> existingPositions)
        {
            float radius = config.ShooterRadius;

            var margins = new Vector2(radius, radius);

            var maxAttempts = 100;

            Vector2[] existingPositionsArray = existingPositions as Vector2[] ?? existingPositions.ToArray();

            Vector2 position;

            do
            {
                position = GetRandomPosition(margins);

                maxAttempts--;

                if (maxAttempts == 0)
                    break;
            } while (IsPositionOccupied(position, existingPositionsArray, radius));

            return position;
        }

        private Vector2 GetRandomPosition(Vector2 margins)
        {
            Vector3 min = screenMin + (Vector3)margins;
            Vector3 max = screenMax - (Vector3)margins;

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

        public bool IsOnScreen(Vector2 position) => position.x > screenMin.x && position.x < screenMax.x
            && position.y > screenMin.y && position.y < screenMax.y;
    }
}
