using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform _playerVisual;
    [SerializeField] private float _moveSpeed;
    
    private float _horizontalAxisValue;
    private float _verticalAxisValue;
    private float _moveLimiter = 0.7f;
    
    void Update()
    {
        CheckInput();
    }

    void FixedUpdate()
    {
        Movement();
    }

    private void CheckInput()
    {
        // Gives a value between -1 and 1
        _horizontalAxisValue = Input.GetAxisRaw("Horizontal");
        _verticalAxisValue = Input.GetAxisRaw("Vertical");

        if (_horizontalAxisValue != 0 || _verticalAxisValue != 0)
        {
            _animator.SetBool("isWalking", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
        }

        if (_horizontalAxisValue > 0)
        {
            _playerVisual.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_horizontalAxisValue < 0)
        {
            _playerVisual.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void Movement()
    {
        if (_horizontalAxisValue != 0 && _verticalAxisValue != 0)
        {
            _horizontalAxisValue *= _moveLimiter;
            _verticalAxisValue *= _moveLimiter;
        } 

        _rigidbody.velocity = new Vector2(_horizontalAxisValue * _moveSpeed, _verticalAxisValue * _moveSpeed);
    }
}
