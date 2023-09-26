using System.Collections.Generic;
using UnityEngine;

namespace Entry
{
    [CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config")]
    public class Config : ScriptableObject
    {
        [SerializeField]
        private int[] levels;
        public IEnumerable<int> Levels => levels;

        [SerializeField]
        private int angleMin, angleMax;
        public int Angle => Random.Range(angleMin, angleMax);

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
        public float BulletSpeed { get; private set; }
    }
}
