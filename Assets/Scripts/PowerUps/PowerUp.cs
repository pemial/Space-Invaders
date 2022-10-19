using UnityEngine;

namespace PowerUps
{
    public abstract class PowerUp : MonoBehaviour, IPickUpable
    {
        public virtual void PickUp(GameObject picker)
        {
        }
    }
}
