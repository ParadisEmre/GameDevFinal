using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvinciblityBuffHit : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ship")
        {
            other.gameObject.GetComponent<ShipControl>().InvinciblityBuffCollected();
            Destroy(gameObject);
        }
    }
}
