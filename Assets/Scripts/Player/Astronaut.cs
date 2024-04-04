using System;
using UnityEngine;

[RequireComponent(typeof(AstronautMover))]
[RequireComponent(typeof(EnemyKillCounter))]
[RequireComponent(typeof(AstronautCollisionHandler))]
public class Astronaut : MonoBehaviour
{
    private AstronautMover _astronautMover;
    private EnemyKillCounter _scoreCounter;
    private AstronautCollisionHandler _handler;

    public event Action GameOver;

    private void Awake()
    {
        _scoreCounter = GetComponent<EnemyKillCounter>();
        _handler = GetComponent<AstronautCollisionHandler>();
        _astronautMover = GetComponent<AstronautMover>();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void ProcessCollision(IInteractable interactable)
    {
        if (interactable is EnemyDestroy)
        {
            GameOver?.Invoke();
        }
        else if (interactable is Bullet)
        {
            GameOver?.Invoke();
        }
        else if (interactable is Layer)
        {
            GameOver?.Invoke();
        }
    }

    public void Reset()
    {
        _scoreCounter.Reset();
        _astronautMover.Reset();
    }
}
