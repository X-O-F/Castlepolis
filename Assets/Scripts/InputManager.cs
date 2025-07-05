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

    public GameObject player;
    private Rigidbody2D playerRb;

    [SerializeField] private MenuController pauseMenu;

    private bool lastPauseState = false;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _sprintAction = _playerInput.actions["Sprint"];
        _openMenuAction = _playerInput.actions["OpenMenu"];
        _openMenuAction.performed += ctx => OnOpenMenuPressed();

        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody2D>();
            if (playerRb == null)
            {
                Debug.LogWarning("Player Rigidbody2D not found!");
            }
        }
        else
        {
            Debug.LogWarning("Player GameObject is not assigned!");
        }
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
        // Update Rigidbody body type based on pause state, but only when it changes
        if (lastPauseState != isGamePaused)
        {
            lastPauseState = isGamePaused;
            if (playerRb != null)
            {
                if (isGamePaused)
                {
                    playerRb.bodyType = RigidbodyType2D.Kinematic;
                    playerRb.linearVelocity = Vector2.zero;
                }
                else
                {
                    playerRb.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }

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
