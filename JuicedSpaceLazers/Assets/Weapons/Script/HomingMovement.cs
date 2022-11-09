using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMovement : MonoBehaviour
{
    Collider[] posTargets;
    public float speed = 4;
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posTargets = Physics.OverlapSphere(transform.position, 20);
        foreach (Collider i in posTargets)
        {
            if (i.gameObject.CompareTag("Player"))
            {
                target = i.gameObject.transform;
                break;
            } else
            {
                target = null;
            }
        }
        if (target != null)
        {
            float hypo = Mathf.Sqrt(Mathf.Pow(target.position.x - transform.position.x, 2) + Mathf.Pow(target.position.y - transform.position.y, 2));
            //float angleToTarget = transform.position
        }

        transform.Translate(0, speed * Time.deltaTime, 0);

    }
}


//https://youtu.be/AKKpPmxx07w?t=533
