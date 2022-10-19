using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private Text _info;

    private GameManager _gameManager;
    private Player _player;
    private ScoreManager _scoreManager;
    
    private int _score;
    private int _lives;
    private int _level;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Player>();
        _gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        _scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
    }

    void Start()
    {
        _info = GetComponent<Text>();
        ChangeInfo();
    }

    private void FixedUpdate()
    {
        if (_score != _scoreManager.GetScore() ||
            _lives != _player.GetLives() ||
            _level != _gameManager.GetLevel() + 1)
        {
            ChangeInfo();
        }
    }

    private void ChangeInfo()
    {
        _score = _scoreManager.GetScore();
        _lives = _player.GetLives();
        _level = _gameManager.GetLevel() + 1;
        _info.text = "Score: " + _score + "\n" +
                     "Lives: " + _lives + "\n" +
                     "Level: " + _level;
    }
}
