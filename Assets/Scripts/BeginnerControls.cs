using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginnerControls : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("isSkin1") == 2)
        {
            //gemi.material = 1
        }else if (PlayerPrefs.GetInt("isSkin2") == 2)
        {
            //gemi.material = 1
        }else
        {
            //gemi.material normal
        }
    }
   
    
}
