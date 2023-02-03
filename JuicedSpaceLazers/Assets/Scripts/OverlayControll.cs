using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlayControll : MonoBehaviour
{

    public Text speedtext;
    public Text acctext;
    public Text ammotext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speedreport = PlaneControl.currentspeedglobal;
        float gravaccreport = PlaneControl.diraccglobal;
        float stallspeed = PlaneControl.stallspeedglobal;
        float ammoleft = Gunfire.ammoleftglobal;
        bool isreloading = Gunfire.ifreloadingglobal;


        if (true)
        {
            speedtext.text = " Speed: " + (Mathf.Round(speedreport * 100.0f) * 1f) + " STALL";
            speedtext.color = Color.red;
            //Debug.Log(speedreport);
        }
        if (speedreport >= stallspeed)
        {
            speedtext.text = " Speed: " + (Mathf.Round(speedreport * 100.0f) * 1f);
            speedtext.color = Color.green;
            //Debug.Log(speedreport);
        }


        acctext.text = " Gravacc: " + gravaccreport;


        if (isreloading == true)
        {
            ammotext.text = " Ammunition Left: " + ammoleft + " - Reloading";
            ammotext.color = Color.black;
        }
        if (isreloading == false)
        {
            ammotext.text = " Ammunition Left: " + ammoleft;
            ammotext.color = Color.yellow;
        }

    }
}
