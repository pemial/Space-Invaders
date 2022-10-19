using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _transform;

    public float speed;
    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        _transform.position += new Vector3(0, speed, 0);
    }
}
