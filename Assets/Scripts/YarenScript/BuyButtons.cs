using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyButtons : MonoBehaviour
{
    public void NoAdvB()
    {
        //Ücret alcak

        //Adv kapatcak
        if (PlayerPrefs.GetInt("isAdvOn") != 0)
        {
            PlayerPrefs.SetInt("isAdvOn", 0);
            PlayerPrefs.Save();
        
            Debug.Log("isAdvOn : " + PlayerPrefs.GetInt("isAdvOn") + " , From now on Advertisements are off.");
            
        }
        else
        {
            Debug.Log("Advertisements are already off");
        }
        
        //Buton Disabled

    }
}
