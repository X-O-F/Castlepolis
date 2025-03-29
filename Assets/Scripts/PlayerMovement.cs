using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _movement;
    
    private Rigidbody2D _rb;
    private Animator _animator;

    private const string _HORIZONTAL = "Horizontal";
    private const string _VERTICAL = "Vertical";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        _rb.linearVelocity = _movement * _moveSpeed;

        _animator.SetFloat(_HORIZONTAL, _movement.x);
        _animator.SetFloat(_VERTICAL, _movement.y);
    }
}
