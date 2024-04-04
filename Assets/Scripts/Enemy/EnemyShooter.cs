using UnityEngine;
using System.Collections;

public class EnemyShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletSpeed = 0.5f;
    [SerializeField] private float _initialDelay = 0f;
    [SerializeField] private float _repeatRate = 2f;

    private Coroutine _shootingCoroutine;

    private void OnEnable()
    {
        _shootingCoroutine = StartCoroutine(ShootRoutine());
    }

    private void OnDisable()
    {
        if (_shootingCoroutine != null)
        {
            StopCoroutine(_shootingCoroutine);
        }
    }

    private IEnumerator ShootRoutine()
    {
        yield return new WaitForSeconds(_initialDelay);

        while (true)
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
            bulletRigidbody.AddForce(Vector2.left * _bulletSpeed, ForceMode2D.Impulse);

            yield return new WaitForSeconds(_repeatRate); 
        }
    }
}