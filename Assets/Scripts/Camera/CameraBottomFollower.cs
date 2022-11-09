using System;
using UnityEngine;

public class CameraBottomFollower : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private Vector3 _offset;

    [SerializeField]
    private bool _updateOnStart = false;

#if UNITY_EDITOR
    [SerializeField]
    private bool _updateInEditor = false;
#endif

    private Vector3 GetCameraBottomPosition()
    {
        if(_camera.orthographic == false)
            throw new InvalidOperationException("Camera should be orthographic");

        return _camera.transform.position + Vector3.down * _camera.orthographicSize;
    }

    [ContextMenu("Set Offset By Current")]
    public void SetOffsetByCurrent()
    {
        _offset = transform.position - GetCameraBottomPosition();
    }

    [ContextMenu("Update Position")]
    public void UpdatePosition()
    {
        transform.position = GetCameraBottomPosition() + _offset;
    }

    public void Start()
    {
        if(_updateOnStart)
            UpdatePosition();
    }

    private void OnValidate()
    {
        if(_camera == null || _updateInEditor == false)
            return;
        UpdatePosition();
    }
}
