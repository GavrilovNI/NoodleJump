using System;
using UnityEngine;

public class ScreenSideTeleporter : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;


    private void FixedUpdate()
    {
        Vector3 localPosition = transform.position - _camera.transform.position;
        Vector3 sideOffset = Vector2.Dot(_camera.transform.right, localPosition) * _camera.transform.right;

        float orthographicSize = _camera.orthographicSize;
        float halfOrthographicSize = orthographicSize / 2f;

        float distance = sideOffset.magnitude;
        if(distance > halfOrthographicSize)
        {
            float newDistance = (distance + halfOrthographicSize) % orthographicSize - halfOrthographicSize;
            Vector3 newSideOffset = newDistance * sideOffset.normalized;

            Vector3 newLocalPosition = localPosition - sideOffset + newSideOffset;

            transform.position = _camera.transform.position + newLocalPosition;
        }
    }
}
