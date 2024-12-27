using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefab; // Le prefab de la balle

    [SerializeField]
    private Transform FirePoint; // Le point d'où les balles sont tirées


    private float nextFireTime;

    void Start()
    {
        nextFireTime = Time.time + StatsManager.Instance.getFireRate();
    }

    void Update()
    {
        if (Time.time >= nextFireTime && UiManager.instance.RotationJoystick.Direction.magnitude > 0)
        {
            nextFireTime = Time.time + StatsManager.Instance.getFireRate();
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
