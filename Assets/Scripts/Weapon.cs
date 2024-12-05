using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab; // Le prefab de la balle

    [SerializeField]
    private Transform FirePoint; // Le point d'où les balles sont tirées

    [SerializeField]
    private float BulletSpeed = 20f; // Vitesse de la balle

    [SerializeField]
    private float FireRate = 0.5f; // Temps entre les tirs
    private float nextFireTime;

    void Start()
    {
        nextFireTime = Time.time + FireRate;
    }

    void Update()
    {
        if (Time.time >= nextFireTime && UiManager.instance.RotationJoystick.Direction.magnitude > 0)
        {
            nextFireTime = Time.time + FireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
