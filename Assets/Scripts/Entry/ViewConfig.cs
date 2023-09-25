using UnityEngine;

namespace Entry
{
    [CreateAssetMenu(fileName = "ViewConfig", menuName = "ScriptableObjects/ViewConfig")]
    public class ViewConfig : ScriptableObject
    {
        public Color[] levelColors;

        private int current;

        public void Initialize()
        {
            current = 0;
        }
        
        public Color NextColor() => levelColors[current++ % levelColors.Length];
    }
}
