using UnityEngine;

namespace PowerUps
{
    public class SpeedUpPowerUp : PowerUp
    {
        public override void PickUp(GameObject picker)
        {
            picker.GetComponent<Player>().SpeedUp();
        }
    }
}