using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;
using Zenject;

namespace Entry.Views
{
    public class CancelButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        [Inject]
        private InputSystemUIInputModule inputModule;

        private void Awake()
        {
            inputModule.cancel.action.performed += SubmitActionPerformed;
        }

        private void SubmitActionPerformed(InputAction.CallbackContext _)
        {
            button.onClick.Invoke();
        }

        private void OnDestroy()
        {
            inputModule.cancel.action.performed -= SubmitActionPerformed;
        }
    }
}
