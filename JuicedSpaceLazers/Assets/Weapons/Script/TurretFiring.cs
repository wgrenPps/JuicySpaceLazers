using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFiring : MonoBehaviour
{
    public GameObject bullet;
    public Transform barrel;
    private GameObject shot;
    public Vector3 originPoint;
    float radToDegMult = Mathf.PI / 180;
    private float barrelDistFromRot;

    // Start is called before the first frame update
    void Start()
    {
        barrelDistFromRot = barrel.localScale.y / 2;

       
    }

    // Update is called once per frame
    void Update()
    {
        originPoint = barrel.transform.position + new Vector3(Mathf.Cos(((barrel.transform.localEulerAngles.y * -1) + 90f) * radToDegMult) * barrelDistFromRot, 0, Mathf.Sin(((barrel.transform.localEulerAngles.y * -1) + 90f) * radToDegMult) * barrelDistFromRot);

        if (Input.GetKeyDown(KeyCode.W))
        {
            print(originPoint);
            shot = Instantiate(bullet);
            shot.transform.eulerAngles = barrel.transform.eulerAngles;
            
        }

    }
}
