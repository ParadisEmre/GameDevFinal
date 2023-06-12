using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipHealthController : MonoBehaviour
{
    // Start is called before the first frame update
    public static ShipHealthController instance;

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
            SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
    }

    
}
