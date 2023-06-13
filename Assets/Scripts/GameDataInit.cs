using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDataInit : MonoBehaviour
{
    void Start()
    {
        // Check if the "isAdvOn" key is not set
        if (!PlayerPrefs.HasKey("isAdvOn"))
        {
            // Set the value of "isAdvOn" to 1
            PlayerPrefs.SetInt("isAdvOn", 1);
            PlayerPrefs.Save();
            
            Debug.Log("isAdvOn : " + PlayerPrefs.GetInt("isAdvOn"));
        }
        
    }

    public void DebugAdvB()
    {
        PlayerPrefs.DeleteKey("isAdvOn");
        
        Debug.Log("isAdvOn Key deleted.");
        
        SceneManager.LoadScene("MenuScene");
        
        Debug.Log("Scene reloaded.");
    }
    
}
