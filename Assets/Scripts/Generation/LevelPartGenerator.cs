using UnityEngine;

public abstract class LevelPartGenerator : ScriptableObject
{
    public const string ScriptableObjectMenuFolder = "Level Generation";

    public abstract GenerationResult Generate(float positionY, Level level);

    protected Platform InstantiatePlatform(Platform prefab, Vector3 position, Level level)
    {
        Platform platform = GameObject.Instantiate(prefab, position, Quaternion.identity, level.transform);
        ClampPlatformXPosition(platform, level);
        return platform;
    }

    protected void ClampPlatformXPosition(Platform platform, Level level)
    {
        float platformHalfWidth = platform.GetWidth() / 2f;
        float levelHalfWidth = level.Width / 2f;
        float levelCenterX = level.transform.position.x;
        float clampedXPosition = Mathf.Clamp(platform.transform.position.x, levelCenterX - levelHalfWidth + platformHalfWidth, levelCenterX + levelHalfWidth - platformHalfWidth);
        platform.transform.position = new Vector3(clampedXPosition, platform.transform.position.y, platform.transform.position.z);
    }
}
