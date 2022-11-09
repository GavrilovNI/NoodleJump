using UnityEngine;

[CreateAssetMenu(menuName = LevelPartGenerator.ScriptableObjectMenuFolder + "/Random Position")]
public class RandomPositionGenerator : LevelPartGenerator
{
    [SerializeField]
    private Platform _platformPrefab;
    [SerializeField]
    private float _minHeightOffset = 0.1f;
    [SerializeField]
    private float _maxHeightOffset = 2f;
    [SerializeField]
    private AnimationCurve _heightOffsetChance = AnimationCurve.Linear(0f, 0f, 1f, 1f);
    [SerializeField]
    private AnimationCurve _xOffsetChance = AnimationCurve.Linear(0f, 0f, 1f, 1f);

    [Min(1)]
    [SerializeField]
    private int _countMin = 1;
    [SerializeField]
    private int _countMax = 5;

    public override GenerationResult Generate(float positionY, Level level)
    {
        int count = Random.Range(_countMin, _countMax + 1);

        float currentPosY = positionY;

        for(int i = 0; i < count; ++i)
        {
            var platfrom = GeneratePlatform(currentPosY, level);

            currentPosY = platfrom.transform.position.y + platfrom.GetHeight();
        }
        return new GenerationResult(currentPosY - positionY);
    }

    private float GetRandomHeight()
    {
        float heightDifference = _maxHeightOffset - _minHeightOffset;
        return _heightOffsetChance.Evaluate(Random.Range(0f, 1f)) * heightDifference + _minHeightOffset;
    }

    private Platform GeneratePlatform(float positionY, Level level)
    {
        float xPosition = _xOffsetChance.Evaluate(Random.Range(0f, 1f)) * level.Width - level.Width / 2f;

        Vector3 position = new(xPosition, positionY + GetRandomHeight(), 0);

        return InstantiatePlatform(_platformPrefab, position, level);
    }

    private void OnValidate()
    {
        if(_countMax < _countMin)
            _countMax = _countMin;
    }
}
