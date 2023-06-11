using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private float speed = 0.7f;
    private float x, y, z;

    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(-speed, speed);
        y = Random.Range(-speed, speed);
        z = Random.Range(-speed, speed);
    }

    // Update is called once per frame
    void Update()
    {
        //Space.self rotates the object relative to its own axis 
        transform.Rotate(x, y, z, Space.Self);
    }
}


