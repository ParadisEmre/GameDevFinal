using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{   

    public TextMeshProUGUI timerText;
    public float currentTime;
    public float frenzyLimit;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if you go beyond frenzy limit text turns red
        if(currentTime >= frenzyLimit)
        {
            timerText.color = Color.red;
        }
        //timer counts up
        currentTime = currentTime += Time.deltaTime;

        //timer text is updated with 2 floating point format ex. 12.10
        timerText.text = currentTime.ToString("0.00");
    }
}
