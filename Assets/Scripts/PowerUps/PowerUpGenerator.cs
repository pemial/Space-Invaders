using System.Collections.Generic;
using UnityEngine;

namespace PowerUps
{
    public class PowerUpGenerator : MonoBehaviour
    {
        public List<GameObject> powerUpPrefabs;

        public void GenerateRandomPowerUp(Vector3 position)
        {
            Instantiate(powerUpPrefabs[(int)Random.Range(0, powerUpPrefabs.Count)], position, Quaternion.identity);
        }
    }
}
