using UnityEngine;
using UnityEngine.Events;

public class ColliderScript : MonoBehaviour
{
    [SerializeField]
    private Collider2D _playeCollider;
    [SerializeField]
    private UnityEvent _collsionEntered;

    [SerializeField]
    private UnityEvent _collisionExit;

    private void OnCollisionEnter2D(Collision2D col)
    
    {
        if (col.collider == _playeCollider)
        {
            _collsionEntered?.Invoke();
        }
    }
    private void OnCollisionExit2D(Collision2D col)
    
    {
        if (col.collider == _playeCollider)
        {
            _collisionExit?.Invoke();
        }
    }
}
