using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void BackB()
    {
        AudioControllerScript.instance.PlaySound(7);
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
        AudioControllerScript.instance.PlaySound(7);
        SceneManager.LoadScene("ShopScene");
    }
    
    public void CreditsB()
    {
        AudioControllerScript.instance.PlaySound(7);
        SceneManager.LoadScene("CreditsScene");
    }
    
    public void SettingsB()
    {
        AudioControllerScript.instance.PlaySound(7);
        SceneManager.LoadScene("SettingsScene");
    }
}
