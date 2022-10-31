using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float _height;
    [SerializeField]
    private float _width;

    public float GetHeight()
    {
        return _height;
    }
    public float GetWidth()
    {
        return _width;
    }
}
