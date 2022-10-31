using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NoodleMovement : MonoBehaviour
{
    public string HorizontalAxisName = "Horizontal";

    [Min(0)]
    [SerializeField]
    private float _speed = 1;

    private Rigidbody2D _rigidbody;
    private float _input;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void HandleInput()
    {
        _input = Input.GetAxisRaw(HorizontalAxisName);
        if(_input != 0)
            _input = Mathf.Sign(_input);
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_input * _speed, _rigidbody.velocity.y);
    }
}
