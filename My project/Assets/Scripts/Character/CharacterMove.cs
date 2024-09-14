using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMove : MonoBehaviour, IControlable
{
    [SerializeField] private int _speed;

    [SerializeField] private int _dashSpeed;
    [SerializeField] private float _dashDuration;
    private float _dashTime;
    private bool _isDashing = false;

    [SerializeField] private float _jumpForce;
    private const float _accelerationOfGravity = -9.8f;
    private float _verticalMovement;

    [SerializeField] private int _actionCount;
    private const int _maxActions = 2;

    private Animator _animator;
    private CharacterController _controller;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        GravityFall();

        if (_controller.isGrounded)
            _actionCount = 0;

        if (_dashTime > 0)
        {
           _dashTime -= Time.deltaTime;
           _controller.Move(transform.forward * _dashSpeed * Time.deltaTime);
        }
        else
        {
            _isDashing = false;
        }
    }

    public void Jump()
    {
        if (_actionCount < _maxActions)
        {
            _verticalMovement = _jumpForce;
            _actionCount++;
        }
    }

    public void Move(Vector2 _inputDirection)
    {
        Vector3 _direction = new Vector3(_inputDirection.x, 0, _inputDirection.y);

        if (!_isDashing && _direction != Vector3.zero)
        {
              _animator.CrossFade("Move", 0.01f);
           // _animator.SetTrigger("Move");
            _controller.Move(_direction * _speed * Time.deltaTime);
            transform.localRotation = Quaternion.Euler(0f, 90f * Mathf.Abs(_direction.z) - 90 * _direction.z + 90f * _direction.x, 0f);
        }
        else
        {
            _animator.SetTrigger("Idle");
        }
/*        if (_direction == Vector3.zero && !_isDashing)
        {
            // _animator.CrossFade("Idle", 0.02f);
            _animator.SetTrigger("Idle");
        }*/
    }

    private void GravityFall()
    {
        if (!_isDashing && !_controller.isGrounded)
        {
            _controller.Move(Vector3.up * _verticalMovement * Time.deltaTime);
            _verticalMovement += _accelerationOfGravity * Time.deltaTime;
        }
    }

    public void Dash()
    {
        if (_actionCount < _maxActions)
        { 
            _animator.SetTrigger("Dash");
            _actionCount++;
            _dashTime = _dashDuration;
            _isDashing = true;
          
        }
    }
}