using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _sprintMultiplier = 1.5f; 

    private Vector2 _movement;
    private Rigidbody2D _rb;
    private Animator _animator;

    private bool _canMove = true;
    private bool _isSwinging = false;

    private const string _HORIZONTAL = "Horizontal";
    private const string _VERTICAL = "Vertical";
    private const string _IS_SPRINTING = "IsSprinting";
    private const string _LAST_HORIZONTAL = "LastHorizontal";
    private const string _LAST_VERTICAL = "LastVertical";
    private const string _SWING_SWORD = "SwingSword";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_canMove) return; // Prevent movement if character engaged in animation

        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        float speed = _moveSpeed * (InputManager.isSprinting ? _sprintMultiplier : 1f);

        _rb.linearVelocity = _movement * speed;

        _animator.SetFloat(_HORIZONTAL, _movement.x);
        _animator.SetFloat(_VERTICAL, _movement.y);
        _animator.SetBool("isSprinting", InputManager.isSprinting);

        if(_movement != Vector2.zero)
        {
            _animator.SetFloat(_LAST_HORIZONTAL, _movement.x);
            _animator.SetFloat(_LAST_VERTICAL, _movement.y);
        }
         
    }

    public void SwingSword()
    {
        if (_isSwinging) return; // Prevents multiple swings
        _isSwinging = true;
        _canMove = false;

        _animator.SetTrigger(_SWING_SWORD);
        Debug.Log("swing");
    }

    public void EndSwing() // Called via Animation Event when the swing ends
    {
        Debug.Log("end swing");
        _isSwinging = false;
        _canMove = true;
    }
}
