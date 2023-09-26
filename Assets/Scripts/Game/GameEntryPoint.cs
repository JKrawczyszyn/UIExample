using Game.Controllers;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameEntryPoint : MonoBehaviour
    {
        [Inject]
        private GameController gameController;

        public void Start()
        {
            Debug.Log($"Start '{GetType().Name}'.");

            gameController.Initialize();
        }
    }
}
