using UnityEngine;

public class AstronautTracker : MonoBehaviour
{
    [SerializeField] private Astronaut _astronaut;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        var position = transform.position;
        position.x = _astronaut.transform.position.x + _xOffset;
        transform.position = position;
    }
}
