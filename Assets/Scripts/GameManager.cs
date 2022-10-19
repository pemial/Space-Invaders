using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private ScoreManager _scoreManager;
    
    private Player _player;
    
    private int _level;
    public GameObject levelPrefab;
    private GameObject _currentLevel;
    private readonly Vector3 _levelPosition = new Vector3(0, 0, 0);

    private const float StartSpeed = 0.02f;
    private const float AddSpeedPerLevel = 0.002f;
    private const float StartSpeedMultiplier = 1.03f;
    private const float AddSpeedMultiplierPerLevel = 0.003f;
    private float _bulletRandomness;

    private void Awake()
    {
        _scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
        DontDestroyOnLoad(gameObject);
    }

    public void StartGame()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _level = 0;
        _bulletRandomness = 3000;
        _scoreManager.Clear();
        StartLevel();
    }

    private void StartLevel()
    {
        _currentLevel = Instantiate(levelPrefab, _levelPosition, Quaternion.identity);
        var newLevel = _currentLevel.GetComponent<Level>();
        newLevel.SetParameters(StartSpeed + AddSpeedPerLevel * _level,
                               StartSpeedMultiplier + AddSpeedMultiplierPerLevel * _level,
                               (int)_bulletRandomness);
    }

    private void EndLevel()
    {
        Destroy(_currentLevel.gameObject);
    }

    public void EndGame()
    {
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
    
    public void NextLevel()
    {
        EndLevel();
        ++_level;
        _bulletRandomness *= 0.8f;
        _player.AddLife();
        var bullets = GameObject.FindGameObjectsWithTag("PlayerBullet");
        foreach (var bullet in bullets)
        {
            Destroy(bullet);
        }
        StartLevel();
    }

    public int GetLevel()
    {
        return _level;
    }
}