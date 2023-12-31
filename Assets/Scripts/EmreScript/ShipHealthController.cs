using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipHealthController : MonoBehaviour
{
    // Start is called before the first frame update
    public static ShipHealthController instance;
    public AdsManager adsManager;

    void Start()
    {
        instance = this;
    }


    public int health = 3;

    public void GotHit()
    {
        health--;
        if(health <= 0)
        {
            if(PlayerPrefs.GetInt("isAdvOn") == 1){
                adsManager.PlayAd();
            }
            AudioControllerScript.instance.PlaySound(1);
            SceneManager.LoadScene(0);
            AudioControllerScript.instance.PlaySound(4);
            Destroy(gameObject);
        }
    }

    
}
