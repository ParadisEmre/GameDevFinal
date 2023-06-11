using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidHit : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ship")
        {
            other.gameObject.GetComponent<ShipHealthController>().GotHit();
            Destroy(gameObject);
        }
    }
}
