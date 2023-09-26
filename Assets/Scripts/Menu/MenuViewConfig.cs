using UnityEngine;

namespace Menu
{
    [CreateAssetMenu(fileName = "MenuViewConfig", menuName = "ScriptableObjects/MenuViewConfig")]
    public class MenuViewConfig : ScriptableObject
    {
        [SerializeField]
        private Color[] levelColors;

        private int currentColorIndex;

        public void Initialize()
        {
            currentColorIndex = 0;
        }

        public Color NextColor() => levelColors[currentColorIndex++ % levelColors.Length];
    }
}
