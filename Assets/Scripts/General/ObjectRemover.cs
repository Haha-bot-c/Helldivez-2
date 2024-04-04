using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;
    
   private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out EnemyDestroy enemy))
        {
            _pool.PutObject(enemy);
        }
        else if(other.TryGetComponent(out Bullet bullet))
        {
            Destroy(other.gameObject);
        }
    }
}
