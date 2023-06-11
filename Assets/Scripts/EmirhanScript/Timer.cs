using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{   

    public TextMeshProUGUI timerText;
    public float currentTime;
    public float frenzyLimit;

    public static Timer instance;
    
    void Awake()
    {
        instance = this;
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

    public void addTime(float change)
    {
        currentTime += change;
    }
    public void subtractTime(float change)
    {
        currentTime -= change;
    }
}
