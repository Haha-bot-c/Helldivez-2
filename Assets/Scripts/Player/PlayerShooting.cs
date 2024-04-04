using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletSpeed = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            Bullet bullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);
            float playerRotationZ = transform.eulerAngles.z;
            Vector2 lookDirection = Quaternion.Euler(0, 0, playerRotationZ) * Vector2.right;
            bullet.GetComponent<Rigidbody2D>().velocity = lookDirection.normalized * _bulletSpeed;
        }
    }
}
