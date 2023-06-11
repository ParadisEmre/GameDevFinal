using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectibleScore : MonoBehaviour
{
    public TMP_Text tmp;

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ship")
        {
            if (tmp.text.StartsWith("+"))
            {
                // Extract the numeric part of the text (excluding the "+")
                string numericText = tmp.text.Substring(1);

                // Attempt to parse the numeric part as an integer using int.TryParse
                if (int.TryParse(numericText, out int value))
                {
                    Timer.instance.addTime(value);
                }
            }
            Destroy(gameObject);
        }
        
    }
}
