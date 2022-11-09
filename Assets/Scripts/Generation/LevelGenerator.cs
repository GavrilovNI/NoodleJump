using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private Platform _platformPrefab;

    [SerializeField]
    private List<LevelPartGenerator> _startPartGenerators = new();
    [SerializeField]
    private List<LevelPartGenerator> _partGenerators = new();

    [SerializeField]
    private Level _level;

    private float _currentPositionY;

    public void ResetBuilding()
    {
        _currentPositionY = _level.transform.position.y;
        foreach(var platform in transform.GetComponentsInChildren<Platform>())
            GameObject.Destroy(platform.gameObject);
    }


    private void Start()
    {
        ResetBuilding();

        TestBuild();
    }

    private void GenerateRandomPart(List<LevelPartGenerator> generators)
    {
        var index = Random.Range(0, generators.Count);
        var genertaionResult = generators[index].Generate(_currentPositionY, _level);

        _currentPositionY += genertaionResult.GeneratedHeight;
    }

    public void TestBuild()
    {
        GenerateRandomPart(_startPartGenerators);
        for(int i = 0; i < 20; i++)
            GenerateRandomPart(_partGenerators);
    }
}
