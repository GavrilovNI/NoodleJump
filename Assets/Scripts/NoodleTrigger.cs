using UnityEngine;
using UnityEngine.Events;

public class NoodleTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Noodle>() != null)
            _onEnter.Invoke();
    }
}
