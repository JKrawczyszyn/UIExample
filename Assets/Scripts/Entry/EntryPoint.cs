using Entry.Controllers;
using UnityEngine;
using Zenject;

namespace Entry
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject]
        private FlowController flowController;
        
        [Inject]
        public void Construct()
        {
            Debug.Log($"Start '{GetType().Name}'.");

            flowController.LoadMenu();
        }
    }
}
