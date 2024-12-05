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
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, distance, LayerMask.NameToLayer("MapObject")))
        {
            collide(hit.collider.gameObject);
        }else
        { 
            Vector3 nextPosition = transform.position + transform.forward * distance;
            transform.position = nextPosition;
        }
    }

    void collide(GameObject objecthit)
    {
        Health health = objecthit.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(Damage);
        }

        Destroy(gameObject);
    }
}
