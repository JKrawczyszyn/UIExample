using Cysharp.Threading.Tasks;
using Entry.Controllers;
using UnityEngine;
using Zenject;

namespace Entry
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject]
        private Config config;
        
        [Inject]
        private GameFlowController gameFlowController;

        public void Start()
        {
            Debug.Log($"Start '{GetType().Name}'.");

            Time.timeScale = config.timeScale;
            
            gameFlowController.LoadMenu().Forget();
        }
    }
}
