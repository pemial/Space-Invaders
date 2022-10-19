using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class StartMenu : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private InputAction _startGameAction;
        
        private void Awake()
        {
            _startGameAction = GetComponent<PlayerInput>().actions["Start"];
            _startGameAction.started += StartGame;
        }

        private void OnEnable()
        {
            _startGameAction.Enable();
        }

        private void OnDisable()
        {
            _startGameAction.Disable();
        }

        private void OnDestroy()
        {
            _startGameAction.started -= StartGame;
        }

        private void StartGame(InputAction.CallbackContext context)
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}