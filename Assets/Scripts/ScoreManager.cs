using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int _score;
    private int _highscore;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _highscore = PlayerPrefs.GetInt("highscore");
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("highscore", _highscore);
    }

    public void AddScore(int addScore)
    {
        _score += addScore;
        if (_score > _highscore)
        {
            _highscore = _score;
        }
    }

    public void Clear()
    {
        _score = 0;
    }

    public int GetScore()
    {
        return _score;
    }
    
    public int GetHighscore()
    {
        return _highscore;
    }
}