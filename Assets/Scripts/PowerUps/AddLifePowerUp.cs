using UnityEngine;

namespace PowerUps
{
    public class AddLifePowerUp : PowerUp
    {
        public override void PickUp(GameObject picker)
        {
            picker.GetComponent<Player>().AddLife();
        }
    }
}
