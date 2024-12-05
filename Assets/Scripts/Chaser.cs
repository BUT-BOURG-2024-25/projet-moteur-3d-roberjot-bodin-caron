using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField]
    private float Speed = 20.0f;

    [SerializeField]
    private int Xp = 10;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        if (target == null)
        {

            if (GameObject.FindWithTag("Player") != null)
            {
                target = GameObject.FindWithTag("Player").GetComponent<Transform>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        // face the target
        transform.LookAt(target);

        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position, target.position);

        transform.position += transform.forward * Speed * Time.deltaTime;
    }

    void OnDestroy()
    {
        XPManager.Instance.IncrementXP(Xp);
    }
}
