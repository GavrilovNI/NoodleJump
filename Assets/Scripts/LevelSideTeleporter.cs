using System;
using UnityEngine;

public class LevelSideTeleporter : MonoBehaviour
{
    [SerializeField]
    private Level _level;

    private void FixedUpdate()
    {
        float localPositionX = transform.position.x - _level.transform.position.x;

        float levelHalfWidth = _level.Width / 2f;

        float distanceFromCenter = Mathf.Abs(localPositionX);
        if(distanceFromCenter > levelHalfWidth)
        {
            float newLocalPositionX = ((distanceFromCenter + levelHalfWidth) % _level.Width - levelHalfWidth) * Mathf.Sign(localPositionX);
            transform.position = new Vector3(_level.transform.position.x + newLocalPositionX, transform.position.y, transform.position.z);
        }
    }
}
