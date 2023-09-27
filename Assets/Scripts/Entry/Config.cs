using System.Collections.Generic;
using UnityEngine;

namespace Entry
{
    [CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config")]
    public class Config : ScriptableObject
    {
        [field: SerializeField]
        public float timeScale { get; private set; }

        [SerializeField]
        private int[] levels;
        public IEnumerable<int> Levels => levels;

        [SerializeField]
        private float angleMin, angleMax;
        public float Angle => Random.Range(angleMin, angleMax);

        [field: SerializeField]
        public int Lives { get; private set; }

        [SerializeField]
        private float turnTimeMin, turnTimeMax;
        public float TurnTime => Random.Range(turnTimeMin, turnTimeMax);

        [field: SerializeField]
        public float ShootTime { get; private set; }

        [field: SerializeField]
        public float ShooterRadius { get; private set; }

        [field: SerializeField]
        public float BulletRadius { get; private set; }

        [field: SerializeField]
        public float BulletSpeed { get; private set; }

        [field: SerializeField]
        public float RespawnTime { get; private set; }
    }
}
