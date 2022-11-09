using System;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraResizer : MonoBehaviour
{
    [SerializeField]
    [Min(0.001f)]
    private float _width = 1;

    private Camera _camera;


    public void ApplySizeToCamera()
    {
        if(_camera.orthographic == false)
            throw new InvalidOperationException("Camera should be orthographic");

        var aspect = _camera.aspect;
        _camera.orthographicSize = _width / aspect / 2f;
    }

    private void FindCamera()
    {
        _camera = GetComponent<Camera>();
    }

    private void Awake()
    {
        FindCamera();
    }

    private void Start()
    {
        ApplySizeToCamera();
    }

    private void OnValidate()
    {
        FindCamera();
        ApplySizeToCamera();
    }
}
