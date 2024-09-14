using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class FlatCharacterMove : MonoBehaviour, IControlable
{
    [SerializeField] private int _speed;

    [SerializeField] private int _dashSpeed;
    [SerializeField] private float _dashDuration;
    private float _dashTime;
    private bool _isDashing = false;

    [SerializeField] private float _jumpForce;

    [SerializeField] private int _actionCount;
    private const int _maxActions = 1;

    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (_dashTime > 0)
        {
            _dashTime -= Time.deltaTime;
            transform.position += new Vector3(1, 0, 0) * _dashSpeed * Time.deltaTime;
        }
        else
        {
            _isDashing = false;
            GetComponent<BoxCollider2D>().enabled = true;
        }

        if (_actionCount == _maxActions)
            Invoke(nameof(ResetActionCount), 3f);
        }

    public void Dash()
    {
        if (_actionCount < _maxActions)
        {
            _animator.SetTrigger("Dash");
            _actionCount++;
            _dashTime = _dashDuration;
            _isDashing = true;
            GetComponent<BoxCollider2D>().enabled = false;

        }
    }

    private void ResetActionCount()
    {
        _actionCount = 0;
    }

    public void Jump()
    {
        throw new System.NotImplementedException();
    }

    public void Move(Vector2 _direction)
    {
       if(_direction != Vector2.zero && !_isDashing)
        _rigidbody.MovePosition(_rigidbody.position + _direction.normalized * _speed * Time.fixedDeltaTime);
    }
}