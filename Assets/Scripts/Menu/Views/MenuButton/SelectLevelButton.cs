using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Menu.Views
{
    public class SelectLevelButton : MenuButton
    {
        [SerializeField]
        private Image boxImage;

        [SerializeField]
        private Animator animator;

        public GameObject ButtonGameObject => button.gameObject;

        public void Initialize(string text, Color boxColor)
        {
            base.Initialize(text);

            boxImage.color = boxColor;
        }

        public void SetSelected(bool value)
        {
            animator.SetBool(Hashes.Selected, value);
        }
    }
}
