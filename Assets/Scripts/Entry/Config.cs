using UnityEngine;

namespace Entry
{
    [CreateAssetMenu(fileName = "Config", menuName = "ScriptableObjects/Config")]
    public class Config : ScriptableObject
    {
        public int[] levels;
    }
}
