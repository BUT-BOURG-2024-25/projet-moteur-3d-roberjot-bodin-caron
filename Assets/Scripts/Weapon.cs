using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab; // Le prefab de la balle
    [SerializeField]
    private Transform firePoint; // Le point d'où les balles sont tirées
    [SerializeField]
    private float bulletSpeed = 20f; // Vitesse de la balle
    [SerializeField]
    private float fireRate = 0.5f; // Temps entre les tirs
    private float nextFireTime;

    void Update()
    {

        if (UiManager.instance.RotationJoystick.Direction.magnitude>0)
        {
            Shoot();
        nextFireTime = Time.time + fireRate;
        }
        
        
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = firePoint.up * bulletSpeed;


    }
}
