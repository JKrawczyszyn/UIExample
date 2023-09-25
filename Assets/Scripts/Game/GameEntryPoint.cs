using UnityEngine;

namespace Game
{
    public class GameEntryPoint : MonoBehaviour
    {
        public void Start()
        {
            Debug.Log($"Start '{GetType().Name}'.");
        }
    }
}
