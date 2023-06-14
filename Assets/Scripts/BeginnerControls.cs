using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginnerControls : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.GetInt("Skin1") == 2)
        {
            //gemi.material = 1
        }else if (PlayerPrefs.GetInt("Skin2") == 2)
        {
            //gemi.material = 1
        }else
        {
            //gemi.material normal
        }
    }
   
    
}
