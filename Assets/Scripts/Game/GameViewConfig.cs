using Game.Views;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "GameViewConfig", menuName = "ScriptableObjects/GameViewConfig")]
    public class GameViewConfig : ScriptableObject
    {
        [field: SerializeField]
        public Shooter ShooterPrefab { get; private set; }

        [field: SerializeField]
        public Bullet BulletPrefab { get; private set; }
    }
}
