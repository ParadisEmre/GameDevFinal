using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void BackB()
    {
        SceneManager.LoadScene("MenuScene");
    }
    
    public void StartB()
    {
        AudioControllerScript.instance.PlaySound(3);
        AudioControllerScript.instance.StopSound(4);
        SceneManager.LoadScene("SampleScene");
    }
    
    public void ShopB()
    {
        SceneManager.LoadScene("ShopScene");
    }
    
    public void CreditsB()
    {
        SceneManager.LoadScene("CreditsScene");
    }
    
    public void SettingsB()
    {
        SceneManager.LoadScene("SettingsScene");
    }
}
