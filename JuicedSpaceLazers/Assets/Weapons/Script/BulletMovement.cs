using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float shotSpeed = 2;
    TurretFiring turretScript;
    // Start is called before the first frame update
    void Start()
    {
        turretScript = FindObjectOfType<TurretFiring>();
        transform.position = turretScript.originPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(0, 0, -shotSpeed * Time.deltaTime);
        if (Mathf.Abs(transform.position.z - turretScript.originPoint.z) >= 10)
        {
            Destroy(gameObject);
        }
    }
}
