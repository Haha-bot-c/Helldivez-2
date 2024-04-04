using System;
using UnityEngine;

public class EnemyKillCounter : MonoBehaviour
{
    public static EnemyKillCounter Instance { get; private set; }

    private int _enemiesKilled;

    public event Action<int> EnemiesKilledChanged;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    public void AddEnemyKilled()
    {
        _enemiesKilled++;
        EnemiesKilledChanged?.Invoke(_enemiesKilled);
    }

    public void Reset()
    {
        _enemiesKilled = 0;
        EnemiesKilledChanged?.Invoke(_enemiesKilled);
    }
}
