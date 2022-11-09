using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingFiring : MonoBehaviour
{
    public GameObject bullet;
    private GameObject shot;
    public Vector3 originPoint;
    float radToDegMult = Mathf.PI / 180;
    private float barrelDistFromRot;

    // Start is called before the first frame update
    void Start()
    {
        barrelDistFromRot = transform.localScale.y;
        print(barrelDistFromRot);
        print(Mathf.Cos(((transform.localEulerAngles.y * -1) + 90f) * radToDegMult) * barrelDistFromRot);
        print(Mathf.Sin(((transform.localEulerAngles.y * -1) + 90f) * radToDegMult) * barrelDistFromRot);
    }

    // Update is called once per frame
    void Update()
    {
        originPoint = transform.position + new Vector3(Mathf.Cos(((transform.localEulerAngles.y * -1) + 90f) * radToDegMult) * barrelDistFromRot, 0, Mathf.Sin(((transform.localEulerAngles.y * -1) + 90f) * radToDegMult) * barrelDistFromRot);
        if (Input.GetKeyDown(KeyCode.S))
        {
            print("Missile ogPnt: " + originPoint);
            shot = Instantiate(bullet);
            shot.transform.eulerAngles = transform.eulerAngles;
            shot.transform.position = originPoint;

        }
    }
}
