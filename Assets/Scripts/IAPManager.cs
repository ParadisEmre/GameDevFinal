using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    // Skin 1 butonları
    public GameObject Skin1BuyButton;        // Skin 1 satın alma butonu
    public GameObject Skin1EquipButton;      // Skin 1 giyme butonu
    public GameObject Skin1UnequipButton;    // Skin 1 çıkarma butonu

    // Skin 2 butonları
    public GameObject Skin2BuyButton;        // Skin 2 satın alma butonu
    public GameObject Skin2EquipButton;      // Skin 2 giyme butonu
    public GameObject Skin2UnequipButton;    // Skin 2 çıkarma butonu

    public GameObject NoAdvBuyButton;        // Reklamsız satın alma butonu,
    public GameObject AdvTakenText;        // Reklam alındı yazısı

    private string skin1 = "skin1";          // Skin 1 ürün kimliği
    private string skin2 = "skin2";          // Skin 2 ürün kimliği
    private string noadv = "noadv";          // Reklamsız ürün kimliği

    private void Start()
    {
        // Skin 1 butonlarının durumunu güncelle
        UpdateSkin1Buttons();

        // Skin 2 butonlarının durumunu güncelle
        UpdateSkin2Buttons();
        
        //Update Adv Text
        UpdateAdvText();
    }

    private void UpdateAdvText()
    {
        int advStatus = PlayerPrefs.GetInt("isAdvOn");
        if (advStatus == 0)
        {
            NoAdvBuyButton.SetActive(false);
            AdvTakenText.SetActive(true);
        }
        else if (advStatus == 1)
        {
            NoAdvBuyButton.SetActive(true);
            AdvTakenText.SetActive(false);
        }
    }

    // Skin 1 butonlarının durumunu güncelleyen fonksiyon
    private void UpdateSkin1Buttons()
    {
        int skin1Status = PlayerPrefs.GetInt("isSkin1");

        if (skin1Status == 1)
        {
            Skin1BuyButton.SetActive(false);
            Skin1EquipButton.SetActive(true);
            Skin1UnequipButton.SetActive(false);
        }
        else if (skin1Status == 2)
        {
            Skin1BuyButton.SetActive(false);
            Skin1EquipButton.SetActive(false);
            Skin1UnequipButton.SetActive(true);
        }
        else
        {
            Skin1BuyButton.SetActive(true);
            Skin1EquipButton.SetActive(false);
            Skin1UnequipButton.SetActive(false);
        }
    }

    // Skin 2 butonlarının durumunu güncelleyen fonksiyon
    private void UpdateSkin2Buttons()
    {
        int skin2Status = PlayerPrefs.GetInt("isSkin2");

        if (skin2Status == 1)
        {
            Skin2BuyButton.SetActive(false);
            Skin2EquipButton.SetActive(true);
            Skin2UnequipButton.SetActive(false);
        }
        else if (skin2Status == 2)
        {
            Skin2BuyButton.SetActive(false);
            Skin2EquipButton.SetActive(false);
            Skin2UnequipButton.SetActive(true);
        }
        else
        {
            Skin2BuyButton.SetActive(true);
            Skin2EquipButton.SetActive(false);
            Skin2UnequipButton.SetActive(false);
        }
    }

    // Satın alma işlemi tamamlandığında çağrılan fonksiyon
    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == skin1)
        {
            if (PlayerPrefs.GetInt("isSkin1") < 1)
            {
                PlayerPrefs.SetInt("isSkin1", 1);
                PlayerPrefs.Save();
                Debug.Log("isSkin1: " + PlayerPrefs.GetInt("isSkin1") + ", From now on Skin1 is available.");
            }
            else
            {
                Debug.Log("Skin1 is already taken");
            }

            Skin1BuyButton.SetActive(false);
            Skin1EquipButton.SetActive(true);
            Skin1UnequipButton.SetActive(false);
        }
        else if (product.definition.id == skin2)
        {
            if (PlayerPrefs.GetInt("isSkin2") < 1)
            {
                PlayerPrefs.SetInt("isSkin2", 1);
                PlayerPrefs.Save();
                Debug.Log("isSkin2: " + PlayerPrefs.GetInt("isSkin2") + ", From now on Skin2 is available.");
            }
            else
            {
                Debug.Log("Skin2 is already taken");
            }

            Skin2BuyButton.SetActive(false);
            Skin2EquipButton.SetActive(true);
            Skin2UnequipButton.SetActive(false);
        }
        else if (product.definition.id == noadv)
        {
            if (PlayerPrefs.GetInt("isAdvOn") != 0)
            {
                PlayerPrefs.SetInt("isAdvOn", 0);
                PlayerPrefs.Save();
                Debug.Log("isAdvOn: " + PlayerPrefs.GetInt("isAdvOn") + ", From now on Advertisements are off.");
            }
            else
            {
                Debug.Log("Advertisements are already off");
            }
            
            NoAdvBuyButton.SetActive(false);
            AdvTakenText.SetActive(true);
        }
    }

    // Satın alma işlemi başarısız olduğunda çağrılan fonksiyon
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(product.definition.id + " failed because " + failureReason);
    }

    // Skin 1'i giymek için çağrılan fonksiyon
    public void EquipSkin1()
    {
        PlayerPrefs.SetInt("isSkin1", 2);
        PlayerPrefs.Save();
        UpdateSkin1Buttons();

        if (PlayerPrefs.GetInt("isSkin2") == 2)
        {
            PlayerPrefs.SetInt("isSkin2", 1);
            PlayerPrefs.Save();
            UpdateSkin2Buttons();
        }
        
    }

    // Skin 2'yi giymek için çağrılan fonksiyon
    public void EquipSkin2()
    {
        PlayerPrefs.SetInt("isSkin2", 2);
        PlayerPrefs.Save();
        UpdateSkin2Buttons();
        
        if (PlayerPrefs.GetInt("isSkin1") == 2)
        {
            PlayerPrefs.SetInt("isSkin1", 1);
            PlayerPrefs.Save();
            UpdateSkin1Buttons();
        }
    }

    // Skin 1'i çıkarmak için çağrılan fonksiyon
    public void UnEquipSkin1Button()
    {
        PlayerPrefs.SetInt("isSkin1", 1);
        PlayerPrefs.Save();
        UpdateSkin1Buttons();
    }

    // Skin 2'yi çıkarmak için çağrılan fonksiyon
    public void UnEquipSkin2Button()
    {
        PlayerPrefs.SetInt("isSkin2", 1);
        PlayerPrefs.Save();
        UpdateSkin2Buttons();
    }

    // Reklamsız satın alma işlemi
    public void NoAdvB()
    {
        if (PlayerPrefs.GetInt("isAdvOn") != 0)
        {
            PlayerPrefs.SetInt("isAdvOn", 0);
            PlayerPrefs.Save();
            Debug.Log("isAdvOn: " + PlayerPrefs.GetInt("isAdvOn") + ", From now on Advertisements are off.");
        }
        else
        {
            Debug.Log("Advertisements are already off");
        }
    }
}
