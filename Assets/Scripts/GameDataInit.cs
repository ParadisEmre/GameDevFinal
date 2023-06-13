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
        
        // Check if the "isSkin1" key is not set
        if (!PlayerPrefs.HasKey("isSkin1"))
        {
            // Set the value of "isAdvOn" to 1
            PlayerPrefs.SetInt("isSkin1", 0);
            PlayerPrefs.Save();
            
            Debug.Log("isSkin1 : " + PlayerPrefs.GetInt("isSkin1"));
        }
        
        // Check if the "isSkin1" key is not set
        if (!PlayerPrefs.HasKey("isSkin2"))
        {
            // Set the value of "isAdvOn" to 1
            PlayerPrefs.SetInt("isSkin2", 0);
            PlayerPrefs.Save();
            
            Debug.Log("isSkin2 : " + PlayerPrefs.GetInt("isSkin2"));
        }
        
    }

    public void DebugAdvB()
    {
        PlayerPrefs.DeleteKey("isAdvOn");
        PlayerPrefs.DeleteKey("isSkin1");
        PlayerPrefs.DeleteKey("isSkin2");
        
        Debug.Log("isAdvOn Key deleted.");
        
        SceneManager.LoadScene("MenuScene");
        
        Debug.Log("Scene reloaded.");
    }
    
}
