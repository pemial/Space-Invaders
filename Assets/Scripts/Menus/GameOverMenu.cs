using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menus
{
    public class GameOverMenu : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private InputAction _quitAction;
        private InputAction _restartAction;

        private ScoreManager _scoreManager;

        private Text _text;

        private void Awake()
        {
            _scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
            _playerInput = GetComponent<PlayerInput>();
            _restartAction = _playerInput.actions["Restart"];
            _quitAction = _playerInput.actions["Quit"];
            _restartAction.started += Restart;
            _quitAction.started += Quit;
        }

        void Start()
        {
            _text = GetComponent<Text>();
            _text.text = "GAME OVER\n" +
                         "Score: " + _scoreManager.GetScore() + "\n" +
                         "Highscore: " + _scoreManager.GetHighscore() + "\n" +
                         "To restart press r\n" +
                         "To quit press q";
        }

        private void OnEnable()
        {
            _restartAction.Enable();
            _quitAction.Enable();
        }
        
        private void OnDisable()
        {
            _restartAction.Disable();
            _quitAction.Disable();
        }

        private void OnDestroy()
        {
            _restartAction.started -= Restart;
            _quitAction.started -= Quit;
        }

        private void Quit(InputAction.CallbackContext context)
        {
            Application.Quit();
        }

        private void Restart(InputAction.CallbackContext context)
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}