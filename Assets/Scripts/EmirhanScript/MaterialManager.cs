using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialManager : MonoBehaviour
{
    public GameObject[] shipParts;
    public Material ColorWhite;
    public Material ColorCyan;
  
    public void Start()
    {
        if(PlayerPrefs.GetInt("isSkin1") == 2)
        {
            changeColorWhite();
        }
        if(PlayerPrefs.GetInt("isSkin2") == 2)
        {
            changeColorCyan();
        }
        else
        {
        }
    }

    public void changeColorWhite(){
        foreach(GameObject shipPart in shipParts)
        {
            shipPart.GetComponent<Renderer>().material = ColorWhite;
        }

    }
    public void changeColorCyan(){
        foreach(GameObject shipPart in shipParts)
        {
            shipPart.GetComponent<Renderer>().material = ColorCyan;
        }

    }
}
