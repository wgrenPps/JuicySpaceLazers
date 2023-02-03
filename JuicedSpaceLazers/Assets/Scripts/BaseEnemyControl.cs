using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEnemyControl : MonoBehaviour
{


    //Gun Related Code


    public GameObject bulletprefab;

    GameObject bullet;
    public float firerate;
    public int maxammo;
    public float reloadtime;

    float timepassed = 0;
    float reloadtimepassed = 0;
    int ammoremaining = 0;
    bool reloading = true;



    //Plane Related Code

    public float grav;
    public float speed;
    public float acceleration;
    public float turnx;
    public float turny;
    public float turnz;
    public float graveff;
    public float gravacc;
    public float stallspeed;


    float xrotacc = 0f;
    float yrotacc = 0f;
    float zrotacc = 0f;
    float currentspeed = 0.3f;
    float diracc = 0f;
    float diraccmult = 0f;
    float fallacc = 0f;
    float fallaccacc = 0f;
    float fallaccturn = 0f;

    bool wpress = false;
    bool apress = false;
    bool spress = false;
    bool dpress = false;
    bool qpress = false;
    bool epress = false;
    bool spacepress = false;
    bool rpress = false;

    bool resetplane = true;



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


                                        //Control Input
        if (apress == true)
        {
            if (yrotacc > -1)
            {
                yrotacc = yrotacc - (2f * Time.deltaTime);

            }
        }

        if (dpress == true)
        {
            if (yrotacc < 1)
            {
                yrotacc = yrotacc + (2f * Time.deltaTime);

            }
        }

        if (epress == true)
        {
            if (zrotacc < turnz)
            {
                zrotacc = zrotacc - (6f * Time.deltaTime);
            }
        }

        if (qpress == true)
        {
            if (zrotacc > -turnz)
            {
                zrotacc = zrotacc + (6f * Time.deltaTime);
            }
        }


        if (spress == true)
        {
            if (xrotacc < turnx)
            {
                xrotacc = xrotacc - (3f * Time.deltaTime);
            }
        }

        if (wpress == true)
        {
            if (xrotacc > -turnx)
            {
                xrotacc = xrotacc + (3f * Time.deltaTime);
            }
        }

        if (Input.GetKey(KeyCode.T))
        {
            resetplane = true;
        }


        if (resetplane == true) //reset plane procedure
        {
            zrotacc = 0f;
            xrotacc = 0f;
            yrotacc = 0f;
            transform.position = new Vector3(0f, 20f, 0f);
            transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
            currentspeed = (stallspeed+0.0001f);
            fallaccacc = 0f;
            resetplane = false;
            //Debug.Log("Crash");

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



        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (currentspeed < 1)
            {
                currentspeed = currentspeed + (0.2f * Time.deltaTime * acceleration);
            }

        }


        if (Input.GetKey(KeyCode.LeftControl)) //Slow Down
        {
            currentspeed = currentspeed - (acceleration * 0.2f * Time.deltaTime);

        }
        if (currentspeed > 1) //???
        {
            currentspeed = currentspeed - (acceleration * 0.05f * Time.deltaTime);
        }

        if (currentspeed < 0f) // makes currentspeeed always positive.
        {
            currentspeed = 0.00f;
        }
        if (currentspeed > 0.99f && !Input.GetKey(KeyCode.LeftControl)) //Slow Down
        {
            currentspeed = 1f;
        }

        if (currentspeed < stallspeed)
        {
            fallacc = ((stallspeed - currentspeed) * speed);
        }

        if (fallacc > 0f && fallaccacc < (1 + graveff)) //accellerating falling if falling and if falling slower than gravity
        {
            fallaccacc = fallaccacc + (fallacc * Time.deltaTime * 0.005f);
        }

        if (fallacc < 0.01f)
        {
            if (currentspeed > stallspeed)
            {
                if (fallaccacc < speed)
                {
                    fallaccacc = fallaccacc - (currentspeed * Time.deltaTime * 0.1f);
                }
            }

        }

        if (currentspeed > stallspeed)
        {
            if (fallaccacc < speed)
            {
                fallaccacc = fallaccacc - (currentspeed * Time.deltaTime * 1f);
            }
        }


        if (fallaccacc > speed) //plane can't fall faster than max speed.
        {
            fallaccacc = speed;
        }
        if (fallaccacc < 0f) //fallacc can't be positive
        {
            fallaccacc = 0f;
        }
        if (currentspeed > stallspeed) //stops fallinf if fast enough
        {
            fallacc = 0f;
        }

        if (currentspeed < stallspeed)
        {
            fallaccturn = 1f - (3f * (stallspeed - currentspeed)); //reduces speed if stalling
        }

        if (currentspeed > stallspeed)
        {
            fallaccturn = 1f;
        }


        if (fallaccturn < 0f)
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
            diraccmult = diraccmult + (diracc * Time.deltaTime * (gravacc * 0.1f));
        }

        if (diraccmult > diracc)
        {
            diraccmult = diraccmult - (diracc * Time.deltaTime * (gravacc * 0.004f));
        }
        //diraccmult = diraccmult;

        //public static float currentspeedglobal = currentspeed;

        //Debug.Log(diracc);
        //Debug.Log(diraccmult);
        //Debug.Log(currentspeedglobal);


        if (true)
        {
            transform.position = transform.position + new Vector3((Mathf.Sin(roty) * Mathf.Cos(rotx) * 1f) * currentspeed, (((Mathf.Sin(-rotx) * 1f) * currentspeed) - fallaccacc), ((Mathf.Cos(rotx) * Mathf.Cos(roty) * 1f) * currentspeed)) * Time.deltaTime * speed * diracc;
            //rb.velocity( (new Vector3((Mathf.Sin(roty) * Mathf.Cos(rotx) * 1f) * currentspeed, (((Mathf.Sin(-rotx) * 1f) * currentspeed) - fallaccacc), ((Mathf.Cos(rotx) * Mathf.Cos(roty) * 1f) * currentspeed)) * Time.deltaTime * speed * diraccmult), ForceMode.Impulse);
        }


        ///Gun Code ======================================================================

        ///Gun Code ======================================================================

        ///Gun Code ======================================================================

        ///Gun Code ======================================================================



        //float gunrotx = (transform.eulerAngles.x * Mathf.PI) / 180;
        //float gunroty = (transform.eulerAngles.y * Mathf.PI) / 180;
        //float gunrotz = (transform.eulerAngles.z * Mathf.PI) / 180;



        if (spacepress == false)
        {
            if (reloading == false)
            {
                if (ammoremaining >= 1)
                {
                    if (timepassed > 1)
                    {
                        bullet = GameObject.Instantiate(bulletprefab, transform.position, transform.rotation);
                        bullet.transform.position = transform.position;
                        timepassed = 0;
                        ammoremaining = ammoremaining - 1;
                        //Debug.Log("fire");
                    }
                }
            }
        }

        if (ammoremaining < 1)
        {
            reloading = true;
        }

        if (rpress == true)
        {
            reloading = true;

        }
        if (reloading == true)
        {
            reloadtimepassed = reloadtimepassed + (1 * Time.deltaTime);
        }

        if (reloadtimepassed > reloadtime)
        {
            reloading = false;
            ammoremaining = maxammo;
            reloadtimepassed = 0f;
            //Debug.Log("reloaded");
        }


        timepassed = timepassed + (Time.deltaTime * (firerate * 1));




    }


    void OnCollisionEnter(Collision other)
    {
       if (other.gameObject.CompareTag("Terrain"))
        {
            resetplane = true;
            //Debug.Log("Hi");
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            resetplane = true;
            //Debug.Log("Hi");
        }
    }

}