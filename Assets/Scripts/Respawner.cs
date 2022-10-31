using UnityEngine;

public class Respawner : MonoBehaviour
{
    [SerializeField]
    private Vector3 _spawnPosition;
    [SerializeField]
    private Quaternion _spawnRotation;
    [SerializeField]
    private bool _resetVelocity = true;

    public void Respawn()
    {
        transform.position = _spawnPosition;
        transform.rotation = _spawnRotation;

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        if(_resetVelocity && rigidbody != null)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.angularVelocity = 0;
        }
    }
}
