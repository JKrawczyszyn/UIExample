using UnityEngine;
using UnityEngine.UI;

namespace Entry.Views
{
    public class DpadButton : MenuButton
    {
        [SerializeField]
        private Image dpadImage;

        public override void SetActive(bool value)
        {
            base.SetActive(value);

            dpadImage.gameObject.SetActive(value);
        }
    }
}
