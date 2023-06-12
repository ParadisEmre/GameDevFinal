using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasHeartManager : MonoBehaviour
{
    public Image heart1;
    public Image heart2;
    public Image heart3;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
    {
        if(ShipHealthController.instance.health == 3)
        {
            heart1.sprite = fullHeart;
            heart2.sprite = fullHeart;
            heart3.sprite = fullHeart;
        }
        else if(ShipHealthController.instance.health == 2)
        {
            heart1.sprite = fullHeart;
            heart2.sprite = fullHeart;
            heart3.sprite = emptyHeart;
        }
        else if(ShipHealthController.instance.health == 1)
        {
            heart1.sprite = fullHeart;
            heart2.sprite = emptyHeart;
            heart3.sprite = emptyHeart;
        }
        else if(ShipHealthController.instance.health == 0)
        {
            heart1.sprite = emptyHeart;
            heart2.sprite = emptyHeart;
            heart3.sprite = emptyHeart;
        }

    }
}
