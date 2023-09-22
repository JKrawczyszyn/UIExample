using UnityEngine;
using Zenject;

namespace Game
{
    public class GameEntryPoint : MonoBehaviour
    {
        [Inject]
        public void Construct()
        {
            Debug.Log($"Start '{GetType().Name}'.");
        }
    }
}
