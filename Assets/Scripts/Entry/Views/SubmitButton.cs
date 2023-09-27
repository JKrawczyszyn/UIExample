using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;
using Zenject;

namespace Entry.Views
{
    public class SubmitButton : MonoBehaviour
    {
        [SerializeField]
        private Button button;

        [Inject]
        private InputSystemUIInputModule inputModule;

        private void Awake()
        {
            inputModule.submit.action.performed += SubmitActionPerformed;
        }

        private void SubmitActionPerformed(InputAction.CallbackContext _)
        {
            button.onClick.Invoke();
        }

        private void OnDestroy()
        {
            inputModule.submit.action.performed -= SubmitActionPerformed;
        }
    }
}
