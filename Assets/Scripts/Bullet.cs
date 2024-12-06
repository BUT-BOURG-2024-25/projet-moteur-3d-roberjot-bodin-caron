using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField]
    private float Damage = 10f;

    [SerializeField]
    private float Lifetime = 1.5f;

    [SerializeField]
    private float Speed = 1f;

    void Start()
    {
        Destroy(gameObject, Lifetime);
    }

    void Update()
    {
        float distance = Time.deltaTime * Speed;
        Vector3 nextPosition = transform.position + transform.up * distance;

        if (Physics.Raycast(transform.position, transform.up, out RaycastHit hit, distance) || Physics.Raycast(nextPosition, -transform.up, out hit, distance))
        {
            collide(hit.collider.gameObject);
        }
        else
        {
            transform.position = nextPosition;
        }
    }

    void collide(GameObject objecthit)
    {
        Health health = objecthit.GetComponent<Health>();
        Rigidbody body = objecthit.GetComponent<Rigidbody>();
        health?.TakeDamage(Damage);
        body?.AddForce(transform.up * 50, ForceMode.Impulse);
        
        Destroy(gameObject);
    }
}
