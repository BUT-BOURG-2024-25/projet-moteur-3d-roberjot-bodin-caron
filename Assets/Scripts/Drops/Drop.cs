using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Drop : MonoBehaviour
{
    public abstract void OnCollect();

    void Start()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();

        if (renderer != null )
        {
            transform.position += Vector3.up * (renderer.bounds.size.y / 2 + 1);
        }
    }

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, Mathf.PI / 4 * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            OnCollect();
            Destroy(gameObject);
        }
    }
}
