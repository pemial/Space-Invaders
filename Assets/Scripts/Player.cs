using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamagable
{
    private Transform _transform;
    private readonly Vector3 _positionBulletSpawn = new Vector3(0, 0.6f, 0);

    private int _lives = 3;
    private GameManager _gameManager;
    public GameObject bullet;

    private float _speedMultiplier = 0.1f;
    private readonly float _speedUp = 0.02f;
    private float _speed = 0;
    private readonly Vector3 _startPosition = new Vector3(-8.5f, -4.5f, 0);

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _fireAction;
    private InputAction _pauseAction;

    private void Awake()
    {
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _fireAction = _playerInput.actions["Fire"];
        _pauseAction = _playerInput.actions["Pause"];
                
        _pauseAction.started += Pause;
        _fireAction.started += Fire;
        _moveAction.started += StartMove;
        _moveAction.canceled += EndMove;
    }

    void Start()
    {
        _transform = GetComponent<Transform>();
        _gameManager.StartGame();
    }

    private void FixedUpdate()
    {
        _transform.position += new Vector3(_speed, 0, 0);
    }

    private void OnEnable()
    {
        _moveAction.Enable();
        _fireAction.Enable();
        _pauseAction.Enable();
    }

    private void OnDisable()
    {
        _moveAction.Disable();
        _fireAction.Disable();
        _pauseAction.Disable();
    }

    private void OnDestroy()
    {
        _fireAction.started -= Fire;
        _moveAction.started -= StartMove;
        _moveAction.canceled -= EndMove;
        _pauseAction.started -= Pause;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
            other.GetComponent<IPickUpable>().PickUp(gameObject);
        }
        
        if (other.gameObject.CompareTag("InvaderBullet"))
        {
            Destroy(other.gameObject);
            ReceiveDamage();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RightBorder") || other.gameObject.CompareTag("LeftBorder"))
        {
            transform.position -= new Vector3(_speed, 0, 0);
        }
    }

    public void ReceiveDamage()
    {
        --_lives;
        _transform.position = _startPosition;
        if (_lives == 0)
        {
            _gameManager.EndGame();
        }
    }

    public int GetLives()
    {
        return _lives;
    }

    public void AddLife()
    {
        ++_lives;
    }

    public void SpeedUp()
    {
        _speedMultiplier += _speedUp;
    }

    private void Fire(InputAction.CallbackContext context)
    {
        Instantiate(bullet, _transform.position + _positionBulletSpawn, Quaternion.identity);
    }

    private void StartMove(InputAction.CallbackContext context)
    {
        _speed = context.ReadValue<Vector2>().x * _speedMultiplier;
    }
    
    private void EndMove(InputAction.CallbackContext context)
    {
        _speed = 0;
    }
    
    private void Pause(InputAction.CallbackContext context)
    {
        GetComponent<Player>().enabled = false;
        Time.timeScale = 0;
        SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
    }
}
