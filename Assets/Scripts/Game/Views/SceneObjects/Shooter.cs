using Game.Models;
using UnityEngine;

namespace Game.Views
{
    public class Shooter : MonoBehaviour
    {
        public void UpdateFromModel(ShooterModel model)
        {
            transform.position = model.Position;
            transform.rotation = Quaternion.Euler(0, 0, model.Angle);
        }
    }
}
