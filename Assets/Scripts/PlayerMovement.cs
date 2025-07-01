using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _sprintMultiplier = 1.5f;

    [SerializeField] private AudioSource _footstepAudioSource;
    [SerializeField] private float _stepInterval = 0.4f;

    private float _stepTimer;

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
    private const string _SWING_PICKAXE = "SwingPickaxe";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_canMove) return; // Prevent movement if character engaged in animation

        _movement.Set(InputManager.Movement.x, InputManager.Movement.y);

        float speed = _moveSpeed * (InputManager.isSprinting ? _sprintMultiplier : 1f);

        _rb.linearVelocity = _movement * speed;

        _animator.SetFloat(_HORIZONTAL, _movement.x);
        _animator.SetFloat(_VERTICAL, _movement.y);
        _animator.SetBool(_IS_SPRINTING, InputManager.isSprinting);

        if (_movement != Vector2.zero)
        {
            _animator.SetFloat(_LAST_HORIZONTAL, _movement.x);
            _animator.SetFloat(_LAST_VERTICAL, _movement.y);
        }

        HandleFootsteps();
    }

    private void HandleFootsteps()
    {
        if (_rb.linearVelocity.magnitude > 0.1f)
        {
            _stepTimer -= Time.deltaTime;

            if (_stepTimer <= 0f)
            {
                _footstepAudioSource.pitch = Random.Range(0.95f, 1.05f);
                _footstepAudioSource.Play();

                float currentStepInterval = _stepInterval;
                if (InputManager.isSprinting)
                    currentStepInterval /= _sprintMultiplier;
                _stepTimer = currentStepInterval;
            }
        }
        else
        {
            _stepTimer = 0f; // reset timer when idle
        }

    }

    public void SwingSword()
    {
        if (_isSwinging) return; // Prevents multiple swings
        _isSwinging = true;
        _canMove = false;

        _rb.linearVelocity = Vector2.zero; // Instantly stop any movement
        _animator.SetFloat(_HORIZONTAL, 0);
        _animator.SetFloat(_VERTICAL, 0);
        _animator.SetBool(_IS_SPRINTING, false);

        MusicManager.instance.PlaySwingSwordSFX();

        _animator.SetTrigger(_SWING_SWORD);
        Debug.Log("swing");
    }

    public void SwingPickaxe()
    {
        if (_isSwinging) return; // Prevents multiple swings
        _isSwinging = true;
        _canMove = false;

        _rb.linearVelocity = Vector2.zero; // Instantly stop any movement
        _animator.SetFloat(_HORIZONTAL, 0);
        _animator.SetFloat(_VERTICAL, 0);
        _animator.SetBool(_IS_SPRINTING, false);

        MusicManager.instance.PlaySwingPickaxeSFX();

        _animator.SetTrigger(_SWING_PICKAXE);
        Debug.Log("swing");
    }

    public void test()
    {
        Debug.Log("hi");
    }
    public void EndSwing() // Called via Animation Event when the swing ends
    {
        Debug.Log("end swing");
        _isSwinging = false;
        _canMove = true;
    }
}
