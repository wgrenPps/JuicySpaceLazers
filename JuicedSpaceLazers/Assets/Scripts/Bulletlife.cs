using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletlife : MonoBehaviour
{
    //public static bool gunreloadstatus;
    //public static float 

    public float bulletspeed;
    public float bulletlife;

    float timepassed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timepassed = timepassed + (Time.deltaTime);

        if(timepassed > bulletlife)
        {
            //Debug.Log("bye");
            Object.Destroy(this.gameObject);
        }


        float rotx = (transform.eulerAngles.x * Mathf.PI) / 180;
        float roty = (transform.eulerAngles.y * Mathf.PI) / 180;
        float rotz = (transform.eulerAngles.z * Mathf.PI) / 180;

        //Debug.Log(rotx);
        //Debug.Log(roty);
        //Debug.Log(rotz);

        //Log(transform.eulerAngles.x);
        //Debug.Log(transform.eulerAngles.y);
        //Debug.Log(transform.eulerAngles.z);

        //Debug.Log("JFK");
        transform.position = transform.position + new Vector3((Mathf.Sin(roty) * (Mathf.Cos(rotx) * 1f) * bulletspeed), (((Mathf.Sin(-rotx) * 1f) * bulletspeed)), ((Mathf.Cos(rotx) * Mathf.Cos(roty) * 1f) * bulletspeed));

        //Debug.Log(Mathf.Sin(roty) * Mathf.Cos(rotz) * bulletspeed * 1f);
        //Debug.Log(Mathf.Sin(rotz) * Mathf.Cos(rotx) * bulletspeed * 1f);
        //Debug.Log(Mathf.Sin(rotx) * Mathf.Cos(roty) * bulletspeed * 1f);
    }



    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {



            Debug.Log("Hit");
            Object.Destroy(this.gameObject);
        }

        if (other.gameObject.CompareTag("Terrain"))
        {



            //Debug.Log("Pop");
            Object.Destroy(this.gameObject);
        }

    }




}
