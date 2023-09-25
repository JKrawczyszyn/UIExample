using Cysharp.Threading.Tasks;
using Entry.Controllers;
using UnityEngine;
using Zenject;

namespace Entry
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject]
        private FlowController flowController;

        public void Start()
        {
            Debug.Log($"Start '{GetType().Name}'.");

            flowController.LoadMenu().Forget();
        }
    }
}
