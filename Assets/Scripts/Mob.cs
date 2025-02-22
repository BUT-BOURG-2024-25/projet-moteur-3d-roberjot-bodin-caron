using System.Diagnostics.Tracing;
using System.Transactions;
using UnityEngine;

public class Mob : Health
{
    [SerializeField]
    private int Damage = 10;

    [SerializeField]
    private float Speed = 20.0f;

    private Transform target;
    private float nextAvailableDamageTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            target = GameObject.FindWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        Vector3 targetPosition = new(target.position.x, transform.position.y, target.position.z);
        // face the target
        transform.LookAt(targetPosition);
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.Lerp(rb.velocity, Speed * transform.forward, 0.05f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (nextAvailableDamageTime <= Time.time && collision.gameObject.tag == "Player")
        {
            nextAvailableDamageTime = Time.time + 1;
            HealthManager.Instance.TakeDamage(Damage);
        }
    }
}
