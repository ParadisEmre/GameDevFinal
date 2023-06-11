using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldHit : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ship")
        {
            other.gameObject.GetComponent<ShipControl>().ShieldBuffCollected();
            Destroy(gameObject);
        }
    }
}
