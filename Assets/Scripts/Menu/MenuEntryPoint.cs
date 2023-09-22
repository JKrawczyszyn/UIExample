using UnityEngine;
using Zenject;

namespace Menu
{
    public class MenuEntryPoint : MonoBehaviour
    {
        [Inject]
        public void Construct()
        {
            Debug.Log($"Start '{GetType().Name}'.");
        }
    }
}
