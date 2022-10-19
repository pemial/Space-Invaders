using Invaders;
using UnityEngine;

public class Level : MonoBehaviour
{
    private Transform _transform;

    private float _speed;
    private float _speedMultiplier;

    private GameManager _gameManager;

    private readonly Vector3 _horizontalTransform = new Vector3(0, -0.5f, 0);

    void Awake()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        _transform.position += new Vector3(_speed, 0, 0);
        if (transform.childCount == 0)
        {
            _gameManager.NextLevel();
        } 
    }

    public void KillOne()
    {
        _speed *= _speedMultiplier;
    }

    public void MoveRight()
    {
        if (_speed < 0)
        {
            _speed = -_speed;
            _transform.position += _horizontalTransform;
        }
    }

    public void MoveLeft()
    {
        if (_speed > 0)
        {
            _speed = -_speed;
            _transform.position += _horizontalTransform;
        }
    }

    public void SetParameters(float speed, float speedMultiplier, int bulletRandomness)
    {
        _speed = speed;
        _speedMultiplier = speedMultiplier;
        for (int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).GetComponent<Invader>().SetBulletRandomness(bulletRandomness);
        }
    }
}
