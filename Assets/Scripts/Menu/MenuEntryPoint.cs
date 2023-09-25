using Menu.Controllers;
using UnityEngine;
using Zenject;

namespace Menu
{
    public class MenuEntryPoint : MonoBehaviour
    {
        [Inject]
        private MenuController menuController;
        
        public void Start()
        {
            Debug.Log($"Start '{GetType().Name}'.");
            
            menuController.Initialize();
        }
    }
}
