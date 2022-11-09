using UnityEngine;

[CreateAssetMenu(menuName = LevelPartGenerator.ScriptableObjectMenuFolder + "/One Platform")]
public class OnePlatformGenerator : LevelPartGenerator
{
    [SerializeField]
    private Platform _platformPrefab;
    [SerializeField]
    private float _positionX = 0;
    [SerializeField]
    private float _bottomOffset = 0;
    [SerializeField]
    private float _topOffset = 0.1f;

    public override GenerationResult Generate(float positionY, Level level)
    {
        Vector3 position = new(_positionX, positionY, 0);
        var platform = InstantiatePlatform(_platformPrefab, position, level);

        return new GenerationResult(platform.GetHeight() + _bottomOffset + _topOffset);
    }
}
