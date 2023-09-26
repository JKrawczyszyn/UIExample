using Cysharp.Threading.Tasks;
using Entry.Controllers;
using UnityEngine;
using Zenject;

namespace Entry
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject]
        private GameFlowController gameFlowController;

        public void Start()
        {
            Debug.Log($"Start '{GetType().Name}'.");

            gameFlowController.LoadMenu().Forget();
        }
    }
}
