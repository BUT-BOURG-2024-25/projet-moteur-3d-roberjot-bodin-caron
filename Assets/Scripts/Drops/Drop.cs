using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Drop : MonoBehaviour
{
    public abstract void OnCollect();

    [SerializeField]
    private float Lifetime = 30f;

    void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        if (renderer != null )
        {
            transform.position += Vector3.up * (renderer.bounds.size.y / 2 + 1);
        }
        Destroy(gameObject, Lifetime);
    }

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, Mathf.PI / 4 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnCollect();
            Destroy(gameObject);
        }
    }
}
