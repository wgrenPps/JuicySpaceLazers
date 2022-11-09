using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{

    public float grav;
    public float speed;
    public float acceleration;
    public float turnx;
    public float turny;
    public float turnz;
    public float graveff;
    public float gravacc;

    float xrotacc = 0f;
    float yrotacc = 0f;
    float zrotacc = 0f;
    float currentspeed = 0f;
    float diracc = 0f;
    float diraccmult = 0f;
    float fallacc = 0f;
    float fallaccacc = 0f;
    float fallaccturn = 0f;




    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector3(300f, 10f, 20f);

    }

    // Update is called once per frame
    void Update()
    {
        float rotx = (transform.eulerAngles.x * Mathf.PI) / 180;
        float roty = (transform.eulerAngles.y * Mathf.PI) / 180;
        float rotz = (transform.eulerAngles.z * Mathf.PI) / 180;
        //Debug.Log(Mathf.PI);
        //Debug.Log(Mathf.Sin(transform.eulerAngles.y * Mathf.PI) / 180);



        if (Input.GetKey(KeyCode.A))
        {
            if (yrotacc > -1)
            {
                yrotacc = yrotacc - (1f * Time.deltaTime);

            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (yrotacc < 1)
            {
                yrotacc = yrotacc + (1f * Time.deltaTime);

            }
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (zrotacc < turnz)
            {
                zrotacc = zrotacc - (4f * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (zrotacc > -turnz)
            {
                zrotacc = zrotacc + (4f * Time.deltaTime);
            }
        }


        if (Input.GetKey(KeyCode.S))
        {
            if (xrotacc < turnx)
            {
                xrotacc = xrotacc - (2f * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (xrotacc > -turnx)
            {
                xrotacc = xrotacc + (2f * Time.deltaTime);
            }
        }


        if (Input.GetKey(KeyCode.T))
        {
            zrotacc = 0f;
            xrotacc = 0f;
            yrotacc = 0f;
            currentspeed = 0;

        }


        transform.Rotate(new Vector3(60f, 0f, 0f) * Time.deltaTime * xrotacc * fallaccturn * 1);
        transform.Rotate(new Vector3(0f, 60f, 0f) * Time.deltaTime * yrotacc * fallaccturn * 1);
        transform.Rotate(new Vector3(0f, 0f, 60f) * Time.deltaTime * zrotacc * fallaccturn * 1);



        if (xrotacc > 0)
        {
            xrotacc = xrotacc - (3f * Time.deltaTime * xrotacc);
        }
        if (xrotacc < 0)
        {
            xrotacc = xrotacc - (3f * Time.deltaTime * xrotacc);
        }

        if (yrotacc > 0)
        {
            yrotacc = yrotacc - (3f * Time.deltaTime * yrotacc);
        }
        if (yrotacc < 0)
        {
            yrotacc = yrotacc - (3f * Time.deltaTime * yrotacc);
        }

        if (zrotacc > 0)
        {
            zrotacc = zrotacc - (3f * Time.deltaTime * zrotacc);
        }
        if (zrotacc < 0)
        {
            zrotacc = zrotacc - (3f * Time.deltaTime * zrotacc);
        }



        if (Input.GetKey(KeyCode.LeftShift)){
            if (currentspeed < 1) {
            currentspeed = currentspeed + (0.2f * Time.deltaTime * acceleration);
            }

        }


        if (Input.GetKey(KeyCode.LeftControl))
        {
            currentspeed = currentspeed - (acceleration * 0.2f * Time.deltaTime);

        }
        if (currentspeed > 1)
        {
            currentspeed = currentspeed - (acceleration * 0.05f * Time.deltaTime);
        }

        if (currentspeed < 0f)
        {
            currentspeed = 0.00f;
        }


        if (currentspeed < 0.3f)
        {
            fallacc = ((0.3f - currentspeed) * 15f);
        }

        if(fallacc > 0f && fallaccacc < 20f)
        {
            fallaccacc = fallaccacc + (fallacc * Time.deltaTime * 0.05f);
        }

        if (fallacc < 0.01f)
        {
            if(currentspeed > 0.3f)
            {
                if (fallaccacc < 20f)
                {
                    fallaccacc = fallaccacc - (currentspeed * Time.deltaTime * 1f);
                }
            }
         
        }

        if (fallaccacc > 20f)
        {
            fallaccacc = 20f;
        }
        if (fallaccacc < 0f)
        {
            fallaccacc = 0f;
        }
        if (currentspeed > 0.3f)
        {
            fallacc = 0f;
        }

        fallaccturn = 1f - fallacc;
        if (fallaccturn < 0)
        {
            fallaccturn = 0;
        }



        if ((transform.eulerAngles.x - 180) < 0)
        {
            diracc = 1 + (graveff * (Mathf.Sin(((Mathf.Abs((Mathf.Abs((Mathf.Abs(((transform.eulerAngles.x) % 180)) - 90))) - 90)) * Mathf.PI) / 180) * 1f));
        }
        if ((transform.eulerAngles.x - 180) > 0)
        {
            diracc = 1 - (graveff * (Mathf.Sin(((Mathf.Abs((Mathf.Abs((Mathf.Abs(((transform.eulerAngles.x) % 180)) - 90))) - 90)) * Mathf.PI) / 180) * 1f));
        }

        if (diraccmult < diracc)
        {
            diraccmult = diraccmult + (diracc * Time.deltaTime * (gravacc * 0.01f));
        }

        if (diraccmult > diracc)
        {
            diraccmult = diraccmult - (diracc * Time.deltaTime * (gravacc * 0.01f));
        }




        Debug.Log(currentspeed);
        Debug.Log(fallacc);
        Debug.Log(fallaccacc);


        if (true)
        {
            transform.position = transform.position + new Vector3((Mathf.Sin(roty) * Mathf.Cos(rotx) * 1f) * currentspeed, (((Mathf.Sin(-rotx) * 1f) * currentspeed) -fallaccacc), ((Mathf.Cos(rotx) * Mathf.Cos(roty) * 1f) * currentspeed)) * Time.deltaTime * speed * diraccmult;
        }
    }
}
