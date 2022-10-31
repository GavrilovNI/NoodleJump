using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField]
    private Platform _platformPrefab;

    [SerializeField]
    private float _sceneWidth;
    [SerializeField]
    private Vector2 _startCenterBuildingPoint;

    [SerializeField]
    private float _minHeightOffset;
    [SerializeField]
    private float _maxHeightOffset;
    [SerializeField]
    private AnimationCurve _heightOffsetChance;


    private float _currentBuildingHeight;


    public void ResetBuilding()
    {
        _currentBuildingHeight = _startCenterBuildingPoint.y;
        foreach(var platform in transform.GetComponentsInChildren<Platform>())
            GameObject.Destroy(platform.gameObject);
    }


    private void Start()
    {
        ResetBuilding();

        TestBuild();
    }

    public void TestBuild()
    {
        BuildPlatform(0);
        for(int i = 0; i < 100; i++)
            BuildPlatform();
    }

    private void BuildPlatform(float xPosition)
    {
        Vector3 position = new(xPosition, _currentBuildingHeight, 0);
        Platform platform = GameObject.Instantiate(_platformPrefab, position, Quaternion.identity, transform);

        float platformHalfWidth = platform.GetWidth() / 2f;
        float sceneHalfWidth = _sceneWidth / 2f;
        float clampedXPosition = Mathf.Clamp(platform.transform.position.x, _startCenterBuildingPoint.x - sceneHalfWidth + platformHalfWidth, _startCenterBuildingPoint.x + sceneHalfWidth - platformHalfWidth);
        platform.transform.position = new Vector3(clampedXPosition, platform.transform.position.y, platform.transform.position.z);

        float heightDifference = _maxHeightOffset - _minHeightOffset;
        float heightOffset = _heightOffsetChance.Evaluate(Random.Range(0f, 1f)) * heightDifference + _minHeightOffset;

        _currentBuildingHeight += platform.GetHeight() + heightOffset;
    }

    private void BuildPlatform()
    {
        BuildPlatform(Random.Range(0, _sceneWidth) - _sceneWidth / 2f);
    }

    private void OnValidate()
    {
        if(_minHeightOffset > _maxHeightOffset)
            _maxHeightOffset = _minHeightOffset;
    }
}
