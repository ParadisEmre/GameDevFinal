using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthController : MonoBehaviour
{
    // Start is called before the first frame update
    public int health = 3;

    public void GotHit()
    {
        health--;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    
}
