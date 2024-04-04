using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance { get; private set; }

    [SerializeField] private Transform _container;
    [SerializeField] private EnemyDestroy _prefab;

    private Queue<EnemyDestroy> _pool;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        _pool = new Queue<EnemyDestroy>();
    }

    public EnemyDestroy GetObject()
    {
        if (_pool.Count == 0)
        {
            EnemyDestroy enemy = Instantiate(_prefab);
            enemy.transform.parent = _container;

            return enemy;
        }

        return _pool.Dequeue();
    }

    public void PutObject(EnemyDestroy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    public void Reset()
    {
        _pool.Clear();
    }
}