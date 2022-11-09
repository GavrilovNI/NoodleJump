using UnityEngine;

public class Level : MonoBehaviour
{
    [Min(0.001f)]
    [SerializeField]
    private float _width = 1;

    public float Width => _width;

}
