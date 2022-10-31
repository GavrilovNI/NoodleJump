using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraMaxHeightFolower : MonoBehaviour
{
    [SerializeField]
    private Transform _target;

    [SerializeField]
    private float _offsetFromBottom = 0;

    private Camera _camera;
    private float _targetingHeight;

    public void ResetTargetHeight()
    {
        _targetingHeight = _target.position.y;
        UpdateTargetingHeight();
    }

    private bool UpdateTargetingHeight()
    {
        if(_targetingHeight < _target.position.y)
        {
            _targetingHeight = _target.position.y;
            return true;
        }
        return false;
    }

    private float GetCameraScreenCenterToBottomOffset()
    {
        return -_camera.orthographicSize / _camera.aspect / 2f;
    }

    private void MoveToTargetingHeight()
    {
        float newYPosition = _targetingHeight - GetCameraScreenCenterToBottomOffset() - _offsetFromBottom;
        if(newYPosition > transform.position.y)
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);
    }

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        if(_camera.orthographic == false)
            throw new InvalidOperationException("Camera should be orthographic");
    }

    private void Start()
    {
        ResetTargetHeight();
    }

    private void Update()
    {
        bool targetingHeightUpdated = UpdateTargetingHeight();

        if(targetingHeightUpdated)
            MoveToTargetingHeight();
    }
}
