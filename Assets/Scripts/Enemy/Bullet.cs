using UnityEngine;

public class Bullet : MonoBehaviour, IInteractable
{
    private const float Lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, Lifetime);
    }
}