using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTest : MonoBehaviour
{
    [SerializeField]
    private Transform _gravityShower;
    [SerializeField]
    private Transform _rotationShower;

    private void Start()
    {
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        _gravityShower.up = Input.gyro.gravity;
        _rotationShower.rotation = Input.gyro.attitude;
        Debug.Log($"Input.gyro.gravity.x: {Input.gyro.gravity.x}");
    }
}
