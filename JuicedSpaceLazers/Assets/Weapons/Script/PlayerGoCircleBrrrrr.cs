using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGoCircleBrrrrr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Mathf.Cos(Time.time * 10 * Mathf.PI / 180) * 10, Mathf.Sin(Time.time * 10 * Mathf.PI / 180) * 10, 30);
    }
}