using UnityEngine;
using UnityEngine.InputSystem;
public class InputManager : MonoBehaviour
{
    public static Vector2 Movement;
    public static bool isSprinting;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private InputAction _sprintAction;
    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];
        _sprintAction = _playerInput.actions["Sprint"];
    }

    private void Update()
    {
        Movement = _moveAction.ReadValue<Vector2>();
        isSprinting = _sprintAction.IsPressed();
    }
}
