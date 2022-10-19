using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Menus
{
    public class PauseMenu : MonoBehaviour
    {
        private PlayerInput _playerInput;
        private InputAction _unpauseAction;
        
        private Player _player;
        
        private void Awake()
        {
            _player = GameObject.FindWithTag("Player").GetComponent<Player>();
            _playerInput = GetComponent<PlayerInput>();
            _unpauseAction = _playerInput.actions["Unpause"];
            _unpauseAction.started += Unpause;
        }
        
        private void OnEnable()
        {
            _unpauseAction.Enable();
        }
        
        private void OnDisable()
        {
            _unpauseAction.Disable();
        }
        
        private void OnDestroy()
        {
            _unpauseAction.started -= Unpause;
        }
        
        private void Unpause(InputAction.CallbackContext context)
        {
            SceneManager.UnloadSceneAsync("PauseMenu");
            Time.timeScale = 1;
            _player.enabled = true;
        }
    }
}