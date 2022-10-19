using UnityEngine;

public class Explosion : MonoBehaviour
{
        private const float Lifetime = 0.2f;
        private float _startLifetime;

        private void Start()
        {
                _startLifetime = Time.time;
        }

        private void FixedUpdate()
        {
                if (Time.time > _startLifetime + Lifetime)
                {
                        Destroy(gameObject);
                }
        }
}
