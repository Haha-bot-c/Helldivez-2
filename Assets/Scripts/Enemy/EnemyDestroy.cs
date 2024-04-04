using UnityEngine;

public class EnemyDestroy : MonoBehaviour, IInteractable
{
    private ObjectPool _objectPool;
    private EnemyKillCounter _enemyCounter; 

    private void Awake()
    {
        _objectPool = ObjectPool.Instance;
        _enemyCounter = EnemyKillCounter.Instance; 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Bullet bullet))
        {
            ReturnToPool();
            _enemyCounter.AddEnemyKilled();
        }
    }

    private void ReturnToPool()
    {
        gameObject.SetActive(false);
        _objectPool.PutObject(this);
    }
}