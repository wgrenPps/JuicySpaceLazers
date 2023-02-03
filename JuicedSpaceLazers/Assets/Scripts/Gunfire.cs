using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunfire : MonoBehaviour
{
    public static int ammoleftglobal;
    public static bool ifreloadingglobal = true;

    public GameObject bulletprefab;

    GameObject bullet;
    public float firerate;
    public float lifetime;
    public int maxammo;
    public float reloadtime;

    float timepassed = 0;
    float reloadtimepassed = 0;
    int ammoremaining = 0;
    bool reloading = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float rotx = (transform.eulerAngles.x * Mathf.PI) / 180;
        float roty = (transform.eulerAngles.y * Mathf.PI) / 180;
        float rotz = (transform.eulerAngles.z * Mathf.PI) / 180;



        if (Input.GetKey(KeyCode.Space))
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

        if (Input.GetKey(KeyCode.R))
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

        ammoleftglobal = ammoremaining;
        ifreloadingglobal = reloading;

        //Debug.Log(timepassed);
        //Debug.Log(reloadtimepassed);
        //Debug.Log(ammoremaining);
    }
}
