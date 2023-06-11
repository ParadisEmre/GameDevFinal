using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCollisionChecker : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Asteroid")
        {   
            other.gameObject.GetComponent<ShieldController>().DeactivateShield();
        }
    }
}
