using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;
    public static bool isSprinting;
    public static bool isGamePaused = false;

    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _sprintAction;
    private InputAction _openMenuAction;

    [SerializeField] private MenuController pauseMenu;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _sprintAction = _playerInput.actions["Sprint"];
        _openMenuAction = _playerInput.actions["OpenMenu"];
        _openMenuAction.performed += ctx => OnOpenMenuPressed();
    }

    private void OnEnable()
    {
        _openMenuAction?.Enable();
    }

    private void OnDisable()
    {
        _openMenuAction?.Disable();
    }

    private void Update()
    {
        if (!isGamePaused)
        {
            Movement = _moveAction.ReadValue<Vector2>();
            isSprinting = _sprintAction.IsPressed();
        }
        else
        {
            Movement = Vector2.zero;
            isSprinting = false;
        }
    }

    private void OnOpenMenuPressed()
    {
        if (pauseMenu != null)
        {
            MusicManager.instance.PlayPopSFX();
            pauseMenu.TogglePause();
        }
    }

    public static void ResetInputState()
    {
        isGamePaused = false;
        Movement = Vector2.zero;
        isSprinting = false;
    }
}
