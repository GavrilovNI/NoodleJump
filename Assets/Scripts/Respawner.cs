using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField]
    private Transform _parent;
    [SerializeField]
    private Vector3 _spawnLocalPosition;
    [SerializeField]
    private Quaternion _spawnRotation;
    [SerializeField]
    private bool _resetVelocity = true;

    public void Respawn()
    {
        Vector3 newPosition = _spawnLocalPosition;
        if(_parent != null)
            newPosition += _parent.position;

        transform.position = newPosition;
        transform.rotation = _spawnRotation;

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if(_resetVelocity && rigidbody != null)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0;
        }
    }

    [ContextMenu("Set From Current")]
    public void SetFromCurrent()
    {
        _spawnRotation = transform.rotation;

        if(_parent == null)
            _spawnLocalPosition = transform.position;
        else
            _spawnLocalPosition = transform.position - _parent.position;
    }
}
