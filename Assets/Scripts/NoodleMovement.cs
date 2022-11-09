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

    [SerializeField]
    private AnimationCurve _speedCurve;

    [Min(0)]
    [SerializeField]
    private float _gyroAngle = 45;

    private Rigidbody2D _rigidbody;
    private float _input;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Input.gyro.enabled = true;
    }  

    private void HandleInput()
    {
        float angle = Input.gyro.gravity.x * 90;

#if UNITY_EDITOR
        if(UnityEditor.EditorApplication.isRemoteConnected)
        {
#endif
            _input = Mathf.InverseLerp(-_gyroAngle, _gyroAngle, angle) * 2f - 1f;
            _input = _speedCurve.Evaluate(Mathf.Abs(_input)) * Mathf.Sign(_input);
#if UNITY_EDITOR
        }
        else
        {
            _input = Input.GetAxisRaw(HorizontalAxisName);
        }
#endif
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
